﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:2.0.50727.5472
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

Namespace Nfe.Versao3.WSDL.StatusServico

    '
    'This source code was auto-generated by wsdl, Version=2.0.50727.3038.
    '

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="NfeStatusServicoSoap", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico")> _
    Partial Public Class NfeStatusServico
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private nfeStatusServicoNFOperationCompleted As System.Threading.SendOrPostCallback

        '''<remarks/>
        Public Sub New()
            MyBase.New()
            Me.Url = "https://nfe.fazenda.sp.gov.br/nfeWEB/services/NfeStatusServico.asmx"
        End Sub

        '''<remarks/>
        Public Event nfeStatusServicoNFCompleted As nfeStatusServicoNFCompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico/nfeStatusServicoNF", RequestNamespace:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico", ResponseNamespace:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function nfeStatusServicoNF(ByVal nfeCabecMsg As String, ByVal nfeDadosMsg As String) As String
            Dim results() As Object = Me.Invoke("nfeStatusServicoNF", New Object() {nfeCabecMsg, nfeDadosMsg})
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Function BeginnfeStatusServicoNF(ByVal nfeCabecMsg As String, ByVal nfeDadosMsg As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("nfeStatusServicoNF", New Object() {nfeCabecMsg, nfeDadosMsg}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndnfeStatusServicoNF(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Overloads Sub nfeStatusServicoNFAsync(ByVal nfeCabecMsg As String, ByVal nfeDadosMsg As String)
            Me.nfeStatusServicoNFAsync(nfeCabecMsg, nfeDadosMsg, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub nfeStatusServicoNFAsync(ByVal nfeCabecMsg As String, ByVal nfeDadosMsg As String, ByVal userState As Object)
            If (Me.nfeStatusServicoNFOperationCompleted Is Nothing) Then
                Me.nfeStatusServicoNFOperationCompleted = AddressOf Me.OnnfeStatusServicoNFOperationCompleted
            End If
            Me.InvokeAsync("nfeStatusServicoNF", New Object() {nfeCabecMsg, nfeDadosMsg}, Me.nfeStatusServicoNFOperationCompleted, userState)
        End Sub

        Private Sub OnnfeStatusServicoNFOperationCompleted(ByVal arg As Object)
            If (Not (Me.nfeStatusServicoNFCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent nfeStatusServicoNFCompleted(Me, New nfeStatusServicoNFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")> _
    Public Delegate Sub nfeStatusServicoNFCompletedEventHandler(ByVal sender As Object, ByVal e As nfeStatusServicoNFCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class nfeStatusServicoNFCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), String)
            End Get
        End Property
    End Class

End Namespace
