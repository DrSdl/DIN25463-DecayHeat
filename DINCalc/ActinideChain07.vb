Namespace DIN25463MOX
    Public Class ActinideChain07


        Private g(21, 21) As Double


        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull

            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    g(k, l) = cc(k, l)
                Next l
            Next k
            CopyMatrix = DBNull.Value
        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Siebte Kette(238U -->244CM III)################

            Dim k As Integer
            Init_chain = DBNull.Value
            Ac_lambda(17) = 0.173 * Ac_lambda(17)
            g(1, 11) = g(1, 10) * Ac_lambda(17) / (R(14) - R(5))
            g(2, 11) = g(2, 10) * Ac_lambda(17) / (R(14) - R(4))
            g(3, 11) = g(3, 10) * Ac_lambda(17) / (R(14) - R(7))
            g(4, 11) = g(4, 10) * Ac_lambda(17) / (R(14) - R(8))
            g(5, 11) = g(5, 10) * Ac_lambda(17) / (R(14) - R(10))
            g(6, 11) = g(6, 10) * Ac_lambda(17) / (R(14) - R(11))
            g(7, 11) = g(7, 10) * Ac_lambda(17) / (R(14) - R(12))
            g(8, 11) = g(8, 10) * Ac_lambda(17) / (R(14) - R(13))
            g(9, 11) = g(9, 10) * Ac_lambda(17) / (R(14) - R(16))
            g(10, 11) = g(10, 10) * Ac_lambda(17) / (R(14) - R(17))
            Ac_lambda(17) = Ac_lambda(17) / 0.173
            g(11, 11) = ybeg(14) * 0
            For k = 1 To 10
                g(11, 11) = g(11, 11) - g(k, 11)
            Next k
            ' ---------------------------------------------------------------
            g(1, 12) = g(1, 11) * cap(14) / (R(15) - R(5))
            g(2, 12) = g(2, 11) * cap(14) / (R(15) - R(4))
            g(3, 12) = g(3, 11) * cap(14) / (R(15) - R(7))
            g(4, 12) = g(4, 11) * cap(14) / (R(15) - R(8))
            g(5, 12) = g(5, 11) * cap(14) / (R(15) - R(10))
            g(6, 12) = g(6, 11) * cap(14) / (R(15) - R(11))
            g(7, 12) = g(7, 11) * cap(14) / (R(15) - R(12))
            g(8, 12) = g(8, 11) * cap(14) / (R(15) - R(13))
            g(9, 12) = g(9, 11) * cap(14) / (R(15) - R(16))
            g(10, 12) = g(10, 11) * cap(14) / (R(15) - R(17))
            g(11, 12) = g(11, 11) * cap(14) / (R(15) - R(14))
            g(12, 12) = ybeg(15) * 0
            For k = 1 To 11
                g(12, 12) = g(12, 12) - g(k, 12)
            Next k
            ' ---------------------------------------------------------------
            g(1, 13) = g(1, 12) * Ac_lambda(15) / (R(18) - R(5))
            g(2, 13) = g(2, 12) * Ac_lambda(15) / (R(18) - R(4))
            g(3, 13) = g(3, 12) * Ac_lambda(15) / (R(18) - R(7))
            g(4, 13) = g(4, 12) * Ac_lambda(15) / (R(18) - R(8))
            g(5, 13) = g(5, 12) * Ac_lambda(15) / (R(18) - R(10))
            g(6, 13) = g(6, 12) * Ac_lambda(15) / (R(18) - R(11))
            g(7, 13) = g(7, 12) * Ac_lambda(15) / (R(18) - R(12))
            g(8, 13) = g(8, 12) * Ac_lambda(15) / (R(18) - R(13))
            g(9, 13) = g(9, 12) * Ac_lambda(15) / (R(18) - R(16))
            g(10, 13) = g(10, 12) * Ac_lambda(15) / (R(18) - R(17))
            g(11, 13) = g(11, 12) * Ac_lambda(15) / (R(18) - R(14))
            g(12, 13) = g(12, 12) * Ac_lambda(15) / (R(18) - R(15))
            g(13, 13) = ybeg(18) * 0
            For k = 1 To 12
                g(13, 13) = g(13, 13) - g(k, 13)
            Next k
            ' ---------------------------------------------------------------
            g(1, 14) = g(1, 13) * cap(18) / (R(19) - R(5))
            g(2, 14) = g(2, 13) * cap(18) / (R(19) - R(4))
            g(3, 14) = g(3, 13) * cap(18) / (R(19) - R(7))
            g(4, 14) = g(4, 13) * cap(18) / (R(19) - R(8))
            g(5, 14) = g(5, 13) * cap(18) / (R(19) - R(10))
            g(6, 14) = g(6, 13) * cap(18) / (R(19) - R(11))
            g(7, 14) = g(7, 13) * cap(18) / (R(19) - R(12))
            g(8, 14) = g(8, 13) * cap(18) / (R(19) - R(13))
            g(9, 14) = g(9, 13) * cap(18) / (R(19) - R(16))
            g(10, 14) = g(10, 13) * cap(18) / (R(19) - R(17))
            g(11, 14) = g(11, 13) * cap(18) / (R(19) - R(14))
            g(12, 14) = g(12, 13) * cap(18) / (R(19) - R(15))
            g(13, 14) = g(13, 13) * cap(18) / (R(19) - R(18))
            g(14, 14) = ybeg(19) * 0
            For k = 1 To 13
                g(14, 14) = g(14, 14) - g(k, 14)
            Next k
            ' ---------------------------------------------------------------
            g(1, 15) = g(1, 14) * Ac_lambda(19) / (R(21) - R(5))
            g(2, 15) = g(2, 14) * Ac_lambda(19) / (R(21) - R(4))
            g(3, 15) = g(3, 14) * Ac_lambda(19) / (R(21) - R(7))
            g(4, 15) = g(4, 14) * Ac_lambda(19) / (R(21) - R(8))
            g(5, 15) = g(5, 14) * Ac_lambda(19) / (R(21) - R(10))
            g(6, 15) = g(6, 14) * Ac_lambda(19) / (R(21) - R(11))
            g(7, 15) = g(7, 14) * Ac_lambda(19) / (R(21) - R(12))
            g(8, 15) = g(8, 14) * Ac_lambda(19) / (R(21) - R(13))
            g(9, 15) = g(9, 14) * Ac_lambda(19) / (R(21) - R(16))
            g(10, 15) = g(10, 14) * Ac_lambda(19) / (R(21) - R(17))
            g(11, 15) = g(11, 14) * Ac_lambda(19) / (R(21) - R(14))
            g(12, 15) = g(12, 14) * Ac_lambda(19) / (R(21) - R(15))
            g(13, 15) = g(13, 14) * Ac_lambda(19) / (R(21) - R(18))
            g(14, 15) = g(14, 14) * Ac_lambda(19) / (R(21) - R(19))
            g(15, 15) = ybeg(21) * 0
            For k = 1 To 14
                g(15, 15) = g(15, 15) - g(k, 15)
            Next k
            ' ---------------------------------------------------------------

        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yg() As Double, ByVal t As Double) As DBNull

            yg(14) = g(1, 11) * Math.Exp(-R(5) * t) + g(2, 11) * Math.Exp(-R(4) * t) + g(3, 11) * Math.Exp(-R(7) * t) + g(4, 11) * Math.Exp(-R(8) * t) + g(5, 11) * Math.Exp(-R(10) * t) + g(6, 11) * Math.Exp(-R(11) * t) + g(7, 11) * Math.Exp(-R(12) * t) + g(8, 11) * Math.Exp(-R(13) * t) + g(9, 11) * Math.Exp(-R(16) * t) + g(10, 11) * Math.Exp(-R(17) * t) + g(11, 11) * Math.Exp(-R(14) * t)
            yg(15) = g(1, 12) * Math.Exp(-R(5) * t) + g(2, 12) * Math.Exp(-R(4) * t) + g(3, 12) * Math.Exp(-R(7) * t) + g(4, 12) * Math.Exp(-R(8) * t) + g(5, 12) * Math.Exp(-R(10) * t) + g(6, 12) * Math.Exp(-R(11) * t) + g(7, 12) * Math.Exp(-R(12) * t) + g(8, 12) * Math.Exp(-R(13) * t) + g(9, 12) * Math.Exp(-R(16) * t) + g(10, 12) * Math.Exp(-R(17) * t) + g(11, 12) * Math.Exp(-R(14) * t) + g(12, 12) * Math.Exp(-R(15) * t)
            yg(18) = g(1, 13) * Math.Exp(-R(5) * t) + g(2, 13) * Math.Exp(-R(4) * t) + g(3, 13) * Math.Exp(-R(7) * t) + g(4, 13) * Math.Exp(-R(8) * t) + g(5, 13) * Math.Exp(-R(10) * t) + g(6, 13) * Math.Exp(-R(11) * t) + g(7, 13) * Math.Exp(-R(12) * t) + g(8, 13) * Math.Exp(-R(13) * t) + g(9, 13) * Math.Exp(-R(16) * t) + g(10, 13) * Math.Exp(-R(17) * t) + g(11, 13) * Math.Exp(-R(14) * t) + g(12, 13) * Math.Exp(-R(15) * t) + g(13, 13) * Math.Exp(-R(18) * t)
            yg(19) = g(1, 14) * Math.Exp(-R(5) * t) + g(2, 14) * Math.Exp(-R(4) * t) + g(3, 14) * Math.Exp(-R(7) * t) + g(4, 14) * Math.Exp(-R(8) * t) + g(5, 14) * Math.Exp(-R(10) * t) + g(6, 14) * Math.Exp(-R(11) * t) + g(7, 14) * Math.Exp(-R(12) * t) + g(8, 14) * Math.Exp(-R(13) * t) + g(9, 14) * Math.Exp(-R(16) * t) + g(10, 14) * Math.Exp(-R(17) * t) + g(11, 14) * Math.Exp(-R(14) * t) + g(12, 14) * Math.Exp(-R(15) * t) + g(13, 14) * Math.Exp(-R(18) * t) + g(14, 14) * Math.Exp(-R(19) * t)
            yg(21) = g(1, 15) * Math.Exp(-R(5) * t) + g(2, 15) * Math.Exp(-R(4) * t) + g(3, 15) * Math.Exp(-R(7) * t) + g(4, 15) * Math.Exp(-R(8) * t) + g(5, 15) * Math.Exp(-R(10) * t) + g(6, 15) * Math.Exp(-R(11) * t) + g(7, 15) * Math.Exp(-R(12) * t) + g(8, 15) * Math.Exp(-R(13) * t) + g(9, 15) * Math.Exp(-R(16) * t) + g(10, 15) * Math.Exp(-R(17) * t) + g(11, 15) * Math.Exp(-R(14) * t) + g(12, 15) * Math.Exp(-R(15) * t) + g(13, 15) * Math.Exp(-R(18) * t) + g(14, 15) * Math.Exp(-R(19) * t) + g(15, 15) * Math.Exp(-R(21) * t)

            CalcChain = DBNull.Value
        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = g(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = g

        End Function

    End Class
End Namespace