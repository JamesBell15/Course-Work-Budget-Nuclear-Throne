Public Class MainMenu

    Private Sub BQuit_Click(sender As Object, e As EventArgs) Handles BQuit.Click 'Quits the program 
        Me.Close()
    End Sub

    Private Sub BPlay_Click(sender As Object, e As EventArgs) Handles BPlay.Click 'Opens character selection
        Me.Hide()
        CharacterSelect.Show()
    End Sub

    Private Sub BLeader_Click(sender As Object, e As EventArgs) Handles BLeader.Click ' Opens the leader board
        Me.Hide()
        LeaderBoard.Show()
    End Sub

    Private Sub BSetting_Click(sender As Object, e As EventArgs) Handles BSetting.Click 'Opens settings
        Me.Hide()
        Settings.Show()
    End Sub
End Class
