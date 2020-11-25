Imports System.Security
Imports System.Security.AccessControl
Imports System.Diagnostics
Imports Microsoft.Win32
Imports System.IO

Public Class DSCEventViewer

    'HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\eventlog

    '*************************************************************
    'NAME:          WriteToEventLog
    'PURPOSE:       Write to Event Log
    'PARAMETERS:    Entry - Value to Write
    '               AppName - Name of Client Application. Needed 
    '               because before writing to event log, you must 
    '               have a named EventLog source. 
    '               EventType - Entry Type, from EventLogEntryType 
    '               Structure e.g., EventLogEntryType.Warning, 
    '               EventLogEntryType.Error
    '               LogNam1e: Name of Log (System, Application; 
    '               Security is read-only) If you 
    '               specify a non-existent log, the log will be
    '               created
    'RETURNS:       True if successful
    '*************************************************************
    Public Shared Function WriteToEventLog(ByVal entry As String, _
                                           Optional ByVal Source As String = "DSC.RA", _
                                           Optional ByVal eventType As EventLogEntryType = EventLogEntryType.Information, _
                                           Optional ByVal LogName As String = "DSC.RA") As Boolean

        Dim objEventLog As New EventLog

        Try

            AddAccessRuleSecurity()

            Dim sourceExist As Boolean

            Try
                sourceExist = EventLog.SourceExists(Source)
            Catch ex As Exception
                sourceExist = False
            End Try

            If Not sourceExist Then
                Dim ev As New EventLogPermission(EventLogPermissionAccess.Administer, ".")
                ev.Assert()

                EventLog.CreateEventSource(Source, LogName)
            End If

            'log the entry
            objEventLog.Source = Source
            objEventLog.WriteEntry(entry, eventType, EventLogEntryType.Error)

            Return True

        Catch Ex As Exception

            Return False

        End Try

    End Function

    Private Shared Sub AddAccessRuleSecurity()

        Try

            Dim RegistryEventLog As RegistryKey = Registry.LocalMachine

            ' Cria um objeto de segurança que não concede o acesso.

            Dim RegistrySecurityEventLog As New RegistrySecurity()

            ' Adiciona regras desegurança para o usuário logado

            Dim user As String = Path.Combine(Environment.UserDomainName, Environment.UserName)

            ' Adiciona uma regra que concede ao usuário atual o direito de ler e enumerar os pares nome / valor em uma chave,
            ' Ler seu acesso e regras de auditoria, para enumerar suas subchaves, para criar subchaves, e para excluir a chave.
            ' A regra é herdada por todas as subchaves contidas.

            Dim rule As New RegistryAccessRule(user, _
                                               RegistryRights.FullControl, _
                                               InheritanceFlags.ContainerInherit, _
                                               PropagationFlags.None, _
                                               AccessControlType.Allow)

            RegistrySecurityEventLog.AddAccessRule(rule)

            ' Adiciona uma regra que permite que o usuário atual do direito direito de definir os pares nome / valor em uma chave.
            ' Esta regra é herdada por subchaves contidas, mas sinalizadores de propagação limitá-lo a subchaves filho imediato.

            rule = New RegistryAccessRule(user, _
                                          RegistryRights.ChangePermissions, _
                                          InheritanceFlags.ContainerInherit, _
                                          PropagationFlags.InheritOnly Or PropagationFlags.NoPropagateInherit, _
                                          AccessControlType.Allow)

            RegistrySecurityEventLog.AddAccessRule(rule)

            'HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\eventlog

            Dim RegistryKeyEventLog As RegistryKey = RegistryEventLog.CreateSubKey("SYSTEM\CurrentControlSet\services\eventlog", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistrySecurityEventLog)

            RegistryKeyEventLog.SetAccessControl(RegistrySecurityEventLog)

        Catch ex As SecurityException
            Throw ex

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Shared Sub GravaLog(ByVal messageFile As String)

        Dim myLogName As String
        Dim sourceName As String = "DSC - Recebimento Automático"

        ' Create the event source if it does not exist. 
        If Not EventLog.SourceExists(sourceName) Then

            ' Create a new event source for the custom event log 
            ' named "myNewLog."  

            myLogName = "myNewLog"

            Dim mySourceData As EventSourceCreationData = New EventSourceCreationData(sourceName, myLogName)

            mySourceData.MessageResourceFile = messageFile
            mySourceData.CategoryResourceFile = messageFile
            'mySourceData.CategoryCount = CategoryCount
            mySourceData.ParameterResourceFile = messageFile

            EventLog.CreateEventSource(mySourceData)
        Else
            ' Get the event log corresponding to the existing source.
            myLogName = EventLog.LogNameFromSourceName(sourceName, ".")
            EventLog.WriteEntry(sourceName, messageFile)

        End If

    End Sub

End Class
