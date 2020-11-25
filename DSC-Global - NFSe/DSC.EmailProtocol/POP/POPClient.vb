Public Class POPClient
    Implements IEmailClient

#Region "Variaveis Privadas"

    Private _clientSocket As System.Net.Sockets.TcpClient
    Private _logText As New Text.StringBuilder
    Private _stream As IO.Stream
    Private _commandCounter As Integer = 0

#End Region

#Region "Properties"

    ''' <summary>
    ''' The host internet address. Like 'pop.gmail.com'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property host As String Implements IEmailClient.host

    ''' <summary>
    ''' The server port to connect to
    ''' </summary>
    ''' <value>Default 110</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property port As Integer = 110 Implements IEmailClient.port

    ''' <summary>
    ''' The e-mail account user to log in
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property user As String Implements IEmailClient.user

    ''' <summary>
    ''' The e-mail account password to log in
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pass As String Implements IEmailClient.pass

    ''' <summary>
    ''' set if the server requires SSL security or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SSL As Boolean Implements IEmailClient.SSL

    ''' <summary>
    ''' Enables or disables the LOG functionality
    ''' </summary>
    ''' <value>True enable the LOG
    ''' False disable the LOG
    ''' </value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property enableLog As Boolean = False Implements IEmailClient.enableLog

#End Region

#Region "Events"

    Public Event logChanged(ByVal text As String) Implements IEmailClient.logChanged

#End Region

#Region "Construtores"

    Sub New()
    End Sub

    Sub New(ByVal host As String, ByVal port As Integer, ByVal user As String, ByVal pass As String, ByVal SSL As Boolean)
        _host = host
        _port = port
        _user = user
        _pass = pass
        _SSL = SSL
        enableLog = True
    End Sub

#End Region

#Region "Métodos Privados"

    Private Sub putLog(ByVal text As String)
        If Not enableLog Then Exit Sub
        _logText.AppendLine(text)
        RaiseEvent logChanged(_logText.ToString)
    End Sub

    Private Function validaCertificado(ByVal sender As Object,
                                       ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate,
                                       ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                       ByVal policyErrors As System.Net.Security.SslPolicyErrors)
        If (policyErrors = System.Net.Security.SslPolicyErrors.None) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function certificateValidator(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslpolicyerrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Shared Function IsOkResponse(ByVal response As String) As Boolean
        If (response.StartsWith("+", StringComparison.OrdinalIgnoreCase)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ReadLineAsAscii() As String
        Dim readFromStream As Byte() = ReadLineAsBytes()
        Return Text.Encoding.ASCII.GetString(readFromStream)
    End Function

    Private Function ReadLineAsBytes() As Byte()

        If (_stream Is Nothing) Then
            Throw New ArgumentNullException("stream")
        End If
        Dim MemoryStream As IO.MemoryStream = New IO.MemoryStream()

        While (True)
            Dim justRead As Integer
            Try
                justRead = _stream.ReadByte()
            Catch ex As Exception
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.ReadTimeoutExceded, "", ex.Message)
            End Try
            If (justRead = -1 And MemoryStream.Length > 0) Then
                Exit While
            End If

            If (justRead = -1 And MemoryStream.Length = 0) Then Return Nothing

            Dim readChar As Char = Chr(justRead)

            If (readChar <> vbCr AndAlso readChar <> vbLf) Then MemoryStream.WriteByte(justRead)

            If (readChar = Chr(10)) Then Exit While

            If (System.Text.ASCIIEncoding.ASCII.GetString(MemoryStream.ToArray()) = "-ERR") Then
                'Exit While
            End If

        End While

        Return MemoryStream.ToArray()

    End Function

    Private Function enviaComando(ByVal comando As String) As String

        Dim response As String = ""
        Try
            putLog(comando)

            Dim commandBytes As Byte() = Text.Encoding.ASCII.GetBytes(comando + vbCrLf)

            Try
                _stream.Write(commandBytes, 0, commandBytes.Length)
                _stream.Flush()
            Catch ex As Exception
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.NotConnectedToTheServer, comando, "Connection closed.")
            End Try

            response = ReadLineAsAscii()
            IsOkResponse(response)
            putLog(response)

            Return response
        Catch ex As DSCMailException
            Throw ex
        Catch ex As Exception
            putLog(response)
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.UnknownError, comando, ex.Message)
        End Try
    End Function

    Private Function enviaComandoBuscaMensagemCompleta(ByVal comando As String) As String
        Dim response As String = ""
        Try
            putLog(comando)

            Dim commandBytes As Byte() = Text.Encoding.ASCII.GetBytes(comando + vbCrLf)

            Try
                _stream.Write(commandBytes, 0, commandBytes.Length)
                _stream.Flush()
            Catch ex As Exception
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.NotConnectedToTheServer, comando, "Connection closed.")
            End Try

            response = ReadLineAsAscii() & vbCrLf
            While 1
                Dim linha As String = ReadLineAsAscii()
                response &= linha & vbCrLf
                If linha = "." Then
                    Exit While
                End If
            End While

            IsOkResponse(response)
            putLog(response)

            Return response
        Catch ex As DSCMailException
            Throw ex
        Catch ex As Exception
            putLog(response)
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.UnknownError, comando, ex.Message)
        End Try

    End Function

    Private Function SendCommandIntResponse(ByVal command As String, ByVal location As Integer) As Integer
        Dim response As String = enviaComando(command)
        Dim v() As String = response.Split(" ")
        If IsNumeric(v(location)) Then
            Return Integer.Parse(v(location), System.Globalization.CultureInfo.InvariantCulture)
        Else
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.ServerTypeError, command, "Error trying to cast '" & v(location) & "' to Integer")
        End If
    End Function

    Private Function decodeEmailMessage(ByVal emailText As String) As EmailMessage

        Dim mailParts As New List(Of String)

        Dim boundary As String = StringFunctions.getTextBetweenWords(emailText, "boundary=""", """", False, False, True)

        If boundary = "" Then
            boundary = StringFunctions.getTextBetweenWords(emailText, "boundary=", Chr(13), False, False, True)
            boundary = boundary.Replace(Chr(10), "")
        End If

        mailParts = Split(emailText, boundary).ToList

        Dim cabecalho As String = mailParts(0) & boundary & mailParts(1)

        mailParts.RemoveAt(0)
        mailParts.RemoveAt(0)

        mailParts.Insert(0, cabecalho)

        Dim mailPart As String = ""

        Dim from As String = ""
        Dim [to] As String = ""
        Dim [subject] As String = ""
        Dim body As String = ""

        For Each linha In Split(mailParts(0), vbCrLf)

            If linha.StartsWith("From:") Then
                from = linha.Substring(6, linha.Length - 6)
            End If
            If linha.StartsWith("To:") Then
                [to] = linha.Substring(4, linha.Length - 4)
            End If
            If linha.StartsWith("Subject:") Then
                subject = linha.Substring(9, linha.Length - 9)
            End If

        Next

        Dim attachmentList As New List(Of Attachment)

        For i = 1 To mailParts.Count - 2

            Dim attName, attType

            mailPart = mailParts(i)

            Dim teste() As String = Split(mailPart, vbCrLf & vbCrLf)
            Dim infos As String = teste(0)
            Dim encodingName As String = getEncodingName(infos)

            attName = getAttachmentName(infos)
            attType = getAttachmentType(infos)

            Dim content As String = teste(1)


            Dim arrByte As Byte() = {}

            If (content.Replace(vbCrLf, "").Trim <> "") Then

                If encodingName.ToUpper = "BASE64" Then

                    content = content.Replace(vbCrLf & "--", "")
                    content = content.Replace(vbCrLf, "")
                    arrByte = Convert.FromBase64CharArray(content.ToCharArray(), 0, content.Length)

                Else

                    arrByte = System.Text.ASCIIEncoding.ASCII.GetBytes(content)

                End If

            End If

            If attName.trim = "" Then
                body = System.Text.ASCIIEncoding.ASCII.GetString(arrByte)
            Else
                attachmentList.Add(New Attachment(attName, arrByte, attType))
            End If

        Next

        Dim email As New EmailMessage(subject, [from], [to], body, attachmentList)
        Return email

    End Function

  Private Function getAttachmentName(infos As String) As String
        'procura por 'filename=', se nao achar, procura por 'name='

        Dim v() As String = StringFunctions.splitText(infos, " ")

        Dim resp As String = ""
        Dim i As Integer = infos.ToLower.IndexOf("filename=")

        For Each s In v
            If s.Trim.ToLower.StartsWith("filename") Then
                Return s.Trim.Substring(9, s.Length - 9).Replace("""", "")
            End If
        Next
        For Each s In v
            If s.Trim.ToLower.StartsWith("name") Then
                Return s.Trim.Substring(5, s.Length - 5).Replace("""", "")
            End If
        Next

        If i > -1 Then
            resp = infos.Substring(i + 9, infos.Length - i - 9)
        End If
        If resp <> "" Then
            Return resp.Split(Chr(13))(0).Replace("""", "")
        End If

        i = infos.ToLower.IndexOf("name=")

        If i > -1 Then
            resp = infos.Substring(i + 5, infos.Length - i - 5)
        End If
        Return resp.Split(Chr(13))(0).Replace("""", "")

    End Function

    Private Function getAttachmentType(ByVal infos As String) As String
        Dim resp As String = ""
        Dim i As Integer = infos.ToUpper.IndexOf("TYPE:")

        If i > -1 Then
            resp = infos.Substring(i + 5, infos.Length - i - 5)
        End If

        Return resp.Split(";")(0).Trim
    End Function

    Private Function getEncodingName(ByVal s As String) As String
        Dim resp As String = ""
        For Each linha In Split(s, vbCrLf)
            Dim i As Integer = s.ToLower.IndexOf("encoding: ")
            If i > -1 Then
                resp = s.Substring(i + 10, s.Length - i - 10)
            End If
        Next
        Return resp.Split(Chr(13))(0)
    End Function

    Private Function getMessageCount() As Integer
        enviaComando("NOOP")
        Return SendCommandIntResponse("STAT", 1)
    End Function

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' Connects to the server an log in using HOST, PORT, USER, PASS and SSL specified
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub connectAndLogin() Implements IEmailClient.connectAndLogin

        Dim certificateValidat As System.Net.Security.RemoteCertificateValidationCallback = AddressOf certificateValidator

        Dim receiveTimeout As Integer = 5000
        Dim sendTimeout As Integer = 5000

        _clientSocket = New System.Net.Sockets.TcpClient

        _clientSocket.ReceiveTimeout = receiveTimeout
        _clientSocket.SendTimeout = sendTimeout

        Try
            _clientSocket.Connect(_host, _port)
        Catch ex As System.Net.Sockets.SocketException
            Try
                _clientSocket.Close()
            Catch
            End Try
            putLog("Connect(): " + ex.Message)
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.CouldNotConnectToServer, "Connect():", ex.Message)
        End Try

        Dim Stream As IO.Stream
        If (_SSL) Then

            Dim SslStream As System.Net.Security.SslStream
            If (certificateValidat Is Nothing) Then
                SslStream = New System.Net.Security.SslStream(_clientSocket.GetStream(), False)
            Else
                SslStream = New System.Net.Security.SslStream(_clientSocket.GetStream(), False, certificateValidat)
            End If
            SslStream.ReadTimeout = receiveTimeout
            SslStream.WriteTimeout = sendTimeout
            Try
                SslStream.AuthenticateAsClient(host)
            Catch ex As Exception
                SslStream = Nothing
                putLog("The server on port " & port & " is not ready for SSL connection")
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.TheServerIsNotReadyForSSL, "<Authenticate SSL>", "The server on port " & port & " is not ready for SSL connection")
            End Try
            Stream = SslStream
        Else
            Stream = _clientSocket.GetStream()
        End If

        _stream = Stream

        Dim response As String = ReadLineAsAscii()

        Try
            If (Not response.StartsWith("+", StringComparison.OrdinalIgnoreCase)) Then
                _stream = Nothing
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.AuthenticationError, "", response)
            End If
            IsOkResponse(response)
        Catch e As DSCMailException
            _stream = Nothing
            Throw e
        Catch e As Exception
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.UnknownError, "", e.Message)
        End Try

        'Authenticar 
        Dim comando As String
        Dim resp As String

        comando = "USER " + user
        resp = enviaComando(comando)
        If Not IsOkResponse(resp) Then
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.InvalidUsername, comando, resp)
        End If
        comando = "PASS " + pass
        resp = enviaComando(comando)
        If Not IsOkResponse(resp) Then
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.InvalidPassword, comando, resp)
        End If

    End Sub

    ''' <summary>
    ''' Create a new folder on the POP server.
    ''' </summary>
    ''' <param name="folderName">CASE SENSITIVE
    ''' The name of the folder to be created.
    ''' This name must or not be absolute. Depending of the server.
    ''' The folder's name separator is the '.' character. ex: INBOX.folderName
    ''' </param>
    ''' <remarks></remarks>
    Public Sub createNewFolder(ByVal folderName As String) Implements IEmailClient.createNewFolder
        Throw New DSCMailException(DSCMailException.DSCMailExceptionType.POPServerDoesNotAcceptFolderCommands, "", "A folder can't be created when using POP3. Only IMAP supports folder creation")
    End Sub

    ''' <summary>
    ''' Verify if this client is connected to the server.
    ''' </summary>
    ''' <returns>Returns TRUE if the user is connected to the server and FALSE if the user is NOT connected</returns>
    ''' <remarks></remarks>
    Public Function isConnected() As Boolean Implements IEmailClient.isConnected
        Try
            Return IsOkResponse(enviaComando("NOOP"))
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Verify if the client is connected to the server and logged in
    ''' </summary>
    ''' <returns>Returns TRUE if the user is logged in and FALSE if the user is NOT logged in</returns>
    ''' <remarks></remarks>
    Public Function isLoggedIn() As Boolean Implements IEmailClient.isLoggedIn
        Try
            Return IsOkResponse(enviaComando("NOOP"))
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Log out from the server
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub logout() Implements IEmailClient.logout
        enviaComando("QUIT")
    End Sub

    ''' <summary>
    ''' Move messages between folders
    ''' </summary>
    ''' <param name="MessageUID">Message UID (Unique ID assigned to the message) to be moved. CASE SENSITIVE</param>
    ''' <param name="folderName">CASE SENSITIVE
    ''' Folder name to move the message To</param>
    ''' <remarks></remarks>
    Public Sub moveMessageToFolder(ByVal MessageUID As String, ByVal folderName As String) Implements IEmailClient.moveMessageToFolder
        Throw New DSCMailException(DSCMailException.DSCMailExceptionType.POPServerDoesNotAcceptFolderCommands, "", "A message can't be moved when using POP3. Only IMAP supports moving messages between folders")
    End Sub

    ''' <summary>
    ''' Delete a message from the server
    ''' You need to logout alter the DELETE command to it take effect on next time ou login
    ''' </summary>
    ''' <param name="MessageUID">UID (Unique ID assigned to the message) to be deleted</param>
    ''' <remarks></remarks>
    Public Sub deleteMessage(ByVal MessageUID As String) Implements IEmailClient.deleteMessage
        Dim messageIndex As Integer = 0

        For i = 1 To getMessageCount()
            Dim resp As String = enviaComando("UIDL " + i.ToString())
            Dim loopUID As String = resp.Split(" ")(2)
            If loopUID = MessageUID Then
                messageIndex = i
                Exit For
            End If
        Next
        enviaComando("DELE " & messageIndex)
    End Sub

    ''' <summary>
    ''' Returns an array of String containing all messages UID on the server
    ''' </summary>
    ''' <returns>A array of String containing the messages UID </returns>
    ''' <remarks></remarks>
    Public Function getAllMessagesUID() As List(Of String) Implements IEmailClient.getAllMessagesUID
        Dim l As New List(Of String)
        For i = 1 To getMessageCount()
            Dim resp As String = enviaComando("UIDL " & i)
            If Not resp.StartsWith("-ERR") Then
                l.Add(resp.Split(" ")(2))
            End If
        Next
        Return l
    End Function

    ''' <summary>
    ''' Return a DSCMail.EmailMessage object containing informations about the message
    ''' </summary>
    ''' <param name="UID">The message UID(Unique ID assigned to the message) to get</param>
    ''' <returns>A DSCMail.EmailMessage object filled with message info.</returns>
    ''' <remarks></remarks>
    Public Function getMessage(ByVal UID As String) As EmailMessage Implements IEmailClient.getMessage

        Dim messageIndex As Integer = 0

        For i = 1 To getMessageCount()
            Dim resp As String = enviaComando("UIDL " + i.ToString())
            Dim loopUID As String = resp.Split(" ")(2)
            If loopUID = UID Then
                messageIndex = i
                Exit For
            End If
        Next

        Dim conteudo As String = enviaComandoBuscaMensagemCompleta("RETR " & messageIndex)

        Return decodeEmailMessage(conteudo)

    End Function

#End Region

End Class
