Public Class FrmDocumentos
    Dim doc As New CDocumentos
    Public corresp As New CCorrespondencia

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        corresp = corresp.getCorrespondenciaId(corresp)
        Me.lbTitulo.Text = corresp.Asunto + ""
        Me.doc.getDocumentos(Me.dgListado, corresp)

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frmAdd As New FrmDocumentosReg
        frmAdd.corresp = corresp
        frmAdd.ShowDialog()
        If (frmAdd.isSafe = True) Then
            Me.FrmDocumentos_Load(sender, e)
        End If
        frmAdd.Close()
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Me.InitDocumento()

        If (doc.IdDocumento <> "") Then
            corresp.getArchivoPDF(doc, True, doc.ExtensionArchivo)
        Else
            MessageBox.Show("No hay documentos seleccionados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub InitDocumento()
        doc.IdDocumento = ""
        If (Me.dgListado.Rows.Count > 0) Then
            doc.IdDocumento = Me.dgListado.Rows(Me.dgListado.CurrentCell.RowIndex).Cells("IdDocumento").Value.ToString.Trim
            doc.Descripcion = Me.dgListado.Rows(Me.dgListado.CurrentCell.RowIndex).Cells("Descripcion").Value.ToString.Trim
            doc.ExtensionArchivo = Me.dgListado.Rows(Me.dgListado.CurrentCell.RowIndex).Cells("Ext").Value.ToString.Trim
        End If
    End Sub

   
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.InitDocumento()

        If (doc.IdDocumento <> "") Then
            corresp.getArchivoGuardar(doc, True, doc.ExtensionArchivo)
        Else
            MessageBox.Show("No hay documentos seleccionados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class