Namespace DIN25463MOX
    Public Class ActinideChain11


        Private p(21, 21) As Double


        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    p(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Elfte Kette(238U -->244CM VI)################
            Dim k As Integer
            Init_chain = DBNull.Value
            Ac_lambda(17) = 0.173 * Ac_lambda(17)
            p(1, 9) = p(1, 8) * Ac_lambda(17) / (R(14) - R(5))
            p(2, 9) = p(2, 8) * Ac_lambda(17) / (R(14) - R(6))
            p(3, 9) = p(3, 8) * Ac_lambda(17) / (R(14) - R(9))
            p(4, 9) = p(4, 8) * Ac_lambda(17) / (R(14) - R(11))
            p(5, 9) = p(5, 8) * Ac_lambda(17) / (R(14) - R(12))
            p(6, 9) = p(6, 8) * Ac_lambda(17) / (R(14) - R(13))
            p(7, 9) = p(7, 8) * Ac_lambda(17) / (R(14) - R(16))
            p(8, 9) = p(8, 8) * Ac_lambda(17) / (R(14) - R(17))
            Ac_lambda(17) = Ac_lambda(17) / 0.173
            p(9, 9) = ybeg(14) * 0
            For k = 1 To 8
                p(9, 9) = p(9, 9) - p(k, 9)
            Next k
            ' ---------------------------------------------------------------
            p(1, 10) = p(1, 9) * cap(14) / (R(15) - R(5))
            p(2, 10) = p(2, 9) * cap(14) / (R(15) - R(6))
            p(3, 10) = p(3, 9) * cap(14) / (R(15) - R(9))
            p(4, 10) = p(4, 9) * cap(14) / (R(15) - R(11))
            p(5, 10) = p(5, 9) * cap(14) / (R(15) - R(12))
            p(6, 10) = p(6, 9) * cap(14) / (R(15) - R(13))
            p(7, 10) = p(7, 9) * cap(14) / (R(15) - R(16))
            p(8, 10) = p(8, 9) * cap(14) / (R(15) - R(17))
            p(9, 10) = p(9, 9) * cap(14) / (R(15) - R(14))
            p(10, 10) = ybeg(15) * 0
            For k = 1 To 9
                p(10, 10) = p(10, 10) - p(k, 10)
            Next k
            ' ---------------------------------------------------------------
            p(1, 11) = p(1, 10) * Ac_lambda(15) / (R(18) - R(5))
            p(2, 11) = p(2, 10) * Ac_lambda(15) / (R(18) - R(6))
            p(3, 11) = p(3, 10) * Ac_lambda(15) / (R(18) - R(9))
            p(4, 11) = p(4, 10) * Ac_lambda(15) / (R(18) - R(11))
            p(5, 11) = p(5, 10) * Ac_lambda(15) / (R(18) - R(12))
            p(6, 11) = p(6, 10) * Ac_lambda(15) / (R(18) - R(13))
            p(7, 11) = p(7, 10) * Ac_lambda(15) / (R(18) - R(16))
            p(8, 11) = p(8, 10) * Ac_lambda(15) / (R(18) - R(17))
            p(9, 11) = p(9, 10) * Ac_lambda(15) / (R(18) - R(14))
            p(10, 11) = p(10, 10) * Ac_lambda(15) / (R(18) - R(15))
            p(11, 11) = ybeg(18) * 0
            For k = 1 To 10
                p(11, 11) = p(11, 11) - p(k, 11)
            Next k
            ' ---------------------------------------------------------------
            p(1, 12) = p(1, 11) * cap(18) / (R(19) - R(5))
            p(2, 12) = p(2, 11) * cap(18) / (R(19) - R(6))
            p(3, 12) = p(3, 11) * cap(18) / (R(19) - R(9))
            p(4, 12) = p(4, 11) * cap(18) / (R(19) - R(11))
            p(5, 12) = p(5, 11) * cap(18) / (R(19) - R(12))
            p(6, 12) = p(6, 11) * cap(18) / (R(19) - R(13))
            p(7, 12) = p(7, 11) * cap(18) / (R(19) - R(16))
            p(8, 12) = p(8, 11) * cap(18) / (R(19) - R(17))
            p(9, 12) = p(9, 11) * cap(18) / (R(19) - R(14))
            p(10, 12) = p(10, 11) * cap(18) / (R(19) - R(15))
            p(11, 12) = p(11, 11) * cap(18) / (R(19) - R(18))
            p(12, 12) = ybeg(19) * 0
            For k = 1 To 11
                p(12, 12) = p(12, 12) - p(k, 12)
            Next k
            ' ---------------------------------------------------------------
            p(1, 13) = p(1, 12) * Ac_lambda(19) / (R(21) - R(5))
            p(2, 13) = p(2, 12) * Ac_lambda(19) / (R(21) - R(6))
            p(3, 13) = p(3, 12) * Ac_lambda(19) / (R(21) - R(9))
            p(4, 13) = p(4, 12) * Ac_lambda(19) / (R(21) - R(11))
            p(5, 13) = p(5, 12) * Ac_lambda(19) / (R(21) - R(12))
            p(6, 13) = p(6, 12) * Ac_lambda(19) / (R(21) - R(13))
            p(7, 13) = p(7, 12) * Ac_lambda(19) / (R(21) - R(16))
            p(8, 13) = p(8, 12) * Ac_lambda(19) / (R(21) - R(17))
            p(9, 13) = p(9, 12) * Ac_lambda(19) / (R(21) - R(14))
            p(10, 13) = p(10, 12) * Ac_lambda(19) / (R(21) - R(15))
            p(11, 13) = p(11, 12) * Ac_lambda(19) / (R(21) - R(18))
            p(12, 13) = p(12, 12) * Ac_lambda(19) / (R(21) - R(19))
            p(13, 13) = ybeg(21) * 0
            For k = 1 To 12
                p(13, 13) = p(13, 13) - p(k, 13)
            Next k
            ' ---------------------------------------------------------------

        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yp() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            yp(14) = p(1, 9) * Math.Exp(-R(5) * t) + p(2, 9) * Math.Exp(-R(6) * t) + p(3, 9) * Math.Exp(-R(9) * t) + p(4, 9) * Math.Exp(-R(11) * t) + p(5, 9) * Math.Exp(-R(12) * t) + p(6, 9) * Math.Exp(-R(13) * t) + p(7, 9) * Math.Exp(-R(16) * t) + p(8, 9) * Math.Exp(-R(17) * t) + p(9, 9) * Math.Exp(-R(14) * t)
            yp(15) = p(1, 10) * Math.Exp(-R(5) * t) + p(2, 10) * Math.Exp(-R(6) * t) + p(3, 10) * Math.Exp(-R(9) * t) + p(4, 10) * Math.Exp(-R(11) * t) + p(5, 10) * Math.Exp(-R(12) * t) + p(6, 10) * Math.Exp(-R(13) * t) + p(7, 10) * Math.Exp(-R(16) * t) + p(8, 10) * Math.Exp(-R(17) * t) + p(9, 10) * Math.Exp(-R(14) * t) + p(10, 10) * Math.Exp(-R(15) * t)
            yp(18) = p(1, 11) * Math.Exp(-R(5) * t) + p(2, 11) * Math.Exp(-R(6) * t) + p(3, 11) * Math.Exp(-R(9) * t) + p(4, 11) * Math.Exp(-R(11) * t) + p(5, 11) * Math.Exp(-R(12) * t) + p(6, 11) * Math.Exp(-R(13) * t) + p(7, 11) * Math.Exp(-R(16) * t) + p(8, 11) * Math.Exp(-R(17) * t) + p(9, 11) * Math.Exp(-R(14) * t) + p(10, 11) * Math.Exp(-R(15) * t) + p(11, 11) * Math.Exp(-R(18) * t)
            yp(19) = p(1, 12) * Math.Exp(-R(5) * t) + p(2, 12) * Math.Exp(-R(6) * t) + p(3, 12) * Math.Exp(-R(9) * t) + p(4, 12) * Math.Exp(-R(11) * t) + p(5, 12) * Math.Exp(-R(12) * t) + p(6, 12) * Math.Exp(-R(13) * t) + p(7, 12) * Math.Exp(-R(16) * t) + p(8, 12) * Math.Exp(-R(17) * t) + p(9, 12) * Math.Exp(-R(14) * t) + p(10, 12) * Math.Exp(-R(15) * t) + p(11, 12) * Math.Exp(-R(18) * t) + p(12, 12) * Math.Exp(-R(19) * t)
            yp(21) = p(1, 13) * Math.Exp(-R(5) * t) + p(2, 13) * Math.Exp(-R(6) * t) + p(3, 13) * Math.Exp(-R(9) * t) + p(4, 13) * Math.Exp(-R(11) * t) + p(5, 13) * Math.Exp(-R(12) * t) + p(6, 13) * Math.Exp(-R(13) * t) + p(7, 13) * Math.Exp(-R(16) * t) + p(8, 13) * Math.Exp(-R(17) * t) + p(9, 13) * Math.Exp(-R(14) * t) + p(10, 13) * Math.Exp(-R(15) * t) + p(11, 13) * Math.Exp(-R(18) * t) + p(12, 13) * Math.Exp(-R(19) * t) + p(13, 13) * Math.Exp(-R(21) * t)

        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = p(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = p

        End Function

    End Class
End Namespace