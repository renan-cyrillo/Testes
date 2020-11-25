Public Class frmAuthentication

    Property mensagem As String
        Get
            Return lblMensagem.Text
        End Get
        Set(value As String)
            lblMensagem.Text = "Ocorreu um erro ao tentar agendar as tarefas de execução do MD."
        End Set
    End Property

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnRetry.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnIgnore.Click
        Me.DialogResult = Windows.Forms.DialogResult.Ignore
    End Sub
End Class