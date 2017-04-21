Namespace DIN25463MOX
    Public Class MyFissionFunktion

        Inherits MyFunktion

        Private Function_nvar As Integer
        Private ystart(51) As Double
        Private sigmaf(51) As Double
        Private sigmac(51) As Double
        Private sigman2n(51) As Double
        Private leistung As Double
        Private pfi As Double
        Private lambda(51) As Double
        Private lambdas(51, 51) As Double
        Private sigmas(51, 51) As Double
        Private epsilon As Double
        Private y_fi(4, 51) As Double
        Private Nks(4) As Double
        Private sigmafiss(4) As Double



        Public Sub New()



            epsilon = 0.00000000000016022
            leistung = 0.0#

        End Sub



        Public Overrides Function SetNk(ByRef Nk() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 4
                Nks(i) = Nk(i)
            Next i
        End Function

        Public Overrides Function SetSigma(ByRef f() As Double, ByRef c() As Double, ByRef n2n() As Double) As Boolean

            Dim i As Integer

            For i = 1 To Function_nvar
                sigmaf(i) = f(i)
                sigmac(i) = c(i)
                sigman2n(i) = n2n(i)
            Next i

            sigmafiss(1) = f(Function_nvar + 1)
            sigmafiss(2) = f(Function_nvar + 2)
            sigmafiss(3) = f(Function_nvar + 3)
            sigmafiss(4) = f(Function_nvar + 4)


        End Function

        Public Overrides Function SetLambda(ByRef l() As Double) As Boolean

            Dim i As Integer

            For i = 1 To Function_nvar
                lambda(i) = l(i)
            Next i

        End Function


        Public Overrides Function SetPhi(ByRef p As Double) As Boolean

            pfi = p

        End Function

        Public Overrides Function SetPower(ByRef p As Double) As Boolean

            leistung = p

        End Function
        Public Overrides Function SetYfi(ByRef fi(,) As Double) As Boolean

            Dim i As Integer

            For i = 1 To Function_nvar
                y_fi(1, i) = fi(1, i)
                y_fi(2, i) = fi(2, i)
                y_fi(3, i) = fi(3, i)
                y_fi(4, i) = fi(4, i)
            Next i

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

            For i = 1 To Function_nvar
                For j = 1 To Function_nvar
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

            phi = pfi

            For N = 1 To Function_nvar
                dydx(N) = -1.0# * lambda(N) * y(N) - (sigmaf(N) + sigmac(N) + sigman2n(N)) * phi * y(N) + y_fi(1, N) * phi * Nks(1) * sigmafiss(1) + y_fi(2, N) * phi * Nks(2) * sigmafiss(2) + y_fi(3, N) * phi * Nks(3) * sigmafiss(3) + y_fi(4, N) * phi * Nks(4) * sigmafiss(4)
            Next N

            For N = 1 To Function_nvar

                sum = 0
                For s = 1 To Function_nvar
                    sum = sum + (lambdas(N, s) + sigmas(N, s) * phi) * y(s)
                Next s

                dydx(N) = dydx(N) + sum

            Next N


        End Function

        Public Overrides Function jacobn(ByRef x As Double, ByRef y() As Double, ByRef dfdx() As Double, ByRef dfdy(,) As Double, ByRef nn As Integer) As Boolean

            Dim N As Integer
            Dim s As Integer
            Dim k As Integer
            Dim sum As Double


            Dim phi As Double


            phi = pfi

            For N = 1 To Function_nvar
                dfdx(N) = 0
            Next N


            For N = 1 To Function_nvar
                For s = 1 To Function_nvar
                    dfdy(N, s) = 0.0#
                Next s
            Next N


            For N = 1 To Function_nvar
                For s = 1 To Function_nvar


                    dfdy(N, s) = (-1.0# * lambda(N) - (sigmaf(N) + sigmac(N) + sigman2n(N)) * phi) * GetDirac(N, s)

                    sum = 0
                    For k = 1 To Function_nvar
                        sum = sum + (lambdas(N, k) + sigmas(N, k) * phi) * GetDirac(k, s)
                    Next k

                    dfdy(N, s) = dfdy(N, s) + sum

                Next s
            Next N

        End Function

        Public Function GetDirac(ByRef N As Integer, ByRef s As Integer) As Double

            If (N = s) Then
                GetDirac = 1.0#
            Else
                GetDirac = 0.0#
            End If

        End Function

    End Class
End Namespace