Public Class FrmDocentes

    Private _frmMain As FrmMain

    Sub New(ByVal frmMain As FrmMain)
        ' TODO: Complete member initialization 
        _frmMain = frmMain
        InitializeComponent()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New FrmDocentesReg
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub FrmDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        _frmMain.RemoveTab(Me.Tag)
    End Sub

    Private Sub txtPropietario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPropietario.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class