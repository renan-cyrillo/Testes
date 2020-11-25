Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class EmailProtocolController

    Public Shared Function GetEmailProtocol(ByVal clientKey As String) As EmailProtocolModel

        Dim EmailProtocol As New EmailProtocolModel
        Dim EmailProtocolPath As String

        EmailProtocolPath = Path.Combine(CP_RegistryPrincipalKey, clientKey, CP_RegistryEmailProtocolKey)

        Try

            Dim RegistryKey As RegistryKey = Registry.CurrentUser
            Dim RegistryKeyRA As RegistryKey = RegistryKey.OpenSubKey(EmailProtocolPath, False)

            Dim protocol As String = RegistryKeyRA.GetValue("Protocol")

            EmailProtocol.Protocol = IIf(protocol = "IMAP", RA.EmailProtocolModel.enEmailProtocol.IMAP, RA.EmailProtocolModel.enEmailProtocol.POP)
            EmailProtocol.Server = RegistryKeyRA.GetValue("Server")
            EmailProtocol.Port = RegistryKeyRA.GetValue("Port")
            EmailProtocol.User = RegistryKeyRA.GetValue("User")
            EmailProtocol.Password = RegistryKeyRA.GetValue("Password")
            EmailProtocol.Backup = RegistryKeyRA.GetValue("Backup")
            EmailProtocol.ConnectionSecurity = RegistryKeyRA.GetValue("ConnectionSecurity")

            RegistryKeyRA.Close()

            Return EmailProtocol

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub SetEmailProtocol(ByVal EmailProtocol As EmailProtocolModel)

        Try

            Dim RegistryRA As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityRA As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityRA)

            ' Cria a chave principal do RA

            Dim RegistryKeyRA As RegistryKey = RegistryRA.CreateSubKey(CP_RegistryPrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityRA)

            ' Cria a chave para cada Chave do Cliente (CNPJ)

            Dim RegistryKeyClientKey As RegistryKey = RegistryKeyRA.CreateSubKey(EmailProtocol.ClientKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            ' Cria entradas para o Protocolo da caixa de e-mail

            Dim RegistryKeyEmailProtocol As RegistryKey = RegistryKeyClientKey.CreateSubKey(CP_RegistryEmailProtocolKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            RegistryKeyEmailProtocol.SetValue("Protocol", EmailProtocol.Protocol)
            RegistryKeyEmailProtocol.SetValue("Server", EmailProtocol.Server)
            RegistryKeyEmailProtocol.SetValue("Port", EmailProtocol.Port)
            RegistryKeyEmailProtocol.SetValue("User", EmailProtocol.User)
            RegistryKeyEmailProtocol.SetValue("Password", EmailProtocol.Password)
            RegistryKeyEmailProtocol.SetValue("Backup", EmailProtocol.Backup)
            RegistryKeyEmailProtocol.SetValue("ConnectionSecurity", EmailProtocol.ConnectionSecurity)

            RegistryKeyEmailProtocol.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
