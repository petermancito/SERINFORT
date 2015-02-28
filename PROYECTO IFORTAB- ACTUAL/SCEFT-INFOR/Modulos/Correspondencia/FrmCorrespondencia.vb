Public Class FrmCorrespondencia
    Public key As String
    Private _frmMain As FrmMain
    Private cbx As New CCombox
    Private corresp As New CCorrespondencia
    Private cnt As New LogicaNegocio.CConexionSql

    Sub New(ByVal frmMain As FrmMain)
        ' TODO: Complete member initialization 
        _frmMain = frmMain
        InitializeComponent()
    End Sub

   
    
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.btnActualizar_Click(sender, e)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim dt As New DataTable
        Dim sql As String
        corresp.IdEstatus = Me.cmbEstatus.SelectedValue.ToString.Trim
        corresp.FechaInicio = Me.txtFechaInicio.SelectionEnd.ToShortDateString.ToString.Trim
        corresp.FechaFin = Me.txtFechaFin.Text.Trim
        corresp.Asunto = Me.txtAsunto.Text.Trim



        If (Me.checkEntrega.Checked = True) Then
            sql = "select * from vctrl_correspondencia where cast(fecharespuesta as date)>='" + corresp.FechaInicio + "' "
            sql = sql & " and cast(fecharespuesta as date)<='" + corresp.FechaFin + "' "
        Else
            sql = "select * from vctrl_correspondencia where cast(fechasolicitud as date)>='" + corresp.FechaInicio + "' "
            sql = sql & " and cast(fechasolicitud as date)<='" + corresp.FechaFin + "' "

            If (Me.checkFiltro.Checked = False) Then
                If (corresp.IdEstatus <> "") Then
                    sql = sql & " and idestatus='" + corresp.IdEstatus + "'"
                End If
            End If
        End If

        'sql = "select * from vctrl_correspondencia where cast(fechasolicitud as date)>='" + corresp.FechaInicio + "' "
        'sql = sql & " and cast(fechasolicitud as date)<='" + corresp.FechaFin + "' "


       
        

        If (corresp.Asunto <> "") Then
            sql = sql & " and asunto like '%" + corresp.Asunto + "%' "
        End If


        Me.dgDatos.Rows.Clear()

        dt = cnt.LlenarDataTable(sql)


        If (dt.Rows.Count > 0) Then
            For i = 0 To dt.Rows.Count - 1

                Application.DoEvents()

                Dim dr As DataRow = dt.Rows(i)
                corresp.IdCorrespondencia = dr("idcorrespondencia").ToString.Trim
                corresp.Asunto = dr("asunto").ToString.Trim
                corresp.NoOficio = dr("noOficio").ToString.Trim
                corresp.Descripcion = dr("descripcion").ToString.Trim
                corresp.Catalogo.Dependencia.Dependencia = dr("dependencia").ToString.Trim
                corresp.Catalogo.TipoDocumento.TipoDocumento = dr("documento").ToString.Trim
                corresp.Catalogo.Area.Area = dr("areaatencion").ToString.Trim
                corresp.Color = dr("color").ToString.Trim
                corresp.FechaResp = dr("fecharespuesta").ToString.Trim
                corresp.HoraResp = dr("horarespuesta").ToString.Trim
                'System.Drawing.Color(dr("color").ToString.Trim)

                With Me.dgDatos.Rows
                    .Add(i + 1, corresp.Asunto, corresp.NoOficio, corresp.Descripcion, corresp.Catalogo.Dependencia.Dependencia, _
                        corresp.Catalogo.TipoDocumento.TipoDocumento, corresp.Catalogo.Area.Area, _
                        corresp.IdEstatus, corresp.FechaResp, corresp.HoraResp, dr("sysuser").ToString.Trim, dr("sysdata").ToString.Trim, corresp.IdCorrespondencia, corresp.Color)
                End With


                'Me.dgDatos.Rows(i).DefaultCellStyle.ForeColor =  new Drawing.FontConverter

                Me.dgDatos.Rows(i).DefaultCellStyle.ForeColor = corresp.getColor(corresp.Color)
                Me.dgDatos.Rows(i).DefaultCellStyle.SelectionForeColor = corresp.getColor(corresp.Color)



            Next
        End If



    End Sub

    Private Sub FrmCorrespondencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbEstatus, "CAT_CORRESP")
        cbx.getCmbLlenarComboxs(Me.cmbArea, "CAT_AREAS")
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstatus.SelectedIndexChanged
        'MsgBox(Me.cmbEstatus.SelectedValue)
        Me.btnActualizar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New FrmCorrespondenciaReg
        frm.isAdd = True
        frm.ShowDialog()
        If (frm.isSafe = True) Then
            Me.btnActualizar_Click(sender, e)
        End If
        frm.Close()
    End Sub

    Private Sub dgDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellDoubleClick

        Timer1.Enabled = False

        Dim frm As New FrmCorrespondenciaReg
        frm.isAdd = False
        InitDatos()
        frm.ShowDialog(corresp)
        If (frm.isSafe = True) Then
            Me.btnActualizar_Click(sender, e)
        End If
        frm.Close()

        Timer1.Enabled = True
    End Sub
    Private Sub InitDatos()
        Try
            corresp.IdCorrespondencia = Me.dgDatos.Rows(Me.dgDatos.CurrentCell.RowIndex).Cells("idcorrespondencia").Value.ToString.Trim
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        _frmMain.RemoveTab(Me.Tag)
    End Sub

    Private Sub btnDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumentos.Click
        Me.InitDatos()
        Dim frmDoc As New FrmDocumentos
        frmDoc.corresp = corresp
        frmDoc.ShowDialog()
        frmDoc.Close()
    End Sub


    Private Sub txtFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaFin.ValueChanged
        Me.btnActualizar_Click(sender, e)
    End Sub

    Private Sub RealizarMarcajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealizarMarcajeToolStripMenuItem.Click
        Dim ls As New FrmListado
        Dim resp As String
        resp = ls.ShowDialog(FrmListado.TIPO_LISTADO.ESTATUS_CORRESPONDENCIA)

        InitDatos()

        ls.Close()
        If (resp <> "") Then
            cnt.ExecuteSql("update tblcorrespondencia set idestatus = '" + resp + "',sysuser='" + CUsers.MYUserActual.IdUsuario + "',sysdata=GETDATE() where idcorrespondencia='" + corresp.IdCorrespondencia + "'")
        End If

        Me.btnActualizar_Click(sender, e)
    End Sub

    Private Sub btnTraspaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraspaso.Click
        InitDatos()
        Dim frm As New FrmCorrespondenciaTraspasos
        frm.corresp = corresp
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub txtFechaInicio_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles txtFechaInicio.DateChanged
        Me.btnActualizar_Click(sender, e)
    End Sub
End Class