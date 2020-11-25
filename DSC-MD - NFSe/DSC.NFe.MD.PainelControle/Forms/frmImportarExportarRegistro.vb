Imports Microsoft.Win32

Public Class frmImportarExportarRegistro

    Private Sub btnPastaExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnPastaExportar.Click

        FolderBrowserDialogExportar.Description = "Selecione pasta de destino"

        If IO.File.Exists(lblPastaExportar.Text) Then
            FolderBrowserDialogExportar.RootFolder = lblPastaExportar.Text
        Else
            FolderBrowserDialogExportar.RootFolder = Environment.SpecialFolder.MyComputer
        End If

        FolderBrowserDialogExportar.ShowNewFolderButton = True

        If FolderBrowserDialogExportar.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblPastaExportar.Text = FolderBrowserDialogExportar.SelectedPath & "\DSC-Backup-MD.reg"
        End If

    End Sub

    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click

        Try

            If String.IsNullOrEmpty(lblPastaExportar.Text) Then Exit Sub

            If Not ChecaExisteChaveMD() Then
                MessageBox.Show("Não existe configuração para ser exportado!", "DSC-MD - Importar/Exportar Configurações", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim p As Process = New Process
            Dim ps As ProcessStartInfo = New ProcessStartInfo
            ps.FileName = "regedit.exe"
            ps.Arguments = "/e " & lblPastaExportar.Text & " " & """HKEY_CURRENT_USER\Software\DSC\"""
            p.StartInfo = ps
            p.Start()

            MessageBox.Show("Configurações exportadas com sucesso!", "DSC-MD - Importar/Exportar Configurações", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erro ao exportar arquivo.", "DSC-MD - Importar/Exportar Configurações", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EventLogDSC.WriteEntry(String.Format("frmImportarExportarRegistro / btnExportar / {0} - {1}", ex.Message, ex.InnerException))

        End Try

    End Sub

    Private Sub btnPastaImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnPastaImportar.Click
        Dim r = OpenFileDialogImportar.ShowDialog()
        If r = Windows.Forms.DialogResult.OK Then lblPastaImportar.Text = OpenFileDialogImportar.FileName
    End Sub

    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click

        Try

            If String.IsNullOrEmpty(lblPastaImportar.Text) Then Exit Sub

            If ChecaExisteChaveMD() Then
                Dim resp = MessageBox.Show("Configurações já registrada para este computador. Deseja sobrescrever as configurações atuais?", "DSC-MD - Importar/Exportar Configurações", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If resp = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            Dim p As Process = New Process
            Dim ps As ProcessStartInfo = New ProcessStartInfo
            ps.FileName = "regedit.exe"
            ps.Arguments = "/S " & lblPastaImportar.Text
            p.StartInfo = ps
            p.Start()

            MessageBox.Show("Configurações importadas com sucesso!", "DSC-MD - Importar/Exportar Configurações", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erro ao importar o arquivo.", "DSC-MD - Importar/Exportar Configurações")
            EventLogDSC.WriteEntry(String.Format("frmImportarExportarRegistro / btnImportar / {0} - {1}", ex.Message, ex.InnerException))

        End Try

    End Sub

    Private Sub frmImportarExportarRegistro_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try

            If Not System.Diagnostics.EventLog.SourceExists("PainelControle") Then
                System.Diagnostics.EventLog.CreateEventSource("PainelControle", "EventLog DSC-MD")
            End If

            EventLogDSC.Source = "PainelControle"
            EventLogDSC.Log = "EventLog DSC-MD"

        Catch ex As Exception
            'O erro ocorre quando o registro não possuí um CNPJ cadastrado, o que é normal após a instalação 

        End Try

    End Sub

    Private Function ChecaExisteChaveMD() As Boolean

        Dim existeChave As Boolean = False

        Try
            Dim r As RegistryKey = Registry.CurrentUser
            r = r.OpenSubKey("Software\\DSC\\MD")
            Dim v As String = CStr(r.GetValue("RootFolder"))

            If Not v Is Nothing OrElse String.IsNullOrEmpty(v) Then existeChave = True

        Catch ex As Exception
            existeChave = False

        End Try

        Return existeChave

    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class