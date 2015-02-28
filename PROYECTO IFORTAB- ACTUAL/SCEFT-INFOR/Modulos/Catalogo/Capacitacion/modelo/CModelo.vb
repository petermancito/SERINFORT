Public Class CModelo
    Dim pIdmodelo As String
    Dim pModelo As String
    Dim pestatus As String
    Dim porden As Integer

#Region "propiedades"

    Dim cnt As New LogicaNegocio.CConexionSql
    Public Property IdModelo As String
        Get
            Return pIdmodelo
        End Get
        Set(ByVal value As String)
            pIdmodelo = value
        End Set
    End Property

    Public Property Modelo As String
        Get
            Return pModelo
        End Get
        Set(ByVal value As String)
            pModelo = value
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
        dt = cnt.LlenarDataTable("select * from catmodelo ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idmodelo"), dr("modelo"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"))
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CModelo) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            sql = "INSERT INTO catmodelo values "
            sql = sql + " ('" + clase.IdModelo + "','" + clase.Modelo + "','" + clase.IdEstatus + "',"
            sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catmodelo set idestatus='" + clase.IdEstatus + "',"
            sql = sql + "modelo='" + clase.Modelo + "',orden ='" + clase.Orden.ToString + "',"
            sql = sql + "sysuser='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE idmodelo ='" + clase.IdModelo + "'"
        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catmodelo where idmodelo='" + clase.IdModelo + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())
        Return resp

    End Function

#End Region


End Class
