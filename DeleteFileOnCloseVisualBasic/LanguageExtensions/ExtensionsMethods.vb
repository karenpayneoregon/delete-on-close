Imports System.IO

Namespace LanguageExtensions
    Public Module ExtensionsMethods
        ''' <summary>
        ''' Creates a file stream which will be removed from disk when the application closes
        ''' </summary>
        ''' <param name="FileName"></param>
        ''' <returns>FileStream marked for removal when app closes</returns>
        ''' <remarks></remarks>
        Public Function FileStreamDeleteOnClose(FileName As String) As FileStream

            Dim fileStream As New FileStream(
                FileName,
                FileMode.Create,
                Security.AccessControl.FileSystemRights.Modify,
                FileShare.None,
                8,
                FileOptions.DeleteOnClose)

            File.SetAttributes(
                fileStream.Name,
                File.GetAttributes(fileStream.Name) Or FileAttributes.Temporary)

            Return fileStream

        End Function
        <DebuggerStepThrough()>
        <Runtime.CompilerServices.Extension()>
        Public Function GenerateRandomXmlFile(sender As String, Length As Integer) As String
            Return sender & GenerateRandomBaseName(Length) & ".XML"
        End Function
        <DebuggerStepThrough()>
        Private Function GenerateRandomBaseName(Length As Integer) As String
            Dim rand As Random = New Random()
            Return CStr(Enumerable.Range(0, Length).Select(Function(i) (Chr(Asc("A") + rand.Next(0, 26)))).ToArray)
        End Function

    End Module
End Namespace