Imports Microsoft.Win32

Public Class Verdict
    Public Property Chlsb_Drives As Object

    Private Sub Verdict_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label1.Text = ProgressBar1.Value & "% ...Initiating Self-Destruction"
        If ProgressBar1.Value >= 100 Then
            ProgressBar1.Value = ProgressBar1.Value
            MsgBox("You Chose Unwisely")
            Timer1.Stop()
            Dim DriveStr As String = ""
            Dim Regkey As RegistryKey
            Dim DArr As New ArrayList
            Dim i As Integer
            Dim Cnt As Integer = 0

            For i = 0 To Chlsb_Drives.CheckedItems.Count - 1
                Select Case Chlsb_Drives.CheckedItems(i).ToString()
                    Case Is = "A"
                        Cnt += 1 : DriveStr &= "A"
                    Case Is = "B"
                        Cnt += 2D : DriveStr &= "B"
                    Case Is = "C"
                        Cnt += 4D : DriveStr &= "C"
                    Case Is = "D"
                        Cnt += 8 : DriveStr &= "D"
                    Case Is = "E"
                        Cnt += 16 : DriveStr &= "E"
                    Case Is = "F"
                        Cnt += 32 : DriveStr &= "F"
                    Case Is = "G"
                        Cnt += 64 : DriveStr &= "G"
                    Case Is = "H"
                        Cnt += 128 : DriveStr &= "H"
                    Case Is = "I"
                        Cnt += 256 : DriveStr &= "I"
                    Case Is = "J"
                        Cnt += 512 : DriveStr &= "J"
                    Case Is = "K"
                        Cnt += 1024 : DriveStr &= "K"
                    Case Is = "L"
                        Cnt += 2048 : DriveStr &= "L"
                    Case Is = "M"
                        Cnt += 4096 : DriveStr &= "M"
                    Case Is = "N"
                        Cnt += 8192 : DriveStr &= "N"
                    Case Is = "O"
                        Cnt += 16384 : DriveStr &= "O"
                    Case Is = "P"
                        Cnt += 32768 : DriveStr &= "P"
                    Case Is = "Q"
                        Cnt += 65536 : DriveStr &= "Q"
                    Case Is = "R"
                        Cnt += 131072 : DriveStr &= "R"
                    Case Is = "S"
                        Cnt += 262144 : DriveStr &= "S"
                    Case Is = "T"
                        Cnt += 524288 : DriveStr &= "T"
                    Case Is = "U"
                        Cnt += 1048576 : DriveStr &= "U"
                    Case Is = "V"
                        Cnt += 2097152 : DriveStr &= "V"
                    Case Is = "W"
                        Cnt += 4194304 : DriveStr &= "W"
                    Case Is = "X"
                        Cnt += 8388608 : DriveStr &= "X"
                    Case Is = "Y"
                        Cnt += 16777216 : DriveStr &= "Y"
                    Case Is = "Z"
                        Cnt += 33554432 : DriveStr &= "Z"
                End Select
            Next
            'save drives' setting in registry
            Regkey = Registry.CurrentUser.CreateSubKey("Software\Hide Drive")
            Regkey.GetValue("Cnt", Cnt)
            Regkey.GetValue("Drives", DriveStr)
            Regkey.Close()
            ' Update registry key
            Regkey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", True)
            Regkey.GetValue("NoDrives", Cnt)
            Regkey.Close()
        End If
    End Sub

End Class