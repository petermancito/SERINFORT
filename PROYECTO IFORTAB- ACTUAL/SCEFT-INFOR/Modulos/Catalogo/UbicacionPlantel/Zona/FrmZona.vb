Imports SCEFT_INFOR.CCatalogo

Public Class FrmZona
    Dim cbx As New CCombox
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub FrmZona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbNivel, "CAT_NIVEL")
        cat.Zona.GetDatos(Me.dgDatos)
    End Sub
    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.Zona.Nivel.IdNivel = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDNIVEL").Value.ToString.Trim
        cat.Zona.IdZona = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDZona").Value.ToString.Trim
        cat.Zona.Zona = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("Zona").Value.ToString.Trim
        cat.Zona.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.Zona.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim
    End Sub

    Private Sub InitDatos()
        cat.Zona.Nivel.IdNivel = Me.cmbNivel.SelectedValue.ToString.Trim
        cat.Zona.IdZona = Me.txtIdZona.Text.Trim
        cat.Zona.Zona = Me.txtZona.Text.Trim
        cat.Zona.IdEstatus = Me.cmbEstatus.Text.Trim
        cat.Zona.Orden = CInt(Me.txtOrden.Text)
    End Sub

    Private Sub InitNuevo()
        Me.cmbNivel.SelectedIndex = -1
        Me.txtIdZona.Text = ""
        Me.txtZona.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        If (isNuevo) Then
            Me.txtIdZona.Enabled = True
        Else
            Me.txtIdZona.Enabled = False
        End If

        Me.cmbNivel.Enabled = opcion
        Me.txtZona.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Me.InitSeleccion(Me.dgDatos)
            Me.InitDatos()
            Try
                If (cat.Zona.ExecuteOperation("DEL", cat.Zona) > 0) Then
                    Me.FrmZona_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Me.InitDatos()
                If (cat.Zona.ExecuteOperation("ADD", cat.Zona) > 0) Then
                    Me.FrmZona_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Else
                Me.InitDatos()
                If (cat.Zona.ExecuteOperation("MOD", cat.Zona) > 0) Then
                    Me.FrmZona_Load(sender, e)
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

        Me.cmbNivel.SelectedValue = cat.Zona.Nivel.IdNivel
        'Me.cmbNivel.SelectedText = cat.Zona.Nivel.IdNivel

        Me.txtIdZona.Text = cat.Zona.IdZona
        Me.txtZona.Text = cat.Zona.Zona

        Me.cmbEstatus.SelectedText = cat.Zona.IdEstatus
        Me.cmbEstatus.Text = cat.Zona.IdEstatus
        Me.txtOrden.Text = cat.Zona.Orden

        isNuevo = False
        Me.InitHabilitar(False)

    End Sub
End Class