Namespace DIN25463MOX
    Public Class ActinideChain01


        Private a(21, 21) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '##############Erste Kette(234U-->244CM I)#############

            Dim k As Integer
            Init_chain = DBNull.Value

            a(1, 1) = ybeg(1)
            ' ---------------------------------------------------------------
            a(1, 2) = a(1, 1) * cap(1) / (R(2) - R(1))
            a(2, 2) = ybeg(2) - a(1, 2)
            ' ---------------------------------------------------------------
            a(1, 3) = a(1, 2) * cap(2) / (R(3) - R(1))
            a(2, 3) = a(2, 2) * cap(2) / (R(3) - R(2))
            a(3, 3) = ybeg(3) - a(1, 3) - a(2, 3)
            ' ---------------------------------------------------------------
            a(1, 4) = a(1, 3) * cap(3) / (R(4) - R(1))
            a(2, 4) = a(2, 3) * cap(3) / (R(4) - R(2))
            a(3, 4) = a(3, 3) * cap(3) / (R(4) - R(3))
            a(4, 4) = ybeg(4)
            For k = 1 To 3
                a(4, 4) = a(4, 4) - a(k, 4)
            Next k
            ' ---------------------------------------------------------------
            a(1, 5) = a(1, 4) * Ac_lambda(4) / (R(7) - R(1))
            a(2, 5) = a(2, 4) * Ac_lambda(4) / (R(7) - R(2))
            a(3, 5) = a(3, 4) * Ac_lambda(4) / (R(7) - R(3))
            a(4, 5) = a(4, 4) * Ac_lambda(4) / (R(7) - R(4))
            a(5, 5) = ybeg(7)
            For k = 1 To 4
                a(5, 5) = a(5, 5) - a(k, 5)
            Next k
            ' ---------------------------------------------------------------
            a(1, 6) = a(1, 5) * cap(7) / (R(8) - R(1))
            a(2, 6) = a(2, 5) * cap(7) / (R(8) - R(2))
            a(3, 6) = a(3, 5) * cap(7) / (R(8) - R(3))
            a(4, 6) = a(4, 5) * cap(7) / (R(8) - R(4))
            a(5, 6) = a(5, 5) * cap(7) / (R(8) - R(7))
            a(6, 6) = ybeg(8)
            For k = 1 To 5
                a(6, 6) = a(6, 6) - a(k, 6)
            Next k
            ' ---------------------------------------------------------------
            a(1, 7) = a(1, 6) * Ac_lambda(8) / (R(10) - R(1))
            a(2, 7) = a(2, 6) * Ac_lambda(8) / (R(10) - R(2))
            a(3, 7) = a(3, 6) * Ac_lambda(8) / (R(10) - R(3))
            a(4, 7) = a(4, 6) * Ac_lambda(8) / (R(10) - R(4))
            a(5, 7) = a(5, 6) * Ac_lambda(8) / (R(10) - R(7))
            a(6, 7) = a(6, 6) * Ac_lambda(8) / (R(10) - R(8))
            a(7, 7) = ybeg(10)
            For k = 1 To 6
                a(7, 7) = a(7, 7) - a(k, 7)
            Next k
            ' ---------------------------------------------------------------
            a(1, 8) = a(1, 7) * cap(10) / (R(11) - R(1))
            a(2, 8) = a(2, 7) * cap(10) / (R(11) - R(2))
            a(3, 8) = a(3, 7) * cap(10) / (R(11) - R(3))
            a(4, 8) = a(4, 7) * cap(10) / (R(11) - R(4))
            a(5, 8) = a(5, 7) * cap(10) / (R(11) - R(7))
            a(6, 8) = a(6, 7) * cap(10) / (R(11) - R(8))
            a(7, 8) = a(7, 7) * cap(10) / (R(11) - R(10))
            a(8, 8) = ybeg(11)
            For k = 1 To 7
                a(8, 8) = a(8, 8) - a(k, 8)
            Next k
            ' ---------------------------------------------------------------
            a(1, 9) = a(1, 8) * cap(11) / (R(12) - R(1))
            a(2, 9) = a(2, 8) * cap(11) / (R(12) - R(2))
            a(3, 9) = a(3, 8) * cap(11) / (R(12) - R(3))
            a(4, 9) = a(4, 8) * cap(11) / (R(12) - R(4))
            a(5, 9) = a(5, 8) * cap(11) / (R(12) - R(7))
            a(6, 9) = a(6, 8) * cap(11) / (R(12) - R(8))
            a(7, 9) = a(7, 8) * cap(11) / (R(12) - R(10))
            a(8, 9) = a(8, 8) * cap(11) / (R(12) - R(11))
            a(9, 9) = ybeg(12)
            For k = 1 To 8
                a(9, 9) = a(9, 9) - a(k, 9)
            Next k
            ' ---------------------------------------------------------------
            a(1, 10) = a(1, 9) * cap(12) / (R(13) - R(1))
            a(2, 10) = a(2, 9) * cap(12) / (R(13) - R(2))
            a(3, 10) = a(3, 9) * cap(12) / (R(13) - R(3))
            a(4, 10) = a(4, 9) * cap(12) / (R(13) - R(4))
            a(5, 10) = a(5, 9) * cap(12) / (R(13) - R(7))
            a(6, 10) = a(6, 9) * cap(12) / (R(13) - R(8))
            a(7, 10) = a(7, 9) * cap(12) / (R(13) - R(10))
            a(8, 10) = a(8, 9) * cap(12) / (R(13) - R(11))
            a(9, 10) = a(9, 9) * cap(12) / (R(13) - R(12))
            a(10, 10) = ybeg(13)
            For k = 1 To 9
                a(10, 10) = a(10, 10) - a(k, 10)
            Next k
            ' ---------------------------------------------------------------
            a(1, 11) = a(1, 10) * cap(13) / (R(14) - R(1))
            a(2, 11) = a(2, 10) * cap(13) / (R(14) - R(2))
            a(3, 11) = a(3, 10) * cap(13) / (R(14) - R(3))
            a(4, 11) = a(4, 10) * cap(13) / (R(14) - R(4))
            a(5, 11) = a(5, 10) * cap(13) / (R(14) - R(7))
            a(6, 11) = a(6, 10) * cap(13) / (R(14) - R(8))
            a(7, 11) = a(7, 10) * cap(13) / (R(14) - R(10))
            a(8, 11) = a(8, 10) * cap(13) / (R(14) - R(11))
            a(9, 11) = a(9, 10) * cap(13) / (R(14) - R(12))
            a(10, 11) = a(10, 10) * cap(13) / (R(14) - R(13))
            a(11, 11) = ybeg(14)
            For k = 1 To 10
                a(11, 11) = a(11, 11) - a(k, 11)
            Next k
            ' ---------------------------------------------------------------
            a(1, 12) = a(1, 11) * cap(14) / (R(15) - R(1))
            a(2, 12) = a(2, 11) * cap(14) / (R(15) - R(2))
            a(3, 12) = a(3, 11) * cap(14) / (R(15) - R(3))
            a(4, 12) = a(4, 11) * cap(14) / (R(15) - R(4))
            a(5, 12) = a(5, 11) * cap(14) / (R(15) - R(7))
            a(6, 12) = a(6, 11) * cap(14) / (R(15) - R(8))
            a(7, 12) = a(7, 11) * cap(14) / (R(15) - R(10))
            a(8, 12) = a(8, 11) * cap(14) / (R(15) - R(11))
            a(9, 12) = a(9, 11) * cap(14) / (R(15) - R(12))
            a(10, 12) = a(10, 11) * cap(14) / (R(15) - R(13))
            a(11, 12) = a(11, 11) * cap(14) / (R(15) - R(14))
            a(12, 12) = ybeg(15)
            For k = 1 To 11
                a(12, 12) = a(12, 12) - a(k, 12)
            Next k
            ' ---------------------------------------------------------------
            a(1, 13) = a(1, 12) * Ac_lambda(15) / (R(18) - R(1))
            a(2, 13) = a(2, 12) * Ac_lambda(15) / (R(18) - R(2))
            a(3, 13) = a(3, 12) * Ac_lambda(15) / (R(18) - R(3))
            a(4, 13) = a(4, 12) * Ac_lambda(15) / (R(18) - R(4))
            a(5, 13) = a(5, 12) * Ac_lambda(15) / (R(18) - R(7))
            a(6, 13) = a(6, 12) * Ac_lambda(15) / (R(18) - R(8))
            a(7, 13) = a(7, 12) * Ac_lambda(15) / (R(18) - R(10))
            a(8, 13) = a(8, 12) * Ac_lambda(15) / (R(18) - R(11))
            a(9, 13) = a(9, 12) * Ac_lambda(15) / (R(18) - R(12))
            a(10, 13) = a(10, 12) * Ac_lambda(15) / (R(18) - R(13))
            a(11, 13) = a(11, 12) * Ac_lambda(15) / (R(18) - R(14))
            a(12, 13) = a(12, 12) * Ac_lambda(15) / (R(18) - R(15))
            a(13, 13) = ybeg(18)
            For k = 1 To 12
                a(13, 13) = a(13, 13) - a(k, 13)
            Next k
            ' ---------------------------------------------------------------
            a(1, 14) = a(1, 13) * cap(18) / (R(19) - R(1))
            a(2, 14) = a(2, 13) * cap(18) / (R(19) - R(2))
            a(3, 14) = a(3, 13) * cap(18) / (R(19) - R(3))
            a(4, 14) = a(4, 13) * cap(18) / (R(19) - R(4))
            a(5, 14) = a(5, 13) * cap(18) / (R(19) - R(7))
            a(6, 14) = a(6, 13) * cap(18) / (R(19) - R(8))
            a(7, 14) = a(7, 13) * cap(18) / (R(19) - R(10))
            a(8, 14) = a(8, 13) * cap(18) / (R(19) - R(11))
            a(9, 14) = a(9, 13) * cap(18) / (R(19) - R(12))
            a(10, 14) = a(10, 13) * cap(18) / (R(19) - R(13))
            a(11, 14) = a(11, 13) * cap(18) / (R(19) - R(14))
            a(12, 14) = a(12, 13) * cap(18) / (R(19) - R(15))
            a(13, 14) = a(13, 13) * cap(18) / (R(19) - R(18))
            a(14, 14) = ybeg(19)
            For k = 1 To 13
                a(14, 14) = a(14, 14) - a(k, 14)
            Next k
            ' ---------------------------------------------------------------
            a(1, 15) = a(1, 14) * Ac_lambda(19) / (R(21) - R(1))
            a(2, 15) = a(2, 14) * Ac_lambda(19) / (R(21) - R(2))
            a(3, 15) = a(3, 14) * Ac_lambda(19) / (R(21) - R(3))
            a(4, 15) = a(4, 14) * Ac_lambda(19) / (R(21) - R(4))
            a(5, 15) = a(5, 14) * Ac_lambda(19) / (R(21) - R(7))
            a(6, 15) = a(6, 14) * Ac_lambda(19) / (R(21) - R(8))
            a(7, 15) = a(7, 14) * Ac_lambda(19) / (R(21) - R(10))
            a(8, 15) = a(8, 14) * Ac_lambda(19) / (R(21) - R(11))
            a(9, 15) = a(9, 14) * Ac_lambda(19) / (R(21) - R(12))
            a(10, 15) = a(10, 14) * Ac_lambda(19) / (R(21) - R(13))
            a(11, 15) = a(11, 14) * Ac_lambda(19) / (R(21) - R(14))
            a(12, 15) = a(12, 14) * Ac_lambda(19) / (R(21) - R(15))
            a(13, 15) = a(13, 14) * Ac_lambda(19) / (R(21) - R(18))
            a(14, 15) = a(14, 14) * Ac_lambda(19) / (R(21) - R(19))
            a(15, 15) = ybeg(21)
            For k = 1 To 14
                a(15, 15) = a(15, 15) - a(k, 15)
            Next k
            ' ---------------------------------------------------------------

            'For k = 1 To 15
            'For l = 1 To 15
            'Worksheets("function").Cells(79 + k, 10 + l) = a(k, l)
            'Next l
            'Next k



        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef ya() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            ya(1) = a(1, 1) * Math.Exp(-R(1) * t)
            ya(2) = a(1, 2) * Math.Exp(-R(1) * t) + a(2, 2) * Math.Exp(-R(2) * t)
            ya(3) = a(1, 3) * Math.Exp(-R(1) * t) + a(2, 3) * Math.Exp(-R(2) * t) + a(3, 3) * Math.Exp(-R(3) * t)
            ya(4) = a(1, 4) * Math.Exp(-R(1) * t) + a(2, 4) * Math.Exp(-R(2) * t) + a(3, 4) * Math.Exp(-R(3) * t) + a(4, 4) * Math.Exp(-R(4) * t)
            ya(7) = a(1, 5) * Math.Exp(-R(1) * t) + a(2, 5) * Math.Exp(-R(2) * t) + a(3, 5) * Math.Exp(-R(3) * t) + a(4, 5) * Math.Exp(-R(4) * t) + a(5, 5) * Math.Exp(-R(7) * t)
            ya(8) = a(1, 6) * Math.Exp(-R(1) * t) + a(2, 6) * Math.Exp(-R(2) * t) + a(3, 6) * Math.Exp(-R(3) * t) + a(4, 6) * Math.Exp(-R(4) * t) + a(5, 6) * Math.Exp(-R(7) * t) + a(6, 6) * Math.Exp(-R(8) * t)
            ya(10) = a(1, 7) * Math.Exp(-R(1) * t) + a(2, 7) * Math.Exp(-R(2) * t) + a(3, 7) * Math.Exp(-R(3) * t) + a(4, 7) * Math.Exp(-R(4) * t) + a(5, 7) * Math.Exp(-R(7) * t) + a(6, 7) * Math.Exp(-R(8) * t) + a(7, 7) * Math.Exp(-R(10) * t)
            ya(11) = a(1, 8) * Math.Exp(-R(1) * t) + a(2, 8) * Math.Exp(-R(2) * t) + a(3, 8) * Math.Exp(-R(3) * t) + a(4, 8) * Math.Exp(-R(4) * t) + a(5, 8) * Math.Exp(-R(7) * t) + a(6, 8) * Math.Exp(-R(8) * t) + a(7, 8) * Math.Exp(-R(10) * t) + a(8, 8) * Math.Exp(-R(11) * t)
            ya(12) = a(1, 9) * Math.Exp(-R(1) * t) + a(2, 9) * Math.Exp(-R(2) * t) + a(3, 9) * Math.Exp(-R(3) * t) + a(4, 9) * Math.Exp(-R(4) * t) + a(5, 9) * Math.Exp(-R(7) * t) + a(6, 9) * Math.Exp(-R(8) * t) + a(7, 9) * Math.Exp(-R(10) * t) + a(8, 9) * Math.Exp(-R(11) * t) + a(9, 9) * Math.Exp(-R(12) * t)
            ya(13) = a(1, 10) * Math.Exp(-R(1) * t) + a(2, 10) * Math.Exp(-R(2) * t) + a(3, 10) * Math.Exp(-R(3) * t) + a(4, 10) * Math.Exp(-R(4) * t) + a(5, 10) * Math.Exp(-R(7) * t) + a(6, 10) * Math.Exp(-R(8) * t) + a(7, 10) * Math.Exp(-R(10) * t) + a(8, 10) * Math.Exp(-R(11) * t) + a(9, 10) * Math.Exp(-R(12) * t) + a(10, 10) * Math.Exp(-R(13) * t)
            ya(14) = a(1, 11) * Math.Exp(-R(1) * t) + a(2, 11) * Math.Exp(-R(2) * t) + a(3, 11) * Math.Exp(-R(3) * t) + a(4, 11) * Math.Exp(-R(4) * t) + a(5, 11) * Math.Exp(-R(7) * t) + a(6, 11) * Math.Exp(-R(8) * t) + a(7, 11) * Math.Exp(-R(10) * t) + a(8, 11) * Math.Exp(-R(11) * t) + a(9, 11) * Math.Exp(-R(12) * t) + a(10, 11) * Math.Exp(-R(13) * t) + a(11, 11) * Math.Exp(-R(14) * t)
            ya(15) = a(1, 12) * Math.Exp(-R(1) * t) + a(2, 12) * Math.Exp(-R(2) * t) + a(3, 12) * Math.Exp(-R(3) * t) + a(4, 12) * Math.Exp(-R(4) * t) + a(5, 12) * Math.Exp(-R(7) * t) + a(6, 12) * Math.Exp(-R(8) * t) + a(7, 12) * Math.Exp(-R(10) * t) + a(8, 12) * Math.Exp(-R(11) * t) + a(9, 12) * Math.Exp(-R(12) * t) + a(10, 12) * Math.Exp(-R(13) * t) + a(11, 12) * Math.Exp(-R(14) * t) + a(12, 12) * Math.Exp(-R(15) * t)
            ya(18) = a(1, 13) * Math.Exp(-R(1) * t) + a(2, 13) * Math.Exp(-R(2) * t) + a(3, 13) * Math.Exp(-R(3) * t) + a(4, 13) * Math.Exp(-R(4) * t) + a(5, 13) * Math.Exp(-R(7) * t) + a(6, 13) * Math.Exp(-R(8) * t) + a(7, 13) * Math.Exp(-R(10) * t) + a(8, 13) * Math.Exp(-R(11) * t) + a(9, 13) * Math.Exp(-R(12) * t) + a(10, 13) * Math.Exp(-R(13) * t) + a(11, 13) * Math.Exp(-R(14) * t) + a(12, 13) * Math.Exp(-R(15) * t) + a(13, 13) * Math.Exp(-R(18) * t)
            ya(19) = a(1, 14) * Math.Exp(-R(1) * t) + a(2, 14) * Math.Exp(-R(2) * t) + a(3, 14) * Math.Exp(-R(3) * t) + a(4, 14) * Math.Exp(-R(4) * t) + a(5, 14) * Math.Exp(-R(7) * t) + a(6, 14) * Math.Exp(-R(8) * t) + a(7, 14) * Math.Exp(-R(10) * t) + a(8, 14) * Math.Exp(-R(11) * t) + a(9, 14) * Math.Exp(-R(12) * t) + a(10, 14) * Math.Exp(-R(13) * t) + a(11, 14) * Math.Exp(-R(14) * t) + a(12, 14) * Math.Exp(-R(15) * t) + a(13, 14) * Math.Exp(-R(18) * t) + a(14, 14) * Math.Exp(-R(19) * t)
            ya(21) = a(1, 15) * Math.Exp(-R(1) * t) + a(2, 15) * Math.Exp(-R(2) * t) + a(3, 15) * Math.Exp(-R(3) * t) + a(4, 15) * Math.Exp(-R(4) * t) + a(5, 15) * Math.Exp(-R(7) * t) + a(6, 15) * Math.Exp(-R(8) * t) + a(7, 15) * Math.Exp(-R(10) * t) + a(8, 15) * Math.Exp(-R(11) * t) + a(9, 15) * Math.Exp(-R(12) * t) + a(10, 15) * Math.Exp(-R(13) * t) + a(11, 15) * Math.Exp(-R(14) * t) + a(12, 15) * Math.Exp(-R(15) * t) + a(13, 15) * Math.Exp(-R(18) * t) + a(14, 15) * Math.Exp(-R(19) * t) + a(15, 15) * Math.Exp(-R(21) * t)


        End Function

        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = a(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = a

        End Function

    End Class
End Namespace
