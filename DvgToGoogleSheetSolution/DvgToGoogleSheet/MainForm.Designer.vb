<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.cmbSheets = New System.Windows.Forms.ComboBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cmbSpreadSheets = New System.Windows.Forms.ComboBox()
        Me.lblOne = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSecond = New System.Windows.Forms.Label()
        Me.lblThree = New System.Windows.Forms.Label()
        Me.lblFour = New System.Windows.Forms.Label()
        Me.btnFillIn = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(22, 3)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.Enabled = False
        Me.cmbSheets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(268, 3)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(121, 21)
        Me.cmbSheets.TabIndex = 1
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 47)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(776, 391)
        Me.dgv.TabIndex = 2
        '
        'cmbSpreadSheets
        '
        Me.cmbSpreadSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpreadSheets.Enabled = False
        Me.cmbSpreadSheets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSpreadSheets.FormattingEnabled = True
        Me.cmbSpreadSheets.Location = New System.Drawing.Point(122, 3)
        Me.cmbSpreadSheets.Name = "cmbSpreadSheets"
        Me.cmbSpreadSheets.Size = New System.Drawing.Size(121, 21)
        Me.cmbSpreadSheets.TabIndex = 3
        '
        'lblOne
        '
        Me.lblOne.AutoSize = True
        Me.lblOne.Location = New System.Drawing.Point(3, 0)
        Me.lblOne.Name = "lblOne"
        Me.lblOne.Size = New System.Drawing.Size(13, 13)
        Me.lblOne.TabIndex = 4
        Me.lblOne.Text = "1"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.lblOne)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnConnect)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblSecond)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSpreadSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblThree)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblFour)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnFillIn)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(492, 29)
        Me.FlowLayoutPanel1.TabIndex = 5
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'lblSecond
        '
        Me.lblSecond.AutoSize = True
        Me.lblSecond.Enabled = False
        Me.lblSecond.Location = New System.Drawing.Point(103, 0)
        Me.lblSecond.Name = "lblSecond"
        Me.lblSecond.Size = New System.Drawing.Size(13, 13)
        Me.lblSecond.TabIndex = 4
        Me.lblSecond.Text = "2"
        '
        'lblThree
        '
        Me.lblThree.AutoSize = True
        Me.lblThree.Enabled = False
        Me.lblThree.Location = New System.Drawing.Point(249, 0)
        Me.lblThree.Name = "lblThree"
        Me.lblThree.Size = New System.Drawing.Size(13, 13)
        Me.lblThree.TabIndex = 4
        Me.lblThree.Text = "3"
        '
        'lblFour
        '
        Me.lblFour.AutoSize = True
        Me.lblFour.Enabled = False
        Me.lblFour.Location = New System.Drawing.Point(395, 0)
        Me.lblFour.Name = "lblFour"
        Me.lblFour.Size = New System.Drawing.Size(13, 13)
        Me.lblFour.TabIndex = 4
        Me.lblFour.Text = "4"
        '
        'btnFillIn
        '
        Me.btnFillIn.Enabled = False
        Me.btnFillIn.Location = New System.Drawing.Point(414, 3)
        Me.btnFillIn.Name = "btnFillIn"
        Me.btnFillIn.Size = New System.Drawing.Size(75, 23)
        Me.btnFillIn.TabIndex = 0
        Me.btnFillIn.Text = "Fill in"
        Me.btnFillIn.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents cmbSheets As ComboBox
    Friend WithEvents dgv As DataGridView
    Friend WithEvents cmbSpreadSheets As ComboBox
    Friend WithEvents lblOne As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblSecond As Label
    Friend WithEvents lblThree As Label
    Friend WithEvents lblFour As Label
    Friend WithEvents btnFillIn As Button
End Class
