Public Class IMAPClient
    Implements IEmailClient

#Region "Variaveis Privadas"

    Private _logText As New Text.StringBuilder
    Private _TCP As System.Net.Sockets.TcpClient
    Private _sslStream As System.Net.Security.SslStream
    Private _readStream As IO.StreamReader
    Private _writeStream As IO.Stream
    Private _commandCounter As Integer = 0

#End Region

#Region "Properties"

    ''' <summary>
    ''' The host internet address. Like 'imap.gmail.com'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property host As String Implements IEmailClient.host

    ''' <summary>
    ''' The server port to connect to
    ''' </summary>
    ''' <value>Default 993</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property port As Integer = 993 Implements IEmailClient.port

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

    Private Function enviaComando(ByVal comando As String) As String
        Dim result As String = ""

        _commandCounter += 1

        Dim chave As String = "a" & _commandCounter
        comando = chave & " " & comando

        Try
            putLog(comando)
            Dim data() As Byte = System.Text.Encoding.ASCII.GetBytes(comando & vbCrLf)

            'Envia Comando
            Try
                _writeStream.Write(data, 0, data.Length)
            Catch ex As Exception
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.NotConnectedToTheServer, comando, "Connection closed.")
            End Try

            Dim bRead As Boolean = True

            While bRead
                Dim resultLine As String =
                    _readStream.ReadLine

                If resultLine Is Nothing Then
                    putLog("")
                    Throw New DSCMailException(DSCMailException.DSCMailExceptionType.NoDataReceivedFromTheServer, comando, "No data received from the server.")
                End If

                If resultLine.Contains(chave & " OK ") Or
                   resultLine.Contains(chave & " BAD ") Or
                   resultLine.Contains(chave & " NO ") Then

                    bRead = False

                    If resultLine.Contains(chave & " BAD ") Or
                       resultLine.Contains(chave & " NO ") Then
                        putLog(result & resultLine)
                        Throw New DSCMailException(DSCMailException.DSCMailExceptionType.CommandResponseError, comando, resultLine)
                    End If

                End If

                result &= resultLine & vbCrLf

            End While
            putLog(result)

        Catch ex As Exception
            putLog(result)
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.UnknownError, comando, ex.Message)
        End Try

        Return result
    End Function

    Private Function anexoFromString(ByVal conteudo As String) As Byte()

        Dim conteudoAnexo As String

        Dim ms As New IO.MemoryStream
        Dim ds As New IO.Compression.DeflateStream(ms, IO.Compression.CompressionMode.Decompress)
        Dim v() As String = conteudo.Split(vbCrLf)
        Dim l As New List(Of String)
        l = v.ToList
        l.RemoveAt(0)
        l.RemoveAt(l.Count - 1)
        l.RemoveAt(l.Count - 1)
        'TODO: ALABI - Erro no donwload de anexo, linha comentada pois remove uma linha a mais truncado o xml
        'l.RemoveAt(l.Count - 1)   
        'TODO: ALABI - Erro no donwload de anexo, comando para remover caracter ')'
        l(l.Count - 1) = l(l.Count - 1).Replace(")", "")

        conteudoAnexo = String.Join("", l.ToArray).Replace(Chr(10), "")

        Dim arrByte() As Byte = System.Text.Encoding.UTF8.GetBytes(conteudoAnexo)
        Dim arrChar() As Char = System.Text.Encoding.UTF8.GetChars(arrByte)
        Try
            arrByte = Convert.FromBase64CharArray(arrChar, 0, arrByte.Length)
        Catch ex As Exception

        End Try
        Return arrByte
    End Function

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

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' Connects to the server an log in using HOST, PORT, USER, PASS and SSL specified
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub connectAndLogin() Implements IEmailClient.connectAndLogin


        _TCP = New System.Net.Sockets.TcpClient(_host, _port)
        _TCP.ReceiveTimeout = 50000
        _TCP.SendTimeout = 50000

        _sslStream = New System.Net.Security.SslStream(_TCP.GetStream, False, New System.Net.Security.RemoteCertificateValidationCallback(AddressOf validaCertificado), Nothing)

        If SSL Then
            Try
                _sslStream.AuthenticateAsClient(host)
                _writeStream = _sslStream
                _readStream = New IO.StreamReader(_sslStream)
            Catch ex As Exception
                Throw New DSCMailException(DSCMailException.DSCMailExceptionType.CouldNotConnectToServer, "", ex.Message)
            End Try
        Else
            _writeStream = _TCP.GetStream
            _readStream = New IO.StreamReader(_TCP.GetStream)
        End If

        Try
            putLog(_readStream.ReadLine())
        Catch ex As Exception
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.UnknownError, "ReadTimeoutExcedded", ex.Message)
        End Try

        If _user.Trim = "" Then
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.InvalidUsername, "", "")
        End If
        If _pass.Trim = "" Then
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.InvalidPassword, "", "")
        End If

        Try
            enviaComando("login " & _user & " " & _pass)
        Catch ex As DSCMailException
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.IncorrectPassword, "login " & _user & " " & _pass, "")
        Catch ex As Exception
            Throw New DSCMailException(DSCMailException.DSCMailExceptionType.UnknownError, "", ex.Message)
        End Try

        enviaComando("select inbox")

    End Sub

    ''' <summary>
    ''' Create a new folder on the IMAP server.
    ''' </summary>
    ''' <param name="folderName">CASE SENSITIVE
    ''' The name of the folder to be created.
    ''' This name must or not be absolute. Depending of the server.
    ''' The folder's name separator is the '.' character. ex: INBOX.folderName
    ''' </param>
    ''' <remarks></remarks>
    Public Sub createNewFolder(ByVal folderName As String) Implements IEmailClient.createNewFolder
        enviaComando("CREATE " & folderName)
    End Sub

    ''' <summary>
    ''' Verify if this client is connected to the server.
    ''' </summary>
    ''' <returns>Returns TRUE if the user is connected to the server and FALSE if the user is NOT connected</returns>
    ''' <remarks></remarks>
    Public Function isConnected() As Boolean Implements IEmailClient.isConnected
        Try
            enviaComando("NOOP")
            Return True
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
            If enviaComando("NOOP").ToLower.Contains("success") Or enviaComando("NOOP").ToLower.Contains(" ok ") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Log out from the server
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub logout() Implements IEmailClient.logout
        enviaComando("logout")
    End Sub

    ''' <summary>
    ''' Move messages between folders
    ''' </summary>
    ''' <param name="MessageUID">Message UID (Unique ID assigned to the message) to be moved. CASE SENSITIVE</param>
    ''' <param name="folderName">CASE SENSITIVE
    ''' Folder name to move the message To</param>
    ''' <remarks></remarks>
    Public Sub moveMessageToFolder(ByVal MessageUID As String, ByVal folderName As String) Implements IEmailClient.moveMessageToFolder
        enviaComando("UID MOVE " & MessageUID & " " & folderName)
    End Sub

    ''' <summary>
    ''' Delete a message from the server
    ''' </summary>
    ''' <param name="MessageUID">UID (Unique ID assigned to the message) to be deleted</param>
    ''' <remarks></remarks>
    Public Sub deleteMessage(ByVal MessageUID As String) Implements IEmailClient.deleteMessage
        enviaComando("UID STORE " & MessageUID & " +FLAGS (\Deleted)")
        'enviaComando("UID EXPUNGE " & MessageUID)
    End Sub

    ''' <summary>
    ''' Returns an array of String containing all messages UID on the server
    ''' </summary>
    ''' <returns>A array of String containing the messages UID </returns>
    ''' <remarks></remarks>
    Public Function getAllMessagesUID() As List(Of String) Implements IEmailClient.getAllMessagesUID
        Dim l As New List(Of String)
        For Each linha In enviaComando("uid search UNDELETED").Split(vbCrLf)
            'For Each linha In enviaComando("fetch 1:* uid FLAGS (\UNDELETED)").Split(vbCrLf)
            If linha.Trim.StartsWith("*") Then
                linha = linha.Replace("* SEARCH ", "").Trim
                l.AddRange(linha.Split(" "))
            End If
            If linha.Trim.StartsWith("*") And linha.Contains("UID ") Then
                Dim uid As String = Split(linha, "UID ")(1)
                uid = uid.Split(")")(0)
                l.Add(uid)
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
        Dim header As String =
            enviaComando("uid fetch " & UID & " body[HEADER.fields (""TO"" ""FROM"" ""DATE"" ""SUBJECT"")]")
        'Date: Tue, 29 Oct 2013 12:48:38 -0200
        'From: Emerson Valente <emersonvalente@uol.com.br>
        'To: testezicado@gmail.com
        'Subject:    TESTE(3)
        Dim [from] As String = ""
        Dim [date] As Date = Nothing
        Dim [to] As String = ""
        Dim [subject] As String = ""

        For Each linha As String In header.Split(vbCrLf)
            If linha.Trim.ToUpper().StartsWith("DATE: ") Then
                '[date] = Trim(linha.Substring(6, linha.Length - 6))
            End If
            If linha.Trim.ToUpper().StartsWith("FROM: ") Then
                from = linha.Substring(6, linha.Length - 6)
            End If
            If linha.Trim.ToUpper().StartsWith("TO: ") Then
                [to] = linha.Substring(4, linha.Length - 4)
            End If
            If linha.Trim.ToUpper().StartsWith("SUBJECT: ") Then
                subject = linha.Substring(9, linha.Length - 9)
            End If
        Next


        Dim body As String =
            enviaComando("UID FETCH " & UID & " BODY")

        Dim v() As String = body.Split(" ")

        Dim anexos As New List(Of Attachment)

        Dim content As String = enviaComando("UID FETCH " & UID & " BODY[1]")

        Dim count As Integer = 0
        For i = 0 To v.GetUpperBound(0)
            If v(i).ToUpper.Replace("""", "").Replace("(", "").StartsWith("NAME") Then
                Dim nome As String = v(i + 1).Replace("""", "").Split("(")(0).Split(")")(0)
                Dim size As String = v(i + 5).Replace("""", "").Split("(")(0).Split(")")(0)
                Dim type As String = v(i - 1).Replace("""", "").Split("(")(0).Split(")")(0)
                Try
                    Dim bytes() As Byte = anexoFromString(enviaComando("UID FETCH " & UID & " BODY[" & 2 + count & "]"))
                    anexos.Add(New Attachment(nome, bytes, type))

                Catch ex As Exception
                    ex = ex
                End Try
                count += 1
            End If
        Next

        Dim email As New EmailMessage(subject, from, [to], content, anexos)
        Return email
    End Function

#End Region

End Class