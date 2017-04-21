Namespace DIN25463MOX
    Public Class ActinideChain09


        Private m(21, 21) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    m(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Neunte Kette(238U -->244CM IV)################
            Init_chain = DBNull.Value
            Dim k As Integer

            m(1, 1) = ybeg(5)
            ' ---------------------------------------------------------------
            m(1, 2) = m(1, 1) * cap(5) / (R(6) - R(5))
            m(2, 2) = ybeg(6) - m(1, 2)
            ' ---------------------------------------------------------------
            m(1, 3) = m(1, 2) * Ac_lambda(6) / (R(9) - R(5))
            m(2, 3) = m(2, 2) * Ac_lambda(6) / (R(9) - R(6))
            m(3, 3) = ybeg(9) - m(1, 3) - m(2, 3)
            ' ---------------------------------------------------------------
            m(1, 4) = m(1, 3) * Ac_lambda(9) / (R(11) - R(5))
            m(2, 4) = m(2, 3) * Ac_lambda(9) / (R(11) - R(6))
            m(3, 4) = m(3, 3) * Ac_lambda(9) / (R(11) - R(9))
            m(4, 4) = ybeg(11) * 0
            For k = 1 To 3
                m(4, 4) = m(4, 4) - m(k, 4)
            Next k
            ' ---------------------------------------------------------------
            m(1, 5) = m(1, 4) * cap(11) / (R(12) - R(5))
            m(2, 5) = m(2, 4) * cap(11) / (R(12) - R(6))
            m(3, 5) = m(3, 4) * cap(11) / (R(12) - R(9))
            m(4, 5) = m(4, 4) * cap(11) / (R(12) - R(11))
            m(5, 5) = ybeg(12) * 0
            For k = 1 To 4
                m(5, 5) = m(5, 5) - m(k, 5)
            Next k
            ' ---------------------------------------------------------------
            m(1, 6) = m(1, 5) * cap(12) / (R(13) - R(5))
            m(2, 6) = m(2, 5) * cap(12) / (R(13) - R(6))
            m(3, 6) = m(3, 5) * cap(12) / (R(13) - R(9))
            m(4, 6) = m(4, 5) * cap(12) / (R(13) - R(11))
            m(5, 6) = m(5, 5) * cap(12) / (R(13) - R(12))
            m(6, 6) = ybeg(13) * 0
            For k = 1 To 5
                m(6, 6) = m(6, 6) - m(k, 6)
            Next k
            ' ---------------------------------------------------------------
            m(1, 7) = m(1, 6) * cap(13) / (R(14) - R(5))
            m(2, 7) = m(2, 6) * cap(13) / (R(14) - R(6))
            m(3, 7) = m(3, 6) * cap(13) / (R(14) - R(9))
            m(4, 7) = m(4, 6) * cap(13) / (R(14) - R(11))
            m(5, 7) = m(5, 6) * cap(13) / (R(14) - R(12))
            m(6, 7) = m(6, 6) * cap(13) / (R(14) - R(13))
            m(7, 7) = ybeg(14) * 0
            For k = 1 To 6
                m(7, 7) = m(7, 7) - m(k, 7)
            Next k
            ' ---------------------------------------------------------------
            m(1, 8) = m(1, 7) * cap(14) / (R(15) - R(5))
            m(2, 8) = m(2, 7) * cap(14) / (R(15) - R(6))
            m(3, 8) = m(3, 7) * cap(14) / (R(15) - R(9))
            m(4, 8) = m(4, 7) * cap(14) / (R(15) - R(11))
            m(5, 8) = m(5, 7) * cap(14) / (R(15) - R(12))
            m(6, 8) = m(6, 7) * cap(14) / (R(15) - R(13))
            m(7, 8) = m(7, 7) * cap(14) / (R(15) - R(14))
            m(8, 8) = ybeg(15) * 0
            For k = 1 To 7
                m(8, 8) = m(8, 8) - m(k, 8)
            Next k
            ' ---------------------------------------------------------------
            m(1, 9) = m(1, 8) * Ac_lambda(15) / (R(18) - R(5))
            m(2, 9) = m(2, 8) * Ac_lambda(15) / (R(18) - R(6))
            m(3, 9) = m(3, 8) * Ac_lambda(15) / (R(18) - R(9))
            m(4, 9) = m(4, 8) * Ac_lambda(15) / (R(18) - R(11))
            m(5, 9) = m(5, 8) * Ac_lambda(15) / (R(18) - R(12))
            m(6, 9) = m(6, 8) * Ac_lambda(15) / (R(18) - R(13))
            m(7, 9) = m(7, 8) * Ac_lambda(15) / (R(18) - R(14))
            m(8, 9) = m(8, 8) * Ac_lambda(15) / (R(18) - R(15))
            m(9, 9) = ybeg(18) * 0
            For k = 1 To 8
                m(9, 9) = m(9, 9) - m(k, 9)
            Next k
            ' ---------------------------------------------------------------
            m(1, 10) = m(1, 9) * cap(18) / (R(19) - R(5))
            m(2, 10) = m(2, 9) * cap(18) / (R(19) - R(6))
            m(3, 10) = m(3, 9) * cap(18) / (R(19) - R(9))
            m(4, 10) = m(4, 9) * cap(18) / (R(19) - R(11))
            m(5, 10) = m(5, 9) * cap(18) / (R(19) - R(12))
            m(6, 10) = m(6, 9) * cap(18) / (R(19) - R(13))
            m(7, 10) = m(7, 9) * cap(18) / (R(19) - R(14))
            m(8, 10) = m(8, 9) * cap(18) / (R(19) - R(15))
            m(9, 10) = m(9, 9) * cap(18) / (R(19) - R(18))
            m(10, 10) = ybeg(19) * 0
            For k = 1 To 9
                m(10, 10) = m(10, 10) - m(k, 10)
            Next k
            ' ---------------------------------------------------------------
            m(1, 11) = m(1, 10) * Ac_lambda(19) / (R(21) - R(5))
            m(2, 11) = m(2, 10) * Ac_lambda(19) / (R(21) - R(6))
            m(3, 11) = m(3, 10) * Ac_lambda(19) / (R(21) - R(9))
            m(4, 11) = m(4, 10) * Ac_lambda(19) / (R(21) - R(11))
            m(5, 11) = m(5, 10) * Ac_lambda(19) / (R(21) - R(12))
            m(6, 11) = m(6, 10) * Ac_lambda(19) / (R(21) - R(13))
            m(7, 11) = m(7, 10) * Ac_lambda(19) / (R(21) - R(14))
            m(8, 11) = m(8, 10) * Ac_lambda(19) / (R(21) - R(15))
            m(9, 11) = m(9, 10) * Ac_lambda(19) / (R(21) - R(18))
            m(10, 11) = m(10, 10) * Ac_lambda(19) / (R(21) - R(19))
            m(11, 11) = ybeg(21) * 0
            For k = 1 To 10
                m(11, 11) = m(11, 11) - m(k, 11)
            Next k


        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef ym() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            ym(6) = m(1, 2) * Math.Exp(-R(5) * t) + m(2, 2) * Math.Exp(-R(6) * t)
            ym(9) = m(1, 3) * Math.Exp(-R(5) * t) + m(2, 3) * Math.Exp(-R(6) * t) + m(3, 3) * Math.Exp(-R(9) * t)
            ym(11) = m(1, 4) * Math.Exp(-R(5) * t) + m(2, 4) * Math.Exp(-R(6) * t) + m(3, 4) * Math.Exp(-R(9) * t) + m(4, 4) * Math.Exp(-R(11) * t)
            ym(12) = m(1, 5) * Math.Exp(-R(5) * t) + m(2, 5) * Math.Exp(-R(6) * t) + m(3, 5) * Math.Exp(-R(9) * t) + m(4, 5) * Math.Exp(-R(11) * t) + m(5, 5) * Math.Exp(-R(12) * t)
            ym(13) = m(1, 6) * Math.Exp(-R(5) * t) + m(2, 6) * Math.Exp(-R(6) * t) + m(3, 6) * Math.Exp(-R(9) * t) + m(4, 6) * Math.Exp(-R(11) * t) + m(5, 6) * Math.Exp(-R(12) * t) + m(6, 6) * Math.Exp(-R(13) * t)
            ym(14) = m(1, 7) * Math.Exp(-R(5) * t) + m(2, 7) * Math.Exp(-R(6) * t) + m(3, 7) * Math.Exp(-R(9) * t) + m(4, 7) * Math.Exp(-R(11) * t) + m(5, 7) * Math.Exp(-R(12) * t) + m(6, 7) * Math.Exp(-R(13) * t) + m(7, 7) * Math.Exp(-R(14) * t)
            ym(15) = m(1, 8) * Math.Exp(-R(5) * t) + m(2, 8) * Math.Exp(-R(6) * t) + m(3, 8) * Math.Exp(-R(9) * t) + m(4, 8) * Math.Exp(-R(11) * t) + m(5, 8) * Math.Exp(-R(12) * t) + m(6, 8) * Math.Exp(-R(13) * t) + m(7, 8) * Math.Exp(-R(14) * t) + m(8, 8) * Math.Exp(-R(15) * t)
            ym(18) = m(1, 9) * Math.Exp(-R(5) * t) + m(2, 9) * Math.Exp(-R(6) * t) + m(3, 9) * Math.Exp(-R(9) * t) + m(4, 9) * Math.Exp(-R(11) * t) + m(5, 9) * Math.Exp(-R(12) * t) + m(6, 9) * Math.Exp(-R(13) * t) + m(7, 9) * Math.Exp(-R(14) * t) + m(8, 9) * Math.Exp(-R(15) * t) + m(9, 9) * Math.Exp(-R(18) * t)
            ym(19) = m(1, 10) * Math.Exp(-R(5) * t) + m(2, 10) * Math.Exp(-R(6) * t) + m(3, 10) * Math.Exp(-R(9) * t) + m(4, 10) * Math.Exp(-R(11) * t) + m(5, 10) * Math.Exp(-R(12) * t) + m(6, 10) * Math.Exp(-R(13) * t) + m(7, 10) * Math.Exp(-R(14) * t) + m(8, 10) * Math.Exp(-R(15) * t) + m(9, 10) * Math.Exp(-R(18) * t) + m(10, 10) * Math.Exp(-R(19) * t)
            ym(21) = m(1, 11) * Math.Exp(-R(5) * t) + m(2, 11) * Math.Exp(-R(6) * t) + m(3, 11) * Math.Exp(-R(9) * t) + m(4, 11) * Math.Exp(-R(11) * t) + m(5, 11) * Math.Exp(-R(12) * t) + m(6, 11) * Math.Exp(-R(13) * t) + m(7, 11) * Math.Exp(-R(14) * t) + m(8, 11) * Math.Exp(-R(15) * t) + m(9, 11) * Math.Exp(-R(18) * t) + m(10, 11) * Math.Exp(-R(19) * t) + m(11, 11) * Math.Exp(-R(21) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = m(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = m

        End Function

    End Class
End Namespace