Namespace DIN25463MOX
    Public Class FissionChainPd


        Private gamma(51) As Double
        Dim ypd(51) As Double
        Dim Pd(4, 4) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull

            Dim k, l As Integer
            CopyMatrix = DBNull.Value
            For k = 1 To N
                For l = 1 To N
                    Pd(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Init_chain = DBNull.Value

            gamma(12) = zeta(12) / R(12)
            gamma(13) = (cap(12) * gamma(12) + zeta(13)) / R(13)
            gamma(14) = (Fi_lambda(13) * gamma(13) + zeta(14)) / R(14)
            gamma(15) = (0.038 * cap(14) * gamma(14) + zeta(15)) / R(15)

            Pd(1, 1) = ystart(12) - gamma(12)
            ' -------------------------------------------------------
            Pd(1, 2) = Pd(1, 1) * cap(12) / (R(13) - R(12))
            Pd(2, 2) = ystart(13) - Pd(1, 2) - gamma(13)
            ' -------------------------------------------------------
            Pd(1, 3) = Pd(1, 2) * Fi_lambda(13) / (R(14) - R(12))
            Pd(2, 3) = Pd(2, 2) * Fi_lambda(13) / (R(14) - R(13))
            Pd(3, 3) = ystart(14) - Pd(1, 3) - Pd(2, 3) - gamma(14)
            ' -------------------------------------------------------
            Pd(1, 4) = Pd(1, 3) * 0.038 * cap(14) / (R(15) - R(12))
            Pd(2, 4) = Pd(2, 3) * 0.038 * cap(14) / (R(15) - R(13))
            Pd(3, 4) = Pd(3, 3) * 0.038 * cap(14) / (R(15) - R(14))
            Pd(4, 4) = ystart(15) - Pd(1, 4) - Pd(2, 4) - Pd(3, 4) - gamma(15)
            ' -------------------------------------------------------

        End Function

        Public Function Init_chainDecay(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double)
            Init_chainDecay = DBNull.Value

            gamma(12) = 0
            gamma(13) = 0
            gamma(14) = 0
            gamma(15) = 0

            Pd(1, 1) = ystart(12) - gamma(12)
            ' -------------------------------------------------------
            Pd(1, 2) = Pd(1, 1) * cap(12) / (R(13) - R(12))
            Pd(2, 2) = ystart(13) - Pd(1, 2) - gamma(13)
            ' -------------------------------------------------------
            Pd(1, 3) = 0
            Pd(2, 3) = Pd(2, 2) * Fi_lambda(13) / (R(14) - R(13))
            Pd(3, 3) = ystart(14) - Pd(1, 3) - Pd(2, 3) - gamma(14)
            ' -------------------------------------------------------
            Pd(1, 4) = Pd(1, 3) * 0.038 * cap(14) / (R(15) - R(12))
            Pd(2, 4) = Pd(2, 3) * 0.038 * cap(14) / (R(15) - R(13))
            Pd(3, 4) = Pd(3, 3) * 0.038 * cap(14) / (R(15) - R(14))
            Pd(4, 4) = ystart(15) - Pd(1, 4) - Pd(2, 4) - Pd(3, 4) - gamma(15)
            ' -------------------------------------------------------

        End Function



        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double) As DBNull

            CalcChain = DBNull.Value

            ypd(12) = Pd(1, 1) * Math.Exp(-R(12) * t) + gamma(12)
            ypd(13) = Pd(1, 2) * Math.Exp(-R(12) * t) + Pd(2, 2) * Math.Exp(-R(13) * t) + gamma(13)
            ypd(14) = Pd(1, 3) * Math.Exp(-R(12) * t) + Pd(2, 3) * Math.Exp(-R(13) * t) + Pd(3, 3) * Math.Exp(-R(14) * t) + gamma(14)
            ypd(15) = Pd(1, 4) * Math.Exp(-R(12) * t) + Pd(2, 4) * Math.Exp(-R(13) * t) + Pd(3, 4) * Math.Exp(-R(14) * t) + Pd(4, 4) * Math.Exp(-R(15) * t) + gamma(15)

            yd(12) = ypd(12)
            yd(13) = ypd(13)
            yd(14) = ypd(14)
            yd(15) = ypd(15)

        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = Pd(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = Pd

        End Function




    End Class
End Namespace
