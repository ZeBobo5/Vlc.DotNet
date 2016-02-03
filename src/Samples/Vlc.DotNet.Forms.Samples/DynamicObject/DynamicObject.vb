Imports System.IO
Imports Vlc.DotNet

Public Class DynamicObject
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim b As Forms.VlcControl
        Dim aP As String
        b = New Vlc.DotNet.Forms.VlcControl

        b.BeginInit()
        If Environment.Is64BitOperatingSystem Then
            If Environment.Is64BitProcess Then
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\VLC")
            Else
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN\VLC")
            End If
        Else
            aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\VLC")
        End If
        b.VlcLibDirectory = New DirectoryInfo(aP)
        b.Parent = Panel1
        b.Dock = DockStyle.Fill
        AddHandler b.VlcLibDirectoryNeeded, AddressOf checkdir
        AddHandler b.Playing, AddressOf onPlay2

        Panel1.Controls.Add(b)

        b.EndInit()
    End Sub

    Private Function checkdir() As DirectoryInfo
        Dim aP As String

        If Environment.Is64BitOperatingSystem Then
            If Environment.Is64BitProcess Then
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\VLC")
            Else
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN\VLC")
            End If
        Else
            aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\VLC")
        End If
        If Not File.Exists(Path.Combine(aP, "libvlc.dll")) Then
            Using fbdDialog As New FolderBrowserDialog()
                fbdDialog.Description = "Select VLC Path"
                fbdDialog.SelectedPath = Path.Combine(aP, "VideoLAN\VLC")

                If fbdDialog.ShowDialog() = DialogResult.OK Then
                    Return New DirectoryInfo(fbdDialog.SelectedPath)
                End If
            End Using
        Else
            Return New DirectoryInfo(aP)
        End If
        Return Nothing
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim aP As Vlc.DotNet.Forms.VlcControl
        Using fbdDialog As New OpenFileDialog()
            fbdDialog.Title = "Select video"
            fbdDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            fbdDialog.Filter = "All files (*.*)|*.*"
            fbdDialog.RestoreDirectory = True
            fbdDialog.Multiselect = False

            If fbdDialog.ShowDialog() = DialogResult.OK Then
                aP = CType(Panel1.Controls(0), Vlc.DotNet.Forms.VlcControl)
                aP.Play(New Uri(fbdDialog.FileName))
            End If
        End Using

    End Sub

    Private Sub onPlay2()
        Dim aP As Vlc.DotNet.Forms.VlcControl
        aP = CType(Panel1.Controls(0), Vlc.DotNet.Forms.VlcControl)
        Dim aP2 As String = aP.GetCurrentMedia.URL
        If Me.InvokeRequired Then
            Me.Invoke(Sub() onPlay2())
            Return
        End If
        For Each aM In aP.GetCurrentMedia().TracksInformations
            If aM.Type = Core.Interops.Signatures.MediaTrackTypes.Audio Then
                Label1.Text = aM.CodecName
            Else
                If aM.Type = Core.Interops.Signatures.MediaTrackTypes.Video Then
                    Label2.Text = aM.CodecName
                End If
            End If
        Next
    End Sub
End Class
