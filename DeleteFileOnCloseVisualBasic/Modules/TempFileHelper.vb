Imports System.IO
Imports System.Reflection

Namespace Modules

    Public Module TempFileHelper
        ''' <summary>
        ''' Create temp file name
        ''' </summary>
        ''' <param name="CreateNewFile">Physically create file</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Calling this method and create a file the next call will
        ''' increment one number higher and create a file. Calling
        ''' this method passing false will not increment as there are
        ''' no files to determine a next number
        ''' </remarks>
        Public Function CreateNewOutPutFile(Optional CreateNewFile As Boolean = True) As String
            Dim removeLeft As String = Assembly.GetExecutingAssembly().GetName().Name
            Const removeRight As String = ".txt"
            Dim searchString As String = removeLeft & "*" & removeRight
            Const numberSpecifier As String = "0000"

            Dim maxTempIndex As Integer = -1

            Dim fileName As String
            Dim files() As String = Directory.GetFiles(Directory.GetCurrentDirectory(), searchString)

            For Each file As String In files

                fileName = Path.GetFileName(file)

                Dim stripped As String = fileName.Remove(
                    fileName.Length - removeRight.Length,
                    removeRight.Length).Remove(0, removeLeft.Length)

                Dim current As Integer

                If Integer.TryParse(stripped, current) Then
                    If current > maxTempIndex Then
                        maxTempIndex = current
                    End If
                End If
            Next

            maxTempIndex += 1

            fileName = $"{removeLeft }{maxTempIndex.ToString(numberSpecifier) }{removeRight }"

            If CreateNewFile Then
                File.CreateText(fileName)
            End If


            Return fileName

        End Function
    End Module
End Namespace