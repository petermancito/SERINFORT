Imports SCEFT_INFOR.CCatalogo

Public Class FrmCiclo
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub FrmCiclo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cat.Ciclo.GetDatos(Me.dgDatos)
    End Sub

    
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Me.InitSeleccion(Me.dgDatos)
            Me.InitDatos()
            Try
                If (cat.Ciclo.ExecuteOperation("DEL", cat.Ciclo) > 0) Then
                    Me.FrmCiclo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Me.InitDatos()
                If (cat.Ciclo.ExecuteOperation("ADD", cat.Ciclo) > 0) Then
                    Me.FrmCiclo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Else
                Me.InitDatos()
                If (cat.Ciclo.ExecuteOperation("MOD", cat.Ciclo) > 0) Then
                    Me.FrmCiclo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            End If
        ElseIf (sender Is btnModificar) Then
            isNuevo = False
            Me.InitHabilitar(True)
        ElseIf (sender Is btnNuevo) Then
            isNuevo = True
            Me.InitNuevo()
            Me.InitHabilitar(True)
        End If

    End Sub

    Private Sub dgDatos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentDoubleClick
        InitSeleccion(Me.dgDatos)

        Me.txtIdCiclo.Text = cat.Ciclo.Idciclo
        Me.txtCiclo.Text = cat.Ciclo.Ciclo
        Me.cmbEstatus.SelectedText = cat.Ciclo.IdEstatus
        Me.cmbEstatus.Text = cat.Ciclo.IdEstatus
        Me.txtOrden.Text = cat.Ciclo.Orden

        isNuevo = False
        Me.InitHabilitar(False)

    End Sub
    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.Ciclo.Idciclo = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDCICLO").Value.ToString.Trim
        cat.Ciclo.Ciclo = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("CICLOESCOLAR").Value.ToString.Trim
        cat.Ciclo.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.Ciclo.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim
    End Sub

    Private Sub InitDatos()
        cat.Ciclo.Idciclo = Me.txtIdCiclo.Text.Trim
        cat.Ciclo.Ciclo = Me.txtCiclo.Text.Trim
        cat.Ciclo.IdEstatus = Me.cmbEstatus.Text.Trim
        cat.Ciclo.Orden = Me.txtOrden.Text.Trim
    End Sub

    Private Sub InitNuevo()
        Me.txtIdCiclo.Text = ""
        Me.txtCiclo.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        If (isNuevo) Then
            Me.txtIdCiclo.Enabled = True
        Else
            Me.txtIdCiclo.Enabled = False
        End If
        Me.txtCiclo.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub

    


End Class