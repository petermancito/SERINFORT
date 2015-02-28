Imports SCEFT_INFOR.CCatalogo

Public Class FrmAreaFormacion
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Try
                Me.InitSeleccion(Me.dgDatos)
                Me.InitDatos()

                If (cat.AreaFormacion.ExecuteOperation("DEL", cat.AreaFormacion) > 0) Then
                    MsgBox("El Área se ha registrado correctamente", MsgBoxStyle.Information)
                    Me.FrmAreaFormacion_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Catch ex As Exception
                MessageBox.Show("Debe Seleccionar el registro con Doble click", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Try
                    Me.InitDatos()
                    If (cat.AreaFormacion.ExecuteOperation("ADD", cat.AreaFormacion) > 0) Then
                        MsgBox("EL ÁREA SE HA REGISTRADO CORRECTAMENTE", MsgBoxStyle.Information)
                        Me.FrmAreaFormacion_Load(sender, e)
                        Me.InitHabilitar(False)
                        Me.InitNuevo()
                        Me.btnGuardar.Enabled = False
                    End If
                Catch ex As Exception
                    MessageBox.Show("Debe Capturar los datos requeridos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.InitDatos()
                If (cat.AreaFormacion.ExecuteOperation("MOD", cat.AreaFormacion) > 0) Then
                    Me.FrmAreaFormacion_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                    Me.btnGuardar.Enabled = False
                End If
            End If
        ElseIf (sender Is btnModificar) Then
            isNuevo = False
            Me.InitHabilitar(True)
        ElseIf (sender Is btnNuevo) Then
            isNuevo = True
            Me.InitNuevo()
            Me.InitHabilitar(True)
            Me.btnGuardar.Enabled = True
        End If

    End Sub
    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.AreaFormacion.IdArea = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDAREA").Value.ToString.Trim
        cat.AreaFormacion.Area = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("AREAS").Value.ToString.Trim
        cat.AreaFormacion.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.AreaFormacion.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim
    End Sub

    Private Sub InitDatos()
        cat.AreaFormacion.IdArea = Me.txtIdArea.Text.Trim
        cat.AreaFormacion.Area = Me.txtArea.Text.Trim
        cat.AreaFormacion.IdEstatus = Me.cmbEstatus.Text.Trim        
        cat.AreaFormacion.Orden = CInt(Me.txtOrden.Text)
    End Sub

    Private Sub InitNuevo()
        Me.txtIdArea.Text = ""
        Me.txtArea.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        If (isNuevo) Then
            Me.txtIdArea.Enabled = True
        Else
            Me.txtIdArea.Enabled = False
        End If
        Me.txtArea.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub

    Private Sub FrmAreaFormacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cat.AreaFormacion.GetDatos(Me.dgDatos)
    End Sub

    Private Sub dgDatos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentDoubleClick
        InitSeleccion(Me.dgDatos)

        Me.txtIdArea.Text = cat.AreaFormacion.IdArea
        Me.txtArea.Text = cat.AreaFormacion.Area

        Me.cmbEstatus.SelectedText = cat.AreaFormacion.IdEstatus
        Me.cmbEstatus.Text = cat.AreaFormacion.IdEstatus
        Me.txtOrden.Text = cat.AreaFormacion.Orden

        isNuevo = False
        Me.InitHabilitar(False)
    End Sub

    Private Sub txtOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrden.KeyPress
        'If Not (Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar)) Then
        'e.Handled = True
        'End If
        valida_numero(e)
    End Sub

End Class