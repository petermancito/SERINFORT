Module Module_functions
    Public Function valida_numero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        Return e
    End Function

End Module
