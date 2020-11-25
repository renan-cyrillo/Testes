Imports System.IO
Imports System.Web.Services.Protocols
Imports System.Xml

''' <summary>
''' SOAP Extension that traces the SOAP request and
''' SOAP response for the PayPal SOAP API Web service. 
''' </summary>
Public Class TraceExtension
    Inherits SoapExtension
    Private oldStream As Stream
    Private newStream As Stream

    Sub New()
        MyBase.New()
    End Sub

    Private Shared m_xmlRequest As XmlDocument
    ''' <summary>
    ''' Gets the outgoing XML request sent to PayPal
    ''' </summary>
    Public Shared ReadOnly Property XmlRequest() As XmlDocument
        Get
            Return m_xmlRequest
        End Get
    End Property

    Private Shared m_xmlResponse As XmlDocument
    ''' <summary>
    ''' Gets the incoming XML response sent from PayPal
    ''' </summary>
    Public Shared ReadOnly Property XmlResponse() As XmlDocument
        Get
            Return m_xmlResponse
        End Get
    End Property

    ''' <summary>
    ''' Save the Stream representing the SOAP request
    ''' or SOAP response into a local memory buffer. 
    ''' </summary>
    ''' <param name="stream"></param>
    ''' <returns></returns>
    Public Overrides Function ChainStream(stream As Stream) As Stream
        oldStream = stream
        newStream = New MemoryStream()

        Return newStream  'Return MyBase.ChainStream(newStream)
    End Function

    ''' <summary>
    ''' If the SoapMessageStage is such that the SoapRequest or
    ''' SoapResponse is still in the SOAP format to be sent or received,
    ''' save it to the xmlRequest or xmlResponse property.
    ''' </summary>
    ''' <param name="message"></param>
    Public Overrides Sub ProcessMessage(message As SoapMessage)
        Select Case message.Stage
            Case SoapMessageStage.BeforeSerialize
                Exit Select
            Case SoapMessageStage.AfterSerialize
                m_xmlRequest = GetSoapEnvelope(newStream)
                CopyStream(newStream, oldStream)
                Exit Select
            Case SoapMessageStage.BeforeDeserialize
                CopyStream(oldStream, newStream)
                m_xmlResponse = GetSoapEnvelope(newStream)
                Exit Select
            Case SoapMessageStage.AfterDeserialize
                Exit Select
        End Select
    End Sub

    ''' <summary>
    ''' Returns the XML representation of the Soap Envelope in the supplied stream.
    ''' Resets the position of stream to zero.
    ''' </summary>
    ''' <param name="stream"></param>
    ''' <returns></returns>
    Private Function GetSoapEnvelope(stream As Stream) As XmlDocument
        Dim xml As New XmlDocument()
        stream.Position = 0
        Dim reader As New StreamReader(stream)
        xml.LoadXml(reader.ReadToEnd())
        stream.Position = 0
        Return xml
    End Function

    ''' <summary>
    ''' Copies a stream.
    ''' </summary>
    ''' <param name="from"></param>
    ''' <param name="to"></param>
    Private Sub CopyStream(from As Stream, [to] As Stream)
        Dim reader As TextReader = New StreamReader(from)
        Dim writer As TextWriter = New StreamWriter([to])
        writer.WriteLine(reader.ReadToEnd())
        writer.Flush()
    End Sub

#Region "NoOp"
    ''' <summary>
    ''' Included only because it must be implemented.
    ''' </summary>
    ''' <param name="methodInfo"></param>
    ''' <param name="attribute"></param>
    ''' <returns></returns>
    Public Overrides Function GetInitializer(methodInfo As LogicalMethodInfo, attribute As SoapExtensionAttribute) As Object
        Return Nothing
    End Function

    ''' <summary>
    ''' Included only because it must be implemented.
    ''' </summary>
    ''' <param name="WebServiceType"></param>
    ''' <returns></returns>
    Public Overrides Function GetInitializer(WebServiceType As Type) As Object
        Return Nothing
    End Function

    ''' <summary>
    ''' Included only because it must be implemented.
    ''' </summary>
    ''' <param name="initializer"></param>
    Public Overrides Sub Initialize(initializer As Object)
    End Sub
#End Region

End Class
