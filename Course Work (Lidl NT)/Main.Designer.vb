<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.PBTitle = New System.Windows.Forms.PictureBox()
        Me.BPlay = New System.Windows.Forms.Button()
        Me.BLeader = New System.Windows.Forms.Button()
        Me.BSetting = New System.Windows.Forms.Button()
        Me.BQuit = New System.Windows.Forms.Button()
        CType(Me.PBTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBTitle
        '
        Me.PBTitle.BackgroundImage = CType(resources.GetObject("PBTitle.BackgroundImage"), System.Drawing.Image)
        Me.PBTitle.Location = New System.Drawing.Point(29, 19)
        Me.PBTitle.Name = "PBTitle"
        Me.PBTitle.Size = New System.Drawing.Size(680, 80)
        Me.PBTitle.TabIndex = 4
        Me.PBTitle.TabStop = False
        '
        'BPlay
        '
        Me.BPlay.Location = New System.Drawing.Point(235, 105)
        Me.BPlay.Name = "BPlay"
        Me.BPlay.Size = New System.Drawing.Size(240, 80)
        Me.BPlay.TabIndex = 5
        Me.BPlay.Text = "Play"
        Me.BPlay.UseVisualStyleBackColor = True
        '
        'BLeader
        '
        Me.BLeader.Location = New System.Drawing.Point(235, 191)
        Me.BLeader.Name = "BLeader"
        Me.BLeader.Size = New System.Drawing.Size(240, 80)
        Me.BLeader.TabIndex = 6
        Me.BLeader.Text = "Leader Board"
        Me.BLeader.UseVisualStyleBackColor = True
        '
        'BSetting
        '
        Me.BSetting.Location = New System.Drawing.Point(235, 277)
        Me.BSetting.Name = "BSetting"
        Me.BSetting.Size = New System.Drawing.Size(240, 80)
        Me.BSetting.TabIndex = 7
        Me.BSetting.Text = "Settings"
        Me.BSetting.UseVisualStyleBackColor = True
        '
        'BQuit
        '
        Me.BQuit.Location = New System.Drawing.Point(235, 363)
        Me.BQuit.Name = "BQuit"
        Me.BQuit.Size = New System.Drawing.Size(240, 80)
        Me.BQuit.TabIndex = 8
        Me.BQuit.Text = "Quit"
        Me.BQuit.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 490)
        Me.ControlBox = False
        Me.Controls.Add(Me.BQuit)
        Me.Controls.Add(Me.BSetting)
        Me.Controls.Add(Me.BLeader)
        Me.Controls.Add(Me.BPlay)
        Me.Controls.Add(Me.PBTitle)
        Me.Name = "MainMenu"
        Me.Text = "Form1"
        CType(Me.PBTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBTitle As PictureBox
    Friend WithEvents BPlay As Button
    Friend WithEvents BLeader As Button
    Friend WithEvents BSetting As Button
    Friend WithEvents BQuit As Button
End Class
