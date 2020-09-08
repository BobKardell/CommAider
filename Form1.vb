Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(IO.File.ReadAllLines("CommandKeeper.txt"))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim scriptform As New RunScript

        scriptform.Show()


    End Sub
End Class
