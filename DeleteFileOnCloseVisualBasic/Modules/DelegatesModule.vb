Imports DeleteFileOnClose.Classes

Namespace Modules
    Public Module DelegatesModule
        Public Delegate Sub PeekEventHandler(sender As Object, e As PeekArgs)
        Public Delegate Sub CustomersEventHandler(sender As Object, e As CustomerArgs)
    End Module
End Namespace