<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmailSettingsForm
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblDeleteAccount = New System.Windows.Forms.LinkLabel()
        Me.lblAddAccount = New System.Windows.Forms.LinkLabel()
        Me.tvwNames = New System.Windows.Forms.TreeView()
        Me.EmailPropertyGrid1 = New GapiTools.EmailPropertyGrid()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(327, 332)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 1, 4, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 27)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(423, 332)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 1, 4, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 27)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Отмена"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDeleteAccount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAddAccount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwNames)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EmailPropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(511, 327)
        Me.SplitContainer1.SplitterDistance = 206
        Me.SplitContainer1.TabIndex = 5
        '
        'lblDeleteAccount
        '
        Me.lblDeleteAccount.AutoSize = True
        Me.lblDeleteAccount.Location = New System.Drawing.Point(109, 4)
        Me.lblDeleteAccount.Name = "lblDeleteAccount"
        Me.lblDeleteAccount.Size = New System.Drawing.Size(96, 15)
        Me.lblDeleteAccount.TabIndex = 1
        Me.lblDeleteAccount.TabStop = True
        Me.lblDeleteAccount.Text = "Удалить аккаунт"
        '
        'lblAddAccount
        '
        Me.lblAddAccount.AutoSize = True
        Me.lblAddAccount.Location = New System.Drawing.Point(3, 4)
        Me.lblAddAccount.Name = "lblAddAccount"
        Me.lblAddAccount.Size = New System.Drawing.Size(104, 15)
        Me.lblAddAccount.TabIndex = 0
        Me.lblAddAccount.TabStop = True
        Me.lblAddAccount.Text = "Добавить аккаунт"
        '
        'tvwNames
        '
        Me.tvwNames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwNames.FullRowSelect = True
        Me.tvwNames.HideSelection = False
        Me.tvwNames.Location = New System.Drawing.Point(0, 26)
        Me.tvwNames.Name = "tvwNames"
        Me.tvwNames.Size = New System.Drawing.Size(204, 301)
        Me.tvwNames.TabIndex = 2
        '
        'EmailPropertyGrid1
        '
        Me.EmailPropertyGrid1.Accounts = Nothing
        Me.EmailPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EmailPropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.EmailPropertyGrid1.Name = "EmailPropertyGrid1"
        Me.EmailPropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.EmailPropertyGrid1.Size = New System.Drawing.Size(301, 327)
        Me.EmailPropertyGrid1.TabIndex = 0
        '
        'EmailSettingsForm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(514, 361)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(530, 400)
        Me.Name = "EmailSettingsForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Настройки почты"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents EmailPropertyGrid1 As EmailPropertyGrid
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tvwNames As TreeView
    Friend WithEvents lblDeleteAccount As LinkLabel
    Friend WithEvents lblAddAccount As LinkLabel
End Class
