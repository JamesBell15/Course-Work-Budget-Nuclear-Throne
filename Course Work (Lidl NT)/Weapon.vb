Public Class Weapon
    Private nnumOfPro As Double
    Private nlifespan As Double
    Private nproSpeed As Integer
    Private ndimensions As Double
    Private rnd As New Random
    Private ninaccRange As Double
    Private ninaccuracy As Double
    Private ncooldown As New Integer
    Private nautomatic As Boolean
    Private nbounces As Integer
    Private nDamage As Integer

    Property numOfPro As Integer
        Get
            Return nnumOfPro
        End Get
        Set(value As Integer)
            nnumOfPro = value
        End Set
    End Property

    Property lifespan As Double
        Get
            Return nlifespan
        End Get
        Set(value As Double)
            nlifespan = value
        End Set
    End Property

    Property proSpeed As Double
        Get
            Return nproSpeed
        End Get
        Set(value As Double)
            nproSpeed = value
        End Set
    End Property

    Property di As Double
        Get
            Return ndimensions
        End Get
        Set(value As Double)
            ndimensions = value
        End Set
    End Property

    Property inaccRange As Double
        Get
            Return ninaccRange
        End Get
        Set(value As Double)
            ninaccRange = value
        End Set
    End Property

    Property inaccuracy As Double
        Get
            Return ninaccuracy
        End Get
        Set(value As Double)
            ninaccuracy = value
        End Set
    End Property

    Property cooldown As Integer
        Get
            Return ncooldown
        End Get
        Set(value As Integer)
            ncooldown = value
        End Set
    End Property

    Property automatic As Boolean
        Get
            Return nautomatic
        End Get
        Set(value As Boolean)
            nautomatic = value
        End Set
    End Property

    Property bounces As Integer
        Get
            Return nbounces
        End Get
        Set(value As Integer)
            nbounces = value
        End Set
    End Property

    Property damage As Integer
        Get
            Return nDamage
        End Get
        Set(value As Integer)
            nDamage = value
        End Set
    End Property

    Public Sub New(pSpeed As Double, dimensions As Double, inaccArc As Integer, lifeS As Double, proCount As Integer, delay As Integer, auto As Boolean, bounceCount As Integer, dmg As Integer) 'Recives and sets up all the values the class will use.
        proSpeed = pSpeed
        di = dimensions

        lifespan = lifeS
        inaccRange = inaccArc
        numOfPro = proCount
        cooldown = delay
        automatic = auto
        bounces = bounceCount
        damage = dmg
    End Sub

    Public Sub newInacc() 'Produces the deivence that the projectile will follow
        inaccuracy = rnd.Next((-inaccRange), inaccRange) * Math.PI
    End Sub

End Class
