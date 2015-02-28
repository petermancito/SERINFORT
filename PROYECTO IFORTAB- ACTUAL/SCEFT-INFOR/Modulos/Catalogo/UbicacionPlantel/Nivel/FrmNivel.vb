Imports SCEFT_INFOR.CCatalogo

Public Class FrmNivel
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Me.InitSeleccion(Me.dgDatos)
            Me.InitDatos()
            Try
                If (cat.Nivel.ExecuteOperation("DEL", cat.Nivel) > 0) Then
                    Me.FrmNivel_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Me.InitDatos()
                If (cat.Nivel.ExecuteOperation("ADD", cat.Nivel) > 0) Then
                    Me.FrmNivel_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Else
                Me.InitDatos()
                If (cat.Nivel.ExecuteOperation("MOD", cat.Nivel) > 0) Then
                    Me.FrmNivel_Load(sender, e)
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

    Private Sub FrmNivel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cat.Nivel.GetDatos(Me.dgDatos)
    End Sub

    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.Nivel.IdNivel = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDNIVEL").Value.ToString.Trim
        cat.Nivel.Nivel = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("NIVEL").Value.ToString.Trim
        cat.Nivel.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.Nivel.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim
    End Sub

    Private Sub InitDatos()
        cat.Nivel.IdNivel = Me.txtIdNivel.Text.Trim
        cat.Nivel.Nivel = Me.txtNivel.Text.Trim
        cat.Nivel.IdEstatus = Me.cmbEstatus.Text.Trim
        cat.Nivel.Orden = CInt(Me.txtOrden.Text)
    End Sub

    Private Sub InitNuevo()
        Me.txtIdNivel.Text = ""
        Me.txtNivel.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        If (isNuevo) Then
            Me.txtIdNivel.Enabled = True
        Else
            Me.txtIdNivel.Enabled = False
        End If
        Me.txtNivel.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub


    Private Sub dgDatos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentDoubleClick
        InitSeleccion(Me.dgDatos)

        Me.txtIdNivel.Text = cat.Nivel.IdNivel
        Me.txtNivel.Text = cat.Nivel.Nivel
        Me.cmbEstatus.SelectedText = cat.Nivel.IdEstatus
        Me.cmbEstatus.Text = cat.Nivel.IdEstatus
        Me.txtOrden.Text = cat.Nivel.Orden

        isNuevo = False
        Me.InitHabilitar(False)
    End Sub
End Class