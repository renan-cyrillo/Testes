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
Namespace Cte.Versao3.XmlModel.retConsSitCTe

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
     System.Xml.Serialization.XmlRootAttribute("retConsSitCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
    Partial Public Class TRetConsSitCTe

        Private tpAmbField As TAmb

        Private verAplicField As String

        Private cStatField As String

        Private xMotivoField As String

        Private cUFField As TCodUfIBGE

        Private itemField As Object

        Private procEventoCTeField() As TRetConsSitCTeProcEventoCTe

        Private versaoField As String

        '''<remarks/>
        Public Property tpAmb() As TAmb
            Get
                Return Me.tpAmbField
            End Get
            Set(ByVal value As TAmb)
                Me.tpAmbField = value
            End Set
        End Property

        '''<remarks/>
        Public Property verAplic() As String
            Get
                Return Me.verAplicField
            End Get
            Set(ByVal value As String)
                Me.verAplicField = value
            End Set
        End Property

        '''<remarks/>
        Public Property cStat() As String
            Get
                Return Me.cStatField
            End Get
            Set(ByVal value As String)
                Me.cStatField = value
            End Set
        End Property

        '''<remarks/>
        Public Property xMotivo() As String
            Get
                Return Me.xMotivoField
            End Get
            Set(ByVal value As String)
                Me.xMotivoField = value
            End Set
        End Property

        '''<remarks/>
        Public Property cUF() As TCodUfIBGE
            Get
                Return Me.cUFField
            End Get
            Set(ByVal value As TCodUfIBGE)
                Me.cUFField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("protCTe", GetType(TRetConsSitCTeProtCTe)), _
         System.Xml.Serialization.XmlElementAttribute("retCancCTe", GetType(TRetConsSitCTeRetCancCTe))> _
        Public Property Item() As Object
            Get
                Return Me.itemField
            End Get
            Set(ByVal value As Object)
                Me.itemField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("procEventoCTe")> _
        Public Property procEventoCTe() As TRetConsSitCTeProcEventoCTe()
            Get
                Return Me.procEventoCTeField
            End Get
            Set(ByVal value As TRetConsSitCTeProcEventoCTe())
                Me.procEventoCTeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property versao() As String
            Get
                Return Me.versaoField
            End Get
            Set(ByVal value As String)
                Me.versaoField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum TAmb

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")> _
        Item1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2")> _
        Item2
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum TCodUfIBGE

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("11")> _
        Item11

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("12")> _
        Item12

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("13")> _
        Item13

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("14")> _
        Item14

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("15")> _
        Item15

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("16")> _
        Item16

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("17")> _
        Item17

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("21")> _
        Item21

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("22")> _
        Item22

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("23")> _
        Item23

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("24")> _
        Item24

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("25")> _
        Item25

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("26")> _
        Item26

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("27")> _
        Item27

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("28")> _
        Item28

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("29")> _
        Item29

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("31")> _
        Item31

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("32")> _
        Item32

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("33")> _
        Item33

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("35")> _
        Item35

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("41")> _
        Item41

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("42")> _
        Item42

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("43")> _
        Item43

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("50")> _
        Item50

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("51")> _
        Item51

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("52")> _
        Item52

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("53")> _
        Item53
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class TRetConsSitCTeProtCTe

        Private anyField As System.Xml.XmlElement

        Private versaoField As TRetConsSitCTeProtCTeVersao

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyElementAttribute()> _
        Public Property Any() As System.Xml.XmlElement
            Get
                Return Me.anyField
            End Get
            Set(ByVal value As System.Xml.XmlElement)
                Me.anyField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property versao() As TRetConsSitCTeProtCTeVersao
            Get
                Return Me.versaoField
            End Get
            Set(ByVal value As TRetConsSitCTeProtCTeVersao)
                Me.versaoField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum TRetConsSitCTeProtCTeVersao

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1.03")> _
        Item103

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1.04")> _
        Item104

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2.00")> _
        Item200

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3.00")> _
        Item300
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class TRetConsSitCTeRetCancCTe

        Private anyField As System.Xml.XmlElement

        Private versaoField As TRetConsSitCTeRetCancCTeVersao

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyElementAttribute()> _
        Public Property Any() As System.Xml.XmlElement
            Get
                Return Me.anyField
            End Get
            Set(ByVal value As System.Xml.XmlElement)
                Me.anyField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property versao() As TRetConsSitCTeRetCancCTeVersao
            Get
                Return Me.versaoField
            End Get
            Set(ByVal value As TRetConsSitCTeRetCancCTeVersao)
                Me.versaoField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum TRetConsSitCTeRetCancCTeVersao

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1.03")> _
        Item103

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1.04")> _
        Item104
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class TRetConsSitCTeProcEventoCTe

        Private anyField As System.Xml.XmlElement

        Private versaoField As TRetConsSitCTeProcEventoCTeVersao

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyElementAttribute()> _
        Public Property Any() As System.Xml.XmlElement
            Get
                Return Me.anyField
            End Get
            Set(ByVal value As System.Xml.XmlElement)
                Me.anyField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property versao() As TRetConsSitCTeProcEventoCTeVersao
            Get
                Return Me.versaoField
            End Get
            Set(ByVal value As TRetConsSitCTeProcEventoCTeVersao)
                Me.versaoField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum TRetConsSitCTeProcEventoCTeVersao

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1.04")> _
        Item104

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2.00")> _
        Item200

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3.00")> _
        Item300
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#"), _
     System.Xml.Serialization.XmlRootAttribute("Signature", [Namespace]:="http://www.w3.org/2000/09/xmldsig#", IsNullable:=False)> _
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
            Set(ByVal value As SignedInfoType)
                Me.signedInfoField = value
            End Set
        End Property

        '''<remarks/>
        Public Property SignatureValue() As SignatureValueType
            Get
                Return Me.signatureValueField
            End Get
            Set(ByVal value As SignatureValueType)
                Me.signatureValueField = value
            End Set
        End Property

        '''<remarks/>
        Public Property KeyInfo() As KeyInfoType
            Get
                Return Me.keyInfoField
            End Get
            Set(ByVal value As KeyInfoType)
                Me.keyInfoField = value
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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
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
            Set(ByVal value As SignedInfoTypeCanonicalizationMethod)
                Me.canonicalizationMethodField = value
            End Set
        End Property

        '''<remarks/>
        Public Property SignatureMethod() As SignedInfoTypeSignatureMethod
            Get
                Return Me.signatureMethodField
            End Get
            Set(ByVal value As SignedInfoTypeSignatureMethod)
                Me.signatureMethodField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Reference() As ReferenceType
            Get
                Return Me.referenceField
            End Get
            Set(ByVal value As ReferenceType)
                Me.referenceField = value
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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignedInfoTypeCanonicalizationMethod

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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignedInfoTypeSignatureMethod

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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class ReferenceType

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
            End Set
        End Property

        '''<remarks/>
        Public Property DigestMethod() As ReferenceTypeDigestMethod
            Get
                Return Me.digestMethodField
            End Get
            Set(ByVal value As ReferenceTypeDigestMethod)
                Me.digestMethodField = value
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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class TransformType

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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class ReferenceTypeDigestMethod

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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class SignatureValueType

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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class KeyInfoType

        Private x509DataField As X509DataType

        Private idField As String

        '''<remarks/>
        Public Property X509Data() As X509DataType
            Get
                Return Me.x509DataField
            End Get
            Set(ByVal value As X509DataType)
                Me.x509DataField = value
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
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Partial Public Class X509DataType

        Private x509CertificateField() As Byte

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
        Public Property X509Certificate() As Byte()
            Get
                Return Me.x509CertificateField
            End Get
            Set(ByVal value As Byte())
                Me.x509CertificateField = value
            End Set
        End Property
    End Class
End Namespace
