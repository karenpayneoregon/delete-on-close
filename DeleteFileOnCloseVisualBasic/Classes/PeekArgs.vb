Namespace Classes
    Public Class PeekArgs
        Inherits EventArgs

        Private _message As String

        Public Sub New(message As String)
            _message = message

        End Sub
        Public ReadOnly Property Message As String
            Get
                Return _message
            End Get
        End Property
    End Class
End NameSpace