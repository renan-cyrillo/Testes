Imports System.IO
Imports DSC.NFe.MD

Public Class frmConfiguracoes

    Private LocalConfiguration As DefaultConfigurationModel
    Private LocalClientKey As String

    Public Sub New(ByVal clientKey As String)

        Try

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            LocalClientKey = clientKey

            LocalConfiguration = DefaultConfigurationController.GetDefaultConfiguration(clientKey)

            txtEmailXML.Text = LocalConfiguration.EmailXmlNFe
            lblNSU.Text = LocalConfiguration.NSU
            lblNsuCte.Text = LocalConfiguration.NsuCte
        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If txtEmailXML.Text.Trim <> "" And Not IsEmailAddressValid(txtEmailXML.Text) Then
            MessageBox.Show("Conta de e-mail inválida!", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmailXML.Focus()
            Exit Sub
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            LocalConfiguration.ClientKey = LocalClientKey
            LocalConfiguration.EmailXmlNFe = txtEmailXML.Text
            LocalConfiguration.NSU = lblNSU.Text
            LocalConfiguration.NsuCte = lblNsuCte.Text

            DefaultConfigurationController.SetDefaultConfiguration(LocalConfiguration)

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

    Private Sub btnLimpaNSU_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpaNSU.Click
        lblNSU.Text = ""
    End Sub

    Private Sub btnLimpaNsuCte_Click(sender As Object, e As EventArgs) Handles btnLimpaNsuCte.Click
        lblNsuCte.Text = ""
    End Sub
End Class