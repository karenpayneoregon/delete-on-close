Imports System.IO

Namespace LanguageExtensions
    Public Module ExtensionsMethods
        ''' <summary>
        ''' Creates a file stream which will be removed from disk when the application closes
        ''' </summary>
        ''' <param name="fileName"></param>
        ''' <returns>FileStream marked for removal when app closes</returns>
        ''' <remarks></remarks>
        Public Function FileStreamDeleteOnClose(fileName As String) As FileStream

            Dim fileStream As New FileStream(
                fileName,
                FileMode.Create,
                Security.AccessControl.FileSystemRights.Modify,
                FileShare.None,
                8,
                FileOptions.DeleteOnClose)

            File.SetAttributes(
                fileStream.Name,
                File.GetAttributes(fileStream.Name) Or
                FileAttributes.Temporary)

            Return fileStream

        End Function
        <DebuggerStepThrough()>
        <Runtime.CompilerServices.Extension()>
        Public Function GenerateRandomXmlFile(sender As String, length As Integer) As String
            Return sender & GenerateRandomBaseName(length) & ".XML"
        End Function
        <DebuggerStepThrough()>
        Private Function GenerateRandomBaseName(length As Integer) As String

            Dim rand = New Random()

            Return CStr(Enumerable.Range(0, length).
                Select(Function(index) (Chr(Asc("A") + rand.Next(0, 26)))).
                ToArray)

        End Function

    End Module
End Namespace