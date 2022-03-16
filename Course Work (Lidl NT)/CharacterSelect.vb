Public Class CharacterSelect

    Public Shared zoomConstant As Integer = 24
    Public Shared ChaImage As Bitmap
    Private ZoomPicked As Boolean = False
    Private ChaPicked As Boolean = False
    Private Sub PBReturn_Click(sender As Object, e As EventArgs) Handles PBReturn.Click 'Sends the user back to the main menu
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click 'Starts the game once the scale has been selected
        If ZoomPicked And ChaPicked Then
            Me.Hide()
            GameLoop.Show()
        ElseIf Not ZoomPicked Then
            MsgBox("Please pick a scale")
        ElseIf Not ChaPicked Then
            MsgBox("Please pick a character")
        Else
            MsgBox("Please pick both a scale and character")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Selects the 5 scale and allows the game to be played
        zoomConstant = 5
        Label1.Text = zoomConstant
        ZoomPicked = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Selects the 5 scale and allows the game to be played
        zoomConstant = 24
        Label1.Text = zoomConstant
        ZoomPicked = True
    End Sub

    Private Sub CharacterSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Sets up the text for the lables
        Label1.Text = "Please choose a zoom"
        Label2.Text = "Please choose a character"
    End Sub

    Private Sub ChaSelect1(sender As Object, e As EventArgs) Handles PBChar1.Click, Char1.Click 'Sets the image to the first charater can allows for the user to progress to the game.
        ChaImage = New Bitmap("Player1.bmp")
        Label2.Text = "Smile"
        ChaPicked = True
    End Sub
    Private Sub ChaSelect2(sender As Object, e As EventArgs) Handles PBChar2.Click, Char2.Click 'picks the second character
        ChaImage = New Bitmap("Player2.bmp")
        Label2.Text = "Nose"
        ChaPicked = True
    End Sub
    Private Sub ChaSelect3(sender As Object, e As EventArgs) Handles PBChar3.Click, Char3.Click 'picks the thrid character
        ChaImage = New Bitmap("Player3.bmp")
        Label2.Text = "Fish"
        ChaPicked = True
    End Sub

End Class
