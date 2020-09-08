Imports System.Text.RegularExpressions

Public Class RunScript
    Private Sub RunScript_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Form1.ComboBox1.Text

        Dim list As New List(Of String)
        Dim matches As MatchCollection = Regex.Matches(TextBox1.Text, "\[\w+\]")

        For Each m As Match In matches
            List.Add(m.Value)
        Next

        list = list.Distinct.ToList

        Dim newbox As TextBox
        Dim newlabel As Label

        For i As Integer = 1 To list.Count

            'create a new textbox and set its properties
            newlabel = New Label
            newlabel.Size = New Drawing.Size(190, 30)
            newlabel.Location = New System.Drawing.Point(10, 45 + (35 * (i - 1)))
            newlabel.Name = "Label" & i
            newlabel.Text = list(i - 1)

            newbox = New TextBox
            newbox.Size = New Drawing.Size(190, 30)
            newbox.Location = New System.Drawing.Point(200, 45 + (35 * (i - 1)))
            newbox.Name = "TextBox" & i
            'newbox.Text = list(i - 1)

            'connect it to a handler, save a reference to the array and add it to the form controls

            'AddHandler newbox.TextChanged, AddressOf newbox_TextChanged
            'boxes(i) = newbox

            AddHandler newbox.TextChanged, AddressOf newbox_TextChanged

            Panel1.Controls.Add(newlabel)
            Panel1.Controls.Add(newbox)

        Next

    End Sub
    Private Sub newbox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim matches As MatchCollection = Regex.Matches(TextBox1.Text, "\[\w+\]")
        'MsgBox(matches.Count)
        'Dim list As New List(Of String)

        'For Each m As Match In matches
        'list.Add(m.Value)
        'Next

        'list = list.Distinct.ToList


        'For i As Integer = 1 To list.Count
        Dim tb_value As String
        Dim lb_value As String
        Dim i As String
        i = Strings.Right(Me.ActiveControl.Name, 1)

        Dim textboxvalue As TextBox = CType(Panel1.Controls("TextBox" & i), TextBox)
            tb_value = textboxvalue.Text
            Dim labelvalue As Label = CType(Panel1.Controls("Label" & i), Label)
            lb_value = labelvalue.Text

            TextBox2.Text = Replace(TextBox1.Text, lb_value, tb_value)

            Me.Refresh()
        'Next


    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Shell("com.exe" & TextBox2.Text, AppWinStyle.NormalFocus)
        If RadioButton1.Checked Then
            Process.Start("cmd", "/k" & TextBox2.Text)
        End If

        If RadioButton2.Checked Then
            Process.Start("cmd", "/c" & TextBox2.Text)
        End If

    End Sub

End Class