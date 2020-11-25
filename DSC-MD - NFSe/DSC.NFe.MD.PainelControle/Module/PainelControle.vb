Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions

Module PainelControle

    Public Const CP_CaptionMessageBox As String = "DSC - MD"
    Public Const CP_Image_Erro As String = "DSC_Button_Erro.png"
    Public Const CP_Image_OK As String = "DSC_Button_OK.png"
    Public Const CP_Cryptography_Key As String = "Manifestação do Destinatário DSC"

    Public Function IsEmailAddressValid(ByVal emailAddress As String) As Boolean

        ' Pattern ou mascara de verificação
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        ' Verifica se o email corresponde a pattern/mascara
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)

        Return (emailAddressMatch.Success)

    End Function

End Module

