Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class MDConfigurationController

    Public Shared Function GetMDConfiguration() As MDConfigurationModel

        Try

Reinicio:
            Dim RegistryKey As RegistryKey = Registry.CurrentUser
            Dim RegistryKeyMD As RegistryKey = RegistryKey.OpenSubKey(CP_RegistryPrincipalKey, False)

            If IsNothing(RegistryKeyMD) Then
                Dim ClientController As New ClientController()
                GoTo Reinicio
            End If

            Dim MDConfiguration As New MDConfigurationModel

            MDConfiguration.LogFolder = RegistryKeyMD.GetValue("LogFolder")

            RegistryKeyMD.Close()

            Return MDConfiguration

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try



    End Function

    Public Shared Sub SetMDConfiguration(ByVal MDConfiguration As MDConfigurationModel)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do MD

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_RegistryPrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            RegistryKeyMD.SetValue("LogFolder", MDConfiguration.LogFolder)

            RegistryMD.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
