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
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabSpreadSheets = New System.Windows.Forms.TabPage()
        Me.tabSripts = New System.Windows.Forms.TabPage()
        Me.menu = New System.Windows.Forms.MenuStrip()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblConnectionStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SheetsControl1 = New GapiTools.SheetsControl()
        Me.ScriptControl1 = New GapiTools.ScriptControl()
        Me.tabControl.SuspendLayout()
        Me.tabSpreadSheets.SuspendLayout()
        Me.tabSripts.SuspendLayout()
        Me.menu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tabControl.Size = New System.Drawing.Size(960, 445)
        Me.tabControl.TabIndex = 6
        '
        'tabSpreadSheets
        '
        Me.tabSpreadSheets.Controls.Add(Me.SheetsControl1)
        Me.tabSpreadSheets.Location = New System.Drawing.Point(4, 22)
        Me.tabSpreadSheets.Name = "tabSpreadSheets"
        Me.tabSpreadSheets.Size = New System.Drawing.Size(952, 419)
        Me.tabSpreadSheets.TabIndex = 0
        Me.tabSpreadSheets.Text = "Spreadsheets"
        Me.tabSpreadSheets.UseVisualStyleBackColor = True
        '
        'tabSripts
        '
        Me.tabSripts.Controls.Add(Me.ScriptControl1)
        Me.tabSripts.Location = New System.Drawing.Point(4, 22)
        Me.tabSripts.Name = "tabSripts"
        Me.tabSripts.Size = New System.Drawing.Size(952, 419)
        Me.tabSripts.TabIndex = 1
        Me.tabSripts.Text = "Scripts"
        Me.tabSripts.UseVisualStyleBackColor = True
        '
        'menu
        '
        Me.menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem})
        Me.menu.Location = New System.Drawing.Point(0, 0)
        Me.menu.Name = "menu"
        Me.menu.Size = New System.Drawing.Size(984, 24)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 479)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 23)
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
        'SheetsControl1
        '
        Me.SheetsControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SheetsControl1.Location = New System.Drawing.Point(0, 0)
        Me.SheetsControl1.Name = "SheetsControl1"
        Me.SheetsControl1.Size = New System.Drawing.Size(952, 419)
        Me.SheetsControl1.TabIndex = 0
        '
        'ScriptControl1
        '
        Me.ScriptControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScriptControl1.Location = New System.Drawing.Point(0, 0)
        Me.ScriptControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.ScriptControl1.Name = "ScriptControl1"
        Me.ScriptControl1.Size = New System.Drawing.Size(952, 419)
        Me.ScriptControl1.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 502)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.menu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menu
        Me.Name = "MainForm"
        Me.Text = "Google API Demo"
        Me.tabControl.ResumeLayout(False)
        Me.tabSpreadSheets.ResumeLayout(False)
        Me.tabSripts.ResumeLayout(False)
        Me.menu.ResumeLayout(False)
        Me.menu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabSpreadSheets As TabPage
    Friend WithEvents tabSripts As TabPage
    Friend WithEvents menu As MenuStrip
    Friend WithEvents ConnectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblConnectionStatus As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SheetsControl1 As SheetsControl
    Friend WithEvents ScriptControl1 As ScriptControl
End Class
