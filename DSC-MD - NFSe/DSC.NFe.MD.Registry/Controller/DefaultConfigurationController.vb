Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class DefaultConfigurationController

    Public Shared Function GetDefaultConfiguration(ByVal clientKey As String) As DefaultConfigurationModel

        Dim DefautConfiguration As New DefaultConfigurationModel
        Dim DefaultConfigurationPath As String

        DefaultConfigurationPath = Path.Combine(CP_RegistryPrincipalKey, clientKey, CP_RegistryDefaultConfigurationKey)

        Try

            Dim RegistryKey As RegistryKey = Registry.CurrentUser
            Dim RegistryKeyMD As RegistryKey = RegistryKey.OpenSubKey(DefaultConfigurationPath, False)

            DefautConfiguration.EmailXmlNFe = RegistryKeyMD.GetValue("EmailXmlNFe")
            DefautConfiguration.NSU = RegistryKeyMD.GetValue("NSU")
            DefautConfiguration.NsuCte = RegistryKeyMD.GetValue("NsuCte")

            RegistryKeyMD.Close()

            Return DefautConfiguration

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub SetDefaultConfiguration(ByVal DefaultConfiguration As DefaultConfigurationModel)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do MD

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_RegistryPrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            ' Cria a chave para cada Chave do Cliente (CNPJ)

            Dim RegistryKeyClientKey As RegistryKey = RegistryKeyMD.CreateSubKey(DefaultConfiguration.ClientKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            ' Cria entradas padrões

            Dim RegistryKeyDefaultConfiguration As RegistryKey = RegistryKeyClientKey.CreateSubKey(CP_RegistryDefaultConfigurationKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            RegistryKeyDefaultConfiguration.SetValue("EmailXmlNFe", DefaultConfiguration.EmailXmlNFe)
            RegistryKeyDefaultConfiguration.SetValue("NSU", DefaultConfiguration.NSU)
            RegistryKeyDefaultConfiguration.SetValue("NsuCte", DefaultConfiguration.NsuCte)

            RegistryKeyDefaultConfiguration.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
