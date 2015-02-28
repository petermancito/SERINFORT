Public Class CArea
    Dim pIdArea As String
    Dim pArea As String


    Public Property IdArea() As String
        Get
            Return pIdArea
        End Get
        Set(ByVal value As String)
            pIdArea = value
        End Set
    End Property

    Public Property Area() As String
        Get
            Return pArea
        End Get
        Set(ByVal value As String)
            pArea = value
        End Set
    End Property
End Class
