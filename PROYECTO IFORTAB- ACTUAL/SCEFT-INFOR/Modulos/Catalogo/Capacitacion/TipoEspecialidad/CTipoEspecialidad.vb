Public Class CTipoEspecialidad
    Dim pIdTipoEspecialidad As String
    Dim pTipoEspecialidad As String
    Dim pOrden As String
    Dim pIdEstatus As String

    Public Property IdTipoEspecialidad As String
        Get
            Return pIdTipoEspecialidad
        End Get
        Set(ByVal value As String)
            pIdTipoEspecialidad = value
        End Set
    End Property

    Public Property TipoEspecialidad As String
        Get
            Return pTipoEspecialidad
        End Get
        Set(ByVal value As String)
            pTipoEspecialidad = value
        End Set
    End Property
    Public Property Orden As String
        Get
            Return pOrden
        End Get
        Set(ByVal value As String)
            pOrden = value
        End Set
    End Property

    Public Property IdEstatus As String
        Get
            Return pIdEstatus
        End Get
        Set(ByVal value As String)
            pIdEstatus = value
        End Set
    End Property

End Class
