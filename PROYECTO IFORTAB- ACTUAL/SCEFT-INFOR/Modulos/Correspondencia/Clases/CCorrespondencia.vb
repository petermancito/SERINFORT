Imports System.IO
Imports Npgsql



Public Class CCorrespondencia
    Dim pCatalogo As New CCatalogo
    Dim pFolio As String
    Dim pNoOficio As String
    Dim pDescripcion As String
    Dim pSolicitante As String

    Dim pDiasRespuesta As String
    Dim pFechaSolicitud As String

    Dim pIdestatus As String
    Dim pAsunto As String
    Dim pRuta As String

    Dim pIdCorrespondencia As String

    Dim pObservacion As String
    Dim pFechaResp As String
    Dim pHoraResp As String

    Dim pFechaInicio As String
    Dim pFechaFin As String

    Dim pColor As String

    Dim cnt As New LogicaNegocio.CConexionSql


#Region "Própiedades"

    Public Property IdCorrespondencia() As String
        Get
            Return pIdCorrespondencia
        End Get
        Set(ByVal value As String)
            pIdCorrespondencia = value
        End Set
    End Property

    Public Property FechaInicio() As String
        Get
            Return pFechaInicio
        End Get
        Set(ByVal value As String)
            pFechaInicio = value
        End Set
    End Property

    Public Property FechaFin() As String
        Get
            Return pFechaFin
        End Get
        Set(ByVal value As String)
            pFechaFin = value
        End Set
    End Property


    Public Property Color() As String
        Get
            Return pColor
        End Get
        Set(ByVal value As String)
            pColor = value
        End Set
    End Property


    Public Property Catalogo() As CCatalogo
        Get
            Return pCatalogo
        End Get
        Set(ByVal value As CCatalogo)
            pCatalogo = value
        End Set
    End Property

    Public Property Observacion() As String
        Get
            Return pObservacion
        End Get
        Set(ByVal value As String)
            pObservacion = value
        End Set
    End Property

    Public Property FechaResp() As String
        Get
            Return pFechaResp
        End Get
        Set(ByVal value As String)
            pFechaResp = value
        End Set
    End Property

    Public Property HoraResp() As String
        Get
            Return pHoraResp
        End Get
        Set(ByVal value As String)
            pHoraResp = value
        End Set
    End Property



    Public Property Folio() As String
        Get
            Return pFolio
        End Get
        Set(ByVal value As String)
            pFolio = value
        End Set
    End Property

    Public Property NoOficio() As String
        Get
            Return pNoOficio
        End Get
        Set(ByVal value As String)
            pNoOficio = value
        End Set
    End Property


    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property


    Public Property Solicitante() As String
        Get
            Return pSolicitante
        End Get
        Set(ByVal value As String)
            pSolicitante = value
        End Set
    End Property


    Public Property DiasRespuesta() As String
        Get
            Return pDiasRespuesta
        End Get
        Set(ByVal value As String)
            pDiasRespuesta = value
        End Set
    End Property

   


    Public Property FechaSolicitud() As String
        Get
            Return pFechaSolicitud
        End Get
        Set(ByVal value As String)
            pFechaSolicitud = value
        End Set
    End Property



    Public Property IdEstatus() As String
        Get
            Return pIdestatus
        End Get
        Set(ByVal value As String)
            pIdestatus = value
        End Set
    End Property


    Public Property Asunto() As String
        Get
            Return pAsunto
        End Get
        Set(ByVal value As String)
            pAsunto = value
        End Set
    End Property

    Public Property Ruta() As String
        Get
            Return pRuta
        End Get
        Set(ByVal value As String)
            pRuta = value
        End Set
    End Property

    





#End Region

    Public Function getColor(ByRef color As String) As Drawing.Color
        Dim col As New Drawing.Color

        If (color = "ROJO") Then
            col = Drawing.Color.Red
        ElseIf (color = "VERDE") Then
            col = Drawing.Color.Green
        ElseIf (color = "AMARILLO") Then
            col = Drawing.Color.Yellow
        ElseIf (color = "MORADO") Then
            col = Drawing.Color.Purple
        ElseIf (color = "ROSA") Then
            col = Drawing.Color.Pink
        ElseIf (color = "NARANJA") Then
            col = Drawing.Color.Orange
        ElseIf (color = "AZUL") Then
            col = Drawing.Color.Blue
        Else
            col = Drawing.Color.Black
        End If

        Return col
    End Function

    Public Function getCorrespondenciaActualizarEstatus(ByRef corresp As CCorrespondencia) As String
        Dim resp As Integer
        Dim sql As String

        sql = "update tblcorrespondencia set idestatus='" + corresp.IdEstatus + "', "
        sql = sql & "idtipodoc='" + corresp.Catalogo.TipoDocumento.IdTipoDocumento + "', "
        sql = sql & "idtipoatencion='" + corresp.Catalogo.TipoAtencion.IdTipoAtencion + "', "
        sql = sql & "idtiemporespuesta='" + corresp.Catalogo.TiempoRespuesta.IdTiempoRespueta + "', "
        sql = sql & "folio='" + corresp.Folio + "', "
        sql = sql & "nooficio='" + corresp.NoOficio + "', "
        sql = sql & "fechasolicitud='" + corresp.FechaSolicitud + "', "
        sql = sql & "iddependencia='" + corresp.Catalogo.Dependencia.IdDependencia + "', "
        sql = sql & "idarea='" + corresp.Catalogo.Area.IdArea + "', "
        sql = sql & "solicitante='" + corresp.Solicitante + "', "
        sql = sql & "asunto='" + corresp.Asunto + "', "
        sql = sql & "descripcion='" + corresp.Descripcion + "', "
        sql = sql & "fecharespuesta='" + corresp.FechaResp + "', "
        sql = sql & "horarespuesta='" + corresp.HoraResp.ToString.Substring(0, 8) + "', "
        sql = sql & "sysdata='" + Me.GetDATE() + "', "
        sql = sql & "sysuser='" + CUsers.MYUserActual.IdUsuario + "' "
        sql = sql & " where idcorrespondencia = '" + corresp.IdCorrespondencia + "'"

        resp = cnt.ExecuteSql(sql)
        Return resp
    End Function

    Public Function getCorrespondenciaTraspaso(ByRef corresp As CCorrespondencia) As String
        Dim resp As Integer
        Dim sql As String

        sql = "update tblcorrespondencia set idarea='" + corresp.Catalogo.Area.IdArea + "', "
        sql = sql & "sysdata='" + Me.GetDATE() + "', "
        sql = sql & "sysuser='" + CUsers.MYUserActual.IdUsuario + "' "
        sql = sql & " where idcorrespondencia = '" + corresp.IdCorrespondencia + "'"

        resp = cnt.ExecuteSql(sql)
        Return resp
    End Function


    Public Function getCorrespondencia(ByRef corresp As CCorrespondencia, ByRef fi As String, ByRef ff As String) As DataTable
        Dim sql As String
        Dim dt As New DataTable


        sql = "SELECT * FROM VCORRESPONDENCIA WHERE "
        sql = sql & " date(dguardo) between '" + fi + "' and '" + ff + "' "
        'date('2011-01-25') between fecha_inicio and fecha_fin

        If (IdEstatus <> "") Then
            sql = sql & " AND IDESTATUS = '" + corresp.IdEstatus + "' "
        End If

        dt = cnt.LlenarDataTable(sql)

        Return dt
    End Function

    Public Function getCorrespondenciaId(ByRef corresp As CCorrespondencia) As CCorrespondencia
        Dim sql As String
        Dim dt As New DataTable


        sql = "SELECT * FROM vctrl_correspondencia WHERE idcorrespondencia = '" + corresp.IdCorrespondencia + "' "

        dt = cnt.LlenarDataTable(sql)

        If (dt.Rows.Count > 0) Then
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                corresp.IdCorrespondencia = dr("idcorrespondencia").ToString.Trim
                corresp.Catalogo.TipoDocumento.IdTipoDocumento = dr("idtipodoc").ToString.Trim
                corresp.Folio = dr("folio").ToString.Trim
                corresp.NoOficio = dr("nooficio").ToString.Trim
                corresp.Catalogo.Dependencia.IdDependencia = dr("iddependencia").ToString.Trim
                corresp.Catalogo.Area.IdArea = dr("idarea").ToString.Trim
                corresp.Descripcion = dr("descripcion").ToString.Trim

                corresp.FechaSolicitud = dr("fechasolicitud").ToString.Trim

                corresp.Solicitante = dr("solicitante").ToString.Trim
                corresp.FechaResp = dr("fecharespuesta").ToString.Trim
                corresp.HoraResp = dr("horarespuesta").ToString.Trim
                corresp.IdEstatus = dr("idestatus").ToString.Trim
                corresp.Asunto = dr("asunto").ToString.Trim

                corresp.Catalogo.TipoAtencion.IdTipoAtencion = dr("idtipoatencion").ToString.Trim
                corresp.Catalogo.TiempoRespuesta.IdTiempoRespueta = dr("idtiemporespuesta").ToString.Trim



            Next
        End If

        Return corresp
    End Function

    Public Function getGuardarCorrespondencia(ByRef item As CCorrespondencia) As Integer

        Dim resp As Integer

        'para el almacenamiento del archivo
        'Dim Myfile As System.IO.FileStream
        'Myfile = File.OpenRead(item.Ruta)


        'Dim Arr(Myfile.Length) As Byte


        'Myfile.Read(Arr, 0, Myfile.Length)

      

        Dim sql2 As String
        sql2 = "insert into tblcorrespondencia values (@id,@tipo,@atencion,@tiempo,@folio,"
        sql2 = sql2 & " @nooficio,@fechasol,@dependencia,@area,@solicitante,@asunto,@descripcion,"
        sql2 = sql2 & " @idestatus,@fecharesp,@horaresp,@sysdata,@sysuser"
        sql2 = sql2 & " )"

            'item.IdCorrespondencia = Me.GetID


        '          idcorrespondencia character(30) NOT NULL,
        'idtipodoc character(6),
        'idtipoatencion character(21),
        'idtiemporespuesta character(21),
        'folio character(20),
        'nooficio character(20),
        'fechasolicitud character(10),
        'iddependencia character(6),
        'idarea character(6),
        'solicitante character(200),
        'asunto character(60),
        'descripcion character(200),
        'idestatus character(6),
        'fecharespuesta character(10),
        'horarespuesta character(10),
        'sysdata character(31),
        '          sysuser(character(12))


        Dim cmd As New NpgsqlCommand(sql2, cnt.Conectar)
        With cmd.Parameters
            .Add("@id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.IdCorrespondencia
            .Add("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Catalogo.TipoDocumento.IdTipoDocumento
            .Add("@atencion", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Catalogo.TipoAtencion.IdTipoAtencion
            .Add("@tiempo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Catalogo.TiempoRespuesta.IdTiempoRespueta
            .Add("@folio", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Folio
            .Add("@nooficio", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.NoOficio
            .Add("@fechasol", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.FechaSolicitud
            .Add("@dependencia", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Catalogo.Dependencia.IdDependencia
            .Add("@area", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Catalogo.Area.IdArea
            .Add("@solicitante", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Solicitante
            .Add("@asunto", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Asunto
            .Add("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Descripcion
            .Add("@idestatus", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.IdEstatus
            .Add("@fecharesp", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.FechaResp
            .Add("@horaresp", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.HoraResp.ToString.Substring(0, 8)
            .Add("@sysdata", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Me.GetDATE()
            .Add("@sysuser", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CUsers.MYUserActual.IdUsuario
        End With
            resp = "0"

            If (cmd.ExecuteNonQuery > 0) Then
                resp = 1
            End If




        Return resp
    End Function

    Public Sub getArchivoGuardar(ByRef doc As CDocumentos, ByRef abrir As Boolean, ByRef ext As String)
        Dim sql As String

        sql = "select dato from tbldocumentos where iddocumento = '" + doc.IdDocumento + "'"


        Dim cmd As New NpgsqlCommand(sql, cnt.Conectar)
        Dim result As Byte() = cmd.ExecuteScalar()
        Dim fs As FileStream
        Dim rutaAct As String
        'Dim rutaNuevo As String
        Dim rutaSafe As String = ""

        Dim fil As New SaveFileDialog
        'fil.Filter = "Archivos de Oficios (.pdf)|*.pdf"

        fil.Filter = "Archivo *" + ext + "|*" + ext + ""

        'Image Files (*.bmp, *.jpg)|*.bmp;*.jpg

        If (doc.Descripcion.Length > 10) Then
            fil.FileName = "" + doc.Descripcion.Substring(0, 10)
        Else
            fil.FileName = "" + doc.Descripcion
        End If


        'fil.FileName = fil.Fi

        If (fil.ShowDialog = Windows.Forms.DialogResult.OK) Then
            rutaSafe = fil.FileName + "" + ext
        Else
            fil.Dispose()
            Exit Sub
        End If
        fil.Dispose()


        Dim rutaNuevo As String = My.Computer.FileSystem.GetTempFileName()


        My.Computer.FileSystem.RenameFile(rutaNuevo, rutaNuevo.Split("\")(rutaNuevo.Split("\").Count - 1).Split(".")(0) + "" + ext + "")
        rutaAct = Me.CrearRuta(rutaNuevo, rutaNuevo.Split("\")(rutaNuevo.Split("\").Count - 1).Split(".")(0) + "" + ext + "")

        'My.Computer.FileSystem.RenameFile(rutaNuevo, rutaNuevo.Split("\")(rutaNuevo.Split("\").Count - 1).Split(".")(0) + "" + ext + "")
        'rutaAct = Me.CrearRuta(rutaNuevo, rutaNuevo.Split("\")(rutaNuevo.Split("\").Count - 1).Split(".")(0) + "" + ext + "")





        fs = New FileStream(rutaAct, FileMode.Truncate, FileAccess.Write)

        Dim bw As New BinaryWriter(New BufferedStream(fs))
        bw.Write(result)
        bw.Flush()
        bw.Close()


        If (abrir = True) Then
            If (rutaSafe <> "") Then
                FileCopy(rutaAct, rutaSafe)

                If (MessageBox.Show("¿Desea Abrir el Documento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes) Then
                    Process.Start(rutaSafe)
                End If

            End If

            'Process.Start(rutaAct)
            'File.Delete(rutaAct)
        End If
    End Sub

    Public Sub getArchivoPDF(ByRef doc As CDocumentos, ByRef abrir As Boolean, ByRef ext As String)
        Dim sql As String

        sql = "select dato from tbldocumentos where iddocumento = '" + doc.IdDocumento + "'"


        Dim cmd As New NpgsqlCommand(sql, cnt.Conectar)
        Dim result As Byte() = cmd.ExecuteScalar()
        Dim fs As FileStream
        Dim rutaAct As String


        Dim rutaNuevo As String = My.Computer.FileSystem.GetTempFileName()

        'My.Computer.FileSystem.RenameFile(rutaNuevo, "" + doc.IdDocumento + "" + ext)


        My.Computer.FileSystem.RenameFile(rutaNuevo, rutaNuevo.Split("\")(rutaNuevo.Split("\").Count - 1).Split(".")(0) + "" + ext + "")
        rutaAct = Me.CrearRuta(rutaNuevo, rutaNuevo.Split("\")(rutaNuevo.Split("\").Count - 1).Split(".")(0) + "" + ext + "")






        fs = New FileStream(rutaAct, FileMode.Truncate, FileAccess.Write)



        Dim bw As New BinaryWriter(New BufferedStream(fs))
        bw.Write(result)
        bw.Flush()
        bw.Close()


        If (abrir = True) Then
            Process.Start(rutaAct)
            'File.Delete(rutaAct)
        End If
    End Sub

    Private Function CrearRuta(ByRef rutaAnt As String, ByRef nomArchivo As String) As String
        Dim arreglo() As String
        arreglo = rutaAnt.Split("\")
        Dim resp As String = ""

        For i = 0 To arreglo.Count - 1
            If (i <> arreglo.Count - 1) Then
                resp = resp + "" + arreglo(i) + "/"
            End If
        Next

        resp = resp + "" + nomArchivo
        Return resp
    End Function

    Public Function GetDATE() As String
        Dim cmd As New NpgsqlCommand("select getdate()", cnt.Conectar)
        Dim result As String = cmd.ExecuteScalar()
        Return result
    End Function

    Public Function GetID() As String
        Dim cmd As New NpgsqlCommand("select getiddocumento()", cnt.Conectar)
        Dim result As String = cmd.ExecuteScalar()
        Return result.ToString.Trim
    End Function


End Class
