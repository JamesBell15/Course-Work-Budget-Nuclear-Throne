Public Class Pause
    Private Sub ResumeButton_Click(sender As Object, e As EventArgs) Handles ResumeButton.Click 'Resumes the current game
        GameLoop.Show()
        GameLoop.GameTimer.Start()
        Me.Close()
    End Sub

    Private Sub RestartButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click 'Restarts the game with the same parameters
        GameLoop.Close()
        GameLoop.Show()
        Me.Close()
    End Sub

    Private Sub MainButton_Click(sender As Object, e As EventArgs) Handles MainButton.Click 'Returns to the main menu
        GameLoop.Close()
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click 'Exits the program
        End
    End Sub

    Private Sub Pause_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'If the player has died they won't be able to resume the current game
        If GameLoop.GameOver Then
            ResumeButton.Hide()
        Else
            ResumeButton.Show()
        End If
    End Sub
End Class