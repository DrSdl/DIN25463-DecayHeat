Namespace DIN25463MOX
    Public Class ActinideChain08


        Private h(21, 21) As Double


        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    h(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Achte Kette(238U -->242CM I)################
            Dim k As Integer
            Init_chain = DBNull.Value

            Ac_lambda(17) = 0.827 * Ac_lambda(17)
            h(1, 11) = h(1, 10) * Ac_lambda(17) / (R(20) - R(5))
            h(2, 11) = h(2, 10) * Ac_lambda(17) / (R(20) - R(4))
            h(3, 11) = h(3, 10) * Ac_lambda(17) / (R(20) - R(7))
            h(4, 11) = h(4, 10) * Ac_lambda(17) / (R(20) - R(8))
            h(5, 11) = h(5, 10) * Ac_lambda(17) / (R(20) - R(10))
            h(6, 11) = h(6, 10) * Ac_lambda(17) / (R(20) - R(11))
            h(7, 11) = h(7, 10) * Ac_lambda(17) / (R(20) - R(12))
            h(8, 11) = h(8, 10) * Ac_lambda(17) / (R(20) - R(13))
            h(9, 11) = h(9, 10) * Ac_lambda(17) / (R(20) - R(16))
            h(10, 11) = h(10, 10) * Ac_lambda(17) / (R(20) - R(17))
            Ac_lambda(17) = Ac_lambda(17) / 0.827
            h(11, 11) = ybeg(20) * 0
            For k = 1 To 10
                h(11, 11) = h(11, 11) - h(k, 11)
            Next k
            ' ---------------------------------------------------------------

        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yh() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            yh(20) = h(1, 11) * Math.Exp(-R(5) * t) + h(2, 11) * Math.Exp(-R(4) * t) + h(3, 11) * Math.Exp(-R(7) * t) + h(4, 11) * Math.Exp(-R(8) * t) + h(5, 11) * Math.Exp(-R(10) * t) + h(6, 11) * Math.Exp(-R(11) * t) + h(7, 11) * Math.Exp(-R(12) * t) + h(8, 11) * Math.Exp(-R(13) * t) + h(9, 11) * Math.Exp(-R(16) * t) + h(10, 11) * Math.Exp(-R(17) * t) + h(11, 11) * Math.Exp(-R(20) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = h(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = h

        End Function

    End Class
End Namespace