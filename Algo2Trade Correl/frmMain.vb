Imports Utilities.DAL
Imports System.Threading
Imports System.IO

Public Class frmMain

#Region "Common Delegates"
    Delegate Sub SetObjectEnableDisable_Delegate(ByVal [obj] As Object, ByVal [value] As Boolean)
    Public Sub SetObjectEnableDisable_ThreadSafe(ByVal [obj] As Object, ByVal [value] As Boolean)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [obj].InvokeRequired Then
            Dim MyDelegate As New SetObjectEnableDisable_Delegate(AddressOf SetObjectEnableDisable_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[obj], [value]})
        Else
            [obj].Enabled = [value]
        End If
    End Sub

    Delegate Sub SetLabelText_Delegate(ByVal [label] As Label, ByVal [text] As String)
    Public Sub SetLabelText_ThreadSafe(ByVal [label] As Label, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New SetLabelText_Delegate(AddressOf SetLabelText_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[label], [text]})
        Else
            [label].Text = [text]
        End If
    End Sub

    Delegate Function GetLabelText_Delegate(ByVal [label] As Label) As String
    Public Function GetLabelText_ThreadSafe(ByVal [label] As Label) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New GetLabelText_Delegate(AddressOf GetLabelText_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[label]})
        Else
            Return [label].Text
        End If
    End Function

    Delegate Sub SetLabelTag_Delegate(ByVal [label] As Label, ByVal [tag] As String)
    Public Sub SetLabelTag_ThreadSafe(ByVal [label] As Label, ByVal [tag] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New SetLabelTag_Delegate(AddressOf SetLabelTag_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[label], [tag]})
        Else
            [label].Tag = [tag]
        End If
    End Sub

    Delegate Function GetLabelTag_Delegate(ByVal [label] As Label) As String
    Public Function GetLabelTag_ThreadSafe(ByVal [label] As Label) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New GetLabelTag_Delegate(AddressOf GetLabelTag_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[label]})
        Else
            Return [label].Tag
        End If
    End Function
    Delegate Sub SetToolStripLabel_Delegate(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripStatusLabel, ByVal [text] As String)
    Public Sub SetToolStripLabel_ThreadSafe(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripStatusLabel, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [toolStrip].InvokeRequired Then
            Dim MyDelegate As New SetToolStripLabel_Delegate(AddressOf SetToolStripLabel_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[toolStrip], [label], [text]})
        Else
            [label].Text = [text]
        End If
    End Sub

    Delegate Function GetToolStripLabel_Delegate(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripLabel) As String
    Public Function GetToolStripLabel_ThreadSafe(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripLabel) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [toolStrip].InvokeRequired Then
            Dim MyDelegate As New GetToolStripLabel_Delegate(AddressOf GetToolStripLabel_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[toolStrip], [label]})
        Else
            Return [label].Text
        End If
    End Function

    Delegate Function GetDateTimePickerValue_Delegate(ByVal [dateTimePicker] As DateTimePicker) As Date
    Public Function GetDateTimePickerValue_ThreadSafe(ByVal [dateTimePicker] As DateTimePicker) As Date
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [dateTimePicker].InvokeRequired Then
            Dim MyDelegate As New GetDateTimePickerValue_Delegate(AddressOf GetDateTimePickerValue_ThreadSafe)
            Return Me.Invoke(MyDelegate, New DateTimePicker() {[dateTimePicker]})
        Else
            Return [dateTimePicker].Value
        End If
    End Function

    Delegate Function GetNumericUpDownValue_Delegate(ByVal [numericUpDown] As NumericUpDown) As Integer
    Public Function GetNumericUpDownValue_ThreadSafe(ByVal [numericUpDown] As NumericUpDown) As Integer
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [numericUpDown].InvokeRequired Then
            Dim MyDelegate As New GetNumericUpDownValue_Delegate(AddressOf GetNumericUpDownValue_ThreadSafe)
            Return Me.Invoke(MyDelegate, New NumericUpDown() {[numericUpDown]})
        Else
            Return [numericUpDown].Value
        End If
    End Function

    Delegate Function GetComboBoxIndex_Delegate(ByVal [combobox] As ComboBox) As Integer
    Public Function GetComboBoxIndex_ThreadSafe(ByVal [combobox] As ComboBox) As Integer
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [combobox].InvokeRequired Then
            Dim MyDelegate As New GetComboBoxIndex_Delegate(AddressOf GetComboBoxIndex_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[combobox]})
        Else
            Return [combobox].SelectedIndex
        End If
    End Function

    Delegate Function GetComboBoxItem_Delegate(ByVal [ComboBox] As ComboBox) As String
    Public Function GetComboBoxItem_ThreadSafe(ByVal [ComboBox] As ComboBox) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [ComboBox].InvokeRequired Then
            Dim MyDelegate As New GetComboBoxItem_Delegate(AddressOf GetComboBoxItem_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[ComboBox]})
        Else
            Return [ComboBox].SelectedItem.ToString
        End If
    End Function

    Delegate Function GetTextBoxText_Delegate(ByVal [textBox] As TextBox) As String
    Public Function GetTextBoxText_ThreadSafe(ByVal [textBox] As TextBox) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [textBox].InvokeRequired Then
            Dim MyDelegate As New GetTextBoxText_Delegate(AddressOf GetTextBoxText_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[textBox]})
        Else
            Return [textBox].Text
        End If
    End Function

    Delegate Function GetCheckBoxChecked_Delegate(ByVal [checkBox] As CheckBox) As Boolean
    Public Function GetCheckBoxChecked_ThreadSafe(ByVal [checkBox] As CheckBox) As Boolean
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [checkBox].InvokeRequired Then
            Dim MyDelegate As New GetCheckBoxChecked_Delegate(AddressOf GetCheckBoxChecked_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[checkBox]})
        Else
            Return [checkBox].Checked
        End If
    End Function

    Delegate Sub SetDatagridBindDatatable_Delegate(ByVal [datagrid] As DataGridView, ByVal [table] As DataTable)
    Public Sub SetDatagridBindDatatable_ThreadSafe(ByVal [datagrid] As DataGridView, ByVal [table] As DataTable)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [datagrid].InvokeRequired Then
            Dim MyDelegate As New SetDatagridBindDatatable_Delegate(AddressOf SetDatagridBindDatatable_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[datagrid], [table]})
        Else
            [datagrid].DataSource = [table]
        End If
    End Sub
#End Region

#Region "Event Handlers"
    Private _canceller As CancellationTokenSource
    Private Sub OnHeartbeat(message As String)
        SetLabelText_ThreadSafe(lblProgress, message)
    End Sub
    Private Sub OnHeartbeatMain(message As String)
        SetLabelText_ThreadSafe(lblProgressMain, message)
    End Sub
    Private Sub OnDocumentDownloadComplete()
        'OnHeartbeat("Document download compelete")
    End Sub
    Private Sub OnDocumentRetryStatus(currentTry As Integer, totalTries As Integer)
        OnHeartbeat(String.Format("Try #{0}/{1}: Connecting...", currentTry, totalTries))
    End Sub
    Public Sub OnWaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
        OnHeartbeat(String.Format("{0}, waiting {1}/{2} secs", msg, elapsedSecs, totalSecs))
    End Sub
#End Region

    Private Sub InitUI(ByVal value As Boolean)
        SetObjectEnableDisable_ThreadSafe(btnView, value)
        SetObjectEnableDisable_ThreadSafe(pnlDetails, value)
        SetObjectEnableDisable_ThreadSafe(btnCancel, Not value)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _canceller.Cancel()
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitUI(True)
        txtInstruments.Text = My.Settings.Intrument
        cmbCategory.SelectedIndex = My.Settings.Category
        If My.Settings.LastDate <> Date.MinValue Then dtpckrLastDate.Value = My.Settings.LastDate
        nmrcTimeframe.Value = My.Settings.Timeframe
        nmrcNumberOfCandles.Value = My.Settings.NumberOfCandles
    End Sub
    Private Async Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        My.Settings.Intrument = txtInstruments.Text
        My.Settings.Category = cmbCategory.SelectedIndex
        My.Settings.LastDate = dtpckrLastDate.Value
        My.Settings.Timeframe = nmrcTimeframe.Value
        My.Settings.NumberOfCandles = nmrcNumberOfCandles.Value
        My.Settings.Save()
        InitUI(False)

        _canceller = New CancellationTokenSource
        Await Task.Run(AddressOf ViewDataAsync).ConfigureAwait(False)
    End Sub
    Private Async Function ViewDataAsync() As Task
        Try
            Dim lastDate As Date = GetDateTimePickerValue_ThreadSafe(dtpckrLastDate)
            Dim names As String = GetTextBoxText_ThreadSafe(txtInstruments)
            Dim category As String = GetComboBoxItem_ThreadSafe(cmbCategory)
            Dim timeframe As Integer = GetNumericUpDownValue_ThreadSafe(nmrcTimeframe)
            Dim numberOfCandles As Integer = GetNumericUpDownValue_ThreadSafe(nmrcNumberOfCandles)

            Dim startDate As Date = Date.MinValue
            Dim totalNumberOfMinCandles As Integer = Integer.MinValue
            Select Case category
                Case "Intraday Cash", "Intraday Future", "EOD Cash", "EOD Future"
                    totalNumberOfMinCandles = 375
                Case "Intraday Currency", "EOD Currency"
                    totalNumberOfMinCandles = 480
                Case "Intraday Commodity", "EOD Commodity"
                    totalNumberOfMinCandles = 870
                Case Else
                    Throw New NotImplementedException
            End Select
            If totalNumberOfMinCandles <> Integer.MinValue Then
                Dim totalNumberOfXMinCandles As Integer = Math.Ceiling(totalNumberOfMinCandles / timeframe)
                Dim numberOfDays As Integer = Math.Ceiling(numberOfCandles / totalNumberOfXMinCandles)
                Dim numberOfDaysWithOffset As Integer = numberOfDays + Math.Ceiling(numberOfDays / 5) * 2 + 5
                startDate = lastDate.AddDays(numberOfDaysWithOffset * -1)
            End If

            Dim instruments() As String = names.Trim.Split(vbCrLf)

            If instruments IsNot Nothing AndAlso instruments.Count > 0 AndAlso startDate <> Date.MinValue Then
                Dim outputFileName As String = Path.Combine(My.Application.Info.DirectoryPath, String.Format("Data Output {0} {1}_{2}_{3}.xlsx", category, Now.Hour, Now.Minute, Now.Second))
                Using excelWriter As New ExcelHelper(outputFileName, ExcelHelper.ExcelOpenStatus.OpenAfreshForWrite, ExcelHelper.ExcelSaveType.XLS_XLSX, _canceller)
                    AddHandler excelWriter.Heartbeat, AddressOf OnHeartbeat
                    AddHandler excelWriter.WaitingFor, AddressOf OnWaitingFor

                    excelWriter.SaveExcel()
                End Using
                Dim counter As Integer = 0
                For Each runningInstrument In instruments
                    counter += 1
                    Dim instrumentName As String = runningInstrument.Trim

                    OnHeartbeatMain(String.Format("Running for:{0}  ({1}/{2})", instrumentName.Trim, counter, instruments.Count))

                    Dim rule As GetRawCandle = New GetRawCandle(_canceller, category, instrumentName.Trim, timeframe, numberOfCandles)
                    AddHandler rule.Heartbeat, AddressOf OnHeartbeat
                    AddHandler rule.WaitingFor, AddressOf OnWaitingFor
                    AddHandler rule.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    AddHandler rule.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete

                    Dim dt As DataTable = Await rule.RunAsync(startDate, lastDate).ConfigureAwait(False)

                    WriteToExcel(outputFileName, dt, instrumentName.Trim)
                Next
            End If
        Catch ox As OperationCanceledException
            MsgBox(String.Format("Error: {0}", ox.Message), MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox(String.Format("Error: {0}", ex.Message), MsgBoxStyle.Critical)
        Finally
            OnHeartbeat("Process Complete")
            OnHeartbeatMain("")
            InitUI(True)
        End Try
    End Function
    Private Sub WriteToExcel(ByVal outputFileName As String, ByVal dataToWrite As DataTable, ByVal sheetName As String)
        If dataToWrite IsNot Nothing Then
            Using excelWriter As New ExcelHelper(outputFileName, ExcelHelper.ExcelOpenStatus.OpenExistingForReadWrite, ExcelHelper.ExcelSaveType.XLS_XLSX, _canceller)
                AddHandler excelWriter.Heartbeat, AddressOf OnHeartbeat
                AddHandler excelWriter.WaitingFor, AddressOf OnWaitingFor

                excelWriter.CreateNewSheet(sheetName)
                excelWriter.SetActiveSheet(sheetName)

                OnHeartbeat("Creating 2D array")
                Dim mainRawData(dataToWrite.Rows.Count, dataToWrite.Columns.Count - 1) As Object
                Dim c As Integer = 0
                For Each column As DataColumn In dataToWrite.Columns
                    mainRawData(0, c) = column.ColumnName
                    c += 1
                Next

                For i As Integer = 1 To dataToWrite.Rows.Count
                    OnHeartbeat(String.Format("Row number:{0} of {1}", i, dataToWrite.Rows.Count))
                    For j As Integer = 0 To dataToWrite.Columns.Count - 1
                        mainRawData(i, j) = dataToWrite.Rows(i - 1).Item(j)
                    Next
                Next

                Dim range As String = excelWriter.GetNamedRange(1, dataToWrite.Rows.Count, 1, dataToWrite.Columns.Count - 1)
                excelWriter.WriteArrayToExcel(mainRawData, range)

                excelWriter.SaveExcel()
            End Using
        End If
    End Sub
End Class
