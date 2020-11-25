Imports System.Text
Imports System.Net.Mail

''' <summary>
''' Classe com métodos para envio de e-mail via SMTP
''' </summary>
Public Class SMTPClient

    Public Sub New()
    End Sub

    Public Enum EmailFormat
        Text
        HTML
    End Enum

    Public Shared Sub SendEmail(ByVal SMTPHost As String, _
                                ByVal SMTPPort As Integer, _
                                ByVal SMTPAddress As String, _
                                ByVal DisplayName As String, _
                                ByVal ListaEmailsTO As List(Of String), _
                                ByVal SSLConnection As Boolean, _
                                ByVal Credential As System.Net.NetworkCredential, _
                                Optional ByVal subject As String = "", _
                                Optional ByVal body As String = "", _
                                Optional ByVal ListaEmailsCC As List(Of String) = Nothing, _
                                Optional ByVal ListaEmailsBCC As List(Of String) = Nothing, _
                                Optional ByVal ListaFiles As List(Of String) = Nothing, _
                                Optional ByVal priority As MailPriority = MailPriority.Normal, _
                                Optional ByVal emailFormat As EmailFormat = EmailFormat.Text)

        Try

            ' to

            Dim ToMailAdress As New System.Net.Mail.MailAddressCollection()

            For Each Emails As String In ListaEmailsTO
                ToMailAdress.Add(Emails)
            Next

            ' Bcc

            Dim bccMailAdress As New System.Net.Mail.MailAddressCollection()

            If Not IsNothing(ListaEmailsBCC) Then
                For Each Emails As String In ListaEmailsBCC
                    bccMailAdress.Add(Emails)
                Next
            End If

            ' CC

            Dim ccMailAdress As New MailAddressCollection()

            If Not IsNothing(ListaEmailsCC) Then
                For Each Emails As String In ListaEmailsCC
                    ccMailAdress.Add(Emails)
                Next
            End If

            'Dim attachmentCol As System.Net.Mail.AttachmentCollection

            'If Not IsNothing(ListaFiles) Then
            '    For Each file As String In ListaFiles
            '        Dim attachment As New System.Net.Mail.Attachment(file)
            '        attachmentCol.Add(attachment)
            '    Next
            'End If

            SendEmail(SMTPHost, _
                      SMTPPort, _
                      SMTPAddress, _
                      DisplayName, _
                      ToMailAdress, _
                      subject, _
                      body, _
                      ccMailAdress, _
                      bccMailAdress, _
                      ListaFiles, _
                      priority, _
                      emailFormat, _
                      SSLConnection, _
                      Credential)

        Catch exSmtp As SmtpException
            Throw (exSmtp)

        Catch ex As Exception
            Throw (ex)

        End Try

    End Sub

    Private Shared Sub SendEmail(ByVal SMTPHost As String, _
                                 ByVal SMTPPort As Integer, _
                                 ByVal SMTPAddress As String, _
                                 ByVal DisplayName As String, _
                                 ByVal ToMailAddressCollection As System.Net.Mail.MailAddressCollection, _
                                 ByVal subject As String, _
                                 ByVal body As String, _
                                 ByVal ccMailAddressCollection As System.Net.Mail.MailAddressCollection, _
                                 ByVal bccMailAddressCollection As System.Net.Mail.MailAddressCollection, _
                                 ByVal ListOfAttachment As List(Of String), _
                                 ByVal priority As System.Net.Mail.MailPriority, _
                                 ByVal emailFormat As EmailFormat, _
                                 ByVal SSLConnection As Boolean,
                                 ByVal Credential As System.Net.NetworkCredential)

        ' cria uma instância do objeto MailMessage
        Dim objEmail As New System.Net.Mail.MailMessage()

        ' Cria uma instância de SmtpClient - Nota - Define qual o host a ser usado para envio de mensagens
        Dim objSmtp As New System.Net.Mail.SmtpClient(SMTPHost, SMTPPort)

        Try

            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

            ' Define o endereço do remetente
            objEmail.From = New System.Net.Mail.MailAddress(SMTPAddress, DisplayName, System.Text.Encoding.GetEncoding("ISO-8859-1"))

            ' Define o destinario da mensagem
            For Each ToMailAdress As System.Net.Mail.MailAddress In ToMailAddressCollection
                objEmail.[To].Add(ToMailAdress)
            Next

            ' Define o endereço bcc
            For Each bccMailAdress As System.Net.Mail.MailAddress In bccMailAddressCollection
                objEmail.Bcc.Add(bccMailAdress)
            Next

            ' Define o endereço cc 
            For Each ccMailAdress As System.Net.Mail.MailAddress In ccMailAddressCollection
                objEmail.CC.Add(ccMailAdress)
            Next

            ' Define o assunto 
            objEmail.Subject = subject

            ' Define o corpo da mensagem
            objEmail.Body = body

            ' Define o formato do email como Texto
            If emailFormat = emailFormat.Text Then
                objEmail.IsBodyHtml = False
            Else
                objEmail.IsBodyHtml = True
            End If

            ' Define a prioridade da mensagem como normal
            objEmail.Priority = priority

            ' Define os arquivos em anexo que serão enviados
            If Not IsNothing(ListOfAttachment) Then
                For Each attachment As String In ListOfAttachment
                    objEmail.Attachments.Add(New Net.Mail.Attachment(attachment))
                Next
            End If

            'Conexão Segura
            If SSLConnection Then objSmtp.EnableSsl = True

            'Credenciais acesso e-mail
            objSmtp.Credentials = Credential

            ' Envia o email
            objSmtp.Send(objEmail)


        Catch exSmtp As SmtpException
            Throw (exSmtp)

        Catch ex As Exception
            Throw (ex)

        Finally
            objEmail = Nothing
            objSmtp = Nothing
        End Try

    End Sub

End Class
