Imports O = Microsoft.Office.Interop.Outlook
Imports System.ComponentModel
Imports System.Globalization

Public Class OUTLOOKClient

    Public Enum enumCloseOutlookProcessResult
        ClosedSuccessfully
        ProcessNotFound
        ErrorTryingToCloseOutlookProcess
    End Enum

    Private Shared Function getFolderRec(ns As O.NameSpace, folderPath As String) As O.Folder
        For Each fdr As O.Folder In ns.Folders
            If fdr.FolderPath.ToLower.Contains(folderPath.ToLower) Then
                Return fdr
            Else
                Dim path As O.Folder = getFolderRec(fdr, folderPath)
                If Not path Is Nothing Then
                    Return path
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Shared Function getFolderRec(folder As O.Folder, folderPath As String) As O.Folder
        Dim result As O.Folder = Nothing

        For Each fdr As O.Folder In folder.Folders

            If fdr.FolderPath.ToLower.Contains(folderPath.ToLower) Then
                Return fdr
            Else
                result = getFolderRec(fdr, folderPath)
            End If
            If Not result Is Nothing Then
                Return result
            End If
        Next
        Return Nothing
    End Function

    Shared app As New O.Application

    ''' <summary>
    ''' Conecta a uma pasta do outlook e baixa todos os e-mails e anexos contidos na pasta
    ''' </summary>
    ''' <param name="OutlookInboxFolderPath">A pasta do Outlook de onde serão extraídos os e-mails.
    '''  Ex.: Conta abc@empresa.com.br, Pasta Inbox => '\\abc@empresa.com.br\inbox'
    ''' </param>
    ''' <param name="outlookBackupFolderPath">A pasta do Outlook para onde serão movidos os e-mails baixados.
    '''  Ex.: Conta abc@empresa.com.br, Pasta Backup => '\\abc@empresa.com.br\backup'
    '''     Caso este parâmetro não seja fornecido, o e-mail será apagado.</param>
    ''' <param name="systemFolderToSaveAttachments">Pasta do computador ou da rede onde serão gravados os anexos baixados</param>
    ''' <param name="systemFolderToSaveEML">Pasta do computador ou da rede onde serão gravados os arquivos de e-mail (EML) baixados OPCIONAL.</param>
    ''' <param name="attachmentFilePrefix">Prefixo a ser concatenado ao nome do anexo - OPCIONAL</param>
    ''' <param name="emlFilePrefix">Prefixo a ser concatenado ao nome do arquivo (EML) - OPCIONAL</param>
    ''' <param name="attachmentFileSufix">Sufixo a ser concatenado ao nome do anexo - OPCIONAL</param>
    ''' <param name="emlFileSufix">Sufixo a ser concatenado ao nome do anexo - OPCIONAL</param>
    ''' <remarks></remarks>
    Public Shared Sub downloadAttachments(outlookInboxFolderPath As String,
                                          outlookBackupFolderPath As String,
                                          systemFolderToSaveAttachments As String,
                                          Optional systemFolderToSaveEML As String = "",
                                          Optional attachmentFilePrefix As String = "",
                                          Optional emlFilePrefix As String = "",
                                          Optional attachmentFileSufix As String = "",
                                          Optional emlFileSufix As String = ""
                                          )
        'Shell("outlook", AppWinStyle.Hide, True)
        app = New O.Application

        If Not systemFolderToSaveEML.EndsWith("\") Then
            systemFolderToSaveEML &= "\"
        End If

        If Not systemFolderToSaveAttachments.EndsWith("\") Then
            systemFolderToSaveAttachments &= "\"
        End If

        Try

            Dim ns As O.NameSpace = app.GetNamespace("MAPI")
            ns.Logon(Nothing, Nothing, False, False)

            Try
                'MsgBox("Iniciando Send/Receive")
                ns.SendAndReceive(True)

            Catch ex As Exception
                'MsgBox("Erro Send/Receive")

            End Try

            'MsgBox("Finalizando Send/Receive")

            Dim folder As O.Folder =
                getFolderRec(ns, outlookInboxFolderPath)

            If folder Is Nothing Then
                Throw New Exception("The folder '" & outlookInboxFolderPath & "' does no exists.")
            End If

            Dim backupFolder As O.Folder =
                getFolderRec(ns, outlookBackupFolderPath)


            Dim cnt As Integer = 0
            Dim cntErro As Integer = 0

            'Para cada e-mail na pasta:
            'For Each i In folder.Items  ' baixa metade dos e-mails

            For i As Integer = folder.Items.Count To 1 Step -1

                Try

                    'MsgBox(folder.Items(i).class) ' e-mail class 43 parece ser o que serve

                    'Converto o item para e-mail
                    'Dim mail As O.MailItem = i
                    Dim mail As O.MailItem = folder.Items(i)

                    Try
                        'Grava o e-mail na pasta de backup
                        If systemFolderToSaveEML <> "\" Then
                            mail.SaveAs(systemFolderToSaveEML & emlFilePrefix & mail.EntryID & emlFileSufix & ".eml")
                        End If

                    Catch ex As Exception
                        GoTo ApagaEmailComErro

                    End Try

                    Try
                        'Para cada anexo:
                        For Each att As O.Attachment In mail.Attachments
                            'Grava anexo na pasta de arquivos
                            att.SaveAsFile(systemFolderToSaveAttachments & attachmentFilePrefix & att.FileName & attachmentFileSufix)
                        Next

                    Catch ex As Exception
                        GoTo ApagaEmailComErro

                    End Try

                    If outlookBackupFolderPath = "" Then
                        mail.Delete()
                    Else
                        Try
                            mail.Move(backupFolder)
                        Catch ex As Exception
                            'MsgBox(outlookBackupFolderPath)
                            'Throw ex
                        End Try
                    End If

                    cnt += 1

                    GoTo EmailOK

                Catch ex As System.Exception
                    cntErro += 1
                    GoTo ApagaEmailComErro

                End Try

ApagaEmailComErro:
                If outlookBackupFolderPath = "" Then
                    folder.Items(i).Delete()
                Else
                    Try
                        folder.Items(i).Move(backupFolder)
                    Catch ex2 As Exception
                        'MsgBox(outlookBackupFolderPath)
                        'Throw ex
                    End Try
                End If
EmailOK:

            Next

        Catch ex As System.Exception
            Throw ex

        Finally
            'app.Quit()
            'app = Nothing
            'closeOutlookProcess()

        End Try

    End Sub

    Private Shared Function closeOutlookProcess() As enumCloseOutlookProcessResult

        Try
            For Each proc In Process.GetProcesses()
                If proc.ProcessName.ToLower.StartsWith("outlook") Then
                    proc.Close()
                    Return enumCloseOutlookProcessResult.ClosedSuccessfully
                End If
            Next

            Return enumCloseOutlookProcessResult.ProcessNotFound

        Catch ex As Exception
            Return enumCloseOutlookProcessResult.ErrorTryingToCloseOutlookProcess
        End Try

    End Function

End Class
