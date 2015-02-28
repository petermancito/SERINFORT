Public Class CIconos
    Public Property Img As Image

    Public Function getIcono(ByRef nombre As String) As Image

        If (nombre = "EDUCANDOS") Then
            Img = SCEFT_INFOR.My.Resources.Resources.areaFormacion
        End If
        If (nombre = "PLANTELES") Then
            Img = SCEFT_INFOR.My.Resources.Resources.areaFormacion
        End If
        If (nombre = "CURSOS") Then
            Img = SCEFT_INFOR.My.Resources.Resources.user2
        End If


        Return Img

    End Function

End Class
