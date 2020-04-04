Namespace Classes
    Public Class Customer
        Public Property Identifier() As Integer
        Public Property Name() As String

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End NameSpace