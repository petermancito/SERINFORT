Public Class CPeriodo
    Dim pIdperiodo As String
    Dim pPeriodo As String
    Dim pestatus As String
    Dim porden As Integer

#Region "propiedades"

    Dim cnt As New LogicaNegocio.CConexionSql
    Public Property IdPeriodo As String
        Get
            Return pIdperiodo
        End Get
        Set(ByVal value As String)
            pIdperiodo = value
        End Set
    End Property

    Public Property Periodo As String
        Get
            Return pPeriodo
        End Get
        Set(ByVal value As String)
            pPeriodo = value
        End Set
    End Property

    Public Property IdEstatus As String
        Get
            Return pestatus
        End Get
        Set(ByVal value As String)
            pestatus = value
        End Set
    End Property

    Public Property Orden As Integer
        Get
            Return porden
        End Get
        Set(ByVal value As Integer)
            porden = value
        End Set
    End Property

#End Region

#Region "Metodos"
    Public Sub GetDatos(ByRef dg As DataGridView)
        Dim dt As New DataTable
        dt = cnt.LlenarDataTable("select * from catperiodo ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idperiodo"), dr("periodo"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"))
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CPeriodo) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            sql = "INSERT INTO catperiodo values "
            sql = sql + " ('" + clase.IdPeriodo + "','" + clase.Periodo + "','" + clase.IdEstatus + "',"
            sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catperiodo set idestatus='" + clase.IdEstatus + "',"
            sql = sql + "periodo='" + clase.Periodo + "',orden ='" + clase.Orden.ToString + "',"
            sql = sql + "sysuser='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE idperiodo ='" + clase.IdPeriodo + "'"
        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catperiodo where idperiodo='" + clase.IdPeriodo + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())
        Return resp

    End Function

#End Region


End Class
