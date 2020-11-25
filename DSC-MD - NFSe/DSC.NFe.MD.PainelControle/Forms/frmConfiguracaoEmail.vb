Imports DSC.NFe.RA


Public Class frmConfiguracaoEmail

    Private LocalEmailProtocol As EmailProtocolModel
    Private LocalClientKey As String

    Dim WithEvents emailClient As Global.DSC.EmailProtocol.IEmailClient

    Public Sub New(ByVal clientKey As String)

        Try
            ' This call is required by the designer.
            InitializeComponent()

            cboProtocolo.Items.AddRange({"POP", "IMAP"})

            LocalClientKey = clientKey

            LocalEmailProtocol = EmailProtocolController.GetEmailProtocol(clientKey)

            cboProtocolo.SelectedItem = IIf(LocalEmailProtocol.Protocol = EmailProtocolModel.enEmailProtocol.IMAP, "IMAP", "POP")
            txtServidor.Text = LocalEmailProtocol.Server
            nudPorta.Value = LocalEmailProtocol.Port
            txtUsuario.Text = LocalEmailProtocol.User
            txtSenha.Text = Cryptography.Cryptography.Decifrar(LocalEmailProtocol.Password, CP_Cryptography_Key)
            chkSSLConnection.Checked = LocalEmailProtocol.ConnectionSecurity

        Catch ex As Global.DSC.EmailProtocol.DSCMailException
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            LocalEmailProtocol.ClientKey = LocalClientKey
            LocalEmailProtocol.Protocol = IIf(cboProtocolo.SelectedItem = "IMAP", EmailProtocolModel.enEmailProtocol.IMAP, EmailProtocolModel.enEmailProtocol.POP)
            LocalEmailProtocol.Server = txtServidor.Text
            LocalEmailProtocol.Port = nudPorta.Value
            LocalEmailProtocol.User = txtUsuario.Text
            LocalEmailProtocol.Password = Cryptography.Cryptography.Cifrar(txtSenha.Text, CP_Cryptography_Key)
            LocalEmailProtocol.ConnectionSecurity = (chkSSLConnection.Checked)

            EmailProtocolController.SetEmailProtocol(LocalEmailProtocol)

            Me.Close()
            Me.Dispose()

        Catch ex As Global.DSC.EmailProtocol.DSCMailException
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnTestaConexao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestaConexao.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If cboProtocolo.SelectedItem = "POP" Then
            emailClient = New Global.DSC.EmailProtocol.POPClient
        Else
            emailClient = New Global.DSC.EmailProtocol.IMAPClient
        End If

        Try
            emailClient.host = txtServidor.Text
            emailClient.port = nudPorta.Value
            emailClient.user = txtUsuario.Text
            emailClient.pass = txtSenha.Text
            emailClient.SSL = (chkSSLConnection.Checked)
            emailClient.enableLog = True
            emailClient.connectAndLogin()

            emailClient.logout()

            MessageBox.Show("Teste de conexão com servidor de e-mail efetuado com sucesso.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Global.DSC.EmailProtocol.DSCMailException
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            emailClient = Nothing

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub cboProtocolo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProtocolo.SelectedIndexChanged
        SetPorta()
    End Sub

    Private Sub chkSSLConnection_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkSSLConnection.CheckedChanged
        SetPorta()
    End Sub

    Private Sub SetPorta()

        If cboProtocolo.SelectedItem = "IMAP" Then

            chkBackup.Visible = True

            Me.Size = New Size("550", "320")

            If chkSSLConnection.Checked Then
                nudPorta.Value = 993
            Else
                nudPorta.Value = 143
            End If

        Else

            chkBackup.Visible = False
            chkBackup.Checked = False

            Me.Size = New Size("550", "285")

            If chkSSLConnection.Checked Then
                nudPorta.Value = 995
            Else
                nudPorta.Value = 110
            End If

        End If

    End Sub

    Private Sub frmConfiguracaoEmail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class