Public Class CTipoDocumento
    Dim pIdTipoDocumento As String
    Dim pTipoDocumento As String
    Dim pDias As String

    Public Property IdTipoDocumento() As String
        Get
            Return pIdTipoDocumento
        End Get
        Set(ByVal value As String)
            pIdTipoDocumento = value
        End Set
    End Property

    Public Property TipoDocumento() As String
        Get
            Return pTipoDocumento
        End Get
        Set(ByVal value As String)
            pTipoDocumento = value
        End Set
    End Property

    Public Property Dias() As String
        Get
            Return pDias
        End Get
        Set(ByVal value As String)
            pDias = value
        End Set
    End Property


End Class
