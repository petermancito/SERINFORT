Public Class CDependencia
    Dim pIdDependencia As String
    Dim pDependencia As String

    Public Property IdDependencia() As String
        Get
            Return pIdDependencia
        End Get
        Set(ByVal value As String)
            pIdDependencia = value
        End Set
    End Property

    Public Property Dependencia() As String
        Get
            Return pDependencia
        End Get
        Set(ByVal value As String)
            pDependencia = value
        End Set
    End Property

End Class
