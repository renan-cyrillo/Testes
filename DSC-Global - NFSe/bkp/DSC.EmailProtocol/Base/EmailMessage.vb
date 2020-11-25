Public Class EmailMessage
    Public Property [subject] As String
    Public Property [from] As String
    Public Property [to] As String
    Public Property [content] As String
    Public Property [attachments] As New List(Of attachment)

    Sub New(ByVal subject As String, ByVal [from] As String, ByVal [to] As String, ByVal content As String, ByVal attachments As List(Of attachment))
        _subject = subject
        _from = [from]
        _to = [to]
        _content = content
        _attachments = attachments
    End Sub

End Class