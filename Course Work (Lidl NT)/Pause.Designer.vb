<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pause
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ResumeButton = New System.Windows.Forms.Button()
        Me.RestartButton = New System.Windows.Forms.Button()
        Me.MainButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ResumeButton
        '
        Me.ResumeButton.Location = New System.Drawing.Point(12, 12)
        Me.ResumeButton.Name = "ResumeButton"
        Me.ResumeButton.Size = New System.Drawing.Size(120, 43)
        Me.ResumeButton.TabIndex = 0
        Me.ResumeButton.Text = "Resume"
        Me.ResumeButton.UseVisualStyleBackColor = True
        '
        'RestartButton
        '
        Me.RestartButton.Location = New System.Drawing.Point(12, 61)
        Me.RestartButton.Name = "RestartButton"
        Me.RestartButton.Size = New System.Drawing.Size(120, 43)
        Me.RestartButton.TabIndex = 1
        Me.RestartButton.Text = "Restart"
        Me.RestartButton.UseVisualStyleBackColor = True
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(12, 110)
        Me.MainButton.Name = "MainButton"
        Me.MainButton.Size = New System.Drawing.Size(120, 43)
        Me.MainButton.TabIndex = 2
        Me.MainButton.Text = "Main Menu"
        Me.MainButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(12, 159)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(120, 43)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.Text = "Quit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'Pause
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(142, 212)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.MainButton)
        Me.Controls.Add(Me.RestartButton)
        Me.Controls.Add(Me.ResumeButton)
        Me.Name = "Pause"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ResumeButton As Button
    Friend WithEvents RestartButton As Button
    Friend WithEvents MainButton As Button
    Friend WithEvents ExitButton As Button
End Class
