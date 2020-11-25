Imports System.Security.Cryptography.X509Certificates

Public Class frmInstalaCertificado

    Private FileName As String = ""

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try

            If FileName.Trim = "" Then
                MessageBox.Show("Certificado não foi selecionado.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim cert As New X509Certificate2(FileName, txtSenhaCertificado.Text, X509KeyStorageFlags.MachineKeySet Or X509KeyStorageFlags.PersistKeySet)

            If Not IsNothing(cert) Then
                Dim store1 As New X509Store(StoreName.My)
                store1.Open(OpenFlags.ReadWrite)

                If Not store1.Certificates.Contains(cert) Then
                    store1.Add(cert)
                    MessageBox.Show("Certificado instalado com sucesso", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Certificado já está instalado", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnAbreCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbreCertificado.Click
        If OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            FileName = OpenFileDialog.FileName
            lblArquivoCertificado.Text = OpenFileDialog.SafeFileName
        End If
    End Sub

End Class