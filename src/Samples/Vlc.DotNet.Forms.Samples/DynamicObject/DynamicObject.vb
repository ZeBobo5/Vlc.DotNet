Option Strict On

Imports System.IO
Imports System.Text.RegularExpressions
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
        b.Name = "VlcControl"
        b.Parent = Panel1
        b.Dock = DockStyle.Fill
        AddHandler b.VlcLibDirectoryNeeded, AddressOf checkVLCDir
        AddHandler b.Playing, AddressOf OnPlaying

        Panel1.Controls.Add(b)

        b.EndInit()
    End Sub

    Private Sub checkVLCDir(sender As Object, e As Forms.VlcLibDirectoryNeededEventArgs)
        Dim aPath As String
        Dim aTitle As String

        If Environment.Is64BitOperatingSystem Then
            If Environment.Is64BitProcess Then
                aPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                aTitle = "Select VLC x64 bit Path"
            Else
                aPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
                aTitle = "Select VLC x86 bit Path"
            End If
        Else
            aPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            aTitle = "Select VLC x86 bit Path"
        End If
        If Not File.Exists(Path.Combine(Path.Combine(aPath, "VideoLAN\VLC"), "libvlc.dll")) Then
            Using fbdDialog As New FolderBrowserDialog()
                fbdDialog.Description = aTitle
                fbdDialog.SelectedPath = aPath

                If fbdDialog.ShowDialog() = DialogResult.OK Then
                    e.VlcLibDirectory = New DirectoryInfo(fbdDialog.SelectedPath)
                End If
            End Using
        Else
            e.VlcLibDirectory = New DirectoryInfo(Path.Combine(aPath, "VideoLAN\VLC"))
        End If
        e.VlcLibDirectory = Nothing
    End Sub

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

    Private Sub OnPlaying(sender As Object, e As Core.VlcMediaPlayerPlayingEventArgs)
        Dim aVlcControl As Forms.VlcControl
        aVlcControl = CType(Panel1.Controls.Find("VlcControl", True)(0), Vlc.DotNet.Forms.VlcControl)
        Dim aP2 As String = aVlcControl.GetCurrentMedia.URL
        If Me.InvokeRequired Then
            Me.Invoke(Sub() OnPlaying(sender, e))
            Return
        End If
        For Each aM In aVlcControl.GetCurrentMedia().TracksInformations
            If aM.Type = Core.Interops.Signatures.MediaTrackTypes.Audio Then
                Label1.Text = aM.CodecName
            Else
                If aM.Type = Core.Interops.Signatures.MediaTrackTypes.Video Then
                    Label2.Text = aM.CodecName
                End If
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim aP As Vlc.DotNet.Forms.VlcControl
        If Regex.IsMatch(txtURL.Text, "http:\/\/.*?") Then
            aP = CType(Panel1.Controls(0), Vlc.DotNet.Forms.VlcControl)
            aP.Play(New Uri(txtURL.Text))
            '            aP.SetMedia()
        End If
    End Sub
End Class
