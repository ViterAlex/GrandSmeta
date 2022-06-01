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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSpreadSheet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSpreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpreadSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSpreadSheet.Location = New System.Drawing.Point(0, 30)
        Me.dgvSpreadSheet.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvSpreadSheet.Name = "dgvSpreadSheet"
        Me.dgvSpreadSheet.Size = New System.Drawing.Size(968, 534)
        Me.dgvSpreadSheet.TabIndex = 6
        Me.dgvSpreadSheet.VirtualMode = True
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
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(968, 30)
        Me.FlowLayoutPanel1.TabIndex = 7
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'lblOne
        '
        Me.lblOne.Location = New System.Drawing.Point(4, 0)
        Me.lblOne.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOne.Name = "lblOne"
        Me.lblOne.Size = New System.Drawing.Size(96, 24)
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
        Me.cmbSpreadSheets.Location = New System.Drawing.Point(108, 3)
        Me.cmbSpreadSheets.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbSpreadSheets.Name = "cmbSpreadSheets"
        Me.cmbSpreadSheets.Size = New System.Drawing.Size(140, 23)
        Me.cmbSpreadSheets.TabIndex = 3
        '
        'lblSheets
        '
        Me.lblSheets.Enabled = False
        Me.lblSheets.Location = New System.Drawing.Point(256, 0)
        Me.lblSheets.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSheets.Name = "lblSheets"
        Me.lblSheets.Size = New System.Drawing.Size(55, 24)
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
        Me.cmbSheets.Location = New System.Drawing.Point(319, 3)
        Me.cmbSheets.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(140, 23)
        Me.cmbSheets.TabIndex = 1
        '
        'btnRead
        '
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(467, 3)
        Me.btnRead.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(88, 24)
        Me.btnRead.TabIndex = 0
        Me.btnRead.Text = "Read"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnFillIn
        '
        Me.btnFillIn.Enabled = False
        Me.btnFillIn.Location = New System.Drawing.Point(563, 3)
        Me.btnFillIn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnFillIn.Name = "btnFillIn"
        Me.btnFillIn.Size = New System.Drawing.Size(88, 24)
        Me.btnFillIn.TabIndex = 0
        Me.btnFillIn.Text = "Write"
        Me.btnFillIn.UseVisualStyleBackColor = True
        '
        'SheetsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvSpreadSheet)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "SheetsControl"
        Me.Size = New System.Drawing.Size(968, 564)
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
