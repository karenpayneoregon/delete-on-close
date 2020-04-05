Imports System.IO
Imports System.Text
Imports DeleteFileOnClose.Classes
Imports DeleteFileOnClose.LanguageExtensions
Imports DeleteFileOnClose.Modules

Public Class Form1
    WithEvents fileOperations As New FileOperations
    Private crashFileName As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Crashed.txt")


    Private Sub FirstTimePopulateFileButton_Click(sender As Object, e As EventArgs) Handles FirstTimePopulateFileButton.Click
        fileOperations.PopulateTempFile()
        FirstTimePopulateFileButton.Enabled = False
    End Sub

    Private Sub ExamineFileButton_Click(sender As Object, e As EventArgs) Handles ExamineFileButton.Click
        MessageTextBox.Text = ""
        fileOperations.ExamineCustomersFromXmlFile()
    End Sub

    Private Sub AddCustomerToFileButton_Click(sender As Object, e As EventArgs) Handles AddCustomerToFileButton.Click
        If Not String.IsNullOrWhiteSpace(CustomerNameTextBox.Text) Then
            MessageTextBox.Text = ""
            fileOperations.AddNewCustomer(New Customer() With {.Name = CustomerNameTextBox.Text})
        Else
            MessageBox.Show("Requires a name")
        End If
    End Sub

    Private Sub AddPersonToFileButton_Click(sender As Object, e As EventArgs) Handles AddPersonToFileButton.Click

        Dim people As New List(Of Person) From {
                New Person() With {.FirstName = "Mary", .LastName = "Frank"},
                New Person() With {.FirstName = "Jim", .LastName = "Gallagher"}
                }

        MessageTextBox.Text = ""
        fileOperations.QuickUse(people, FaileFastCheckBox.Checked)

    End Sub

    Private Sub fileOperations_PeekEventHandler(sender As Object, e As PeekArgs) Handles fileOperations.PeekEventHandler
        MessageTextBox.AppendText($"{e.Message}{Environment.NewLine}")
    End Sub

    Private Sub fileOperations_CustomersEventHandler(sender As Object, e As CustomerArgs) Handles fileOperations.CustomersEventHandler
        For Each customer As Customer In e.Customers
            MessageTextBox.AppendText($"{customer.Identifier}, {customer.Name}{Environment.NewLine}")
        Next
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If File.Exists(crashFileName) Then
            MessageBox.Show("Cleaning up from crash")
            File.Delete(crashFileName)
        End If

        If Debugger.IsAttached Then
            '
            ' Crash example works best outside the IDE
            ' to get the full experience 
            '
            CrashButton.Enabled = False
        End If
    End Sub

    Private Sub CrashButton_Click(sender As Object, e As EventArgs) Handles CrashButton.Click

        fileOperations.Crash("Line one")

        For i As Integer = 0 To 3
            Console.WriteLine(TempFileHelper.CreateNewOutPutFile())
        Next
    End Sub
End Class
