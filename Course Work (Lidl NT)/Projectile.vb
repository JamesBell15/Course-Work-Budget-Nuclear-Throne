Public Class Projectile
    Inherits MoblieObject

    Private nang As Double
    Private nbounces As Integer
    Private nref As Boolean
    Private nGraphicPoint As Point


    Public Property GraphicPoint As Point
        Get
            Return nGraphicPoint
        End Get
        Set(value As Point)
            nGraphicPoint = value
        End Set
    End Property

    Public Property ang As Double
        Get
            Return nang
        End Get
        Set(value As Double)
            nang = value
        End Set
    End Property

    Public Property bounces As Integer
        Get
            Return nbounces
        End Get
        Set(value As Integer)
            nbounces = value
        End Set
    End Property




    Public Sub New(point As Point, d As Point, weapon As Weapon, friendQ As Boolean, zoom As Integer) 'Recives and sets up all the values the class will use.
        MyBase.New(friendQ, zoom)
        p(0) = point
        di = weapon.di
        nGraphicPoint.X = point.X - Math.Round((di / 2))
        nGraphicPoint.Y = point.Y - Math.Round((di / 2))

        bounces = weapon.bounces
        weap = weapon
        weap.newInacc()
        ang = grabAng(point, d) + weap.inaccuracy

        updateAng()


    End Sub

    Public Function grabAng(source As Point, terminal As Point) As Double 'This subroutine produces the angle from west in radians, from the source to the terminal points.
        Return (Math.Atan2(terminal.Y - source.Y, terminal.X - source.X) + Math.PI)
    End Function



    Public Sub updateAng() 'This subroutine updates teh velocity of the projectile based on it's angle.

        vel = New Vector(0, 0)

        vel.x = -Math.Cos(ang) * weap.proSpeed
        vel.y = -Math.Sin(ang) * weap.proSpeed

    End Sub


    Public Sub update() 'moves the center of the cirle by the velocity and the point which the cirle is drawn from by the velocity


        p(0).X += vel.x
        p(0).Y += vel.y

        Dim temp As New Point(GraphicPoint.X + vel.x, GraphicPoint.Y + vel.y)
        GraphicPoint = temp

    End Sub


    Public Sub collisonLogi(walls(,) As StaticObject) 'Contains the logic that dictates what happens when a projectile collides with a wall.
        For wx As Integer = -1 To 1 Step 1
            For wy As Integer = -1 To 1 Step 1
                If Not (Math.Round(p(0).X / zoomConstant) + wx < 0 Or Math.Round(p(0).X / zoomConstant) + wx > 127 Or Math.Round(p(0).Y / zoomConstant) + wy < 0 Or Math.Round(p(0).Y / zoomConstant) + wy > 95) Then 'Makes sure there aren't any out of bounds calls to the walls array
                    If walls(Math.Round((p(0).X) / zoomConstant) + wx, Math.Round((p(0).Y) / zoomConstant) + wy).ded = False Then

                        Dim wall As StaticObject = walls(Math.Round((p(0).X) / zoomConstant) + wx, Math.Round((p(0).Y) / zoomConstant) + wy)

                        If CollisionVec(wall) Then


                            If bounces = 0 Then
                                ded = True
                            Else


                                Dim TempAngle As Double = grabAng(wall.item_center, p(0))


                                If (TempAngle > Math.PI / 4 And TempAngle < (3 * Math.PI) / 4) Or (TempAngle > (5 * Math.PI) / 4 And TempAngle < (7 * Math.PI) / 4) Then
                                    vel.y *= -1

                                Else
                                    vel.x *= -1

                                End If




                                bounces -= 1



                            End If
                        End If
                    End If
                End If


            Next
        Next
    End Sub

    Public Function CollisionVec(obj As Object) As Boolean 'return wether or not a projectile has collided with a square object ei. everything other than projectiles
        Dim c As New Vector(p(0).X, p(0).Y)
        Dim b As New Vector(obj.p(0).X, obj.p(0).Y)
        Dim cc As New Point(clamp(c.x, b.x + (obj.di), b.x), clamp(c.y, b.y + (obj.di), b.y))
        Dim dd As New Vector((cc.X - c.x), (cc.Y - c.y))



        If dd.mag <= di / 2 Then
            Return True
        Else
            Return False
        End If

    End Function



    Public Function collisionUnit(target As Unit) As Boolean 'decides if the projectile has collided with a unit (the player or AI)

        If CollisionVec(target) And Not target.ded Then
            Return True
        End If
        Return False
    End Function




    Private Function clamp(value As Double, max As Double, min As Double) As Double 'used to trap a value between two bounds.
        If value >= max Then
            Return max
        ElseIf value <= min Then
            Return min
        Else
            Return value
        End If
    End Function

End Class
