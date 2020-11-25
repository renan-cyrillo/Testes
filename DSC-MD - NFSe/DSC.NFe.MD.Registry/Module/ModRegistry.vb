Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Module ModRegistry

    Public Const CP_RegistryPrincipalKey As String = "SOFTWARE\DSC\MD\"
    Public Const CP_RegistryDigitalCertificateKey As String = "DigitalCertificate"
    Public Const CP_RegistryProgressConfigurationKey As String = "ProgressConfiguration"
    Public Const CP_RegistrySMTPConfigurationKey As String = "SMTPConfiguration"
    Public Const CP_RegistryDefaultConfigurationKey As String = "DefaultConfiguration"

    Public Sub AddAccessRuleSecurity(ByRef RegistrySecurity As RegistrySecurity)

        Try

            Dim user As String = Path.Combine(Environment.UserDomainName, Environment.UserName)

            ' Adiciona uma regra que concede ao usuário atual o direito de ler e enumerar os pares nome / valor em uma chave,
            ' Ler seu acesso e regras de auditoria, para enumerar suas subchaves, para criar subchaves, e para excluir a chave.
            ' A regra é herdada por todas as subchaves contidas.

            Dim rule As New RegistryAccessRule(user, _
                                               RegistryRights.ReadKey Or RegistryRights.WriteKey Or RegistryRights.Delete, _
                                               InheritanceFlags.ContainerInherit, _
                                               PropagationFlags.None, _
                                               AccessControlType.Allow)

            RegistrySecurity.AddAccessRule(rule)

            ' Adiciona uma regra que permite que o usuário atual do direito direito de definir os pares nome / valor em uma chave.
            ' Esta regra é herdada por subchaves contidas, mas sinalizadores de propagação limitá-lo a subchaves filho imediato.

            rule = New RegistryAccessRule(user, _
                                          RegistryRights.ChangePermissions, _
                                          InheritanceFlags.ContainerInherit, _
                                          PropagationFlags.InheritOnly Or PropagationFlags.NoPropagateInherit, _
                                          AccessControlType.Allow)

            RegistrySecurity.AddAccessRule(rule)

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Module
