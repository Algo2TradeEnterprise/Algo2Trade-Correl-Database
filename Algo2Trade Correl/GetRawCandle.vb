Imports Algo2TradeBLL
Imports System.Threading
Public Class GetRawCandle

#Region "Events/Event handlers"
    Public Event DocumentDownloadComplete()
    Public Event DocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
    Public Event Heartbeat(ByVal msg As String)
    Public Event WaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
    'The below functions are needed to allow the derived classes to raise the above two events
    Protected Overridable Sub OnDocumentDownloadComplete()
        RaiseEvent DocumentDownloadComplete()
    End Sub
    Protected Overridable Sub OnDocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
        RaiseEvent DocumentRetryStatus(currentTry, totalTries)
    End Sub
    Protected Overridable Sub OnHeartbeat(ByVal msg As String)
        RaiseEvent Heartbeat(msg)
    End Sub
    Protected Overridable Sub OnWaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
        RaiseEvent WaitingFor(elapsedSecs, totalSecs, msg)
    End Sub
#End Region

    Protected _canceller As CancellationTokenSource
    Protected _category As String
    Protected _name As String
    Protected _timeFrame As Integer
    Protected _numberOfCandles As Integer
    Protected _common As Common

    Public Sub New(ByVal canceller As CancellationTokenSource,
                   ByVal stockCategory As String,
                   ByVal stockName As String,
                   ByVal timeFrame As Integer,
                   ByVal numberOfCandles As Integer)
        _canceller = canceller
        _category = stockCategory
        _name = stockName
        _timeFrame = timeFrame
        _numberOfCandles = numberOfCandles

        _common = New Common(_canceller)
        AddHandler _common.Heartbeat, AddressOf OnHeartbeat
        AddHandler _common.WaitingFor, AddressOf OnWaitingFor
        AddHandler _common.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
        AddHandler _common.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
    End Sub

    Public Async Function RunAsync(ByVal startDate As Date, ByVal endDate As Date) As Task(Of DataTable)
        Dim ret As DataTable = Nothing
        Select Case _category
            Case "Intraday Cash"
                ret = Await RunCashAsync(startDate, endDate).ConfigureAwait(False)
            Case Else
                ret = Await RunOthersAsync(startDate, endDate).ConfigureAwait(False)
        End Select
        Return ret
    End Function

    Private Async Function RunOthersAsync(ByVal startDate As Date, ByVal endDate As Date) As Task(Of DataTable)
        Await Task.Delay(0).ConfigureAwait(False)
        Dim ret As New DataTable
        ret.Columns.Add("Date")
        ret.Columns.Add("Trading Symbol")
        ret.Columns.Add("Open")
        ret.Columns.Add("Low")
        ret.Columns.Add("High")
        ret.Columns.Add("Close")
        ret.Columns.Add("Volume")

        Dim chkDate As Date = startDate
        While chkDate <= endDate
            _canceller.Token.ThrowIfCancellationRequested()
            Dim stockList As List(Of String) = New List(Of String) From {_name}

            _canceller.Token.ThrowIfCancellationRequested()
            If stockList IsNot Nothing AndAlso stockList.Count > 0 Then
                For Each stock In stockList
                    _canceller.Token.ThrowIfCancellationRequested()
                    Dim stockPayload As Dictionary(Of Date, Payload) = Nothing
                    Dim exchangeStartTime As Date = Date.MinValue
                    Select Case _category
                        Case "Intraday Cash"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 15, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.Intraday_Cash, stock, chkDate.AddDays(-7), chkDate)
                        Case "Intraday Currency"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 0, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.Intraday_Currency, stock, chkDate.AddDays(-7), chkDate)
                        Case "Intraday Commodity"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 0, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.Intraday_Commodity, stock, chkDate.AddDays(-7), chkDate)
                        Case "Intraday Future"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 15, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.Intraday_Futures, stock, chkDate.AddDays(-7), chkDate)
                        Case "EOD Cash"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 15, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.EOD_Cash, stock, chkDate.AddDays(-7), chkDate)
                        Case "EOD Currency"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 0, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.EOD_Currency, stock, chkDate.AddDays(-7), chkDate)
                        Case "EOD Commodity"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 0, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.EOD_Commodity, stock, chkDate.AddDays(-7), chkDate)
                        Case "EOD Future"
                            exchangeStartTime = New Date(chkDate.Year, chkDate.Month, chkDate.Day, 9, 15, 0)
                            stockPayload = _common.GetRawPayload(Common.DataBaseTable.EOD_Futures, stock, chkDate.AddDays(-7), chkDate)
                        Case Else
                            Throw New NotImplementedException
                    End Select
                    _canceller.Token.ThrowIfCancellationRequested()
                    If stockPayload IsNot Nothing AndAlso stockPayload.Count > 0 Then
                        Dim inputPayload As Dictionary(Of Date, Payload) = Nothing
                        If _timeFrame > 1 Then
                            inputPayload = Common.ConvertPayloadsToXMinutes(stockPayload, _timeFrame, exchangeStartTime)
                        Else
                            inputPayload = stockPayload
                        End If
                        _canceller.Token.ThrowIfCancellationRequested()
                        Dim currentDayPayload As Dictionary(Of Date, Payload) = Nothing
                        For Each runningPayload In inputPayload.Skip(Math.Max(0, inputPayload.Count() - _numberOfCandles))
                            _canceller.Token.ThrowIfCancellationRequested()
                            If currentDayPayload Is Nothing Then currentDayPayload = New Dictionary(Of Date, Payload)
                            currentDayPayload.Add(runningPayload.Key, runningPayload.Value)
                        Next
                        'Main Logic
                        If currentDayPayload IsNot Nothing AndAlso currentDayPayload.Count > 0 Then
                            For Each runningPayload In currentDayPayload.Keys
                                _canceller.Token.ThrowIfCancellationRequested()
                                Dim row As DataRow = ret.NewRow
                                row("Date") = currentDayPayload(runningPayload).PayloadDate
                                row("Trading Symbol") = currentDayPayload(runningPayload).TradingSymbol
                                row("Open") = currentDayPayload(runningPayload).Open
                                row("Low") = currentDayPayload(runningPayload).Low
                                row("High") = currentDayPayload(runningPayload).High
                                row("Close") = currentDayPayload(runningPayload).Close
                                row("Volume") = currentDayPayload(runningPayload).Volume
                                ret.Rows.Add(row)
                            Next
                        End If
                    End If
                Next
            End If
            chkDate = chkDate.AddDays(1)
        End While
        Return ret
    End Function

    Private Async Function RunCashAsync(ByVal startDate As Date, ByVal endDate As Date) As Task(Of DataTable)
        Await Task.Delay(0).ConfigureAwait(False)
        Dim ret As New DataTable
        ret.Columns.Add("Date")
        ret.Columns.Add("Trading Symbol")
        ret.Columns.Add("Open")
        ret.Columns.Add("Low")
        ret.Columns.Add("High")
        ret.Columns.Add("Close")
        ret.Columns.Add("Volume")

        _canceller.Token.ThrowIfCancellationRequested()
        Dim stockList As List(Of String) = New List(Of String) From {_name}

        _canceller.Token.ThrowIfCancellationRequested()
        If stockList IsNot Nothing AndAlso stockList.Count > 0 Then
            For Each stock In stockList
                _canceller.Token.ThrowIfCancellationRequested()
                Dim stockPayload As Dictionary(Of Date, Payload) = _common.GetRawPayload(Common.DataBaseTable.Intraday_Cash, stock, startDate.Date.AddDays(-7), endDate.Date)
                _canceller.Token.ThrowIfCancellationRequested()
                If stockPayload IsNot Nothing AndAlso stockPayload.Count > 0 Then
                    Dim inputPayload As Dictionary(Of Date, Payload) = Nothing
                    If _timeFrame > 1 Then
                        Throw New NotImplementedException
                        inputPayload = Common.ConvertPayloadsToXMinutes(stockPayload, _timeFrame, New Date(endDate.Year, endDate.Month, endDate.Day, 9, 15, 0))
                    Else
                        inputPayload = stockPayload
                    End If
                    _canceller.Token.ThrowIfCancellationRequested()
                    Dim currentDayPayload As Dictionary(Of Date, Payload) = Nothing
                    For Each runningPayload In inputPayload.Skip(Math.Max(0, inputPayload.Count() - _numberOfCandles))
                        _canceller.Token.ThrowIfCancellationRequested()
                        If currentDayPayload Is Nothing Then currentDayPayload = New Dictionary(Of Date, Payload)
                        currentDayPayload.Add(runningPayload.Key, runningPayload.Value)
                    Next
                    'Main Logic
                    If currentDayPayload IsNot Nothing AndAlso currentDayPayload.Count > 0 Then
                        For Each runningPayload In currentDayPayload.Keys
                            _canceller.Token.ThrowIfCancellationRequested()
                            Dim row As DataRow = ret.NewRow
                            row("Date") = currentDayPayload(runningPayload).PayloadDate
                            row("Trading Symbol") = currentDayPayload(runningPayload).TradingSymbol
                            row("Open") = currentDayPayload(runningPayload).Open
                            row("Low") = currentDayPayload(runningPayload).Low
                            row("High") = currentDayPayload(runningPayload).High
                            row("Close") = currentDayPayload(runningPayload).Close
                            row("Volume") = currentDayPayload(runningPayload).Volume
                            ret.Rows.Add(row)
                        Next
                    End If
                End If
            Next
        End If
        Return ret
    End Function
End Class