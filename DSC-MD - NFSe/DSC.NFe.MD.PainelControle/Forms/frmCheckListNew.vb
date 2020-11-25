Public Class frmCheckListNew
    Private last As uctlItemCheckList

    Private Sub newStep(Message As String)
        Dim u As New uctlItemCheckList
        u.Width = FlowLayoutPanel1.Width - 40
        u.text = Message
        u.Margin = New Padding(0, 0, 0, 3)
        FlowLayoutPanel1.Controls.Add(u)
        last = u
        Application.DoEvents()
        FlowLayoutPanel1.VerticalScroll.Value = FlowLayoutPanel1.VerticalScroll.Maximum
    End Sub

    Private Sub newTitle(Title As String)
        Dim u As New uctlItemCheckList
        u.Label1.Font = New Font(u.Font.Name, u.Font.SizeInPoints, FontStyle.Bold)
        u.BackColor = Color.FromArgb(230, 230, 230)
        u.Width = FlowLayoutPanel1.Width - 40
        u.text = Title
        u.Margin = New Padding(0, 0, 0, 3)
        FlowLayoutPanel1.Controls.Add(u)
        last = u
        Application.DoEvents()
        FlowLayoutPanel1.VerticalScroll.Value = FlowLayoutPanel1.VerticalScroll.Maximum
    End Sub

    Private Sub setStatus(enumStatus As uctlItemCheckList.enumStatus, Optional message As String = "")
        last.ex = New Exception(message)
        last.status = enumStatus
        Application.DoEvents()
    End Sub

    
    Dim _itemCounter As Integer = 0
    Private Property itemCounter As Integer
        Get
            Return _itemCounter
        End Get
        Set(value As Integer)
            _itemCounter = value
            If value > ProgressBar1.Maximum Then
                value = ProgressBar1.Maximum
            End If
            ProgressBar1.Value = value
            If value = ProgressBar1.Maximum Then
                lblProgresso.Text = "Concluido"
            Else
                lblProgresso.Text = Format((_itemCounter / ProgressBar1.Maximum) * 100, "0") & "% Concluido"
            End If

        End Set
    End Property

    Private Sub wait()
        For i = 1 To 10
            System.Threading.Thread.Sleep(50)
            Application.DoEvents()
        Next
    End Sub

    Private Sub btnInicia_Click(sender As System.Object, e As System.EventArgs) Handles btnInicia.Click

        Cursor.Current = Cursors.WaitCursor

        FlowLayoutPanel1.Controls.Clear()

        Dim systemFoldersToCheck As New List(Of String)

        Dim CertificatesToCheck As New List(Of String)

        Dim RegistryEntries As List(Of PainelControleController) =
            ClientController.GetMDRegistry()

        Dim cnt As Integer = RegistryEntries.Count

        ProgressBar1.Maximum = cnt

        itemCounter = 0

        For Each item In RegistryEntries

            newTitle(item.Client.ClientName & ": " & item.Client.ClientKey)

            CertificatesToCheck.Add(item.Client.ClientKey)

            Try
                newStep("Verificando certificado digital.")
                TestaCertificadoDigital(item.Client.ClientKey)
                setStatus(uctlItemCheckList.enumStatus.ok)
            Catch ex As Exception
                setStatus(uctlItemCheckList.enumStatus.erro, ex.Message)
            End Try

            itemCounter += 1
            ProgressBar1.Value = itemCounter

        Next

        newTitle("")
        ProgressBar1.Value = ProgressBar1.Maximum

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub TestaCertificadoDigital(ByVal LocalClientKey As String)

        Dim LocalDigitalCertificate As DigitalCertificateModel

        LocalDigitalCertificate = DigitalCertificateController.GetDigitalCertificate(LocalClientKey)

        Try
            If LocalDigitalCertificate.FriendlyName Is Nothing Then
                Throw New Exception("Certificado não instalado.")
            End If

            LocalDigitalCertificate.ClientKey = LocalClientKey
            DigitalCertificateController.SetDigitalCertificate(LocalDigitalCertificate)

            Dim v() As String = LocalDigitalCertificate.ValidateTo.Trim.Replace(" ", "").Split("/")

            Dim dataExpiracao As New Date(v(2), v(1), v(0))

            If dataExpiracao < Today Then
                Throw New Exception("Certificado expirado.")
            End If

        Catch ex As Exception
            Throw ex

        Finally
            LocalDigitalCertificate = Nothing

        End Try

    End Sub
End Class