Public Class StaticObject
    Private np(3) As Point
    Private nded As Boolean = False
    Private ndi As Double
    Protected zoomConstant As Integer

    Public Property p As Point()
        Get
            Return np
        End Get
        Set(value As Point())
            np = value
        End Set
    End Property

    Public Property ded As Boolean
        Get
            Return nded
        End Get
        Set(value As Boolean)
            nded = value
        End Set
    End Property

    Public Overridable Property di As Double
        Get
            Return ndi
        End Get
        Set(value As Double)
            ndi = value
        End Set
    End Property

    Public Sub New(zoom As Integer) 'Recives and sets up all the values the class will use.
        zoomConstant = zoom
        di = zoom
    End Sub

    Public Sub Ini(a As Point) 'Sets up the array of points that describe the square of a unit
        p(0) = New Point(a.X, a.Y)
        p(1) = New Point(a.X + di, a.Y)
        p(2) = New Point(a.X + di, a.Y + di)
        p(3) = New Point(a.X, a.Y + di)
    End Sub



    Public Overridable Function collision(object2Points() As Point) As Boolean 'Returns a boolean depending if any of either arrays intersect with each other
        For g As Integer = 0 To 3
            If (p(0).X < object2Points(g).X And p(1).X > object2Points(g).X) And (p(0).Y < object2Points(g).Y And p(3).Y > object2Points(g).Y) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function item_center() As Point 'Produces the center point of the unit/square
        Dim center As Point

        center.X = (p(0).X + p(1).X + p(2).X + p(3).X) / 4
        center.Y = (p(0).Y + p(1).Y + p(2).Y + p(3).Y) / 4

        Return center
    End Function

    Public Function item_distance(point1 As Point) As Double 'Produces the distance from one point and the center of the unit/square
        Return Math.Sqrt((point1.X - item_center.X) ^ 2 + (point1.Y - item_center.Y) ^ 2)
    End Function

End Class
