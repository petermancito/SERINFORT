Public Class CCombox
    Dim cnt As New LogicaNegocio.CConexionSql

    Public Sub getCmbLlenarComboxs(ByRef cmb As ComboBox, ByRef tipo As String)
        'cmb.Items.Clear()

        Dim dt As New DataTable
        dt = cnt.LlenarDataTable("SELECT * FROM sp_comboxs('" + tipo + "') AS DATOS (id character(10),nom character(100))")

        cmb.DataSource = dt
        cmb.ValueMember = "id"
        cmb.DisplayMember = "nom"

    End Sub

    Public Sub getCmbLlenarPlantel(ByRef cmb As ComboBox, ByRef esc As CEscuela)
        Dim dt As New DataTable
        Dim sql As String

        sql = "SELECT idescuela id, escuela as nom from catescuela where idciclo='" + esc.Idciclo + "'  "
        sql = sql & " and idescuela <> '" + esc.Idescuela + "' "

        dt = cnt.LlenarDataTable(sql)

        cmb.DataSource = dt
        cmb.ValueMember = "id"
        cmb.DisplayMember = "nom"
    End Sub

    Public Sub getCmbLlenarEstado(ByRef cmb As ComboBox)
        Dim dt As New DataTable
        Dim sql As String

        sql = "SELECT idestado id, estado as nom from catestado order by orden "

        dt = cnt.LlenarDataTable(sql)

        cmb.DataSource = dt
        cmb.ValueMember = "id"
        cmb.DisplayMember = "nom"
    End Sub

    Public Sub getCmbLlenarMunicipio(ByRef cmb As ComboBox, ByRef idestado As String)
        Dim dt As New DataTable
        Dim sql As String

        sql = "SELECT idmunicipio id, municipio as nom from catmunicipio where idestado='" + idestado + "'  order by orden"

        dt = cnt.LlenarDataTable(sql)

        cmb.DataSource = dt
        cmb.ValueMember = "id"
        cmb.DisplayMember = "nom"
    End Sub


    Public Sub getCmbLlenarTipoEscuela(ByRef cmb As ComboBox)
        Dim dt As New DataTable
        Dim sql As String

        sql = "SELECT idtipoescuela id, tipoescuela as nom from cattipoescuela order by orden"

        dt = cnt.LlenarDataTable(sql)

        cmb.DataSource = dt
        cmb.ValueMember = "id"
        cmb.DisplayMember = "nom"
    End Sub

End Class
