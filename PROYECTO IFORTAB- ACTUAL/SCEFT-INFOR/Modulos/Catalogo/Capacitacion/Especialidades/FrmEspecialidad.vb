Imports SCEFT_INFOR.CCatalogo

Public Class FrmEspecialidad

    Dim cbx As New CCombox
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Try
                Me.InitSeleccion(Me.dgDatos)
                Me.InitDatos()

                If (cat.Especialidad.ExecuteOperation("DEL", cat.Especialidad) > 0) Then
                    Me.FrmEspecialidad_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                    MessageBox.Show("El registro ha sido eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Debe Seleccionar el registro con un click", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Me.InitDatos()
                If (cat.Especialidad.ExecuteOperation("ADD", cat.Especialidad) > 0) Then
                    Me.FrmEspecialidad_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                    Me.btnGuardar.Enabled = False
                End If
            Else
                Me.InitDatos()
                If (cat.Especialidad.ExecuteOperation("MOD", cat.Especialidad) > 0) Then
                    Me.FrmEspecialidad_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                    Me.btnGuardar.Enabled = False
                End If
            End If
        ElseIf (sender Is btnModificar) Then
            If Me.txtEspecialidad.Text.Trim <> "" Then
                isNuevo = False
                Me.InitHabilitar(True)
            Else
                MessageBox.Show("Debe Seleccionar el registro con un click", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf (sender Is btnNuevo) Then
            isNuevo = True
            Me.InitNuevo()
            Me.InitHabilitar(True)
            Me.btnGuardar.Enabled = True
        End If
        'Me.Close()
    End Sub
    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.Especialidad.AreaFormacion.IdArea = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IdAreaFormacion").Value.ToString.Trim
        cat.Especialidad.IdEspecialidad = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IdEspecialidad").Value.ToString.Trim
        cat.Especialidad.ClaveEspecialidad = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("CveEspecial").Value.ToString.Trim
        cat.Especialidad.Especialidad = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("Especialidad").Value.ToString.Trim
        cat.Especialidad.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.Especialidad.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim

    End Sub

    Private Sub InitDatos()
        ' Try
        cat.Especialidad.AreaFormacion.IdArea = Me.cmbArea.SelectedValue.ToString.Trim
        'cat.Especialidad.IdEspecialidad = 
        cat.Especialidad.ClaveEspecialidad = Me.txtCveEspecialidad.Text.Trim
        cat.Especialidad.Especialidad = Me.txtEspecialidad.Text.Trim
        cat.Especialidad.IdEstatus = Me.cmbEstatus.Text.Trim
        cat.Especialidad.Orden = Me.txtOrden.Text.Trim
        '    Catch ex As Exception

        ' End Try

    End Sub

    Private Sub InitNuevo()
        Me.cmbArea.SelectedIndex = -1
        Me.txtCveEspecialidad.Text = ""
        Me.txtEspecialidad.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        Me.cmbArea.Enabled = opcion
        Me.txtCveEspecialidad.Enabled = opcion
        Me.txtEspecialidad.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub

    Private Sub FrmEspecialidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbArea, "CAT_AREA_FORMACION")
        cat.Especialidad.GetDatos(Me.dgDatos)
    End Sub

    Private Sub dgDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentClick
        InitSeleccion(Me.dgDatos)

        Me.cmbArea.SelectedValue = cat.Especialidad.AreaFormacion.IdArea
        Me.txtCveEspecialidad.Text = cat.Especialidad.ClaveEspecialidad
        Me.txtEspecialidad.Text = cat.Especialidad.Especialidad

        Me.cmbEstatus.SelectedText = cat.Especialidad.IdEstatus
        Me.cmbEstatus.Text = cat.Especialidad.IdEstatus
        Me.txtOrden.Text = cat.Especialidad.Orden



        isNuevo = False
        Me.InitHabilitar(False)
    End Sub

    Private Sub txtOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrden.KeyPress
        valida_numero(e)
    End Sub
End Class