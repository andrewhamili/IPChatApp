﻿Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Public Class Chat

    Dim Listener As New TcpListener(65535)
    Dim Client As New TcpClient
    Dim Message As String = ""

    Dim ListenerThread As New Thread(New ThreadStart(AddressOf Listening))

    Private Sub Listening()
        Listener.Start()
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim Param As CreateParams = MyBase.CreateParams
            Param.ClassStyle = Param.ClassStyle Or &H200
            Return Param
        End Get
    End Property

    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles Me.Load
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = Me.Icon
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        Listening()
        Timer1.Enabled = True
        rtbBody.Enabled = False
    End Sub
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If btnConnect.Text = "Connect" Then
            Dim isOnline As Boolean = Ping(txtServer.Text)


            If isOnline = True Then

                txtName.Enabled = False
                txtServer.Enabled = False
                btnConnect.Text = "Disconnect"
                rtbBody.Enabled = True
            Else
                MsgBox("Cannot connect because the IP address is unreachable.")
            End If
        Else
            btnConnect.Text = "Connect"
            txtName.Enabled = True
            txtServer.Enabled = True
            rtbBody.Enabled = False
        End If




    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Listener.Pending = True Then
            Message = ""
            Client = Listener.AcceptTcpClient()

            Dim Reader As New StreamReader(Client.GetStream())
            While Reader.Peek > -1
                Message = Message + Convert.ToChar(Reader.Read()).ToString
            End While
            With rtbMessages
                .ForeColor = Color.Black
                .Text += Message + vbCrLf

                .SelectionStart = .Text.Length
                .ScrollToCaret()

                NotifyIcon1.BalloonTipTitle = "New Message"
                NotifyIcon1.BalloonTipText = "New Message"

                NotifyIcon1.ShowBalloonTip(20000)





                If Me.WindowState = FormWindowState.Normal Then
                Else
                    'Dim response As DialogResult = MsgBox("One new message received!! Do you want to open it now?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + 4096, "IP Chat App")
                    'If response = DialogResult.Yes Then
                    '    Me.WindowState = FormWindowState.Normal
                    '    Exit Sub
                    'End If
                    'Timer2.Enabled = True
                    'NotifyIcon1.Icon = SystemIcons.Information
                    Me.WindowState = FormWindowState.Normal
                End If



            End With
        End If
    End Sub
    Private Sub btnSend_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles btnSend.Click
        If btnConnect.Text = "Connect" Then
            MsgBox("Please Connect first!!")
            Exit Sub
        End If
        If String.IsNullOrEmpty(rtbBody.Text) Then
            MsgBox("Please enter a message first", MsgBoxStyle.Exclamation, "IP Chat App")
            Exit Sub
        End If
        'Check to make sure that the user has entered 
        'a display name, and a client IP Address
        'If Not, Show a Message Box

        If Ping(txtServer.Text) = True Then
            Try
                Client = New TcpClient(txtServer.Text, 65535)

                'Declare the Client as an IP Address. 
                'Must be in the Correct form. eg. 000.0.0.0
                Dim Writer As New StreamWriter(Client.GetStream())

                Writer.Write(txtName.Text & " Says:  " & rtbBody.Text & vbCrLf)
                Writer.Flush()

                'Write the Message in the stream

                rtbMessages.Text += (txtName.Text & " Says:  " & rtbBody.Text & vbCrLf) + vbCrLf
                rtbMessages.SelectionStart = rtbMessages.Text.Length
                rtbMessages.ScrollToCaret()

                rtbBody.Text = ""
            Catch ex As Exception
                Console.WriteLine(ex)
                Dim Errorresult As String = ex.Message
                MessageBox.Show(Errorresult & vbCrLf & vbCrLf &
                                    "Please Review Client Address",
                                    "Error Sending Message" & vbCrLf &
                                    "The peer maybe offline",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MsgBox("The specified peer has become unreachable. Please try again later.")
        End If
        rtbBody.Focus()

    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick, NotifyIcon1.BalloonTipClicked
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
        Else
            Me.WindowState = FormWindowState.Normal

            Me.ShowInTaskbar = True
        End If
        Timer2.Enabled = False
    End Sub
    Private Sub Chat_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
        Else
            Me.ShowInTaskbar = True
        End If
    End Sub

    Private Sub Exit1_Click(sender As Object, e As EventArgs) Handles Exit1.Click
        ListenerThread.Abort()
        Me.Close()
    End Sub

    Public Function Ping(ByVal peer As String)

        Dim result As Boolean



        Try
            If My.Computer.Network.Ping(peer) Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return result
    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Start As Date = Date.Now.ToString("HH:mm:ss")
        Dim span As TimeSpan
        While span.TotalSeconds <> 60
            Console.WriteLine(span.TotalSeconds)
            Dim liveDate As Date = Date.Now.ToString("HH:mm:ss")
            span = liveDate.Subtract(Start)
            If span.TotalSeconds = 30 Then
                NotifyIcon1.ShowBalloonTip(20000)
                MsgBox("There are unread messages.", MsgBoxStyle.Information, "IP Chat App")
                Start = Date.Now.ToString("HH:mm:ss")
            End If

        End While
    End Sub

    Private Sub cbEnterToSend_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnterToSend.CheckedChanged
        If cbEnterToSend.Checked Then
            AcceptButton = btnSend
        ElseIf cbEnterToSend.Checked = False Then
            AcceptButton = Nothing
        End If
    End Sub
End Class