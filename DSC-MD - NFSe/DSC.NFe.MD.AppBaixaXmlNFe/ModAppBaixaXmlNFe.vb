Imports System.IO
Imports System.IO.Compression
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Security.Cryptography.X509Certificates
Imports DSC.NFe.MD.MDGlobal
Imports DSC.NFe.Sefaz.XmlSefaz

Module ModAppBaixaXmlNFe

    Private MDConfiguration As New MDConfigurationModel
    Private ListPainelControleMD As New List(Of PainelControleController)

    Private LogName As String = "DSC.MD"
    Private Source As String = "AppBaixaXmlNFe"

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

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando AppBaixaXmlNFe", EventLogEntryType.Information, LogName, Source)
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Buscando configurações do Painel de Controle", EventLogEntryType.Information, LogName, Source)

            ListPainelControleMD = ClientController.GetMDRegistry()

            For Each client As PainelControleController In ListPainelControleMD
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando Baixa de NFe do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
                BuscaListaNFe(client)
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando Baixa de NFe do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
            Next

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando AppBaixaXmlNFe", EventLogEntryType.Information, LogName, Source)

        Catch secEx As System.Security.SecurityException
            Console.WriteLine("ERRO: " & secEx.Message)

        Catch ex As Exception
            Console.WriteLine("ERRO: " & ex.Message)

        End Try

    End Sub

    Private Sub BuscaListaNFe(ByVal client As PainelControleController)

        Dim XmlSefaz As String = ""
        Dim UltNSU As String = ""

        Dim ProgressConfiguration As New ProgressConfigurationModel

        Dim ret As DSC.NFe.MD.Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno
        Dim XmlDataTransfer As DSC.NFe.MD.Progress.XmlDataTransfer

        Dim XmlNfe As List(Of String)
        Dim fileName As String = ""

        Try

            ' Busca Lista de Solicitação de Eventos no progress

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Buscando Xml de Busca de NFe para Baixar no Progress", EventLogEntryType.Information, LogName, Source)

            XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" &
                                                                      client.ProgressConfiguration.IP & ":" &
                                                                      client.ProgressConfiguration.PortNumber & "/" &
                                                                      client.ProgressConfiguration.AppServer)

            ' Envia Xml de Retorno do Sefaz da Nfe para o Progress

            ret = XmlDataTransfer.BuscaXmlListaDownloadNFeProgress(client.Client.ClientKey, XmlSefaz)
            'ret = 0

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Envio Sefaz: ", EventLogEntryType.Information, LogName, Source)
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, XmlSefaz, EventLogEntryType.Information, LogName, Source)
            'XmlSefaz = "<?xml version=""1.0"" ?><downloadNFe versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>DOWNLOAD NFE</xServ><CNPJ>86902053000113</CNPJ><chNFe>35190960680873000114550010003665301636718151</chNFe><chNFe>33190910542732000167550010000044621009411190</chNFe></downloadNFe>"
            Select Case ret

                Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK

                    If XmlSefaz = "" Then
                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Progress retornou um XML vazio.", EventLogEntryType.Warning, LogName, Source)
                    Else
                        Dim retDistDFeInt As New List(Of Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt)
                        XmlNfe = GetXmlSefaz(client, XmlSefaz, retDistDFeInt)

                        If retDistDFeInt Is Nothing Then
                            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Sefaz retornou um XML vazio.", EventLogEntryType.Warning, LogName, Source)
                        End If

                        'Nova implementação. Recebe o xml compactado da nota e descompacta antes de enviar ao progress
                        For Each objXml In retDistDFeInt
                            XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" &
                                                              client.ProgressConfiguration.IP & ":" &
                                                              client.ProgressConfiguration.PortNumber & "/" &
                                                              client.ProgressConfiguration.AppServer)

                            If objXml.loteDistDFeInt Is Nothing And objXml.cStat <> 653 Then
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Sefaz não encontrou nenhum documento.", EventLogEntryType.Warning, LogName, Source)
                                Return
                            End If


                            Dim xmlNotaStr As String
                            If objXml.cStat = 653 Then
                                xmlNotaStr = objXml.cStat + "-" + objXml.xMotivo
                            Else
                                Dim listaNota = objXml.loteDistDFeInt.docZip
                                Dim nota As Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeIntLoteDistDFeIntDocZip
                                nota = objXml.loteDistDFeInt.docZip(0)
                                Dim docZip As Byte() = nota.Value

                                Dim stream As Stream = New MemoryStream(docZip)
                                Dim gz As New System.IO.Compression.GZipStream(stream, CompressionMode.Decompress)
                                Dim srNota As New IO.StreamReader(gz)
                                'Dim xmlNotaStr As String = srNota.ReadLine()
                                xmlNotaStr = srNota.ReadToEnd()

                                srNota.Close()
                            End If



                            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Retorno Sefaz: ", EventLogEntryType.Information, LogName, Source)
                            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, xmlNotaStr, EventLogEntryType.Information, LogName, Source)

                            'ret = XmlDataTransfer.EnviaProgressXmlRetornoDownloadNFe(XmlNfe)
                            'Versao nova

                            ret = XmlDataTransfer.EnviaProgressXmlRetornoDownloadNFe(xmlNotaStr)
                            'ret = 0
                            Select Case ret
                                Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK

                                    ' Verifica se o e-mail foi informado no Painel de Controle
                                    ' Se sim envia um e-mail com a NFe em anexo

                                    If client.DefaultConfiguration.EmailXmlNFe <> "" Then

                                        Try

                                            Dim xmlRetDownloadNFe As New XmlDocument()

                                            xmlRetDownloadNFe.PreserveWhitespace = False
                                            'xmlRetDownloadNFe.LoadXml(XmlNfe)
                                            'Versao nova
                                            xmlRetDownloadNFe.LoadXml(xmlNotaStr)

                                            For Each xmlRetNfeNode As XmlElement In xmlRetDownloadNFe.DocumentElement.ChildNodes

                                                'If xmlRetNfeNode.Name.ToLower = "retnfe" Then
                                                'Versao nova
                                                If xmlRetNfeNode.Name.ToLower = "nfe" Then

                                                    Dim xmlRetNFe As New XmlDocument()

                                                    xmlRetNFe.PreserveWhitespace = False
                                                    xmlRetNFe.LoadXml(xmlRetNfeNode.OuterXml)

                                                    For Each xmlProcNfeNode As XmlElement In xmlRetNFe.DocumentElement.ChildNodes

                                                        'If xmlProcNfeNode.Name.ToLower = "procnfe" Then
                                                        If xmlProcNfeNode.Name.ToLower = "infnfe" Then

                                                            'fileName = xmlProcNfeNode.ChildNodes(0).ChildNodes(0).ChildNodes(0).Attributes(0).Value & ".xml"
                                                            fileName = xmlProcNfeNode.Attributes.Item(0).Value & ".xml"
                                                            Dim xmlNFeToRA As New XmlDocument()

                                                            'xmlNFeToRA.LoadXml(xmlProcNfeNode.InnerXml)
                                                            xmlNFeToRA.LoadXml(xmlNotaStr)
                                                            xmlNFeToRA.Save(fileName)

                                                            Dim EmailList As New List(Of String)

                                                            EmailList.Add(client.DefaultConfiguration.EmailXmlNFe)

                                                            Dim FileList As New List(Of String)

                                                            FileList.Add(fileName)

                                                            EmailProtocol.SMTPClient.SendEmail(client.SMTPConfiguration.HostName,
                                                                                               client.SMTPConfiguration.PortNumber,
                                                                                               client.SMTPConfiguration.User,
                                                                                               client.SMTPConfiguration.User,
                                                                                               EmailList,
                                                                                               client.SMTPConfiguration.SSL,
                                                                                               Nothing,
                                                                                               "Email enviado via MD - " & fileName,
                                                                                               "",
                                                                                               Nothing,
                                                                                               Nothing,
                                                                                               FileList,
                                                                                               Net.Mail.MailPriority.High,
                                                                                               EmailProtocol.SMTPClient.EmailFormat.Text)

                                                        End If
                                                    Next

                                                End If

                                            Next

                                        Catch ex As Exception
                                            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao enviar e-mail com a NFe para o RA.", EventLogEntryType.Error, LogName, Source)

                                        Finally
                                            If fileName <> "" Then
                                                If File.Exists(fileName) Then
                                                    File.Delete(fileName)
                                                End If
                                            End If

                                        End Try

                                    End If

                                Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroDeComunicacaoProgress, Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao se comunicar com o Progress.", EventLogEntryType.Error, LogName, Source)

                            End Select
                        Next
                    End If

                Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroDeComunicacaoProgress, Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao se comunicar com o Progress.", EventLogEntryType.Error, LogName, Source)

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function GetXmlSefaz(ByVal client As PainelControleController, ByRef XmlSefaz As String, ByRef retDistDFeInt As List(Of Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt)) As List(Of String)

        Try

            Dim versaoDados As String = ""
            Dim cnpj As String = client.Client.ClientKey
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao

            'Versão nova
            Dim listaChaves As New List(Of String)
            Dim listaRetornoXmlString As New List(Of String)

            Dim objXmlSefaz As New XmlDocument()
            objXmlSefaz.PreserveWhitespace = False
            objXmlSefaz.LoadXml(XmlSefaz)

            For Each xmlRetNfeNode As XmlElement In objXmlSefaz.DocumentElement.ChildNodes

                'If xmlRetNfeNode.Name.ToLower = "retnfe" Then
                If xmlRetNfeNode.Name.ToLower = "chnfe" Then

                    Dim xmlRetNFe As New XmlDocument()

                    xmlRetNFe.PreserveWhitespace = False
                    xmlRetNFe.LoadXml(xmlRetNfeNode.OuterXml)

                    Dim xmlStr As String = ""
                    xmlStr = xmlRetNFe.ChildNodes(0).InnerText
                    'xmlStr = "35190960680873000114550010003665301636718151"
                    listaChaves.Add(xmlStr)

                End If

            Next

            For Each chave In listaChaves

                Dim distDFeInt As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.distDFeInt
                distDFeInt.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TAmb.Item1 'producao
                'distDFeInt.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TAmb.Item2  'homologacao
                distDFeInt.cUFAutor = RetornarEnumUf(client.Client.ClientUF)
                distDFeInt.cUFAutorSpecified = True
                distDFeInt.Item = cnpj
                distDFeInt.ItemElementName = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.ItemChoiceType.CNPJ
                distDFeInt.versao = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TVerDistDFe.Item101
                Dim distNSU As New NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.distDFeIntConsChNFe()
                distNSU.chNFe = chave
                distDFeInt.Item1 = distNSU

                'versaoDados = "1.00"
                versaoDados = "1.01"

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

                'Versao antiga
                'Dim nfeDownloadNF As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.DownloadNF.NfeDownloadNF

                'nfeDownloadNF.ClientCertificates.Add(x509)
                'nfeDownloadNF.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                'nfeDownloadNF.RequestEncoding = System.Text.Encoding.UTF8
                'nfeDownloadNF.Url = Global.DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, WebServicesSefaz.enUF_IBGE.AmbienteNacional, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeDownloadNF)

                'Dim nfeCabecMsg As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.DownloadNF.nfeCabecMsg

                'nfeCabecMsg.cUF = client.Client.ClientUF
                'nfeCabecMsg.versaoDados = versaoDados

                'nfeDownloadNF.nfeCabecMsgValue = nfeCabecMsg

                'Dim xmlDoc As New XmlDocument()

                'xmlDoc.PreserveWhitespace = True
                'xmlDoc.InnerXml = XmlSefaz

                'Dim node As XmlNode = xmlDoc

                'Dim XmlNodeRet As XmlNode

                'XmlNodeRet = nfeDownloadNF.nfeDownloadNF(node)

                'Versao Nova
                Dim nfeDistribuicaoDFe As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.ConsultaDest12.NFeDistribuicaoDFe

                nfeDistribuicaoDFe.ClientCertificates.Add(x509)
                nfeDistribuicaoDFe.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeDistribuicaoDFe.RequestEncoding = System.Text.Encoding.UTF8
                nfeDistribuicaoDFe.Url = Global.DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, WebServicesSefaz.enUF_IBGE.AmbienteNacional, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeDownloadNF)

                Dim xmlConsNFeDest As String

                xmlConsNFeDest = SerializeObjectToXmlString(distDFeInt)


                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsNFeDest

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeDistribuicaoDFe.nfeDistDFeInteresse(node)


                If Not XmlNodeRet Is Nothing AndAlso Not XmlNodeRet.OuterXml Is Nothing Then
                    Dim itemRetObjXml As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt
                    itemRetObjXml = DeserializeXmlStringToObject(XmlNodeRet.OuterXml, itemRetObjXml.GetType)

                    If Not itemRetObjXml.loteDistDFeInt Is Nothing Then
                        listaRetornoXmlString.Add(XmlNodeRet.OuterXml)
                        retDistDFeInt.Add(itemRetObjXml)
                    End If

                    If itemRetObjXml.cStat = 653 Then
                        listaRetornoXmlString.Add(XmlNodeRet.OuterXml)
                        itemRetObjXml.xMotivo = chave
                        retDistDFeInt.Add(itemRetObjXml)
                    End If
                End If

                'Dim xmlProgress As String = SerializeObjectToXmlString(nfeCabecMsg)
            Next

            Return listaRetornoXmlString

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function RetornarEnumUf(ByVal codigoUf As Integer) As NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE
        Dim retorno As NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE

        Select Case codigoUf
            Case 11
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item11
            Case 12
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item12
            Case 13
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item13
            Case 14
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item14
            Case 15
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item15
            Case 16
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item16
            Case 17
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item17
            Case 21
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item21
            Case 22
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item22
            Case 23
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item23
            Case 24
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item24
            Case 25
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item25
            Case 26
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item26
            Case 27
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item27
            Case 28
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item28
            Case 29
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item29
            Case 31
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item31
            Case 32
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item32
            Case 33
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item33
            Case 35
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item35
            Case 41
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item41
            Case 42
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item42
            Case 43
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item43
            Case 50
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item50
            Case 51
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item51
            Case 52
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item52
            Case 53
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item53
            Case Else
                retorno = Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TCodUfIBGE.Item35
        End Select

        Return retorno
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