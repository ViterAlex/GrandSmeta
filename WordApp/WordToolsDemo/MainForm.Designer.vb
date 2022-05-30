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
        Me.colIsCleared = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnAsyncOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.prbProcess = New WordToolsDemo.ProgressBarEx()
        Me.colNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwDocsInfo
        '
        Me.lvwDocsInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwDocsInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNumber, Me.colFileName, Me.colCharCount, Me.colIsCleared})
        Me.lvwDocsInfo.FullRowSelect = True
        Me.lvwDocsInfo.HideSelection = False
        Me.lvwDocsInfo.Location = New System.Drawing.Point(3, 3)
        Me.lvwDocsInfo.Name = "lvwDocsInfo"
        Me.lvwDocsInfo.Size = New System.Drawing.Size(762, 371)
        Me.lvwDocsInfo.TabIndex = 0
        Me.lvwDocsInfo.UseCompatibleStateImageBehavior = False
        Me.lvwDocsInfo.View = System.Windows.Forms.View.Details
        Me.lvwDocsInfo.Visible = False
        '
        'colFileName
        '
        Me.colFileName.Text = "Имя файла"
        Me.colFileName.Width = 517
        '
        'colCharCount
        '
        Me.colCharCount.Text = "Кол-во символов"
        Me.colCharCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCharCount.Width = 108
        '
        'colIsCleared
        '
        Me.colIsCleared.Text = "Очищен"
        Me.colIsCleared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAsyncOpenFile})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(768, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnAsyncOpenFile
        '
        Me.btnAsyncOpenFile.Name = "btnAsyncOpenFile"
        Me.btnAsyncOpenFile.Size = New System.Drawing.Size(75, 20)
        Me.btnAsyncOpenFile.Text = "Открыть..."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lvwDocsInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.prbProcess, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(768, 406)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'prbProcess
        '
        Me.prbProcess.Dock = System.Windows.Forms.DockStyle.Top
        Me.prbProcess.Format = ""
        Me.prbProcess.Location = New System.Drawing.Point(3, 380)
        Me.prbProcess.Name = "prbProcess"
        Me.prbProcess.ShowText = True
        Me.prbProcess.Size = New System.Drawing.Size(762, 23)
        Me.prbProcess.TabIndex = 1
        Me.prbProcess.Visible = False
        '
        'colNumber
        '
        Me.colNumber.Text = "#"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 430)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MainForm"
        Me.Text = "WordTool"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvwDocsInfo As ListView
    Friend WithEvents colFileName As ColumnHeader
    Friend WithEvents colCharCount As ColumnHeader
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnAsyncOpenFile As ToolStripMenuItem
    Friend WithEvents colIsCleared As ColumnHeader
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents prbProcess As ProgressBarEx
    Friend WithEvents colNumber As ColumnHeader
End Class
