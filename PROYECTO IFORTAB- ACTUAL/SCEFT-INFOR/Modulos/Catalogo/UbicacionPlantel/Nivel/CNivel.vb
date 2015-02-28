Public Class CNivel
    Dim pIdNivel As String
    Dim pNivel As String
    Dim pestatus As String
    Dim porden As Integer

#Region "propiedades"

    Dim cnt As New LogicaNegocio.CConexionSql

    Public Property IdNivel As String
        Get
            Return pIdNivel
        End Get
        Set(ByVal value As String)
            pIdNivel = value
        End Set
    End Property

    Public Property Nivel As String
        Get
            Return pNivel
        End Get
        Set(ByVal value As String)
            pNivel = value
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
        dt = cnt.LlenarDataTable("select * from catnivel ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idnivel"), dr("NIVEL"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"))
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CNivel) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            sql = "INSERT INTO catnivel values "
            sql = sql + " ('" + clase.IdNivel + "','" + clase.Nivel + "','" + clase.IdEstatus + "',"
            sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catnivel set idestatus='" + clase.IdEstatus + "',"
            sql = sql + "nivel='" + clase.Nivel + "',orden ='" + clase.Orden.ToString + "',"
            sql = sql + "sysuser='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE IDNIVEL ='" + clase.IdNivel + "'"
        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catnivel where IDNIVEL='" + clase.IdNivel + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())
        Return resp

    End Function

#End Region


End Class
