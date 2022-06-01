<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScriptControl
    Inherits BaseUC

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptControl))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtSource = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.dgvParams = New System.Windows.Forms.DataGridView()
        Me.colParam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbSourceFiles = New System.Windows.Forms.ComboBox()
        Me.cmbVersions = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbFunctions = New System.Windows.Forms.ComboBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtScriptId = New System.Windows.Forms.TextBox()
        Me.btnGetProject = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.txtSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 61)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSource)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvParams)
        Me.SplitContainer1.Size = New System.Drawing.Size(948, 430)
        Me.SplitContainer1.SplitterDistance = 708
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 16
        '
        'txtSource
        '
        Me.txtSource.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.txtSource.AutoIndentCharsPatterns = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtSource.AutoScrollMinSize = New System.Drawing.Size(27, 14)
        Me.txtSource.BackBrush = Nothing
        Me.txtSource.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.txtSource.CharHeight = 14
        Me.txtSource.CharWidth = 8
        Me.txtSource.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSource.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSource.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.VisibleRange
        Me.txtSource.IsReplaceMode = False
        Me.txtSource.Language = FastColoredTextBoxNS.Language.JS
        Me.txtSource.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.txtSource.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.txtSource.Location = New System.Drawing.Point(0, 0)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Paddings = New System.Windows.Forms.Padding(0)
        Me.txtSource.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.txtSource.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.txtSource.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSource.ServiceColors = CType(resources.GetObject("txtSource.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.txtSource.Size = New System.Drawing.Size(708, 430)
        Me.txtSource.TabIndex = 9
        Me.txtSource.TextAreaBorder = FastColoredTextBoxNS.TextAreaBorderType.[Single]
        Me.txtSource.Zoom = 100
        '
        'dgvParams
        '
        Me.dgvParams.AllowUserToAddRows = False
        Me.dgvParams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParams.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParam, Me.colValue})
        Me.dgvParams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvParams.Location = New System.Drawing.Point(0, 0)
        Me.dgvParams.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvParams.Name = "dgvParams"
        Me.dgvParams.RowHeadersVisible = False
        Me.dgvParams.Size = New System.Drawing.Size(235, 430)
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
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(0, 30)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(749, 29)
        Me.FlowLayoutPanel4.TabIndex = 15
        '
        'cmbSourceFiles
        '
        Me.cmbSourceFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSourceFiles.Enabled = False
        Me.cmbSourceFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSourceFiles.FormattingEnabled = True
        Me.cmbSourceFiles.Location = New System.Drawing.Point(4, 3)
        Me.cmbSourceFiles.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbSourceFiles.Name = "cmbSourceFiles"
        Me.cmbSourceFiles.Size = New System.Drawing.Size(215, 23)
        Me.cmbSourceFiles.TabIndex = 9
        '
        'cmbVersions
        '
        Me.cmbVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersions.Enabled = False
        Me.cmbVersions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVersions.FormattingEnabled = True
        Me.cmbVersions.Location = New System.Drawing.Point(227, 3)
        Me.cmbVersions.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbVersions.Name = "cmbVersions"
        Me.cmbVersions.Size = New System.Drawing.Size(103, 23)
        Me.cmbVersions.TabIndex = 10
        Me.cmbVersions.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(338, 3)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbFunctions
        '
        Me.cmbFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFunctions.Enabled = False
        Me.cmbFunctions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFunctions.FormattingEnabled = True
        Me.cmbFunctions.Location = New System.Drawing.Point(434, 3)
        Me.cmbFunctions.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbFunctions.Name = "cmbFunctions"
        Me.cmbFunctions.Size = New System.Drawing.Size(215, 23)
        Me.cmbFunctions.TabIndex = 10
        '
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.FlatAppearance.BorderSize = 0
        Me.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRun.Location = New System.Drawing.Point(657, 3)
        Me.btnRun.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(88, 23)
        Me.btnRun.TabIndex = 0
        Me.btnRun.Text = "Run"
        Me.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.txtScriptId)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnGetProject)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(778, 29)
        Me.FlowLayoutPanel2.TabIndex = 14
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'txtScriptId
        '
        Me.txtScriptId.Location = New System.Drawing.Point(4, 3)
        Me.txtScriptId.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtScriptId.Name = "txtScriptId"
        Me.txtScriptId.Size = New System.Drawing.Size(674, 23)
        Me.txtScriptId.TabIndex = 1
        Me.txtScriptId.Text = "1Vue7ijdkqpj-yrh_fAU8t8GOVD30E-ppTXm4saGYuwjbkT508IDlE4be"
        '
        'btnGetProject
        '
        Me.btnGetProject.Enabled = False
        Me.btnGetProject.FlatAppearance.BorderSize = 0
        Me.btnGetProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetProject.Location = New System.Drawing.Point(686, 3)
        Me.btnGetProject.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGetProject.Name = "btnGetProject"
        Me.btnGetProject.Size = New System.Drawing.Size(88, 23)
        Me.btnGetProject.TabIndex = 0
        Me.btnGetProject.Text = "Get project"
        Me.btnGetProject.UseVisualStyleBackColor = True
        '
        'ScriptControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FlowLayoutPanel4)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Name = "ScriptControl"
        Me.Size = New System.Drawing.Size(952, 492)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.txtSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents dgvParams As DataGridView
    Friend WithEvents colParam As DataGridViewTextBoxColumn
    Friend WithEvents colValue As DataGridViewTextBoxColumn
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents cmbSourceFiles As ComboBox
    Friend WithEvents cmbVersions As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbFunctions As ComboBox
    Friend WithEvents btnRun As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents txtScriptId As TextBox
    Friend WithEvents btnGetProject As Button
    Friend WithEvents txtSource As FastColoredTextBoxNS.FastColoredTextBox
End Class
