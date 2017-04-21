Namespace DIN25463MOX
    Public Class MyInterpolation


        Private zeitschritte As Integer
        Private zeiten(1000) As Double
        Private funk(1000) As Double

        Public Sub New()
            Dim i As Integer

            For i = 0 To 1000
                zeiten(i) = 0.0#
                funk(i) = 0.0#
            Next i

        End Sub

        Public Function SetZeitSchritte(ByVal t As Integer) As Boolean

            zeitschritte = t

        End Function

        Public Function SetZeit(ByVal t As Integer, ByVal z As Double) As Boolean

            zeiten(t) = z

        End Function

        Public Function SetFunk(ByVal t As Integer, ByVal z As Double) As Boolean

            funk(t) = z

        End Function

        Public Function GetZeit(ByVal t As Integer) As Double

            GetZeit = zeiten(t)

        End Function

        Public Function GetFunk(ByVal t As Integer) As Double

            GetFunk = funk(t)

        End Function

        Public Function GetInterpol(ByVal t As Double) As Double
            ' find value of function func at time t

            Dim r As Double
            Dim i As Integer

            r = 0

            For i = 0 To (zeitschritte - 1)

                If (zeiten(i) <= t And t < zeiten(i + 1)) Then
                    Exit For
                End If

            Next i

            If (t < zeiten(zeitschritte)) Then
                r = funk(i) + (t - zeiten(i)) * (funk(i + 1) - funk(i)) / (zeiten(i + 1) - zeiten(i))
            Else
                r = funk(zeitschritte)
            End If

            GetInterpol = r

        End Function


    End Class
End Namespace
