Public Class frmAcceso
    Dim login As New CLogin
    Dim cnt As New LogicaNegocio.CConexionSql
    Dim init As New CInitDatosSistema

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click, btnCancelar.Click, btnConfig.Click


        If (sender Is btnIngresar) Then
            Me.btnMarque.Enabled = True
            Application.DoEvents()
            login.user.GetUsuariosLogin(Me.txtUsuario.Text, Me.txtPassword.Text)

            If (CUsers.MYUserActual.IdUsuario = "0") Then
                Me.btnMarque.Enabled = False
                Exit Sub
            End If

            Dim main As New FrmMain
            Me.Hide()
            main.WindowState = FormWindowState.Maximized
            main.ShowDialog()
            main.Close()
            Application.Exit()
        ElseIf sender Is btnCancelar Then
            Me.Close()
        ElseIf sender Is btnConfig Then
            Me.ShowConfig()
        End If

    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InitDatosServer()
        Catch ex As Exception
            If (My.Settings.DatosInicio.Length = 0) Then
                InitDatosLocal()
            Else
                InitDatosServer()
            End If
        End Try

        'If (My.Settings.DatosInicio.Length = 0) Then
        '    InitDatosLocal()
        'Else
        '    InitDatosServer()
        'End If


        Me.lbVersion.Text = "Versión:" + Application.ProductVersion


        If (My.Settings.myConfig.Length = 0) Then
            MessageBox.Show("No hay Configuración registrada, debe configurar su conexión", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Me.ShowConfig()
        End If
        Me.btnMarque.ProgressBar.Enabled = False
        'Me.txtServer.Text = cnt.Servidor

    End Sub

    Public Sub InitDatosLocal()
        My.Settings.DatosInicio = "SISTEMA DE CONTROL ESCOLAR*DEPARTAMENTO DE CONTROL ESCOLAR*DEL ESTADO DE TABASCO*SCEFT-INFOR*INGRESAR A SCEFT-INFOR"

        Dim arre() As String
        arre = My.Settings.DatosInicio.Split("*")

        Me.lbTitulo1.Text = arre(0)
        Me.lbTitulo2.Text = arre(1)
        Me.lbTitulo3.Text = arre(2)
        Me.lbTitulo4.Text = arre(3)
        Me.lbTitulo5.Text = arre(4)

    End Sub

    Public Sub InitDatosServer()
        'My.Settings.DatosInicio = "SISTEMA DE CONTROL ESCOLAR*INSTITUTO DE FORMACION PARA EL TRABAJO*DEL ESTADO DE TABASCO*SCEFT-INFOR*INGRESAR A SCEFT-INFOR"
        Try
            Dim arre() As String
            arre = init.getIniDatos("frmAcceso", "").Split("*")

            Me.lbTitulo1.Text = arre(0)
            'Me.lbTitulo1.TextAlign = ContentAlignment.MiddleCenter
            Me.lbTitulo2.Text = arre(1)
            'Me.lbTitulo2.TextAlign = ContentAlignment.MiddleCenter
            Me.lbTitulo3.Text = arre(2)
            'Me.lbTitulo3.TextAlign = ContentAlignment.MiddleCenter

            Me.lbTitulo4.Text = arre(3)
            Me.lbTitulo5.Text = arre(4)
        Catch ex As Exception

        End Try


        Application.DoEvents()

    End Sub


    Private Sub ShowConfig()
        Dim conf As New FrmConfig
        conf.ShowDialog()
        conf.Dispose()
    End Sub
End Class
