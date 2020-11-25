<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracaoEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracaoEmail))
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnTestaConexao = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSSLConnection = New System.Windows.Forms.CheckBox()
        Me.chkBackup = New System.Windows.Forms.CheckBox()
        Me.nudPorta = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboProtocolo = New System.Windows.Forms.ComboBox()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudPorta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancela
        '
        Me.btnCancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Location = New System.Drawing.Point(446, 208)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 32)
        Me.btnCancela.TabIndex = 10
        Me.btnCancela.Text = "Cancela"
        Me.ToolTip.SetToolTip(Me.btnCancela, "Clique aqui para cancelar as alterações.")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(355, 208)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 32)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.ToolTip.SetToolTip(Me.btnOK, "Clique aqui para salvar as alterações.")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnTestaConexao
        '
        Me.btnTestaConexao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTestaConexao.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestaConexao.Location = New System.Drawing.Point(12, 208)
        Me.btnTestaConexao.Name = "btnTestaConexao"
        Me.btnTestaConexao.Size = New System.Drawing.Size(145, 32)
        Me.btnTestaConexao.TabIndex = 8
        Me.btnTestaConexao.Text = "Testa Conexão"
        Me.ToolTip.SetToolTip(Me.btnTestaConexao, "Clique aqui para testar se sua conexão está ativa.")
        Me.btnTestaConexao.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkSSLConnection)
        Me.GroupBox1.Controls.Add(Me.chkBackup)
        Me.GroupBox1.Controls.Add(Me.nudPorta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProtocolo)
        Me.GroupBox1.Controls.Add(Me.txtSenha)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtServidor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 195)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'chkSSLConnection
        '
        Me.chkSSLConnection.AutoSize = True
        Me.chkSSLConnection.Location = New System.Drawing.Point(109, 169)
        Me.chkSSLConnection.Name = "chkSSLConnection"
        Me.chkSSLConnection.Size = New System.Drawing.Size(119, 22)
        Me.chkSSLConnection.TabIndex = 17
        Me.chkSSLConnection.Text = "Conexão SSL"
        Me.ToolTip.SetToolTip(Me.chkSSLConnection, "Informe se a conexão é segura")
        Me.chkSSLConnection.UseVisualStyleBackColor = True
        '
        'chkBackup
        '
        Me.chkBackup.AutoSize = True
        Me.chkBackup.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBackup.Location = New System.Drawing.Point(109, 197)
        Me.chkBackup.Name = "chkBackup"
        Me.chkBackup.Size = New System.Drawing.Size(307, 22)
        Me.chkBackup.TabIndex = 16
        Me.chkBackup.Text = "Guardar cópia do e-mail na pasta DSC-RA"
        Me.ToolTip.SetToolTip(Me.chkBackup, "Informe se deseja salvar uma cópia dos e-mails na pasta DSC-RA.")
        Me.chkBackup.UseVisualStyleBackColor = True
        Me.chkBackup.Visible = False
        '
        'nudPorta
        '
        Me.nudPorta.Location = New System.Drawing.Point(109, 79)
        Me.nudPorta.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudPorta.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPorta.Name = "nudPorta"
        Me.nudPorta.Size = New System.Drawing.Size(63, 24)
        Me.nudPorta.TabIndex = 2
        Me.nudPorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip.SetToolTip(Me.nudPorta, "Informe a Porta do Servidor.")
        Me.nudPorta.Value = New Decimal(New Integer() {110, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 18)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Protocolo:"
        '
        'cboProtocolo
        '
        Me.cboProtocolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProtocolo.FormattingEnabled = True
        Me.cboProtocolo.Location = New System.Drawing.Point(109, 17)
        Me.cboProtocolo.Name = "cboProtocolo"
        Me.cboProtocolo.Size = New System.Drawing.Size(121, 26)
        Me.cboProtocolo.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.cboProtocolo, "Selecione o Protocolo IMAP ou POP.")
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(109, 139)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(149, 24)
        Me.txtSenha.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.txtSenha, "Informe a senha para acessar a caixa postal das NF-e")
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(109, 109)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(253, 24)
        Me.txtUsuario.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.txtUsuario, "Informe o e-mail da caixa postal que receberá as NF-e. Algo como nfe@dominio.com." & _
        "br.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Usuário:"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(109, 49)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(419, 24)
        Me.txtServidor.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.txtServidor, "Informe o servidor IMAP ou POP. Algo como pop3.dominio.com.br ou imap.dominio.com" & _
        ".br.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Servidor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Porta:"
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "DSC-RA - Configuração de Protocolo de E-mail"
        '
        'frmConfiguracaoEmail
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancela
        Me.ClientSize = New System.Drawing.Size(540, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnTestaConexao)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfiguracaoEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DSC-RA - Configuração de Protocolo de E-mail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudPorta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnTestaConexao As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProtocolo As System.Windows.Forms.ComboBox
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudPorta As System.Windows.Forms.NumericUpDown
    Private WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents chkBackup As System.Windows.Forms.CheckBox
    Friend WithEvents chkSSLConnection As System.Windows.Forms.CheckBox
End Class
