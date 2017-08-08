<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chat
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
        Me.components = New System.ComponentModel.Container()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtbMessages = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsExit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Exit1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.cmsExit.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(158, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 30)
        Me.txtName.TabIndex = 0
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(413, 26)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(126, 30)
        Me.txtServer.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Display Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(300, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "IP Address"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(553, 24)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(101, 32)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtbMessages)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 287)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 150)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Messages"
        '
        'rtbMessages
        '
        Me.rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbMessages.Location = New System.Drawing.Point(3, 26)
        Me.rtbMessages.Name = "rtbMessages"
        Me.rtbMessages.ReadOnly = True
        Me.rtbMessages.Size = New System.Drawing.Size(639, 121)
        Me.rtbMessages.TabIndex = 0
        Me.rtbMessages.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtbBody)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 174)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Body"
        '
        'rtbBody
        '
        Me.rtbBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbBody.Location = New System.Drawing.Point(3, 26)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(527, 145)
        Me.rtbBody.TabIndex = 0
        Me.rtbBody.Text = ""
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(550, 150)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(101, 30)
        Me.btnSend.TabIndex = 4
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "New Message"
        Me.NotifyIcon1.BalloonTipTitle = "New Message"
        Me.NotifyIcon1.ContextMenuStrip = Me.cmsExit
        Me.NotifyIcon1.Text = "Chat"
        Me.NotifyIcon1.Visible = True
        '
        'cmsExit
        '
        Me.cmsExit.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsExit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Exit1})
        Me.cmsExit.Name = "cmsExit"
        Me.cmsExit.Size = New System.Drawing.Size(103, 28)
        '
        'Exit1
        '
        Me.Exit1.Name = "Exit1"
        Me.Exit1.Size = New System.Drawing.Size(102, 24)
        Me.Exit1.Text = "Exit"
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Chat
        '
        Me.AcceptButton = Me.btnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 449)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.txtName)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Chat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chat"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.cmsExit.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rtbMessages As RichTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rtbBody As RichTextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmsExit As ContextMenuStrip
    Friend WithEvents Exit1 As ToolStripMenuItem
    Friend WithEvents Timer2 As Timer
End Class
