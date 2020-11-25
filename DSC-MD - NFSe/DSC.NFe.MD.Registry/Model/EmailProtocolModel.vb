Public Class EmailProtocolModel
    Inherits ClientModel

    Public Enum enEmailProtocol
        IMAP
        POP
    End Enum

    Public Property Protocol As enEmailProtocol
    Public Property Server As String
    Public Property Port As Integer
    Public Property User As String
    Public Property Password As String
    Public Property Backup As Boolean
    Public Property ConnectionSecurity As Boolean

End Class
