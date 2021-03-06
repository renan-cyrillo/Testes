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

Namespace Cte.Versao1.WSDL.ConsultaCadastro

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="CadConsultaCadastroSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CadConsultaCadastro")> _
    Partial Public Class CadConsultaCadastro
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private cteCabecMsgField As CTeCabecMsg

        Private consultaCadastroOperationCompleted As System.Threading.SendOrPostCallback

        '''<remarks/>
        Public Sub New()
            MyBase.New()
            Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
            Me.Url = "https://producao.cte.ms.gov.br/cteWEB/CadConsultaCadastro.asmx"
        End Sub

        Public Property cteCabecMsg() As CTeCabecMsg
            Get
                Return Me.cteCabecMsgField
            End Get
            Set(ByVal value As CTeCabecMsg)
                Me.cteCabecMsgField = value
            End Set
        End Property

        '''<remarks/>
        Public Event consultaCadastroCompleted As consultaCadastroCompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsg", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CadConsultaCadastro/consultaCadastro", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
        Public Function consultaCadastro(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CadConsultaCadastro")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CadConsultaCadastro")> System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("consultaCadastro", New Object() {cteDadosMsg})
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Function BeginconsultaCadastro(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("consultaCadastro", New Object() {cteDadosMsg}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndconsultaCadastro(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Overloads Sub consultaCadastroAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
            Me.consultaCadastroAsync(cteDadosMsg, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub consultaCadastroAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.consultaCadastroOperationCompleted Is Nothing) Then
                Me.consultaCadastroOperationCompleted = AddressOf Me.OnconsultaCadastroOperationCompleted
            End If
            Me.InvokeAsync("consultaCadastro", New Object() {cteDadosMsg}, Me.consultaCadastroOperationCompleted, userState)
        End Sub

        Private Sub OnconsultaCadastroOperationCompleted(ByVal arg As Object)
            If (Not (Me.consultaCadastroCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent consultaCadastroCompleted(Me, New consultaCadastroCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CadConsultaCadastro"), _
     System.Xml.Serialization.XmlRootAttribute("cteCabecMsg", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CadConsultaCadastro", IsNullable:=False)> _
    Partial Public Class CTeCabecMsg
        Inherits System.Web.Services.Protocols.SoapHeader

        Private cUFField As String

        Private versaoDadosField As String

        Private anyAttrField() As System.Xml.XmlAttribute

        '''<remarks/>
        Public Property cUF() As String
            Get
                Return Me.cUFField
            End Get
            Set(ByVal value As String)
                Me.cUFField = value
            End Set
        End Property

        '''<remarks/>
        Public Property versaoDados() As String
            Get
                Return Me.versaoDadosField
            End Get
            Set(ByVal value As String)
                Me.versaoDadosField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
        Public Property AnyAttr() As System.Xml.XmlAttribute()
            Get
                Return Me.anyAttrField
            End Get
            Set(ByVal value As System.Xml.XmlAttribute())
                Me.anyAttrField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")> _
    Public Delegate Sub consultaCadastroCompletedEventHandler(ByVal sender As Object, ByVal e As consultaCadastroCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class consultaCadastroCompletedEventArgs
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
