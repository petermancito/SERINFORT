Imports SCEFT_INFOR.CCatalogo

Public Class FrmPeriodo
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Me.InitSeleccion(Me.dgDatos)
            Me.InitDatos()
            Try
                If (cat.Periodo.ExecuteOperation("DEL", cat.Periodo) > 0) Then
                    Me.FrmPeriodo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Me.InitDatos()
                If (cat.Periodo.ExecuteOperation("ADD", cat.Periodo) > 0) Then
                    Me.FrmPeriodo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Else
                Me.InitDatos()
                If (cat.Periodo.ExecuteOperation("MOD", cat.Periodo) > 0) Then
                    Me.FrmPeriodo_Load(sender, e)
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

    Private Sub FrmPeriodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cat.Periodo.GetDatos(Me.dgDatos)
    End Sub

    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.Periodo.IdPeriodo = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDPERIODO").Value.ToString.Trim
        cat.Periodo.Periodo = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("PERIODO").Value.ToString.Trim
        cat.Periodo.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.Periodo.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim
    End Sub

    Private Sub InitDatos()        
        cat.Periodo.IdPeriodo = Me.txtIdPeriodo.Text.Trim
        cat.Periodo.Periodo = Me.txtPeriodo.Text.Trim
        cat.Periodo.IdEstatus = Me.cmbEstatus.Text.Trim
        cat.Periodo.Orden = CInt(Me.txtOrden.Text)
    End Sub

    Private Sub InitNuevo()
        Me.txtIdperiodo.Text = ""
        Me.txtPeriodo.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        If (isNuevo) Then
            Me.txtIdperiodo.Enabled = True
        Else
            Me.txtIdperiodo.Enabled = False
        End If
        Me.txtPeriodo.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub


    Private Sub dgDatos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentDoubleClick
        InitSeleccion(Me.dgDatos)

        Me.txtIdPeriodo.Text = cat.Periodo.IdPeriodo
        Me.txtPeriodo.Text = cat.Periodo.Periodo
        Me.cmbEstatus.SelectedText = cat.Periodo.IdEstatus
        Me.cmbEstatus.Text = cat.Periodo.IdEstatus
        Me.txtOrden.Text = cat.Periodo.Orden

        isNuevo = False
        Me.InitHabilitar(False)
    End Sub
End Class