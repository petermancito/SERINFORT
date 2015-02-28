Imports SCEFT_INFOR.CCatalogo

Public Class FrmModelo
    Dim cat As New CCatalogo
    Dim isNuevo As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnEliminar.Click, btnGuardar.Click, btnModificar.Click, btnNuevo.Click
        If (sender Is btnCerrar) Then
            Me.Close()
        ElseIf (sender Is btnEliminar) Then
            Try
                Me.InitSeleccion(Me.dgDatos)
                Me.InitDatos()

                If (cat.Modelo.ExecuteOperation("DEL", cat.Modelo) > 0) Then
                    Me.FrmModelo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                End If
            Catch ex As Exception
                MessageBox.Show("Debe Seleccionar el registro con un click", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf (sender Is btnGuardar) Then
            If (isNuevo) Then
                Me.InitDatos()
                If (cat.Modelo.ExecuteOperation("ADD", cat.Modelo) > 0) Then
                    Me.FrmModelo_Load(sender, e)
                    Me.InitHabilitar(False)
                    Me.InitNuevo()
                    Me.btnGuardar.Enabled = False
                    MessageBox.Show("EL Modelo ha sido registrado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else

                Me.InitDatos()
                Try
                    If (cat.Modelo.ExecuteOperation("MOD", cat.Modelo) > 0) Then
                        Me.FrmModelo_Load(sender, e)
                        Me.InitHabilitar(False)
                        Me.InitNuevo()
                        Me.btnGuardar.Enabled = False
                    End If
                Catch ex As Exception
                    MessageBox.Show("Debe Seleccionar el registro con un click", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf (sender Is btnModificar) Then
            If Me.txtModelo.Text.Trim <> "" Then
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

    End Sub

    Private Sub FrmModelo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cat.Modelo.GetDatos(Me.dgDatos)
    End Sub

    Private Sub InitSeleccion(ByRef dg As DataGridView)
        cat.Modelo.IdModelo = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDMODELO").Value.ToString.Trim
        cat.Modelo.Modelo = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("MODELO").Value.ToString.Trim
        cat.Modelo.IdEstatus = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("IDESTATUS").Value.ToString.Trim
        cat.Modelo.Orden = Me.dgDatos.Rows(Me.dgDatos.CurrentRow.Index).Cells("ORDEN").Value.ToString.Trim
    End Sub

    Private Sub InitDatos()        
            cat.Modelo.IdModelo = Me.txtIdmodelo.Text.Trim
            cat.Modelo.Modelo = Me.txtModelo.Text.Trim
            cat.Modelo.IdEstatus = Me.cmbEstatus.Text.Trim
            cat.Modelo.Orden = CInt(Me.txtOrden.Text)
    End Sub

    Private Sub InitNuevo()
        Me.txtIdmodelo.Text = ""
        Me.txtModelo.Text = ""
        Me.cmbEstatus.SelectedIndex = -1
        Me.txtOrden.Text = ""
    End Sub
    Private Sub InitHabilitar(ByRef opcion As Boolean)
        If (isNuevo) Then
            Me.txtIdmodelo.Enabled = True
        Else
            Me.txtIdmodelo.Enabled = False
        End If
        Me.txtModelo.Enabled = opcion
        Me.cmbEstatus.Enabled = opcion
        Me.txtOrden.Enabled = opcion
    End Sub


    Private Sub dgDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentClick
        InitSeleccion(Me.dgDatos)

        Me.txtIdmodelo.Text = cat.Modelo.IdModelo
        Me.txtModelo.Text = cat.Modelo.Modelo
        Me.cmbEstatus.SelectedText = cat.Modelo.IdEstatus
        Me.cmbEstatus.Text = cat.Modelo.IdEstatus
        Me.txtOrden.Text = cat.Modelo.Orden

        isNuevo = False
        Me.InitHabilitar(False)
    End Sub

    Private Sub txtOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrden.KeyPress
        valida_numero(e)
    End Sub
End Class