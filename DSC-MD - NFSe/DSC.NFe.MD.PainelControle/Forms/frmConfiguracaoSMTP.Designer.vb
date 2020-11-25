<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracaoSMTP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracaoSMTP))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.nudPorta = New System.Windows.Forms.NumericUpDown()
        Me.btnTestaConexao = New System.Windows.Forms.Button()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.chkSSLConnection = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.nudPorta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "DSC-MD - Configuração SMTP"
        '
        'btnCancela
        '
        Me.btnCancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Location = New System.Drawing.Point(347, 188)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 32)
        Me.btnCancela.TabIndex = 19
        Me.btnCancela.Text = "Cancela"
        Me.ToolTip.SetToolTip(Me.btnCancela, "Clique aqui para cancelar as alterações.")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'nudPorta
        '
        Me.nudPorta.Location = New System.Drawing.Point(135, 53)
        Me.nudPorta.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudPorta.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPorta.Name = "nudPorta"
        Me.nudPorta.Size = New System.Drawing.Size(63, 24)
        Me.nudPorta.TabIndex = 2
        Me.nudPorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip.SetToolTip(Me.nudPorta, "Informe a porta de acesso ao servidor SMTP.")
        Me.nudPorta.Value = New Decimal(New Integer() {465, 0, 0, 0})
        '
        'btnTestaConexao
        '
        Me.btnTestaConexao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTestaConexao.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestaConexao.Location = New System.Drawing.Point(5, 188)
        Me.btnTestaConexao.Name = "btnTestaConexao"
        Me.btnTestaConexao.Size = New System.Drawing.Size(145, 32)
        Me.btnTestaConexao.TabIndex = 17
        Me.btnTestaConexao.Text = "Testa Conexão"
        Me.ToolTip.SetToolTip(Me.btnTestaConexao, "Clique aqui para testar se sua conexão está ativa.")
        Me.btnTestaConexao.UseVisualStyleBackColor = True
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(136, 20)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(292, 24)
        Me.txtServidor.TabIndex = 1
        Me.txtServidor.Text = "smtp.gmail.com"
        Me.ToolTip.SetToolTip(Me.txtServidor, "Informe o nome do servidor SMTP.")
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(256, 188)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 32)
        Me.btnOK.TabIndex = 18
        Me.btnOK.Text = "OK"
        Me.ToolTip.SetToolTip(Me.btnOK, "Clique aqui para salvar as alterações.")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(136, 119)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(149, 24)
        Me.txtPassword.TabIndex = 10
        Me.txtPassword.Text = "9virtual"
        Me.ToolTip.SetToolTip(Me.txtPassword, "Informe a senha do usuário.")
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(136, 86)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(292, 24)
        Me.txtUsuario.TabIndex = 9
        Me.txtUsuario.Text = "caquiti2013@gmail.com"
        Me.ToolTip.SetToolTip(Me.txtUsuario, "Informe o Usuário através do qual as mensagens SMTP serão enviadas.")
        '
        'chkSSLConnection
        '
        Me.chkSSLConnection.AutoSize = True
        Me.chkSSLConnection.Location = New System.Drawing.Point(136, 149)
        Me.chkSSLConnection.Name = "chkSSLConnection"
        Me.chkSSLConnection.Size = New System.Drawing.Size(119, 22)
        Me.chkSSLConnection.TabIndex = 13
        Me.chkSSLConnection.Text = "Conexão SSL"
        Me.ToolTip.SetToolTip(Me.chkSSLConnection, "Informe se a conexão é segura")
        Me.chkSSLConnection.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkSSLConnection)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.nudPorta)
        Me.GroupBox1.Controls.Add(Me.txtServidor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 180)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 18)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Usuário:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Servidor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Porta:"
        '
        'frmConfiguracaoSMTP
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancela
        Me.ClientSize = New System.Drawing.Size(438, 227)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnTestaConexao)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfiguracaoSMTP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DKP-MD - Configuração SMTP"
        CType(Me.nudPorta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents nudPorta As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnTestaConexao As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSSLConnection As System.Windows.Forms.CheckBox
End Class
