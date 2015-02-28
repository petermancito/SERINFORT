Public Class CCurso
    Public Property IdCurso As String
    Public Property Especialidad As New CEspecialidad
    Public Property Modelo As String
    Public Property TipoCurso As String
    Public Property ClaveCurso As String
    Public Property Curso As String
    Public Property Estatus As String
    Public Property CapMin As Integer
    Public Property CapMax As Integer
    Public Property Orden As Integer
    Public Property HorasAjustadas As String
    Public Property DuracionHoras As String
    Public Property HorasDiarias As String
    Public Property HSM As String
    Public Property DiasHabiles As String
    Public Property Meses As String

    Dim cnt As New LogicaNegocio.CConexionSql


#Region "METODOS"
    Public Sub GetDatos(ByRef dg As DataGridView)
        Dim dt As New DataTable
        dt = cnt.LlenarDataTable("select * from VCtrl_Cursos ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("clavecurso"), dr("curso"), dr("tipo_curso"), dr("especialidad"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"), dr("idcurso").ToString.Trim)
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CCurso) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            clase.IdCurso = "getiddocumento()"
            sql = "INSERT INTO catcurso values "
            sql = sql + " (" + clase.IdCurso + ","
            sql = sql + " '" + clase.Especialidad.IdEspecialidad + "','" + clase.Modelo + "','" + clase.TipoCurso + "',"
            sql = sql + " '" + clase.ClaveCurso + "',"
            sql = sql + " '" + clase.Curso + "',"
            sql = sql + " '" + clase.Estatus + "',"
            sql = sql + " '" + clase.CapMin + "',"
            sql = sql + " '" + clase.CapMax + "',"
            sql = sql + " '" + clase.Orden + "',"
            sql = sql + " '" + clase.HorasAjustadas + "',"
            sql = sql + " '" + clase.DuracionHoras + "',"
            sql = sql + " '" + clase.HorasDiarias + "',"
            sql = sql + " '" + clase.HSM + "',"
            sql = sql + " '" + clase.DiasHabiles + "',"
            sql = sql + " '" + clase.Meses + "',"
            sql = sql + " '" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catcurso set idestatus = '" + clase.Estatus + "',"
            sql = sql + " idespecialidad ='" + clase.Especialidad.IdEspecialidad + "',"
            sql = sql + " idmodelo ='" + clase.Modelo + "',"
            sql = sql + " idtipocurso ='" + clase.TipoCurso + "',"
            sql = sql + " clavecurso ='" + clase.ClaveCurso + "',"
            sql = sql + " curso ='" + clase.Curso + "',"
            sql = sql + " idestatus ='" + clase.Estatus + "',"
            sql = sql + " capmin ='" + clase.CapMin + "',"
            sql = sql + " capmax ='" + clase.CapMax + "',"
            sql = sql + " orden ='" + clase.Orden + "',"
            sql = sql + " horasajustadas ='" + clase.HorasAjustadas + "',"
            sql = sql + " duracionhoras ='" + clase.DuracionHoras + "',"
            sql = sql + " horasdiarias ='" + clase.HorasDiarias + "',"
            sql = sql + " hsm  ='" + clase.HSM + "',"
            sql = sql + " diashabiles ='" + clase.DiasHabiles + "',"
            sql = sql + " meses ='" + clase.Meses + "',"
            sql = sql + " sysuser ='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE idcurso ='" + clase.IdCurso + "' "
        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catcurso where idcurso = '" + clase.IdCurso + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())

        Return resp

    End Function

#End Region




End Class
