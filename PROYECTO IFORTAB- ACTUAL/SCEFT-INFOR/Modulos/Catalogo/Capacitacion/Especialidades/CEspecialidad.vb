Public Class CEspecialidad
    Dim pIdEspecilidad As String
    Dim pAreaFormacion As New CAreaFormacion

    Dim pClaveEspecialidad As String
    Dim pEspecialidad As String
    Dim pIdEstatus As String
    Dim pOrden As String


    Dim cnt As New LogicaNegocio.CConexionSql

#Region "propiedades"



    Public Property IdEspecialidad() As String
        Get
            Return pIdEspecilidad
        End Get
        Set(ByVal value As String)
            pIdEspecilidad = value
        End Set
    End Property

    Public Property AreaFormacion As CAreaFormacion
        Get
            Return pAreaFormacion
        End Get
        Set(ByVal value As CAreaFormacion)
            pAreaFormacion = value
        End Set
    End Property

    Public Property ClaveEspecialidad() As String
        Get
            Return pClaveEspecialidad
        End Get
        Set(ByVal value As String)
            pClaveEspecialidad = value
        End Set
    End Property

    Public Property Especialidad() As String
        Get
            Return pEspecialidad
        End Get
        Set(ByVal value As String)
            pEspecialidad = value
        End Set
    End Property


    Public Property IdEstatus() As String
        Get
            Return pIdEstatus
        End Get
        Set(ByVal value As String)
            pIdEstatus = value
        End Set
    End Property

    Public Property Orden() As String
        Get
            Return pOrden
        End Get
        Set(ByVal value As String)
            pOrden = value
        End Set
    End Property

#End Region

#Region "METODOS"
    Public Sub GetDatos(ByRef dg As DataGridView)
        Dim dt As New DataTable
        dt = cnt.LlenarDataTable("select * from catespecialidad ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idareaformacion"), dr("ClaveEspecialidad"), dr("Especialidad"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"), dr("idespecialidad").ToString.Trim)
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CEspecialidad) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            clase.IdEspecialidad = "getiddocumento()"
            sql = "INSERT INTO catespecialidad values "
            sql = sql + " (" + clase.IdEspecialidad + ","
            sql = sql + " '" + clase.AreaFormacion.IdArea + "','" + clase.ClaveEspecialidad + "','" + clase.Especialidad + "',"
            sql = sql + " '" + clase.IdEstatus + "',"
            sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catespecialidad set idestatus = '" + clase.IdEstatus + "',"
            sql = sql + " idareaformacion ='" + clase.AreaFormacion.IdArea + "',claveespecialidad='" + clase.ClaveEspecialidad + "',"
            sql = sql + " especialidad ='" + clase.Especialidad.ToString + "',orden='" + clase.Orden + "',"
            sql = sql + " sysuser ='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE idespecialidad ='" + clase.IdEspecialidad + "' "
        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catespecialidad where idespecialidad = '" + clase.IdEspecialidad + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())

        Return resp

    End Function

#End Region


End Class
