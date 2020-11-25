Public Class Zip

    Private Const exeName As String = "7za.exe"

    Private Shared appPath As String = System.IO.Directory.GetCurrentDirectory()
    Private Shared exeFullPath As String = IO.Path.Combine(appPath, exeName)
    Private Shared logFileFullPath As String = IO.Path.Combine(appPath, "logZipFile.log")

    Private Shared Sub extractExe()
        My.Computer.FileSystem.WriteAllBytes(exeFullPath, My.Resources.ZipResource._7za, False)
    End Sub

    Private Shared Function isExeExtracted() As Boolean
        Return IO.File.Exists(exeFullPath)
    End Function

    Public Shared Sub extractFile(zipFileFullPath As String,
                                  fileFullPathInsideZip As String,
                                  pathToExtractTo As String)

        Try

            If Not isExeExtracted() Then
                extractExe()
            End If

            Dim psi As New ProcessStartInfo(exeFullPath)

            psi.WorkingDirectory = IO.Path.GetDirectoryName(appPath)
            psi.Arguments = " e """ & zipFileFullPath & """ -o" & """" & pathToExtractTo & """ """ & fileFullPathInsideZip & """ -r -y -p"

            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True
            psi.WindowStyle = ProcessWindowStyle.Hidden

            psi.StandardOutputEncoding = Text.ASCIIEncoding.ASCII
            psi.UseShellExecute = False
            psi.RedirectStandardError = True

            Dim p = Process.Start(psi)
            Dim conteudoArquivo As String = p.StandardOutput.ReadToEnd

            p.WaitForExit()

            psi = Nothing

            p.Dispose()
            p = Nothing

            System.Threading.Thread.Sleep(500)

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function listFiles(zipFilename As String) As List(Of File)

        If Not IO.File.Exists(zipFilename) Then
            Throw New Exception("ZIP File does not exists.")
        End If

        If Not isExeExtracted() Then
            extractExe()
        End If

        Dim psi As New ProcessStartInfo(exeFullPath)

        psi.WorkingDirectory = IO.Path.GetDirectoryName(appPath)
        psi.Arguments = " l """ & zipFilename & """"


        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True
        psi.WindowStyle = ProcessWindowStyle.Hidden

        psi.StandardOutputEncoding = Text.ASCIIEncoding.ASCII
        psi.UseShellExecute = False
        Dim p = Process.Start(psi)
        Dim conteudoArquivo As String = p.StandardOutput.ReadToEnd

        p.WaitForExit()

        'Lê arquivo Log

        Dim ch As Char

        If conteudoArquivo.Contains(Chr(13)) Then
            conteudoArquivo = conteudoArquivo.Replace(Chr(10), "")
            ch = Chr(13)
        Else
            conteudoArquivo = conteudoArquivo.Replace(Chr(13), "")
            ch = Chr(10)
        End If

        Dim result As New List(Of File)

        Dim linhas() As String = conteudoArquivo.Split(ch)
        Dim started As Boolean = False

        For Each linha In linhas
            If started Then
                If linha.StartsWith("-") Then
                    Return result
                Else
                    Dim sData As String = linha.Substring(0, 19)
                    Dim sAttr As String = linha.Substring(20, 5)
                    Dim sSize As String = linha.Substring(26, 12)
                    Dim sCompSize As String = linha.Substring(39, 12)
                    Dim filename As String = linha.Substring(53, linha.Length() - 53)

                    Dim d As Date = Date.Parse(sData)
                    Dim sz As Integer = Integer.Parse(sSize.Trim)
                    Dim cz As Integer = Integer.Parse(sCompSize.Trim)

                    If sAttr.EndsWith("A") Then 'Arquivo e não diretorio
                        result.Add(New File(filename, d, sAttr, sz, cz))
                    End If
                End If
            Else
                If linha = "------------------- ----- ------------ ------------  ------------------------" Then
                    started = True
                End If
            End If
        Next

        Return result

    End Function

    Class File

        Public FullPath As String

        Public ReadOnly Property Filename As String
            Get
                Return IO.Path.GetFileName(FullPath)
            End Get
        End Property

        Public ReadOnly Property Path As String
            Get
                Return IO.Path.GetDirectoryName(Filename)
            End Get
        End Property

        Public Data As Date
        Public Attr As String
        Public Size As Integer
        Public CompressedSize As Integer

        Sub New(fullPath As String,
                 Data As Date,
                 Attr As String,
                 Size As Integer,
                 CompressedSize As Integer)

            Me.FullPath = fullPath
            Me.Data = Data
            Me.Attr = Attr
            Me.Size = Size
            Me.CompressedSize = CompressedSize

        End Sub

    End Class

End Class
