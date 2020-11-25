Imports System.Data.Odbc

Public Class frmConfiguracaoProgress

    Private LocalProgressConfiguration As ProgressConfigurationModel
    Private LocalClientKey As String

    Public Sub New(ByVal clientKey As String)

        Try

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            LocalClientKey = clientKey

            LocalProgressConfiguration = ProgressConfigurationController.GetProgressConfiguration(clientKey)

            txtIP.Text = LocalProgressConfiguration.IP
            nudPorta.Value = IIf(LocalProgressConfiguration.PortNumber < nudPorta.Minimum, nudPorta.Minimum, LocalProgressConfiguration.PortNumber)
            txtAppServer.Text = LocalProgressConfiguration.AppServer

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            LocalProgressConfiguration.ClientKey = LocalClientKey
            LocalProgressConfiguration.IP = txtIP.Text
            LocalProgressConfiguration.PortNumber = nudPorta.Value
            LocalProgressConfiguration.AppServer = txtAppServer.Text

            ProgressConfigurationController.SetProgressConfiguration(LocalProgressConfiguration)

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

    Private Sub btnTestaConexao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestaConexao.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim XmlDataTransfer As Global.DSC.NFe.MD.Progress.XmlDataTransfer = Nothing

        Try
            XmlDataTransfer = New Global.DSC.NFe.MD.Progress.XmlDataTransfer("AppServerDC://" & _
                                                                             txtIP.Text & ":" & _
                                                                             nudPorta.Value & "/" & _
                                                                             txtAppServer.Text)

            MessageBox.Show("Teste de conexão com AppServer progress efetuado com sucesso.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            XmlDataTransfer = Nothing

        End Try

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

End Class