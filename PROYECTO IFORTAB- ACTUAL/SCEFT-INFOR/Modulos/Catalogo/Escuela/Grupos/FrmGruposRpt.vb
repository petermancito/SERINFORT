Public Class FrmGruposRpt

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim imp As New FRptGrupos
        imp.ShowDialog()
        imp.Close()
    End Sub
End Class