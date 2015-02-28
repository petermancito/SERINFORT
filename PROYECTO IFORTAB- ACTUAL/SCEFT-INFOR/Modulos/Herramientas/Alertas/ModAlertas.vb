Module ModAlertas

    Private ModAlertasMsgError = "Error"
    Private ModAlertasMsgAviso = "Aviso"
    Private ModAlertasMsgConfirma = "Mensaje de Confirmación"

    Public Sub AlertaError(ByRef texto As String)
        MessageBox.Show(texto, ModAlertasMsgError, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub AlertaAviso(ByRef texto As String)
        MessageBox.Show(texto, ModAlertasMsgAviso, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub AlertaConfirma(ByRef texto As String)
        MessageBox.Show(texto, ModAlertasMsgConfirma, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


End Module
