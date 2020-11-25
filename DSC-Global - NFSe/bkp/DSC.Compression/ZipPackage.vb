Imports System.IO.Compression
Imports System.IO.Packaging
Imports System.IO

Public Class ZipPackage

    Public Shared Sub AddToZipFile(zipFilename As String, filenameToAdd As String)

        Using zipPackage__1 As Package = System.IO.Packaging.ZipPackage.Open(zipFilename, FileMode.OpenOrCreate)

            Dim destFilename As String = ".\" + Path.GetFileName(filenameToAdd)

            Dim zipPartUri As Uri = PackUriHelper.CreatePartUri(New Uri(destFilename, UriKind.Relative))

            If zipPackage__1.PartExists(zipPartUri) Then
                zipPackage__1.DeletePart(zipPartUri)
            End If

            Dim zipPackagePart As PackagePart = zipPackage__1.CreatePart(zipPartUri, "", CompressionOption.Normal)

            Using fileStream As New FileStream(filenameToAdd, FileMode.Open, FileAccess.Read)
                Using dest As Stream = zipPackagePart.GetStream()
                    CopyStream(fileStream, dest)
                End Using
            End Using

        End Using

    End Sub

    'Copy one stream data to another
    Private Shared Sub CopyStream(source As Stream, target As Stream)
        Const bufSize As Integer = &H1000
        Dim buf As Byte() = New Byte(bufSize - 1) {}
        Dim bytesRead As Integer = 1

        While bytesRead > 0
            bytesRead = source.Read(buf, 0, bufSize)
            target.Write(buf, 0, bytesRead)
        End While

    End Sub

End Class
