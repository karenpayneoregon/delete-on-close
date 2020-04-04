Imports System.IO
Imports System.Text
Imports DeleteFileOnClose.LanguageExtensions
Imports DeleteFileOnClose.Modules

Namespace Classes
    Public Class FileOperations

        Public Event PeekEventHandler As PeekEventHandler
        Public Event CustomersEventHandler As CustomersEventHandler

        Private _creator1 As FileStream

        ''' <summary>
        ''' Setup FileStream with a random file name marked
        ''' to remove on app crash or normal close of app.
        ''' </summary>
        Public Sub New()

            _creator1 = FileStreamDeleteOnClose(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "K1".GenerateRandomXmlFile(5)))

        End Sub
        Public Sub QuickUse(peopleList As List(Of Person))

            Dim fileName = Path.GetTempFileName()

            RaiseEvent PeekEventHandler(Me, New PeekArgs($"Temporary file name: {fileName}"))
            RaiseEvent PeekEventHandler(Me, New PeekArgs(""))

            Using fileStream = New FileStream(fileName,
                                              FileMode.Open,
                                              FileAccess.ReadWrite,
                                              FileShare.None,
                                              4096,
                                              FileOptions.DeleteOnClose)

                Using streamWriter = New StreamWriter(fileStream)

                    '
                    ' Write each person comma delimited
                    '
                    For index As Integer = 0 To peopleList.Count - 1
                        streamWriter.WriteLine($"{peopleList(index).FirstName},{peopleList(index).LastName}")
                    Next

                    streamWriter.Flush()

                    '
                    ' Read data back
                    '

                    Dim streamReader As StreamReader

                    streamReader = New StreamReader(fileStream)
                    streamReader.BaseStream.Seek(0, SeekOrigin.Begin)

                    While (streamReader.Peek > -1)

                        Dim nameParts = streamReader.ReadLine().Split(","c)

                        RaiseEvent PeekEventHandler(
                            Me, New PeekArgs($"{nameParts(0)} - {nameParts(1)}"))

                    End While

                End Using

            End Using

        End Sub
        ''' <summary>
        ''' Initial population of file
        ''' </summary>
        Public Sub PopulateTempFile()
            Dim xmlData As XDocument =
                    <?xml version="1.0" standalone="yes"?>
                    <Customers>
                        <Customer>
                            <CustomerID>100</CustomerID>
                            <CompanyName>Alfreds Futterkiste</CompanyName>
                        </Customer>
                        <Customer>
                            <CustomerID>101</CustomerID>
                            <CompanyName>Ana Trujillo Emparedados y helados</CompanyName>
                        </Customer>
                        <Customer>
                            <CustomerID>102</CustomerID>
                            <CompanyName>Bilido Comidas preparadas</CompanyName>
                        </Customer>
                        <Customer>
                            <CustomerID>103</CustomerID>
                            <CompanyName>Centro comercial Moctezuma</CompanyName>
                        </Customer>
                    </Customers>

            Dim byteArray As Byte() = Encoding.ASCII.GetBytes(xmlData.ToString)

            _creator1.Write(byteArray, 0, byteArray.Length)

        End Sub
        ''' <summary>
        ''' Add a new Customer to the file then read the
        ''' file contents back
        ''' </summary>
        ''' <param name="newCustomer"></param>
        Public Sub AddNewCustomer(newCustomer As Customer)
            If _creator1.Length = 0 Then
                PopulateTempFile()
            End If

            _creator1.Position = 0

            Dim streamReader As StreamReader
            streamReader = New StreamReader(_creator1)
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin)

            Dim customerDataBuilder As New StringBuilder

            While (streamReader.Peek > -1)
                customerDataBuilder.Append(streamReader.ReadLine())
            End While


            Dim customersLambdaTyped = (
                    From customer In XDocument.Parse(customerDataBuilder.ToString())...<Customer>).
                    Select(Function(customer)
                               Return New Customer With {
                              .Name = customer.<CompanyName>.Value,
                              .Identifier = CInt(customer.<CustomerID>.Value)}
                           End Function).ToList()


            '
            ' Get last identifier and increment by 1
            ' Since we have an exclusive lock there are no 
            ' issues of colliding with another section of code
            ' grabbing the same identifier
            '
            Dim id = customersLambdaTyped.Select(Function(customer) customer.Identifier).Max() + 1

            newCustomer.Identifier = id

            '
            ' Add customer to existing list
            '
            customersLambdaTyped.Add(newCustomer)

            '
            ' Transform to XML using xml literals and embedded expressions
            '
            Dim doc As XDocument =
                    <?xml version="1.0" standalone="yes"?>
                    <Customers><%= From currentCustomer In customersLambdaTyped Select
                        <Customer>
                            <CustomerID><%= currentCustomer.Identifier %></CustomerID>
                            <CompanyName><%= currentCustomer.Name %></CompanyName>
                        </Customer> %>
                    </Customers>

            doc.Declaration.Version = "1.0"
            doc.Declaration.Encoding = "utf-8"

            '
            ' Rewrite the file rather than appending
            '
            Dim byteArray As Byte() = Encoding.ASCII.GetBytes(doc.ToString)
            _creator1.SetLength(0)
            _creator1.Write(byteArray, 0, byteArray.Length)

            ExamineCustomersFromXmlFile()

        End Sub
        Public Sub ExamineCustomersFromXmlFile()

            If _creator1.Length = 0 Then
                PopulateTempFile()
            End If

            '
            ' Rewind to start of temporary file
            '
            _creator1.Position = 0

            '
            ' Read data from  temporary file into a StringBuilder
            ' to parse into either a anonymous type or strong typed
            ' list.
            '
            Dim streamReader As StreamReader
            streamReader = New StreamReader(_creator1)
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin)

            Dim customerDataBuilder As New StringBuilder

            While (streamReader.Peek > -1)
                customerDataBuilder.Append(streamReader.ReadLine())
            End While

            '
            ' Example of reading data anonymously and strong typed
            '


            Dim customersLinqAnonymous = (
                    From customer In XDocument.Parse(customerDataBuilder.ToString())...<Customer>
                    Select
                        Name = customer.<CompanyName>.Value,
                        Identifier = CInt(customer.<CustomerID>.Value)
                    ).ToList

            Dim customersLambdaTyped = (
                    From customer In XDocument.Parse(customerDataBuilder.ToString())...<Customer>).
                    Select(Function(customer)
                               Return New Customer With {
                                  .Name = customer.<CompanyName>.Value,
                                  .Identifier = CInt(customer.<CustomerID>.Value)}
                           End Function).ToList()



            RaiseEvent CustomersEventHandler(Me, New CustomerArgs(customersLambdaTyped))

        End Sub

    End Class
End Namespace