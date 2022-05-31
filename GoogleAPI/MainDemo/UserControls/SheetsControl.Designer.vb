<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SheetsControl
    Inherits BaseUC

    'UserControl overrides dispose to clean up the component list.
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
        Me.dgvSpreadSheet = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblOne = New System.Windows.Forms.Label()
        Me.cmbSpreadSheets = New System.Windows.Forms.ComboBox()
        Me.lblSheets = New System.Windows.Forms.Label()
        Me.cmbSheets = New System.Windows.Forms.ComboBox()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnFillIn = New System.Windows.Forms.Button()
        CType(Me.dgvSpreadSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSpreadSheet
        '
        Me.dgvSpreadSheet.AllowUserToAddRows = False
        Me.dgvSpreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpreadSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSpreadSheet.Location = New System.Drawing.Point(0, 27)
        Me.dgvSpreadSheet.Name = "dgvSpreadSheet"
        Me.dgvSpreadSheet.Size = New System.Drawing.Size(830, 487)
        Me.dgvSpreadSheet.TabIndex = 6
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.lblOne)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSpreadSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRead)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnFillIn)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(830, 27)
        Me.FlowLayoutPanel1.TabIndex = 7
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'lblOne
        '
        Me.lblOne.Location = New System.Drawing.Point(3, 0)
        Me.lblOne.Name = "lblOne"
        Me.lblOne.Size = New System.Drawing.Size(82, 21)
        Me.lblOne.TabIndex = 4
        Me.lblOne.Text = "Spreadsheets:"
        Me.lblOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSpreadSheets
        '
        Me.cmbSpreadSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpreadSheets.Enabled = False
        Me.cmbSpreadSheets.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSpreadSheets.FormattingEnabled = True
        Me.cmbSpreadSheets.Location = New System.Drawing.Point(91, 3)
        Me.cmbSpreadSheets.Name = "cmbSpreadSheets"
        Me.cmbSpreadSheets.Size = New System.Drawing.Size(121, 21)
        Me.cmbSpreadSheets.TabIndex = 3
        '
        'lblSheets
        '
        Me.lblSheets.Enabled = False
        Me.lblSheets.Location = New System.Drawing.Point(218, 0)
        Me.lblSheets.Name = "lblSheets"
        Me.lblSheets.Size = New System.Drawing.Size(47, 21)
        Me.lblSheets.TabIndex = 4
        Me.lblSheets.Text = "Sheets:"
        Me.lblSheets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.Enabled = False
        Me.cmbSheets.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(271, 3)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(121, 21)
        Me.cmbSheets.TabIndex = 1
        '
        'btnRead
        '
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(398, 3)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(75, 21)
        Me.btnRead.TabIndex = 0
        Me.btnRead.Text = "Read"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnFillIn
        '
        Me.btnFillIn.Enabled = False
        Me.btnFillIn.Location = New System.Drawing.Point(479, 3)
        Me.btnFillIn.Name = "btnFillIn"
        Me.btnFillIn.Size = New System.Drawing.Size(75, 21)
        Me.btnFillIn.TabIndex = 0
        Me.btnFillIn.Text = "Write"
        Me.btnFillIn.UseVisualStyleBackColor = True
        '
        'SheetsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvSpreadSheet)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "SheetsControl"
        Me.Size = New System.Drawing.Size(830, 514)
        CType(Me.dgvSpreadSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSpreadSheet As DataGridView
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblOne As Label
    Friend WithEvents cmbSpreadSheets As ComboBox
    Friend WithEvents lblSheets As Label
    Friend WithEvents cmbSheets As ComboBox
    Friend WithEvents btnRead As Button
    Friend WithEvents btnFillIn As Button
End Class
