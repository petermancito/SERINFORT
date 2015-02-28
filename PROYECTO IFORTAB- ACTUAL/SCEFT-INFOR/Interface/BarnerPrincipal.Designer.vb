<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarnerPrincipal
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.picIcono = New System.Windows.Forms.PictureBox()
        Me.lbTitulo = New System.Windows.Forms.Label()
        Me.lbSubtitulo = New System.Windows.Forms.Label()
        CType(Me.picIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picIcono
        '
        Me.picIcono.Location = New System.Drawing.Point(12, 8)
        Me.picIcono.Name = "picIcono"
        Me.picIcono.Size = New System.Drawing.Size(32, 32)
        Me.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcono.TabIndex = 0
        Me.picIcono.TabStop = False
        '
        'lbTitulo
        '
        Me.lbTitulo.AutoSize = True
        Me.lbTitulo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo.Location = New System.Drawing.Point(47, 4)
        Me.lbTitulo.Name = "lbTitulo"
        Me.lbTitulo.Size = New System.Drawing.Size(72, 25)
        Me.lbTitulo.TabIndex = 1
        Me.lbTitulo.Text = "Label1"
        '
        'lbSubtitulo
        '
        Me.lbSubtitulo.AutoSize = True
        Me.lbSubtitulo.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubtitulo.ForeColor = System.Drawing.Color.Red
        Me.lbSubtitulo.Location = New System.Drawing.Point(50, 29)
        Me.lbSubtitulo.Name = "lbSubtitulo"
        Me.lbSubtitulo.Size = New System.Drawing.Size(63, 19)
        Me.lbSubtitulo.TabIndex = 2
        Me.lbSubtitulo.Text = "Label2"
        '
        'BarnerPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbSubtitulo)
        Me.Controls.Add(Me.lbTitulo)
        Me.Controls.Add(Me.picIcono)
        Me.Name = "BarnerPrincipal"
        Me.Size = New System.Drawing.Size(389, 56)
        CType(Me.picIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picIcono As System.Windows.Forms.PictureBox
    Friend WithEvents lbTitulo As System.Windows.Forms.Label
    Friend WithEvents lbSubtitulo As System.Windows.Forms.Label

End Class
