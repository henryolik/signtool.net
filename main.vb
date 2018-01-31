Public Class main

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_tosign.Click
        OpenFileDialog1.Title = "Please select a file"
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.Filter = "All files|*.*"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            tb_tosign.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_cert.Click
        OpenFileDialog1.Title = "Please select a signing certificate"
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.Filter = "Certificate files|*.pfx"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            tb_cert.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Process.Start("cmd", "/c signtool sign /f """ & tb_cert.Text & """ /t http://timestamp.verisign.com/scripts/timstamp.dll /d """ & tb_name.Text & """ /du " & tb_www.Text & " /v """ & tb_tosign.Text & Chr(34))
        My.Settings.cert = tb_cert.Text
        My.Settings.tosign = tb_tosign.Text
        My.Settings.www = tb_www.Text
        My.Settings.name = tb_name.Text
    End Sub

    Private Sub main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tb_cert.Text = My.Settings.cert
        tb_name.Text = My.Settings.name
        tb_tosign.Text = My.Settings.tosign
        tb_www.Text = My.Settings.www
    End Sub
End Class
