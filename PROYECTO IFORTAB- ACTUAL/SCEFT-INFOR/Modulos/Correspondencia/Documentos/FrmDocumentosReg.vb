Public Class FrmDocumentosReg
    Dim doc As New CDocumentos
    Dim cbx As New CCombox
    Public corresp As New CCorrespondencia
    Public isSafe As Boolean

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        Dim fil As New OpenFileDialog
        'fil.Filter = "Archivos de Oficios (.pdf)|*.pdf"
        If (fil.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.txtRuta.Text = fil.FileName
        End If
        fil.Dispose()
    End Sub

    Private Sub FrmDocumentosReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbArea, "CAT_AREAS")
        cbx.getCmbLlenarComboxs(Me.cmbTipoDoc, "CAT_TIPOSDOC")

        Me.txtAsunto.Text = corresp.Asunto
        Me.txtFolio.Text = corresp.Folio
        Me.txtNoOficio.Text = corresp.NoOficio
        Me.cmbArea.SelectedValue = corresp.Catalogo.Area.IdArea


    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        doc.IdCorrespondencia = corresp.IdCorrespondencia
        doc.Descripcion = Me.txtDescripcion.Text.Trim
        doc.ExtensionArchivo = "." + txtRuta.Text.Split(".")(txtRuta.Text.Split(".").Count - 1)
        doc.IdTipoDocumento.IdTipoDocumento = Me.cmbTipoDoc.SelectedValue.ToString.Trim
        doc.Ruta = Me.txtRuta.Text.Trim


        If (doc.getGuardarDocumento(doc) > 0) Then
            isSafe = True
            Me.Close()
        End If


    End Sub
End Class