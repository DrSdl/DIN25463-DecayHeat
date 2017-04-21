Namespace DIN25463MOX
    Public Class ActinideChain12


        Private q(21, 21) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    q(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ybeg() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Ac_lambda() As Double) As DBNull
            '###############Zwölfte Kette(238U -->242CM II)################
            Init_chain = DBNull.Value
            Dim k As Integer

            Ac_lambda(17) = 0.827 * Ac_lambda(17)
            q(1, 9) = q(1, 8) * Ac_lambda(17) / (R(20) - R(5))
            q(2, 9) = q(2, 8) * Ac_lambda(17) / (R(20) - R(6))
            q(3, 9) = q(3, 8) * Ac_lambda(17) / (R(20) - R(9))
            q(4, 9) = q(4, 8) * Ac_lambda(17) / (R(20) - R(11))
            q(5, 9) = q(5, 8) * Ac_lambda(17) / (R(20) - R(12))
            q(6, 9) = q(6, 8) * Ac_lambda(17) / (R(20) - R(13))
            q(7, 9) = q(7, 8) * Ac_lambda(17) / (R(20) - R(16))
            q(8, 9) = q(8, 8) * Ac_lambda(17) / (R(20) - R(17))
            Ac_lambda(17) = Ac_lambda(17) / 0.827
            q(9, 9) = ybeg(20) * 0
            For k = 1 To 8
                q(9, 9) = q(9, 9) - q(k, 9)
            Next k
            ' ---------------------------------------------------------------
        End Function


        Public Function CalcChain(ByRef R() As Double, ByRef yq() As Double, ByVal t As Double) As DBNull
            CalcChain = DBNull.Value
            yq(20) = q(1, 9) * Math.Exp(-R(5) * t) + q(2, 9) * Math.Exp(-R(6) * t) + q(3, 9) * Math.Exp(-R(9) * t) + q(4, 9) * Math.Exp(-R(11) * t) + q(5, 9) * Math.Exp(-R(12) * t) + q(6, 9) * Math.Exp(-R(13) * t) + q(7, 9) * Math.Exp(-R(16) * t) + q(8, 9) * Math.Exp(-R(17) * t) + q(9, 9) * Math.Exp(-R(20) * t)


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = q(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = q

        End Function

    End Class
End Namespace