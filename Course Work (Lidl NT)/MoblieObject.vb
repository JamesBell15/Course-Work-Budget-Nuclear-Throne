Public Class MoblieObject
    Inherits StaticObject

    Private nvel As New Vector(0, 0)
    Private na As New Vector(0, 0)
    Private nfriendly As Boolean
    Private nweap As Weapon

    Property weap As Weapon
        Get
            Return nweap
        End Get
        Set(value As Weapon)
            nweap = value
        End Set
    End Property

    Property friendly As Boolean
        Get
            Return nfriendly
        End Get
        Set(value As Boolean)
            nfriendly = value
        End Set
    End Property

    Property vel As Vector
        Get
            Return nvel
        End Get
        Set(value As Vector)
            nvel = value
        End Set
    End Property

    Property A As Vector
        Get
            Return na
        End Get
        Set(value As Vector)
            na = value
        End Set
    End Property


    Public Sub New(friendQ As Boolean, zoom As Integer) 'Recives and sets up all the values the class will use.
        MyBase.New(zoom)
        friendly = friendQ
    End Sub




End Class
