Public Class FrmMain

    Dim contador As Integer
    Dim init As New CInitDatosSistema

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TabControl1.TabPages.RemoveAt(0)
        contador = 0
        frmAcceso.InitDatosServer()

        ModCorrespondenciaConfig.DiasHabiles = init.getIniDatos("frmConfCorrespondencia", "DIAS HABILES")


    End Sub

    Private Sub mnuCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCerrar.Click
        Application.Exit()
    End Sub




    Private Sub AddNewTab(ByRef frm As Form, ByRef titulo As String)
        Dim form As New Form
        form = frm
        Dim tab As New TabPage(titulo)
        form.Name = "f" + contador.ToString
        form.TopLevel = False
        form.WindowState = FormWindowState.Maximized
        form.FormBorderStyle = FormBorderStyle.None
        tab.Controls.Add(form)
        Me.TabControl1.TabPages.Add(tab)
        Me.TabControl1.SelectedTab = tab
        form.Show()

    End Sub

    Public Sub RemoveTab(ByRef cont As Integer)
        Try

            Dim current_tab As TabPage = Me.TabControl1.SelectedTab
            Me.TabControl1.TabPages.Remove(current_tab)
            current_tab.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    


    Private Sub EscuelasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EscuelasToolStripMenuItem.Click
        'Me.AddNewTab(New FrmEscuelas(Me), "Escuelas")
        'contador = contador + 1
    End Sub

   
    Private Sub UsuariosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddNewTab(New FrmUsuarios(Me), "Usuarios")
        contador = contador + 1
    End Sub

    Private Sub CicloEscolarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CicloEscolarToolStripMenuItem.Click
        Dim frm As New FrmCiclo
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub NivelEscolarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NivelEscolarToolStripMenuItem.Click
        Dim frm As New FrmNivel
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub ZonasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New FrmZona
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub AreasDeFormaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AreasDeFormaciónToolStripMenuItem.Click
        Dim frm As New FrmAreaFormacion
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub EspecialidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EspecialidadesToolStripMenuItem.Click
        Dim frm As New FrmEspecialidad
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub CursosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CursosToolStripMenuItem.Click
        Dim frm As New FrmCurso
        frm.ShowDialog()
        frm.Close()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        Me.AddNewTab(New FrmUsuarios(Me), "Usuarios")
        contador = contador + 1
    End Sub

    Private Sub ConfigCorrespondenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigCorrespondenciaToolStripMenuItem.Click
        Dim frmConfig As New FrmConfigCorrespondencia
        frmConfig.ShowDialog()
        frmConfig.Close()
    End Sub

    Private Sub AlumnosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlumnosToolStripMenuItem1.Click
        Me.AddNewTab(New FrmAlumnos(Me), "Educando")
        contador = contador + 1
    End Sub

    

    Private Sub EscuelasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EscuelasToolStripMenuItem1.Click
        Me.AddNewTab(New FrmEscuelas(Me), "Planteles")
        contador = contador + 1
    End Sub

    Private Sub CorrespondenciaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorrespondenciaToolStripMenuItem1.Click
        Me.AddNewTab(New FrmCorrespondencia(Me), "Correspondencia")
        contador = contador + 1
    End Sub

    Private Sub InstructoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstructoresToolStripMenuItem.Click
        Me.AddNewTab(New FrmDocentes(Me), "Instructores")
        contador = contador + 1
    End Sub

    Private Sub CursosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CursosToolStripMenuItem2.Click
        Dim reg As New FrmCursosReg
        reg.ShowDialog()
        reg.Close()
    End Sub

    Private Sub ModelosEducativosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModelosEducativosToolStripMenuItem.Click
        Dim reg As New FrmModelo
        reg.ShowDialog()
        reg.Close()
    End Sub

    Private Sub PeriodoEscolarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodoEscolarToolStripMenuItem.Click
        Dim reg As New FrmPeriodo
        reg.ShowDialog()
        reg.Close()
    End Sub

    Private Sub ReporteDeEscuelasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ReporteDeGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeGruposToolStripMenuItem.Click
        
    End Sub

End Class