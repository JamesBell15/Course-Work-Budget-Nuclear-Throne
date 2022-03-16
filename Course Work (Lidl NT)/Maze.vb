Public Class Maze
    Private Cells(127, 95) As Boolean
    Private tempCells(127, 95) As Boolean
    Private cCells(127, 95) As String

    Private LivingChance As Double = 0.45
    Private EnSpawnRate As Double = 0.005
    Private deathlimit As Integer = 4
    Private birthLimit As Integer = 6
    Private ran As New Random
    Private validTiles As Integer = 50
    Private zoomConstant As Integer = 24

    Public Sub initialise(x As Integer, y As Integer, zoom As Integer) 'sets up the maze grid by adding walls randomly
        zoomConstant = zoom
        For i As Integer = 0 To 127
            For j As Integer = 0 To 95
                If i = (x / zoomConstant) And j = (y / zoomConstant) Then
                    Cells(i, j) = True
                ElseIf ran.NextDouble() * 1 < LivingChance Then

                    Cells(i, j) = True

                End If
            Next
        Next

    End Sub

    Public Sub remap(walls(,) As StaticObject) 'Transfers the internal map to the map the game will use

        For i As Integer = 0 To 127
            For j As Integer = 0 To 95
                walls(i, j).ded = Cells(i, j)

            Next

        Next
    End Sub

    Public Sub fillMap(x As Integer, y As Integer) 'Calls all the functions that are used to fill in inaccessable areas of the maze
        Dim b As Integer
        transMap()

        b = floodFill(x / zoomConstant, y / zoomConstant)
        reverseMap()

    End Sub

    Public Sub transMap() 'translates the grid into string format for FloodFill to use
        For i As Integer = 0 To 127
            For j As Integer = 0 To 95
                If Not Cells(i, j) Then
                    cCells(i, j) = "b"
                Else
                    cCells(i, j) = "a"
                End If
            Next
        Next
    End Sub

    Public Sub reverseMap() 'Translates back the string grid into the boolean grid
        validTiles = 0
        For i As Integer = 0 To 127
            For j As Integer = 0 To 95
                If cCells(i, j) = "c" Then
                    Cells(i, j) = True
                    validTiles += 1
                ElseIf cCells(i, j) = "b" Or cCells(i, j) = "a" Then
                    Cells(i, j) = False

                End If

            Next
        Next


    End Sub

    Public Sub simulate() 'Applies the game of life algorithim to the grid
        Dim nbs As Integer = 0

        For i As Integer = 1 To 126
            For j As Integer = 1 To 94
                nbs = countNeighboursDi(i, j)


                If Not Cells(i, j) Then
                    If nbs < deathlimit Then
                        tempCells(i, j) = True
                    Else
                        tempCells(i, j) = False
                    End If
                Else
                    If nbs > birthLimit Then
                        tempCells(i, j) = False

                    Else
                        tempCells(i, j) = True

                    End If
                End If

            Next
        Next

        Cells = tempCells

    End Sub


    Public Sub placeEn(walls(,) As StaticObject, enemies As List(Of AIunit), cha As Unit, weap As Weapon) 'Randomly places enemies around the grid except near the player.
        For i As Integer = 2 To 125
            For j As Integer = 2 To 93
                If walls(i, j).ded Then



                    If ran.NextDouble * 1 < EnSpawnRate And Math.Sqrt((walls(i, j).p(0).X - cha.p(0).X) ^ 2 + (walls(i, j).p(0).Y - cha.p(0).Y) ^ 2) > 50 Then
                        enemies.Add(New AIunit(New Point(i * zoomConstant, j * zoomConstant), (4 * zoomConstant) / 5, True, 2, 0.15, 25, 2.5, weap, 6, 2, 100, zoomConstant))
                    End If

                End If
            Next

        Next
    End Sub


    Private Function countNeighboursDi(x As Integer, y As Integer) As Integer 'Counts the number of walls around a posistion 
        Dim count As Integer = 0
        Dim neighbour() As Integer = {0, 0}

        For i As Integer = -1 To 1
            For j As Integer = -1 To 1
                neighbour(0) = x + i
                neighbour(1) = y + j

                If i = 0 And j = 0 Then

                ElseIf (neighbour(0) < 1 Or neighbour(1) < 1 Or neighbour(0) > 126 Or neighbour(1) > 94) Then
                    count += 1
                ElseIf Not Cells(neighbour(0), neighbour(1)) Then
                    count += 1

                End If

            Next
        Next

        Return count
    End Function


    Public Function floodFill(nodex As Integer, nodey As Integer) As Integer 'A recrsive algorithim to find all the accessiable areas from a perticular point
        'a is a free space, b is a blocked space, c is a free space that has been checked
        If cCells(nodex, nodey) <> "a" Then
            Return 0
        ElseIf (nodex < 2 Or nodex > 125) Or (nodey < 2 Or nodey > 93) Then
            cCells(nodex, nodey) = "b"
            Return 0
        ElseIf cCells(nodex, nodey) = "a" Then
            cCells(nodex, nodey) = "c"
            floodFill(nodex, nodey + 1) 'south
            floodFill(nodex, nodey - 1) 'north
            floodFill(nodex + 1, nodey) 'east
            floodFill(nodex - 1, nodey) 'west



        End If


        Return 0




    End Function



End Class
