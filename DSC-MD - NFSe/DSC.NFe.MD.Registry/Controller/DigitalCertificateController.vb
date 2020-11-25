Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class DigitalCertificateController

    Public Shared Function GetDigitalCertificate(ByVal clientKey As String) As DigitalCertificateModel

        Dim DigitalCertificate As New DigitalCertificateModel
        Dim DigitalCertificatePath As String

        DigitalCertificatePath = Path.Combine(CP_RegistryPrincipalKey, clientKey, CP_RegistryDigitalCertificateKey)

        Try


            Dim RegistryKey As RegistryKey = Registry.CurrentUser
            Dim RegistryKeyMD As RegistryKey = RegistryKey.OpenSubKey(DigitalCertificatePath, False)

            DigitalCertificate.FriendlyName = RegistryKeyMD.GetValue("FriendlyName")
            DigitalCertificate.IssuedTo = RegistryKeyMD.GetValue("IssuedTo")
            DigitalCertificate.IssuerName = RegistryKeyMD.GetValue("IssuerName")
            DigitalCertificate.SerialNumber = RegistryKeyMD.GetValue("SerialNumber")
            DigitalCertificate.SimpleName = RegistryKeyMD.GetValue("SimpleName")
            DigitalCertificate.ValidateFrom = RegistryKeyMD.GetValue("ValidateFrom")
            DigitalCertificate.ValidateTo = RegistryKeyMD.GetValue("ValidateTo")
            DigitalCertificate.DaysToExpirationCertificate = Val(RegistryKeyMD.GetValue("DaysToExpirationCertificate"))
            DigitalCertificate.WarningEmail = RegistryKeyMD.GetValue("WarningEmail")

            RegistryKeyMD.Close()

            Return DigitalCertificate

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub SetDigitalCertificate(ByVal DigitalCertificate As DigitalCertificateModel)

        Try

            Dim RegistryMD As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityMD As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityMD)

            ' Cria a chave principal do RA

            Dim RegistryKeyMD As RegistryKey = RegistryMD.CreateSubKey(CP_RegistryPrincipalKey, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityMD)

            ' Cria a chave para cada Chave do Cliente (CNPJ)

            Dim RegistryKeyClientKey As RegistryKey = RegistryKeyMD.CreateSubKey(DigitalCertificate.ClientKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            ' Cria entradas para o Protocolo da caixa de e-mail

            Dim RegistryKeyDigitalCertificate As RegistryKey = RegistryKeyClientKey.CreateSubKey(CP_RegistryDigitalCertificateKey, RegistryKeyPermissionCheck.ReadWriteSubTree)

            RegistryKeyDigitalCertificate.SetValue("FriendlyName", DigitalCertificate.FriendlyName)
            RegistryKeyDigitalCertificate.SetValue("IssuedTo", DigitalCertificate.IssuedTo)
            RegistryKeyDigitalCertificate.SetValue("IssuerName", DigitalCertificate.IssuerName)
            RegistryKeyDigitalCertificate.SetValue("SerialNumber", DigitalCertificate.SerialNumber)
            RegistryKeyDigitalCertificate.SetValue("SimpleName", DigitalCertificate.SimpleName)
            RegistryKeyDigitalCertificate.SetValue("ValidateFrom", DigitalCertificate.ValidateFrom)
            RegistryKeyDigitalCertificate.SetValue("ValidateTo", DigitalCertificate.ValidateTo)
            RegistryKeyDigitalCertificate.SetValue("DaysToExpirationCertificate", DigitalCertificate.DaysToExpirationCertificate)
            RegistryKeyDigitalCertificate.SetValue("WarningEmail", DigitalCertificate.WarningEmail)

            RegistryKeyDigitalCertificate.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
