Namespace DIN25463MOX
    Public Class FissionChainRu


        Private gamma(51) As Double
        Dim yru(51) As Double
        Dim Ru(6, 6) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    Ru(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Dim k As Integer
            Init_chain = DBNull.Value
            gamma(6) = zeta(6) / R(6)
            gamma(7) = (cap(6) * gamma(6) + zeta(7)) / R(7)
            gamma(8) = (cap(7) * gamma(7) + zeta(8)) / R(8)
            gamma(9) = (Fi_lambda(8) * gamma(8) + zeta(9)) / R(9)
            gamma(10) = (cap(9) * gamma(9) + zeta(10)) / R(10)
            gamma(11) = (cap(10) * gamma(10) + zeta(11)) / R(11)


            Ru(1, 1) = ystart(6) - gamma(6)
            ' ------------------------------------------------------
            Ru(1, 2) = Ru(1, 1) * cap(6) / (R(7) - R(6))
            Ru(2, 2) = ystart(7) - Ru(1, 2) - gamma(7)
            ' ------------------------------------------------------
            Ru(1, 3) = Ru(1, 2) * cap(7) / (R(8) - R(6))
            Ru(2, 3) = Ru(2, 2) * cap(7) / (R(8) - R(7))
            Ru(3, 3) = ystart(8) - Ru(1, 3) - Ru(2, 3) - gamma(8)
            ' ------------------------------------------------------
            Ru(1, 4) = Ru(1, 3) * Fi_lambda(8) / (R(9) - R(6))
            Ru(2, 4) = Ru(2, 3) * Fi_lambda(8) / (R(9) - R(7))
            Ru(3, 4) = Ru(3, 3) * Fi_lambda(8) / (R(9) - R(8))
            Ru(4, 4) = ystart(9) - gamma(9)
            For k = 1 To 3
                Ru(4, 4) = Ru(4, 4) - Ru(k, 4)
            Next k
            ' ------------------------------------------------------
            Ru(1, 5) = Ru(1, 4) * cap(9) / (R(10) - R(6))
            Ru(2, 5) = Ru(2, 4) * cap(9) / (R(10) - R(7))
            Ru(3, 5) = Ru(3, 4) * cap(9) / (R(10) - R(8))
            Ru(4, 5) = Ru(4, 4) * cap(9) / (R(10) - R(9))
            Ru(5, 5) = ystart(10) - gamma(10)
            For k = 1 To 4
                Ru(5, 5) = Ru(5, 5) - Ru(k, 5)
            Next k
            ' ------------------------------------------------------
            Ru(1, 6) = Ru(1, 5) * cap(10) / (R(11) - R(6))
            Ru(2, 6) = Ru(2, 5) * cap(10) / (R(11) - R(7))
            Ru(3, 6) = Ru(3, 5) * cap(10) / (R(11) - R(8))
            Ru(4, 6) = Ru(4, 5) * cap(10) / (R(11) - R(9))
            Ru(5, 6) = Ru(5, 5) * cap(10) / (R(11) - R(10))
            Ru(6, 6) = ystart(11) - gamma(11)
            For k = 1 To 5
                Ru(6, 6) = Ru(6, 6) - Ru(k, 6)
            Next k
            ' ------------------------------------------------------

        End Function

        Public Function Init_chainDecay(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double)
            Dim k As Integer
            Init_chainDecay = DBNull.Value
            gamma(6) = 0
            gamma(7) = 0
            gamma(8) = 0
            gamma(9) = 0
            gamma(10) = 0
            gamma(11) = 0


            Ru(1, 1) = ystart(6) - gamma(6)
            ' ------------------------------------------------------
            Ru(1, 2) = 0
            Ru(2, 2) = ystart(7) - Ru(1, 2) - gamma(7)
            ' ------------------------------------------------------
            Ru(1, 3) = Ru(1, 2) * cap(7) / (R(8) - R(6))
            Ru(2, 3) = Ru(2, 2) * cap(7) / (R(8) - R(7))
            Ru(3, 3) = ystart(8) - Ru(1, 3) - Ru(2, 3) - gamma(8)
            ' ------------------------------------------------------
            Ru(1, 4) = 0
            Ru(2, 4) = 0
            Ru(3, 4) = Ru(3, 3) * Fi_lambda(8) / (R(9) - R(8))
            Ru(4, 4) = ystart(9) - gamma(9)
            For k = 1 To 3
                Ru(4, 4) = Ru(4, 4) - Ru(k, 4)
            Next k
            ' ------------------------------------------------------
            Ru(1, 5) = Ru(1, 4) * cap(9) / (R(10) - R(6))
            Ru(2, 5) = Ru(2, 4) * cap(9) / (R(10) - R(7))
            Ru(3, 5) = Ru(3, 4) * cap(9) / (R(10) - R(8))
            Ru(4, 5) = Ru(4, 4) * cap(9) / (R(10) - R(9))
            Ru(5, 5) = ystart(10) - gamma(10)
            For k = 1 To 4
                Ru(5, 5) = Ru(5, 5) - Ru(k, 5)
            Next k
            ' ------------------------------------------------------
            Ru(1, 6) = Ru(1, 5) * cap(10) / (R(11) - R(6))
            Ru(2, 6) = Ru(2, 5) * cap(10) / (R(11) - R(7))
            Ru(3, 6) = Ru(3, 5) * cap(10) / (R(11) - R(8))
            Ru(4, 6) = Ru(4, 5) * cap(10) / (R(11) - R(9))
            Ru(5, 6) = Ru(5, 5) * cap(10) / (R(11) - R(10))
            Ru(6, 6) = ystart(11) - gamma(11)
            For k = 1 To 5
                Ru(6, 6) = Ru(6, 6) - Ru(k, 6)
            Next k
            ' ------------------------------------------------------



        End Function



        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double) As DBNull

            CalcChain = DBNull.Value

            yru(6) = Ru(1, 1) * Math.Exp(-R(6) * t) + gamma(6)
            yru(7) = Ru(1, 2) * Math.Exp(-R(6) * t) + Ru(2, 2) * Math.Exp(-R(7) * t) + gamma(7)
            yru(8) = Ru(1, 3) * Math.Exp(-R(6) * t) + Ru(2, 3) * Math.Exp(-R(7) * t) + Ru(3, 3) * Math.Exp(-R(8) * t) + gamma(8)
            yru(9) = Ru(1, 4) * Math.Exp(-R(6) * t) + Ru(2, 4) * Math.Exp(-R(7) * t) + Ru(3, 4) * Math.Exp(-R(8) * t) + Ru(4, 4) * Math.Exp(-R(9) * t) + gamma(9)
            yru(10) = Ru(1, 5) * Math.Exp(-R(6) * t) + Ru(2, 5) * Math.Exp(-R(7) * t) + Ru(3, 5) * Math.Exp(-R(8) * t) + Ru(4, 5) * Math.Exp(-R(9) * t) + Ru(5, 5) * Math.Exp(-R(10) * t) + gamma(10)
            yru(11) = Ru(1, 6) * Math.Exp(-R(6) * t) + Ru(2, 6) * Math.Exp(-R(7) * t) + Ru(3, 6) * Math.Exp(-R(8) * t) + Ru(4, 6) * Math.Exp(-R(9) * t) + Ru(5, 6) * Math.Exp(-R(10) * t) + Ru(6, 6) * Math.Exp(-R(11) * t) + gamma(11)

            yd(6) = yru(6)
            yd(7) = yru(7)
            yd(8) = yru(8)
            yd(9) = yru(9)
            yd(10) = yru(10)
            yd(11) = yru(11)

        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = Ru(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = Ru

        End Function



    End Class
End Namespace