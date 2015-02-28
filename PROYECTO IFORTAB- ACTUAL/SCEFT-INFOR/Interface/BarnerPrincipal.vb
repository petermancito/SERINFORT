Public Class BarnerPrincipal


    
    Public Sub Datos(ByRef t1 As String, ByVal t2 As String, ByRef img As Image)
        Me.lbTitulo.Text = t1
        Me.lbSubtitulo.Text = "Registro de " & t2
        Me.picIcono.Image = img
    End Sub

    Private Sub BarnerPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
