Public Class AIunit
    Inherits Unit

    Private nactionProb As Double
    Private naggroRange As Double
    Private ngun As Weapon
    Private npros As List(Of Projectile)
    Private nSleep As Boolean = True
    Private nViewDistance As Integer
    Private nWorth As Integer
    Private rnd As New Random

    Property actionProb As Double
        Get
            Return nactionProb
        End Get
        Set(value As Double)
            nactionProb = value
        End Set
    End Property

    Property aggroRange As Double
        Get
            Return nactionProb
        End Get
        Set(value As Double)
            nactionProb = value
        End Set
    End Property

    Property gun As Weapon
        Get
            Return ngun
        End Get
        Set(value As Weapon)
            ngun = value
        End Set
    End Property

    Property Sleep As Boolean
        Get
            Return nSleep
        End Get
        Set(value As Boolean)
            nSleep = value
        End Set
    End Property

    Property ViewDistance As Integer
        Get
            Return nViewDistance
        End Get
        Set(value As Integer)
            nViewDistance = value
        End Set
    End Property

    Property Worth As Integer
        Get
            Return nWorth
        End Get
        Set(value As Integer)
            nWorth = value
        End Set
    End Property

    Public Sub New(s As Point, d As Double, friendQ As Boolean, aProb As Double, fric As Double, aggro As Double, sp As Double, baseGun As Weapon, view As Integer, health As Integer, ScoreValue As Integer, zoom As Integer) 'Recives and sets up all the values the class will use.
        MyBase.New(s, d, friendQ, fric, sp, health, zoom)
        actionProb = aProb
        aggroRange = aggro
        Uncooldown = baseGun.cooldown
        gun = baseGun
        ViewDistance = view
        Worth = ScoreValue
    End Sub

    Public Function attack(targetpos As Point, walls As StaticObject(,)) As Boolean 'checks if the unit can attack the target producing a boolean based on the outcome.
        If ray(targetpos, walls) And Uncooldown <= 0 Then
            Uncooldown = gun.cooldown
            Return True
        Else
            Uncooldown -= 1
            Return False
        End If
    End Function

    Public Sub move(target As Point, walls(,) As StaticObject) 'Checks to see if the unit can move, moves them if they can, and uses random doubles to make movement more eratic 
        If ray(target, walls) Then

            Dim t As Double = item_distance(target)
            Dim tt As Double = rnd.NextDouble
            If item_distance(target) > rnd.NextDouble * ViewDistance * zoomConstant Then
                Dim tempAng As Double = grabAng(item_center, target) + (rnd.Next(-1, 2) * rnd.NextDouble * (Math.PI / 2))

                A.x += -Math.Cos(tempAng) * sp
                A.y += -Math.Sin(tempAng) * sp


            End If
        End If
    End Sub

    Public Function ray(target As Point, walls(,) As StaticObject) As Boolean 'Checks to see if the target point is within range and the line connecting the two points isn't blocked.
        Dim tempAng As Double = grabAng(item_center, target)
        Dim count As Double = 0
        Dim zoom As Integer = zoomConstant
        If tempAng < Math.PI Then
            zoom *= -1
        End If
        Dim x As Double = -Math.Cos(tempAng) * (zoomConstant)
        Dim y As Double = -Math.Sin(tempAng) * (zoomConstant)
        Dim InRange As Boolean = False

        Do Until count >= ViewDistance Or InRange
            count += 0.25
            Dim currentX As Integer = Math.Round((item_center().X + x * count) / zoomConstant)
            Dim currentY As Integer = Math.Round((item_center().Y + y * count) / zoomConstant)

            If Not walls(currentX, currentY).ded Then
                InRange = False
                count = ViewDistance
            ElseIf currentX = Math.Round(target.X / zoomConstant) And currentY = Math.Round(target.Y / zoomConstant) Then
                InRange = True

            End If

        Loop


        Return InRange
    End Function

    Public Function grabAng(source As Point, terminal As Point) As Double 'produces the angle from west the points create.
        Return (Math.Atan2(terminal.Y - source.Y, terminal.X - source.X) + Math.PI)
    End Function
End Class
