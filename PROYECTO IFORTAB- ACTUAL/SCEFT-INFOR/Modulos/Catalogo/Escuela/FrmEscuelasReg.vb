Public Class FrmEscuelasReg

    Dim esc As New CEscuela
    Dim cbx As New CCombox
    Public isNuevo As Boolean
    Public isSafe As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmEscuelasReg2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbx.getCmbLlenarComboxs(Me.cmbCiclo, "CAT_CICLO")
        cbx.getCmbLlenarComboxs(Me.cmbUbicacion, "CAT_UBICACION")
        cbx.getCmbLlenarEstado(Me.cmbEstado)
        cbx.getCmbLlenarEstado(Me.cmbEntidadNac)
        cbx.getCmbLlenarTipoEscuela(Me.cmbTipoEscuela)


        cbx.getCmbLlenarPlantel(Me.cmbPlantel, esc)

        If (isNuevo = False) Then
            Me.cmbCiclo.Enabled = False
        End If



    End Sub
    Public Overloads Sub ShowDialog(ByRef escu As CEscuela)
        esc = escu
        Me.ShowDialog()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        esc.Idciclo = Me.cmbCiclo.SelectedValue.ToString.Trim
        esc.Idescuela = Me.txtCct.Text.Trim
        esc.Escuela = Me.txtNombrePlantel.Text.Trim
        esc.Idestatus = Me.cmbEstatus.SelectedValue
        esc.IdUbicacion = Me.cmbUbicacion.SelectedValue
        esc.Idplantel = Me.cmbPlantel.SelectedValue
        esc.Idestado = Me.cmbEstado.SelectedValue
        esc.Idmunicipio = Me.cmbMunicipio.SelectedValue.ToString.Trim
        esc.Domicilio = Me.txtDomicilio.Text.Trim
        esc.EntreCalle = Me.txtEntreCalle.Text.Trim
        esc.YCalle = Me.txtYCalle.Text.Trim
        esc.Colonia = Me.txtColonia.Text.Trim
        esc.CP = Me.txtCP.Text.Trim
        esc.Telefono = Me.txtTelefono.Text.Trim
        esc.TelExt = Me.txtTelExt.Text.Trim
        esc.IdtipoEscuela = Me.cmbTipoEscuela.SelectedValue.ToString.Trim

        esc.Fax = Me.txtFax.Text.Trim
        esc.FaxExt = Me.txtFaxExt.Text.Trim
        esc.Correo = Me.txtCorreo.Text.Trim
        esc.FechaFundacion = Me.txtFechaFund.Text


        esc.Director.ApePat = Me.txtApePat.Text.Trim
        esc.Director.ApeMat = Me.txtApeMat.Text.Trim
        esc.Director.Nombre = Me.txtNombre.Text.Trim

        esc.Director.Sexo = Me.cmbSexo.Text
        esc.Director.FechaNac = Me.txtFechaNac.Text
        esc.Director.EntidadNac = Me.cmbEntidadNac.SelectedValue.ToString.Trim
        esc.Director.Segmento = Me.txtCurp.Text
        esc.Director.Hom = Me.txtHom.Text


        esc.TotalAulas = Me.txtTotalAulas.Text
        esc.Latitud = Me.txtLatitud.Text
        esc.Longitud = Me.txtLongitud.Text


        If (isNuevo = True) Then
            If (esc.getEscuelaGuardar(esc) = "GUARDO") Then
                MessageBox.Show("Escuela Registrada Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                isSafe = True
                Me.Close()
            End If
        Else
            If (esc.getEscuelaActualizar(esc) = "GUARDO") Then
                MessageBox.Show("Escuela Actualizada Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                isSafe = True
            End If
        End If



    End Sub



    Private Sub cmbEstado_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedValueChanged
        Try
            esc.Idestado = cmbEstado.SelectedValue.Trim

            If (Me.cmbEstado.Items.Count > 0) Then
                cbx.getCmbLlenarMunicipio(Me.cmbMunicipio, esc.Idestado)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class