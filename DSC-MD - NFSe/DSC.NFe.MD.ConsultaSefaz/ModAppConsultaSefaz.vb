Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports DSC.NFe.MD.MDGlobal
Imports DSC.NFe.Sefaz.XmlSefaz

Module ModAppConsultaSefaz

    Private MDConfiguration As New MDConfigurationModel
    Private ListPainelControleMD As New List(Of PainelControleController)
    Private LocalRootFolder As String

    Private LogName As String = "DSC.MD"
    Private Source As String = "AppConsultaSefaz"

    Sub Main()

#If DEMO Then
        Try

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando versão de avaliação do RA", EventLogEntryType.Information, LogName, Source)

            Dim Trial As TrialModel

            Trial = TrialController.GetTrial()

            Dim dataInstalacao As Date
            Dim dataExpiracao As Date
            Dim cultInfo As New System.Globalization.CultureInfo("pt-BR")

            If Date.TryParse(Trial.dRsAc, cultInfo, Globalization.DateTimeStyles.AssumeUniversal, dataInstalacao) Then

                dataExpiracao = DateAdd(DateInterval.Day, 60, dataInstalacao.Date)

                If Now.Date > dataExpiracao Then
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "A versão de avaliação do RA expirou em: " & dataExpiracao, EventLogEntryType.Information, LogName, Source)
                    End
                Else
                    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "A versão de avaliação do RA expirará em: " & dataExpiracao, EventLogEntryType.Information, LogName, Source)
                End If

            Else
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao executar versão de avaliação do RA", EventLogEntryType.Information, LogName, Source)
                End
            End If

        Catch ex As Exception
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro ao executar versão de avaliação do RA", EventLogEntryType.Information, LogName, Source)

        End Try
#End If

        Try

            MDConfiguration = MDConfigurationController.GetMDConfiguration()

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando AppConsultaSefaz", EventLogEntryType.Information, LogName, Source)
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Buscando configurações do Painel de Controle", EventLogEntryType.Information, LogName, Source)

            ListPainelControleMD = ClientController.GetMDRegistry()

            For Each client As PainelControleController In ListPainelControleMD
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Iniciando Consultas de NFe do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)
                ConsultaNFeSefaz(client)
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando Consultas de NFe do CNPJ: " & client.Client.ClientKey, EventLogEntryType.Information, LogName, Source)


            Next

            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Finalizando AppConsultaSefaz", EventLogEntryType.Information, LogName, Source)

        Catch secEx As System.Security.SecurityException
            Console.WriteLine("ERRO: " & secEx.Message)

        Catch ex As Exception
            Console.WriteLine("ERRO: " & ex.Message)

        End Try

    End Sub

#Region "NFe"

    Private Sub ConsultaNFeSefaz(ByVal client As PainelControleController)

        Dim XmlSefaz As String = ""
        Dim XmlRetConsSitNFe As String = ""
        Dim xmlDoc As New XmlDocument()
        Dim TRetConsSitNFe As Object = Nothing

        Dim MDConfiguration As New MDConfigurationModel
        Dim ProgressConfiguration As New ProgressConfigurationModel

        MDConfiguration = MDConfigurationController.GetMDConfiguration()

        Dim ret As DSC.NFe.MD.Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno
        Dim XmlDataTransfer As DSC.NFe.MD.Progress.XmlDataTransfer
        Dim clientKey As String = client.Client.ClientKey

        Try

            XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" &
                                                                                          client.ProgressConfiguration.IP & ":" &
                                                                                          client.ProgressConfiguration.PortNumber & "/" &
                                                                                          client.ProgressConfiguration.AppServer)

            Dim motivo As String = ""
            Dim xmlConsSitNFe As String = XmlDataTransfer.BuscaXmlConsultaNFeSefaz(clientKey, XmlSefaz)

            'Dim xmlConsSitNFe As String = "<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>CONSULTAR</xServ><chNFe>23180702179938000146550010001278451105463720</chNFe></consSitNFe>|<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>CONSULTAR</xServ><chNFe>13180784542901000103550010000586621000062597</chNFe></consSitNFe>|<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>CONSULTAR</xServ><chNFe>13180784542901000103550010000585831000054904</chNFe></consSitNFe>"
            'Dim xmlConsSitNFe As String = "<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>CONSULTAR</xServ><chNFe>35180910265949001068550020000711321827203106</chNFe></consSitNFe>|<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>CONSULTAR</xServ><chNFe>35180945985371000108550210000321651001746790</chNFe></consSitNFe>|<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><xServ>CONSULTAR</xServ><chNFe>35180945985371000108550220000321651001137588</chNFe></consSitNFe>"
            'XmlSefaz = "<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>2</tpAmb><xServ>CONSULTAR</xServ><chNFe>35180910265949001068550020000711321827203106</chNFe></consSitNFe>|<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>2</tpAmb><xServ>CONSULTAR</xServ><chNFe>35180945985371000108550210000321651001746790</chNFe></consSitNFe>|<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>2</tpAmb><xServ>CONSULTAR</xServ><chNFe>35180945985371000108550220000321651001137588</chNFe></consSitNFe>"

            'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> XmlSefaz: " + XmlSefaz, EventLogEntryType.Information, LogName, Source)

            If (XmlSefaz = "" Or XmlSefaz Is Nothing) Then
                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Nao ha notas a serem consultadas", EventLogEntryType.Information, LogName, Source)
            Else
                Dim notas As String() = XmlSefaz.Split("|")



                Dim nota As String
                For Each nota In notas

                    XmlDataTransfer = New DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" &
                                                                                              client.ProgressConfiguration.IP & ":" &
                                                                                              client.ProgressConfiguration.PortNumber & "/" &
                                                                                              client.ProgressConfiguration.AppServer)



                    'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> Nota: " + nota, EventLogEntryType.Information, LogName, Source)
                    'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "--------------------------------------------------", EventLogEntryType.Information, LogName, Source)

                    Try
                        'If xmlConsSitNFe.Contains("versao=""2.") Then
                        '    XmlRetConsSitNFe = ConsultaNFeSefaz2(client, xmlConsSitNFe)
                        '    TRetConsSitNFe = New DSC.NFe.Sefaz.Nfe.Versao2.XmlModel.RetConsSitNFe.TRetConsSitNFe

                        'ElseIf xmlConsSitNFe.Contains("versao=""3.") Then
                        '    XmlRetConsSitNFe = ConsultaNFeSefaz3(client, xmlConsSitNFe)
                        '    TRetConsSitNFe = New DSC.NFe.Sefaz.Nfe.Versao3.XmlModel.RetConsSitNFe.TRetConsSitNFe

                        'ElseIf xmlConsSitNFe.Contains("versao=""4.") Then
                        '    XmlRetConsSitNFe = ConsultaNFeSefaz4(client, nota)
                        '    TRetConsSitNFe = New DSC.NFe.Sefaz.Nfe.Versao4.XmlModel.RetConsSitNFe.TRetConsSitNFe

                        'End If

                        If nota.Contains("versao=""2.") Then
                            XmlRetConsSitNFe = ConsultaNFeSefaz4(client, nota)
                            TRetConsSitNFe = New DSC.NFe.Sefaz.Nfe.Versao2.XmlModel.RetConsSitNFe.TRetConsSitNFe

                        ElseIf nota.Contains("versao=""3.") Then
                            XmlRetConsSitNFe = ConsultaNFeSefaz4(client, nota)
                            TRetConsSitNFe = New DSC.NFe.Sefaz.Nfe.Versao3.XmlModel.RetConsSitNFe.TRetConsSitNFe

                        ElseIf nota.Contains("versao=""4.") Then
                            XmlRetConsSitNFe = ConsultaNFeSefaz4(client, nota)
                            TRetConsSitNFe = New DSC.NFe.Sefaz.Nfe.Versao4.XmlModel.RetConsSitNFe.TRetConsSitNFe

                        End If

                        xmlDoc.InnerXml = XmlRetConsSitNFe

                        TRetConsSitNFe = DeserializeXmlStringToObject(XmlRetConsSitNFe, TRetConsSitNFe.GetType())

                        'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "TRetConsSitNFe: " & TRetConsSitNFe, EventLogEntryType.Information, LogName, Source)

                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Enviando Xml de retorno do Sefaz para o Progress: " & XmlRetConsSitNFe, EventLogEntryType.Information, LogName, Source)



                        ret = XmlDataTransfer.GravaXmlRetornoConsultaNFeSefaz(XmlRetConsSitNFe)


                        Select Case ret

                            Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Retorno do XML enviado ao Progress com sucesso", EventLogEntryType.SuccessAudit, LogName, Source)

                        'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroLeituraXMLConsulta
                        '    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro na Leitura de XML de Consulta", EventLogEntryType.Error, LogName, Source)

                        'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.TipoAmbienteNaoProducao
                        '    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Tipo de Ambiente Incorreto", EventLogEntryType.Error, LogName, Source)

                        'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ChaveAcessoNaoEncontrada
                        '    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Chave de Acesso Não Encontrada", EventLogEntryType.Error, LogName, Source)

                        'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.XMLNaoReconhecido
                        '    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "XML Não Reconhecido", EventLogEntryType.Error, LogName, Source)

                            Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroDeComunicacaoProgress
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro de Comunicação com o Progress", EventLogEntryType.Error, LogName, Source)

                                'Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                                '    DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro inesperado do Progress", EventLogEntryType.Error, LogName, Source)

                            Case Else
                                DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "Erro não tratado pelo Progress", EventLogEntryType.Error, LogName, Source)
                        End Select


                        'Select Case ret
                        '    Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.XmlInconsistente
                        '        motivo = "Xml inconsistente"
                        '        FileMove(clientKey, oFileInfo.Name, oFileInfo.DirectoryName, enPathRA.PathXmlRejeitadosXmlInconsistente)

                        '    Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.TipoAmbienteNaoProducao
                        '        motivo = "Tipo de Ambiente não Produção"
                        '        FileMove(clientKey, oFileInfo.Name, oFileInfo.DirectoryName, enPathRA.PathXmlRejeitadosTipoAmbienteNaoProducao)

                        '    Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ChaveAcessoNaoEncontrada
                        '        motivo = "Chave de Acesso não encontrada"
                        '        FileMove(clientKey, oFileInfo.Name, oFileInfo.DirectoryName, enPathRA.PathXmlRejeitadosChaveAcessoInvalida)

                        '    Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.ErroInesperadoNoProgress
                        '        motivo = "Erro inesperado do Progress"
                        '        FileMove(clientKey, oFileInfo.Name, oFileInfo.DirectoryName, enPathRA.PathXmlRejeitadosErroInesperadoProgress)

                        '    Case Progress.XmlDataTransfer.MensagemErroEnvioXmlRetorno.OK
                        '        motivo = "Erro de envio do XML"
                        '        FileMove(clientKey, oFileInfo.Name, oFileInfo.DirectoryName, enPathRA.PathLixeira)

                        '    Case Else
                        '        motivo = "Erro não tratado pelo Progress"
                        '        FileMove(clientKey, oFileInfo.Name, oFileInfo.DirectoryName, enPathRA.PathXmlRejeitadosErroInesperadoProgress)

                        'End Select



                    Catch ex As Exception
                        DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "ERRO: " & ex.Message, EventLogEntryType.Error, LogName, Source)

                    End Try

                Next
            End If



        Catch ex As Exception
            DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, "ERRO: " & ex.Message, EventLogEntryType.Error, LogName, Source)

        End Try

    End Sub

    Private Function ConsultaNFeSefaz2(ByVal client As PainelControleController, ByVal xmlConsSitNFe As String) As String

        Try

            Dim uf As String = ""
            Dim versaoDados As String = ""
            Dim cnpj As String
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao

            Dim TConsSitNFe As New DSC.NFe.Sefaz.Nfe.Versao2.XmlModel.ConsSitNFe.TConsSitNFe

            TConsSitNFe = DeserializeXmlStringToObject(xmlConsSitNFe, TConsSitNFe.GetType())

            uf = TConsSitNFe.chNFe.Substring(0, 2)
            cnpj = client.Client.ClientKey

            If ListPainelControleMD.Count = 0 Then
                Throw New Exception("Não foi encontrado um certificado digital válido")
            End If

            If TConsSitNFe.versao = DSC.NFe.Sefaz.Nfe.Versao2.XmlModel.ConsSitNFe.TVerConsSitNFe.Versao2 Then
                versaoDados = "2.01"
            End If

            If TConsSitNFe.tpAmb = DSC.NFe.Sefaz.Nfe.Versao2.XmlModel.ConsSitNFe.TAmb.Producao Then
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Producao
            Else
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Homologacao
            End If
            '
            versao = WebServicesSefaz.enVersao.Versao2

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

            Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao2.WSDL.Consulta.NfeConsulta2

            nfeConsulta.ClientCertificates.Add(x509)
            nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
            nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
            nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)

            Dim nfeCabecMsg As New DSC.NFe.Sefaz.Nfe.Versao2.WSDL.Consulta.nfeCabecMsg

            nfeCabecMsg.cUF = uf
            nfeCabecMsg.versaoDados = versaoDados

            nfeConsulta.nfeCabecMsgValue = nfeCabecMsg

            Dim xmlDoc As New XmlDocument()

            xmlDoc.PreserveWhitespace = False
            xmlDoc.InnerXml = xmlConsSitNFe

            Dim node As XmlNode = xmlDoc

            Dim XmlNodeRet As XmlNode

            XmlNodeRet = nfeConsulta.nfeConsultaNF2(node)

            Return XmlNodeRet.OuterXml

        Catch ex As Exception
            'MsgBox(Sefaz.TraceExtension.XmlRequest)
            Throw ex

        End Try

    End Function

    Private Function ConsultaNFeSefaz3(ByVal client As PainelControleController, ByVal xmlConsSitNFe As String) As String

        Try

            Dim retorno As String = ""

            Dim uf As String = ""
            Dim versaoDados As String = ""
            Dim cnpj As String = ""
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao

            Dim TConsSitNFe As New DSC.NFe.Sefaz.Nfe.Versao3.XmlModel.ConsSitNFe.TConsSitNFe

            TConsSitNFe = DeserializeXmlStringToObject(xmlConsSitNFe, TConsSitNFe.GetType())

            uf = TConsSitNFe.chNFe.Substring(0, 2)
            cnpj = client.Client.ClientKey

            If TConsSitNFe.versao = DSC.NFe.Sefaz.Nfe.Versao3.XmlModel.ConsSitNFe.TVerConsSitNFe.Versao3 Then
                versaoDados = "3.10"
            End If

            If TConsSitNFe.tpAmb = DSC.NFe.Sefaz.Nfe.Versao3.XmlModel.ConsSitNFe.TAmb.Producao Then
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Producao
            Else
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Homologacao
            End If

            versao = WebServicesSefaz.enVersao.Versao3

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

            ' Problemas com o sefaz da Bahia (29) forçaram esse bloco, visto que o método do webservice está fora das especificações do sefaz
            If uf = 29 Then

                Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao3.WSDL.ConsultaBA.NfeConsulta

                nfeConsulta.ClientCertificates.Add(x509)
                nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
                nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)

                Dim nfeCabecMsg As New DSC.NFe.Sefaz.Nfe.Versao3.WSDL.ConsultaBA.nfeCabecMsg

                nfeCabecMsg.cUF = uf
                nfeCabecMsg.versaoDados = versaoDados

                nfeConsulta.nfeCabecMsgValue = nfeCabecMsg

                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsSitNFe

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeConsulta.nfeConsultaNF(node)

                retorno = XmlNodeRet.OuterXml

            ElseIf uf = 41 Then

                Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao3.WSDL.ConsultaPR.NfeConsulta3

                nfeConsulta.ClientCertificates.Add(x509)
                nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
                nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)

                Dim nfeCabecMsg As New DSC.NFe.Sefaz.Nfe.Versao3.WSDL.ConsultaPR.nfeCabecMsg

                nfeCabecMsg.cUF = uf
                nfeCabecMsg.versaoDados = versaoDados

                nfeConsulta.nfeCabecMsgValue = nfeCabecMsg

                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsSitNFe

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeConsulta.nfeConsultaNF(node)

                retorno = XmlNodeRet.OuterXml

            Else

                Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao3.WSDL.Consulta.NfeConsulta2

                nfeConsulta.ClientCertificates.Add(x509)
                nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
                nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)

                Dim nfeCabecMsg As New DSC.NFe.Sefaz.Nfe.Versao3.WSDL.Consulta.nfeCabecMsg

                nfeCabecMsg.cUF = uf
                nfeCabecMsg.versaoDados = versaoDados

                nfeConsulta.nfeCabecMsgValue = nfeCabecMsg

                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsSitNFe

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeConsulta.nfeConsultaNF2(node)

                retorno = XmlNodeRet.OuterXml

            End If

            Return retorno

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function ConsultaNFeSefaz4(ByVal client As PainelControleController, ByVal xmlConsSitNFe As String) As String

        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12 'need 4.5 framework

            Dim retorno As String = ""

            Dim uf As String = ""
            Dim versaoDados As String = ""
            Dim cnpj As String = ""
            Dim tipoAmbiente As WebServicesSefaz.enAmbienteSefaz
            Dim versao As WebServicesSefaz.enVersao

            Dim TConsSitNFe As New DSC.NFe.Sefaz.Nfe.Versao4.XmlModel.ConsSitNFe.TConsSitNFe

            TConsSitNFe = DeserializeXmlStringToObject(xmlConsSitNFe, TConsSitNFe.GetType())

            uf = TConsSitNFe.chNFe.Substring(0, 2)
            cnpj = client.Client.ClientKey

            If TConsSitNFe.versao = DSC.NFe.Sefaz.Nfe.Versao4.XmlModel.ConsSitNFe.TVerConsSitNFe.Versao4 Then
                versaoDados = "4.00"
            End If

            If TConsSitNFe.tpAmb = DSC.NFe.Sefaz.Nfe.Versao4.XmlModel.ConsSitNFe.TAmb.Producao Then
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Producao
            Else
                tipoAmbiente = WebServicesSefaz.enAmbienteSefaz.Homologacao
            End If


            versao = WebServicesSefaz.enVersao.Versao4

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

            ' Problemas com o sefaz da Bahia (29) forçaram esse bloco, visto que o método do webservice está fora das especificações do sefaz
            If uf = 29 Then

                Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao4.WSDL.ConsultaBA.NFeConsultaProtocolo

                nfeConsulta.ClientCertificates.Add(x509)
                nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
                nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)


                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsSitNFe

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeConsulta.nfeConsultaNF(node)

                retorno = XmlNodeRet.OuterXml

            ElseIf uf = 41 Then

                Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao4.WSDL.ConsultaPR.NFeConsultaProtocolo3

                nfeConsulta.ClientCertificates.Add(x509)
                nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
                nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)



                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsSitNFe

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeConsulta.nfeConsultaNF(node)

                retorno = XmlNodeRet.OuterXml

            Else

                Dim nfeConsulta As New DSC.NFe.Sefaz.Nfe.Versao4.WSDL.Consulta.NFeConsultaProtocolo2

                nfeConsulta.ClientCertificates.Add(x509)
                nfeConsulta.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
                nfeConsulta.RequestEncoding = System.Text.Encoding.UTF8
                nfeConsulta.Url = DSC.NFe.Sefaz.XmlSefaz.WebServicesSefaz.GetEnderecoSefaz(WebServicesSefaz.enTipoSefaz.Nfe, versao, uf, tipoAmbiente, WebServicesSefaz.enTipoServicoSefaz.NfeConsulta)
                Dim xmlDoc As New XmlDocument()

                xmlDoc.PreserveWhitespace = True
                xmlDoc.InnerXml = xmlConsSitNFe

                Dim node As XmlNode = xmlDoc

                Dim XmlNodeRet As XmlNode

                XmlNodeRet = nfeConsulta.nfeConsultaNF(node)
                retorno = XmlNodeRet.OuterXml
                'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>> XmlNodeRet.OuterXml: " + XmlNodeRet.OuterXml, EventLogEntryType.Error, LogName, Source)
                'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>>Name " + XmlNodeRet.Name, EventLogEntryType.Error, LogName, Source)
                'DSC.NFe.Log.GravaLog(MDConfiguration.LogFolder, ">>>>>NamespaceURI " + XmlNodeRet.NamespaceURI, EventLogEntryType.Error, LogName, Source)



            End If
            Return retorno

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#End Region


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
