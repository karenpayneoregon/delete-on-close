Imports System.IO
Imports System.Text
Imports DeleteFileOnClose.Classes
Imports DeleteFileOnClose.LanguageExtensions

Public Class Form1
    WithEvents fileOperations As New FileOperations

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
        fileOperations.QuickUse(people)

    End Sub

    Private Sub fileOperations_PeekEventHandler(sender As Object, e As PeekArgs) Handles fileOperations.PeekEventHandler
        MessageTextBox.AppendText($"{e.Message}{Environment.NewLine}")
    End Sub

    Private Sub fileOperations_CustomersEventHandler(sender As Object, e As CustomerArgs) Handles fileOperations.CustomersEventHandler
        For Each customer As Customer In e.Customers
            MessageTextBox.AppendText($"{customer.Identifier}, {customer.Name}{Environment.NewLine}")
        Next
    End Sub

End Class
