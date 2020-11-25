Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class SMTPConfigurationController

    Public Shared Function GetSMTPConfiguration(ByVal clientKey As String) As SMTPConfigurationModel

        Dim SMTPConfiguration As New SMTPConfigurationModel
        Dim SMTPConfigurationPath As String

        SMTPConfigurationPath = Path.Combine(CP_RegistryPrincipalKey, clientKey, CP_RegistrySMTPConfigurationKey)

        Try

            Dim RegistryKey As RegistryKey = Registry.CurrentUser
            Dim RegistryKeyMD As RegistryKey = RegistryKey.OpenSubKey(SMTPConfigurationPath, False)

            SMTPConfiguration.HostName = RegistryKeyMD.GetValue("HostName")
            SMTPConfiguration.PortNumber = Val(RegistryKeyMD.GetValue("PortNumber"))
            SMTPConfiguration.User = RegistryKeyMD.GetValue("User")
            SMTPConfiguration.Password = RegistryKeyMD.GetValue("Password")
            SMTPConfiguration.SSL = RegistryKeyMD.GetValue("SSL")

            RegistryKeyMD.Close()

            Return SMTPConfiguration

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub SetSMTPConfiguration(ByVal SMTPConfiguration As SMTPConfigurationModel)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do MD

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_RegistryPrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            ' Cria a chave para cada Chave do Cliente (CNPJ)

            Dim RegistryKeyClientKey As RegistryKey = RegistryKeyMD.CreateSubKey(SMTPConfiguration.ClientKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            ' Cria entradas para o Protocolo da caixa de e-mail

            Dim RegistryKeySMTPConfiguration As RegistryKey = RegistryKeyClientKey.CreateSubKey(CP_RegistrySMTPConfigurationKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            RegistryKeySMTPConfiguration.SetValue("HostName", SMTPConfiguration.HostName)
            RegistryKeySMTPConfiguration.SetValue("PortNumber", SMTPConfiguration.PortNumber)
            RegistryKeySMTPConfiguration.SetValue("User", SMTPConfiguration.User)
            RegistryKeySMTPConfiguration.SetValue("Password", SMTPConfiguration.Password)
            RegistryKeySMTPConfiguration.SetValue("SSL", SMTPConfiguration.SSL)

            RegistryKeySMTPConfiguration.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
