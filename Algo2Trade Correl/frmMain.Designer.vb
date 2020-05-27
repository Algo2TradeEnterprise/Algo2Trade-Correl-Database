<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.nmrcNumberOfCandles = New System.Windows.Forms.NumericUpDown()
        Me.nmrcTimeframe = New System.Windows.Forms.NumericUpDown()
        Me.lblNumberOfCandles = New System.Windows.Forms.Label()
        Me.lblTimeframe = New System.Windows.Forms.Label()
        Me.txtInstruments = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpckrLastDate = New System.Windows.Forms.DateTimePicker()
        Me.lblLastDate = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblProgressMain = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.pnlDetails.SuspendLayout()
        CType(Me.nmrcNumberOfCandles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcTimeframe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDetails
        '
        Me.pnlDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetails.Controls.Add(Me.nmrcNumberOfCandles)
        Me.pnlDetails.Controls.Add(Me.nmrcTimeframe)
        Me.pnlDetails.Controls.Add(Me.lblNumberOfCandles)
        Me.pnlDetails.Controls.Add(Me.lblTimeframe)
        Me.pnlDetails.Controls.Add(Me.txtInstruments)
        Me.pnlDetails.Controls.Add(Me.Label4)
        Me.pnlDetails.Controls.Add(Me.dtpckrLastDate)
        Me.pnlDetails.Controls.Add(Me.lblLastDate)
        Me.pnlDetails.Controls.Add(Me.cmbCategory)
        Me.pnlDetails.Controls.Add(Me.lblCategory)
        Me.pnlDetails.Location = New System.Drawing.Point(3, 11)
        Me.pnlDetails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(627, 197)
        Me.pnlDetails.TabIndex = 1
        '
        'nmrcNumberOfCandles
        '
        Me.nmrcNumberOfCandles.Location = New System.Drawing.Point(436, 110)
        Me.nmrcNumberOfCandles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nmrcNumberOfCandles.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.nmrcNumberOfCandles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmrcNumberOfCandles.Name = "nmrcNumberOfCandles"
        Me.nmrcNumberOfCandles.Size = New System.Drawing.Size(109, 22)
        Me.nmrcNumberOfCandles.TabIndex = 32
        Me.nmrcNumberOfCandles.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nmrcTimeframe
        '
        Me.nmrcTimeframe.Location = New System.Drawing.Point(436, 78)
        Me.nmrcTimeframe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nmrcTimeframe.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nmrcTimeframe.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmrcTimeframe.Name = "nmrcTimeframe"
        Me.nmrcTimeframe.Size = New System.Drawing.Size(109, 22)
        Me.nmrcTimeframe.TabIndex = 31
        Me.nmrcTimeframe.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblNumberOfCandles
        '
        Me.lblNumberOfCandles.AutoSize = True
        Me.lblNumberOfCandles.Location = New System.Drawing.Point(292, 112)
        Me.lblNumberOfCandles.Name = "lblNumberOfCandles"
        Me.lblNumberOfCandles.Size = New System.Drawing.Size(136, 17)
        Me.lblNumberOfCandles.TabIndex = 30
        Me.lblNumberOfCandles.Text = "Number Of Candles:"
        '
        'lblTimeframe
        '
        Me.lblTimeframe.AutoSize = True
        Me.lblTimeframe.Location = New System.Drawing.Point(292, 80)
        Me.lblTimeframe.Name = "lblTimeframe"
        Me.lblTimeframe.Size = New System.Drawing.Size(79, 17)
        Me.lblTimeframe.TabIndex = 29
        Me.lblTimeframe.Text = "Timeframe:"
        '
        'txtInstruments
        '
        Me.txtInstruments.Location = New System.Drawing.Point(12, 30)
        Me.txtInstruments.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtInstruments.Multiline = True
        Me.txtInstruments.Name = "txtInstruments"
        Me.txtInstruments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInstruments.Size = New System.Drawing.Size(273, 153)
        Me.txtInstruments.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(280, 17)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Instrument Names: (Seperated by new line)"
        '
        'dtpckrLastDate
        '
        Me.dtpckrLastDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpckrLastDate.Location = New System.Drawing.Point(436, 43)
        Me.dtpckrLastDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpckrLastDate.Name = "dtpckrLastDate"
        Me.dtpckrLastDate.Size = New System.Drawing.Size(108, 22)
        Me.dtpckrLastDate.TabIndex = 26
        '
        'lblLastDate
        '
        Me.lblLastDate.AutoSize = True
        Me.lblLastDate.Location = New System.Drawing.Point(292, 46)
        Me.lblLastDate.Name = "lblLastDate"
        Me.lblLastDate.Size = New System.Drawing.Size(73, 17)
        Me.lblLastDate.TabIndex = 24
        Me.lblLastDate.Text = "Last Date:"
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Items.AddRange(New Object() {"Intraday Cash", "Intraday Currency", "Intraday Commodity", "Intraday Future", "EOD Cash", "EOD Currency", "EOD Commodity", "EOD Future"})
        Me.cmbCategory.Location = New System.Drawing.Point(436, 7)
        Me.cmbCategory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(183, 24)
        Me.cmbCategory.TabIndex = 19
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(292, 11)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(139, 17)
        Me.lblCategory.TabIndex = 18
        Me.lblCategory.Text = "Instrument Category:"
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.Location = New System.Drawing.Point(4, 250)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(740, 63)
        Me.lblProgress.TabIndex = 19
        Me.lblProgress.Text = "Progess Status ....."
        '
        'lblProgressMain
        '
        Me.lblProgressMain.Location = New System.Drawing.Point(5, 214)
        Me.lblProgressMain.Name = "lblProgressMain"
        Me.lblProgressMain.Size = New System.Drawing.Size(737, 30)
        Me.lblProgressMain.TabIndex = 26
        Me.lblProgressMain.Text = "Total Progress ....."
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancel.Location = New System.Drawing.Point(639, 58)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 42)
        Me.btnCancel.TabIndex = 33
        Me.btnCancel.Text = "Stop"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnView.Location = New System.Drawing.Point(639, 9)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 42)
        Me.btnView.TabIndex = 32
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 318)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.lblProgressMain)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pnlDetails)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Algo2Trade Correl"
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        CType(Me.nmrcNumberOfCandles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcTimeframe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblProgress As Label
    Friend WithEvents dtpckrLastDate As DateTimePicker
    Friend WithEvents lblLastDate As Label
    Friend WithEvents lblProgressMain As Label
    Friend WithEvents txtInstruments As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNumberOfCandles As Label
    Friend WithEvents lblTimeframe As Label
    Friend WithEvents nmrcNumberOfCandles As NumericUpDown
    Friend WithEvents nmrcTimeframe As NumericUpDown
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnView As Button
End Class
