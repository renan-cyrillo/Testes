Imports System.Xml
Imports System.IO
Imports System.Reflection

Namespace XmlSefaz

    Public Class WebServicesSefaz

#Region " Enum "

        Public Enum enTipoSefaz
            Cte
            Nfe
        End Enum

        Public Enum enAmbienteSefaz
            Producao = 1
            Homologacao = 2
        End Enum

        Public Enum enUF_IBGE
            AC = 12
            AL = 27
            AP = 16
            AM = 13
            BA = 29
            CE = 23
            DF = 53
            ES = 32
            GO = 52
            MA = 21
            MG = 31
            MS = 50
            MT = 51
            PA = 15
            PB = 25
            PE = 26
            PI = 22
            PR = 41
            RJ = 33
            RN = 24
            RO = 11
            RR = 14
            RS = 43
            SC = 42
            SE = 28
            SP = 35
            [TO] = 17
            AmbienteNacional = 91
        End Enum

        Public Enum enTipoServicoSefaz
            NfeRecepcao
            NfeRetRecepcao
            NfeCancelamento
            NfeInutilizacao
            NfeConsulta
            NfeStatusServico
            NfeConsultaCadastro
            NfeRecepcaoEvento
            NfeConsultaDest
            NfeDownloadNF
            NFeAutorizacao
            NFeRetAutorizacao
            CteRecepcao
            CteRetRecepcao
            CteCancelamento
            CteInutilizacao
            CteConsultaProtocolo
            CteStatusServico
            CteRecepcaoEvento
            CteConsultaCadastro
            CTeDistribuicaoDFe
        End Enum

        Public Enum enVersao
            Versao1 = 1
            Versao2 = 2
            Versao3 = 3
            Versao4 = 4
        End Enum

#End Region

#Region " Métodos "

        Public Shared Function UF_To_UF_IBGE(ByVal UF As String) As enUF_IBGE

            Dim UF_IBGE As enUF_IBGE

            Select Case UF
                Case "AC"
                    UF_IBGE = enUF_IBGE.AC
                Case "AL"
                    UF_IBGE = enUF_IBGE.AL
                Case "AP"
                    UF_IBGE = enUF_IBGE.AP
                Case "AM"
                    UF_IBGE = enUF_IBGE.AM
                Case "BA"
                    UF_IBGE = enUF_IBGE.BA
                Case "CE"
                    UF_IBGE = enUF_IBGE.CE
                Case "DF"
                    UF_IBGE = enUF_IBGE.DF
                Case "GO"
                    UF_IBGE = enUF_IBGE.GO
                Case "MA"
                    UF_IBGE = enUF_IBGE.MA
                Case "MG"
                    UF_IBGE = enUF_IBGE.MG
                Case "MS"
                    UF_IBGE = enUF_IBGE.MS
                Case "MT"
                    UF_IBGE = enUF_IBGE.MT
                Case "PA"
                    UF_IBGE = enUF_IBGE.PA
                Case "PB"
                    UF_IBGE = enUF_IBGE.PB
                Case "PE"
                    UF_IBGE = enUF_IBGE.PE
                Case "PI"
                    UF_IBGE = enUF_IBGE.PI
                Case "PR"
                    UF_IBGE = enUF_IBGE.PR
                Case "RJ"
                    UF_IBGE = enUF_IBGE.RJ
                Case "RN"
                    UF_IBGE = enUF_IBGE.RN
                Case "RO"
                    UF_IBGE = enUF_IBGE.RO
                Case "RR"
                    UF_IBGE = enUF_IBGE.RR
                Case "RS"
                    UF_IBGE = enUF_IBGE.RS
                Case "SC"
                    UF_IBGE = enUF_IBGE.SC
                Case "SE"
                    UF_IBGE = enUF_IBGE.SE
                Case "SP"
                    UF_IBGE = enUF_IBGE.SP
                Case "TO"
                    UF_IBGE = enUF_IBGE.TO
                Case "ES"
                    UF_IBGE = enUF_IBGE.ES
                Case "AN"
                    UF_IBGE = enUF_IBGE.AmbienteNacional
                Case Else
                    Throw New Exception("UF inválida")

            End Select

            Return UF_IBGE

        End Function

        Public Shared Function UF_IBGE_To_UF(ByVal UF_IBGE As enUF_IBGE) As String

            Dim strUF As String = ""

            Select Case UF_IBGE
                Case enUF_IBGE.AC
                    strUF = "AC"
                Case enUF_IBGE.AL
                    strUF = "AL"
                Case enUF_IBGE.AP
                    strUF = "AP"
                Case enUF_IBGE.AM
                    strUF = "AM"
                Case enUF_IBGE.BA
                    strUF = "BA"
                Case enUF_IBGE.CE
                    strUF = "CE"
                Case enUF_IBGE.DF
                    strUF = "DF"
                Case enUF_IBGE.GO
                    strUF = "GO"
                Case enUF_IBGE.MA
                    strUF = "MA"
                Case enUF_IBGE.MG
                    strUF = "MG"
                Case enUF_IBGE.MS
                    strUF = "MS"
                Case enUF_IBGE.MT
                    strUF = "MT"
                Case enUF_IBGE.PA
                    strUF = "PA"
                Case enUF_IBGE.PB
                    strUF = "PB"
                Case enUF_IBGE.PE
                    strUF = "PE"
                Case enUF_IBGE.PI
                    strUF = "PI"
                Case enUF_IBGE.PR
                    strUF = "PR"
                Case enUF_IBGE.RJ
                    strUF = "RJ"
                Case enUF_IBGE.RN
                    strUF = "RN"
                Case enUF_IBGE.RO
                    strUF = "RO"
                Case enUF_IBGE.RR
                    strUF = "RR"
                Case enUF_IBGE.RS
                    strUF = "RS"
                Case enUF_IBGE.SC
                    strUF = "SC"
                Case enUF_IBGE.SE
                    strUF = "SE"
                Case enUF_IBGE.SP
                    strUF = "SP"
                Case enUF_IBGE.TO
                    strUF = "TO"
                Case enUF_IBGE.ES
                    strUF = "ES"
                Case enUF_IBGE.AmbienteNacional
                    strUF = "AN"
            End Select

            Return strUF

        End Function

        Public Shared Function GetEnderecoSefaz(ByVal TipoSefaz As enTipoSefaz, ByVal VersaoSefaz As enVersao, ByVal UF_IBGE As enUF_IBGE, ByVal AmbienteSefaz As enAmbienteSefaz, ByVal TipoServicoSefaz As enTipoServicoSefaz) As String

            Try

                Dim strUF As String = UF_IBGE_To_UF(UF_IBGE)
                Dim SefazEstado As String = ""

                Dim XmlDocument As New XmlDocument()
                Dim FileXmlConfig As String = "WS-Sefaz.xml"

                Dim pathApp As String = Assembly.GetExecutingAssembly().Location
                Dim FileInfo As FileInfo = New FileInfo(pathApp)
                Dim xfile As String = Path.Combine(FileInfo.DirectoryName, FileXmlConfig)
                If Not File.Exists(xfile) Then
                    Throw New Exception("Arquivo com endereço do WebService não foi encontrado, verifique a existência do arquivo " & FileXmlConfig & " na pasta " & pathApp)
                End If

                XmlDocument.Load(xfile)

                If TipoSefaz = enTipoSefaz.Nfe Then

                    Select Case VersaoSefaz
                        Case enVersao.Versao1, enVersao.Versao2, enVersao.Versao3, enVersao.Versao4

                        Case Else
                            Throw New Exception("Versão Sefaz informada não está sendo tratado pela aplicação.")

                    End Select

                    Select Case UF_IBGE
                        Case enUF_IBGE.AM, enUF_IBGE.BA, enUF_IBGE.CE, enUF_IBGE.GO, enUF_IBGE.MG, enUF_IBGE.MS, enUF_IBGE.MT, enUF_IBGE.PE, enUF_IBGE.PR, enUF_IBGE.RS, enUF_IBGE.SP
                            SefazEstado = strUF

                        Case enUF_IBGE.MA
                            SefazEstado = "SVAN"

                        Case enUF_IBGE.PA, enUF_IBGE.PI, enUF_IBGE.ES, enUF_IBGE.AC, enUF_IBGE.RN, enUF_IBGE.PB, enUF_IBGE.SC, enUF_IBGE.AL, enUF_IBGE.AP, enUF_IBGE.DF, enUF_IBGE.RJ, enUF_IBGE.RO, enUF_IBGE.RR, enUF_IBGE.SE, enUF_IBGE.TO

                            If TipoServicoSefaz = enTipoServicoSefaz.NfeConsultaCadastro Then
                                If UF_IBGE = enUF_IBGE.AC Or UF_IBGE = enUF_IBGE.RN Or UF_IBGE = enUF_IBGE.PB Or UF_IBGE = enUF_IBGE.SC Then
                                    SefazEstado = "SVRS"
                                End If
                            Else
                                SefazEstado = "SVRS"
                            End If

                        Case enUF_IBGE.AmbienteNacional
                            SefazEstado = "AN"

                        Case Else
                            Throw New Exception("Estado informado não está sendo tratado pela aplicação.")

                    End Select

                ElseIf TipoSefaz = enTipoSefaz.Cte Then

                    Select Case VersaoSefaz
                        Case enVersao.Versao1, enVersao.Versao2, enVersao.Versao3
                        Case Else
                            Throw New Exception("Versão Sefaz informada não está sendo tratado pela aplicação.")

                    End Select

                    Select Case UF_IBGE
                        Case enUF_IBGE.MT, enUF_IBGE.MS, enUF_IBGE.MG, enUF_IBGE.PR, enUF_IBGE.RS, enUF_IBGE.SP
                            SefazEstado = strUF

                        Case enUF_IBGE.AP, enUF_IBGE.PE, enUF_IBGE.RR
                            SefazEstado = "SVSP"

                        Case enUF_IBGE.AC, enUF_IBGE.AL, enUF_IBGE.AM, enUF_IBGE.BA, enUF_IBGE.CE, enUF_IBGE.DF, enUF_IBGE.ES, enUF_IBGE.GO, enUF_IBGE.MA, enUF_IBGE.PA, enUF_IBGE.PB, enUF_IBGE.PI, enUF_IBGE.RJ, enUF_IBGE.RN, enUF_IBGE.RO, enUF_IBGE.SC, enUF_IBGE.SE, enUF_IBGE.TO
                            SefazEstado = "SVRS"

                        Case enUF_IBGE.AmbienteNacional
                            SefazEstado = "AN"

                        Case Else
                            Throw New Exception("Estado informado não está sendo tratado pela aplicação.")

                    End Select

                Else
                    Throw New Exception("Tipo de arquivo não tratado pela aplicação.")

                End If

                ' Deve estar na mesma pasta do sistema

                Dim nodeSefaz As XmlNode = Nothing

                nodeSefaz = XmlDocument.SelectSingleNode("WebServicesSefaz/" & TipoSefaz.ToString() & "/" & VersaoSefaz.ToString() & "/" & SefazEstado & "/" & AmbienteSefaz.ToString())

                If IsNothing(nodeSefaz) Then
                    Throw New Exception("Estado informado não está com os endereços de WebService cadastrado.")
                End If

                Select Case TipoServicoSefaz

                    Case enTipoServicoSefaz.NfeCancelamento
                        Return nodeSefaz("NfeCancelamento").InnerText

                    Case enTipoServicoSefaz.NfeConsulta
                        Return nodeSefaz("NfeConsulta").InnerText

                    Case enTipoServicoSefaz.NfeInutilizacao
                        Return nodeSefaz("NfeInutilizacao").InnerText

                    Case enTipoServicoSefaz.NfeRecepcao
                        Return nodeSefaz("NfeRecepcao").InnerText

                    Case enTipoServicoSefaz.NfeRetRecepcao
                        Return nodeSefaz("NfeRetRecepcao").InnerText

                    Case enTipoServicoSefaz.NfeStatusServico
                        Return nodeSefaz("NfeStatusServico").InnerText

                    Case enTipoServicoSefaz.NfeConsultaCadastro
                        Return nodeSefaz("CadConsultaCadastro").InnerText

                    Case enTipoServicoSefaz.NfeConsultaDest
                        Return nodeSefaz("NfeConsultaDest").InnerText

                    Case enTipoServicoSefaz.NfeRecepcaoEvento
                        Return nodeSefaz("RecepcaoEvento").InnerText

                    Case enTipoServicoSefaz.NfeDownloadNF
                        Return nodeSefaz("NfeDownloadNF").InnerText

                    Case enTipoServicoSefaz.NFeAutorizacao
                        Return nodeSefaz("NFeAutorizacao").InnerText

                    Case enTipoServicoSefaz.NFeRetAutorizacao
                        Return nodeSefaz("NFeRetAutorizacao").InnerText

                    Case enTipoServicoSefaz.CteRecepcao
                        Return nodeSefaz("CteRecepcao").InnerText

                    Case enTipoServicoSefaz.CteRetRecepcao
                        Return nodeSefaz("CteRetRecepcao").InnerText

                    Case enTipoServicoSefaz.CteCancelamento
                        Return nodeSefaz("CteCancelamento").InnerText

                    Case enTipoServicoSefaz.CteInutilizacao
                        Return nodeSefaz("CteInutilizacao").InnerText

                    Case enTipoServicoSefaz.CteConsultaProtocolo
                        Return nodeSefaz("CteConsultaProtocolo").InnerText

                    Case enTipoServicoSefaz.CteStatusServico
                        Return nodeSefaz("CteStatusServico").InnerText

                    Case enTipoServicoSefaz.CteRecepcaoEvento
                        Return nodeSefaz("RecepcaoEvento").InnerText

                    Case enTipoServicoSefaz.CteConsultaCadastro
                        Return nodeSefaz("CteConsultaCadastro").InnerText

                    Case enTipoServicoSefaz.CTeDistribuicaoDFe
                        Return nodeSefaz("CTeDistribuicaoDFe").InnerText

                    Case Else
                        Return ""

                End Select

            Catch ex As Exception
                Throw ex

            End Try

        End Function

#End Region

    End Class

End Namespace
