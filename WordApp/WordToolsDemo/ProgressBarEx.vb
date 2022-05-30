Imports System.ComponentModel

Public Class ProgressBarEx
    Inherits ProgressBar

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private _format As String
    Public Property Format() As String
        Get
            Return _format
        End Get
        Set(ByVal value As String)
            _format = value
            Invalidate()
        End Set
    End Property

    Private _showText As Boolean
    Public Property ShowText() As Boolean
        Get
            Return _showText
        End Get
        Set(ByVal value As Boolean)
            _showText = value
            Invalidate()
        End Set
    End Property

    <Browsable(True)>
    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim rect = ClientRectangle
        Dim g = e.Graphics
        ProgressBarRenderer.DrawHorizontalBar(g, rect)
        rect.Inflate(-2, -2)
        Dim w = rect.Width * (Value * 100 / Maximum) / 100.0F
        Dim clip = New Rectangle(rect.X, rect.Y, w, rect.Height)
        ProgressBarRenderer.DrawHorizontalChunks(g, clip)
        If Not ShowText Then
            Return
        End If
        Dim sf = New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        Dim val = Value / CSng(Maximum)
        Dim dx = Width / 2.0F
        Dim dy = Height / 2.0F
        Dim t = IIf(String.IsNullOrEmpty(Format), Me.Text, val.ToString(Format))
        e.Graphics.TranslateTransform(dx, dy)
        e.Graphics.DrawString(t, Me.Font, SystemBrushes.ControlText, 0, 0, sf)
    End Sub
End Class
