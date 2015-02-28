Public Class CTiempoRespuesta
    Dim pIdTiempoRespuesta As String
    Dim pNombre As String
    Dim pDias As String
    Dim pHoras As String
    Dim pMinutos As String
    Dim pSegundos As String


    Public Property IdTiempoRespueta As String
        Get
            Return pIdTiempoRespuesta
        End Get
        Set(ByVal value As String)
            pIdTiempoRespuesta = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return pNombre
        End Get
        Set(ByVal value As String)
            pNombre = value
        End Set
    End Property

    Public Property Dias As String
        Get
            Return pDias
        End Get
        Set(ByVal value As String)
            pDias = value
        End Set
    End Property

    Public Property Horas As String
        Get
            Return pHoras
        End Get
        Set(ByVal value As String)
            pHoras = value
        End Set
    End Property

    Public Property Minutos As String
        Get
            Return pMinutos
        End Get
        Set(ByVal value As String)
            pMinutos = value
        End Set
    End Property

    Public Property Segundos As String
        Get
            Return pSegundos
        End Get
        Set(ByVal value As String)
            pSegundos = value
        End Set
    End Property


End Class
