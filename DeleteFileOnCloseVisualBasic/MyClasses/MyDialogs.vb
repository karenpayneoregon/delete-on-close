Namespace My
    <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
    Partial Friend Class _Dialogs
        Private Function CreateLineBreaks(ByVal Text As String) As String
            Return Text.Replace("~", Environment.NewLine)
        End Function
        ''' <summary>
        ''' Ask question with NO as the default button
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Question(ByVal Text As String) As Boolean
            Return (MessageBox.Show(CreateLineBreaks(Text), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
    End Class
    <Global.Microsoft.VisualBasic.HideModuleName()>
    Friend Module KSG_Dialogs
        Private instance As New ThreadSafeObjectProvider(Of _Dialogs)
        ReadOnly Property Dialogs() As _Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
