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
'This source code was auto-generated by xsd, Version=4.6.1055.0.
'
Namespace Nfe.Versao1.XmlModel.ConsNFeDest12

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
    Partial Public Class distDFeInt

        '''<remarks/>
        Public tpAmb As TAmb

        '''<remarks/>
        Public cUFAutor As TCodUfIBGE

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public cUFAutorSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
         System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
         System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
        Public Item As String

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public ItemElementName As ItemChoiceType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("consChNFe", GetType(distDFeIntConsChNFe)), _
         System.Xml.Serialization.XmlElementAttribute("consNSU", GetType(distDFeIntConsNSU)), _
         System.Xml.Serialization.XmlElementAttribute("distNSU", GetType(distDFeIntDistNSU))> _
        Public Item1 As Object

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public versao As TVerDistDFe
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Public Enum TAmb

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")> _
        Item1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2")> _
        Item2
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IncludeInSchema:=False)> _
    Public Enum ItemChoiceType

        '''<remarks/>
        CNPJ

        '''<remarks/>
        CPF
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Partial Public Class distDFeIntConsChNFe

        '''<remarks/>
        Public chNFe As String
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Partial Public Class distDFeIntConsNSU

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public NSU As String
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Partial Public Class distDFeIntDistNSU

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="token")> _
        Public ultNSU As String
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
    Public Enum TVerDistDFe

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1.01")> _
        Item101
    End Enum
End Namespace