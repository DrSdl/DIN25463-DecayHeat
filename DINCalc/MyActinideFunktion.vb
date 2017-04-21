Namespace DIN25463MOX
    Public Class MyActinideFunktion

        Inherits MyFunktion


        Private Function_nvar As Integer
        Private ystart(21) As Double
        Private sigmaf(21) As Double
        Private sigmac(21) As Double
        Private sigman2n(21) As Double
        Private leistung As Double
        Private pfi As Double
        Private lambda(21) As Double
        Private lambdas(21, 21) As Double
        Private sigmas(21, 21) As Double
        Private Qi(21) As Double
        Private epsilon As Double


        Public Sub New()

            Dim i As Integer

            For i = 1 To 21
                Qi(i) = 200.0#
            Next i

            Qi(2) = 202.4
            Qi(5) = 209.0#
            Qi(11) = 211.4
            Qi(13) = 213.9

            epsilon = 0.00000000000016022

            pfi = 0.0#
            leistung = 0.0#

        End Sub

        Public Overrides Function SetNk(ByRef Nk() As Double) As Boolean

        End Function

        Public Overrides Function SetSigma(ByRef f() As Double, ByRef c() As Double, ByRef n2n() As Double) As Boolean

            Dim i As Integer

            For i = 1 To 21
                sigmaf(i) = f(i)
                sigmac(i) = c(i)
                sigman2n(i) = n2n(i)
            Next i

        End Function

        Public Overrides Function SetLambda(ByRef l() As Double) As Boolean

            Dim i As Integer

            For i = 1 To 21
                lambda(i) = l(i)
            Next i

        End Function


        Public Overrides Function SetPhi(ByRef p As Double) As Boolean

            pfi = p

        End Function

        Public Overrides Function SetPower(ByRef p As Double) As Boolean

            leistung = p

        End Function

        Public Overrides Function GetPhi() As Double
            GetPhi = pfi
        End Function

        Public Overrides Function GetPower() As Double
            GetPower = leistung
        End Function

        Public Overrides Function SetXN(ByRef ls(,) As Double, ByRef ss(,) As Double) As Boolean

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 21
                For j = 1 To 21
                    lambdas(i, j) = ls(i, j)
                    sigmas(i, j) = ss(i, j)
                Next j
            Next i

        End Function


        Public Overrides Function SetNVar(ByVal nvar As Integer) As Boolean
            Function_nvar = nvar
        End Function

        Public Overrides Function SetStart(ByRef y() As Double) As Boolean

            Dim i As Integer

            For i = 1 To Function_nvar

                ystart(i) = y(i)

            Next i

        End Function

        Public Overrides Function GetStart(ByVal N As Integer) As Double

            GetStart = ystart(N)

        End Function


        Public Overrides Function derivs(ByRef x As Double, ByRef y() As Double, ByRef dydx() As Double) As Boolean

            Dim N As Integer
            Dim s As Integer
            Dim sum As Double
            Dim phi As Double

            phi = 0

            If (leistung > 0.0#) Then
                ' ****************************** power > 0 ********************************
                For N = 1 To 21
                    phi = phi + (Qi(N) * sigmaf(N) * y(N))
                Next N

                phi = leistung / (epsilon * phi)
                pfi = phi

                For N = 1 To 21
                    dydx(N) = -1.0# * lambda(N) * y(N) - (sigmaf(N) + sigmac(N) + sigman2n(N)) * phi * y(N)
                Next N

                'Worksheets("function").Cells(30, 3) = phi

                For N = 1 To 21

                    sum = 0
                    For s = 1 To 21
                        sum = sum + (lambdas(N, s) + sigmas(N, s) * phi) * y(s)
                    Next s

                    dydx(N) = dydx(N) + sum

                Next N

            Else
                ' ****************************** power = 0 ********************************
                For N = 1 To 21
                    dydx(N) = -1.0# * lambda(N) * y(N)
                Next N

                For N = 1 To 21

                    sum = 0
                    For s = 1 To 21
                        sum = sum + (lambdas(N, s)) * y(s)
                    Next s

                    dydx(N) = dydx(N) + sum

                Next N

            End If



        End Function

        Public Overrides Function jacobn(ByRef x As Double, ByRef y() As Double, ByRef dfdx() As Double, ByRef dfdy(,) As Double, ByRef nn As Integer) As Boolean

            Dim N As Integer
            Dim s As Integer
            Dim k As Integer
            Dim sum As Double
            Dim sum1 As Double

            Dim phi As Double
            Dim dphids As Double

            phi = 0

            If (leistung > 0.0#) Then
                ' ****************************** power > 0 ********************************
                For N = 1 To 21
                    phi = phi + (Qi(N) * sigmaf(N) * y(N))
                Next N

                sum1 = phi
                phi = leistung / (epsilon * phi)


                For N = 1 To 21
                    dfdx(N) = 0
                Next N


                For N = 1 To 21
                    For s = 1 To 21
                        dfdy(N, s) = 0.0#
                    Next s
                Next N


                For N = 1 To 21
                    For s = 1 To 21

                        dphids = -1.0# * phi / sum1

                        sum = 0
                        For k = 1 To 21
                            sum = sum + (Qi(k) * sigmaf(k) * GetDirac(k, s))
                        Next k

                        dphids = dphids * sum

                        dfdy(N, s) = (-1.0# * lambda(N) - (sigmaf(N) + sigmac(N) + sigman2n(N)) * phi) * GetDirac(N, s) - (sigmaf(N) + sigmac(N) + sigman2n(N)) * y(N) * dphids

                        sum = 0
                        For k = 1 To 21
                            sum = sum + (lambdas(N, k) + sigmas(N, k) * phi) * GetDirac(k, s)
                        Next k

                        dfdy(N, s) = dfdy(N, s) + sum

                        sum = 0
                        For k = 1 To 21
                            sum = sum + (sigmas(N, k) * y(k))
                        Next k

                        dfdy(N, s) = dfdy(N, s) + sum * dphids

                    Next s
                Next N

            Else

                ' ****************************** power = 0 ********************************
                For N = 1 To 21
                    dfdx(N) = 0
                Next N


                For N = 1 To 21
                    For s = 1 To 21
                        dfdy(N, s) = 0.0#
                    Next s
                Next N


                For N = 1 To 21
                    For s = 1 To 21


                        dfdy(N, s) = (-1.0# * lambda(N)) * GetDirac(N, s)

                        sum = 0
                        For k = 1 To 21
                            sum = sum + (lambdas(N, k)) * GetDirac(k, s)
                        Next k

                        dfdy(N, s) = dfdy(N, s) + sum


                    Next s
                Next N

            End If



        End Function

        Public Overrides Function SetYfi(ByRef fi(,) As Double) As Boolean

        End Function



        Public Function GetDirac(ByRef N As Integer, ByRef s As Integer) As Double

            If (N = s) Then
                GetDirac = 1.0#
            Else
                GetDirac = 0.0#
            End If

        End Function

        Public Overrides Function CalcPhi() As Boolean

            Dim N As Integer
            Dim phi As Double

            phi = 0

            For N = 1 To 21
                phi = phi + (Qi(N) * sigmaf(N) * ystart(N))
            Next N

            phi = leistung / (epsilon * phi)
            pfi = phi

        End Function

    End Class
End Namespace