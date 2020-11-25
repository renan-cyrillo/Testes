Friend Class StringFunctions

    Friend Shared Function getTextBetweenWords(ByVal text As String,
                                               ByVal startingWord As String,
                                               ByVal endingWord As String,
                                               Optional ByVal includeStartingWord As Boolean = False,
                                               Optional ByVal includeEndingWord As Boolean = False,
                                               Optional ByVal ignoreCase As Boolean = True) As String

        Dim i As Integer
        Dim e As Integer

        If ignoreCase Then
            i = text.IndexOf(startingWord, comparisonType:=StringComparison.OrdinalIgnoreCase)
            e = text.IndexOf(endingWord, i + startingWord.Length + 1, comparisonType:=StringComparison.OrdinalIgnoreCase)
        Else
            i = text.IndexOf(startingWord)
            e = text.IndexOf(endingWord, i + startingWord.Length + 1)
        End If

        If i < 0 Or e < 0 Then Return ""

        If Not includeStartingWord Then i += startingWord.Length
        If includeEndingWord Then e += endingWord.Length

        Return text.Substring(i, e - i)

    End Function

    Friend Shared Function splitText(ByVal text As String, ByVal splitCharacter As Char) As String()
        Dim charArray As Char() = text.ToCharArray
        Dim acc As String = ""
        Dim l As New List(Of String)
        For i = 0 To text.Length - 1
            Select Case charArray(i)
                Case """"
                    acc &= charArray(i)
                    i += 1
                    While charArray(i) <> """"
                        acc &= charArray(i)
                        i += 1
                    End While
                    acc &= charArray(i)
                    i += 1
                Case "'"
                    acc &= charArray(i)
                    i += 1
                    While charArray(i) <> "'"
                        acc &= charArray(i)
                        i += 1
                    End While
                    acc &= charArray(i)
                    i += 1
                Case splitCharacter, vbCr, vbLf
                    l.Add(acc)
                    acc = ""
                Case Else
                    acc &= charArray(i)
            End Select

        Next

        If acc <> "" Then
            l.Add(acc)
        End If

        Return l.ToArray

    End Function

End Class
