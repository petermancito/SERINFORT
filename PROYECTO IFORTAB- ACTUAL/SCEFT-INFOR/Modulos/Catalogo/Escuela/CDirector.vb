Public Class CDirector

    Public Property IdMaestro As String
    Public Property IdEstatus As String
    Public Property ApePat As String
    Public Property ApeMat As String
    Public Property Nombre As String
    Public Property Segmento As String
    Public Property Curp As String = Segmento + "" + Hom
    Public Property Sexo As String
    Public Property FechaNac As String
    Public Property EntidadNac As String
    Public Property Domicilio As String
    Public Property Nacionalidad As String
    Public Property Telefono As String
    Public Property EdoCivil As String
    Public Property Hom As String

    Dim cnt As New LogicaNegocio.CConexionSql



    Public Function getDirectorEscuela(ByRef direct As CDirector, ByRef escu As CEscuela) As CDirector

        Dim dt As New DataTable
        Dim sql As String

        sql = "select * from vescuela_director where idciclo ='" + escu.Idciclo + "'"
        sql = sql & " and idescuela ='" + escu.Idescuela + "' "
        sql = sql & " "


        dt = cnt.LlenarDataTable(sql)

        Return direct


    End Function


    Public Function getDirectorId(ByRef direct As CDirector) As CDirector
        Dim dt As New DataTable
        Dim sql As String

        sql = "select * from vinstructores where idmaestro ='" + direct.IdMaestro + "'"


        dt = cnt.LlenarDataTable(sql)

        If (dt.Rows.Count <> 0) Then
            Dim dr As DataRow = dt.Rows(0)

            direct.IdMaestro = dr("idmaestro").ToString().Trim
            direct.IdEstatus = dr("idestatus").ToString().Trim
            direct.ApePat = dr("apepat").ToString.Trim
            direct.ApeMat = dr("apemat").ToString.Trim
            direct.Nombre = dr("nombre").ToString.Trim
            direct.Curp = dr("curp").ToString.Trim
            direct.Sexo = dr("sexo").ToString.Trim
            direct.FechaNac = dr("fechanac").ToString.Trim
            direct.EntidadNac = dr("entnac").ToString.Trim
            direct.Domicilio = dr("domicilio").ToString.Trim
            direct.Nacionalidad = dr("nacionalidad").ToString.Trim
            direct.Telefono = dr("telefono").ToString.Trim
            direct.EdoCivil = dr("edocivil").ToString.Trim

        End If

        Return direct
    End Function

    Public Function getDirectorExiste(ByRef direct As CDirector) As String
        Dim dt As New DataTable
        Dim sql As String

        sql = "select * from vinstructores where nombre ='" + direct.Nombre + "'"
        sql = sql & " and apepat = '" + direct.ApePat + "' and apemat = '" + direct.ApeMat + "' "
        sql = sql & " and sexo = '" + direct.Sexo + "'  and fechanac = '" + direct.FechaNac + "' "
        sql = sql & " and substring(curp,0,16)='" + direct.Curp + "' "


        dt = cnt.LlenarDataTable(sql)

        direct.IdMaestro = ""

        If (dt.Rows.Count > 0) Then
            Dim dr As DataRow = dt.Rows(0)

            direct.IdMaestro = dr("idmaestro").ToString().Trim
            direct.IdEstatus = dr("idestatus").ToString().Trim
            direct.ApePat = dr("apepat").ToString.Trim
            direct.ApeMat = dr("apemat").ToString.Trim
            direct.Nombre = dr("nombre").ToString.Trim
            direct.Curp = dr("curp").ToString.Trim
            direct.Sexo = dr("sexo").ToString.Trim
            direct.FechaNac = dr("fechanac").ToString.Trim
            direct.EntidadNac = dr("entnac").ToString.Trim
            direct.Domicilio = dr("domicilio").ToString.Trim
            direct.Nacionalidad = dr("nacionalidad").ToString.Trim
            direct.Telefono = dr("telefono").ToString.Trim
            direct.EdoCivil = dr("edocivil").ToString.Trim

        End If

        Return direct.IdMaestro
    End Function

    Function getDirectorGuardarEscuela(ByRef direct As CDirector, ByRef esc As CEscuela) As String
        Dim sql As String
        Dim resp As String

        resp = ""

        sql = "insert into tblescueladirector values ("
        sql = sql & " '" + direct.IdMaestro.ToString.Trim + "','" + esc.Idciclo.ToString.Trim + "','" + esc.Idescuela.ToString.Trim + "',"
        sql = sql & " 'ACTIVO','" + CUsers.MYUserActual.IdUsuario.ToString.Trim + "',GETDATE()"
        sql = sql & ")"

        If (cnt.ExecuteSql(sql) > 0) Then
            resp = "GUARDO"
        End If

        Return resp
    End Function

    Function getDirectorGuardarDatos(ByRef direct As CDirector) As String
        Dim sql As String
        Dim resp As String
        Dim ids As New CCorrespondencia

        resp = ""

        direct.IdMaestro = "D" + ids.GetID()

        sql = "insert into tblmaestro values  ("
        sql = sql & " '" + direct.IdMaestro + "','" + direct.IdEstatus + "','" + direct.ApePat + "', "
        sql = sql & " '" + direct.ApeMat + "','" + direct.Nombre + "','" + direct.Curp + "', "
        sql = sql & " '" + direct.Sexo + "','" + direct.FechaNac.Substring(0, 10) + "','" + direct.EntidadNac + "', "
        sql = sql & " '" + direct.Domicilio + "','" + direct.Nacionalidad + "','" + direct.Telefono + "', "
        sql = sql & " '" + direct.EdoCivil + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE()"
        sql = sql & ")"

        If (cnt.ExecuteSql(sql) > 0) Then
            resp = "GUARDO"
        End If

        Return resp
    End Function


   


End Class
