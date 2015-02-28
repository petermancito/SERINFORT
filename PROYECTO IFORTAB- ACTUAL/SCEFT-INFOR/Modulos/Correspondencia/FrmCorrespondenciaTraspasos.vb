Public Class FrmCorrespondenciaTraspasos
    Dim cbx As New CCombox
    Public isSafe As Boolean
    Public corresp As New CCorrespondencia
    Dim corresponAux As New CCorrespondencia

    Private Sub FrmCorrespondenciaTraspasos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbAreaAsignada, "CAT_AREAS")
        cbx.getCmbLlenarComboxs(Me.cmbAreaTraspado, "CAT_AREAS")

        'cbx.getCmbLlenarComboxs(Me.cmbAreaAsignada, "CAT_AREAS")

        corresponAux = corresp.getCorrespondenciaId(corresp)

        Me.cmbAreaAsignada.SelectedValue = corresponAux.Catalogo.Area.IdArea

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click



        If (Me.cmbAreaTraspado.SelectedValue.ToString.Trim = Me.cmbAreaAsignada.SelectedValue.ToString.Trim) Then
            MessageBox.Show("El Area Asignada debe ser diferente al Area a Trasnferir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        corresp.Catalogo.Area.IdArea = Me.cmbAreaTraspado.SelectedValue.ToString.Trim

        If (corresp.getCorrespondenciaTraspaso(corresp) > 0) Then
            MessageBox.Show("La Correspondencia ha sido Trasnferida al Area '" + Me.cmbAreaTraspado.Text + "' ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            isSafe = True
            Me.Close()
        End If
    End Sub
End Class