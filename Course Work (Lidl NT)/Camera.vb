Public Class Camera

    Private nGridRef(1) As Integer 'x,y of the upper left most
    Private np As Point
    Private nAOI() As Integer  'width, hight

    Private zoomConstant As Integer


    Public Property GridRef As Integer()
        Get
            Return nGridRef
        End Get
        Set(value As Integer())
            nGridRef = value
        End Set
    End Property

    Public Property pp As Point
        Get
            Return np
        End Get
        Set(value As Point)
            np = value
        End Set
    End Property

    Public Property AOI As Integer()
        Get
            Return nAOI
        End Get
        Set(value As Integer())
            nAOI = value
        End Set
    End Property



    Public Sub New(ByVal chap As Point, zoom As Integer) 'Recives and sets up all the values the class will use.
        zoomConstant = zoom
        If zoomConstant = 5 Then
            AOI = {128, 96}
        Else
            AOI = {30, 22}
        End If
        update(chap)

    End Sub

    Public Sub update(ByVal chap As Point) 'moves the camera to the inputted coordinates

        chap.X -= ((AOI(0) / 2) * zoomConstant)
        chap.Y -= ((AOI(1) / 2) * zoomConstant)
        pp = chap
        GridRef(0) = Math.Round(clamp(Math.Round((pp.X / zoomConstant) - 1, 1), 127, 0))
        GridRef(1) = Math.Round(clamp(Math.Round((pp.Y / zoomConstant) - 1, 1), 95, 0))
    End Sub

    Public Function translateSquare(ByVal target As Point()) As Point() 'used to map translatePoint to a square (an array of points that describe a square)

        Dim temp As New List(Of Point)

        For i As Integer = 0 To target.Count - 1
            temp.Add(translatePoint(target(i)))
        Next

        Return temp.ToArray

    End Function

    Public Function translatePoint(ByVal target As Point) As Point 'Translates a point based on the placement of the camera


        target.X -= pp.X
        target.Y -= pp.Y



        Return New Point(target.X, target.Y)
    End Function

    Private Function clamp(value As Double, max As Double, min As Double) As Double 'restricts an input to two bounds.
        If value >= max Then
            Return max
        ElseIf value <= min Then
            Return min
        Else
            Return value
        End If
    End Function

End Class
