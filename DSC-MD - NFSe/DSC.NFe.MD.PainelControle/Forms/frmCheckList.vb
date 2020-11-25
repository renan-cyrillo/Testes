Imports DSC.EmailProtocol

Public Class frmCheckList

    Dim WithEvents emailClient As IEmailClient

    Private Const CL_TESTE_CONEXAO_SERVIDOR_EMAIL As String = "Testando a conexão com o servidor de e-mail do CNPJ: "
    Private Const CL_TESTE_CERTIFICADO_DIGITAL As String = "Testando o certificado digital do CNPJ: "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InicializaCheckList()

    End Sub

    Private Sub InicializaCheckList()

        DataGridView1.Rows.Clear()

        DataGridView1.Rows.Add("Testando conexão com Sefaz SP")

        Dim cnpj As Long

        For Each painel As PainelControleController In Global.DSC.NFe.RA.ClientController.GetRARegistry
            cnpj = painel.Client.ClientKey
            DataGridView1.Rows.Add(CL_TESTE_CONEXAO_SERVIDOR_EMAIL, String.Format("{0:00\.000\.000\/0000\-00}", cnpj), painel.Client.ClientKey, "", "")
            DataGridView1.Rows.Add(CL_TESTE_CERTIFICADO_DIGITAL, String.Format("{0:00\.000\.000\/0000\-00}", cnpj), painel.Client.ClientKey, "", "")
        Next

        DataGridView1.EndEdit()

    End Sub

    Private Sub btnInicia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicia.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        InicializaCheckList()

        For Each row As DataGridViewRow In DataGridView1.Rows

            Try
                Select Case row.Cells("Tarefa").Value

                    Case CL_TESTE_CONEXAO_SERVIDOR_EMAIL
                        TestaConexaoEmail(row.Cells("CNPJ").Value)

                    Case CL_TESTE_CERTIFICADO_DIGITAL
                        TestaCertificadoDigital(row.Cells("CNPJ").Value)

                    Case Else
                        Throw New Exception("Tarefa não está sendo executada pela aplicação")

                End Select

                row.Cells("Status").Value = "OK"
                row.Cells("Mensagem").Value = "Teste OK"

            Catch ex As Exception
                row.Cells("Status").Value = "ERRO"
                row.Cells("Mensagem").Value = ex.Message

            End Try

            DataGridView1.Refresh()

        Next

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub TestaConexaoEmail(ByVal LocalClientKey As String)

        Dim LocalEmailProtocol As EmailProtocolModel
        Dim img As New DataGridViewImageColumn

        LocalEmailProtocol = EmailProtocolController.GetEmailProtocol(LocalClientKey)

        If LocalEmailProtocol.Protocol = EmailProtocolModel.enEmailProtocol.POP Then
            emailClient = New Global.DSC.EmailProtocol.POPClient
        Else
            emailClient = New Global.DSC.EmailProtocol.IMAPClient
        End If

        Try
            emailClient.host = LocalEmailProtocol.Server
            emailClient.port = LocalEmailProtocol.Port
            emailClient.user = LocalEmailProtocol.User
            emailClient.pass = Cryptography.Cryptography.Decifrar(LocalEmailProtocol.Password, CP_Cryptography_Key)
            emailClient.SSL = LocalEmailProtocol.ConnectionSecurity

            emailClient.enableLog = True
            emailClient.connectAndLogin()

            emailClient.logout()

        Catch ex As Global.DSC.EmailProtocol.DSCMailException
            Throw ex

        Catch ex As Exception
            Throw ex

        Finally
            LocalEmailProtocol = Nothing
            emailClient = Nothing

        End Try

    End Sub

    Private Sub TestaCertificadoDigital(ByVal LocalClientKey As String)

        Dim LocalDigitalCertificate As DigitalCertificateModel
        Dim img As New PictureBox

        LocalDigitalCertificate = DigitalCertificateController.GetDigitalCertificate(LocalClientKey)

        Try
            LocalDigitalCertificate.ClientKey = LocalClientKey
            DigitalCertificateController.SetDigitalCertificate(LocalDigitalCertificate)

        Catch ex As Exception
            Throw ex

        Finally
            LocalDigitalCertificate = Nothing

        End Try

    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class