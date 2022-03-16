Public Class GameLoop
    Private zoomConstant As Integer = CharacterSelect.zoomConstant
    Private GameImage As New Bitmap(640, 480)
    Private Gamegfx As Graphics = Graphics.FromImage(GameImage)
    Private enemies As New List(Of AIunit)
    Private currentGun As Weapon
    Private guns As New List(Of Weapon)
    Private pro As New List(Of Projectile)
    Private bin As New List(Of Integer)
    Private MovBools() As Boolean = {False, False, False, False}
    Private automatic As Boolean = False
    Private ran As New Random
    Private walls(127, 95) As StaticObject
    Private gen As New Maze
    Private cha As New Unit(New Point(64 * zoomConstant, 48 * zoomConstant), (4 * zoomConstant) / 5, True, zoomConstant / 160, zoomConstant / 16, 8, zoomConstant)
    Private currentP As Integer = 0
    Private cam As New Camera(cha.p(0), zoomConstant)
    Private score As Integer = 0
    Private PlayerBitMap As Bitmap
    Private frames As Integer
    Private nGameOver As Boolean

    Property GameOver As Boolean
        Get
            Return cha.ded
        End Get
        Set(value As Boolean)
            nGameOver = value
        End Set
    End Property

    Private Sub GameLoop_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'This is the subroutine that executes when the form first loads, it sets ups all the variables and starts the timer.
        GameOver = False
        guns.Add(New Weapon(zoomConstant / 2, (2 * zoomConstant) / 3, 0, 0, 1, 1, False, 0, 2)) 'def 0
        guns.Add(New Weapon(zoomConstant / 2, (2 * zoomConstant) / 3, 10, 0, 7, 1, True, 5, 2)) 'shot 1
        guns.Add(New Weapon(zoomConstant / 2, (2 * zoomConstant) / 3, 0, 0, 1, 1, True, 5, 2)) 'bouncy def 2
        guns.Add(New Weapon(zoomConstant / 2, (2 * zoomConstant) / 3, 20, 0, 20, 1, True, 5, 2)) 'lag def (works up to pro = ~500~ at 33 timer) 3
        guns.Add(New Weapon(zoomConstant / 4, (2 * zoomConstant) / 3, 4, 0, 1, 20, False, 0, 2)) 'ene

        For i As Integer = 0 To 127
            For j As Integer = 0 To 95

                walls(i, j) = New StaticObject(zoomConstant)
                walls(i, j).Ini(New Point(i * zoomConstant, j * zoomConstant)) '24 for large 5/4 for small

            Next
        Next


        createMaze()

        currentGun = guns(0)

        updateHPLabel()

        HPBar.Maximum = cha.MaxHP
        HPBar.Step = 8

        HPBar.Minimum = 0
        HPBar.PerformStep()
        GameTimer.Start()

    End Sub

    Private Sub createMaze() 'This subroutine houses all the needed actions to produce a new maze.

        gen.initialise(cha.p(0).X, cha.p(0).Y, zoomConstant)
        gen.remap(walls)

        For i As Integer = 0 To 2
            gen.simulate()
            gen.remap(walls)
        Next

        gen.fillMap(cha.p(0).X, cha.p(0).Y)
        gen.remap(walls)

        gen.placeEn(walls, enemies, cha, guns(4))

    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick 'This subroutine executes every 33ms, this is also the game loop that dictates what happens during the game.
        Gamegfx.Clear(Color.Transparent)
        frames += 1
        Label1.Text = "x:" & Math.Round(cha.p(0).X / zoomConstant, 1) & " y:" & Math.Round(cha.p(0).Y / zoomConstant, 1)   'testing
        Label5.Text = "x: " & MousePosition.X - Me.Location.X & " y: " & MousePosition.Y - Me.Location.Y
        Label6.Text = "x: " & cam.GridRef(0) & " y: " & cam.GridRef(1)
        Label7.Text = "x: " & cam.pp.X & " y: " & cam.pp.Y
        Label8.Text = "x: " & cam.translateSquare(cha.p)(0).X & " y: " & cam.translateSquare(cha.p)(0).Y
        Label10.Text = frames
        ' Label9.Text = New Projectile(New Point(0, 0), New Point(0, 0), currentGun, True, 2).grabAng(cha.item_center, New Point(MousePosition.X + cam.pp.X - Me.Location.X - cha.di, MousePosition.Y + cam.pp.Y - Me.Location.Y - cha.di))
        If cha.Uncooldown <> 0 Then
            cha.Uncooldown -= 1
        End If




        cam.update(cha.p(0))
        If enemies.Count <> 0 Then
            enemyLog()
        End If


        If cha.ded = False Then
            chaLog()
        Else
            Label2.Text = "ded"
            GameTimer.Stop()
            Pause.Show()


        End If

        firecheck()

        currentP = 0
        If pro.Count <> 0 Then
            proLog()
        Else
            pro.Clear()
        End If

        Label4.Text = currentP '=======================================



        For o As Integer = cam.GridRef(0) To clamp(cam.GridRef(0) + cam.AOI(0), 127, 0)
            For p As Integer = cam.GridRef(1) To clamp(cam.GridRef(1) + cam.AOI(1), 95, 0)
                If Not walls(o, p).ded Then
                    Dim temp() As Point = walls(o, p).p
                    Gamegfx.FillPolygon(New SolidBrush(Color.Green), cam.translateSquare(temp)) 'walls(o, p).p))

                End If
            Next
        Next

        GameBox.Image = GameImage



    End Sub

    Private Function clamp(value As Double, max As Double, min As Double) As Double 'restricts an input to two bounds.
        If value >= max Then
            Return max
        ElseIf value <= min Then
            Return min
        Else
            Return value
        End If
    End Function

    Private Sub enemyLog() 'Houses the logic for enemies, and displays them onto the image.

        For i As Integer = 0 To enemies.Count - 1
            If Not enemies(i).ded Then



                If Not enemies(i).Sleep Then

                    If enemies(i).attack(cha.item_center, walls) Then
                        pro.Add(New Projectile(enemies(i).item_center, cha.item_center, enemies(i).gun, False, zoomConstant))
                    End If

                    enemies(i).move(cha.item_center, walls)

                    enemies(i).collisionLogi(walls)



                    enemies(i).update()
                    Gamegfx.FillPolygon(New SolidBrush(Color.MediumPurple), cam.translateSquare(enemies(i).p))

                Else

                    If enemies(i).item_distance(cha.item_center) < enemies(i).ViewDistance * zoomConstant Then

                        enemies(i).Sleep = Not (enemies(i).ray(cha.item_center, walls))

                    End If
                    Gamegfx.FillPolygon(New SolidBrush(Color.Black), cam.translateSquare(enemies(i).p))

                End If

            End If
        Next
    End Sub

    Private Sub proLog() 'This subroutine contains the checks needed to decide what happens to each projectile, update their positions, and draw the projectiles.
        Label3.Text = pro.Count 'testing


        For p As Integer = 0 To pro.Count - 1
            If Not pro(p).ded Then
                pro(p).collisonLogi(walls)
                Dim temp As New Point(cam.translatePoint(pro(p).GraphicPoint))
                If pro(p).friendly Then
                    For en As Integer = 0 To enemies.Count - 1
                        If enemies(en).item_distance(pro(p).p(0)) < zoomConstant Then
                            If pro(p).collisionUnit(enemies(en)) Then
                                pro(p).ded = True
                                enemies(en).CurrentHP -= pro(p).weap.damage
                                If enemies(en).CurrentHP <= 0 Then
                                    enemies(en).ded = True
                                    score += enemies(en).Worth
                                    ScoreLable.Text = "Score: " & score
                                End If
                            End If

                        End If

                    Next


                    Gamegfx.FillEllipse(New SolidBrush(Color.DarkOrange), temp.X, temp.Y, Convert.ToSingle(pro(p).di), Convert.ToSingle(pro(p).di))

                    currentP += 1 'testing

                Else
                    If pro(p).collisionUnit(cha) Then
                        pro(p).ded = True
                        cha.CurrentHP -= pro(p).weap.damage
                        updateHPLabel()
                        HPBar.Step = -pro(p).weap.damage
                        HPBar.PerformStep()
                        If cha.CurrentHP <= 0 Then
                            cha.ded = True
                        End If


                    End If



                    Gamegfx.FillEllipse(New SolidBrush(Color.Crimson), temp.X, temp.Y, Convert.ToSingle(pro(p).di), Convert.ToSingle(pro(p).di))

                    End If

                pro(p).update()

            End If
        Next
    End Sub

    Private Sub chaLog() 'Handles how the character moves, collides with walls and draws them onto the image.


        movecheck()



        cha.collisionLogi(walls)



        cha.update()
        Label2.Text = "yo good" 'testing

        If zoomConstant = 24 Then
            Gamegfx.DrawImage(CharacterSelect.ChaImage, cam.translateSquare(cha.p)(0).X, cam.translateSquare(cha.p)(0).Y)
        Else
            Gamegfx.FillPolygon(New SolidBrush(Color.DarkBlue), cam.translateSquare(cha.p))
        End If


    End Sub

    Private Sub movecheck() 'Adds/subtracts accelration depending on the movebools that are set by the player when they press the "wasd" keys


        If MovBools(0) And MovBools(1) Then
            cha.A.y -= cha.sp
            cha.A.x += cha.sp
        ElseIf MovBools(0) And MovBools(3) Then
            cha.A.y -= cha.sp
            cha.A.x -= cha.sp
        ElseIf MovBools(2) And MovBools(1) Then
            cha.A.y += cha.sp
            cha.A.x += cha.sp
        ElseIf MovBools(2) And MovBools(3) Then
            cha.A.y += cha.sp
            cha.A.x -= cha.sp
        ElseIf MovBools(0) Then
            cha.A.y -= cha.sp
        ElseIf MovBools(1) Then
            cha.A.x += cha.sp
        ElseIf MovBools(2) Then
            cha.A.y += cha.sp
        ElseIf MovBools(3) Then
            cha.A.x -= cha.sp
        End If

    End Sub

    Private Sub firecheck() 'Checks if the gun is automatic and adds projectlies when the gun is off cooldown while the mouse button is pressed.
        If automatic Then
            If cha.Uncooldown = 0 And Not (currentGun Is Nothing) Then
                cha.Uncooldown = currentGun.cooldown


                For i As Integer = 1 To currentGun.numOfPro
                    addPro()
                Next

            End If
        End If
    End Sub


    Private Sub GameLoop_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, GameBox.KeyDown 'Takes in the keyboard input when the user first presses the key, and then applies the connected logic

        If e.KeyCode = Keys.W Then
            MovBools(0) = True
        ElseIf e.KeyCode = Keys.D Then
            MovBools(1) = True
        ElseIf e.KeyCode = Keys.S Then
            MovBools(2) = True
        ElseIf e.KeyCode = Keys.A Then
            MovBools(3) = True
        ElseIf e.KeyCode = Keys.NumPad0 Then 'lets the palyer switch weapons
            currentGun = guns(0)
        ElseIf e.KeyCode = Keys.NumPad1 Then
            currentGun = guns(1)
        ElseIf e.KeyCode = Keys.NumPad2 Then
            currentGun = guns(2)
        ElseIf e.KeyCode = Keys.NumPad3 Then
            currentGun = guns(3)
        ElseIf e.KeyCode = Keys.Escape Then 'Allows player to quit the game
            GameTimer.Stop()
            Pause.Show()
        End If

    End Sub

    Private Sub GameBox_KeyUp(sender As Object, e As KeyEventArgs) Handles GameBox.KeyUp, Me.KeyUp 'Handles when the user releases a key, this allows for "wasd" to be held down for movement, instead of tapping each time

        If e.KeyCode = Keys.W Then
            MovBools(0) = False
        ElseIf e.KeyCode = Keys.D Then
            MovBools(1) = False
        ElseIf e.KeyCode = Keys.S Then
            MovBools(2) = False
        ElseIf e.KeyCode = Keys.A Then
            MovBools(3) = False
        End If

    End Sub

    Private Sub GameBox_MouseDown(sender As Object, e As MouseEventArgs) Handles GameBox.MouseDown, Me.MouseDown 'when the user first presses the mouse key it adds a projectile and turns on automatic if the gun has the feature.
        If cha.Uncooldown = 0 And Not (currentGun Is Nothing) Then
            cha.Uncooldown = currentGun.cooldown
            If currentGun.automatic = False Then

                For i As Integer = 1 To currentGun.numOfPro
                    addPro()
                Next
            ElseIf automatic = False And currentGun.automatic = True Then
                automatic = True
            End If
        End If
    End Sub

    Private Sub GameLoop_MouseUp(sender As Object, e As MouseEventArgs) Handles GameBox.MouseUp, Me.MouseUp 'Makes sure the gun stops firing after the mouse button is released
        If automatic Then
            automatic = False
        End If
    End Sub

    Private Sub addPro() 'subroutine to add a projectile to the list, saves having to type out the line everytime.
        pro.Add(New Projectile(cha.item_center, New Point(MousePosition.X + cam.pp.X - Me.Location.X, MousePosition.Y + cam.pp.Y - Me.Location.Y), currentGun, True, zoomConstant))
    End Sub

    Private Sub updateHPLabel() 'Updates the HPLabel text
        HPLable.Text = cha.CurrentHP & "/" & cha.MaxHP
    End Sub

End Class