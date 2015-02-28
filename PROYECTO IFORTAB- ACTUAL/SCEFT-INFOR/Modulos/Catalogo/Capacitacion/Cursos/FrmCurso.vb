Public Class FrmCurso 

    Private Sub FrmCurso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BarnerPrincipal1.Datos(Me.Text, Me.Text, New CIconos().getIcono("CURSOS"))
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim reg As New FrmCursosReg
        reg.ShowDialog()
        reg.Close()
    End Sub

    Private Sub BarnerPrincipal1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class