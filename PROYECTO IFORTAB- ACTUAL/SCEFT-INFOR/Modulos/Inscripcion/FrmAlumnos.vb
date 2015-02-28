Public Class FrmAlumnos

    Private _frmMain As FrmMain
    Private cbx As New CCombox
    Private user As New CUsers


    Sub New(ByVal frmMain As FrmMain)
        ' TODO: Complete member initialization 
        _frmMain = frmMain
        InitializeComponent()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        _frmMain.RemoveTab(Me.Tag)
    End Sub


    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Me.LimpiarGrid()
        Me.LlenarGrid()
    End Sub


    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbDepartamento, "CAT_DEPA")
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim reg As New FrmAlumnosReg
        reg.isNuevo = True
        reg.ShowDialog()
        If (reg.isSafe = True) Then
            Me.btnCargar_Click(sender, e)
        End If
        reg.Dispose()
    End Sub

    Private Sub dgDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellDoubleClick
        If (Me.dgDatos.RowCount > 0) Then
            Dim reg As New FrmUsuariosReg
            reg.user.IdUsuario = Me.dgDatos.Rows(Me.dgDatos.CurrentCell.RowIndex).Cells("IdUsuario").Value.ToString.Trim
            reg.isNuevo = False
            reg.ShowDialog()
            If (reg.isSafe = True) Then
                Me.btnCargar_Click(sender, e)
            End If
            reg.Dispose()
        End If
    End Sub

    Private Sub LimpiarGrid()
        Me.dgDatos.Rows.Clear()
    End Sub
    Private Sub LlenarGrid()
        Dim dt As New DataTable
        Dim user As New CUser

        user.IdDepartamento = Me.cmbDepartamento.SelectedValue.ToString.Trim
        user.Nombre = Me.txtPropietario.Text.Trim
        dt = CUsers.pUser.GetUsuarios(user)


        If (dt.Rows.Count = 0) Then
            ModAlertas.AlertaError("Sin Registros")
            Exit Sub
        End If

        Dim frmMsj As New FProgresoComp

        frmMsj.pgAvance.Maximum = dt.Rows.Count
        frmMsj.pgAvance.Minimum = 0
        frmMsj.Show()

        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow = dt.Rows(i)
            frmMsj.lbRegistros.Text = dr("nombre").ToString.Trim

            frmMsj.pgAvance.Value = i

            Application.DoEvents()


            With Me.dgDatos.Rows
                .Add(i + 1, _
                     dr("idusuario").ToString.Trim, dr("nombre").ToString.Trim, _
                     dr("sexo"), dr("telefono").ToString.Trim, _
                     dr("extencion").ToString.Trim, dr("domicilio").ToString.Trim, _
                     IIf(dr("acceso").ToString.Trim = "1", "CONCEDIDO", "DENEGADO"), dr("tipo_user").ToString.Trim, _
                     dr("departamento"), dr("sysuser"), dr("sysdata") _
                        )
            End With

        Next

        frmMsj.Close()
        frmMsj.Dispose()


    End Sub

    Private Sub txtPropietario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPropietario.TextChanged
        Me.LimpiarGrid()
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Me.LimpiarGrid()
    End Sub


End Class