Imports System.IO
Imports DSC.NFe.MD

Public Class frmMDConfiguracoes

    Private LocalMDConfiguration As MDConfigurationModel

    Public Sub New()

        Try

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            LocalMDConfiguration = MDConfigurationController.GetMDConfiguration

            rbGravaLogAT.Checked = (LocalMDConfiguration.LogFolder <> "")
            lblPastaLog.Text = LocalMDConfiguration.LogFolder

        Catch ex As Global.DSC.EmailProtocol.DSCMailException
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            If IsNothing(LocalMDConfiguration) Then
                Me.Close()
                Me.Dispose()
            End If

            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If rbGravaLogAT.Checked And lblPastaLog.Text = "" Then
            MessageBox.Show("Pasta para gravar Log não foi selecionada.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            LocalMDConfiguration.LogFolder = lblPastaLog.Text

            MDConfigurationController.SetMDConfiguration(LocalMDConfiguration)

            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub rbGravaLogEV_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbGravaLogEV.CheckedChanged
        lblPastaLog.Text = ""
        btnSelecionaPastaLog.Enabled = False
    End Sub

    Private Sub rbGravaLogAT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbGravaLogAT.CheckedChanged
        btnSelecionaPastaLog.Enabled = True
    End Sub

    Private Sub btnSelecionaPastaLog_Click(sender As System.Object, e As System.EventArgs) Handles btnSelecionaPastaLog.Click

        FolderBrowserDialog.Description = "Selecione a pasta para gravar Arquivo de Log"

        If IO.File.Exists(lblPastaLog.Text) Then
            FolderBrowserDialog.RootFolder = lblPastaLog.Text
        Else
            FolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer
        End If

        FolderBrowserDialog.ShowNewFolderButton = True

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblPastaLog.Text = FolderBrowserDialog.SelectedPath
        End If

    End Sub

End Class