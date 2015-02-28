Imports System.IO
Imports Npgsql


Public Class CDocumentos
    Dim pIdDocumento As String
    Dim pIdCorrespondencia As String
    Dim pIdTipoDocumento As New CTipoDocumento
    Dim pDescripcion As String
    Dim pDato As Byte
    Dim pExtArchivo As String
    Dim cnt As New LogicaNegocio.CConexionSql
    Dim corresp As New CCorrespondencia
    Dim pRuta As String


#Region "propiedades"



    Public Property IdDocumento As String
        Get
            Return pIdDocumento
        End Get
        Set(ByVal value As String)
            pIdDocumento = value
        End Set
    End Property

    Public Property Ruta As String
        Get
            Return pRuta
        End Get
        Set(ByVal value As String)
            pRuta = value
        End Set
    End Property


    Public Property IdCorrespondencia As String
        Get
            Return pIdCorrespondencia
        End Get
        Set(ByVal value As String)
            pIdCorrespondencia = value
        End Set
    End Property

    Public Property IdTipoDocumento As CTipoDocumento
        Get
            Return pIdTipoDocumento
        End Get
        Set(ByVal value As CTipoDocumento)
            pIdTipoDocumento = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property

    Public Property Dato As Byte
        Get
            Return pDato
        End Get
        Set(ByVal value As Byte)
            pDato = value
        End Set
    End Property
    Public Property ExtensionArchivo As String
        Get
            Return pExtArchivo
        End Get
        Set(ByVal value As String)
            pExtArchivo = value
        End Set
    End Property

#End Region

#Region "Metodos"
    Public Function getDocumentos(ByRef dg As DataGridView, ByRef corresp As CCorrespondencia) As Integer
        Dim dt As New DataTable
        Dim sql As String

        sql = "select * from tbldocumentos where idcorrespondencia = '" + corresp.IdCorrespondencia.ToString + "'"

        dg.Rows.Clear()

        dt = cnt.LlenarDataTable(sql)

        If (dt.Rows.Count > 0) Then
            For i = 0 To dt.Rows.Count - 1

                Application.DoEvents()

                Dim dr As DataRow = dt.Rows(i)
                With dg.Rows
                    .Add(i + 1, dr("descripcion").ToString.Trim, dr("ext").ToString.Trim, dr("idtipodocumento"), dr("iddocumento").ToString.Trim, dr("sysuser"), dr("sysdata"))
                End With

            Next
        End If


        Return dt.Rows.Count
    End Function

    Public Function getGuardarDocumento(ByRef doc As CDocumentos) As Integer
        Dim resp As Integer

        'para el almacenamiento del archivo
        Dim Myfile As System.IO.FileStream
        Myfile = File.OpenRead(doc.ruta)


        Dim Arr(Myfile.Length) As Byte


        Myfile.Read(Arr, 0, Myfile.Length)

        Dim sql2 As String
        sql2 = "insert into tbldocumentos values (@id,@idcorresp,@tipo,@descripcion,@dato,@ext,@sysdata,@sysuser)"

        'item.IdCorrespondencia = Date.Today.Year & Date.Today.Month & Date.Today.Day & Date.Today.Minute & Date.Today.Second & Date.Now.Millisecond & Date.Today.DayOfYear


        Dim cmd As New NpgsqlCommand(sql2, cnt.Conectar)
        With cmd.Parameters
            .Add("@id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = corresp.GetID()
            .Add("@idcorresp", NpgsqlTypes.NpgsqlDbType.Varchar).Value = doc.IdCorrespondencia
            .Add("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = doc.IdTipoDocumento.IdTipoDocumento.ToString.Trim
            .Add("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar).Value = doc.Descripcion
            .Add("@dato", NpgsqlTypes.NpgsqlDbType.Bytea).Value = Arr
            .Add("@ext", NpgsqlTypes.NpgsqlDbType.Varchar).Value = doc.ExtensionArchivo
            .Add("@sysdata", NpgsqlTypes.NpgsqlDbType.Varchar).Value = corresp.GetDATE()
            .Add("@sysuser", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CUsers.MYUserActual.IdUsuario
        End With
        resp = "1"
        If (cmd.ExecuteNonQuery = 0) Then
            resp = 0
        End If

        Return resp

    End Function

#End Region




End Class
