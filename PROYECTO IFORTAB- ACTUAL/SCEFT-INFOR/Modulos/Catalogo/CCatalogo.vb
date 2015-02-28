
Public Class CCatalogo
    Dim parea As New CArea
    Dim pdepend As New CDependencia
    Dim pTipoDoc As New CTipoDocumento
    Dim pCiclo As New CCicloEscolar
    Dim pNivel As New CNivel
    Dim pZona As New CZona
    Dim pAreaFormacion As New CAreaFormacion
    Dim pEspecialidad As New CEspecialidad
    Dim pTiempoRespuesta As New CTiempoRespuesta
    Dim pTipoAtencion As New CTipoAtencion
    Dim pModelo As New CModelo
    Dim pPeriodo As New CPeriodo

    Public Property Curso As New CCurso



    Public Property TiempoRespuesta() As CTiempoRespuesta
        Get
            Return pTiempoRespuesta
        End Get
        Set(ByVal value As CTiempoRespuesta)
            pTiempoRespuesta = value
        End Set
    End Property

    Public Property TipoAtencion() As CTipoAtencion
        Get
            Return pTipoAtencion
        End Get
        Set(ByVal value As CTipoAtencion)
            pTipoAtencion = value
        End Set
    End Property



    Public Property AreaFormacion() As CAreaFormacion
        Get
            Return pAreaFormacion
        End Get
        Set(ByVal value As CAreaFormacion)
            pAreaFormacion = value
        End Set
    End Property


    Public Property Area() As CArea
        Get
            Return parea
        End Get
        Set(ByVal value As CArea)
            parea = value
        End Set
    End Property

    Public Property Ciclo As CCicloEscolar
        Get
            Return pCiclo
        End Get
        Set(ByVal value As CCicloEscolar)
            pCiclo = value
        End Set
    End Property




    Public Property Dependencia() As CDependencia
        Get
            Return pdepend
        End Get
        Set(ByVal value As CDependencia)
            pdepend = value
        End Set
    End Property

    Public Property TipoDocumento() As CTipoDocumento
        Get
            Return pTipoDoc
        End Get
        Set(ByVal value As CTipoDocumento)
            pTipoDoc = value
        End Set
    End Property

    Public Property Nivel() As CNivel
        Get
            Return pNivel
        End Get
        Set(ByVal value As CNivel)
            pNivel = value
        End Set
    End Property

    Public Property Zona() As CZona
        Get
            Return pZona
        End Get
        Set(ByVal value As CZona)
            pZona = value
        End Set
    End Property

    Public Property Especialidad() As CEspecialidad
        Get
            Return pEspecialidad
        End Get
        Set(ByVal value As CEspecialidad)
            pEspecialidad = value
        End Set
    End Property

    Public Property Modelo() As CModelo
        Get
            Return pModelo
        End Get
        Set(ByVal value As CModelo)
            pModelo = value
        End Set
    End Property


    Public Property Periodo() As CPeriodo
        Get
            Return pPeriodo
        End Get
        Set(ByVal value As CPeriodo)
            pPeriodo = value
        End Set
    End Property





End Class
