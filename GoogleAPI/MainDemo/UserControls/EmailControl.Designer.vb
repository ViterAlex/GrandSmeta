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
        Me.txtEmailContent = New System.Windows.Forms.TextBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.lblLastFolder = New System.Windows.Forms.Label()
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
        Me.btnGetLastEmail.Size = New System.Drawing.Size(194, 40)
        Me.btnGetLastEmail.TabIndex = 2
        Me.btnGetLastEmail.Text = "Показать последнее письмо"
        Me.btnGetLastEmail.UseVisualStyleBackColor = True
        '
        'txtEmailContent
        '
        Me.txtEmailContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailContent.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtEmailContent.Location = New System.Drawing.Point(4, 47)
        Me.txtEmailContent.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtEmailContent.Multiline = True
        Me.txtEmailContent.Name = "txtEmailContent"
        Me.txtEmailContent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEmailContent.Size = New System.Drawing.Size(544, 485)
        Me.txtEmailContent.TabIndex = 3
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.AutoSize = True
        Me.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSettings.Location = New System.Drawing.Point(505, 3)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(43, 35)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "⚙"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'lblLastFolder
        '
        Me.lblLastFolder.AutoSize = True
        Me.lblLastFolder.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblLastFolder.Location = New System.Drawing.Point(206, 11)
        Me.lblLastFolder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastFolder.Name = "lblLastFolder"
        Me.lblLastFolder.Size = New System.Drawing.Size(96, 25)
        Me.lblLastFolder.TabIndex = 5
        Me.lblLastFolder.Text = "lastFolder"
        Me.lblLastFolder.Visible = False
        '
        'EmailControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblLastFolder)
        Me.Controls.Add(Me.txtEmailContent)
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
    Friend WithEvents txtEmailContent As TextBox
    Friend WithEvents btnSettings As Button
    Friend WithEvents lblLastFolder As Label
End Class
