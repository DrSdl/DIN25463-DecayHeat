Namespace DIN25463MOX
    Public Class FissionChainZr


        Private yzr(51) As Double
        Private Zr(3, 3) As Double
        Private gamma(51) As Double

        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value

            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    Zr(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull

            Init_chain = DBNull.Value

            gamma(1) = zeta(1) / R(1)
            gamma(2) = (Fi_lambda(1) * gamma(1) + zeta(2)) / R(2)
            gamma(3) = (Fi_lambda(2) * gamma(2) + zeta(3)) / R(3)

            Zr(1, 1) = ystart(1) - gamma(1)
            ' --------------------------------------------------------------
            Zr(1, 2) = Zr(1, 1) * Fi_lambda(1) / (R(2) - R(1))
            Zr(2, 2) = ystart(2) - Zr(1, 2) - gamma(2)
            ' --------------------------------------------------------------
            Zr(1, 3) = Zr(1, 2) * Fi_lambda(2) / (R(3) - R(1))
            Zr(2, 3) = Zr(2, 2) * Fi_lambda(2) / (R(3) - R(2))
            Zr(3, 3) = ystart(3) - Zr(1, 3) - Zr(2, 3) - gamma(3)
            ' --------------------------------------------------------------

        End Function

        Public Function Init_chainDecay(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull

            Init_chainDecay = DBNull.Value

            gamma(1) = 0
            gamma(2) = 0
            gamma(3) = 0

            Zr(1, 1) = ystart(1) - gamma(1)
            ' --------------------------------------------------------------
            Zr(1, 2) = Zr(1, 1) * Fi_lambda(1) / (R(2) - R(1))
            Zr(2, 2) = ystart(2) - Zr(1, 2) - gamma(2)
            ' --------------------------------------------------------------
            Zr(1, 3) = Zr(1, 2) * Fi_lambda(2) / (R(3) - R(1))
            Zr(2, 3) = Zr(2, 2) * Fi_lambda(2) / (R(3) - R(2))
            Zr(3, 3) = ystart(3) - Zr(1, 3) - Zr(2, 3) - gamma(3)
            ''

        End Function



        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double) As DBNull

            CalcChain = DBNull.Value

            yzr(1) = Zr(1, 1) * Math.Exp(-R(1) * t) + gamma(1)
            yzr(2) = Zr(1, 2) * Math.Exp(-R(1) * t) + Zr(2, 2) * Math.Exp(-R(2) * t) + gamma(2)
            yzr(3) = Zr(1, 3) * Math.Exp(-R(1) * t) + Zr(2, 3) * Math.Exp(-R(2) * t) + Zr(3, 3) * Math.Exp(-R(3) * t) + gamma(3)

            yd(1) = yzr(1)
            yd(2) = yzr(2)
            yd(3) = yzr(3)

        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = Zr(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = Zr

        End Function


    End Class
End Namespace