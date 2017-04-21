Namespace DIN25463MOX
    Public Class ActinideChain02


        Private b(21, 21) As Double


        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    b(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            Dim k As Integer
            Init_chain = DBNull.Value
            '###############Zweite Kette(234U -->244CM II)################


            ' ---------------------------------------------------------------
            'For k = 1 To 10
            'For l = 1 To 10
            'Worksheets("function").Cells(179 + k, 1 + l) = b(k, l)
            'Next l
            'Next k
            ' ---------------------------------------------------------------

            b(1, 11) = b(1, 10) * Ac_lambda(13) / (R(16) - R(1))
            b(2, 11) = b(2, 10) * Ac_lambda(13) / (R(16) - R(2))
            b(3, 11) = b(3, 10) * Ac_lambda(13) / (R(16) - R(3))
            b(4, 11) = b(4, 10) * Ac_lambda(13) / (R(16) - R(4))
            b(5, 11) = b(5, 10) * Ac_lambda(13) / (R(16) - R(7))
            b(6, 11) = b(6, 10) * Ac_lambda(13) / (R(16) - R(8))
            b(7, 11) = b(7, 10) * Ac_lambda(13) / (R(16) - R(10))
            b(8, 11) = b(8, 10) * Ac_lambda(13) / (R(16) - R(11))
            b(9, 11) = b(9, 10) * Ac_lambda(13) / (R(16) - R(12))
            b(10, 11) = b(10, 10) * Ac_lambda(13) / (R(16) - R(13))
            b(11, 11) = ybeg(16)
            For k = 1 To 10
                b(11, 11) = b(11, 11) - b(k, 11)
            Next k
            ' ---------------------------------------------------------------
            b(1, 12) = b(1, 11) * cap(16) / (R(17) - R(1))
            b(2, 12) = b(2, 11) * cap(16) / (R(17) - R(2))
            b(3, 12) = b(3, 11) * cap(16) / (R(17) - R(3))
            b(4, 12) = b(4, 11) * cap(16) / (R(17) - R(4))
            b(5, 12) = b(5, 11) * cap(16) / (R(17) - R(7))
            b(6, 12) = b(6, 11) * cap(16) / (R(17) - R(8))
            b(7, 12) = b(7, 11) * cap(16) / (R(17) - R(10))
            b(8, 12) = b(8, 11) * cap(16) / (R(17) - R(11))
            b(9, 12) = b(9, 11) * cap(16) / (R(17) - R(12))
            b(10, 12) = b(10, 11) * cap(16) / (R(17) - R(13))
            b(11, 12) = b(11, 11) * cap(16) / (R(17) - R(16))
            b(12, 12) = ybeg(17)
            For k = 1 To 11
                b(12, 12) = b(12, 12) - b(k, 12)
            Next k
            ' ---------------------------------------------------------------
            b(1, 13) = b(1, 12) * cap(17) / (R(18) - R(1))
            b(2, 13) = b(2, 12) * cap(17) / (R(18) - R(2))
            b(3, 13) = b(3, 12) * cap(17) / (R(18) - R(3))
            b(4, 13) = b(4, 12) * cap(17) / (R(18) - R(4))
            b(5, 13) = b(5, 12) * cap(17) / (R(18) - R(7))
            b(6, 13) = b(6, 12) * cap(17) / (R(18) - R(8))
            b(7, 13) = b(7, 12) * cap(17) / (R(18) - R(10))
            b(8, 13) = b(8, 12) * cap(17) / (R(18) - R(11))
            b(9, 13) = b(9, 12) * cap(17) / (R(18) - R(12))
            b(10, 13) = b(10, 12) * cap(17) / (R(18) - R(13))
            b(11, 13) = b(11, 12) * cap(17) / (R(18) - R(16))
            b(12, 13) = b(12, 12) * cap(17) / (R(18) - R(17))
            b(13, 13) = ybeg(18) * 0
            For k = 1 To 12
                b(13, 13) = b(13, 13) - b(k, 13)
            Next k
            ' ---------------------------------------------------------------
            b(1, 14) = b(1, 13) * cap(18) / (R(19) - R(1))
            b(2, 14) = b(2, 13) * cap(18) / (R(19) - R(2))
            b(3, 14) = b(3, 13) * cap(18) / (R(19) - R(3))
            b(4, 14) = b(4, 13) * cap(18) / (R(19) - R(4))
            b(5, 14) = b(5, 13) * cap(18) / (R(19) - R(7))
            b(6, 14) = b(6, 13) * cap(18) / (R(19) - R(8))
            b(7, 14) = b(7, 13) * cap(18) / (R(19) - R(10))
            b(8, 14) = b(8, 13) * cap(18) / (R(19) - R(11))
            b(9, 14) = b(9, 13) * cap(18) / (R(19) - R(12))
            b(10, 14) = b(10, 13) * cap(18) / (R(19) - R(13))
            b(11, 14) = b(11, 13) * cap(18) / (R(19) - R(16))
            b(12, 14) = b(12, 13) * cap(18) / (R(19) - R(17))
            b(13, 14) = b(13, 13) * cap(18) / (R(19) - R(18))
            b(14, 14) = ybeg(19) * 0
            For k = 1 To 13
                b(14, 14) = b(14, 14) - b(k, 14)
            Next k
            ' ---------------------------------------------------------------
            b(1, 15) = b(1, 14) * Ac_lambda(19) / (R(21) - R(1))
            b(2, 15) = b(2, 14) * Ac_lambda(19) / (R(21) - R(2))
            b(3, 15) = b(3, 14) * Ac_lambda(19) / (R(21) - R(3))
            b(4, 15) = b(4, 14) * Ac_lambda(19) / (R(21) - R(4))
            b(5, 15) = b(5, 14) * Ac_lambda(19) / (R(21) - R(7))
            b(6, 15) = b(6, 14) * Ac_lambda(19) / (R(21) - R(8))
            b(7, 15) = b(7, 14) * Ac_lambda(19) / (R(21) - R(10))
            b(8, 15) = b(8, 14) * Ac_lambda(19) / (R(21) - R(11))
            b(9, 15) = b(9, 14) * Ac_lambda(19) / (R(21) - R(12))
            b(10, 15) = b(10, 14) * Ac_lambda(19) / (R(21) - R(13))
            b(11, 15) = b(11, 14) * Ac_lambda(19) / (R(21) - R(16))
            b(12, 15) = b(12, 14) * Ac_lambda(19) / (R(21) - R(17))
            b(13, 15) = b(13, 14) * Ac_lambda(19) / (R(21) - R(18))
            b(14, 15) = b(14, 14) * Ac_lambda(19) / (R(21) - R(19))
            b(15, 15) = ybeg(21) * 0
            For k = 1 To 14
                b(15, 15) = b(15, 15) - b(k, 15)
            Next k
            ' ---------------------------------------------------------------
        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yb() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value

            'yb(1) = b(1, 1) * Math.Exp(-R(1) * t)
            'yb(2) = b(1, 2) * Math.Exp(-R(1) * t) + b(2, 2) * Math.Exp(-R(2) * t)
            'yb(3) = b(1, 3) * Math.Exp(-R(1) * t) + b(2, 3) * Math.Exp(-R(2) * t) + b(3, 3) * Math.Exp(-R(3) * t)
            'yb(4) = b(1, 4) * Math.Exp(-R(1) * t) + b(2, 4) * Math.Exp(-R(2) * t) + b(3, 4) * Math.Exp(-R(3) * t) + b(4, 4) * Math.Exp(-R(4) * t)
            'yb(7) = b(1, 5) * Math.Exp(-R(1) * t) + b(2, 5) * Math.Exp(-R(2) * t) + b(3, 5) * Math.Exp(-R(3) * t) + b(4, 5) * Math.Exp(-R(4) * t) + b(5, 5) * Math.Exp(-R(7) * t)
            'yb(8) = b(1, 6) * Math.Exp(-R(1) * t) + b(2, 6) * Math.Exp(-R(2) * t) + b(3, 6) * Math.Exp(-R(3) * t) + b(4, 6) * Math.Exp(-R(4) * t) + b(5, 6) * Math.Exp(-R(7) * t) + b(6, 6) * Math.Exp(-R(8) * t)
            'yb(10) = b(1, 7) * Math.Exp(-R(1) * t) + b(2, 7) * Math.Exp(-R(2) * t) + b(3, 7) * Math.Exp(-R(3) * t) + b(4, 7) * Math.Exp(-R(4) * t) + b(5, 7) * Math.Exp(-R(7) * t) + b(6, 7) * Math.Exp(-R(8) * t) + b(7, 7) * Math.Exp(-R(10) * t)
            'yb(11) = b(1, 8) * Math.Exp(-R(1) * t) + b(2, 8) * Math.Exp(-R(2) * t) + b(3, 8) * Math.Exp(-R(3) * t) + b(4, 8) * Math.Exp(-R(4) * t) + b(5, 8) * Math.Exp(-R(7) * t) + b(6, 8) * Math.Exp(-R(8) * t) + b(7, 8) * Math.Exp(-R(10) * t) + b(8, 8) * Math.Exp(-R(11) * t)
            'yb(12) = b(1, 9) * Math.Exp(-R(1) * t) + b(2, 9) * Math.Exp(-R(2) * t) + b(3, 9) * Math.Exp(-R(3) * t) + b(4, 9) * Math.Exp(-R(4) * t) + b(5, 9) * Math.Exp(-R(7) * t) + b(6, 9) * Math.Exp(-R(8) * t) + b(7, 9) * Math.Exp(-R(10) * t) + b(8, 9) * Math.Exp(-R(11) * t) + b(9, 9) * Math.Exp(-R(12) * t)
            'yb(13) = b(1, 10) * Math.Exp(-R(1) * t) + b(2, 10) * Math.Exp(-R(2) * t) + b(3, 10) * Math.Exp(-R(3) * t) + b(4, 10) * Math.Exp(-R(4) * t) + b(5, 10) * Math.Exp(-R(7) * t) + b(6, 10) * Math.Exp(-R(8) * t) + b(7, 10) * Math.Exp(-R(10) * t) + b(8, 10) * Math.Exp(-R(11) * t) + b(9, 10) * Math.Exp(-R(12) * t) + b(10, 10) * Math.Exp(-R(13) * t)
            yb(16) = b(1, 11) * Math.Exp(-R(1) * t) + b(2, 11) * Math.Exp(-R(2) * t) + b(3, 11) * Math.Exp(-R(3) * t) + b(4, 11) * Math.Exp(-R(4) * t) + b(5, 11) * Math.Exp(-R(7) * t) + b(6, 11) * Math.Exp(-R(8) * t) + b(7, 11) * Math.Exp(-R(10) * t) + b(8, 11) * Math.Exp(-R(11) * t) + b(9, 11) * Math.Exp(-R(12) * t) + b(10, 11) * Math.Exp(-R(13) * t) + b(11, 11) * Math.Exp(-R(16) * t)
            yb(17) = b(1, 12) * Math.Exp(-R(1) * t) + b(2, 12) * Math.Exp(-R(2) * t) + b(3, 12) * Math.Exp(-R(3) * t) + b(4, 12) * Math.Exp(-R(4) * t) + b(5, 12) * Math.Exp(-R(7) * t) + b(6, 12) * Math.Exp(-R(8) * t) + b(7, 12) * Math.Exp(-R(10) * t) + b(8, 12) * Math.Exp(-R(11) * t) + b(9, 12) * Math.Exp(-R(12) * t) + b(10, 12) * Math.Exp(-R(13) * t) + b(11, 12) * Math.Exp(-R(16) * t) + b(12, 12) * Math.Exp(-R(17) * t)
            yb(18) = b(1, 13) * Math.Exp(-R(1) * t) + b(2, 13) * Math.Exp(-R(2) * t) + b(3, 13) * Math.Exp(-R(3) * t) + b(4, 13) * Math.Exp(-R(4) * t) + b(5, 13) * Math.Exp(-R(7) * t) + b(6, 13) * Math.Exp(-R(8) * t) + b(7, 13) * Math.Exp(-R(10) * t) + b(8, 13) * Math.Exp(-R(11) * t) + b(9, 13) * Math.Exp(-R(12) * t) + b(10, 13) * Math.Exp(-R(13) * t) + b(11, 13) * Math.Exp(-R(16) * t) + b(12, 13) * Math.Exp(-R(17) * t) + b(13, 13) * Math.Exp(-R(18) * t)
            yb(19) = b(1, 14) * Math.Exp(-R(1) * t) + b(2, 14) * Math.Exp(-R(2) * t) + b(3, 14) * Math.Exp(-R(3) * t) + b(4, 14) * Math.Exp(-R(4) * t) + b(5, 14) * Math.Exp(-R(7) * t) + b(6, 14) * Math.Exp(-R(8) * t) + b(7, 14) * Math.Exp(-R(10) * t) + b(8, 14) * Math.Exp(-R(11) * t) + b(9, 14) * Math.Exp(-R(12) * t) + b(10, 14) * Math.Exp(-R(13) * t) + b(11, 14) * Math.Exp(-R(16) * t) + b(12, 14) * Math.Exp(-R(17) * t) + b(13, 14) * Math.Exp(-R(18) * t) + b(14, 14) * Math.Exp(-R(19) * t)
            yb(21) = b(1, 15) * Math.Exp(-R(1) * t) + b(2, 15) * Math.Exp(-R(2) * t) + b(3, 15) * Math.Exp(-R(3) * t) + b(4, 15) * Math.Exp(-R(4) * t) + b(5, 15) * Math.Exp(-R(7) * t) + b(6, 15) * Math.Exp(-R(8) * t) + b(7, 15) * Math.Exp(-R(10) * t) + b(8, 15) * Math.Exp(-R(11) * t) + b(9, 15) * Math.Exp(-R(12) * t) + b(10, 15) * Math.Exp(-R(13) * t) + b(11, 15) * Math.Exp(-R(16) * t) + b(12, 15) * Math.Exp(-R(17) * t) + b(13, 15) * Math.Exp(-R(18) * t) + b(14, 15) * Math.Exp(-R(19) * t) + b(15, 15) * Math.Exp(-R(21) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = b(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = b

        End Function


    End Class
End Namespace