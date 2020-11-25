Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports DSC.NFe.MD.MDGlobal
Imports DSC.NFe.Sefaz.XmlSefaz

Module ModAppSolicitacaoEvento

    Private MDConfiguration As New MDConfigurationModel
    Private ListPainelControleMD As New List(Of PainelControleController)

    Private LogName As String = "DSC.MD"
    Private Source As String = "AppSolicitacaoEvento"

    Sub Main()

#If DEMO Then
        Try

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando versão de avaliação do MD", EventLogEntryType.Information, LogName, Source)

            Dim Trial As TrialModel

            Trial = TrialController.GetTrial()

            Dim dataInstalacao As Date
            Dim dataExpiracao As Date
            Dim cultInfo As New System.Globalization.CultureInfo("pt-BR")

            If Date.TryParse(Trial.dMsDc, cultInfo, Globalization.DateTimeStyles.AssumeUniversal, dataInstalacao) Then

                dataExpiracao = DateAdd(DateInterval.Day, 60, dataInstalacao.Date)

                If Now.Date > dataExpiracao Then
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "A versão de avaliação do MD expirou em: " & dataExpiracao, EventLogEntryType.Information, LogName, Source)
                    End
                Else
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "A versão de avaliação do MD expirará em: " & dataExpiracao, EventLogEntryType.Information, LogName, Source)
                End If

            Else
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao executar versão de avaliação do MD", EventLogEntryType.Information, LogName, Source)
                End
            End If

        Catch ex As Exception
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao executar versão de avaliação do MD", EventLogEntryType.Information, LogName, Source)

        End Try
#End If

        Try

            MDConfiguration = MDConfigurationController.GetMDConfiguration()

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando AppSolicitacaoEvento", EventLogEntryType.Information, LogName, Source)
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Buscando configurações do Painel de Controle", EventLogEntryType.Information, LogName, Source)

            ListPainelControleMD = ClientController.GetMDRegistry()

            For Each client As PainelControleController In ListPainelControleMD
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando Solicitação de Eventos do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
                SolicitacaoEvento(client)
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando Solicitação de Eventos do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
            Next

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando AppSolicitacaoEvento", EventLogEntryType.Information, LogName, Source)

        Catch secEx As System.Security.SecurityException
            Console.WriteLine("ERRO: " & secEx.Message)

        Catch ex As Exception
            Console.WriteLine("ERRO: " & ex.Message)

        End Try

    End Sub

    Private Sub SolicitacaoEvento(ByVal client As PainelControleController)

        Dim XmlSefaz As String = ""
        Dim UltNSU As String = ""

        Dim ProgressConfiguration As New ProgressConfigurationModel

        Dim ret As DSC.NFe.MD.Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno
        Dim XmlDataTransfer As DSC.NFe.MD.Progress.XmlDataTransfer

        Dim XmlNfe As String

        Try

            ' Busca Lista de Solicitação de Eventos no progress

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Buscando Xml de Solicitação de Eventos no Progress", EventLogEntryType.Information, LogName, Source)

            XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" & _
                                                                      client.ProgressConfiguration.IP & ":" & _
                                                                      client.ProgressConfiguration.PortNumber & "/" & _
                                                                      client.ProgressConfiguration.AppServer)

            ' Envia Xml de Retorno do Sefaz da Nfe para o Progress

            ret = XmlDataTransfer.BuscaXmlSolicitacaoEventosProgress(client.Client.ClientKey, XmlSefaz)

            Select Case ret

                Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK

                    If XmlSefaz = "" Then
                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Progress retornou um XML vazio.", EventLogEntryType.Warning, LogName, Source)
                    Else
                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Envio: " + XmlSefaz, EventLogEntryType.Warning, LogName, Source)
                        XmlNfe = GetXmlSefaz(client, XmlSefaz)
                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Retorno: " + XmlNfe, EventLogEntryType.Warning, LogName, Source)
                        XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" & _
                                                          client.ProgressConfiguration.IP & ":" & _
                                                          client.ProgressConfiguration.PortNumber & "/" & _
                                                          client.ProgressConfiguration.AppServer)

                        ret = XmlDataTransfer.EnviaProgressXmlRetornoSolicitacaoEvento(XmlNfe)

                        Select Case ret
                            Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Enviado ao Progress com Sucesso!", EventLogEntryType.SuccessAudit, LogName, Source)

                                'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroDeComunicacaoProgress, Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                            Case Else
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao se comunicar com o Progress.", EventLogEntryType.Error, LogName, Source)

                        End Select

                    End If

                Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroDeComunicacaoProgress, Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao se comunicar com o Progress.", EventLogEntryType.Error, LogName, Source)

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function GetXmlSefaz(ByVal client As PainelControleController, ByRef XmlSefaz As String) As String

        Try

            Dim versaoDados As String = ""
            Dim cnpj As String = client.Client.ClientKey
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao

            Dim TEnvEvento As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.EnvConfRecebto.TEnvEvento
            TEnvEvento = DeserializeXmlStringToObject(XmlSefaz, GetType(Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.EnvConfRecebto.TEnvEvento))

            versaoDados = "1.00"

            tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Producao
            'tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Homologacao

            versao = WebServicesSefaz.enVersao.Versao1

            Dim x509 As X509Certificate2

            Try
                x509 = GetX509Certificates(cnpj)

            Catch ex As Exception
                Throw New Exception("Informações sobre o Certificado Digital do cnpj " & cnpj & " não encontradas")

            End Try

            If x509.NotAfter <= Date.Now Then
                Throw New Exception("Certificado Digital do cnpj " & String.Format("{0:00\.000\.000\/0000\-00}", cnpj) & " expirou em " & x509.GetExpirationDateString)
            End If

            If Date.Now <= x509.NotBefore Then
                Throw New Exception("Certificado Digital do cnpj " & String.Format("{0:00\.000\.000\/0000\-00}", cnpj) & " só estará ativo a partir de " & x509.GetEffectiveDateString)
            End If

            Dim nfeRecepcaoEvento As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.RecepcaoEvento.NfeRecepcaoEvento

            nfeRecepcaoEvento.ClientCertificates.Add(x509)
            nfeRecepcaoEvento.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
            nfeRecepcaoEvento.RequestEncoding = System.Text.Encoding.UTF8
            nfeRecepcaoEvento.Url = Global.DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, WebServicesSefaz.enUF_IBGE.AmbienteNacional, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeRecepcaoEvento)

            Dim nfeCabecMsg As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.RecepcaoEvento.nfeCabecMsg

            nfeCabecMsg.cUF = client.Client.ClientUF
            nfeCabecMsg.versaoDados = versaoDados

            nfeRecepcaoEvento.nfeCabecMsgValue = nfeCabecMsg

            Dim xmlEnvEvento As New XmlDocument()

            xmlEnvEvento.PreserveWhitespace = False
            xmlEnvEvento.LoadXml(XmlSefaz)

            Dim reference As Reference

            For Each xmlEvento As XmlElement In xmlEnvEvento.DocumentElement.ChildNodes

                If xmlEvento.Name.ToLower = "evento" Then

                    reference = New Reference
                    reference.Uri = "#" & xmlEvento.GetElementsByTagName("infEvento").Item(0).Attributes(0).Value

                    Dim SignedXml As New System.Security.Cryptography.Xml.SignedXml(xmlEvento)

                    SignedXml.SigningKey = x509.PrivateKey

                    ' adicionando EnvelopedSignatureTransform a referencia

                    Dim envelopedSigntature As XmlDsigEnvelopedSignatureTransform = New XmlDsigEnvelopedSignatureTransform()

                    reference.AddTransform(envelopedSigntature)

                    Dim c14Transform As New XmlDsigC14NTransform()

                    reference.AddTransform(c14Transform)

                    SignedXml.AddReference(reference)

                    ' carrega o certificado em KeyInfoX509Data para adicionar a KeyInfo

                    Dim keyInfo As New KeyInfo()

                    keyInfo.AddClause(New KeyInfoX509Data(x509))

                    SignedXml.KeyInfo = keyInfo
                    SignedXml.ComputeSignature()

                    ' recuperando a representacao do XML assinado

                    Dim xmlDigitalSignature As XmlElement = SignedXml.GetXml()

                    xmlEvento.AppendChild(xmlDigitalSignature)


                End If

            Next

            Dim XmlNodeRet As XmlNode

            XmlNodeRet = nfeRecepcaoEvento.nfeRecepcaoEvento(xmlEnvEvento)

            Return XmlNodeRet.OuterXml

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function GetX509Certificates() As Dictionary(Of String, X509Certificate2)

        Dim dicCertificate As New Dictionary(Of String, X509Certificate2)
        Dim store As New X509Store(StoreName.My)

        store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)

        For Each painel As PainelControleController In ListPainelControleMD

            Dim CertificateCollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindBySerialNumber, painel.DigitalCertificate.SerialNumber, False), X509Certificate2Collection)
            Dim x509 As X509Certificate2

            For Each x509 In CertificateCollection
                dicCertificate.Add(painel.Client.ClientKey, x509)
            Next x509

            store.Close()

        Next

        Return dicCertificate

    End Function

End Module
