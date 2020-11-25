Public Class frmConfiguracaoSMTP

    Private LocalSMTPConfiguration As SMTPConfigurationModel
    Private LocalClientKey As String
    Private SSLConnection As Boolean = False

    Public Sub New(ByVal clientKey As String)

        Try

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            LocalClientKey = clientKey

            LocalSMTPConfiguration = SMTPConfigurationController.GetSMTPConfiguration(clientKey)

            txtServidor.Text = LocalSMTPConfiguration.HostName
            nudPorta.Value = IIf(LocalSMTPConfiguration.PortNumber < nudPorta.Minimum, nudPorta.Minimum, LocalSMTPConfiguration.PortNumber)
            txtUsuario.Text = LocalSMTPConfiguration.User
            txtPassword.Text = Cryptography.Cryptography.Decifrar(LocalSMTPConfiguration.Password, CP_Cryptography_Key)
            chkSSLConnection.Checked = LocalSMTPConfiguration.SSL
            SSLConnection = chkSSLConnection.Checked

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            LocalSMTPConfiguration.ClientKey = LocalClientKey
            LocalSMTPConfiguration.HostName = txtServidor.Text
            LocalSMTPConfiguration.PortNumber = nudPorta.Value
            LocalSMTPConfiguration.User = txtUsuario.Text
            LocalSMTPConfiguration.Password = Cryptography.Cryptography.Cifrar(txtPassword.Text, CP_Cryptography_Key)
            LocalSMTPConfiguration.SSL = chkSSLConnection.Checked

            SMTPConfigurationController.SetSMTPConfiguration(LocalSMTPConfiguration)

            Me.Close()
            Me.Dispose()


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

        Try
            Dim nt As New System.Net.NetworkCredential(txtUsuario.Text, txtPassword.Text)
            Global.DSC.EmailProtocol.SMTPClient.SendEmail(txtServidor.Text, nudPorta.Value, txtUsuario.Text, txtUsuario.Text, New List(Of String)({txtUsuario.Text}), SSLConnection, nt, "Teste de e-mail SMT")
            MessageBox.Show("Configuração SMTP efetuada com sucesso.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub chkSSLConection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSSLConnection.CheckedChanged
        SSLConnection = CType(sender, CheckBox).Checked
        If chkSSLConnection.Checked Then
            nudPorta.Value = 587
        Else
            nudPorta.Value = 25
        End If
    End Sub

End Class