Public Class FrmUsuariosReg
    Public isNuevo As Boolean
    Public user As New CUser
    Public isSafe As Boolean
    Private cbx As New CCombox

    Private Sub FrmUsuariosReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbx.getCmbLlenarComboxs(Me.cmbDepto, "CAT_DEPA")
        cbx.getCmbLlenarComboxs(Me.cmbTipoUsuario, "CAT_USER")


        If (isNuevo = True) Then
            Me.Limpiar()
            Me.btnPermisos.Enabled = False
        Else
            Me.Limpiar()
            Me.txtUsuario.Enabled = False
            Me.btnPermisos.Enabled = True
            Dim u As New CUser
            u = user.GetUsuariosId(user.IdUsuario)
            InitDatos(u)
        End If

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub Limpiar()
        Me.txtUsuario.Text = ""
        Me.txtPassword.Text = ""
        Me.txtPropietario.Text = ""
        Me.cmbSexo.SelectedIndex = -1
        Me.txtTelefono.Text = ""
        Me.txtExt.Text = ""
        Me.txtDomicilio.Text = ""
        Me.checkAcceso.Checked = False
        Me.cmbTipoUsuario.SelectedIndex = -1
        Me.cmbDepto.SelectedIndex = -1

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        user.IdUsuario = Me.txtUsuario.Text.Trim
        user.Password = Me.txtPassword.Text.Trim
        user.Nombre = Me.txtPropietario.Text.Trim
        user.Sexo = Me.cmbSexo.Text.Trim
        user.Telefono = Me.txtTelefono.Text.Trim
        user.Extension = Me.txtExt.Text.Trim
        user.Domicilio = Me.txtDomicilio.Text.Trim
        user.Acceso = IIf(Me.checkAcceso.Checked = True, "1", "0")
        user.IdTipoUsuario = Me.cmbTipoUsuario.SelectedValue
        user.IdDepartamento = Me.cmbDepto.SelectedValue
        user.Sit = "1"



        If (user.getGuardarUsuario(user, IIf(isNuevo = True, "ADD", "UPD")) > 0) Then
            MessageBox.Show("Usuario Registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            isSafe = True
            Me.Limpiar()
            If (Me.isNuevo = False) Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub InitDatos(ByRef c As CUser)
        Me.txtUsuario.Text = c.IdUsuario.ToString.Trim
        Me.txtPassword.Text = c.Password.ToString.Trim
        Me.txtPropietario.Text = c.Nombre.ToString.Trim
        Me.cmbSexo.SelectedItem = c.Sexo.ToString.Trim
        Me.txtTelefono.Text = c.Telefono.ToString.Trim
        Me.txtExt.Text = c.Extension.ToString.Trim
        Me.txtDomicilio.Text = c.Domicilio.ToString.Trim
        Me.checkAcceso.Checked = IIf(c.Acceso = "1", True, False)
        Me.cmbTipoUsuario.SelectedValue = c.IdTipoUsuario.ToString.Trim
        Me.cmbDepto.SelectedValue = c.IdDepartamento.ToString.Trim
    End Sub

  
End Class