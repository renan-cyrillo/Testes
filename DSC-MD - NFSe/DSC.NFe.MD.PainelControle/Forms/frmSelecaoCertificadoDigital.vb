Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates

Public Class frmSelecaoCertificadoDigital

    Private LocalDigitalCertificate As DigitalCertificateModel
    Private LocalClientKey As String

    Public Sub New(ByVal clientKey As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LocalClientKey = clientKey

        LocalDigitalCertificate = DigitalCertificateController.GetDigitalCertificate(clientKey)

        lblFriendlyName.Text = LocalDigitalCertificate.FriendlyName
        lblIssuedTo.Text = LocalDigitalCertificate.IssuedTo
        lblIssuerName.Text = LocalDigitalCertificate.IssuerName
        lblSerialNumber.Text = LocalDigitalCertificate.SerialNumber
        lblSimpleName.Text = LocalDigitalCertificate.SimpleName
        lblValidateFrom.Text = LocalDigitalCertificate.ValidateFrom
        lblValidateTo.Text = LocalDigitalCertificate.ValidateTo
        nudDiasAviso.Value = LocalDigitalCertificate.DaysToExpirationCertificate
        txtEmail.Text = LocalDigitalCertificate.WarningEmail

        AcertaTamanhoTela()

    End Sub

    Private Sub btnSelecionaCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionaCertificado.Click
        SelecionaCertificado()
    End Sub

    Private Sub btnMostraCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostraCertificado.Click
        MostraCertificado()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If nudDiasAviso.Value > 0 Then

            Dim elist() As String = txtEmail.Text.Split(",")

            For Each em As String In elist
                If Not IsEmailAddressValid(em.Trim) Then
                    MessageBox.Show("E-mail informado não é um e-mail válido", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmail.Focus()
                    Exit Sub
                End If
            Next

        End If

        Try
            LocalDigitalCertificate.ClientKey = LocalClientKey
            LocalDigitalCertificate.FriendlyName = lblFriendlyName.Text
            LocalDigitalCertificate.IssuedTo = lblIssuedTo.Text
            LocalDigitalCertificate.IssuerName = lblIssuerName.Text
            LocalDigitalCertificate.SerialNumber = lblSerialNumber.Text
            LocalDigitalCertificate.SimpleName = lblSimpleName.Text
            LocalDigitalCertificate.ValidateFrom = lblValidateFrom.Text
            LocalDigitalCertificate.ValidateTo = lblValidateTo.Text
            LocalDigitalCertificate.DaysToExpirationCertificate = nudDiasAviso.Value
            LocalDigitalCertificate.WarningEmail = txtEmail.Text

            DigitalCertificateController.SetDigitalCertificate(LocalDigitalCertificate)

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

    Private Sub SelecionaCertificado()

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim store As New X509Store(StoreName.My)
        store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Dim fcollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindByTimeValid, DateTime.Now, False), X509Certificate2Collection)
        Dim scollection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(fcollection, "Teste de Certificado", "Selecione o certificado para acesso ao Sefaz na lista abaixo", X509SelectionFlag.SingleSelection)

        Dim x509 As X509Certificate2

        For Each x509 In scollection
            Try

                Dim rawdata As Byte() = x509.RawData
                Dim Subject As String = ""

                If x509.Subject.Trim <> "" Then
                    If x509.Subject.IndexOf(",") > 0 Then
                        Subject = x509.Subject.Substring(x509.Subject.IndexOf("CN=") + 3, x509.Subject.IndexOf(",") - 3)
                    Else
                        Subject = x509.Subject.Substring(x509.Subject.IndexOf("CN=") + 3)
                    End If
                End If

                lblFriendlyName.Text = IIf(x509.FriendlyName.Trim = "", Subject, x509.FriendlyName.Trim)
                lblSerialNumber.Text = x509.SerialNumber
                lblIssuerName.Text = x509.IssuerName.Name
                lblIssuedTo.Text = IIf(Subject = "", x509.FriendlyName.Trim, Subject)
                lblSimpleName.Text = x509.GetNameInfo(X509NameType.SimpleName, True)
                lblValidateFrom.Text = x509.NotBefore.ToShortDateString
                lblValidateTo.Text = x509.NotAfter.ToShortDateString

                AcertaTamanhoTela()

                x509.Reset()

            Catch ex As Exception
                MessageBox.Show("A informação não pode ser escrita para este certificado.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Next x509

        store.Close()

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub MostraCertificado()

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim store As New X509Store(StoreName.My)
        store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Dim fcollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindBySerialNumber, lblSerialNumber.Text, False), X509Certificate2Collection)

        Dim x509 As X509Certificate2

        For Each x509 In fcollection
            Try
                X509Certificate2UI.DisplayCertificate(x509)
                x509.Reset()

            Catch ex As Exception
                MessageBox.Show("A informação não pode ser escrita para este certificado.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Next x509

        store.Close()

        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub AcertaTamanhoTela()
        If lblFriendlyName.Text.Trim <> "" Then
            gbValidade.Visible = True
            Me.Size = New Size(675, 390)
        End If
    End Sub

End Class