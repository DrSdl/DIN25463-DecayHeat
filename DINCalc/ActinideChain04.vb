Namespace DIN25463MOX
    Public Class ActinideChain04


        Private d(21, 21) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    d(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Vierte Kette(234U -->242CM)################
            Dim k As Integer
            Init_chain = DBNull.Value

            Ac_lambda(17) = 0.827 * Ac_lambda(17)
            d(1, 13) = d(1, 12) * Ac_lambda(17) / (R(20) - R(1))
            d(2, 13) = d(2, 12) * Ac_lambda(17) / (R(20) - R(2))
            d(3, 13) = d(3, 12) * Ac_lambda(17) / (R(20) - R(3))
            d(4, 13) = d(4, 12) * Ac_lambda(17) / (R(20) - R(4))
            d(5, 13) = d(5, 12) * Ac_lambda(17) / (R(20) - R(7))
            d(6, 13) = d(6, 12) * Ac_lambda(17) / (R(20) - R(8))
            d(7, 13) = d(7, 12) * Ac_lambda(17) / (R(20) - R(10))
            d(8, 13) = d(8, 12) * Ac_lambda(17) / (R(20) - R(11))
            d(9, 13) = d(9, 12) * Ac_lambda(17) / (R(20) - R(12))
            d(10, 13) = d(10, 12) * Ac_lambda(17) / (R(20) - R(13))
            d(11, 13) = d(11, 12) * Ac_lambda(17) / (R(20) - R(16))
            d(12, 13) = d(12, 12) * Ac_lambda(17) / (R(20) - R(17))
            Ac_lambda(17) = Ac_lambda(17) / 0.827
            d(13, 13) = ybeg(20)
            For k = 1 To 12
                d(13, 13) = d(13, 13) - d(k, 13)
            Next k
            ' ---------------------------------------------------------------

        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            yd(20) = d(1, 13) * Math.Exp(-R(1) * t) + d(2, 13) * Math.Exp(-R(2) * t) + d(3, 13) * Math.Exp(-R(3) * t) + d(4, 13) * Math.Exp(-R(4) * t) + d(5, 13) * Math.Exp(-R(7) * t) + d(6, 13) * Math.Exp(-R(8) * t) + d(7, 13) * Math.Exp(-R(10) * t) + d(8, 13) * Math.Exp(-R(11) * t) + d(9, 13) * Math.Exp(-R(12) * t) + d(10, 13) * Math.Exp(-R(13) * t) + d(11, 13) * Math.Exp(-R(16) * t) + d(12, 13) * Math.Exp(-R(17) * t) + d(13, 13) * Math.Exp(-R(20) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = d(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = d

        End Function

    End Class
End Namespace