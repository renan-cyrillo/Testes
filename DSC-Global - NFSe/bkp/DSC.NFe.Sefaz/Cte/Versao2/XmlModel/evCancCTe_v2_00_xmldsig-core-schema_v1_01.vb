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

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=2.0.50727.3038.
'
Namespace Cte.Versao2.XmlModel.evCancCTe

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
    Partial Public Class evCancCTe
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged

        Private descEventoField As evCancCTeDescEvento

        Private nProtField As String

        Private xJustField As String

        '''<remarks/>
        Public Property descEvento() As evCancCTeDescEvento
            Get
                Return Me.descEventoField
            End Get
            Set(ByVal value As evCancCTeDescEvento)
                Me.descEventoField = value
                Me.RaisePropertyChanged("descEvento")
            End Set
        End Property

        '''<remarks/>
        Public Property nProt() As String
            Get
                Return Me.nProtField
            End Get
            Set(ByVal value As String)
                Me.nProtField = value
                Me.RaisePropertyChanged("nProt")
            End Set
        End Property

        '''<remarks/>
        Public Property xJust() As String
            Get
                Return Me.xJustField
            End Get
            Set(ByVal value As String)
                Me.xJustField = value
                Me.RaisePropertyChanged("xJust")
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum evCancCTeDescEvento

        '''<remarks/>
        Cancelamento
    End Enum

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
            Set(ByVal value As SignedInfoType)
                Me.signedInfoField = value
                Me.RaisePropertyChanged("SignedInfo")
            End Set
        End Property

        '''<remarks/>
        Public Property SignatureValue() As SignatureValueType
            Get
                Return Me.signatureValueField
            End Get
            Set(ByVal value As SignatureValueType)
                Me.signatureValueField = value
                Me.RaisePropertyChanged("SignatureValue")
            End Set
        End Property

        '''<remarks/>
        Public Property KeyInfo() As KeyInfoType
            Get
                Return Me.keyInfoField
            End Get
            Set(ByVal value As KeyInfoType)
                Me.keyInfoField = value
                Me.RaisePropertyChanged("KeyInfo")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(ByVal value As String)
                Me.idField = value
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
            Set(ByVal value As SignedInfoTypeCanonicalizationMethod)
                Me.canonicalizationMethodField = value
                Me.RaisePropertyChanged("CanonicalizationMethod")
            End Set
        End Property

        '''<remarks/>
        Public Property SignatureMethod() As SignedInfoTypeSignatureMethod
            Get
                Return Me.signatureMethodField
            End Get
            Set(ByVal value As SignedInfoTypeSignatureMethod)
                Me.signatureMethodField = value
                Me.RaisePropertyChanged("SignatureMethod")
            End Set
        End Property

        '''<remarks/>
        Public Property Reference() As ReferenceType
            Get
                Return Me.referenceField
            End Get
            Set(ByVal value As ReferenceType)
                Me.referenceField = value
                Me.RaisePropertyChanged("Reference")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(ByVal value As String)
                Me.idField = value
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
            Set(ByVal value As String)
                Me.algorithmField = value
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
            Set(ByVal value As String)
                Me.algorithmField = value
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
            Set(ByVal value As TransformType())
                Me.transformsField = value
                Me.RaisePropertyChanged("Transforms")
            End Set
        End Property

        '''<remarks/>
        Public Property DigestMethod() As ReferenceTypeDigestMethod
            Get
                Return Me.digestMethodField
            End Get
            Set(ByVal value As ReferenceTypeDigestMethod)
                Me.digestMethodField = value
                Me.RaisePropertyChanged("DigestMethod")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
        Public Property DigestValue() As Byte()
            Get
                Return Me.digestValueField
            End Get
            Set(ByVal value As Byte())
                Me.digestValueField = value
                Me.RaisePropertyChanged("DigestValue")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(ByVal value As String)
                Me.idField = value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property URI() As String
            Get
                Return Me.uRIField
            End Get
            Set(ByVal value As String)
                Me.uRIField = value
                Me.RaisePropertyChanged("URI")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
        Public Property Type() As String
            Get
                Return Me.typeField
            End Get
            Set(ByVal value As String)
                Me.typeField = value
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
            Set(ByVal value As String())
                Me.xPathField = value
                Me.RaisePropertyChanged("XPath")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Algorithm() As TTransformURI
            Get
                Return Me.algorithmField
            End Get
            Set(ByVal value As TTransformURI)
                Me.algorithmField = value
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
            Set(ByVal value As String)
                Me.algorithmField = value
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
            Set(ByVal value As String)
                Me.idField = value
                Me.RaisePropertyChanged("Id")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute(DataType:="base64Binary")> _
        Public Property Value() As Byte()
            Get
                Return Me.valueField
            End Get
            Set(ByVal value As Byte())
                Me.valueField = value
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
            Set(ByVal value As X509DataType)
                Me.x509DataField = value
                Me.RaisePropertyChanged("X509Data")
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(ByVal value As String)
                Me.idField = value
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
            Set(ByVal value As Byte())
                Me.x509CertificateField = value
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
End Namespace
