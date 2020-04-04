<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FirstTimePopulateFileButton = New System.Windows.Forms.Button()
        Me.ExamineFileButton = New System.Windows.Forms.Button()
        Me.AddCustomerToFileButton = New System.Windows.Forms.Button()
        Me.AddPersonToFileButton = New System.Windows.Forms.Button()
        Me.MessageTextBox = New System.Windows.Forms.TextBox()
        Me.CustomerNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'FirstTimePopulateFileButton
        '
        Me.FirstTimePopulateFileButton.Location = New System.Drawing.Point(12, 12)
        Me.FirstTimePopulateFileButton.Name = "FirstTimePopulateFileButton"
        Me.FirstTimePopulateFileButton.Size = New System.Drawing.Size(169, 23)
        Me.FirstTimePopulateFileButton.TabIndex = 0
        Me.FirstTimePopulateFileButton.Text = "First time populate file"
        Me.FirstTimePopulateFileButton.UseVisualStyleBackColor = True
        '
        'ExamineFileButton
        '
        Me.ExamineFileButton.Location = New System.Drawing.Point(12, 41)
        Me.ExamineFileButton.Name = "ExamineFileButton"
        Me.ExamineFileButton.Size = New System.Drawing.Size(169, 23)
        Me.ExamineFileButton.TabIndex = 1
        Me.ExamineFileButton.Text = "Examine file"
        Me.ExamineFileButton.UseVisualStyleBackColor = True
        '
        'AddCustomerToFileButton
        '
        Me.AddCustomerToFileButton.Location = New System.Drawing.Point(12, 70)
        Me.AddCustomerToFileButton.Name = "AddCustomerToFileButton"
        Me.AddCustomerToFileButton.Size = New System.Drawing.Size(169, 23)
        Me.AddCustomerToFileButton.TabIndex = 2
        Me.AddCustomerToFileButton.Text = "Add Customer to file"
        Me.AddCustomerToFileButton.UseVisualStyleBackColor = True
        '
        'AddPersonToFileButton
        '
        Me.AddPersonToFileButton.Location = New System.Drawing.Point(12, 99)
        Me.AddPersonToFileButton.Name = "AddPersonToFileButton"
        Me.AddPersonToFileButton.Size = New System.Drawing.Size(169, 23)
        Me.AddPersonToFileButton.TabIndex = 3
        Me.AddPersonToFileButton.Text = "Add person to file"
        Me.AddPersonToFileButton.UseVisualStyleBackColor = True
        '
        'MessageTextBox
        '
        Me.MessageTextBox.Location = New System.Drawing.Point(12, 152)
        Me.MessageTextBox.Multiline = True
        Me.MessageTextBox.Name = "MessageTextBox"
        Me.MessageTextBox.Size = New System.Drawing.Size(293, 205)
        Me.MessageTextBox.TabIndex = 4
        '
        'CustomerNameTextBox
        '
        Me.CustomerNameTextBox.Location = New System.Drawing.Point(196, 70)
        Me.CustomerNameTextBox.Name = "CustomerNameTextBox"
        Me.CustomerNameTextBox.Size = New System.Drawing.Size(109, 20)
        Me.CustomerNameTextBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Event output"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 371)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CustomerNameTextBox)
        Me.Controls.Add(Me.MessageTextBox)
        Me.Controls.Add(Me.AddPersonToFileButton)
        Me.Controls.Add(Me.AddCustomerToFileButton)
        Me.Controls.Add(Me.ExamineFileButton)
        Me.Controls.Add(Me.FirstTimePopulateFileButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Temp self-delete files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FirstTimePopulateFileButton As Button
    Friend WithEvents ExamineFileButton As Button
    Friend WithEvents AddCustomerToFileButton As Button
    Friend WithEvents AddPersonToFileButton As Button
    Friend WithEvents MessageTextBox As TextBox
    Friend WithEvents CustomerNameTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
