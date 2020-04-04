Imports System.IO
Imports System.Text
Imports DeleteFileOnClose.Classes
Imports DeleteFileOnClose.LanguageExtensions

Public Class Form1
    Private test As FileStream

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim tempFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "K1".GenerateRandomXmlFile(5))
        Dim creator1 As FileStream = FileStreamDeleteOnClose(tempFileName)

        Dim xmlData =
        <?xml version="1.0" standalone="yes"?>
        <Customers>
            <Customer>
                <CustomerID>ALFKI</CustomerID>
                <CompanyName>Alfreds Futterkiste</CompanyName>
            </Customer>
            <Customer>
                <CustomerID>ANATR</CustomerID>
                <CompanyName>Ana Trujillo Emparedados y helados</CompanyName>
            </Customer>
            <Customer>
                <CustomerID>BOLID</CustomerID>
                <CompanyName>Bilido Comidas preparadas</CompanyName>
            </Customer>
            <Customer>
                <CustomerID>CENTC</CustomerID>
                <CompanyName>Centro comercial Moctezuma</CompanyName>
            </Customer>
        </Customers>

        Dim byteArray As Byte() = Encoding.ASCII.GetBytes(xmlData.ToString)
        creator1.Write(byteArray, 0, byteArray.Length)

        Dim streamReader As StreamReader
        streamReader = New StreamReader(creator1)
        streamReader.BaseStream.Seek(0, IO.SeekOrigin.Begin)

        Dim customerDataBuilder As New StringBuilder

        While (streamReader.Peek > -1)
            customerDataBuilder.Append(streamReader.ReadLine())
        End While

        Dim customers = (
                From customer In XDocument.Parse(customerDataBuilder.ToString())...<Customer>
                Select Name = customer.<CompanyName>.Value, Identifier = customer.<CustomerID>.Value
                ).ToList

        ' Show the customer we just read in
        For Each customerItem In customers
            Console.WriteLine($"ID=[{customerItem.Identifier}] Company [{ customerItem.Name}]")
        Next

        If File.Exists(tempFileName) Then
            MessageBox.Show("File exists until closes or crashes")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim operations As New FileOperations
        operations.DoSomeWork1()
    End Sub
End Class
