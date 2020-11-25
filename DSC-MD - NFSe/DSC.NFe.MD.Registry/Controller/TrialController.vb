Imports System.Security
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO

Public Class TrialController

    Private Const KEY_REGISTRY_TRIAL As String = "SOFTWARE\Microsoft\NoDelete\"
    Private Const KEY_TRIAL As String = "DSC.MD.Trial"

    Public Shared Function GetTrial() As TrialModel

        Dim Trial As New TrialModel
        Dim TrialPath As String

        TrialPath = Path.Combine(KEY_REGISTRY_TRIAL)

        Try

            Dim RegistryKey As RegistryKey = Registry.CurrentUser

Recarrega:

            Dim RegistryKeyTrial As RegistryKey = RegistryKey.OpenSubKey(TrialPath, False)

            If IsNothing(RegistryKeyTrial) Then
                SetTrial()
                GoTo Recarrega
            Else
                If IsNothing(RegistryKeyTrial.GetValue("dMsDc")) Then
                    SetTrial()
                    GoTo Recarrega
                End If
            End If

            Trial.dMsDc = DSC.Cryptography.Cryptography.Decifrar(RegistryKeyTrial.GetValue("dMsDc"), KEY_TRIAL)

            If Not IsDate(Trial.dMsDc) Then
                Throw New Exception("Versão Trial foi danificada. Entre em contato com o suporte.")
            End If

            RegistryKeyTrial.Close()

            Return Trial

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub SetTrial()

        Try

            Dim RegistryTrial As RegistryKey = Registry.CurrentUser

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityTrial As New RegistrySecurity()

            ' Adiciona regras de segurança para o usuário logado

            AddAccessRuleSecurity(RegistrySecurityTrial)

            ' Cria a chave principal

            Dim dt As DateTime = DateTime.Now
            Dim cultInfo As New System.Globalization.CultureInfo("pt-BR")

            Dim RegistryKeyTrial As RegistryKey = RegistryTrial.CreateSubKey(KEY_REGISTRY_TRIAL, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityTrial)

            RegistryKeyTrial.SetValue("dMsDc", DSC.Cryptography.Cryptography.Cifrar(dt.ToString("d", cultInfo), KEY_TRIAL))

            RegistryKeyTrial.Close()

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
