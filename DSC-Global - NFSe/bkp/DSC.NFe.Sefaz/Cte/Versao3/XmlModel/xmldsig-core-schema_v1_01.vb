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

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=4.0.30319.1.
'
Namespace vb
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#"),  _
     System.Xml.Serialization.XmlRootAttribute("Signature", [Namespace]:="http://www.w3.org/2000/09/xmldsig#", IsNullable:=false)>  _
    Partial Public Class SignatureType
        
        Private signedInfoField As SignedInfoType
        
        Private signatureValueField As SignatureValueType
        
        Private keyInfoField As KeyInfoType
        
        Private idField As String
        
        '''<remarks/>
        Public Property SignedInfo() As SignedInfoType
            Get
                Return Me.signedInfoField
            End Get
            Set
                Me.signedInfoField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property SignatureValue() As SignatureValueType
            Get
                Return Me.signatureValueField
            End Get
            Set
                Me.signatureValueField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property KeyInfo() As KeyInfoType
            Get
                Return Me.keyInfoField
            End Get
            Set
                Me.keyInfoField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")>  _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class SignedInfoType
        
        Private canonicalizationMethodField As SignedInfoTypeCanonicalizationMethod
        
        Private signatureMethodField As SignedInfoTypeSignatureMethod
        
        Private referenceField As ReferenceType
        
        Private idField As String
        
        '''<remarks/>
        Public Property CanonicalizationMethod() As SignedInfoTypeCanonicalizationMethod
            Get
                Return Me.canonicalizationMethodField
            End Get
            Set
                Me.canonicalizationMethodField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property SignatureMethod() As SignedInfoTypeSignatureMethod
            Get
                Return Me.signatureMethodField
            End Get
            Set
                Me.signatureMethodField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Reference() As ReferenceType
            Get
                Return Me.referenceField
            End Get
            Set
                Me.referenceField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")>  _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class SignedInfoTypeCanonicalizationMethod
        
        Private algorithmField As String
        
        Public Sub New()
            MyBase.New
            Me.algorithmField = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
        End Sub
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")>  _
        Public Property Algorithm() As String
            Get
                Return Me.algorithmField
            End Get
            Set
                Me.algorithmField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class X509DataType
        
        Private x509CertificateField() As Byte
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")>  _
        Public Property X509Certificate() As Byte()
            Get
                Return Me.x509CertificateField
            End Get
            Set
                Me.x509CertificateField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class KeyInfoType
        
        Private x509DataField As X509DataType
        
        Private idField As String
        
        '''<remarks/>
        Public Property X509Data() As X509DataType
            Get
                Return Me.x509DataField
            End Get
            Set
                Me.x509DataField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")>  _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class SignatureValueType
        
        Private idField As String
        
        Private valueField() As Byte
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")>  _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute(DataType:="base64Binary")>  _
        Public Property Value() As Byte()
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class TransformType
        
        Private xPathField() As String
        
        Private algorithmField As TTransformURI
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("XPath")>  _
        Public Property XPath() As String()
            Get
                Return Me.xPathField
            End Get
            Set
                Me.xPathField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>  _
        Public Property Algorithm() As TTransformURI
            Get
                Return Me.algorithmField
            End Get
            Set
                Me.algorithmField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Public Enum TTransformURI
        
        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("http://www.w3.org/2000/09/xmldsig#enveloped-signature")>  _
        httpwwww3org200009xmldsigenvelopedsignature
        
        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")>  _
        httpwwww3orgTR2001RECxmlc14n20010315
    End Enum
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class ReferenceType
        
        Private transformsField() As TransformType
        
        Private digestMethodField As ReferenceTypeDigestMethod
        
        Private digestValueField() As Byte
        
        Private idField As String
        
        Private uRIField As String
        
        Private typeField As String
        
        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable:=false)>  _
        Public Property Transforms() As TransformType()
            Get
                Return Me.transformsField
            End Get
            Set
                Me.transformsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property DigestMethod() As ReferenceTypeDigestMethod
            Get
                Return Me.digestMethodField
            End Get
            Set
                Me.digestMethodField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")>  _
        Public Property DigestValue() As Byte()
            Get
                Return Me.digestValueField
            End Get
            Set
                Me.digestValueField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")>  _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")>  _
        Public Property URI() As String
            Get
                Return Me.uRIField
            End Get
            Set
                Me.uRIField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")>  _
        Public Property Type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class ReferenceTypeDigestMethod
        
        Private algorithmField As String
        
        Public Sub New()
            MyBase.New
            Me.algorithmField = "http://www.w3.org/2000/09/xmldsig#sha1"
        End Sub
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")>  _
        Public Property Algorithm() As String
            Get
                Return Me.algorithmField
            End Get
            Set
                Me.algorithmField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")>  _
    Partial Public Class SignedInfoTypeSignatureMethod
        
        Private algorithmField As String
        
        Public Sub New()
            MyBase.New
            Me.algorithmField = "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
        End Sub
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")>  _
        Public Property Algorithm() As String
            Get
                Return Me.algorithmField
            End Get
            Set
                Me.algorithmField = value
            End Set
        End Property
    End Class
End Namespace
