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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.cmbSheets = New System.Windows.Forms.ComboBox()
        Me.dgvSpreadSheet = New System.Windows.Forms.DataGridView()
        Me.cmbSpreadSheets = New System.Windows.Forms.ComboBox()
        Me.lblOne = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSheets = New System.Windows.Forms.Label()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnFillIn = New System.Windows.Forms.Button()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabSpreadSheets = New System.Windows.Forms.TabPage()
        Me.tabSripts = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.dgvParams = New System.Windows.Forms.DataGridView()
        Me.colParam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbSourceFiles = New System.Windows.Forms.ComboBox()
        Me.cmbVersions = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbFunctions = New System.Windows.Forms.ComboBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtScriptId = New System.Windows.Forms.TextBox()
        Me.btnGetSource = New System.Windows.Forms.Button()
        Me.menu = New System.Windows.Forms.MenuStrip()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblConnectionStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvSpreadSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabSpreadSheets.SuspendLayout()
        Me.tabSripts.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvParams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.menu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        'dgvSpreadSheet
        '
        Me.dgvSpreadSheet.AllowUserToAddRows = False
        Me.dgvSpreadSheet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSpreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpreadSheet.Location = New System.Drawing.Point(3, 38)
        Me.dgvSpreadSheet.Name = "dgvSpreadSheet"
        Me.dgvSpreadSheet.Size = New System.Drawing.Size(879, 341)
        Me.dgvSpreadSheet.TabIndex = 2
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
        'lblOne
        '
        Me.lblOne.Location = New System.Drawing.Point(3, 0)
        Me.lblOne.Name = "lblOne"
        Me.lblOne.Size = New System.Drawing.Size(82, 21)
        Me.lblOne.TabIndex = 4
        Me.lblOne.Text = "Spreadsheets:"
        Me.lblOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(882, 27)
        Me.FlowLayoutPanel1.TabIndex = 5
        Me.FlowLayoutPanel1.WrapContents = False
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
        Me.tabControl.Size = New System.Drawing.Size(896, 411)
        Me.tabControl.TabIndex = 6
        '
        'tabSpreadSheets
        '
        Me.tabSpreadSheets.Controls.Add(Me.dgvSpreadSheet)
        Me.tabSpreadSheets.Controls.Add(Me.FlowLayoutPanel1)
        Me.tabSpreadSheets.Location = New System.Drawing.Point(4, 22)
        Me.tabSpreadSheets.Name = "tabSpreadSheets"
        Me.tabSpreadSheets.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSpreadSheets.Size = New System.Drawing.Size(888, 385)
        Me.tabSpreadSheets.TabIndex = 0
        Me.tabSpreadSheets.Text = "Spreadsheets"
        Me.tabSpreadSheets.UseVisualStyleBackColor = True
        '
        'tabSripts
        '
        Me.tabSripts.Controls.Add(Me.SplitContainer1)
        Me.tabSripts.Controls.Add(Me.FlowLayoutPanel4)
        Me.tabSripts.Controls.Add(Me.FlowLayoutPanel3)
        Me.tabSripts.Controls.Add(Me.FlowLayoutPanel2)
        Me.tabSripts.Location = New System.Drawing.Point(4, 22)
        Me.tabSripts.Name = "tabSripts"
        Me.tabSripts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSripts.Size = New System.Drawing.Size(888, 385)
        Me.tabSripts.TabIndex = 1
        Me.tabSripts.Text = "Scripts"
        Me.tabSripts.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 65)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSource)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvParams)
        Me.SplitContainer1.Size = New System.Drawing.Size(876, 314)
        Me.SplitContainer1.SplitterDistance = 656
        Me.SplitContainer1.TabIndex = 13
        '
        'txtSource
        '
        Me.txtSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSource.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtSource.Location = New System.Drawing.Point(0, 0)
        Me.txtSource.Multiline = True
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSource.Size = New System.Drawing.Size(656, 314)
        Me.txtSource.TabIndex = 8
        '
        'dgvParams
        '
        Me.dgvParams.AllowUserToAddRows = False
        Me.dgvParams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParams.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParam, Me.colValue})
        Me.dgvParams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvParams.Location = New System.Drawing.Point(0, 0)
        Me.dgvParams.Name = "dgvParams"
        Me.dgvParams.RowHeadersVisible = False
        Me.dgvParams.Size = New System.Drawing.Size(216, 314)
        Me.dgvParams.TabIndex = 12
        '
        'colParam
        '
        Me.colParam.DataPropertyName = "Param"
        Me.colParam.HeaderText = "Name"
        Me.colParam.Name = "colParam"
        Me.colParam.ReadOnly = True
        '
        'colValue
        '
        Me.colValue.DataPropertyName = "Value"
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.AutoSize = True
        Me.FlowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel4.Controls.Add(Me.cmbSourceFiles)
        Me.FlowLayoutPanel4.Controls.Add(Me.cmbVersions)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnSave)
        Me.FlowLayoutPanel4.Controls.Add(Me.cmbFunctions)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnRun)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(6, 35)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(639, 27)
        Me.FlowLayoutPanel4.TabIndex = 11
        '
        'cmbSourceFiles
        '
        Me.cmbSourceFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSourceFiles.Enabled = False
        Me.cmbSourceFiles.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSourceFiles.FormattingEnabled = True
        Me.cmbSourceFiles.Location = New System.Drawing.Point(3, 3)
        Me.cmbSourceFiles.Name = "cmbSourceFiles"
        Me.cmbSourceFiles.Size = New System.Drawing.Size(185, 21)
        Me.cmbSourceFiles.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.cmbSourceFiles, "Исходные файлы в проекте")
        '
        'cmbVersions
        '
        Me.cmbVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersions.Enabled = False
        Me.cmbVersions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbVersions.FormattingEnabled = True
        Me.cmbVersions.Location = New System.Drawing.Point(194, 3)
        Me.cmbVersions.Name = "cmbVersions"
        Me.cmbVersions.Size = New System.Drawing.Size(89, 21)
        Me.cmbVersions.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cmbVersions, "Версии приложения")
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(289, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 20)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnSave, "Сохранить версию")
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbFunctions
        '
        Me.cmbFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFunctions.Enabled = False
        Me.cmbFunctions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbFunctions.FormattingEnabled = True
        Me.cmbFunctions.Location = New System.Drawing.Point(370, 3)
        Me.cmbFunctions.Name = "cmbFunctions"
        Me.cmbFunctions.Size = New System.Drawing.Size(185, 21)
        Me.cmbFunctions.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cmbFunctions, "Функции в файле проекта")
        '
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(561, 3)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 20)
        Me.btnRun.TabIndex = 0
        Me.btnRun.Text = "Run"
        Me.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnRun, "Запуск выбранной версии")
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(6, 35)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel3.TabIndex = 10
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.txtScriptId)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnGetSource)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(6, 6)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(665, 26)
        Me.FlowLayoutPanel2.TabIndex = 6
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'txtProjectId
        '
        Me.txtScriptId.Location = New System.Drawing.Point(3, 3)
        Me.txtScriptId.Name = "txtProjectId"
        Me.txtScriptId.Size = New System.Drawing.Size(578, 20)
        Me.txtScriptId.TabIndex = 1
        Me.txtScriptId.Text = "1Vue7ijdkqpj-yrh_fAU8t8GOVD30E-ppTXm4saGYuwjbkT508IDlE4be"
        '
        'btnGetSource
        '
        Me.btnGetSource.Enabled = False
        Me.btnGetSource.Location = New System.Drawing.Point(587, 3)
        Me.btnGetSource.Name = "btnGetSource"
        Me.btnGetSource.Size = New System.Drawing.Size(75, 20)
        Me.btnGetSource.TabIndex = 0
        Me.btnGetSource.Text = "Get"
        Me.btnGetSource.UseVisualStyleBackColor = True
        '
        'menu
        '
        Me.menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem})
        Me.menu.Location = New System.Drawing.Point(0, 0)
        Me.menu.Name = "menu"
        Me.menu.Size = New System.Drawing.Size(920, 24)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 445)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(920, 23)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.Image = CType(resources.GetObject("lblConnectionStatus.Image"), System.Drawing.Image)
        Me.lblConnectionStatus.ImageTransparentColor = System.Drawing.Color.White
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Padding = New System.Windows.Forms.Padding(1)
        Me.lblConnectionStatus.Size = New System.Drawing.Size(132, 18)
        Me.lblConnectionStatus.Text = "lblConnectionStatus"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 468)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.menu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menu
        Me.Name = "MainForm"
        Me.Text = "Google API Demo"
        CType(Me.dgvSpreadSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.tabControl.ResumeLayout(False)
        Me.tabSpreadSheets.ResumeLayout(False)
        Me.tabSpreadSheets.PerformLayout()
        Me.tabSripts.ResumeLayout(False)
        Me.tabSripts.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel4.ResumeLayout(False)
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
    Friend WithEvents lblSheets As Label
    Friend WithEvents btnFillIn As Button
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabSpreadSheets As TabPage
    Friend WithEvents tabSripts As TabPage
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents menu As MenuStrip
    Friend WithEvents ConnectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtScriptId As TextBox
    Friend WithEvents btnRead As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblConnectionStatus As ToolStripStatusLabel
    Friend WithEvents txtSource As TextBox
    Friend WithEvents btnGetSource As Button
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents dgvParams As DataGridView
    Friend WithEvents colParam As DataGridViewTextBoxColumn
    Friend WithEvents colValue As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents cmbSourceFiles As ComboBox
    Friend WithEvents cmbVersions As ComboBox
    Friend WithEvents cmbFunctions As ComboBox
    Friend WithEvents btnRun As Button
    Friend WithEvents btnSave As Button
End Class
