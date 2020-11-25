Imports System.IO

Public Class Log

    Public Enum enTipoLog
        EventViewer
        TextFile
    End Enum

    Public Shared Sub GravaLog(ByVal LogFolder As String, ByVal Mensagem As String, ByVal TipoMensagem As System.Diagnostics.EventLogEntryType, ByVal LogName As String, ByVal Source As String)

        Try
            If LogFolder = "" Then
                GravaLogEventViewer(Mensagem, TipoMensagem, LogName, Source)
            Else
                GravaLogTextFile(LogFolder, Mensagem, TipoMensagem, LogName, Source)
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Shared Sub GravaLogEventViewer(ByVal Mensagem As String, ByVal TipoMensagem As System.Diagnostics.EventLogEntryType, ByVal LogName As String, ByVal Source As String)

        Dim EventLogDSC As EventLog

        Try

            If Not EventLog.SourceExists(Source) Then
                Console.WriteLine("Criando entrada no Log de Eventos do Windows: " & LogName)
                EventLog.CreateEventSource(Source, LogName)
            End If

            EventLogDSC = New EventLog

            EventLogDSC.Log = LogName
            EventLogDSC.Source = Source

            EventLogDSC.WriteEntry(Mensagem, TipoMensagem)

        Catch secEx As System.Security.SecurityException
            Throw secEx

        Catch ex As Exception

        Finally
            EventLogDSC = Nothing

        End Try

    End Sub

    Private Shared Sub GravaLogTextFile(ByVal LogFolder As String, ByVal Mensagem As String, ByVal TipoMensagem As System.Diagnostics.EventLogEntryType, ByVal LogName As String, ByVal Source As String)

        Try
            Dim FileName As String = Path.Combine(LogFolder, LogName & "." & Source & "." & Format(Now, "yyyy-MM-dd") & ".txt")

            If Not Directory.Exists(LogFolder) Then
                Directory.CreateDirectory(LogFolder)
            End If

            Dim LogFile As System.IO.StreamWriter

            LogFile = File.AppendText(FileName)

            LogFile.WriteLine("[" & Now & "][" & TipoMensagem.ToString & "] - " & Mensagem)

            LogFile.Close()

        Catch ex As Exception

        End Try

    End Sub

    
End Class
