Public Class Attachment

    Private _name As String
    Public ReadOnly Property name As String
        Get
            Return _name
        End Get
    End Property

    Private _type As String
    Public ReadOnly Property type As String
        Get
            Return (_type)
        End Get
    End Property

    Private _bytes() As Byte
    Public ReadOnly Property getBytes() As Byte()
        Get
            Return _bytes
        End Get
    End Property

    Public ReadOnly Property getString As String
        Get
            Return System.Text.Encoding.UTF8.GetString(_bytes)
        End Get
    End Property

    Public ReadOnly Property size As Integer
        Get
            Return _bytes.Length
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal bytes() As Byte, ByVal type As String)
        _name = name
        _bytes = bytes
        _type = type
    End Sub

    ''' <summary>
    ''' Saves the attachment to a file on disc
    ''' </summary>
    ''' <param name="fileName">The path + name of the file to be saved</param>
    ''' <param name="overwrite">Overwrites the existing file if exists</param>
    ''' <remarks></remarks>
    ''' 

    Public Sub saveToFile(ByVal fileName As String, ByVal overwrite As Boolean)

        Try

            If Not overwrite Then
                If IO.File.Exists(fileName) Then
                    Throw New Exception("Arquivo já existe")
                End If
            End If
            My.Computer.FileSystem.WriteAllBytes(fileName, Me.getBytes, False)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

End Class
