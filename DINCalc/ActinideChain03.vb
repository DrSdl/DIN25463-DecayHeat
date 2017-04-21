Namespace DIN25463MOX
    Public Class ActinideChain03


        Private c(21, 21) As Double


        Public Sub New()


            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    c(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Dritte Kette(234U -->244CM III)################

            Init_chain = DBNull.Value
            Dim k As Integer
            c(1, 11) = c(1, 10) * Ac_lambda(13) / (R(16) - R(1))
            c(2, 11) = c(2, 10) * Ac_lambda(13) / (R(16) - R(2))
            c(3, 11) = c(3, 10) * Ac_lambda(13) / (R(16) - R(3))
            c(4, 11) = c(4, 10) * Ac_lambda(13) / (R(16) - R(4))
            c(5, 11) = c(5, 10) * Ac_lambda(13) / (R(16) - R(7))
            c(6, 11) = c(6, 10) * Ac_lambda(13) / (R(16) - R(8))
            c(7, 11) = c(7, 10) * Ac_lambda(13) / (R(16) - R(10))
            c(8, 11) = c(8, 10) * Ac_lambda(13) / (R(16) - R(11))
            c(9, 11) = c(9, 10) * Ac_lambda(13) / (R(16) - R(12))
            c(10, 11) = c(10, 10) * Ac_lambda(13) / (R(16) - R(13))
            c(11, 11) = ybeg(16) * 0
            For k = 1 To 10
                c(11, 11) = c(11, 11) - c(k, 11)
            Next k
            ' ---------------------------------------------------------------
            c(1, 12) = c(1, 11) * cap(16) / (R(17) - R(1))
            c(2, 12) = c(2, 11) * cap(16) / (R(17) - R(2))
            c(3, 12) = c(3, 11) * cap(16) / (R(17) - R(3))
            c(4, 12) = c(4, 11) * cap(16) / (R(17) - R(4))
            c(5, 12) = c(5, 11) * cap(16) / (R(17) - R(7))
            c(6, 12) = c(6, 11) * cap(16) / (R(17) - R(8))
            c(7, 12) = c(7, 11) * cap(16) / (R(17) - R(10))
            c(8, 12) = c(8, 11) * cap(16) / (R(17) - R(11))
            c(9, 12) = c(9, 11) * cap(16) / (R(17) - R(12))
            c(10, 12) = c(10, 11) * cap(16) / (R(17) - R(13))
            c(11, 12) = c(11, 11) * cap(16) / (R(17) - R(16))
            c(12, 12) = ybeg(17) * 0
            For k = 1 To 11
                c(12, 12) = c(12, 12) - c(k, 12)
            Next k
            ' ---------------------------------------------------------------
            Ac_lambda(17) = 0.173 * Ac_lambda(17)
            c(1, 13) = c(1, 12) * Ac_lambda(17) / (R(14) - R(1))
            c(2, 13) = c(2, 12) * Ac_lambda(17) / (R(14) - R(2))
            c(3, 13) = c(3, 12) * Ac_lambda(17) / (R(14) - R(3))
            c(4, 13) = c(4, 12) * Ac_lambda(17) / (R(14) - R(4))
            c(5, 13) = c(5, 12) * Ac_lambda(17) / (R(14) - R(7))
            c(6, 13) = c(6, 12) * Ac_lambda(17) / (R(14) - R(8))
            c(7, 13) = c(7, 12) * Ac_lambda(17) / (R(14) - R(10))
            c(8, 13) = c(8, 12) * Ac_lambda(17) / (R(14) - R(11))
            c(9, 13) = c(9, 12) * Ac_lambda(17) / (R(14) - R(12))
            c(10, 13) = c(10, 12) * Ac_lambda(17) / (R(14) - R(13))
            c(11, 13) = c(11, 12) * Ac_lambda(17) / (R(14) - R(16))
            c(12, 13) = c(12, 12) * Ac_lambda(17) / (R(14) - R(17))
            Ac_lambda(17) = Ac_lambda(17) / 0.173
            c(13, 13) = ybeg(14) * 0
            For k = 1 To 12
                c(13, 13) = c(13, 13) - c(k, 13)
            Next k
            ' ---------------------------------------------------------------
            c(1, 14) = c(1, 13) * cap(14) / (R(15) - R(1))
            c(2, 14) = c(2, 13) * cap(14) / (R(15) - R(2))
            c(3, 14) = c(3, 13) * cap(14) / (R(15) - R(3))
            c(4, 14) = c(4, 13) * cap(14) / (R(15) - R(4))
            c(5, 14) = c(5, 13) * cap(14) / (R(15) - R(7))
            c(6, 14) = c(6, 13) * cap(14) / (R(15) - R(8))
            c(7, 14) = c(7, 13) * cap(14) / (R(15) - R(10))
            c(8, 14) = c(8, 13) * cap(14) / (R(15) - R(11))
            c(9, 14) = c(9, 13) * cap(14) / (R(15) - R(12))
            c(10, 14) = c(10, 13) * cap(14) / (R(15) - R(13))
            c(11, 14) = c(11, 13) * cap(14) / (R(15) - R(16))
            c(12, 14) = c(12, 13) * cap(14) / (R(15) - R(17))
            c(13, 14) = c(13, 13) * cap(14) / (R(15) - R(14))
            c(14, 14) = ybeg(15) * 0
            For k = 1 To 13
                c(14, 14) = c(14, 14) - c(k, 14)
            Next k
            ' ---------------------------------------------------------------
            c(1, 15) = c(1, 14) * Ac_lambda(15) / (R(18) - R(1))
            c(2, 15) = c(2, 14) * Ac_lambda(15) / (R(18) - R(2))
            c(3, 15) = c(3, 14) * Ac_lambda(15) / (R(18) - R(3))
            c(4, 15) = c(4, 14) * Ac_lambda(15) / (R(18) - R(4))
            c(5, 15) = c(5, 14) * Ac_lambda(15) / (R(18) - R(7))
            c(6, 15) = c(6, 14) * Ac_lambda(15) / (R(18) - R(8))
            c(7, 15) = c(7, 14) * Ac_lambda(15) / (R(18) - R(10))
            c(8, 15) = c(8, 14) * Ac_lambda(15) / (R(18) - R(11))
            c(9, 15) = c(9, 14) * Ac_lambda(15) / (R(18) - R(12))
            c(10, 15) = c(10, 14) * Ac_lambda(15) / (R(18) - R(13))
            c(11, 15) = c(11, 14) * Ac_lambda(15) / (R(18) - R(16))
            c(12, 15) = c(12, 14) * Ac_lambda(15) / (R(18) - R(17))
            c(13, 15) = c(13, 14) * Ac_lambda(15) / (R(18) - R(14))
            c(14, 15) = c(14, 14) * Ac_lambda(15) / (R(18) - R(15))
            c(15, 15) = ybeg(18) * 0
            For k = 1 To 14
                c(15, 15) = c(15, 15) - c(k, 15)
            Next k
            ' ---------------------------------------------------------------
            c(1, 16) = c(1, 15) * cap(18) / (R(19) - R(1))
            c(2, 16) = c(2, 15) * cap(18) / (R(19) - R(2))
            c(3, 16) = c(3, 15) * cap(18) / (R(19) - R(3))
            c(4, 16) = c(4, 15) * cap(18) / (R(19) - R(4))
            c(5, 16) = c(5, 15) * cap(18) / (R(19) - R(7))
            c(6, 16) = c(6, 15) * cap(18) / (R(19) - R(8))
            c(7, 16) = c(7, 15) * cap(18) / (R(19) - R(10))
            c(8, 16) = c(8, 15) * cap(18) / (R(19) - R(11))
            c(9, 16) = c(9, 15) * cap(18) / (R(19) - R(12))
            c(10, 16) = c(10, 15) * cap(18) / (R(19) - R(13))
            c(11, 16) = c(11, 15) * cap(18) / (R(19) - R(16))
            c(12, 16) = c(12, 15) * cap(18) / (R(19) - R(17))
            c(13, 16) = c(13, 15) * cap(18) / (R(19) - R(14))
            c(14, 16) = c(14, 15) * cap(18) / (R(19) - R(15))
            c(15, 16) = c(15, 15) * cap(18) / (R(19) - R(18))
            c(16, 16) = ybeg(19) * 0
            For k = 1 To 15
                c(16, 16) = c(16, 16) - c(k, 16)
            Next k
            ' ---------------------------------------------------------------
            c(1, 17) = c(1, 16) * Ac_lambda(19) / (R(21) - R(1))
            c(2, 17) = c(2, 16) * Ac_lambda(19) / (R(21) - R(2))
            c(3, 17) = c(3, 16) * Ac_lambda(19) / (R(21) - R(3))
            c(4, 17) = c(4, 16) * Ac_lambda(19) / (R(21) - R(4))
            c(5, 17) = c(5, 16) * Ac_lambda(19) / (R(21) - R(7))
            c(6, 17) = c(6, 16) * Ac_lambda(19) / (R(21) - R(8))
            c(7, 17) = c(7, 16) * Ac_lambda(19) / (R(21) - R(10))
            c(8, 17) = c(8, 16) * Ac_lambda(19) / (R(21) - R(11))
            c(9, 17) = c(9, 16) * Ac_lambda(19) / (R(21) - R(12))
            c(10, 17) = c(10, 16) * Ac_lambda(19) / (R(21) - R(13))
            c(11, 17) = c(11, 16) * Ac_lambda(19) / (R(21) - R(16))
            c(12, 17) = c(12, 16) * Ac_lambda(19) / (R(21) - R(17))
            c(13, 17) = c(13, 16) * Ac_lambda(19) / (R(21) - R(14))
            c(14, 17) = c(14, 16) * Ac_lambda(19) / (R(21) - R(15))
            c(15, 17) = c(15, 16) * Ac_lambda(19) / (R(21) - R(18))
            c(16, 17) = c(16, 16) * Ac_lambda(19) / (R(21) - R(19))
            c(17, 17) = ybeg(21) * 0
            For k = 1 To 16
                c(17, 17) = c(17, 17) - c(k, 17)
            Next k


        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yc() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            yc(14) = c(1, 13) * Math.Exp(-R(1) * t) + c(2, 13) * Math.Exp(-R(2) * t) + c(3, 13) * Math.Exp(-R(3) * t) + c(4, 13) * Math.Exp(-R(4) * t) + c(5, 13) * Math.Exp(-R(7) * t) + c(6, 13) * Math.Exp(-R(8) * t) + c(7, 13) * Math.Exp(-R(10) * t) + c(8, 13) * Math.Exp(-R(11) * t) + c(9, 13) * Math.Exp(-R(12) * t) + c(10, 13) * Math.Exp(-R(13) * t) + c(11, 13) * Math.Exp(-R(16) * t) + c(12, 13) * Math.Exp(-R(17) * t) + c(13, 13) * Math.Exp(-R(14) * t)
            yc(15) = c(1, 14) * Math.Exp(-R(1) * t) + c(2, 14) * Math.Exp(-R(2) * t) + c(3, 14) * Math.Exp(-R(3) * t) + c(4, 14) * Math.Exp(-R(4) * t) + c(5, 14) * Math.Exp(-R(7) * t) + c(6, 14) * Math.Exp(-R(8) * t) + c(7, 14) * Math.Exp(-R(10) * t) + c(8, 14) * Math.Exp(-R(11) * t) + c(9, 14) * Math.Exp(-R(12) * t) + c(10, 14) * Math.Exp(-R(13) * t) + c(11, 14) * Math.Exp(-R(16) * t) + c(12, 14) * Math.Exp(-R(17) * t) + c(13, 14) * Math.Exp(-R(14) * t) + c(14, 14) * Math.Exp(-R(15) * t)
            yc(18) = c(1, 15) * Math.Exp(-R(1) * t) + c(2, 15) * Math.Exp(-R(2) * t) + c(3, 15) * Math.Exp(-R(3) * t) + c(4, 15) * Math.Exp(-R(4) * t) + c(5, 15) * Math.Exp(-R(7) * t) + c(6, 15) * Math.Exp(-R(8) * t) + c(7, 15) * Math.Exp(-R(10) * t) + c(8, 15) * Math.Exp(-R(11) * t) + c(9, 15) * Math.Exp(-R(12) * t) + c(10, 15) * Math.Exp(-R(13) * t) + c(11, 15) * Math.Exp(-R(16) * t) + c(12, 15) * Math.Exp(-R(17) * t) + c(13, 15) * Math.Exp(-R(14) * t) + c(14, 15) * Math.Exp(-R(15) * t) + c(15, 15) * Math.Exp(-R(18) * t)
            yc(19) = c(1, 16) * Math.Exp(-R(1) * t) + c(2, 16) * Math.Exp(-R(2) * t) + c(3, 16) * Math.Exp(-R(3) * t) + c(4, 16) * Math.Exp(-R(4) * t) + c(5, 16) * Math.Exp(-R(7) * t) + c(6, 16) * Math.Exp(-R(8) * t) + c(7, 16) * Math.Exp(-R(10) * t) + c(8, 16) * Math.Exp(-R(11) * t) + c(9, 16) * Math.Exp(-R(12) * t) + c(10, 16) * Math.Exp(-R(13) * t) + c(11, 16) * Math.Exp(-R(16) * t) + c(12, 16) * Math.Exp(-R(17) * t) + c(13, 16) * Math.Exp(-R(14) * t) + c(14, 16) * Math.Exp(-R(15) * t) + c(15, 16) * Math.Exp(-R(18) * t) + c(16, 16) * Math.Exp(-R(19) * t)
            yc(21) = c(1, 17) * Math.Exp(-R(1) * t) + c(2, 17) * Math.Exp(-R(2) * t) + c(3, 17) * Math.Exp(-R(3) * t) + c(4, 17) * Math.Exp(-R(4) * t) + c(5, 17) * Math.Exp(-R(7) * t) + c(6, 17) * Math.Exp(-R(8) * t) + c(7, 17) * Math.Exp(-R(10) * t) + c(8, 17) * Math.Exp(-R(11) * t) + c(9, 17) * Math.Exp(-R(12) * t) + c(10, 17) * Math.Exp(-R(13) * t) + c(11, 17) * Math.Exp(-R(16) * t) + c(12, 17) * Math.Exp(-R(17) * t) + c(13, 17) * Math.Exp(-R(14) * t) + c(14, 17) * Math.Exp(-R(15) * t) + c(15, 17) * Math.Exp(-R(18) * t) + c(16, 17) * Math.Exp(-R(19) * t) + c(17, 17) * Math.Exp(-R(21) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = c(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = c

        End Function

    End Class
End Namespace