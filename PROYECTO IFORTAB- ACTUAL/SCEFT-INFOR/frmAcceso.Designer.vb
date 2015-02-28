<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcceso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btnMarque = New System.Windows.Forms.ToolStripProgressBar()
        Me.lbTitulo5 = New System.Windows.Forms.Label()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.lbTitulo4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lbTitulo3 = New System.Windows.Forms.Label()
        Me.lbTitulo2 = New System.Windows.Forms.Label()
        Me.lbTitulo1 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMarque})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 364)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(475, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btnMarque
        '
        Me.btnMarque.Name = "btnMarque"
        Me.btnMarque.Size = New System.Drawing.Size(100, 16)
        Me.btnMarque.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'lbTitulo5
        '
        Me.lbTitulo5.AutoSize = True
        Me.lbTitulo5.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo5.Location = New System.Drawing.Point(136, 104)
        Me.lbTitulo5.Name = "lbTitulo5"
        Me.lbTitulo5.Size = New System.Drawing.Size(202, 23)
        Me.lbTitulo5.TabIndex = 3
        Me.lbTitulo5.Text = "INGRESAR A SCEFT-INFO"
        '
        'btnIngresar
        '
        Me.btnIngresar.Location = New System.Drawing.Point(247, 302)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(90, 41)
        Me.btnIngresar.TabIndex = 6
        Me.btnIngresar.Text = "LOGIN"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(343, 302)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 41)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(60, 302)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(41, 41)
        Me.btnConfig.TabIndex = 8
        Me.btnConfig.Text = "::"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'lbVersion
        '
        Me.lbVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbVersion.AutoSize = True
        Me.lbVersion.BackColor = System.Drawing.Color.Transparent
        Me.lbVersion.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersion.Location = New System.Drawing.Point(376, 76)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(89, 20)
        Me.lbVersion.TabIndex = 10
        Me.lbVersion.Text = "Versión: 0.0.1"
        '
        'lbTitulo4
        '
        Me.lbTitulo4.AutoSize = True
        Me.lbTitulo4.BackColor = System.Drawing.Color.Transparent
        Me.lbTitulo4.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo4.Location = New System.Drawing.Point(7, 75)
        Me.lbTitulo4.Name = "lbTitulo4"
        Me.lbTitulo4.Size = New System.Drawing.Size(94, 20)
        Me.lbTitulo4.TabIndex = 9
        Me.lbTitulo4.Text = "SCEFT-INFOR"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(59, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 144)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(128, 91)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(184, 26)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "123"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(132, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 19)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Password"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(128, 40)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(181, 26)
        Me.txtUsuario.TabIndex = 1
        Me.txtUsuario.Text = "PETERMANCITO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(132, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Usuario"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.SCEFT_INFOR.My.Resources.Resources.user
        Me.PictureBox1.Location = New System.Drawing.Point(17, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(82, 82)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SCEFT_INFOR.My.Resources.Resources.RepeatHeadWindows
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.lbTitulo3)
        Me.Panel1.Controls.Add(Me.lbTitulo2)
        Me.Panel1.Controls.Add(Me.lbTitulo1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 73)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SCEFT_INFOR.My.Resources.Resources.logo
        Me.PictureBox2.Location = New System.Drawing.Point(342, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(128, 65)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'lbTitulo3
        '
        Me.lbTitulo3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTitulo3.AutoSize = True
        Me.lbTitulo3.BackColor = System.Drawing.Color.Transparent
        Me.lbTitulo3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo3.Location = New System.Drawing.Point(2, 44)
        Me.lbTitulo3.Name = "lbTitulo3"
        Me.lbTitulo3.Size = New System.Drawing.Size(182, 24)
        Me.lbTitulo3.TabIndex = 6
        Me.lbTitulo3.Text = "DEL ESTADO DE TABASCO"
        Me.lbTitulo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTitulo3.UseCompatibleTextRendering = True
        '
        'lbTitulo2
        '
        Me.lbTitulo2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTitulo2.AutoSize = True
        Me.lbTitulo2.BackColor = System.Drawing.Color.Transparent
        Me.lbTitulo2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo2.Location = New System.Drawing.Point(2, 26)
        Me.lbTitulo2.Name = "lbTitulo2"
        Me.lbTitulo2.Size = New System.Drawing.Size(313, 24)
        Me.lbTitulo2.TabIndex = 5
        Me.lbTitulo2.Text = "INSTITUTO DE FORMACIÓN PARA EL TRABAJO"
        Me.lbTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTitulo2.UseCompatibleTextRendering = True
        '
        'lbTitulo1
        '
        Me.lbTitulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTitulo1.AutoSize = True
        Me.lbTitulo1.BackColor = System.Drawing.Color.Transparent
        Me.lbTitulo1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo1.Location = New System.Drawing.Point(2, 4)
        Me.lbTitulo1.Name = "lbTitulo1"
        Me.lbTitulo1.Size = New System.Drawing.Size(300, 30)
        Me.lbTitulo1.TabIndex = 4
        Me.lbTitulo1.Text = "SISTEMA DE CONTROL ESCOLAR"
        Me.lbTitulo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTitulo1.UseCompatibleTextRendering = True
        '
        'frmAcceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 386)
        Me.Controls.Add(Me.lbVersion)
        Me.Controls.Add(Me.lbTitulo4)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbTitulo5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAcceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbTitulo1 As System.Windows.Forms.Label
    Friend WithEvents lbTitulo2 As System.Windows.Forms.Label
    Friend WithEvents lbTitulo3 As System.Windows.Forms.Label
    Friend WithEvents lbTitulo5 As System.Windows.Forms.Label
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnMarque As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents lbTitulo4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
