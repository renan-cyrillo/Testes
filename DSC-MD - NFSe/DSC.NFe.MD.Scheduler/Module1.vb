Imports Microsoft.Win32.TaskScheduler

Module Module1

    Dim mens As String = ""

    Sub Main()

        If MsgBox("Deseja agendar automaticamente as tarefas?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim tasks(2) As task

        tasks(0) = New task("DSC.NFe.MD.AppBuscaListaDestinadas.exe", "MD_Busca_Lista_Destinadas", "Serviço do MD responsável por buscar a lista de destinadas.")
        tasks(1) = New task("DSC.NFe.MD.AppSolicitacaoEvento.exe", "MD_Solicitacao_Evento", "Serviço do MD responsável pela solicitação dos eventos.")
        tasks(2) = New task("DSC.NFe.MD.AppBaixaXmlNFe.exe", "MD_Baixa_XmlNFe", "Serviço do MD responsável baixar a NFe.")

        addTaskSchedule(tasks)

        If mens <> "" Then MsgBox(mens, MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "MD")

    End Sub

    Private Sub addTaskSchedule(tasks As task())
        Dim taskService As New TaskService
        Dim interval As Integer = 5

        Using taskService

            For Each task In tasks
                While 1

                    ' Create a new task definition and assign properties
                    Dim taskDefinition As TaskDefinition = taskService.NewTask

                    taskDefinition.RegistrationInfo.Description = task.description

                    Dim timeTrigger As New TimeTrigger

                    timeTrigger.StartBoundary = Now.AddMinutes(interval) ' Starta o serviço 2 minutos após a instalação

                    interval += 5

                    timeTrigger.EndBoundary = Date.MaxValue

                    timeTrigger.Repetition.StopAtDurationEnd = True
                    'timeTrigger.Repetition.Duration = TimeSpan.FromMinutes(5) '.MaxValue
                    timeTrigger.Repetition.Interval = TimeSpan.FromMinutes(5)

                    timeTrigger.ExecutionTimeLimit = TimeSpan.FromHours(1)

                    taskDefinition.Triggers.Add(timeTrigger)

                    Dim FolderPath As String = AppDomain.CurrentDomain.BaseDirectory

                    Dim ExeLocation As String = IO.Path.Combine(FolderPath, task.filename)
                    ExeLocation = ExeLocation.Replace("\"c, "/"c)

                    ' Add an action (shorthand) that runs Notepad
                    taskDefinition.Actions.Add(New ExecAction(ExeLocation))

                    Dim folder As Microsoft.Win32.TaskScheduler.TaskFolder

                    Try
                        folder = taskService.RootFolder.SubFolders.Item("DSC.NFe.MD")
                    Catch ex As Exception
                        folder = taskService.RootFolder.CreateFolder("DSC.NFe.MD")
                    End Try

                    taskDefinition.Principal.RunLevel = TaskRunLevel.Highest
                    taskDefinition.Principal.LogonType = TaskLogonType.InteractiveToken

                    taskDefinition.Settings.RunOnlyIfNetworkAvailable = True
                    taskDefinition.Settings.StartWhenAvailable = True


                    ' Register the task in the root folder
                    Try
                        folder.RegisterTaskDefinition(task.taskName, taskDefinition)
                        mens &= ("Tarefa " & task.taskName & " registrada!") & vbCrLf

                        Exit While

                    Catch ex As Exception

                        Dim f As New frmAuthentication
                        Dim result As Windows.Forms.DialogResult

                        result = f.ShowDialog()

                        If result = Windows.Forms.DialogResult.Retry Then
                            Try
                                taskService = New TaskService("", f.txtUser.Text, f.txtDomain.Text, f.txtPass.Text)
                            Catch ex1 As Exception
                                mens &= ("Erro ao registrar as tarefa " & task.taskName & ": " & ex1.Message) & vbCrLf
                            End Try
                        ElseIf result = Windows.Forms.DialogResult.Ignore Then
                            mens &= ("Tarefas não registradas. MD não irá funcionar corretamente.") & vbCrLf
                            Exit Sub
                        Else
                            Exit Sub
                        End If

                    End Try

                End While
            Next

        End Using

    End Sub

    Private Class task
        Public filename As String
        Public taskName As String
        Public description As String

        Sub New(filename As String, taskname As String, description As String)
            Me.filename = filename
            Me.taskName = taskname
            Me.description = description
        End Sub
    End Class

End Module
