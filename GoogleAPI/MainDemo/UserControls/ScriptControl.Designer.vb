﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtScriptId = New System.Windows.Forms.TextBox()
        Me.btnGetProject = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 53)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(813, 373)
        Me.SplitContainer1.SplitterDistance = 608
        Me.SplitContainer1.TabIndex = 16
        '
        'txtSource
        '
        Me.txtSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSource.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtSource.Location = New System.Drawing.Point(0, 0)
        Me.txtSource.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSource.Multiline = True
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSource.Size = New System.Drawing.Size(608, 373)
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
        Me.dgvParams.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvParams.Name = "dgvParams"
        Me.dgvParams.RowHeadersVisible = False
        Me.dgvParams.Size = New System.Drawing.Size(201, 373)
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
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(0, 26)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(639, 27)
        Me.FlowLayoutPanel4.TabIndex = 15
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
        Me.cmbVersions.Visible = False
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
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(665, 26)
        Me.FlowLayoutPanel2.TabIndex = 14
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'txtScriptId
        '
        Me.txtScriptId.Location = New System.Drawing.Point(3, 3)
        Me.txtScriptId.Name = "txtScriptId"
        Me.txtScriptId.Size = New System.Drawing.Size(578, 20)
        Me.txtScriptId.TabIndex = 1
        Me.txtScriptId.Text = "1Vue7ijdkqpj-yrh_fAU8t8GOVD30E-ppTXm4saGYuwjbkT508IDlE4be"
        '
        'btnGetProject
        '
        Me.btnGetProject.Enabled = False
        Me.btnGetProject.Location = New System.Drawing.Point(587, 3)
        Me.btnGetProject.Name = "btnGetProject"
        Me.btnGetProject.Size = New System.Drawing.Size(75, 20)
        Me.btnGetProject.TabIndex = 0
        Me.btnGetProject.Text = "Get project"
        Me.btnGetProject.UseVisualStyleBackColor = True
        '
        'ScriptControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FlowLayoutPanel4)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Name = "ScriptControl"
        Me.Size = New System.Drawing.Size(816, 426)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents txtSource As TextBox
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
End Class