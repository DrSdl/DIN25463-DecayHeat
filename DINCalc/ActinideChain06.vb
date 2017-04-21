Namespace DIN25463MOX
    Public Class ActinideChain06


        Private f(21, 21) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    f(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Sechste Kette(238U -->244CM II)################
            Dim k As Integer

            Init_chain = DBNull.Value

            f(1, 9) = f(1, 8) * Ac_lambda(13) / (R(16) - R(5))
            f(2, 9) = f(2, 8) * Ac_lambda(13) / (R(16) - R(4))
            f(3, 9) = f(3, 8) * Ac_lambda(13) / (R(16) - R(7))
            f(4, 9) = f(4, 8) * Ac_lambda(13) / (R(16) - R(8))
            f(5, 9) = f(5, 8) * Ac_lambda(13) / (R(16) - R(10))
            f(6, 9) = f(6, 8) * Ac_lambda(13) / (R(16) - R(11))
            f(7, 9) = f(7, 8) * Ac_lambda(13) / (R(16) - R(12))
            f(8, 9) = f(8, 8) * Ac_lambda(13) / (R(16) - R(13))
            f(9, 9) = ybeg(16) * 0
            For k = 1 To 8
                f(9, 9) = f(9, 9) - f(k, 9)
            Next k
            ' ---------------------------------------------------------------
            f(1, 10) = f(1, 9) * cap(16) / (R(17) - R(5))
            f(2, 10) = f(2, 9) * cap(16) / (R(17) - R(4))
            f(3, 10) = f(3, 9) * cap(16) / (R(17) - R(7))
            f(4, 10) = f(4, 9) * cap(16) / (R(17) - R(8))
            f(5, 10) = f(5, 9) * cap(16) / (R(17) - R(10))
            f(6, 10) = f(6, 9) * cap(16) / (R(17) - R(11))
            f(7, 10) = f(7, 9) * cap(16) / (R(17) - R(12))
            f(8, 10) = f(8, 9) * cap(16) / (R(17) - R(13))
            f(9, 10) = f(9, 9) * cap(16) / (R(17) - R(16))
            f(10, 10) = ybeg(17) * 0
            For k = 1 To 9
                f(10, 10) = f(10, 10) - f(k, 10)
            Next k
            ' ---------------------------------------------------------------
            f(1, 11) = f(1, 10) * cap(17) / (R(18) - R(5))
            f(2, 11) = f(2, 10) * cap(17) / (R(18) - R(4))
            f(3, 11) = f(3, 10) * cap(17) / (R(18) - R(7))
            f(4, 11) = f(4, 10) * cap(17) / (R(18) - R(8))
            f(5, 11) = f(5, 10) * cap(17) / (R(18) - R(10))
            f(6, 11) = f(6, 10) * cap(17) / (R(18) - R(11))
            f(7, 11) = f(7, 10) * cap(17) / (R(18) - R(12))
            f(8, 11) = f(8, 10) * cap(17) / (R(18) - R(13))
            f(9, 11) = f(9, 10) * cap(17) / (R(18) - R(16))
            f(10, 11) = f(10, 10) * cap(17) / (R(18) - R(17))
            f(11, 11) = ybeg(18) * 0
            For k = 1 To 10
                f(11, 11) = f(11, 11) - f(k, 11)
            Next k
            ' ---------------------------------------------------------------
            f(1, 12) = f(1, 11) * cap(18) / (R(19) - R(5))
            f(2, 12) = f(2, 11) * cap(18) / (R(19) - R(4))
            f(3, 12) = f(3, 11) * cap(18) / (R(19) - R(7))
            f(4, 12) = f(4, 11) * cap(18) / (R(19) - R(8))
            f(5, 12) = f(5, 11) * cap(18) / (R(19) - R(10))
            f(6, 12) = f(6, 11) * cap(18) / (R(19) - R(11))
            f(7, 12) = f(7, 11) * cap(18) / (R(19) - R(12))
            f(8, 12) = f(8, 11) * cap(18) / (R(19) - R(13))
            f(9, 12) = f(9, 11) * cap(18) / (R(19) - R(16))
            f(10, 12) = f(10, 11) * cap(18) / (R(19) - R(17))
            f(11, 12) = f(11, 11) * cap(18) / (R(19) - R(18))
            f(12, 12) = ybeg(19) * 0
            For k = 1 To 11
                f(12, 12) = f(12, 12) - f(k, 12)
            Next k
            ' ---------------------------------------------------------------
            f(1, 13) = f(1, 12) * Ac_lambda(19) / (R(21) - R(5))
            f(2, 13) = f(2, 12) * Ac_lambda(19) / (R(21) - R(4))
            f(3, 13) = f(3, 12) * Ac_lambda(19) / (R(21) - R(7))
            f(4, 13) = f(4, 12) * Ac_lambda(19) / (R(21) - R(8))
            f(5, 13) = f(5, 12) * Ac_lambda(19) / (R(21) - R(10))
            f(6, 13) = f(6, 12) * Ac_lambda(19) / (R(21) - R(11))
            f(7, 13) = f(7, 12) * Ac_lambda(19) / (R(21) - R(12))
            f(8, 13) = f(8, 12) * Ac_lambda(19) / (R(21) - R(13))
            f(9, 13) = f(9, 12) * Ac_lambda(19) / (R(21) - R(16))
            f(10, 13) = f(10, 12) * Ac_lambda(19) / (R(21) - R(17))
            f(11, 13) = f(11, 12) * Ac_lambda(19) / (R(21) - R(18))
            f(12, 13) = f(12, 12) * Ac_lambda(19) / (R(21) - R(19))
            f(13, 13) = ybeg(21) * 0
            For k = 1 To 12
                f(13, 13) = f(13, 13) - f(k, 13)
            Next k
            ' ---------------------------------------------------------------


        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yf() As Double, ByVal t As Double) As DBNull

            CalcChain = DBNull.Value
            yf(16) = f(1, 9) * Math.Exp(-R(5) * t) + f(2, 9) * Math.Exp(-R(4) * t) + f(3, 9) * Math.Exp(-R(7) * t) + f(4, 9) * Math.Exp(-R(8) * t) + f(5, 9) * Math.Exp(-R(10) * t) + f(6, 9) * Math.Exp(-R(11) * t) + f(7, 9) * Math.Exp(-R(12) * t) + f(8, 9) * Math.Exp(-R(13) * t) + f(9, 9) * Math.Exp(-R(16) * t)
            yf(17) = f(1, 10) * Math.Exp(-R(5) * t) + f(2, 10) * Math.Exp(-R(4) * t) + f(3, 10) * Math.Exp(-R(7) * t) + f(4, 10) * Math.Exp(-R(8) * t) + f(5, 10) * Math.Exp(-R(10) * t) + f(6, 10) * Math.Exp(-R(11) * t) + f(7, 10) * Math.Exp(-R(12) * t) + f(8, 10) * Math.Exp(-R(13) * t) + f(9, 10) * Math.Exp(-R(16) * t) + f(10, 10) * Math.Exp(-R(17) * t)
            yf(18) = f(1, 11) * Math.Exp(-R(5) * t) + f(2, 11) * Math.Exp(-R(4) * t) + f(3, 11) * Math.Exp(-R(7) * t) + f(4, 11) * Math.Exp(-R(8) * t) + f(5, 11) * Math.Exp(-R(10) * t) + f(6, 11) * Math.Exp(-R(11) * t) + f(7, 11) * Math.Exp(-R(12) * t) + f(8, 11) * Math.Exp(-R(13) * t) + f(9, 11) * Math.Exp(-R(16) * t) + f(10, 11) * Math.Exp(-R(17) * t) + f(11, 11) * Math.Exp(-R(18) * t)
            yf(19) = f(1, 12) * Math.Exp(-R(5) * t) + f(2, 12) * Math.Exp(-R(4) * t) + f(3, 12) * Math.Exp(-R(7) * t) + f(4, 12) * Math.Exp(-R(8) * t) + f(5, 12) * Math.Exp(-R(10) * t) + f(6, 12) * Math.Exp(-R(11) * t) + f(7, 12) * Math.Exp(-R(12) * t) + f(8, 12) * Math.Exp(-R(13) * t) + f(9, 12) * Math.Exp(-R(16) * t) + f(10, 12) * Math.Exp(-R(17) * t) + f(11, 12) * Math.Exp(-R(18) * t) + f(12, 12) * Math.Exp(-R(19) * t)
            yf(21) = f(1, 13) * Math.Exp(-R(5) * t) + f(2, 13) * Math.Exp(-R(4) * t) + f(3, 13) * Math.Exp(-R(7) * t) + f(4, 13) * Math.Exp(-R(8) * t) + f(5, 13) * Math.Exp(-R(10) * t) + f(6, 13) * Math.Exp(-R(11) * t) + f(7, 13) * Math.Exp(-R(12) * t) + f(8, 13) * Math.Exp(-R(13) * t) + f(9, 13) * Math.Exp(-R(16) * t) + f(10, 13) * Math.Exp(-R(17) * t) + f(11, 13) * Math.Exp(-R(18) * t) + f(12, 13) * Math.Exp(-R(19) * t) + f(13, 13) * Math.Exp(-R(21) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = f(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = f

        End Function


    End Class
End Namespace