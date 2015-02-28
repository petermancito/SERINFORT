Imports Cryptograp

Public Class FrmConfig


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Server=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=CtrlEscBD;

        My.Settings.myConfig = "Server=" + Me.txtServer.Text + ";port=5432;User Id=" + Me.txtUser.Text + ";Password=" + Me.txtPass.Text + ";Database=" + Me.txtBd.Text + ";"
        My.Settings.myConfig = CEncriptaciones.Encrypt(My.Settings.myConfig)
        My.Settings.Save()

        Me.Close()

    End Sub

    Private Sub FrmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (My.Settings.myConfig.Length > 0) Then
            Dim arre As String()
            arre = CEncriptaciones.Decrypt(My.Settings.myConfig).Split(";")
            Me.txtServer.Text = arre(0).Replace("Server=", "")
            Me.txtUser.Text = arre(2).Replace("User Id=", "")
            Me.txtPass.Text = arre(3).Replace("Password=", "")
            Me.txtBd.Text = arre(4).Replace("Database=", "")

            My.Application.DoEvents()

        End If
    End Sub
End Class