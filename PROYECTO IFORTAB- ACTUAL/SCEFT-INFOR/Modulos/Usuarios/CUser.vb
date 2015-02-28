Imports SCEFT_INFOR.LogicaNegocio
Imports Npgsql

Public Class CUser
    Dim encrpy As New Cryptograp.CEncriptaciones


#Region "propiedades"


    Public Property IdUsuario As String
    Public Property Nombre As String
    Public Property Password As String
    Public Property Sexo As String
    Public Property Telefono As String
    Public Property Extension As String
    Public Property Domicilio As String
    Public Property Acceso As String
    Public Property IdTipoUsuario As String
    Public Property IdDepartamento As String
    Public Property SysUser As String
    Public Property SysData As String
    Public Property Sit As String


    Dim cnt As New LogicaNegocio.CConexionSql


#End Region


    Public Function getGuardarUsuario(ByRef item As CUser, ByRef modo As String) As Integer

        Dim resp As Integer

        Dim cmd As New NpgsqlCommand("sp_usuarioguardar", cnt.Conectar)
        cmd.CommandType = CommandType.StoredProcedure

        With cmd.Parameters
            .Add("idusuario1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.IdUsuario
            .Add("nombre1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Nombre
            .Add("password1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Cryptograp.CEncriptaciones.Encrypt(item.Password)
            .Add("sexo1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Sexo
            .Add("telefono1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Telefono
            .Add("ext1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Extension
            .Add("dom1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Domicilio
            .Add("acceso1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Acceso
            .Add("idtipousuario1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.IdTipoUsuario
            .Add("iddepartamento1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.IdDepartamento
            .Add("sysuser1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CUsers.MYUserActual.IdUsuario
            .Add("sit1", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Sit
            .Add("modo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = modo
        End With
        resp = 0
        If (cmd.ExecuteNonQuery) Then
            resp = 1
        End If

        cmd.Dispose()

        Return resp
    End Function

    Public Function GetUsuariosId(ByRef Id As String) As CUser
        Dim dt As New DataTable
        Dim cnt As New CConexionSql
        Dim u As New CUser



        dt = cnt.LlenarDataTable("select * from vusuarios where IdUsuario = '" + Id + "' ")




        If (dt.Rows.Count = 0) Then
            MessageBox.Show("Sin Registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'CUsers.MYUserActual.IdUsuario = 0
        Else
            Dim dr As DataRow = dt.Rows(0)
            u.IdUsuario = dr("idusuario").ToString.Trim
            u.Nombre = dr("nombre").ToString.Trim
            u.Sexo = dr("sexo").ToString.Trim
            u.Telefono = dr("telefono").ToString.Trim
            u.Extension = dr("extencion").ToString.Trim
            u.Domicilio = dr("domicilio").ToString.Trim
            u.Acceso = dr("acceso").ToString.Trim
            u.IdTipoUsuario = dr("idtipousuario").ToString.Trim
            u.IdDepartamento = dr("iddepartamento").ToString.Trim
            u.Password = Cryptograp.CEncriptaciones.Decrypt(dr("password").ToString.Trim)

        End If

        Return u
    End Function


    Public Function GetUsuarios(ByRef user As CUser) As DataTable
        Dim dt As New DataTable
        Dim cnt As New CConexionSql
        Dim u As New CUser
        Dim sql As String

        sql = "select * from vusuarios where idusuario <> '' "

        If (user.IdDepartamento <> "ALL") Then
            sql = sql & " AND  iddepartamento = '" + user.IdDepartamento + "'"
        End If

        If (user.Nombre <> "") Then
            sql = sql & " AND NOMBRE LIKE '" + user.Nombre + "' "
        End If

        dt = cnt.LlenarDataTable(sql)


        Return dt
    End Function



    Public Function GetUsuariosLogin(ByRef Id As String, ByRef pass As String) As CUser
        Dim dt As New DataTable
        Dim cnt As New CConexionSql


        pass = Cryptograp.CEncriptaciones.Encrypt(pass)

        dt = cnt.LlenarDataTable("select * from vusuarios where IdUsuario = '" + Id.ToUpper + "' and password = '" + pass + "' ")


        If (dt.Rows.Count = 0) Then
            MessageBox.Show("Usuario / Password No validos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CUsers.MYUserActual.IdUsuario = 0
        Else
            Dim dr As DataRow = dt.Rows(0)
            CUsers.MYUserActual.IdUsuario = dr("IdUsuario").ToString.Trim
            CUsers.MYUserActual.IdTipoUsuario = dr("tipo_user").ToString.Trim
            CUsers.MYUserActual.IdDepartamento = dr("iddepartamento").ToString.Trim

            If (dr("acceso").ToString.Trim = "1") Then
                CUsers.MYUserActual.IdUsuario = dr("IdUsuario").ToString.Trim
            ElseIf (dr("acceso").ToString.Trim = "0") Then
                MessageBox.Show("Acceso Bloqueado,consulte con Administrador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CUsers.MYUserActual.IdUsuario = 0
            ElseIf (dr("acceso").ToString.Trim = "2") Then
                MessageBox.Show("Acceso Bloqueado temporalmente,consulte con Administrador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CUsers.MYUserActual.IdUsuario = 0
            Else
                MessageBox.Show("Sin Acceso,consulte con Administrador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CUsers.MYUserActual.IdUsuario = 0
            End If

        End If

        Return CUsers.MYUserActual
    End Function


End Class
