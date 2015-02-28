Public Class CEscuela
    Public Property Idciclo As String
    Public Property IdtipoEscuela As String
    Public Property Idplantel As String
    Public Property Idescuela As String

    Public Property IdUbicacion As String
    Public Property Idestado As String
    Public Property Idmunicipio As String
    Public Property Idestatus As String
    Public Property Escuela As String

    Public Property Domicilio As String
    Public Property EntreCalle As String
    Public Property YCalle As String
    Public Property Colonia As String

    Public Property CP As String
    Public Property Telefono As String
    Public Property TelExt As String
    Public Property Fax As String
    Public Property FaxExt As String

    Public Property Correo As String
    Public Property Pagina As String
    Public Property FechaFundacion As String
    Public Property TotalAulas As String

    Public Property Latitud As String
    Public Property Longitud As String

    Public Property Catalogo As New CCatalogo
    Dim cnt As New LogicaNegocio.CConexionSql
    Public Property Director As New CDirector


    Public Function getEscuelaExiste(ByRef esc As CEscuela) As Boolean
        Dim dt As New DataTable
        Dim sql As String
        Dim resp As Boolean

        sql = "select * from vescuelas where idciclo = '" + esc.Idciclo + "' and idescuela = '" + esc.Idescuela + "'"


        dt = cnt.LlenarDataTable(sql)


        resp = False

        If (dt.Rows.Count > 0) Then
            resp = True
        End If

        Return resp
    End Function

    Public Function getEscuelaConsulta(ByRef esc As CEscuela, Optional ByRef isGeneral As Boolean = False) As DataTable
        Dim dt As New DataTable
        Dim sql As String

        sql = "select * from vescuelas where idciclo <> '' "


        If (esc.Idescuela <> "") Then
            sql = sql & " and idescuela ='" + esc.Idescuela + "' "
        End If


        If (isGeneral = False) Then
            sql = sql & " and idciclo = '" + esc.Idciclo + "' "
        End If


        dt = cnt.LlenarDataTable(sql)
        'esc.Idescuela = ""

        Return dt
    End Function

    Public Function getEscuelaId(ByRef esc As CEscuela) As CEscuela
        Dim dt As New DataTable
        Dim sql As String

        sql = "select * from vescuelas where idciclo = '" + esc.Idciclo + "' and idescuela = '" + esc.Idescuela + "'"


        dt = cnt.LlenarDataTable(sql)
        esc.Idescuela = ""

        If (dt.Rows.Count > 0) Then
            Dim dr As DataRow = dt.Rows(0)

            esc.Idciclo = dr("idciclo").ToString.Trim
            esc.Idescuela = dr("idescuela").ToString.Trim
            esc.Escuela = dr("escuela").ToString.Trim
            esc.IdtipoEscuela = dr("idtipoescuela").ToString.Trim
            esc.IdUbicacion = dr("idubicacion").ToString.Trim
            esc.Idestado = dr("idestado").ToString.Trim()
            esc.Idmunicipio = dr("idmunicipio").ToString.Trim
            esc.Idestatus = dr("idestatus").ToString.Trim
            esc.Escuela = dr("escuela").ToString.Trim
            esc.Domicilio = dr("domicilio").ToString.Trim
            esc.EntreCalle = dr("entrecalle").ToString.Trim
            esc.YCalle = dr("ycalle").ToString.Trim
            esc.Colonia = dr("colonia").ToString.Trim
            esc.CP = dr("codpostal").ToString.Trim
            esc.Telefono = dr("telefono").ToString.Trim
            esc.TelExt = dr("telext").ToString.Trim
            esc.Fax = dr("fax").ToString.Trim
            esc.FaxExt = dr("faxext").ToString.Trim
            esc.Correo = dr("correo").ToString.Trim
            esc.Pagina = dr("pagina").ToString.Trim
            esc.FechaFundacion = dr("fechafunda").ToString.Trim
            esc.TotalAulas = dr("total_aulas").ToString.Trim
            esc.Latitud = dr("latitud").ToString.Trim
            esc.Longitud = dr("longitud").ToString.Trim

        End If

        Return esc
    End Function


    Function getEscuelaGuardar(ByRef esc As CEscuela) As String
        Dim sql As String
        Dim resp As String

        resp = ""

        If (esc.getEscuelaExiste(esc) = True) Then
            MessageBox.Show("El CCT, ya se encuentra Registrado en Este Ciclo")
            Exit Function
        End If


        sql = "insert into catescuela values ("
        sql = sql & " '" + esc.Idciclo + "','" + esc.IdtipoEscuela + "','" + esc.Idplantel + "',  "
        sql = sql & " '" + esc.Idescuela + "','" + esc.IdUbicacion + "','" + esc.Idestado + "',  "
        sql = sql & " '" + esc.Idmunicipio + "','" + esc.Idestatus + "','" + esc.Escuela + "',  "
        sql = sql & " '" + esc.Domicilio + "','" + esc.EntreCalle + "','" + esc.YCalle + "',  "
        sql = sql & " '" + esc.Colonia + "','" + esc.CP + "','" + esc.Telefono + "',  "
        sql = sql & " '" + esc.TelExt + "','" + esc.Fax + "','" + esc.FaxExt + "',  "
        sql = sql & " '" + esc.Correo + "','" + esc.Pagina + "',cast('" + esc.FechaFundacion + "' as date),cast('" + esc.FechaFundacion + "' as date),  "
        sql = sql & " " + esc.TotalAulas + ",'" + esc.Latitud + "','" + esc.Longitud + "',  "
        sql = sql & " '" + CUsers.MYUserActual.IdUsuario + "',GETDATE(),1 "
        sql = sql & ")"

        esc.Director.IdMaestro = ""

        If (cnt.ExecuteSql(sql) > 0) Then
            resp = "GUARDO"


            esc.Director.IdMaestro = esc.Director.getDirectorExiste(esc.Director)


            If (esc.Director.IdMaestro = "") Then
                esc.Director.getDirectorGuardarDatos(esc.Director)
            End If

            If (esc.Director.getDirectorGuardarEscuela(esc.Director, esc) = "GUARDO") Then

            End If



        End If

        Return resp
    End Function


    Function getEscuelaActualizar(ByRef esc As CEscuela) As String
        Dim sql As String
        Dim resp As String

        resp = ""

        sql = "update catescuela set "
        sql = sql & " idplantel = '" + esc.Idplantel + "',"
        sql = sql & " idubicacion = '" + esc.IdUbicacion + "',"
        sql = sql & " idestado = '" + esc.Idestado + "',"
        sql = sql & " idmunicipio = '" + esc.Idmunicipio + "',"
        sql = sql & " idestatus = '" + esc.Idestatus + "',"
        sql = sql & " escuela = '" + esc.Escuela + "',"
        sql = sql & " domicilio = '" + esc.Domicilio + "',"
        sql = sql & " entrecalle = '" + esc.EntreCalle + "',"
        sql = sql & " ycalle = '" + esc.YCalle + "',"
        sql = sql & " colonia = '" + esc.Colonia + "',"
        sql = sql & " codpostal = '" + esc.CP + "',"
        sql = sql & " telefono = '" + esc.Idplantel + "',"
        sql = sql & " telext = '" + esc.Idplantel + "',"
        sql = sql & " fax = '" + esc.Idplantel + "',"
        sql = sql & " faxext = '" + esc.Idplantel + "',"
        sql = sql & " correo = '" + esc.Idplantel + "',"
        sql = sql & " pagina = '" + esc.Idplantel + "',"
        sql = sql & " fechafunda = '" + esc.Idplantel + "',"
        sql = sql & " fechaactua = '" + esc.Idplantel + "',"
        sql = sql & " total_aulas = '" + esc.TotalAulas + "',"
        sql = sql & " latitud = '" + esc.Latitud + "',"
        sql = sql & " longitud = '" + esc.Longitud + "',"
        sql = sql & " sysuer = '" + CUsers.MYUserActual.IdUsuario + "',"
        sql = sql & " fechafunda = GETDATE() "
        sql = sql & " where idciclo = '" + esc.Idciclo + "' and idescuela= '" + esc.Idescuela + "'"

        If (cnt.ExecuteSql(sql) > 0) Then
            resp = "GUARDO"
        End If

        Return resp
    End Function






End Class
