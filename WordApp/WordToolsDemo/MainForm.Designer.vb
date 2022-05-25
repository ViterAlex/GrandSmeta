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
        Me.lvwDocsInfo = New System.Windows.Forms.ListView()
        Me.colFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCharCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menuOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAsyncOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.prbProcess = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwDocsInfo
        '
        Me.lvwDocsInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwDocsInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFileName, Me.colCharCount})
        Me.lvwDocsInfo.FullRowSelect = True
        Me.lvwDocsInfo.HideSelection = False
        Me.lvwDocsInfo.Location = New System.Drawing.Point(0, 28)
        Me.lvwDocsInfo.Name = "lvwDocsInfo"
        Me.lvwDocsInfo.Size = New System.Drawing.Size(768, 383)
        Me.lvwDocsInfo.TabIndex = 0
        Me.lvwDocsInfo.UseCompatibleStateImageBehavior = False
        Me.lvwDocsInfo.View = System.Windows.Forms.View.Details
        Me.lvwDocsInfo.Visible = False
        '
        'colFileName
        '
        Me.colFileName.Text = "Имя файла"
        Me.colFileName.Width = 428
        '
        'colCharCount
        '
        Me.colCharCount.Text = "Кол-во символов"
        Me.colCharCount.Width = 108
        '
        'ofd
        '
        Me.ofd.Filter = "Все документы Word|*.docx;*.docm;*.dotx;*.dotm;*.doc|Документы Word|*.docx|Докуме" &
    "нты Word с макросами|*.docm|Шаблоны Word|*.dotx|Шаблоны Word с макросами|*.dotm|" &
    "Документы Word 97-2003|*.doc"
        Me.ofd.Multiselect = True
        Me.ofd.RestoreDirectory = True
        Me.ofd.SupportMultiDottedExtensions = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuOpenFile, Me.btnAsyncOpenFile})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(768, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menuOpenFile
        '
        Me.menuOpenFile.Name = "menuOpenFile"
        Me.menuOpenFile.Size = New System.Drawing.Size(124, 20)
        Me.menuOpenFile.Text = "Открыть файл(ы)..."
        '
        'btnAsyncOpenFile
        '
        Me.btnAsyncOpenFile.Name = "btnAsyncOpenFile"
        Me.btnAsyncOpenFile.Size = New System.Drawing.Size(194, 20)
        Me.btnAsyncOpenFile.Text = "Открыть файл(ы) асинхронно..."
        '
        'prbProcess
        '
        Me.prbProcess.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.prbProcess.Location = New System.Drawing.Point(0, 414)
        Me.prbProcess.Name = "prbProcess"
        Me.prbProcess.Size = New System.Drawing.Size(768, 16)
        Me.prbProcess.Step = 1
        Me.prbProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbProcess.TabIndex = 2
        Me.prbProcess.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 430)
        Me.Controls.Add(Me.prbProcess)
        Me.Controls.Add(Me.lvwDocsInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MainForm"
        Me.Text = "WordTool"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvwDocsInfo As ListView
    Friend WithEvents colFileName As ColumnHeader
    Friend WithEvents colCharCount As ColumnHeader
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents menuOpenFile As ToolStripMenuItem
    Friend WithEvents btnAsyncOpenFile As ToolStripMenuItem
    Friend WithEvents prbProcess As ProgressBar
End Class
