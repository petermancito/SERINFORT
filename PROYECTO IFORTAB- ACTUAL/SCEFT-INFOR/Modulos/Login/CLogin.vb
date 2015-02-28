Public Class CLogin

    Dim puser As New CUser
    Public Property user() As CUser
        Get
            Return puser
        End Get
        Set(ByVal value As CUser)
            puser = value
        End Set
    End Property

End Class
