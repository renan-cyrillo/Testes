﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:2.0.50727.6419
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=2.0.50727.3038.
'
Namespace Nfe.Versao1.XmlModel.RetEnvConfRecebto

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
     System.Xml.Serialization.XmlRootAttribute("retEnvEvento", [Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
    Partial Public Class TRetEnvEvento
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private idLoteField As String

        Private tpAmbField As TAmb

        Private verAplicField As String

        Private cOrgaoField As TCOrgaoIBGE

        Private cStatField As String

        Private xMotivoField As String

        Private retEventoField() As TretEvento

        Private versaoField As String

        '''<remarks/>
        Public Property idLote() As String
            Get
                Return Me.idLoteField
            End Get
            Set(value As String)
                Me.idLoteField = Value
                Me.RaisePropertyChanged("idLote")
            End Set
        End Property

        '''<remarks/>
        Public Property tpAmb() As TAmb
            Get
                Return Me.tpAmbField
            End Get
            Set(value As TAmb)
                Me.tpAmbField = Value
                Me.RaisePropertyChanged("tpAmb")
            End Set
        End Property

        '''<remarks/>
        Public Property verAplic() As String
            Get
                Return Me.verAplicField
            End Get
            Set(value As String)
                Me.verAplicField = Value
                Me.RaisePropertyChanged("verAplic")
            End Set
        End Property

        '''<remarks/>
        Public Property cOrgao() As TCOrgaoIBGE
            Get
                Return Me.cOrgaoField
            End Get
            Set(value As TCOrgaoIBGE)
                Me.cOrgaoField = Value
                Me.RaisePropertyChanged("cOrgao")
            End Set
        End Property

        '''<remarks/>
        Public Property cStat() As String
            Get
                Return Me.cStatField
            End Get
            Set(value As String)
                Me.cStatField = Value
                Me.RaisePropertyChanged("cStat")
            End Set
        End Property

        '''<remarks/>
        Public Property xMotivo() As String
            Get
                Return Me.xMotivoField
            End Get
            Set(value As String)
                Me.xMotivoField = Value
                Me.RaisePropertyChanged("xMotivo")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("retEvento")> _
        Public Property retEvento() As TretEvento()
            Get
                Return Me.retEventoField
            End Get
            Set(value As TretEvento())
                Me.retEventoField = Value
                Me.RaisePropertyChanged("retEvento")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property versao() As String
            Get
                Return Me.versaoField
            End Get
            Set(value As String)
                Me.versaoField = Value
                Me.RaisePropertyChanged("versao")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Public Enum TAmb

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")> _
        Producao = 1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2")> _
        Homologacao = 2
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Public Enum TCOrgaoIBGE

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("11")> _
        UF_RO

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("12")> _
        UF_AC

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("13")> _
        UF_AM

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("14")> _
        UF_RR

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("15")> _
        UF_PA

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("16")> _
        UF_AP

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("17")> _
        UF_TO

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("21")> _
        UF_MA

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("22")> _
        UF_PI

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("23")> _
        UF_CE

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("24")> _
        UF_RN

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("25")> _
        UF_PB

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("26")> _
        UF_PE

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("27")> _
        UF_AL

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("28")> _
        UF_SE

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("29")> _
        UF_BA

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("31")> _
        UF_MG

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("32")> _
        UF_ES

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("33")> _
        UF_RJ

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("35")> _
        UF_SP

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("41")> _
        UF_PR

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("42")> _
        UF_SC

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("43")> _
        UF_RS

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("50")> _
        UF_MS

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("51")> _
        UF_MT

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("52")> _
        UF_GO

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("53")> _
        UF_DF

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("90")> _
        UF_AN90

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("91")> _
        UF_AN91

    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Partial Public Class TretEvento
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private infEventoField As TretEventoInfEvento

        Private signatureField As SignatureType

        Private versaoField As String

        '''<remarks/>
        Public Property infEvento() As TretEventoInfEvento
            Get
                Return Me.infEventoField
            End Get
            Set(value As TretEventoInfEvento)
                Me.infEventoField = Value
                Me.RaisePropertyChanged("infEvento")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
        Public Property Signature() As SignatureType
            Get
                Return Me.signatureField
            End Get
            Set(value As SignatureType)
                Me.signatureField = Value
                Me.RaisePropertyChanged("Signature")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property versao() As String
            Get
                Return Me.versaoField
            End Get
            Set(value As String)
                Me.versaoField = Value
                Me.RaisePropertyChanged("versao")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Partial Public Class TretEventoInfEvento
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private tpAmbField As TAmb

        Private verAplicField As String

        Private cOrgaoField As TCOrgaoIBGE

        Private cStatField As String

        Private xMotivoField As String

        Private chNFeField As String

        Private tpEventoField As String

        Private xEventoField As String

        Private nSeqEventoField As String

        Private itemField As String

        Private itemElementNameField As ItemChoiceType

        Private emailDestField As String

        Private dhRegEventoField As String

        Private nProtField As String

        Private idField As String

        '''<remarks/>
        Public Property tpAmb() As TAmb
            Get
                Return Me.tpAmbField
            End Get
            Set(value As TAmb)
                Me.tpAmbField = Value
                Me.RaisePropertyChanged("tpAmb")
            End Set
        End Property

        '''<remarks/>
        Public Property verAplic() As String
            Get
                Return Me.verAplicField
            End Get
            Set(value As String)
                Me.verAplicField = Value
                Me.RaisePropertyChanged("verAplic")
            End Set
        End Property

        '''<remarks/>
        Public Property cOrgao() As TCOrgaoIBGE
            Get
                Return Me.cOrgaoField
            End Get
            Set(value As TCOrgaoIBGE)
                Me.cOrgaoField = Value
                Me.RaisePropertyChanged("cOrgao")
            End Set
        End Property

        '''<remarks/>
        Public Property cStat() As String
            Get
                Return Me.cStatField
            End Get
            Set(value As String)
                Me.cStatField = Value
                Me.RaisePropertyChanged("cStat")
            End Set
        End Property

        '''<remarks/>
        Public Property xMotivo() As String
            Get
                Return Me.xMotivoField
            End Get
            Set(value As String)
                Me.xMotivoField = Value
                Me.RaisePropertyChanged("xMotivo")
            End Set
        End Property

        '''<remarks/>
        Public Property chNFe() As String
            Get
                Return Me.chNFeField
            End Get
            Set(value As String)
                Me.chNFeField = Value
                Me.RaisePropertyChanged("chNFe")
            End Set
        End Property

        '''<remarks/>
        Public Property tpEvento() As String
            Get
                Return Me.tpEventoField
            End Get
            Set(value As String)
                Me.tpEventoField = Value
                Me.RaisePropertyChanged("tpEvento")
            End Set
        End Property

        '''<remarks/>
        Public Property xEvento() As String
            Get
                Return Me.xEventoField
            End Get
            Set(value As String)
                Me.xEventoField = Value
                Me.RaisePropertyChanged("xEvento")
            End Set
        End Property

        '''<remarks/>
        Public Property nSeqEvento() As String
            Get
                Return Me.nSeqEventoField
            End Get
            Set(value As String)
                Me.nSeqEventoField = Value
                Me.RaisePropertyChanged("nSeqEvento")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("CNPJDest", GetType(String)), _
         System.Xml.Serialization.XmlElementAttribute("CPFDest", GetType(String)), _
         System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
        Public Property Item() As String
            Get
                Return Me.itemField
            End Get
            Set(value As String)
                Me.itemField = Value
                Me.RaisePropertyChanged("Item")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property ItemElementName() As ItemChoiceType
            Get
                Return Me.itemElementNameField
            End Get
            Set(value As ItemChoiceType)
                Me.itemElementNameField = Value
                Me.RaisePropertyChanged("ItemElementName")
            End Set
        End Property

        '''<remarks/>
        Public Property emailDest() As String
            Get
                Return Me.emailDestField
            End Get
            Set(value As String)
                Me.emailDestField = Value
                Me.RaisePropertyChanged("emailDest")
            End Set
        End Property

        '''<remarks/>
        Public Property dhRegEvento() As String
            Get
                Return Me.dhRegEventoField
            End Get
            Set(value As String)
                Me.dhRegEventoField = Value
                Me.RaisePropertyChanged("dhRegEvento")
            End Set
        End Property

        '''<remarks/>
        Public Property nProt() As String
            Get
                Return Me.nProtField
            End Get
            Set(value As String)
                Me.nProtField = Value
                Me.RaisePropertyChanged("nProt")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = Value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IncludeInSchema:=False)> _
    Public Enum ItemChoiceType

        '''<remarks/>
        CNPJDest

        '''<remarks/>
        CPFDest
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class X509DataType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private x509CertificateField() As Byte

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
        Public Property X509Certificate() As Byte()
            Get
                Return Me.x509CertificateField
            End Get
            Set(value As Byte())
                Me.x509CertificateField = Value
                Me.RaisePropertyChanged("X509Certificate")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class KeyInfoType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private x509DataField As X509DataType

        Private idField As String

        '''<remarks/>
        Public Property X509Data() As X509DataType
            Get
                Return Me.x509DataField
            End Get
            Set(value As X509DataType)
                Me.x509DataField = Value
                Me.RaisePropertyChanged("X509Data")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = Value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignatureValueType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private idField As String

        Private valueField() As Byte

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = Value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute(DataType:="base64Binary")> _
        Public Property Value() As Byte()
            Get
                Return Me.valueField
            End Get
            Set(value As Byte())
                Me.valueField = Value
                Me.RaisePropertyChanged("Value")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class TransformType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private xPathField() As String

        Private algorithmField As TTransformURI

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("XPath")> _
        Public Property XPath() As String()
            Get
                Return Me.xPathField
            End Get
            Set(value As String())
                Me.xPathField = Value
                Me.RaisePropertyChanged("XPath")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Algorithm() As TTransformURI
            Get
                Return Me.algorithmField
            End Get
            Set(value As TTransformURI)
                Me.algorithmField = Value
                Me.RaisePropertyChanged("Algorithm")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Enum TTransformURI

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("http://www.w3.org/2000/09/xmldsig#enveloped-signature")> _
        httpwwww3org200009xmldsigenvelopedsignature

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")> _
        httpwwww3orgTR2001RECxmlc14n20010315
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class ReferenceType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private transformsField() As TransformType

        Private digestMethodField As ReferenceTypeDigestMethod

        Private digestValueField() As Byte

        Private idField As String

        Private uRIField As String

        Private typeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable:=False)> _
        Public Property Transforms() As TransformType()
            Get
                Return Me.transformsField
            End Get
            Set(value As TransformType())
                Me.transformsField = Value
                Me.RaisePropertyChanged("Transforms")
            End Set
        End Property

        '''<remarks/>
        Public Property DigestMethod() As ReferenceTypeDigestMethod
            Get
                Return Me.digestMethodField
            End Get
            Set(value As ReferenceTypeDigestMethod)
                Me.digestMethodField = Value
                Me.RaisePropertyChanged("DigestMethod")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
        Public Property DigestValue() As Byte()
            Get
                Return Me.digestValueField
            End Get
            Set(value As Byte())
                Me.digestValueField = Value
                Me.RaisePropertyChanged("DigestValue")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = Value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property URI() As String
            Get
                Return Me.uRIField
            End Get
            Set(value As String)
                Me.uRIField = Value
                Me.RaisePropertyChanged("URI")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property Type() As String
            Get
                Return Me.typeField
            End Get
            Set(value As String)
                Me.typeField = Value
                Me.RaisePropertyChanged("Type")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class ReferenceTypeDigestMethod
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private algorithmField As String

        Public Sub New()
            MyBase.New()
            Me.algorithmField = "http://www.w3.org/2000/09/xmldsig#sha1"
        End Sub

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property Algorithm() As String
            Get
                Return Me.algorithmField
            End Get
            Set(value As String)
                Me.algorithmField = Value
                Me.RaisePropertyChanged("Algorithm")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignedInfoType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private canonicalizationMethodField As SignedInfoTypeCanonicalizationMethod

        Private signatureMethodField As SignedInfoTypeSignatureMethod

        Private referenceField As ReferenceType

        Private idField As String

        '''<remarks/>
        Public Property CanonicalizationMethod() As SignedInfoTypeCanonicalizationMethod
            Get
                Return Me.canonicalizationMethodField
            End Get
            Set(value As SignedInfoTypeCanonicalizationMethod)
                Me.canonicalizationMethodField = Value
                Me.RaisePropertyChanged("CanonicalizationMethod")
            End Set
        End Property

        '''<remarks/>
        Public Property SignatureMethod() As SignedInfoTypeSignatureMethod
            Get
                Return Me.signatureMethodField
            End Get
            Set(value As SignedInfoTypeSignatureMethod)
                Me.signatureMethodField = Value
                Me.RaisePropertyChanged("SignatureMethod")
            End Set
        End Property

        '''<remarks/>
        Public Property Reference() As ReferenceType
            Get
                Return Me.referenceField
            End Get
            Set(value As ReferenceType)
                Me.referenceField = Value
                Me.RaisePropertyChanged("Reference")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = Value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignedInfoTypeCanonicalizationMethod
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private algorithmField As String

        Public Sub New()
            MyBase.New()
            Me.algorithmField = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
        End Sub

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property Algorithm() As String
            Get
                Return Me.algorithmField
            End Get
            Set(value As String)
                Me.algorithmField = Value
                Me.RaisePropertyChanged("Algorithm")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignedInfoTypeSignatureMethod
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private algorithmField As String

        Public Sub New()
            MyBase.New()
            Me.algorithmField = "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
        End Sub

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property Algorithm() As String
            Get
                Return Me.algorithmField
            End Get
            Set(value As String)
                Me.algorithmField = Value
                Me.RaisePropertyChanged("Algorithm")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#"), _
     System.Xml.Serialization.XmlRootAttribute("Signature", [Namespace]:="http://www.w3.org/2000/09/xmldsig#", IsNullable:=False)> _
    Partial Public Class SignatureType
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private signedInfoField As SignedInfoType

        Private signatureValueField As SignatureValueType

        Private keyInfoField As KeyInfoType

        Private idField As String

        '''<remarks/>
        Public Property SignedInfo() As SignedInfoType
            Get
                Return Me.signedInfoField
            End Get
            Set(value As SignedInfoType)
                Me.signedInfoField = Value
                Me.RaisePropertyChanged("SignedInfo")
            End Set
        End Property

        '''<remarks/>
        Public Property SignatureValue() As SignatureValueType
            Get
                Return Me.signatureValueField
            End Get
            Set(value As SignatureValueType)
                Me.signatureValueField = Value
                Me.RaisePropertyChanged("SignatureValue")
            End Set
        End Property

        '''<remarks/>
        Public Property KeyInfo() As KeyInfoType
            Get
                Return Me.keyInfoField
            End Get
            Set(value As KeyInfoType)
                Me.keyInfoField = Value
                Me.RaisePropertyChanged("KeyInfo")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = Value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
End Namespace
