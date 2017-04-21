Namespace DIN25463MOX
    Public Class ActinideChain10


        Private o(21, 21) As Double


        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    o(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Zehnte Kette(238U -->244CM V)################
            Init_chain = DBNull.Value
            Dim k As Integer

            o(1, 7) = o(1, 6) * Ac_lambda(13) / (R(16) - R(5))
            o(2, 7) = o(2, 6) * Ac_lambda(13) / (R(16) - R(6))
            o(3, 7) = o(3, 6) * Ac_lambda(13) / (R(16) - R(9))
            o(4, 7) = o(4, 6) * Ac_lambda(13) / (R(16) - R(11))
            o(5, 7) = o(5, 6) * Ac_lambda(13) / (R(16) - R(12))
            o(6, 7) = o(6, 6) * Ac_lambda(13) / (R(16) - R(13))
            o(7, 7) = ybeg(16) * 0
            For k = 1 To 6
                o(7, 7) = o(7, 7) - o(k, 7)
            Next k
            ' ---------------------------------------------------------------
            o(1, 8) = o(1, 7) * cap(16) / (R(17) - R(5))
            o(2, 8) = o(2, 7) * cap(16) / (R(17) - R(6))
            o(3, 8) = o(3, 7) * cap(16) / (R(17) - R(9))
            o(4, 8) = o(4, 7) * cap(16) / (R(17) - R(11))
            o(5, 8) = o(5, 7) * cap(16) / (R(17) - R(12))
            o(6, 8) = o(6, 7) * cap(16) / (R(17) - R(13))
            o(7, 8) = o(7, 7) * cap(16) / (R(17) - R(16))
            o(8, 8) = ybeg(17) * 0
            For k = 1 To 7
                o(8, 8) = o(8, 8) - o(k, 8)
            Next k
            ' ---------------------------------------------------------------
            o(1, 9) = o(1, 8) * cap(17) / (R(18) - R(5))
            o(2, 9) = o(2, 8) * cap(17) / (R(18) - R(6))
            o(3, 9) = o(3, 8) * cap(17) / (R(18) - R(9))
            o(4, 9) = o(4, 8) * cap(17) / (R(18) - R(11))
            o(5, 9) = o(5, 8) * cap(17) / (R(18) - R(12))
            o(6, 9) = o(6, 8) * cap(17) / (R(18) - R(13))
            o(7, 9) = o(7, 8) * cap(17) / (R(18) - R(16))
            o(8, 9) = o(8, 8) * cap(17) / (R(18) - R(17))
            o(9, 9) = ybeg(18) * 0
            For k = 1 To 8
                o(9, 9) = o(9, 9) - o(k, 9)
            Next k
            ' ---------------------------------------------------------------
            o(1, 10) = o(1, 9) * cap(18) / (R(19) - R(5))
            o(2, 10) = o(2, 9) * cap(18) / (R(19) - R(6))
            o(3, 10) = o(3, 9) * cap(18) / (R(19) - R(9))
            o(4, 10) = o(4, 9) * cap(18) / (R(19) - R(11))
            o(5, 10) = o(5, 9) * cap(18) / (R(19) - R(12))
            o(6, 10) = o(6, 9) * cap(18) / (R(19) - R(13))
            o(7, 10) = o(7, 9) * cap(18) / (R(19) - R(16))
            o(8, 10) = o(8, 9) * cap(18) / (R(19) - R(17))
            o(9, 10) = o(9, 9) * cap(18) / (R(19) - R(18))
            o(10, 10) = ybeg(19) * 0
            For k = 1 To 9
                o(10, 10) = o(10, 10) - o(k, 10)
            Next k
            ' ---------------------------------------------------------------
            o(1, 11) = o(1, 10) * Ac_lambda(19) / (R(21) - R(5))
            o(2, 11) = o(2, 10) * Ac_lambda(19) / (R(21) - R(6))
            o(3, 11) = o(3, 10) * Ac_lambda(19) / (R(21) - R(9))
            o(4, 11) = o(4, 10) * Ac_lambda(19) / (R(21) - R(11))
            o(5, 11) = o(5, 10) * Ac_lambda(19) / (R(21) - R(12))
            o(6, 11) = o(6, 10) * Ac_lambda(19) / (R(21) - R(13))
            o(7, 11) = o(7, 10) * Ac_lambda(19) / (R(21) - R(16))
            o(8, 11) = o(8, 10) * Ac_lambda(19) / (R(21) - R(17))
            o(9, 11) = o(9, 10) * Ac_lambda(19) / (R(21) - R(18))
            o(10, 11) = o(10, 10) * Ac_lambda(19) / (R(21) - R(19))
            o(11, 11) = ybeg(21) * 0
            For k = 1 To 10
                o(11, 11) = o(11, 11) - o(k, 11)
            Next k
            ' ---------------------------------------------------------------

        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yo() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value

            yo(16) = o(1, 7) * Math.Exp(-R(5) * t) + o(2, 7) * Math.Exp(-R(6) * t) + o(3, 7) * Math.Exp(-R(9) * t) + o(4, 7) * Math.Exp(-R(11) * t) + o(5, 7) * Math.Exp(-R(12) * t) + o(6, 7) * Math.Exp(-R(13) * t) + o(7, 7) * Math.Exp(-R(16) * t)
            yo(17) = o(1, 8) * Math.Exp(-R(5) * t) + o(2, 8) * Math.Exp(-R(6) * t) + o(3, 8) * Math.Exp(-R(9) * t) + o(4, 8) * Math.Exp(-R(11) * t) + o(5, 8) * Math.Exp(-R(12) * t) + o(6, 8) * Math.Exp(-R(13) * t) + o(7, 8) * Math.Exp(-R(16) * t) + o(8, 8) * Math.Exp(-R(17) * t)
            yo(18) = o(1, 9) * Math.Exp(-R(5) * t) + o(2, 9) * Math.Exp(-R(6) * t) + o(3, 9) * Math.Exp(-R(9) * t) + o(4, 9) * Math.Exp(-R(11) * t) + o(5, 9) * Math.Exp(-R(12) * t) + o(6, 9) * Math.Exp(-R(13) * t) + o(7, 9) * Math.Exp(-R(16) * t) + o(8, 9) * Math.Exp(-R(17) * t) + o(9, 9) * Math.Exp(-R(18) * t)
            yo(19) = o(1, 10) * Math.Exp(-R(5) * t) + o(2, 10) * Math.Exp(-R(6) * t) + o(3, 10) * Math.Exp(-R(9) * t) + o(4, 10) * Math.Exp(-R(11) * t) + o(5, 10) * Math.Exp(-R(12) * t) + o(6, 10) * Math.Exp(-R(13) * t) + o(7, 10) * Math.Exp(-R(16) * t) + o(8, 10) * Math.Exp(-R(17) * t) + o(9, 10) * Math.Exp(-R(18) * t) + o(10, 10) * Math.Exp(-R(19) * t)
            yo(21) = o(1, 11) * Math.Exp(-R(5) * t) + o(2, 11) * Math.Exp(-R(6) * t) + o(3, 11) * Math.Exp(-R(9) * t) + o(4, 11) * Math.Exp(-R(11) * t) + o(5, 11) * Math.Exp(-R(12) * t) + o(6, 11) * Math.Exp(-R(13) * t) + o(7, 11) * Math.Exp(-R(16) * t) + o(8, 11) * Math.Exp(-R(17) * t) + o(9, 11) * Math.Exp(-R(18) * t) + o(10, 11) * Math.Exp(-R(19) * t) + o(11, 11) * Math.Exp(-R(21) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = o(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = o

        End Function

    End Class
End Namespace