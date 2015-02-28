Public Structure CUsers

    Shared pUser As New CUser
    Dim p As String


    Sub New(ByRef user As CUsers)
        user = New CUsers
    End Sub

    Public Shared Property MYUserActual() As CUser
        Get
            Return pUser
        End Get
        Set(ByVal value As CUser)
            pUser = value
        End Set
    End Property


End Structure
