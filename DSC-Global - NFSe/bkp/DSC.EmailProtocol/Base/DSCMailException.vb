Public Class DSCMailException
    Inherits System.Exception

    Public Property code As DSCMailExceptionType
    Public Property commandSent As String

    Sub New(ByVal code As DSCMailExceptionType,
            ByVal commandSent As String,
            ByVal message As String)

        MyBase.New(translate(code) & vbCrLf & vbCrLf & "Detalhes do erro:" & vbCrLf & message)

        _code = code
        _commandSent = commandSent

    End Sub

    Enum DSCMailExceptionType
        CouldNotConnectToServer = 1
        ReadTimeoutExceded = 2
        InvalidUsername = 3
        InvalidPassword = 4
        IncorrectPassword = 5
        NotConnectedToTheServer = 6
        CommandResponseError = 7
        NoDataReceivedFromTheServer = 8
        UnknownError = 9
        TheServerIsNotReadyForSSL = 10
        POPServerDoesNotAcceptFolderCommands = 11
        ServerTypeError = 12
        AuthenticationError = 13
    End Enum

    Public Function translate() As String
        Return translate(_code)
    End Function

    Public Shared Function translateMessage(ByVal code As DSCMailExceptionType) As String
        Return translate(code)
    End Function

    Private Shared Function translate(ByVal code As DSCMailExceptionType) As String
        Select Case code
            Case DSCMailExceptionType.CommandResponseError
                Return "O servidor retornou um erro"
            Case DSCMailExceptionType.CouldNotConnectToServer
                Return "Não foi possível conectar ao servidor"
            Case DSCMailExceptionType.IncorrectPassword
                Return "Usuário e senha inválidos"
            Case DSCMailExceptionType.InvalidPassword
                Return "Senha Inválida"
            Case DSCMailExceptionType.InvalidUsername
                Return "Usuário inválido"
            Case DSCMailExceptionType.NoDataReceivedFromTheServer
                Return "Não houve resposta do servidor"
            Case DSCMailExceptionType.NotConnectedToTheServer
                Return "Não conectado ao servidor"
            Case DSCMailExceptionType.POPServerDoesNotAcceptFolderCommands
                Return "POP não oferece suporte a pastas. Apenas IMAP oferece esta função"
            Case DSCMailExceptionType.ReadTimeoutExceded
                Return "Excedido o tempo limite de resposta do servidor"
            Case DSCMailExceptionType.TheServerIsNotReadyForSSL
                Return "O servidor selecionado não reconhece SSL"
            Case DSCMailExceptionType.UnknownError
                Return "Erro desconhecido."
            Case DSCMailExceptionType.ServerTypeError
                Return "Tipo de servidor inválido. Se estiver utilizando POP, tente utilizar IMAP ou vice-versa."
            Case DSCMailExceptionType.AuthenticationError
                Return "Erro na authenticação. Verifique os dados de conexão e porta."
            Case Else
                Throw New Exception("Tipo de erro não tratado (" & CInt(code) & ")")
        End Select
    End Function


End Class
