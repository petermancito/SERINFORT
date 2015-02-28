Public Class CInitDatosSistema
    Dim Init As CInicializer
    Dim cnt As New LogicaNegocio.CConexionSql
    Dim dtDatos As New DataTable

    Private Function InitDatosAcceso(ByRef tipo As String, ByRef campo As String) As DataTable
        dtDatos = cnt.LlenarDataTable("SELECT valor FROM tblconfig where tipo= '" + tipo + "' order by orden")
        Return dtDatos
    End Function
    Public Function getIniDatos(ByRef tipo As String, ByRef campo As String) As String
        Dim resp As String
        Dim dt As New DataTable
        dt = InitDatosAcceso(tipo, campo)

        resp = ""

        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow = dt.Rows(i)

            If (i = 0) Then
                resp = dr("valor").ToString.Trim
            Else
                resp = resp + "*" + dr("valor").ToString.Trim
            End If
        Next

        Return resp
    End Function
End Class
