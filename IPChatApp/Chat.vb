Imports System.IO
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
        NotifyIcon1.Icon = SystemIcons.Application
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        Listening()
        Timer1.Enabled = True
    End Sub
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        If btnConnect.Text = "Connect" Then
            Dim isOnline As Boolean = False
            Try
                If My.Computer.Network.Ping(txtServer.Text) Then
                    isOnline = True
                Else
                    isOnline = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If isOnline = True Then

                txtName.Enabled = False
                txtServer.Enabled = False
                btnConnect.Text = "Disconnect"
            Else
                MsgBox("Cannot connect because the IP address is unreachable.")
            End If
        Else
            txtName.Enabled = True
            txtServer.Enabled = True
            btnConnect.Text = "Connect"
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Listener.Pending = True Then
            Message = ""
            Client = Listener.AcceptTcpClient()
            Console.WriteLine("Fire1")

            Dim Reader As New StreamReader(Client.GetStream())
            While Reader.Peek > -1
                Message = Message + Convert.ToChar(Reader.Read()).ToString

                Console.WriteLine("Fire2")
            End While
            With rtbMessages
                .ForeColor = Color.Black
                .Text += Message + vbCrLf

                NotifyIcon1.BalloonTipTitle = "New Message"
                NotifyIcon1.BalloonTipText = "New Message"
                NotifyIcon1.ShowBalloonTip(20000)

                If Me.WindowState = FormWindowState.Normal Then
                Else
                    NotifyIcon1.Icon = SystemIcons.Information
                End If



            End With
        End If
    End Sub
    Private Sub btnSend_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles btnSend.Click

        'Check to make sure that the user has entered 
        'a display name, and a client IP Address
        'If Not, Show a Message Box

        Try
            Client = New TcpClient(txtServer.Text, 65535)

            'Declare the Client as an IP Address. 
            'Must be in the Correct form. eg. 000.0.0.0
            Dim Writer As New StreamWriter(Client.GetStream())

            Writer.Write(txtName.Text & " Says:  " & rtbBody.Text & vbCrLf)
            Writer.Flush()

            'Write the Message in the stream

            rtbMessages.Text += (txtName.Text & " Says:  " & rtbBody.Text & vbCrLf) + vbCrLf
            rtbBody.Text = ""
        Catch ex As Exception
            Console.WriteLine(ex)
            Dim Errorresult As String = ex.Message
            MessageBox.Show(Errorresult & vbCrLf & vbCrLf &
                                "Please Review Client Address",
                                "Error Sending Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick, NotifyIcon1.BalloonTipClicked
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
        Else
            Me.WindowState = FormWindowState.Normal
            NotifyIcon1.Icon = SystemIcons.Application
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

End Class