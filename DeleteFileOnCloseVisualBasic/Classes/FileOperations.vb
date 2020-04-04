Imports System.IO
Imports System.Text
Imports DeleteFileOnClose.LanguageExtensions

Namespace Classes
    Public Class FileOperations
        Private Creator1 As FileStream

        Public Sub New()

            Creator1 = FileStreamDeleteOnClose(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "K1".GenerateRandomXmlFile(5)))

        End Sub
        Public Sub DoSomeWork1()
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
            Creator1.Write(byteArray, 0, byteArray.Length)

            Dim streamReader As StreamReader
            streamReader = New StreamReader(Creator1)
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

        End Sub
    End Class
End Namespace