Public Class uctlItemCheckList
    Enum enumStatus
        loading
        ok
        erro
    End Enum

    Private expanded As Boolean = False

    Private _status As enumStatus
    Public WriteOnly Property status As enumStatus
        Set(value As enumStatus)
            Select Case value
                Case enumStatus.ok
                    PictureBox1.Image = My.Resources.ResourceImages.done
                Case enumStatus.erro
                    PictureBox1.Image = My.Resources.ResourceImages.erro
                    Dim tt As New ToolTip
                    tt.SetToolTip(PictureBox1, ex.Message)
            End Select
            _status = value
        End Set
    End Property

    Public Overrides Property text As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
            If Label1.Height > 100 Then
                If expanded Then
                    Me.Height = Label1.Height + 15
                Else
                    Me.Height = 110
                    Label2.Visible = True
                    Label2.Top = Me.Height - Label2.Height

                    Label2.Left = Me.Width - Label2.Width
                End If
            End If
        End Set
    End Property
    Public Property isError As Boolean
    Public Property ex As Exception

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_DoubleClick(sender As Object, e As System.EventArgs) Handles Label1.DoubleClick
        expandreduce()
    End Sub
    Sub expandreduce()
        If Label1.Height > 100 Then
            If expanded Then
                reduce()
            Else
                expand()
            End If
        End If
    End Sub
    Sub expand()
        Me.Height = Label1.Height + 15
        Label2.Top = Me.Height - Label2.Height
        Label2.Text = "Compactar Resultados"
        expanded = True
    End Sub
    Sub reduce()
        Me.Height = 110
        Label2.Top = Me.Height - Label2.Height
        expanded = False
        Label2.Text = "Mostrar mais Resultados"
    End Sub



    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        expandreduce()
    End Sub

    Private Sub uctlItem_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick
        expandreduce()
    End Sub
End Class
