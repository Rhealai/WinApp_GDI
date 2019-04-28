Imports System.Drawing
Imports System.Drawing.Drawing2D


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'paint_font()
        'RotateGDI()

        Dim ctPoint As Point = New Point(150, 150)
        Dim cyclePoint As Point

        For angle = 0 To 360 Step 5

            cyclePoint.X = ctPoint.X + 150 * d2rCos(angle)
            cyclePoint.Y = ctPoint.Y + 150 * d2rSin(angle)

            fntDrawLine(cyclePoint, angle, 10)

        Next

        fntDrawCircle()
        'fntDrawArrow(0)
        Timer1.Enabled = True

    End Sub



    Private Sub Form1_Move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Move
        paint_font()
        drawLine()
    End Sub


    Sub paint_font()
        Dim fnt As Font = New Font("Tahoma", 20, FontStyle.Bold Or FontStyle.Italic)
        Dim g As Graphics

        g = Me.CreateGraphics()
        g.DrawString("Hello World!! GDI Font.", fnt, New SolidBrush(Color.Blue), 14, 10)
        fnt.Dispose() : g.Dispose()

    End Sub


    Sub drawLine()
        Dim g As Graphics = Me.CreateGraphics()
        Dim Mypen1 As New Pen(Color.Blue, 2)
        Dim Mypen2 As New Pen(Color.Green, 5)
        g.DrawLine(Mypen1, 10, 10, 180, 10)
        Dim pt1 As Point = New Point(10, 50)
        Dim pt2 As Point = New Point(180, 50)
        g.DrawLine(Mypen2, pt1, pt2)
        Mypen1.Dispose() : Mypen2.Dispose()

    End Sub

    Sub fntDrawArrow(ByVal angle As Single)
        Dim g As Graphics = Me.CreateGraphics()
        Dim Mypen As New Pen(Color.Green, 2)
        Dim MatGraphic As New Matrix
        Dim curvePts() As Point =
            {New Point(150, 150),
             New Point(250, 145),
             New Point(250, 140),
             New Point(280, 150),
             New Point(250, 160),
             New Point(250, 155)
            }

        Dim curvePath As New GraphicsPath
        curvePath.AddPolygon(curvePts)
        MatGraphic.RotateAt(angle, New Point(150, 150))
        curvePath.Transform(MatGraphic)
        g.FillPath(Brushes.Green, curvePath)


        g.Dispose()

    End Sub

    Sub fntDrawCircle()
        Dim g As Graphics = Me.CreateGraphics()
        Dim Mypen As New Pen(Color.Red, 3)
        Mypen.DashStyle = Drawing2D.DashStyle.Dot
        g.DrawArc(Mypen, 0, 0, 300, 300, 0, 360)

        Mypen.Dispose() : g.Dispose()

    End Sub

    Sub DrawCoverCircle()
        Dim g As Graphics = Me.CreateGraphics()
        g.FillPie(Brushes.White, 0, 0, 300, 300, 0, 360)
        g.Dispose()

    End Sub

    Sub fntDrawLine(ByVal ctPoint As Point, ByVal ctAngleDegree As Double, ByVal leng As Integer)
        Dim g As Graphics = Me.CreateGraphics()
        Dim Mypen As New Pen(Color.Blue, 1)

        Dim sinAngle As Double = d2rSin(ctAngleDegree)
        Dim cosAngle As Double = d2rCos(ctAngleDegree)


        'Dim pt1 As Point = New Point(10, 50)
        'Dim pt2 As Point = New Point(180, 50)

        Dim pt1 As Point = New Point(ctPoint.X - leng * cosAngle, ctPoint.Y - leng * sinAngle)
        Dim pt2 As Point = New Point(ctPoint.X + leng * cosAngle, ctPoint.Y + leng * sinAngle)


        g.DrawLine(Mypen, pt1, pt2)

        Mypen.Dispose()
    End Sub

    Private Function d2rSin(ByVal AngleDegree) As Double
        Return Math.Sin(Math.PI * AngleDegree / 180.0)
    End Function

    Private Function d2rCos(ByVal AngleDegree) As Double
        Return Math.Cos(Math.PI * AngleDegree / 180.0)
    End Function


    Sub RotateGDI()

        Dim fnt As Font = New Font("Tahoma", 20, FontStyle.Bold Or FontStyle.Italic)

        Dim e As Graphics = Me.CreateGraphics()

        Dim sz As Size = Me.Size
        'Dim Middle As Point = New Point(sz.Width / 2, sz.Height / 2)


        Dim Middle As Point = New Point(PictureBox1.Location.X + PictureBox1.Width / 2, PictureBox1.Location.Y + PictureBox1.Height / 2)

        e.TranslateTransform(Middle.X, Middle.Y)
        e.RotateTransform(30)

        Dim Fmat As StringFormat = New StringFormat(StringFormatFlags.NoClip)
        Fmat.Alignment = StringAlignment.Center
        Fmat.LineAlignment = StringAlignment.Center
        e.DrawString("A Simple TextString", fnt, Brushes.Black, 0, 0, Fmat)



    End Sub

    Dim angleA As Single = 0
    Dim canvas As New Bitmap(300, 300)
    Dim gTimer As Graphics

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'gTimer = Graphics.FromImage(canvas)
        'gTimer.Clear(Color.White)

        'gTimer.DrawLine(Pens.Black, 0, 150, 300, 150)
        'gTimer.DrawLine(Pens.Black, 150, 0, 150, 300)

        DrawCoverCircle()

        Dim ctPoint As Point = New Point(150, 150)
        Dim cyclePoint As Point

        For angle = 0 To 360 Step 5

            cyclePoint.X = ctPoint.X + 150 * d2rCos(angle)
            cyclePoint.Y = ctPoint.Y + 150 * d2rSin(angle)

            fntDrawLine(cyclePoint, angle, 10)

        Next

        fntDrawCircle()

        fntDrawCircle()
        fntDrawArrow(angleA)
        angleA += -1
    End Sub


End Class
