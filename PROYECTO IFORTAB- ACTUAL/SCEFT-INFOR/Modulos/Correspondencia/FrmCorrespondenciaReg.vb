Public Class FrmCorrespondenciaReg
    Public isAdd As Boolean
    Public isSafe As Boolean

    Dim cbx As New CCombox
    Dim corresp As New CCorrespondencia
    Dim cnt As New LogicaNegocio.CConexionSql

    Private Sub FrmCorrespondenciaReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        cbx.getCmbLlenarComboxs(Me.cmbAreaAsignada, "CAT_AREAS")
        cbx.getCmbLlenarComboxs(Me.cmbDependencia, "CAT_DEPENDENCIAS")
        cbx.getCmbLlenarComboxs(Me.cmbTipoDocumento, "CAT_TIPOSDOC")
        cbx.getCmbLlenarComboxs(Me.cmbTipoAtencion, "CAT_TIPOATENCION")
        cbx.getCmbLlenarComboxs(Me.cmbTiempoRespuesta, "CAT_TIEMPORESPUESTA")



        If (isAdd = True) Then
            Me.btnDocumentos.Enabled = False
            Me.txtFechaSolicitud.Text = Date.Today.ToShortDateString
        Else
            Me.btnDocumentos.Enabled = True

            If (corresp.IdEstatus = "SOLADD") Then
                If (MessageBox.Show("¿Desea Modificar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No) Then
                    Me.BloquearDatos()
                End If
            Else
                Me.BloquearDatos()
            End If

            Me.InitDatos(corresp)

            'If (corresp.IdEstatus = "SOLSEG") Then

            'End If
        End If

    End Sub
    Public Overloads Sub ShowDialog(ByRef co As CCorrespondencia)
        corresp = co.getCorrespondenciaId(co)
        Me.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        isSafe = False
        Me.Close()
    End Sub

    Private Sub InitDatos(ByRef p As CCorrespondencia)
        Me.txtFolio.Text = p.Folio
        Me.txtNoOficio.Text = p.NoOficio
        Me.txtFechaSolicitud.Text = p.FechaSolicitud

        Me.cmbDependencia.SelectedValue = p.Catalogo.Dependencia.IdDependencia
        Me.txtAsunto.Text = p.Asunto
        Me.txtDescripcion.Text = p.Descripcion

        Me.cmbTipoDocumento.SelectedValue = p.Catalogo.TipoDocumento.IdTipoDocumento
        Me.cmbTipoAtencion.SelectedValue = p.Catalogo.TipoAtencion.IdTipoAtencion
        Me.cmbTiempoRespuesta.SelectedValue = p.Catalogo.TiempoRespuesta.IdTiempoRespueta
        Me.cmbAreaAsignada.SelectedValue = p.Catalogo.Area.IdArea.ToString.Trim

        'Me.txtObservaciones.Text = p.Observacion
        Me.txtFechaResp.Text = p.FechaResp
        Me.txtHoraResp.Text = p.HoraResp

    End Sub

    Private Sub BloquearDatos()
        Me.txtFolio.Enabled = False
        Me.txtNoOficio.Enabled = False
        Me.txtFechaSolicitud.Enabled = False
        Me.cmbDependencia.Enabled = False
        Me.txtAsunto.Enabled = False
        Me.txtDescripcion.Enabled = False

        Me.cmbTipoDocumento.Enabled = False
        Me.cmbTipoAtencion.Enabled = False
        Me.cmbTiempoRespuesta.Enabled = False
        Me.cmbAreaAsignada.Enabled = False

        'Me.txtObservaciones.Text = p.Observacion
        Me.txtHoraResp.Enabled = False
        Me.txtFechaResp.Enabled = False
    End Sub

    Private Sub Limpiar()
        Me.txtFolio.Text = ""
        Me.txtNoOficio.Text = ""
        Me.txtFechaSolicitud.Text = ""
        Me.cmbDependencia.SelectedValue = -1
        Me.txtAsunto.Text = ""
        Me.txtDescripcion.Text = ""

        Me.cmbTipoDocumento.SelectedValue = -1
        Me.cmbTipoAtencion.SelectedValue = -1
        Me.cmbTiempoRespuesta.SelectedValue = -1
        Me.cmbAreaAsignada.SelectedValue = -1

        'Me.txtObservaciones.Text = ""
        Me.txtHoraResp.Text = ""
        Me.txtFechaResp.Text = ""

    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        
        corresp.Folio = Me.txtFolio.Text.Trim
        corresp.NoOficio = Me.txtNoOficio.Text.Trim
        corresp.FechaSolicitud = Me.txtFechaSolicitud.Text.Trim
        corresp.Catalogo.Dependencia.IdDependencia = Me.cmbDependencia.SelectedValue.ToString.Trim
        corresp.Asunto = Me.txtAsunto.Text.Trim
        corresp.Descripcion = Me.txtDescripcion.Text.Trim

        corresp.Catalogo.TipoDocumento.IdTipoDocumento = Me.cmbTipoDocumento.SelectedValue.ToString.Trim
        corresp.Catalogo.TipoAtencion.IdTipoAtencion = Me.cmbTipoAtencion.SelectedValue.ToString.Trim
        corresp.Catalogo.TiempoRespuesta.IdTiempoRespueta = Me.cmbTiempoRespuesta.SelectedValue.ToString.Trim
        corresp.Catalogo.Area.IdArea = Me.cmbAreaAsignada.SelectedValue.ToString.Trim

        corresp.Observacion = ""
        corresp.Solicitante = Me.cmbDependencia.Text.Trim

        corresp.FechaResp = Me.txtFechaResp.Text
        corresp.HoraResp = Me.txtHoraResp.Text


        If (isAdd = True) Then
            corresp.IdEstatus = "SOLADD"
            corresp.IdCorrespondencia = corresp.GetID()

            If (corresp.getGuardarCorrespondencia(corresp) > 0) Then
                MessageBox.Show("Correspondencia Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                isSafe = True

                If (MessageBox.Show("¿Desea Agregar Documentos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    Dim frmDoc As New FrmDocumentosReg
                    frmDoc.corresp = corresp
                    frmDoc.ShowDialog()
                    frmDoc.Close()
                End If

                Me.Close()
            Else
                MessageBox.Show("Error al Registrar Correspondencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Dim isMod As Boolean
            Dim respuesta As String = ""

            'segun permiso se podra realzizar este marcaje
            If (MessageBox.Show("¿Desea Modificar el Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                isMod = True
            End If

            If (isMod = False) Then
                Dim frmAccion As New FrmListado
                respuesta = frmAccion.ShowDialog(FrmListado.TIPO_LISTADO.ESTATUS_CORRESPONDENCIA)
                frmAccion.Dispose()
            End If

            If (respuesta <> "") Then
                corresp.IdEstatus = respuesta
            End If


            If (corresp.getCorrespondenciaActualizarEstatus(corresp) > 0) Then
                MessageBox.Show("Correspondencia Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                isSafe = True
                Me.Close()
            Else
                MessageBox.Show("Error al Registrar Correspondencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'If (corresp.IdEstatus = "SOLADD") Then


            'Else
            '    Me.Close()
            'End If

        End If

    End Sub

    Private Sub btnDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumentos.Click
        Dim frmDoc As New FrmDocumentos
        frmDoc.corresp = corresp
        frmDoc.ShowDialog()
        frmDoc.Close()
    End Sub

   
    Private Function GetDias(ByRef fecha As String) As String
        Dim div() As String
        Dim divValor() As String

        div = fecha.Split(",")
        divValor = div(0).ToString.Split(" ")
        Return divValor(0)

    End Function
    Private Function GetHoras(ByRef fecha As String) As String
        Dim div() As String
        Dim divValor() As String

        div = fecha.Split(",")
        divValor = div(1).ToString.Split(" ")
        Return divValor(0)
    End Function
    Private Function GetMinutos(ByRef fecha As String) As String
        Dim div() As String
        Dim divValor() As String

        div = fecha.Split(",")
        divValor = div(2).ToString.Split(" ")
        Return divValor(0)
    End Function
    Private Sub GetTiempoRespuesta(ByRef tiempoRespuesta As String, ByRef FechaSolictud As String)
        Dim dias As String
        Dim horas As String
        Dim minutos As String
        Dim FechaRespuesta As Date
        Dim HoraRespuesta As String
        Dim HoraMinima As Integer = 7

        FechaRespuesta = CDate(FechaSolictud)

        dias = GetDias(tiempoRespuesta)
        horas = GetHoras(tiempoRespuesta)
        minutos = GetMinutos(tiempoRespuesta)

        FechaRespuesta = FechaRespuesta.AddDays(dias)

        If (Me.txtFechaResp.Text <> FechaRespuesta) Then
            FechaRespuesta = Me.txtFechaResp.Text
        End If

        HoraRespuesta = Me.GetHoraMaxima(FechaRespuesta, horas)


        Me.txtFechaResp.Text = CDate(FechaRespuesta)
        Me.txtHoraResp.Text = HoraRespuesta.ToString() & ":" & "" + minutos + "" & ":00"

    End Sub

    Private Function GetHoraMaxima(ByRef fecha As String, ByRef hora As String) As String
        Dim dt As New DataTable
        Dim HoraRespuesta As String


        dt = cnt.LlenarDataTable("select max(horarespuesta) as hora from tblcorrespondencia where fechaRespuesta='" + fecha + "' ")

        If (dt.Rows.Count = 0) Then
            HoraRespuesta = 8
        Else
            Dim dr As DataRow = dt.Rows(0)
            If (dr("hora").ToString.Trim = "") Then
                HoraRespuesta = 8 + CInt(hora)
            Else
                HoraRespuesta = CInt(dr("hora").ToString.Substring(0, 2)) + 1
            End If

        End If

        Return HoraRespuesta

    End Function


    Private Sub cmbTiempoRespuesta_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTiempoRespuesta.SelectedValueChanged
        If (Me.isAdd = True) Then
            Dim tiempo As String
            tiempo = cmbTiempoRespuesta.Text.ToString.Trim

            If (tiempo.ToString.Trim.Length <= 6 Or tiempo = "System.Data.DataRowView") Then
                Exit Sub
            End If

            Me.GetTiempoRespuesta(tiempo, Me.txtFechaSolicitud.Text)
            MostrarFechaRespuesta(txtFechaResp.Text)
        Else

            If (Me.corresp.FechaResp <> "") Then
                MostrarFechaRespuesta(corresp.FechaResp)
            End If
        End If
    End Sub

    Private Sub MostrarFechaRespuesta(ByRef fecha As String)

        Dim dia As String
        Dim numero As Integer
        Dim mes As String
        Dim anio As String

        numero = CDate(fecha).DayOfWeek
        mes = CDate(fecha).Month
        anio = CDate(fecha).Year

        dia = CDate(fecha).Day

        If (numero = "1") Then
            dia = "LUNES"
        ElseIf (numero = "2") Then
            dia = "MARTES"
        ElseIf (numero = "3") Then
            dia = "MIERCOLES"
        ElseIf (numero = "4") Then
            dia = "JUEVES"
        ElseIf (numero = "5") Then
            dia = "VIERNES"
        ElseIf (numero = "6") Then
            dia = "SABADO"
        ElseIf (numero = "0") Then
            dia = "DOMINGO"
        End If

        If (mes = 1) Then
            mes = "ENERO"
        ElseIf (mes = 2) Then
            mes = "FEBRERO"
        ElseIf (mes = 3) Then
            mes = "MARZO"
        ElseIf (mes = 4) Then
            mes = "ABRIL"
        ElseIf (mes = 5) Then
            mes = "MAYO"
        ElseIf (mes = 6) Then
            mes = "JUNIO"
        ElseIf (mes = 7) Then
            mes = "JULIO"
        ElseIf (mes = 8) Then
            mes = "AGOSTO"
        ElseIf (mes = 9) Then
            mes = "SEPTIEMBRE"
        ElseIf (mes = 10) Then
            mes = "OCTUBRE"
        ElseIf (mes = 11) Then
            mes = "NOVIEMBRE"
        ElseIf (mes = 12) Then
            mes = "DICIEMBRE"
        End If

        Me.lbFecha.Text = dia & " " & CDate(fecha).Day & " DE " & mes & " DEL " & anio
    End Sub


    Private Sub txtFechaSolicitud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaSolicitud.ValueChanged
        cmbTiempoRespuesta_SelectedValueChanged(sender, e)
    End Sub

   
    Private Sub txtFechaResp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaResp.ValueChanged
        If (Me.isAdd = True) Then
            Me.cmbTiempoRespuesta_SelectedValueChanged(sender, e)
        Else
            Me.MostrarFechaRespuesta(Me.corresp.FechaResp)
        End If
    End Sub

End Class