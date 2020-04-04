Namespace Classes
    Public Class CustomerArgs
        Inherits EventArgs

        Private _customerList As List(Of Customer)

        Public Sub New(customerList As List(Of Customer))
            _customerList = customerList
        End Sub
        Public ReadOnly Property Customers As List(Of Customer)
            Get
                Return _customerList
            End Get
        End Property
    End Class
End NameSpace