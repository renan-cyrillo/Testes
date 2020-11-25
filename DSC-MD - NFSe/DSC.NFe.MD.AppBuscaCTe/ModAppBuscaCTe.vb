Imports System.IO
Imports System.IO.Compression
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports DSC.NFe.MD.MDGlobal
Imports DSC.NFe.Sefaz.XmlSefaz
Imports System.Xml.Serialization

Module ModAppBuscaCTe

    Private MDConfiguration As New MDConfigurationModel
    Private ListPainelControleMD As New List(Of PainelControleController)

    Private LogName As String = "DSC.MD"
    Private Source As String = "AppBuscaCTe"

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

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando AppBuscaListaDestinadas", EventLogEntryType.Information, LogName, Source)
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Buscando configurações do Painel de Controle", EventLogEntryType.Information, LogName, Source)

            ListPainelControleMD = ClientController.GetMDRegistry()

            For Each client As PainelControleController In ListPainelControleMD

                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando Busca de Lista Destinadas CTe no Sefaz do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
                BuscaListaDestinadasCTe(client)
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando Busca de Lista Destinadas CTe no Sefaz do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
            Next

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando AppBuscaListaDestinadas", EventLogEntryType.Information, LogName, Source)

        Catch secEx As System.Security.SecurityException
            'Console.WriteLine("ERRO: " & secEx.Message)

        Catch ex As Exception
            'Console.WriteLine("ERRO: " & ex.Message)

        End Try

    End Sub



    Private Sub BuscaListaDestinadasCTe(ByVal client As PainelControleController)
        Dim XmlSefaz As String
        Dim UltNSU As String = ""

        Dim ProgressConfiguration As New ProgressConfigurationModel

        Dim ret As DSC.NFe.MD.Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno
        Dim XmlDataTransfer As DSC.NFe.MD.Progress.XmlDataTransfer

        Dim status As String
        Dim motivo As String
        Dim continua As Integer = 1
        Dim maxNSU As Integer = 1, ultNSUInt As Integer = 0

        Try
            UltNSU = client.DefaultConfiguration.NsuCte

            'Do While continua = 1
            Do While ultNSUInt < maxNSU

                ' Faz a busca da lista de destinadas no sefaz
                'Dim retDistDFeInt As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt
                Dim retDistDFeInt As New Global.DSC.NFe.Sefaz.Cte.Versao1.XmlModel.RetDistDFeInt.retDistDFeInt

                status = ""
                motivo = ""
                XmlSefaz = GetXmlCTeSefaz(client, UltNSU, status, motivo, maxNSU, retDistDFeInt)
                'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> ZIPADO XmlSefaz: " + XmlSefaz, EventLogEntryType.Information, LogName, Source)
                If status = "138" Then

                    ' Nova implementação. Faz loop no lote de notas zipadas, descompacta e envia uma por uma para progress
                    ' For Each nota As Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeIntLoteDistDFeIntDocZip In retDistDFeInt.loteDistDFeInt.docZip
                    For Each nota As Global.DSC.NFe.Sefaz.Cte.Versao1.XmlModel.RetDistDFeInt.retDistDFeIntLoteDistDFeIntDocZip In retDistDFeInt.loteDistDFeInt.docZip
                        Dim nsu As Integer = nota.NSU
                        Dim schema As String = nota.schema
                        Dim docZip As Byte() = nota.Value

                        Dim stream As Stream = New MemoryStream(docZip)
                        Dim gz As New System.IO.Compression.GZipStream(stream, CompressionMode.Decompress)
                        Dim srNota As New IO.StreamReader(gz)
                        Dim xmlNotaStr As String = srNota.ReadLine()
                        srNota.Close()
                        'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> xmlNotaStr: " + xmlNotaStr, EventLogEntryType.Information, LogName, Source)

                        ' Envia o xml de retorno para o progress

                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Enviando Xml de retorno do Sefaz para o Progress: " & xmlNotaStr, EventLogEntryType.Information, LogName, Source)
                        XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" &
                                                                                  client.ProgressConfiguration.IP & ":" &
                                                                                  client.ProgressConfiguration.PortNumber & "/" &
                                                                                  client.ProgressConfiguration.AppServer)

                        ' Envia Xml de Retorno do Sefaz da Nfe para o Progress

                        'ret = XmlDataTransfer.GravaXmlCTeProgress(xmlNotaStr, client.Client.ClientKey)
                        ret = XmlDataTransfer.GravaXmlCTeProgress(xmlNotaStr)

                        Select Case ret

                            Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK

                                ' Atualiza NSU
                                client.DefaultConfiguration.NsuCte = UltNSU
                                DefaultConfigurationController.SetDefaultConfiguration(client.DefaultConfiguration)
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Enviado ao Progress com Sucesso!", EventLogEntryType.SuccessAudit, LogName, Source)

                                'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroDeComunicacaoProgress, Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                            Case Else
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao se comunicar com o Progress.", EventLogEntryType.Error, LogName, Source)

                        End Select
                    Next
                Else
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro: " & status & " - " & motivo, EventLogEntryType.Warning, LogName, Source)
                End If

                ultNSUInt = CType(UltNSU, Integer)

            Loop

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Function GetXmlCTeSefaz(ByVal client As PainelControleController, ByRef UltNSU As String, ByRef status As String, ByRef motivo As String, ByRef maxNSU As Integer, ByRef retDistDFeInt As Global.DSC.NFe.Sefaz.Cte.Versao1.XmlModel.RetDistDFeInt.retDistDFeInt) As String
        Try
            Dim versaoDados As String = ""
            Dim cnpj As String = client.Client.ClientKey
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao




            Dim distDFeInt As New Global.DSC.NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.distDFeInt
            distDFeInt.tpAmb = NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.TAmb.Item1 'producao
            'distDFeInt.tpAmb = NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.TAmb.Item2 'homologacao
            distDFeInt.cUFAutor = RetornarEnumUf(client.Client.ClientUF)
            distDFeInt.Item = cnpj
            distDFeInt.ItemElementName = NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.ItemChoiceType.CNPJ
            distDFeInt.versao = NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.TVerDistDFe.Item100
            Dim distNSU As New NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.distDFeIntDistNSU

            distNSU.ultNSU = UltNSU.PadLeft(15, "0")
            distDFeInt.Item1 = distNSU



            Dim xmlConsNFeDest As String

            xmlConsNFeDest = SerializeObjectToXmlString(distDFeInt)

            If distDFeInt.versao = Global.DSC.NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.TVerDistDFe.Item100 Then
                versaoDados = "1.00"
            End If

            'If distDFeInt.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TAmb.Item1 Then
            If distDFeInt.tpAmb = NFe.Sefaz.Cte.Versao1.XmlModel.DistDFeInt.TAmb.Item1 Then
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Producao
            Else
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Homologacao
            End If
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

            Dim cteDistribuicaoDFe As New Global.DSC.NFe.Sefaz.Cte.Versao1.WSDL.DistribuicaoDFe.CTeDistribuicaoDFe


            cteDistribuicaoDFe.ClientCertificates.Add(x509)
            cteDistribuicaoDFe.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
            cteDistribuicaoDFe.RequestEncoding = System.Text.Encoding.UTF8

            'cteDistribuicaoDFe.Url = Global.DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Cte, versao, WebServicesSefaz.enUF_IBGE.AmbienteNacional, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.CTeDistribuicaoDFe)

            xmlConsNFeDest = xmlConsNFeDest.Replace("http://www.portalfiscal.inf.br/nfe", "http://www.portalfiscal.inf.br/cte")
            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.InnerXml = xmlConsNFeDest




            Dim node As XmlNode = xmlDoc

            Dim XmlNodeRet As XmlNode

            XmlNodeRet = cteDistribuicaoDFe.cteDistDFeInteresse(node)


            retDistDFeInt = DeserializeXmlStringToObject(XmlNodeRet.OuterXml, retDistDFeInt.GetType)



            status = retDistDFeInt.cStat
            motivo = retDistDFeInt.xMotivo
            UltNSU = retDistDFeInt.ultNSU
            maxNSU = retDistDFeInt.maxNSU



            Return XmlNodeRet.OuterXml

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
