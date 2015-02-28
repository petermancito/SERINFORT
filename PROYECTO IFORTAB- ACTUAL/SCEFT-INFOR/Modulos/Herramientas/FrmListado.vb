Public Class FrmListado
    Dim cnt As New LogicaNegocio.CConexionSql
    Dim dt As New DataTable
    Dim resp As String
    Dim tipo_ls As String

    Public Enum TIPO_LISTADO
        DEPENDENCIA = 0
        TIPO_DOC = 1
        TIPO_ATENCION = 2
        TIEMPO_RESP = 3
        AREA_PERSONAL = 4
        ESTATUS_CORRESPONDENCIA = 5
    End Enum

    Private Sub FrmListadoAreas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dt = cnt.LlenarDataTable(Me.getSql)

        Me.dgListado.Rows.Clear()

        If (dt.Rows.Count > 0) Then
            For i = 0 To dt.Rows.Count - 1
                Application.DoEvents()
                Dim dr As DataRow = dt.Rows(i)
                With Me.dgListado.Rows
                    .Add(i + 1, dr("nombre"), dr("id"))
                End With
            Next
        End If
    End Sub
    Public Overloads Function ShowDialog(ByRef tipo As TIPO_LISTADO) As String
        tipo_ls = tipo.ToString
        Me.ShowDialog()
        Return resp
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        resp = ""
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (Me.dgListado.Rows.Count > 0) Then
            resp = Me.dgListado.Rows(Me.dgListado.CurrentCell.RowIndex).Cells("Clave").Value.ToString.Trim
        Else
            resp = ""
        End If
        Me.Close()
    End Sub

    Private Function getSql() As String
        Dim sql_respueta As String = ""

        If (tipo_ls = "AREA_PERSONAL") Then
            Me.lbtitulo1.Text = "AREAS DE ATENCION"
            Me.lbTitulo2.Text = "LISTADO AREAS DE ATENCION"
            sql_respueta = "select idareaatencion as id,areaatencion as nombre from catareaatencion"
        End If

        If (tipo_ls = "DEPENDENCIA") Then
            Me.lbtitulo1.Text = "DEPENDENCIAS"
            Me.lbTitulo2.Text = "LISTADO DEPENDENCIAS"
            sql_respueta = "select iddependencia as id,dependencia as nombre from catdependencia"
        End If

        If (tipo_ls = "TIEMPO_RESP") Then
            Me.lbtitulo1.Text = "TIEMPO DE RESPUESTA"
            Me.lbTitulo2.Text = "LISTADO TIEMPO DE RESPUESTA"
            sql_respueta = "select idtiemporespuesta as id,nombre as nombre from cattiemporespuesta"
        End If


        If (tipo_ls = "TIPO_ATENCION") Then
            Me.lbtitulo1.Text = "TIPO DE ATENCION"
            Me.lbTitulo2.Text = "LISTADO TIPOS DE ATENCIÓN"
            sql_respueta = "select idtipoatencion as id,nombre as nombre from cattipoatencion"
        End If


        If (tipo_ls = "TIPO_DOC") Then
            Me.lbtitulo1.Text = "DOCUMENTOS"
            Me.lbTitulo2.Text = "LISTADO DE TIPOS DE DOCUMENTOS"
            sql_respueta = "select idtipodocumento as id,documento as nombre from cattipodocumento"
        End If

        If (tipo_ls = "ESTATUS_CORRESPONDENCIA") Then
            Me.lbtitulo1.Text = "CORRESPONDENCIA"
            Me.lbTitulo2.Text = "LISTADO DE MARCACIONES"
            sql_respueta = "select idestatus as id,estatus as nombre from catestatuscorrespondencia"
        End If


        Application.DoEvents()

        Return sql_respueta

    End Function
End Class