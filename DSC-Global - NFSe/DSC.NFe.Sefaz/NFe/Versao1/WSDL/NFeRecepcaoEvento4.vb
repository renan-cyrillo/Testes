﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:4.0.30319.42000
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

Namespace Nfe.Versao1.WSDL.RecepcaoEvento4
    '
    'This source code was auto-generated by wsdl, Version=4.7.2046.0.
    '

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.7.2046.0"),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Web.Services.WebServiceBindingAttribute(Name:="NFeRecepcaoEvento4Soap", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")>
    Partial Public Class NFeRecepcaoEvento4
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private nfeRecepcaoEventoNFOperationCompleted As System.Threading.SendOrPostCallback

        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx"
        End Sub

        '''<remarks/>
        Public Event nfeRecepcaoEventoNFCompleted As nfeRecepcaoEventoNFCompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEventoNF", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)>
        Public Function nfeRecepcaoEventoNF(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")> ByVal nfeDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")> System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("nfeRecepcaoEventoNF", New Object() {nfeDadosMsg})
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Function BeginnfeRecepcaoEventoNF(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("nfeRecepcaoEventoNF", New Object() {nfeDadosMsg}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndnfeRecepcaoEventoNF(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Overloads Sub nfeRecepcaoEventoNFAsync(ByVal nfeDadosMsg As System.Xml.XmlNode)
            Me.nfeRecepcaoEventoNFAsync(nfeDadosMsg, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub nfeRecepcaoEventoNFAsync(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.nfeRecepcaoEventoNFOperationCompleted Is Nothing) Then
                Me.nfeRecepcaoEventoNFOperationCompleted = AddressOf Me.OnnfeRecepcaoEventoNFOperationCompleted
            End If
            Me.InvokeAsync("nfeRecepcaoEventoNF", New Object() {nfeDadosMsg}, Me.nfeRecepcaoEventoNFOperationCompleted, userState)
        End Sub

        Private Sub OnnfeRecepcaoEventoNFOperationCompleted(ByVal arg As Object)
            If (Not (Me.nfeRecepcaoEventoNFCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent nfeRecepcaoEventoNFCompleted(Me, New nfeRecepcaoEventoNFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.7.2046.0")>
    Public Delegate Sub nfeRecepcaoEventoNFCompletedEventHandler(ByVal sender As Object, ByVal e As nfeRecepcaoEventoNFCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.7.2046.0"),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code")>
    Partial Public Class nfeRecepcaoEventoNFCompletedEventArgs
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