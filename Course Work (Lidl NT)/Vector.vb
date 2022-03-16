Public Class Vector
    Private Nx As New Double
    Private Ny As New Double
    Private Na As New Double

    Public Property x As Double
        Get
            Return Math.Round(Nx, 10)
        End Get
        Set(value As Double)
            Nx = value
        End Set
    End Property

    Public Property y As Double
        Get
            Return Math.Round(Ny, 10)
        End Get
        Set(value As Double)
            Ny = value
        End Set
    End Property




    Public Sub New(x As Double, y As Double) 'Recives and sets up all the values the class will use.
        Nx = x
        Ny = y
    End Sub

    Public Shared Operator +(a As Vector, b As Vector) As Vector 'Adds two vectors together
        Return New Vector(a.x + b.x, a.y + b.y)
    End Operator

    Public Shared Operator -(a As Vector, b As Vector) As Vector 'Subtracts two vectors
        Return New Vector(a.x - b.x, a.y - b.y)
    End Operator
    Public Shared Operator *(a As Vector, b As Vector) As Double 'DotProduct of two vectors
        Return ((a.x * b.x) + (a.y * b.y))
    End Operator


    Public Function mag() As Double 'Produces the magnitudie of the vector
        Return Math.Sqrt((Nx ^ 2) + (Ny ^ 2))
    End Function




    Public Sub addv(tx As Double, ty As Double) 'adds a scalar to the vector
        Nx += tx
        Ny += ty
    End Sub

    Public Sub subv(tx As Double, ty As Double) 'subtracts a scalar from the vector
        Nx -= tx
        Ny -= ty
    End Sub

    Public Sub mulv(s As Double) 'multiples the vector by a scalar
        Nx *= s
        Ny *= s
    End Sub

    Public Sub divv(tx As Double, ty As Double) 'divides a non zero scalar from the vector
        If tx <> 0 Then
            Nx /= tx
        End If
        If ty <> 0 Then
            Ny /= ty
        End If

    End Sub

End Class
