﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:2.0.50727.6407
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by wsdl, Version=2.0.50727.3038.
'

Namespace Cte.Versao2.WSDL.RetRecepcao

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="CteRetRecepcaoSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao")> _
    Partial Public Class CteRetRecepcao
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private cteCabecMsgValueField As cteCabecMsg

        Private cteRetRecepcaoOperationCompleted As System.Threading.SendOrPostCallback

        '''<remarks/>
        Public Sub New()
            MyBase.New()
            Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
            Me.Url = "https://cte.sefaz.rs.gov.br/ws/cteretrecepcao/CteRetRecepcao.asmx"
        End Sub

        Public Property cteCabecMsgValue() As cteCabecMsg
            Get
                Return Me.cteCabecMsgValueField
            End Get
            Set(value As cteCabecMsg)
                Me.cteCabecMsgValueField = value
            End Set
        End Property

        '''<remarks/>
        Public Event cteRetRecepcaoCompleted As cteRetRecepcaoCompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao/cteRetRecepcao", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
        Public Function cteRetRecepcao(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao")> System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("cteRetRecepcao", New Object() {cteDadosMsg})
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Function BegincteRetRecepcao(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("cteRetRecepcao", New Object() {cteDadosMsg}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndcteRetRecepcao(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Overloads Sub cteRetRecepcaoAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
            Me.cteRetRecepcaoAsync(cteDadosMsg, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub cteRetRecepcaoAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.cteRetRecepcaoOperationCompleted Is Nothing) Then
                Me.cteRetRecepcaoOperationCompleted = AddressOf Me.OncteRetRecepcaoOperationCompleted
            End If
            Me.InvokeAsync("cteRetRecepcao", New Object() {cteDadosMsg}, Me.cteRetRecepcaoOperationCompleted, userState)
        End Sub

        Private Sub OncteRetRecepcaoOperationCompleted(ByVal arg As Object)
            If (Not (Me.cteRetRecepcaoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent cteRetRecepcaoCompleted(Me, New cteRetRecepcaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao", IsNullable:=False)> _
    Partial Public Class cteCabecMsg
        Inherits System.Web.Services.Protocols.SoapHeader

        Private cUFField As String

        Private versaoDadosField As String

        Private anyAttrField() As System.Xml.XmlAttribute

        '''<remarks/>
        Public Property cUF() As String
            Get
                Return Me.cUFField
            End Get
            Set(value As String)
                Me.cUFField = value
            End Set
        End Property

        '''<remarks/>
        Public Property versaoDados() As String
            Get
                Return Me.versaoDadosField
            End Get
            Set(value As String)
                Me.versaoDadosField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
        Public Property AnyAttr() As System.Xml.XmlAttribute()
            Get
                Return Me.anyAttrField
            End Get
            Set(value As System.Xml.XmlAttribute())
                Me.anyAttrField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")> _
    Public Delegate Sub cteRetRecepcaoCompletedEventHandler(ByVal sender As Object, ByVal e As cteRetRecepcaoCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class cteRetRecepcaoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), System.Xml.XmlNode)
            End Get
        End Property
    End Class

End Namespace
