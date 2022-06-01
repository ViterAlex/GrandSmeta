<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailControl
    Inherits System.Windows.Forms.UserControl

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
        Me.btnGetLastEmail = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.EmailsTabControl = New System.Windows.Forms.TabControl()
        Me.SuspendLayout()
        '
        'btnGetLastEmail
        '
        Me.btnGetLastEmail.AutoSize = True
        Me.btnGetLastEmail.FlatAppearance.BorderSize = 0
        Me.btnGetLastEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetLastEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnGetLastEmail.Location = New System.Drawing.Point(4, 3)
        Me.btnGetLastEmail.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGetLastEmail.Name = "btnGetLastEmail"
        Me.btnGetLastEmail.Size = New System.Drawing.Size(194, 27)
        Me.btnGetLastEmail.TabIndex = 2
        Me.btnGetLastEmail.Text = "Получить последние письма"
        Me.btnGetLastEmail.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.AutoSize = True
        Me.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSettings.Location = New System.Drawing.Point(505, -1)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(43, 35)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "⚙"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'EmailsTabControl
        '
        Me.EmailsTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmailsTabControl.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.EmailsTabControl.Location = New System.Drawing.Point(0, 36)
        Me.EmailsTabControl.Name = "EmailsTabControl"
        Me.EmailsTabControl.SelectedIndex = 0
        Me.EmailsTabControl.Size = New System.Drawing.Size(552, 501)
        Me.EmailsTabControl.TabIndex = 6
        '
        'EmailControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EmailsTabControl)
        Me.Controls.Add(Me.btnGetLastEmail)
        Me.Controls.Add(Me.btnSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(537, 190)
        Me.Name = "EmailControl"
        Me.Size = New System.Drawing.Size(552, 537)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGetLastEmail As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents EmailsTabControl As TabControl
End Class
