Namespace DIN25463MOX
    Public Class FissionChainBa


        Private gammaI(51) As Double
        Private gammaII(51) As Double

        Dim ybaI(51), ybaII(51), yba(51) As Double
        Dim BaI(2, 2), BaII(2, 2) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    BaI(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull

            Init_chain = DBNull.Value

            gammaI(25) = zeta(25) / R(25)
            gammaI(26) = (cap(25) * gammaI(25) + zeta(26)) / R(26)

            gammaII(24) = zeta(24) / R(24)
            gammaII(26) = (Fi_lambda(24) * gammaII(24) + zeta(26)) / R(26)

            BaI(1, 1) = ystart(25) - gammaI(25)
            BaI(1, 2) = BaI(1, 1) * cap(25) / (R(26) - R(25))
            BaI(2, 2) = ystart(26) - BaI(1, 2) - gammaI(26)

            BaII(1, 1) = ystart(24) - gammaII(24)
            BaII(1, 2) = BaII(1, 1) * Fi_lambda(24) / (R(26) - R(24))
            BaII(2, 2) = 0 - BaII(1, 2) - gammaII(26)


        End Function

        Public Function Init_chainDecay(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Init_chainDecay = DBNull.Value

            gammaI(25) = 0
            gammaI(26) = 0

            gammaII(24) = 0
            gammaII(26) = 0

            BaI(1, 1) = ystart(25) - gammaI(25)
            BaI(1, 2) = 0
            BaI(2, 2) = ystart(26) - BaI(1, 2) - gammaI(26)

            BaII(1, 1) = ystart(24) - gammaII(24)
            BaII(1, 2) = BaII(1, 1) * Fi_lambda(24) / (R(26) - R(24))
            BaII(2, 2) = 0 - BaII(1, 2) - gammaII(26)

        End Function



        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double) As DBNull

            Dim k As Integer
            CalcChain = DBNull.Value

            ybaI(25) = BaI(1, 1) * Math.Exp(-R(25) * t) + gammaI(25)
            ybaI(26) = BaI(1, 2) * Math.Exp(-R(25) * t) + BaI(2, 2) * Math.Exp(-R(26) * t) + gammaI(26)

            ybaII(24) = BaII(1, 1) * Math.Exp(-R(24) * t) + gammaII(24)
            ybaII(26) = BaII(1, 2) * Math.Exp(-R(24) * t) + BaII(2, 2) * Math.Exp(-R(26) * t) + gammaII(26)


            For k = 1 To 51
                yd(k) = ybaI(k) + ybaII(k)
            Next k

        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = BaI(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = BaI

        End Function

    End Class
End Namespace