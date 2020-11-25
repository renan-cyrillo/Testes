Public Class XmlDataTransfer

    Public Enum MensagemErroEnvioXml
        OK = 0 ' Success
        ErroLeituraXMLConsulta = 2
        TipoAmbienteNaoProducao = 4
        ChaveAcessoNaoEncontrada = 7
        XMLNaoReconhecido = 9
        ErroDeComunicacaoProgress = 98
        ErroInesperadoNoProgress = 99 ' Fatal Error
    End Enum

    Public Enum MensagemErroEnvioXmlRetorno
        OK = 0 ' Success
        ErroLeituraXMLConsulta = 2
        TipoAmbienteNaoProducao = 4
        ChaveAcessoNaoEncontrada = 7
        XMLNaoReconhecido = 9
        ErroDeComunicacaoProgress = 98
        ErroInesperadoNoProgress = 99 ' Fatal Error
    End Enum

    Private conexaoMD As nsManifesto.pgManifesto

    Public Sub New()

    End Sub

    Public Sub New(ByVal UrlString As String)
        Try
            conexaoMD = New nsManifesto.pgManifesto(UrlString, "", "", "")

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Sub

    Public Sub New(ByVal UserId As String, ByVal Password As String, ByVal AppServerInfo As String)
        Try
            conexaoMD = New nsManifesto.pgManifesto(UserId, Password, AppServerInfo)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Sub

    Public Sub New(ByVal UrlString As String, ByVal UserId As String, ByVal Password As String, ByVal AppServerInfo As String)
        Try
            conexaoMD = New nsManifesto.pgManifesto(UrlString, UserId, Password, AppServerInfo)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Sub

    Public Sub New(ByVal ProgressConnection As Global.Progress.Open4GL.Proxy.Connection)
        Try
            conexaoMD = New nsManifesto.pgManifesto(ProgressConnection)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Sub

    Public Function GravaXmlDestinadasProgress(ByVal XmlNFe As String, ByVal Cnpj As String) As MensagemErroEnvioXml

        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.recebeDestinadas(XmlNFe, Cnpj, ret)

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function

    Public Function GravaXmlCTeProgress(ByVal XmlNFe As String) As MensagemErroEnvioXml

        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.recebeXMLCTE(XmlNFe, ret)

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function

    Public Function BuscaXmlSolicitacaoEventosProgress(ByVal Cnpj As String, ByRef XmlNFe As String) As MensagemErroEnvioXml

        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.enviaEvento(Cnpj, XmlNFe)
            ret = MensagemErroEnvioXml.OK

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function

    Public Function EnviaProgressXmlRetornoSolicitacaoEvento(ByRef XmlNFe As String) As MensagemErroEnvioXml

        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.recebeRetornoEvento(XmlNFe, ret)

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function

    Public Function BuscaXmlListaDownloadNFeProgress(ByVal Cnpj As String, ByRef XmlNFe As String) As MensagemErroEnvioXml

        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.enviaListaDownload(Cnpj, XmlNFe)
            ret = MensagemErroEnvioXml.OK

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function

    Public Function EnviaProgressXmlRetornoDownloadNFe(ByRef XmlNFe As String) As MensagemErroEnvioXml

        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.recebeXMLDownload(XmlNFe, ret)

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function

    Public Function GravaXmlRetornoConsultaNFeSefaz(ByVal XmlRetornoConsultaNFeSefaz As String) As MensagemErroEnvioXmlRetorno

        Dim ret As MensagemErroEnvioXml
        Try

            conexaoMD.recebeRetornoConsulta(XmlRetornoConsultaNFeSefaz)
            ret = MensagemErroEnvioXml.OK
        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret


    End Function

    Public Function BuscaXmlConsultaNFeSefaz(ByVal Cnpj As String, ByRef XmlNFe As String)
        Dim ret As MensagemErroEnvioXml

        Try
            conexaoMD.enviaConsulta(Cnpj, XmlNFe)
            ret = MensagemErroEnvioXml.OK

        Catch ex As Exception
            ret = MensagemErroEnvioXml.ErroDeComunicacaoProgress

        Finally
            Finaliza()

        End Try

        Return ret

    End Function


    Protected Overrides Sub Finalize()
        Finaliza()
    End Sub

    Private Sub Finaliza()
        If Not IsNothing(conexaoMD) Then
            conexaoMD.Dispose()
            conexaoMD = Nothing
            MyBase.Finalize()
        End If
    End Sub

End Class
