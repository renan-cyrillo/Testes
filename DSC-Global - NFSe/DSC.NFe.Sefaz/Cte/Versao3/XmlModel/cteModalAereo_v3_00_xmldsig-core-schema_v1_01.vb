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
Namespace Cte.Versao3.XmlModel.cteModalAereo

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
    Partial Public Class aereo

        Private nMinuField As String

        Private nOCAField As String

        Private dPrevAereoField As String

        Private natCargaField As aereoNatCarga

        Private tarifaField As aereoTarifa

        Private periField() As aereoPeri

        '''<remarks/>
        Public Property nMinu() As String
            Get
                Return Me.nMinuField
            End Get
            Set(ByVal value As String)
                Me.nMinuField = value
            End Set
        End Property

        '''<remarks/>
        Public Property nOCA() As String
            Get
                Return Me.nOCAField
            End Get
            Set(ByVal value As String)
                Me.nOCAField = value
            End Set
        End Property

        '''<remarks/>
        Public Property dPrevAereo() As String
            Get
                Return Me.dPrevAereoField
            End Get
            Set(ByVal value As String)
                Me.dPrevAereoField = value
            End Set
        End Property

        '''<remarks/>
        Public Property natCarga() As aereoNatCarga
            Get
                Return Me.natCargaField
            End Get
            Set(ByVal value As aereoNatCarga)
                Me.natCargaField = value
            End Set
        End Property

        '''<remarks/>
        Public Property tarifa() As aereoTarifa
            Get
                Return Me.tarifaField
            End Get
            Set(ByVal value As aereoTarifa)
                Me.tarifaField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("peri")> _
        Public Property peri() As aereoPeri()
            Get
                Return Me.periField
            End Get
            Set(ByVal value As aereoPeri())
                Me.periField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class aereoNatCarga

        Private xDimeField As String

        Private cInfManuField() As aereoNatCargaCInfManu

        '''<remarks/>
        Public Property xDime() As String
            Get
                Return Me.xDimeField
            End Get
            Set(ByVal value As String)
                Me.xDimeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("cInfManu")> _
        Public Property cInfManu() As aereoNatCargaCInfManu()
            Get
                Return Me.cInfManuField
            End Get
            Set(ByVal value As aereoNatCargaCInfManu())
                Me.cInfManuField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum aereoNatCargaCInfManu

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("01")> _
        Item01

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("02")> _
        Item02

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("03")> _
        Item03

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("04")> _
        Item04

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("05")> _
        Item05

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("06")> _
        Item06

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("07")> _
        Item07

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("08")> _
        Item08

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("09")> _
        Item09

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("10")> _
        Item10

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
        <System.Xml.Serialization.XmlEnumAttribute("99")> _
        Item99
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class aereoTarifa

        Private clField As String

        Private cTarField As String

        Private vTarField As String

        '''<remarks/>
        Public Property CL() As String
            Get
                Return Me.clField
            End Get
            Set(ByVal value As String)
                Me.clField = value
            End Set
        End Property

        '''<remarks/>
        Public Property cTar() As String
            Get
                Return Me.cTarField
            End Get
            Set(ByVal value As String)
                Me.cTarField = value
            End Set
        End Property

        '''<remarks/>
        Public Property vTar() As String
            Get
                Return Me.vTarField
            End Get
            Set(ByVal value As String)
                Me.vTarField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class aereoPeri

        Private nONUField As String

        Private qTotEmbField As String

        Private infTotAPField As aereoPeriInfTotAP

        '''<remarks/>
        Public Property nONU() As String
            Get
                Return Me.nONUField
            End Get
            Set(ByVal value As String)
                Me.nONUField = value
            End Set
        End Property

        '''<remarks/>
        Public Property qTotEmb() As String
            Get
                Return Me.qTotEmbField
            End Get
            Set(ByVal value As String)
                Me.qTotEmbField = value
            End Set
        End Property

        '''<remarks/>
        Public Property infTotAP() As aereoPeriInfTotAP
            Get
                Return Me.infTotAPField
            End Get
            Set(ByVal value As aereoPeriInfTotAP)
                Me.infTotAPField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Partial Public Class aereoPeriInfTotAP

        Private qTotProdField As String

        Private uniAPField As aereoPeriInfTotAPUniAP

        '''<remarks/>
        Public Property qTotProd() As String
            Get
                Return Me.qTotProdField
            End Get
            Set(ByVal value As String)
                Me.qTotProdField = value
            End Set
        End Property

        '''<remarks/>
        Public Property uniAP() As aereoPeriInfTotAPUniAP
            Get
                Return Me.uniAPField
            End Get
            Set(ByVal value As aereoPeriInfTotAPUniAP)
                Me.uniAPField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
    Public Enum aereoPeriInfTotAPUniAP

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")> _
        Item1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2")> _
        Item2

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3")> _
        Item3

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("4")> _
        Item4

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("5")> _
        Item5
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
