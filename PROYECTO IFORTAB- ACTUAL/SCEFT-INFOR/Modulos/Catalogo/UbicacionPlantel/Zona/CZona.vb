Public Class CZona
    Dim cnt As New LogicaNegocio.CConexionSql

    Private pIdNivel As New CNivel
    Private pIdZona As String
    Private pZona As String
    Private pIdEstatus As String
    Private pOrden As Integer


#Region "PROPIEDADES"
    Public Property Nivel As CNivel
        Get
            Return pIdNivel
        End Get
        Set(ByVal value As CNivel)
            pIdNivel = value
        End Set
    End Property

    Public Property IdZona As String
        Get
            Return pIdZona
        End Get
        Set(ByVal value As String)
            pIdZona = value
        End Set
    End Property

    Public Property Zona As String
        Get
            Return pZona
        End Get
        Set(ByVal value As String)
            pZona = value
        End Set
    End Property

    Public Property IdEstatus As String
        Get
            Return pIdEstatus
        End Get
        Set(ByVal value As String)
            pIdEstatus = value
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


#Region "METODOS"
    Public Sub GetDatos(ByRef dg As DataGridView)
        Dim dt As New DataTable
        dt = cnt.LlenarDataTable("select * from catzona ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idnivel"), dr("idzona"), dr("zona"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"))
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CZona) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            sql = "INSERT INTO catzona values "
            sql = sql + " ('" + clase.Nivel.IdNivel + "','" + clase.IdZona + "','" + clase.Zona + "','" + clase.IdEstatus + "',"
            sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catzona set idestatus = '" + clase.IdEstatus + "',"
            sql = sql + "zona ='" + clase.Zona + "',orden ='" + clase.Orden.ToString + "',idnivel='" + clase.Nivel.IdNivel + "',"
            sql = sql + "sysuser ='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE IDZONA ='" + clase.IdZona + "' "

        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catzona where IDNIVEL='" + clase.Nivel.IdNivel + "' AND IDZONA = '" + clase.IdZona + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())

        Return resp

    End Function

#End Region

End Class
