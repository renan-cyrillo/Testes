Imports System.IO
Imports System.IO.Compression
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports DSC.NFe.MD.MDGlobal
Imports DSC.NFe.Sefaz.XmlSefaz
Imports System.Xml.Serialization

Imports System.Security.Cryptography.Xml

Module ModAppBuscaNFSeSP

    Private MDConfiguration As New MDConfigurationModel
    Private ListPainelControleMD As New List(Of PainelControleController)

    Private LogName As String = "DSC.MD"
    Private Source As String = "AppBuscaListaDestinadas"

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
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "iniciando busca de lista destinadas no sefaz do cnpj: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
                BuscaNFSeSP(client)
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando Busca de Lista Destinadas no Sefaz do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)

            Next

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando AppBuscaListaDestinadas", EventLogEntryType.Information, LogName, Source)

        Catch secEx As System.Security.SecurityException
            'Console.WriteLine("ERRO: " & secEx.Message)

        Catch ex As Exception
            'Console.WriteLine("ERRO: " & ex.Message)

        End Try

    End Sub

    Private Sub BuscaNFSeSP(ByVal client As PainelControleController)

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

            UltNSU = client.DefaultConfiguration.NSU

            'Do While continua = 1
            Do While ultNSUInt < maxNSU

                ' Faz a busca da lista de destinadas no sefaz
                Dim retDistDFeInt As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt

                status = ""
                motivo = ""

                'XmlSefaz = GetXmlSefaz(client, UltNSU, status, motivo, continua)
                XmlSefaz = GetXmlSefaz(client, UltNSU, status, motivo, maxNSU, retDistDFeInt)
                'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> ZIPADO XmlSefaz: " + XmlSefaz, EventLogEntryType.Information, LogName, Source)
                If status = "138" Then

                    ' Nova implementação. Faz loop no lote de notas zipadas, descompacta e envia uma por uma para progress
                    For Each nota As Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeIntLoteDistDFeIntDocZip In retDistDFeInt.loteDistDFeInt.docZip
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

                        'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Enviando Xml de retorno do Sefaz para o Progress: " & XmlSefaz, EventLogEntryType.Information, LogName, Source)
                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Enviando Xml de retorno do Sefaz para o Progress: " & xmlNotaStr, EventLogEntryType.Information, LogName, Source)
                        'XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" &
                        '                                                          client.ProgressConfiguration.IP & ":" &
                        '                                                          client.ProgressConfiguration.PortNumber & "/" &
                        '                                                          client.ProgressConfiguration.AppServer)

                        ' Envia Xml de Retorno do Sefaz da Nfe para o Progress

                        'ret = XmlDataTransfer.GravaXmlDestinadasProgress(XmlSefaz, client.Client.ClientKey)

                        'ret = XmlDataTransfer.GravaXmlDestinadasProgress(xmlNotaStr, client.Client.ClientKey)
                        ''testes
                        ret = 0

                        'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> xmlNotaStr: " & xmlNotaStr, EventLogEntryType.Information, LogName, Source)

                        Select Case ret

                            Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK

                                ' Atualiza NSU
                                client.DefaultConfiguration.NSU = UltNSU
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



    Private Function GetXmlSefaz(ByVal client As PainelControleController, ByRef UltNSU As String, ByRef status As String, ByRef motivo As String, ByRef maxNSU As Integer, ByRef retDistDFeInt As Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt) As String

        Try



            Dim versaoDados As String = ""
            Dim cnpj As String = client.Client.ClientKey
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao




            Dim wse As New br.gov.sp.prefeitura.nfe.LoteNFe

            '------------------------------------------------------------------

            'Versão antiga
            'Dim TConsNFeDest As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TConsNFeDest
            'TConsNFeDest.CNPJ = cnpj
            'TConsNFeDest.indEmi = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TConsNFeDestIndEmi.TodosEmitentes
            'TConsNFeDest.indNFe = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TConsNFeDestIndNFe.TodasNFe
            'TConsNFeDest.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TAmb.Producao
            ''TConsNFeDest.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TAmb.Homologacao
            'TConsNFeDest.ultNSU = UltNSU
            'TConsNFeDest.versao = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TVeConsNFeDest.Versao101
            'TConsNFeDest.xServ = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TConsNFeDestXServ.CONSULTARNFEDEST

            'Versão nova
            Dim distDFeInt As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.distDFeInt
            Dim teste As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.pedCosnultaCNPJ.PedidoConsultaCNPJ
            Dim pedConsultaCab As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.pedCosnultaNFePeriodo.PedidoConsultaNFePeriodoCabecalho
            Dim pedConsulta As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.pedCosnultaNFePeriodo.PedidoConsultaNFePeriodo

            'Dim cnpjTeste As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.pedCosnultaCNPJ.tpCPFCNPJ
            'cnpjTeste.
            'teste.CNPJContribuinte = cnpj

            'distDFeInt.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TAmb.Item1 'producao
            ''distDFeInt.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TAmb.Item2  'homologacao
            ' .cUFAutor = RetornarEnumUf(client.Client.ClientUF)
            'distDFeInt.cUFAutorSpecified = True
            'distDFeInt.Item = cnpj
            'distDFeInt.ItemElementName = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.ItemChoiceType.CNPJ
            'distDFeInt.versao = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TVerDistDFe.Item101
            'Dim distNSU As New NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.distDFeIntDistNSU()
            'distNSU.ultNSU = UltNSU.PadLeft(15, "0")
            'distDFeInt.Item1 = distNSU


            Dim dataIni As New Date
            Dim dataFin As New Date
            dataIni = DateTime.Now
            dataIni = FormatDateTime(dataIni, DateFormat.ShortDate)
            dataFin = dataIni

            pedConsultaCab.Versao = WebServicesSefaz.enVersao.Versao1

            Dim cnpjj As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.pedCosnultaNFePeriodo.tpCPFCNPJ

            Try
                cnpjj.Item = cnpj
                pedConsultaCab.CPFCNPJ = cnpjj

            Catch ex As Exception
                Throw New Exception(ex.Message)

            End Try

            'pedConsultaCab.Inscricao = 
            pedConsultaCab.NumeroPagina = 1
            pedConsultaCab.dtInicio = dataIni
            pedConsultaCab.dtFim = dataFin

            pedConsulta.Cabecalho = pedConsultaCab






            'Teste chave
            'distDFeInt.Item = "65943078000195"
            'Dim distNSU As New NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.distDFeIntConsChNFe()
            'distNSU.chNFe = "35170774302290000164550000000064491008111084"
            'distDFeInt.Item1 = distNSU


            Dim xmlConsNFeDest As String
            Dim xmlTeste As String

            ''xmlConsNFeDest = SerializeObjectToXmlString(TConsNFeDest)
            'xmlConsNFeDest = SerializeObjectToXmlString(distDFeInt)
            xmlConsNFeDest = SerializeObjectToXmlString(pedConsulta)
            xmlTeste = SerializeObjectToXmlString(teste)


            'cnpj = TConsNFeDest.CNPJ

            'If TConsNFeDest.versao = Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TVeConsNFeDest.Versao101 Then
            If distDFeInt.versao = Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TVeConsNFeDest.Versao101 Then
                versaoDados = "1.01"
            End If

            'If TConsNFeDest.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest.TAmb.Producao Then
            If distDFeInt.tpAmb = NFe.Sefaz.Nfe.Versao1.XmlModel.ConsNFeDest12.TAmb.Item1 Then
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

            'aqui
            'Dim signedXml As New Security.Cryptography.Xml.SignedXml()
            'tentar assinar
            Dim xmlDocTeste As New XmlDocument()
            xmlDocTeste.PreserveWhitespace = True
            xmlDocTeste.InnerXml = xmlConsNFeDest

            Dim xmlAss As New Security.Cryptography.Xml.SignedXml(xmlDocTeste)
            xmlAss.SigningKey = x509.PrivateKey

            Dim referencia As New Security.Cryptography.Xml.Reference()
            referencia.Uri = ""

            Dim env As New XmlDsigEnvelopedSignatureTransform

            referencia.AddTransform(env)

            Dim c14 As New XmlDsigC14NTransform

            referencia.AddTransform(c14)

            xmlAss.AddReference(referencia)

            Dim keyInfo As New KeyInfo

            keyInfo.AddClause(New KeyInfoX509Data(x509))

            xmlAss.KeyInfo = keyInfo


            Try
                xmlAss.ComputeSignature()

            Catch ex As Exception
                Throw New Exception(ex.Message)

            End Try

            Dim xmlAssinado As XmlElement
            Dim assinatura As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.pedCosnultaNFePeriodo.SignatureType

            Try
                xmlAssinado = xmlAss.GetXml()
                assinatura.Id = xmlAssinado.OuterXml
                pedConsulta.Signature = assinatura


            Catch ex As Exception
                Throw New Exception(ex.Message)

            End Try


            'pedConsulta.Signature.SignatureValue = xmlAssinado.InnerText

            'fim assinar
            'pedConsulta.Signature. = keyInfo


            'Dim nfeDistribuicaoDFe As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.ConsultaDest.NFeDistribuicaoDFe

            'nfeDistribuicaoDFe.ClientCertificates.Add(x509)
            'nfeDistribuicaoDFe.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
            'nfeDistribuicaoDFe.RequestEncoding = System.Text.Encoding.UTF8
            'nfeDistribuicaoDFe.Url = Global.DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, WebServicesSefaz.enUF_IBGE.AmbienteNacional, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsultaDest)

            Dim nfeDistribuicaoDFe As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.ConsultaDest12.NFeDistribuicaoDFe
            Dim testeWSDL As New Global.DSC.NFe.Sefaz.Nfse.Versao1.WSDL.LoteNfe.LoteNFe


            'testeWSDL.ClientCertificates.Add(x509)
            'testeWSDL.SoapVersion = Web.Services.Protocols.SoapvoProtocolVersion.Soap12
            'testeWSDL.RequestEncoding = System.Text.Encoding.UTF8
            'testeWSDL.Url = " "

            'testeWSDL.

            'nfeDistribuicaoDFe.ClientCertificates.Add(x509)
            'nfeDistribuicaoDFe.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
            'nfeDistribuicaoDFe.RequestEncoding = System.Text.Encoding.UTF8
            'nfeDistribuicaoDFe.Url = Global.DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, WebServicesSefaz.enUF_IBGE.AmbienteNacional, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsultaDest)
            ''nfeDistribuicaoDFe.Url = "https://nfe.prefeitura.sp.gov.br/ws/lotenfe.asmx"

            'Dim nfeCabecMsg As New Global.DSC.NFe.Sefaz.Nfe.Versao1.WSDL.ConsultaDest.nfeCabecMsg

            'nfeCabecMsg.cUF = client.Client.ClientUF
            'nfeCabecMsg.versaoDados = versaoDados

            'nfeConsultaDest.nfeCabecMsgValue = nfeCabecMsg

            Dim xmlDoc As New XmlDocument()


            'xmlDoc.PreserveWhitespace = True
            'xmlDoc.InnerXml = xmlConsNFeDest






            'signedXml signedXml = New SignedXml(xmlDocTeste)


            Dim node As XmlNode = xmlDoc
            ' Dim nodeTeste As XmlNode = xmlDocTeste

            'Dim XmlNodeRet As XmlNode
            Dim XmlNodeRet As String
            ' Dim XmlNodeRetTeste As String

            'XmlNodeRet = nfeDistribuicaoDFe.nfeDistDFeInteresse(node)
            Dim cabecalhoo = "<?xml version=""1.0"" encoding=""utf-8""?><PedidoConsultaNFePeriodo xmlns=""http://www.prefeitura.sp.gov.br/nfe""><Cabecalho Versao=""1"" xmlns="""">  <CPFCNPJRemetente><CNPJ>86902053000113</CNPJ></CPFCNPJRemetente>  <dtInicio>2020-11-12</dtInicio>  <dtFim>2020-11-12</dtFim>  <NumeroPagina>1</NumeroPagina></Cabecalho></PedidoConsultaNFePeriodo>"
            Dim assinaturaa = pedConsulta.Signature.Id
            Dim xmlCompleto = cabecalhoo + assinaturaa
            Try
                XmlNodeRet = testeWSDL.ConsultaNFeRecebidas(1, xmlCompleto)

            Catch ex As Exception
                Throw New Exception(ex.Message)

            End Try





            'Dim TRetConsNFeDest As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest.TRetConsNFeDest
            'Dim retDistDFeInt As New Global.DSC.NFe.Sefaz.Nfe.Versao1.XmlModel.RetconsNFeDest12.retDistDFeInt
            Dim retConsulta As New Global.DSC.NFe.Sefaz.Nfse.Versao1.XmlModel.retCosnulta.RetornoConsulta


            'TRetConsNFeDest = DeserializeXmlStringToObject(XmlNodeRet.OuterXml, TRetConsNFeDest.GetType)
            'retDistDFeInt = DeserializeXmlStringToObject(XmlNodeRet.OuterXml, retDistDFeInt.GetType)
            retConsulta = DeserializeXmlStringToObject(XmlNodeRet, XmlNodeRet.GetType)

            'status = TRetConsNFeDest.cStat
            'motivo = TRetConsNFeDest.xMotivo
            'continua = TRetConsNFeDest.indCont

            'UltNSU = TRetConsNFeDest.ultNSU

            status = retDistDFeInt.cStat
            motivo = retDistDFeInt.xMotivo
            UltNSU = retDistDFeInt.ultNSU
            maxNSU = retDistDFeInt.maxNSU

            'Dim x As New XmlDocument
            'x.InnerXml = XmlNodeRet.OuterXml
            'x.Save("C:\DSC-RA\Pasta RA\" & UltNSU & ".xml")

            Return XmlNodeRet
            'Return retConsulta

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
