Public Class CAreaFormacion
    Dim pIdArea As String
    Dim pArea As String
    Dim pestatus As String
    Dim porden As Integer

    Dim cnt As New LogicaNegocio.CConexionSql

#Region "propiedades"


    Public Property IdArea As String
        Get
            Return pIdArea
        End Get
        Set(ByVal value As String)
            pIdArea = value
        End Set
    End Property

    Public Property Area As String
        Get
            Return pArea
        End Get
        Set(ByVal value As String)
            pArea = value
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
        dt = cnt.LlenarDataTable("select * from catareaformacion ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idareaformacion"), dr("areaformacion"), dr("idestatus"), dr("orden").ToString, dr("sysuser"), dr("sysdata"))
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CAreaFormacion) As Integer
        Dim resp As Integer
        Dim sql As String = ""
        Try
            If (tipo = "ADD") Then
                sql = "INSERT INTO catareaformacion values "
                sql = sql + " ('" + clase.IdArea + "','" + clase.Area + "','" + clase.IdEstatus + "',"
                sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
            ElseIf tipo = "MOD" Then
                sql = "UPDATE catareaformacion set idestatus='" + clase.IdEstatus + "',"
                sql = sql + "areaformacion='" + clase.Area + "',orden ='" + clase.Orden.ToString + "',"
                sql = sql + "sysuser='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE idareaformacion ='" + clase.IdArea + "' "
            ElseIf tipo = "DEL" Then
                sql = "DELETE FROM catareaformacion where idareaformacion ='" + clase.IdArea + "' "
            End If

            resp = cnt.ExecuteSql(sql, cnt.Conectar())
        Catch EX As Exception
            MsgBox(EX.Message & " - " & EX.Source)
        End Try

        Return resp

    End Function

#End Region


End Class
