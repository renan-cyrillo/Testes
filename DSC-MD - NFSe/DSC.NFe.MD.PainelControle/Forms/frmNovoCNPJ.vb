Public Class frmNovoCNPJ

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If txtNomeFantasia.Text.Trim = "" Then
            txtNomeFantasia.Focus()
            MessageBox.Show("Nome Fantasia não informado", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else

            If mtxtNPJ.Text.Trim = "" Then
                mtxtNPJ.Focus()
                MessageBox.Show("CNPJ não informado", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                Dim CNPJ As New DSC.Global.CNPJ_CPF

                Try
                    CNPJ.cnpj = mtxtNPJ.Text
                Catch ex As Exception
                    MessageBox.Show("CNPJ informado não é um CNPJ válido", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                If Not CNPJ.isCnpjValido Then
                    mtxtNPJ.Focus()
                    MessageBox.Show("CNPJ inválido", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Try

                        Dim cliente As New Global.DSC.NFe.MD.ClientModel

                        cliente.ClientKey = mtxtNPJ.Text.Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "")
                        cliente.ClientName = txtNomeFantasia.Text
                        cliente.ClientUF = cboUF.SelectedValue

                        Dim reg As New Global.DSC.NFe.MD.ClientController(cliente)
                        reg = Nothing

                        txtNomeFantasia.Text = ""
                        mtxtNPJ.Text = ""

                        Me.Close()
                        Me.Dispose()

                    Catch ex As Exception
                        MessageBox.Show("Erro ao tentar criar um novo CNPJ. Verifique se usuário é administrador e tente novamente.", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                End If

            End If

            Windows.Forms.Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmNovoCNPJ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim ListOfUF As New List(Of UF)

        ListOfUF.Add(New UF("AC", 12))
        ListOfUF.Add(New UF("AL", 27))
        ListOfUF.Add(New UF("AP", 16))
        ListOfUF.Add(New UF("AM", 13))
        ListOfUF.Add(New UF("BA", 29))
        ListOfUF.Add(New UF("CE", 23))
        ListOfUF.Add(New UF("DF", 53))
        ListOfUF.Add(New UF("ES", 32))
        ListOfUF.Add(New UF("GO", 52))
        ListOfUF.Add(New UF("MA", 21))
        ListOfUF.Add(New UF("MG", 31))
        ListOfUF.Add(New UF("MS", 50))
        ListOfUF.Add(New UF("MT", 51))
        ListOfUF.Add(New UF("PA", 15))
        ListOfUF.Add(New UF("PB", 25))
        ListOfUF.Add(New UF("PE", 26))
        ListOfUF.Add(New UF("PI", 22))
        ListOfUF.Add(New UF("PR", 41))
        ListOfUF.Add(New UF("RJ", 33))
        ListOfUF.Add(New UF("RN", 24))
        ListOfUF.Add(New UF("RO", 11))
        ListOfUF.Add(New UF("RR", 14))
        ListOfUF.Add(New UF("RS", 43))
        ListOfUF.Add(New UF("SC", 42))
        ListOfUF.Add(New UF("SE", 28))
        ListOfUF.Add(New UF("SP", 35))
        ListOfUF.Add(New UF("TO", 17))

        cboUF.DataSource = ListOfUF
        cboUF.DisplayMember = "UF"
        cboUF.ValueMember = "CodUF"

    End Sub

End Class

Public Class UF

    Public Property UF As String
    Public Property CodUF As String

    Sub New(pUF As String, pCodUF As Integer)
        UF = pUF
        CodUF = pCodUF
    End Sub

End Class