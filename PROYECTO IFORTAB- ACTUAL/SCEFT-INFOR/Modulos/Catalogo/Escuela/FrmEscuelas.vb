Public Class FrmEscuelas

    Private _frmMain As FrmMain
    Private cbx As New CCombox
    Dim esc As New CEscuela

    Sub New(ByVal frmMain As FrmMain)
        ' TODO: Complete member initialization 
        _frmMain = frmMain
        InitializeComponent()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New FrmEscuelasReg
        frm.isNuevo = True
        frm.ShowDialog()
        If (frm.isSafe = True) Then
            Me.btnCargar_Click(sender, e)
        End If
        frm.Close()
    End Sub

    

    Private Sub FrmEscuelas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbx.getCmbLlenarComboxs(Me.cmbCiclo, "CAT_CICLO")
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        _frmMain.RemoveTab(Me.Tag)
    End Sub

    Private Sub btnGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrupos.Click
        Dim frm As New FrmConfiguraCurso
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click


        Dim dt As New DataTable
        esc.Idciclo = Me.cmbCiclo.SelectedValue.ToString.Trim
        esc.Idescuela = Me.txtCct.Text.ToString.Trim

        dt = esc.getEscuelaConsulta(esc, checkCiclo.Checked)

        Me.dgDatos.Rows.Clear()

        If (dt.Rows.Count = 0) Then
            Exit Sub
        End If

        Dim frm As New FProgresoComp
        frm.Show()
        frm.pgAvance.Maximum = dt.Rows.Count
        frm.pgAvance.Minimum = 0



        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow = dt.Rows(i)




            frm.lbRegistros.Text = dr("escuela").ToString.Trim
            frm.pgAvance.Value = i + 1


            Application.DoEvents()

            With Me.dgDatos.Rows
                .Add(i + 1, dr("idciclo"), dr("idescuela").ToString().Trim, dr("escuela").ToString().Trim, _
                        dr("tipoescuela"), dr("ubicacion"), dr("domicilio"), dr("entrecalle"), _
                        dr("YCalle").ToString().Trim, dr("Colonia").ToString().Trim, _
                        dr("codpostal").ToString().Trim, dr("Telefono").ToString().Trim)

            End With

        Next
        frm.Close()




    End Sub

    Private Sub dgDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellContentClick

    End Sub
End Class