Public Class Unit
    Inherits MoblieObject

    Private ns As Double = 0.5
    Private nfriction As Double
    Private ngridRefx As Integer
    Private ngridRefy As Integer
    Private ncooldown As Integer = 0
    Private nMaxHP As Integer
    Private nCurrentHP As Integer


    Property Uncooldown As Integer
        Get
            Return ncooldown
        End Get
        Set(value As Integer)
            ncooldown = value
        End Set
    End Property

    Property sp As Double

        Get
            Return ns
        End Get
        Set(value As Double)
            ns = value
        End Set
    End Property

    Property friction As Double
        Get
            Return nfriction
        End Get
        Set(value As Double)
            nfriction = value
        End Set
    End Property

    Property gridRefx As Integer
        Get
            Return ngridRefx
        End Get
        Set(value As Integer)
            ngridRefx = value
        End Set
    End Property
    Property gridRefy As Integer
        Get
            Return ngridRefy
        End Get
        Set(value As Integer)
            ngridRefy = value
        End Set
    End Property

    Property MaxHP As Integer
        Get
            Return nMaxHP
        End Get
        Set(value As Integer)
            nMaxHP = value
        End Set
    End Property
    Property CurrentHP As Integer
        Get
            Return nCurrentHP
        End Get
        Set(value As Integer)
            nCurrentHP = value
        End Set
    End Property
    'Property gridRef As Integer()
    '    Get
    '        Return ngridRef
    '    End Get
    '    Set(value As Integer())
    '        ngridRef = value
    '    End Set
    'End Property


    Public Sub New(p As Point, d As Double, friendQ As Boolean, fric As Double, s As Double, Health As Integer, zoom As Integer) 'Recives and sets up all the values the class will use.
        MyBase.New(friendQ, zoom)
        sp = s
        di = d
        Ini(p)
        friction = fric
        gridRefx = Math.Round(item_center.X / zoom)
        gridRefy = Math.Round(item_center.Y / zoom)
        MaxHP = Health
        CurrentHP = MaxHP

    End Sub

    Public Sub collisionLogi(walls(,) As StaticObject) 'Checks if the unit has collided with a wall and then pushes them back
        For wx As Integer = -2 To 2 Step 1
            For wy As Integer = -2 To 2 Step 1
                If Not (Math.Round(p(0).X / zoomConstant) + wx < 0 Or Math.Round(p(0).X / zoomConstant) + wx > 127 Or Math.Round(p(0).Y / zoomConstant) + wy < 0 Or Math.Round(p(0).Y / zoomConstant) + wy > 95) Then
                    If walls(Math.Round((p(0).X) / zoomConstant) + wx, Math.Round((p(0).Y) / zoomConstant) + wy).ded = False Then

                        If walls(Math.Round(p(0).X / zoomConstant) + wx, Math.Round(p(0).Y / zoomConstant) + wy).collision(p) Then



                            For b As Integer = 0 To 3
                                p(b).X -= vel.x * 1.1
                                p(b).Y -= vel.y * 1.1
                            Next

                            vel.x = 0
                            vel.y = 0
                            A.x *= -1
                            A.y *= -1




                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub update() 'Updates the position of the points based on their velocity, then updates the velocity based on their acceleration, and also updates the acceleration.
        vel.x += A.x
        vel.y += A.y

        For i As Integer = 0 To 3
            p(i).X += vel.x
            p(i).Y += vel.y
        Next

        A.x = -(vel.x) * friction
        A.y = -(vel.y) * friction
        gridRefx = Math.Round(item_center.X / zoomConstant)
        gridRefy = Math.Round(item_center.Y / zoomConstant)

    End Sub





End Class
