Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class ClientController

    Private Const CP_Registry_PrincipalKey As String = "SOFTWARE\DSC\MD\"
    Private localClient As ClientModel

    Public Sub New(ByVal Client As ClientModel)

        Try
            localClient = Client
            CriaEstruturaRegistryMD()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Sub New()

        Try
            CriaEstruturaBaiscaRegistryMD()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CriaEstruturaBaiscaRegistryMD()

        ' Cria estrutura para o MD

        Try
            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do MD

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_Registry_PrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            If IsNothing(RegistryKeyMD) Then
                RegistryKeyMD.SetValue("LogFolder", "")
            End If

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CriaEstruturaRegistryMD()

        ' Cria estrutura para o MD 

        Try
            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do MD

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_Registry_PrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            ' Cria uma chave para cada CNPJ do Cliente (CNPJ)

            Dim RegistryKeyClientKey As RegistryKey = RegistryKeyMD.CreateSubKey(localClient.ClientKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            RegistryKeyClientKey.SetValue("ClientName", localClient.ClientName)
            RegistryKeyClientKey.SetValue("ClientUF", localClient.ClientUF)

            If RegistryKeyClientKey.SubKeyCount = 0 Then

                ' Cria entradas para o Certificado Digital

                Dim RegistryKeyDigitalCertificate As RegistryKey = RegistryKeyClientKey.CreateSubKey("DigitalCertificate", RegistryKeyPermissionCheck.ReadWriteSubTree)

                RegistryKeyDigitalCertificate.SetValue("FriendlyName", "")
                RegistryKeyDigitalCertificate.SetValue("SerialNumber", "")
                RegistryKeyDigitalCertificate.SetValue("IssuerName", "")
                RegistryKeyDigitalCertificate.SetValue("ValidateFrom", "")
                RegistryKeyDigitalCertificate.SetValue("ValidateTo", "")
                RegistryKeyDigitalCertificate.SetValue("SimpleName", "")
                RegistryKeyDigitalCertificate.SetValue("DaysToExpirationCertificate", "")
                RegistryKeyDigitalCertificate.SetValue("WarningEmail", "")

                ' Cria entradas para as configurações do progress

                Dim RegistryKeyProgressConfiguration As RegistryKey = RegistryKeyClientKey.CreateSubKey("ProgressConfiguration", RegistryKeyPermissionCheck.ReadWriteSubTree)

                RegistryKeyProgressConfiguration.SetValue("IP", "")
                RegistryKeyProgressConfiguration.SetValue("PortNumber", 0)
                RegistryKeyProgressConfiguration.SetValue("AppServer", "")
                RegistryKeyProgressConfiguration.SetValue("UserID", "")
                RegistryKeyProgressConfiguration.SetValue("Password", "")

                ' Cria entradas para as configurações SMTP

                Dim RegistryKeySMTPConfiguration As RegistryKey = RegistryKeyClientKey.CreateSubKey("SMTPConfiguration", RegistryKeyPermissionCheck.ReadWriteSubTree)

                RegistryKeySMTPConfiguration.SetValue("HostName", "")
                RegistryKeySMTPConfiguration.SetValue("PortNumber", 25)
                RegistryKeySMTPConfiguration.SetValue("User", "")
                RegistryKeySMTPConfiguration.SetValue("Password", "")

                ' Cria entradas para as configurações Padrão

                Dim RegistryKeyDefaultConfiguration As RegistryKey = RegistryKeyClientKey.CreateSubKey("DefaultConfiguration", RegistryKeyPermissionCheck.ReadWriteSubTree)

                RegistryKeyDefaultConfiguration.SetValue("EmailXmlNFe", "")
                RegistryKeyDefaultConfiguration.SetValue("NSU", "0")
                RegistryKeyDefaultConfiguration.SetValue("NsuCte", "0")

                RegistryKeyClientKey.Close()
                RegistryKeyMD.Close()

            End If

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Shared Sub SetMDRegistry(ByVal client As ClientModel)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do MD

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(Path.Combine(CP_RegistryPrincipalKey, client.ClientKey), RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            RegistryKeyMD.SetValue("ClientName", client.ClientName)
            RegistryKeyMD.SetValue("ClientUF", client.ClientUF)

            RegistryMD.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Shared Function GetMDRegistry() As List(Of PainelControleController)

        Dim ListPainelControleRA As New List(Of PainelControleController)

        Dim RegistryDigitalCertificateKey As String
        Dim RegistryProgressConfigurationKey As String
        Dim RegistrySMTPConfigurationKey As String
        Dim RegistryDefaultConfigurationKey As String

        Try
            Dim PainelControleMD As PainelControleController

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            Dim RegistryKeyMD As RegistryKey = RegistryMD.OpenSubKey(CP_Registry_PrincipalKey)
            Dim RegistryCNPJ As RegistryKey

            Dim RegistryDigitalCertificate As RegistryKey
            Dim RegistryProgressConfiguration As RegistryKey
            Dim RegistrySMTPConfiguration As RegistryKey
            Dim RegistryDefaultConfiguration As RegistryKey

            For item As Integer = 0 To RegistryKeyMD.SubKeyCount - 1

                RegistryCNPJ = RegistryKeyMD.OpenSubKey(RegistryKeyMD.GetSubKeyNames(item))

                PainelControleMD = New PainelControleController

                PainelControleMD.MDConfiguration.LogFolder = RegistryKeyMD.GetValue("LogFolder")

                PainelControleMD.Client.ClientKey = RegistryCNPJ.Name.Replace(CP_Registry_PrincipalKey, "").Replace(Registry.CurrentUser.Name, "").Replace("\", "")
                PainelControleMD.Client.ClientName = RegistryCNPJ.GetValue("ClientName")
                PainelControleMD.Client.ClientUF = RegistryCNPJ.GetValue("ClientUF")

                RegistryDigitalCertificateKey = Path.Combine(CP_Registry_PrincipalKey, PainelControleMD.Client.ClientKey & "\DigitalCertificate\")
                RegistryProgressConfigurationKey = Path.Combine(CP_Registry_PrincipalKey, PainelControleMD.Client.ClientKey & "\ProgressConfiguration\")
                RegistrySMTPConfigurationKey = Path.Combine(CP_Registry_PrincipalKey, PainelControleMD.Client.ClientKey & "\SMTPConfiguration\")
                RegistryDefaultConfigurationKey = Path.Combine(CP_Registry_PrincipalKey, PainelControleMD.Client.ClientKey & "\DefaultConfiguration\")

                ' Certificado Digital

                RegistryDigitalCertificate = RegistryMD.OpenSubKey(RegistryDigitalCertificateKey)

                PainelControleMD.DigitalCertificate.ClientKey = PainelControleMD.Client.ClientKey
                PainelControleMD.DigitalCertificate.ClientName = PainelControleMD.Client.ClientName
                PainelControleMD.DigitalCertificate.ClientUF = PainelControleMD.Client.ClientUF
                PainelControleMD.DigitalCertificate.FriendlyName = RegistryDigitalCertificate.GetValue("FriendlyName")
                PainelControleMD.DigitalCertificate.IssuedTo = RegistryDigitalCertificate.GetValue("IssuedTo")
                PainelControleMD.DigitalCertificate.IssuerName = RegistryDigitalCertificate.GetValue("IssuerName")
                PainelControleMD.DigitalCertificate.SerialNumber = RegistryDigitalCertificate.GetValue("SerialNumber")
                PainelControleMD.DigitalCertificate.SimpleName = RegistryDigitalCertificate.GetValue("SimpleName")
                PainelControleMD.DigitalCertificate.ValidateFrom = RegistryDigitalCertificate.GetValue("ValidateFrom")
                PainelControleMD.DigitalCertificate.ValidateTo = RegistryDigitalCertificate.GetValue("ValidateTo")
                PainelControleMD.DigitalCertificate.DaysToExpirationCertificate = Val(RegistryDigitalCertificate.GetValue("DaysToExpirationCertificate"))
                PainelControleMD.DigitalCertificate.WarningEmail = RegistryDigitalCertificate.GetValue("WarningEmail")

                ' Configuração do Progress

                RegistryProgressConfiguration = RegistryMD.OpenSubKey(RegistryProgressConfigurationKey)

                PainelControleMD.ProgressConfiguration.ClientKey = PainelControleMD.Client.ClientKey
                PainelControleMD.ProgressConfiguration.ClientName = PainelControleMD.Client.ClientName
                PainelControleMD.ProgressConfiguration.ClientUF = PainelControleMD.Client.ClientUF
                PainelControleMD.ProgressConfiguration.IP = RegistryProgressConfiguration.GetValue("IP")
                PainelControleMD.ProgressConfiguration.PortNumber = Val(RegistryProgressConfiguration.GetValue("PortNumber"))
                PainelControleMD.ProgressConfiguration.AppServer = RegistryProgressConfiguration.GetValue("AppServer")

                ' Configuração do SMTP

                RegistrySMTPConfiguration = RegistryMD.OpenSubKey(RegistrySMTPConfigurationKey)

                PainelControleMD.SMTPConfiguration.ClientKey = PainelControleMD.Client.ClientKey
                PainelControleMD.SMTPConfiguration.ClientName = PainelControleMD.Client.ClientName
                PainelControleMD.SMTPConfiguration.ClientUF = PainelControleMD.Client.ClientUF
                PainelControleMD.SMTPConfiguration.HostName = RegistrySMTPConfiguration.GetValue("HostName")
                PainelControleMD.SMTPConfiguration.PortNumber = Val(RegistrySMTPConfiguration.GetValue("PortNumber"))
                PainelControleMD.SMTPConfiguration.User = RegistrySMTPConfiguration.GetValue("User")
                PainelControleMD.SMTPConfiguration.Password = RegistrySMTPConfiguration.GetValue("Password")

                ' Configurações Padrão

                RegistryDefaultConfiguration = RegistryMD.OpenSubKey(RegistryDefaultConfigurationKey)

                PainelControleMD.DefaultConfiguration.ClientKey = PainelControleMD.Client.ClientKey
                PainelControleMD.DefaultConfiguration.ClientName = PainelControleMD.Client.ClientName
                PainelControleMD.DefaultConfiguration.ClientUF = PainelControleMD.Client.ClientUF
                PainelControleMD.DefaultConfiguration.EmailXmlNFe = RegistryDefaultConfiguration.GetValue("EmailXmlNFe")
                PainelControleMD.DefaultConfiguration.NSU = RegistryDefaultConfiguration.GetValue("NSU")
                PainelControleMD.DefaultConfiguration.NsuCte = RegistryDefaultConfiguration.GetValue("NsuCte")

                ' Adiciona na lista

                ListPainelControleRA.Add(PainelControleMD)

            Next

            Return ListPainelControleRA

        Catch ex As Exception

        End Try

        Return ListPainelControleRA

    End Function

    Public Shared Sub DeleteClientKey(ByVal ClientKey As String)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Apaga a chave principal do RA

            Dim ClientKeyPath As String

            ClientKeyPath = Path.Combine(CP_Registry_PrincipalKey, ClientKey)

            RegistryMD.DeleteSubKeyTree(ClientKeyPath, False)

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
