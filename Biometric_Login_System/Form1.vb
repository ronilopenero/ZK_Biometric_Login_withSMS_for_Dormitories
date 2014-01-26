Imports zkemkeeper
Imports System.IO.Ports

Public Class Form1
    Dim zkem As New Zkem


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Timer1.Interval = 1000
        zkem.connect()
        zkem.StoreUserIds()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        Dim enroll As New Enrollment_Form
        enroll.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        zkem.GetLogs()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim sms As New TimedSMS("COM9")
        'sms.Open()
        'sms.SendSMS("09225176914", "Hello from VB.Net")
        'sms.Close()

        Dim sms As New SerialPort
        With sms
            .BaudRate = 9600
            .PortName = "COM9"
            .DataBits = 8
            .RtsEnable = True
            .Handshake = Handshake.RequestToSend
            .Open()
            .Write("AT+CMGS=" & Chr(34) & "09225176914" & Chr(34) & vbCrLf)
            .Write("Hello World" & vbCrLf & Chr(26))
            .Close()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    End Sub
End Class
