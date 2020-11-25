Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class ProgressConfigurationController

    Public Shared Function GetProgressConfiguration(ByVal clientKey As String) As ProgressConfigurationModel

        Dim ProgressConfiguration As New ProgressConfigurationModel
        Dim ProgressConfigurationPath As String

        ProgressConfigurationPath = Path.Combine(CP_RegistryPrincipalKey, clientKey, CP_RegistryProgressConfigurationKey)

        Try

            Dim RegistryKey As RegistryKey = Registry.CurrentUser
            Dim RegistryKeyMD As RegistryKey = RegistryKey.OpenSubKey(ProgressConfigurationPath, False)

            ProgressConfiguration.IP = RegistryKeyMD.GetValue("IP")
            ProgressConfiguration.PortNumber = Val(RegistryKeyMD.GetValue("PortNumber"))
            ProgressConfiguration.AppServer = RegistryKeyMD.GetValue("AppServer")
            
            RegistryKeyMD.Close()

            Return ProgressConfiguration

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub SetProgressConfiguration(ByVal ProgressConfiguration As ProgressConfigurationModel)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do RA

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_RegistryPrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            ' Cria a chave para cada Chave do Cliente (CNPJ)

            Dim RegistryKeyClientKey As RegistryKey = RegistryKeyMD.CreateSubKey(ProgressConfiguration.ClientKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            ' Cria entradas para o Protocolo da caixa de e-mail

            Dim RegistryKeyProgressConfiguration As RegistryKey = RegistryKeyClientKey.CreateSubKey(CP_RegistryProgressConfigurationKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            RegistryKeyProgressConfiguration.SetValue("IP", ProgressConfiguration.IP)
            RegistryKeyProgressConfiguration.SetValue("PortNumber", ProgressConfiguration.PortNumber)
            RegistryKeyProgressConfiguration.SetValue("AppServer", ProgressConfiguration.AppServer)

            RegistryKeyProgressConfiguration.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
