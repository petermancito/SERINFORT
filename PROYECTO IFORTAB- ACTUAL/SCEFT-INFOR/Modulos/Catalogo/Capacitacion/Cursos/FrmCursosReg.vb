Public Class FrmCursosReg
    Public is_safe As Boolean
    Public is_nuevo As Boolean
    Dim cat As New CCatalogo


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmCursosReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class