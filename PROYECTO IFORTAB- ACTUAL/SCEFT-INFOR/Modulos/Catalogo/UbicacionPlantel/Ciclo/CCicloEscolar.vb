
Public Class CCicloEscolar

    Dim pIdciclo As String
    Dim pCiclo As String
    Dim pIdEstatus As String
    Dim pOrden As Integer
    Dim cnt As New LogicaNegocio.CConexionSql



#Region "Propiedades"

    Public Property Idciclo() As String
        Get
            Return pIdciclo
        End Get
        Set(ByVal value As String)
            pIdciclo = value
        End Set
    End Property

    Public Property Ciclo() As String
        Get
            Return pCiclo
        End Get
        Set(ByVal value As String)
            pCiclo = value
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

    Public Property Orden() As Integer
        Get
            Return pOrden
        End Get
        Set(ByVal value As Integer)
            pOrden = value
        End Set
    End Property

#End Region


#Region "Metodos"
    Public Sub GetDatos(ByRef dg As DataGridView)
        Dim dt As New DataTable
        dt = cnt.LlenarDataTable("select * from catciclo ORDER BY ORDEN")
        dg.Rows.Clear()
        If (dt.Rows.Count > 0) Then
            Application.DoEvents()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("idciclo"), dr("ciclo"), dr("idestatus"), dr("orden"), dr("sysuser"), dr("sysdata"))
                End With
            Next
        End If
    End Sub

    Public Function ExecuteOperation(ByRef tipo As String, ByRef clase As CCicloEscolar) As Integer
        Dim resp As Integer
        Dim sql As String = ""

        If (tipo = "ADD") Then
            sql = "INSERT INTO catciclo values "
            sql = sql + " ('" + clase.Idciclo + "','" + clase.IdEstatus + "','" + clase.Ciclo + "',"
            sql = sql + " '" + clase.Orden.ToString + "','" + CUsers.MYUserActual.IdUsuario + "',GETDATE())"
        ElseIf tipo = "MOD" Then
            sql = "UPDATE catciclo set idestatus='" + clase.IdEstatus + "',"
            sql = sql + "ciclo='" + clase.Ciclo + "',orden ='" + clase.Orden.ToString + "',"
            sql = sql + "sysuser='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() WHERE IDCICLO='" + clase.Idciclo + "'"
        ElseIf tipo = "DEL" Then
            sql = "DELETE FROM catciclo where idciclo='" + clase.Idciclo + "'"
        End If
        resp = cnt.ExecuteSql(sql, cnt.Conectar())
        Return resp

    End Function

#End Region

End Class
