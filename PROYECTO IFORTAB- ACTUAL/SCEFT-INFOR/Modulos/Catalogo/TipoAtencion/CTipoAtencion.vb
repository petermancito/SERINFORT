Public Class CTipoAtencion
    Dim pIdTipoAtencion As String
    Dim pTipoAtencion As String

    Public Property IdTipoAtencion As String
        Get
            Return pIdTipoAtencion
        End Get
        Set(ByVal value As String)
            pIdTipoAtencion = value
        End Set
    End Property

    Public Property TipoAtencion As String
        Get
            Return pTipoAtencion
        End Get
        Set(ByVal value As String)
            pTipoAtencion = value
        End Set
    End Property


End Class
