Imports System.Xml.Serialization
Imports Microsoft.Win32
Imports System.IO
Imports System.Security
Imports System.Security.AccessControl

Public Class MDGlobal

    Public Shared Function DeserializeXmlStringToObject(ByVal XmlString As String, ByVal Type As Type) As Object

        Try
            Dim reader As New StringReader(XmlString)
            Dim serializer As New XmlSerializer(Type)

            Return serializer.Deserialize(reader)

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Function SerializeObjectToXmlString(ByVal obj As Object) As String

        Try

            Dim writer As New StringWriterUTF8()
            Dim serializer As New XmlSerializer(obj.GetType())
            Dim namespaces As New XmlSerializerNamespaces()

            namespaces.Add("", "http://www.portalfiscal.inf.br/nfe")

            'serializer.Serialize(writer, obj, namespaces)

            writer.NewLine = String.Empty
            'nfe.infNFe.ide.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + id_uf.ToString());

            serializer.Serialize(writer, obj)

            Dim xmlRet As String

            xmlRet = writer.ToString()
            xmlRet = xmlRet.Replace("xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""", "").Replace(">  <", "><").Replace("  ", " ")

            Return xmlRet

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Sub AddAccessRuleSecurity()

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

End Class

Public Class StringWriterUTF8
    Inherits StringWriter

    Public Overrides ReadOnly Property Encoding As System.Text.Encoding
        Get
            Return System.Text.Encoding.UTF8
        End Get
    End Property

End Class
