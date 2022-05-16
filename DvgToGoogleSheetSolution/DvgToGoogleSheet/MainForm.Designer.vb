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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.cmbSheets = New System.Windows.Forms.ComboBox()
        Me.dgvSpreadSheet = New System.Windows.Forms.DataGridView()
        Me.cmbSpreadSheets = New System.Windows.Forms.ComboBox()
        Me.lblOne = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblTwo = New System.Windows.Forms.Label()
        Me.lblThree = New System.Windows.Forms.Label()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnFillIn = New System.Windows.Forms.Button()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabSpreadSheets = New System.Windows.Forms.TabPage()
        Me.tabSripts = New System.Windows.Forms.TabPage()
        Me.dgvScripts = New System.Windows.Forms.DataGridView()
        Me.colVariable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtScriptId = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.menu = New System.Windows.Forms.MenuStrip()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblConnectionStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvSpreadSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabSpreadSheets.SuspendLayout()
        Me.tabSripts.SuspendLayout()
        CType(Me.dgvScripts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.menu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.Enabled = False
        Me.cmbSheets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(168, 3)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(121, 21)
        Me.cmbSheets.TabIndex = 1
        '
        'dgvSpreadSheet
        '
        Me.dgvSpreadSheet.AllowUserToAddRows = False
        Me.dgvSpreadSheet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSpreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpreadSheet.Location = New System.Drawing.Point(3, 38)
        Me.dgvSpreadSheet.Name = "dgvSpreadSheet"
        Me.dgvSpreadSheet.Size = New System.Drawing.Size(1027, 399)
        Me.dgvSpreadSheet.TabIndex = 2
        '
        'cmbSpreadSheets
        '
        Me.cmbSpreadSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpreadSheets.Enabled = False
        Me.cmbSpreadSheets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSpreadSheets.FormattingEnabled = True
        Me.cmbSpreadSheets.Location = New System.Drawing.Point(22, 3)
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
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSpreadSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblTwo)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSheets)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblThree)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRead)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnFillIn)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1030, 29)
        Me.FlowLayoutPanel1.TabIndex = 5
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'lblTwo
        '
        Me.lblTwo.AutoSize = True
        Me.lblTwo.Enabled = False
        Me.lblTwo.Location = New System.Drawing.Point(149, 0)
        Me.lblTwo.Name = "lblTwo"
        Me.lblTwo.Size = New System.Drawing.Size(13, 13)
        Me.lblTwo.TabIndex = 4
        Me.lblTwo.Text = "2"
        '
        'lblThree
        '
        Me.lblThree.AutoSize = True
        Me.lblThree.Enabled = False
        Me.lblThree.Location = New System.Drawing.Point(295, 0)
        Me.lblThree.Name = "lblThree"
        Me.lblThree.Size = New System.Drawing.Size(13, 13)
        Me.lblThree.TabIndex = 4
        Me.lblThree.Text = "3"
        '
        'btnRead
        '
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(314, 3)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(75, 23)
        Me.btnRead.TabIndex = 0
        Me.btnRead.Text = "Read"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnFillIn
        '
        Me.btnFillIn.Enabled = False
        Me.btnFillIn.Location = New System.Drawing.Point(395, 3)
        Me.btnFillIn.Name = "btnFillIn"
        Me.btnFillIn.Size = New System.Drawing.Size(75, 23)
        Me.btnFillIn.TabIndex = 0
        Me.btnFillIn.Text = "Write"
        Me.btnFillIn.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabSpreadSheets)
        Me.tabControl.Controls.Add(Me.tabSripts)
        Me.tabControl.Location = New System.Drawing.Point(12, 31)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(1044, 466)
        Me.tabControl.TabIndex = 6
        '
        'tabSpreadSheets
        '
        Me.tabSpreadSheets.Controls.Add(Me.dgvSpreadSheet)
        Me.tabSpreadSheets.Controls.Add(Me.FlowLayoutPanel1)
        Me.tabSpreadSheets.Location = New System.Drawing.Point(4, 22)
        Me.tabSpreadSheets.Name = "tabSpreadSheets"
        Me.tabSpreadSheets.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSpreadSheets.Size = New System.Drawing.Size(1036, 440)
        Me.tabSpreadSheets.TabIndex = 0
        Me.tabSpreadSheets.Text = "Spreadsheets"
        Me.tabSpreadSheets.UseVisualStyleBackColor = True
        '
        'tabSripts
        '
        Me.tabSripts.Controls.Add(Me.dgvScripts)
        Me.tabSripts.Controls.Add(Me.FlowLayoutPanel2)
        Me.tabSripts.Location = New System.Drawing.Point(4, 22)
        Me.tabSripts.Name = "tabSripts"
        Me.tabSripts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSripts.Size = New System.Drawing.Size(1036, 453)
        Me.tabSripts.TabIndex = 1
        Me.tabSripts.Text = "Scripts"
        Me.tabSripts.UseVisualStyleBackColor = True
        '
        'dgvScripts
        '
        Me.dgvScripts.AllowUserToAddRows = False
        Me.dgvScripts.AllowUserToDeleteRows = False
        Me.dgvScripts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvScripts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScripts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVariable, Me.colValue})
        Me.dgvScripts.Location = New System.Drawing.Point(6, 41)
        Me.dgvScripts.Name = "dgvScripts"
        Me.dgvScripts.RowHeadersVisible = False
        Me.dgvScripts.Size = New System.Drawing.Size(514, 406)
        Me.dgvScripts.TabIndex = 7
        '
        'colVariable
        '
        Me.colVariable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colVariable.DataPropertyName = "Variable"
        Me.colVariable.HeaderText = "Variable"
        Me.colVariable.Name = "colVariable"
        '
        'colValue
        '
        Me.colValue.DataPropertyName = "Value"
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.txtScriptId)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnRun)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(6, 6)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(665, 29)
        Me.FlowLayoutPanel2.TabIndex = 6
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'txtScriptId
        '
        Me.txtScriptId.Location = New System.Drawing.Point(3, 3)
        Me.txtScriptId.Name = "txtScriptId"
        Me.txtScriptId.Size = New System.Drawing.Size(578, 20)
        Me.txtScriptId.TabIndex = 1
        '
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.Location = New System.Drawing.Point(587, 3)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 23)
        Me.btnRun.TabIndex = 0
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'menu
        '
        Me.menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem})
        Me.menu.Location = New System.Drawing.Point(0, 0)
        Me.menu.Name = "menu"
        Me.menu.Size = New System.Drawing.Size(1068, 24)
        Me.menu.TabIndex = 7
        Me.menu.Text = "MenuStrip1"
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.ConnectToolStripMenuItem.Text = "Connect"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblConnectionStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1068, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.Image = CType(resources.GetObject("lblConnectionStatus.Image"), System.Drawing.Image)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(130, 17)
        Me.lblConnectionStatus.Text = "lblConnectionStatus"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 522)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.menu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menu
        Me.Name = "MainForm"
        Me.Text = "Google API Demo"
        CType(Me.dgvSpreadSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabSpreadSheets.ResumeLayout(False)
        Me.tabSpreadSheets.PerformLayout()
        Me.tabSripts.ResumeLayout(False)
        Me.tabSripts.PerformLayout()
        CType(Me.dgvScripts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.menu.ResumeLayout(False)
        Me.menu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbSheets As ComboBox
    Friend WithEvents dgvSpreadSheet As DataGridView
    Friend WithEvents cmbSpreadSheets As ComboBox
    Friend WithEvents lblOne As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblThree As Label
    Friend WithEvents lblTwo As Label
    Friend WithEvents btnFillIn As Button
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabSpreadSheets As TabPage
    Friend WithEvents tabSripts As TabPage
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents btnRun As Button
    Friend WithEvents dgvScripts As DataGridView
    Friend WithEvents colVariable As DataGridViewTextBoxColumn
    Friend WithEvents colValue As DataGridViewTextBoxColumn
    Friend WithEvents menu As MenuStrip
    Friend WithEvents ConnectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtScriptId As TextBox
    Friend WithEvents btnRead As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblConnectionStatus As ToolStripStatusLabel
End Class
