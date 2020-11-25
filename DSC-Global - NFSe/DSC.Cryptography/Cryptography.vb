Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

' Crédito - Fabrizio Gianfratti (http://www.imasters.com.br/artigo/4103/aspnet/criptografia_de_dados_128_bits/)

Public Class Cryptography

    ' ***************************************************************
    ' ***** Variável com a sua chave secreta                                                    
    ' ***** Sempre que o numero for alterado, a cifra será diferente                  
    ' ***** Pode ser passado até 32 caracteres                                                
    ' ***** Recomendo não deixar essa variável na sua aplicação, por                
    ' ***** mais estranho que possa ser, existem programas que tem a               
    ' ***** capacidade de ler a sua DLL, crie um arquivo texto com a                
    ' ***** sua chave e proteja essa pasta                                                           
    ' ***************************************************************

    ' ***************************************************************
    ' ***** Função responsável por Cifrar a sua String                                
    ' ***** Use da seguinte forma:                                                               
    ' ***** Call Cifrar("Palavra", "SuaChaveSecreta(Ex.2345)")                   
    ' ***************************************************************

    Public Shared Function Cifrar(ByVal vstrTextToBeEncrypted As String, ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte = Nothing
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged

        Try

            ' ****************************************************
            ' ****** Descarta todos os caracteres nulos da palavra a ser cifrada
            ' ****************************************************

            vstrTextToBeEncrypted = TiraCaracteresNulos(vstrTextToBeEncrypted)

            ' ****************************************************
            ' ****** O valor deve estar dentro da tabela ASCII (i.e., no DBCS chars)
            ' ****************************************************

            bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

            intLength = Len(vstrEncryptionKey)

            ' ****************************************************
            ' ****** A chave cifrada será de 256 bits long (32 bytes) 
            ' ****** Se for maior que 32 bytes então será truncado.
            ' ****** Se for menor que 32 bytes será alocado.  
            ' ****** Usando upper-case Xs.
            ' ****************************************************

            If intLength >= 32 Then
                vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
            Else
                intLength = Len(vstrEncryptionKey)
                intRemaining = 32 - intLength
                vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

            objRijndaelManaged = New RijndaelManaged

            ' *****************************************************
            ' ****** Cria o valor a ser crifrado e depois escreve 
            ' ****** Convertido em uma disposição do byte 
            ' *****************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
                objCryptoStream.Write(bytValue, 0, bytValue.Length)

                objCryptoStream.FlushFinalBlock()

                bytEncoded = objMemoryStream.ToArray
                objMemoryStream.Close()
                objCryptoStream.Close()
            Catch

            End Try

            ' *****************************************************
            ' ****** Retorna o valor cifrado (convertido de byte para base64)
            ' *****************************************************

            Return Convert.ToBase64String(bytEncoded)

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    ' **************************************************************
    ' ***** Função Responsável por Decifrar a sua String Cifrada                     
    ' ***** Use da seguinte forma:                                                                    
    ' ***** Call Decifrar ("Palavra", "SuaChaveSecreta(Ex.2345)")                   
    ' **************************************************************

    Public Shared Function Decifrar(ByVal vstrStringToBeDecrypted As String, ByVal vstrDecryptionKey As String) As String

        Dim bytDataToBeDecrypted() As Byte = Nothing
        Dim bytTemp() As Byte = Nothing
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim intCtr As Integer = Nothing
        Dim strReturnString As String = String.Empty
        Dim achrCharacterArray() As Char = Nothing
        Dim intIndex As Integer = Nothing

        Try

            ' *****************************************************
            ' ****** Convert base64 cifrada para byte array 
            ' ****** Convert base64 cifrada para byte array 
            ' *****************************************************

            bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

            ' *****************************************************
            ' ****** A chave cifrada sera de 256 bits long (32 bytes) 
            ' ****** Se for maior que 32 bytes então será truncado. 
            ' ****** Se for menor que 32 bytes será alocado. 
            ' ****** Usando upper-case Xs.
            ' *****************************************************

            intLength = Len(vstrDecryptionKey)

            If intLength >= 32 Then
                vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
            Else
                intLength = Len(vstrDecryptionKey)
                intRemaining = 32 - intLength
                vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

            ReDim bytTemp(bytDataToBeDecrypted.Length)

            objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

            ' ******************************************************
            ' ****** Escrever o valor decifrado depois que é convertido
            ' ******************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, _
                objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
                CryptoStreamMode.Read)

                objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

                objCryptoStream.FlushFinalBlock()
                objMemoryStream.Close()
                objCryptoStream.Close()

            Catch

            End Try

            ' ****************************************************
            ' ****** Retorna o valor decifrado
            ' ****************************************************

            Return TiraCaracteresNulos(Encoding.ASCII.GetString(bytTemp))

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    ' ***************************************************************
    ' ***** Função responsável por tirar os espaços em branco da                      
    ' ***** variável a ser cifrada                                                                          
    ' ***** Esta função é chamada internamente                                                  
    ' ***************************************************************

    Private Shared Function TiraCaracteresNulos(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String = ""

        Try

            intPosition = 1
            strStringWithOutNulls = vstrStringWithNulls

            Do While intPosition > 0
                intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

                If intPosition > 0 Then
                    strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                    Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
                End If

                If intPosition > strStringWithOutNulls.Length Then
                    Exit Do
                End If
            Loop

        Catch ex As Exception
            Throw ex

        End Try

        Return strStringWithOutNulls

    End Function

End Class
