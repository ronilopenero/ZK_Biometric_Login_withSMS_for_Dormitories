Public Class Enrollment_Form
    Dim sqlBuilder As New ConnectDB

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim choice As Integer
        Dim genChoice As Integer
        If (RadioButton1.Checked = True) Then
            genChoice = 0
        Else
            genChoice = 1
        End If
        choice = MsgBox("Are all information entered correct?", MsgBoxStyle.YesNo, "Save Data")
        If (choice = vbYes) Then
            sqlBuilder.insertUserInfo(TextBox3.Text.ToString(), TextBox1.Text.ToString(), genChoice.ToString(), TextBox2.Text.ToString(), TextBox4.Text.ToString())
            MsgBox("Information Saved")
            Me.Close()
            Form1.Show()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class