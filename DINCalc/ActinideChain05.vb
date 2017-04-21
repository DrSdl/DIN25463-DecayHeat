Namespace DIN25463MOX
    Public Class ActinideChain05


        Private e(21, 21) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    e(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double, ByRef n2n() As Double) As DBNull
            '###############Fünfte Kette(238U -->244CM I)################
            Dim k As Integer
            Init_chain = DBNull.Value
            e(1, 1) = ybeg(5)
            ' ---------------------------------------------------------------
            e(1, 2) = e(1, 1) * n2n(5) / (R(4) - R(5))
            e(2, 2) = ybeg(4) * 0 - e(1, 2)
            ' ---------------------------------------------------------------
            e(1, 3) = e(1, 2) * Ac_lambda(4) / (R(7) - R(5))
            e(2, 3) = e(2, 2) * Ac_lambda(4) / (R(7) - R(4))
            e(3, 3) = ybeg(7) * 0 - e(1, 3) - e(2, 3)
            ' ---------------------------------------------------------------
            e(1, 4) = e(1, 3) * cap(7) / (R(8) - R(5))
            e(2, 4) = e(2, 3) * cap(7) / (R(8) - R(4))
            e(3, 4) = e(3, 3) * cap(7) / (R(8) - R(7))
            e(4, 4) = ybeg(8) * 0
            For k = 1 To 3
                e(4, 4) = e(4, 4) - e(k, 4)
            Next k
            ' ---------------------------------------------------------------
            e(1, 5) = e(1, 4) * Ac_lambda(8) / (R(10) - R(5))
            e(2, 5) = e(2, 4) * Ac_lambda(8) / (R(10) - R(4))
            e(3, 5) = e(3, 4) * Ac_lambda(8) / (R(10) - R(7))
            e(4, 5) = e(4, 4) * Ac_lambda(8) / (R(10) - R(8))
            e(5, 5) = ybeg(10) * 0
            For k = 1 To 4
                e(5, 5) = e(5, 5) - e(k, 5)
            Next k
            ' ---------------------------------------------------------------
            e(1, 6) = e(1, 5) * cap(10) / (R(11) - R(5))
            e(2, 6) = e(2, 5) * cap(10) / (R(11) - R(4))
            e(3, 6) = e(3, 5) * cap(10) / (R(11) - R(7))
            e(4, 6) = e(4, 5) * cap(10) / (R(11) - R(8))
            e(5, 6) = e(5, 5) * cap(10) / (R(11) - R(10))
            e(6, 6) = ybeg(11) * 0
            For k = 1 To 5
                e(6, 6) = e(6, 6) - e(k, 6)
            Next k
            ' ---------------------------------------------------------------
            e(1, 7) = e(1, 6) * cap(11) / (R(12) - R(5))
            e(2, 7) = e(2, 6) * cap(11) / (R(12) - R(4))
            e(3, 7) = e(3, 6) * cap(11) / (R(12) - R(7))
            e(4, 7) = e(4, 6) * cap(11) / (R(12) - R(8))
            e(5, 7) = e(5, 6) * cap(11) / (R(12) - R(10))
            e(6, 7) = e(6, 6) * cap(11) / (R(12) - R(11))
            e(7, 7) = ybeg(12) * 0
            For k = 1 To 6
                e(7, 7) = e(7, 7) - e(k, 7)
            Next k
            ' ---------------------------------------------------------------
            e(1, 8) = e(1, 7) * cap(12) / (R(13) - R(5))
            e(2, 8) = e(2, 7) * cap(12) / (R(13) - R(4))
            e(3, 8) = e(3, 7) * cap(12) / (R(13) - R(7))
            e(4, 8) = e(4, 7) * cap(12) / (R(13) - R(8))
            e(5, 8) = e(5, 7) * cap(12) / (R(13) - R(10))
            e(6, 8) = e(6, 7) * cap(12) / (R(13) - R(11))
            e(7, 8) = e(7, 7) * cap(12) / (R(13) - R(12))
            e(8, 8) = ybeg(13) * 0
            For k = 1 To 7
                e(8, 8) = e(8, 8) - e(k, 8)
            Next k
            ' ---------------------------------------------------------------
            e(1, 9) = e(1, 8) * cap(13) / (R(14) - R(5))
            e(2, 9) = e(2, 8) * cap(13) / (R(14) - R(4))
            e(3, 9) = e(3, 8) * cap(13) / (R(14) - R(7))
            e(4, 9) = e(4, 8) * cap(13) / (R(14) - R(8))
            e(5, 9) = e(5, 8) * cap(13) / (R(14) - R(10))
            e(6, 9) = e(6, 8) * cap(13) / (R(14) - R(11))
            e(7, 9) = e(7, 8) * cap(13) / (R(14) - R(12))
            e(8, 9) = e(8, 8) * cap(13) / (R(14) - R(13))
            e(9, 9) = ybeg(14) * 0
            For k = 1 To 8
                e(9, 9) = e(9, 9) - e(k, 9)
            Next k
            ' ---------------------------------------------------------------
            e(1, 10) = e(1, 9) * cap(14) / (R(15) - R(5))
            e(2, 10) = e(2, 9) * cap(14) / (R(15) - R(4))
            e(3, 10) = e(3, 9) * cap(14) / (R(15) - R(7))
            e(4, 10) = e(4, 9) * cap(14) / (R(15) - R(8))
            e(5, 10) = e(5, 9) * cap(14) / (R(15) - R(10))
            e(6, 10) = e(6, 9) * cap(14) / (R(15) - R(11))
            e(7, 10) = e(7, 9) * cap(14) / (R(15) - R(12))
            e(8, 10) = e(8, 9) * cap(14) / (R(15) - R(13))
            e(9, 10) = e(9, 9) * cap(14) / (R(15) - R(14))
            e(10, 10) = ybeg(15) * 0
            For k = 1 To 9
                e(10, 10) = e(10, 10) - e(k, 10)
            Next k
            ' ---------------------------------------------------------------
            e(1, 11) = e(1, 10) * Ac_lambda(15) / (R(18) - R(5))
            e(2, 11) = e(2, 10) * Ac_lambda(15) / (R(18) - R(4))
            e(3, 11) = e(3, 10) * Ac_lambda(15) / (R(18) - R(7))
            e(4, 11) = e(4, 10) * Ac_lambda(15) / (R(18) - R(8))
            e(5, 11) = e(5, 10) * Ac_lambda(15) / (R(18) - R(10))
            e(6, 11) = e(6, 10) * Ac_lambda(15) / (R(18) - R(11))
            e(7, 11) = e(7, 10) * Ac_lambda(15) / (R(18) - R(12))
            e(8, 11) = e(8, 10) * Ac_lambda(15) / (R(18) - R(13))
            e(9, 11) = e(9, 10) * Ac_lambda(15) / (R(18) - R(14))
            e(10, 11) = e(10, 10) * Ac_lambda(15) / (R(18) - R(15))
            e(11, 11) = ybeg(18) * 0
            For k = 1 To 10
                e(11, 11) = e(11, 11) - e(k, 11)
            Next k
            ' ---------------------------------------------------------------
            e(1, 12) = e(1, 11) * cap(18) / (R(19) - R(5))
            e(2, 12) = e(2, 11) * cap(18) / (R(19) - R(4))
            e(3, 12) = e(3, 11) * cap(18) / (R(19) - R(7))
            e(4, 12) = e(4, 11) * cap(18) / (R(19) - R(8))
            e(5, 12) = e(5, 11) * cap(18) / (R(19) - R(10))
            e(6, 12) = e(6, 11) * cap(18) / (R(19) - R(11))
            e(7, 12) = e(7, 11) * cap(18) / (R(19) - R(12))
            e(8, 12) = e(8, 11) * cap(18) / (R(19) - R(13))
            e(9, 12) = e(9, 11) * cap(18) / (R(19) - R(14))
            e(10, 12) = e(10, 11) * cap(18) / (R(19) - R(15))
            e(11, 12) = e(11, 11) * cap(18) / (R(19) - R(18))
            e(12, 12) = ybeg(19) * 0
            For k = 1 To 11
                e(12, 12) = e(12, 12) - e(k, 12)
            Next k
            ' ---------------------------------------------------------------
            e(1, 13) = e(1, 12) * Ac_lambda(19) / (R(21) - R(5))
            e(2, 13) = e(2, 12) * Ac_lambda(19) / (R(21) - R(4))
            e(3, 13) = e(3, 12) * Ac_lambda(19) / (R(21) - R(7))
            e(4, 13) = e(4, 12) * Ac_lambda(19) / (R(21) - R(8))
            e(5, 13) = e(5, 12) * Ac_lambda(19) / (R(21) - R(10))
            e(6, 13) = e(6, 12) * Ac_lambda(19) / (R(21) - R(11))
            e(7, 13) = e(7, 12) * Ac_lambda(19) / (R(21) - R(12))
            e(8, 13) = e(8, 12) * Ac_lambda(19) / (R(21) - R(13))
            e(9, 13) = e(9, 12) * Ac_lambda(19) / (R(21) - R(14))
            e(10, 13) = e(10, 12) * Ac_lambda(19) / (R(21) - R(15))
            e(11, 13) = e(11, 12) * Ac_lambda(19) / (R(21) - R(18))
            e(12, 13) = e(12, 12) * Ac_lambda(19) / (R(21) - R(19))
            e(13, 13) = ybeg(21) * 0
            For k = 1 To 12
                e(13, 13) = e(13, 13) - e(k, 13)
            Next k
            ' ---------------------------------------------------------------

        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef ye() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            ye(5) = e(1, 1) * Math.Exp(-R(5) * t)
            ye(4) = e(1, 2) * Math.Exp(-R(5) * t) + e(2, 2) * Math.Exp(-R(4) * t)
            ye(7) = e(1, 3) * Math.Exp(-R(5) * t) + e(2, 3) * Math.Exp(-R(4) * t) + e(3, 3) * Math.Exp(-R(7) * t)
            ye(8) = e(1, 4) * Math.Exp(-R(5) * t) + e(2, 4) * Math.Exp(-R(4) * t) + e(3, 4) * Math.Exp(-R(7) * t) + e(4, 4) * Math.Exp(-R(8) * t)
            ye(10) = e(1, 5) * Math.Exp(-R(5) * t) + e(2, 5) * Math.Exp(-R(4) * t) + e(3, 5) * Math.Exp(-R(7) * t) + e(4, 5) * Math.Exp(-R(8) * t) + e(5, 5) * Math.Exp(-R(10) * t)
            ye(11) = e(1, 6) * Math.Exp(-R(5) * t) + e(2, 6) * Math.Exp(-R(4) * t) + e(3, 6) * Math.Exp(-R(7) * t) + e(4, 6) * Math.Exp(-R(8) * t) + e(5, 6) * Math.Exp(-R(10) * t) + e(6, 6) * Math.Exp(-R(11) * t)
            ye(12) = e(1, 7) * Math.Exp(-R(5) * t) + e(2, 7) * Math.Exp(-R(4) * t) + e(3, 7) * Math.Exp(-R(7) * t) + e(4, 7) * Math.Exp(-R(8) * t) + e(5, 7) * Math.Exp(-R(10) * t) + e(6, 7) * Math.Exp(-R(11) * t) + e(7, 7) * Math.Exp(-R(12) * t)
            ye(13) = e(1, 8) * Math.Exp(-R(5) * t) + e(2, 8) * Math.Exp(-R(4) * t) + e(3, 8) * Math.Exp(-R(7) * t) + e(4, 8) * Math.Exp(-R(8) * t) + e(5, 8) * Math.Exp(-R(10) * t) + e(6, 8) * Math.Exp(-R(11) * t) + e(7, 8) * Math.Exp(-R(12) * t) + e(8, 8) * Math.Exp(-R(13) * t)
            ye(14) = e(1, 9) * Math.Exp(-R(5) * t) + e(2, 9) * Math.Exp(-R(4) * t) + e(3, 9) * Math.Exp(-R(7) * t) + e(4, 9) * Math.Exp(-R(8) * t) + e(5, 9) * Math.Exp(-R(10) * t) + e(6, 9) * Math.Exp(-R(11) * t) + e(7, 9) * Math.Exp(-R(12) * t) + e(8, 9) * Math.Exp(-R(13) * t) + e(9, 9) * Math.Exp(-R(14) * t)
            ye(15) = e(1, 10) * Math.Exp(-R(5) * t) + e(2, 10) * Math.Exp(-R(4) * t) + e(3, 10) * Math.Exp(-R(7) * t) + e(4, 10) * Math.Exp(-R(8) * t) + e(5, 10) * Math.Exp(-R(10) * t) + e(6, 10) * Math.Exp(-R(11) * t) + e(7, 10) * Math.Exp(-R(12) * t) + e(8, 10) * Math.Exp(-R(13) * t) + e(9, 10) * Math.Exp(-R(14) * t) + e(10, 10) * Math.Exp(-R(15) * t)
            ye(18) = e(1, 11) * Math.Exp(-R(5) * t) + e(2, 11) * Math.Exp(-R(4) * t) + e(3, 11) * Math.Exp(-R(7) * t) + e(4, 11) * Math.Exp(-R(8) * t) + e(5, 11) * Math.Exp(-R(10) * t) + e(6, 11) * Math.Exp(-R(11) * t) + e(7, 11) * Math.Exp(-R(12) * t) + e(8, 11) * Math.Exp(-R(13) * t) + e(9, 11) * Math.Exp(-R(14) * t) + e(10, 11) * Math.Exp(-R(15) * t) + e(11, 11) * Math.Exp(-R(18) * t)
            ye(19) = e(1, 12) * Math.Exp(-R(5) * t) + e(2, 12) * Math.Exp(-R(4) * t) + e(3, 12) * Math.Exp(-R(7) * t) + e(4, 12) * Math.Exp(-R(8) * t) + e(5, 12) * Math.Exp(-R(10) * t) + e(6, 12) * Math.Exp(-R(11) * t) + e(7, 12) * Math.Exp(-R(12) * t) + e(8, 12) * Math.Exp(-R(13) * t) + e(9, 12) * Math.Exp(-R(14) * t) + e(10, 12) * Math.Exp(-R(15) * t) + e(11, 12) * Math.Exp(-R(18) * t) + e(12, 12) * Math.Exp(-R(19) * t)
            ye(21) = e(1, 13) * Math.Exp(-R(5) * t) + e(2, 13) * Math.Exp(-R(4) * t) + e(3, 13) * Math.Exp(-R(7) * t) + e(4, 13) * Math.Exp(-R(8) * t) + e(5, 13) * Math.Exp(-R(10) * t) + e(6, 13) * Math.Exp(-R(11) * t) + e(7, 13) * Math.Exp(-R(12) * t) + e(8, 13) * Math.Exp(-R(13) * t) + e(9, 13) * Math.Exp(-R(14) * t) + e(10, 13) * Math.Exp(-R(15) * t) + e(11, 13) * Math.Exp(-R(18) * t) + e(12, 13) * Math.Exp(-R(19) * t) + e(13, 13) * Math.Exp(-R(21) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = e(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = e

        End Function


    End Class
End Namespace