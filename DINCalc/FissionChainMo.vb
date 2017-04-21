Namespace DIN25463MOX
    Public Class FissionChainMo


        Dim ymo(51) As Double
        Dim Mo(2, 2) As Double
        Private gamma(51) As Double




        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    Mo(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Init_chain = DBNull.Value


            gamma(4) = zeta(4) / R(4)
            gamma(5) = (Fi_lambda(4) * gamma(4) + zeta(5)) / R(5)

            Mo(1, 1) = ystart(4) - gamma(4)
            ' -----------------------------------------------------------
            Mo(1, 2) = Mo(1, 1) * Fi_lambda(4) / (R(5) - R(4))
            Mo(2, 2) = ystart(5) - Mo(1, 2) - gamma(5)
            ' -----------------------------------------------------------

        End Function

        Public Function Init_chainDecay(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Init_chainDecay = DBNull.Value

            gamma(4) = 0
            gamma(5) = 0

            Mo(1, 1) = ystart(4) - gamma(4)
            ' -----------------------------------------------------------
            Mo(1, 2) = Mo(1, 1) * Fi_lambda(4) / (R(5) - R(4))
            Mo(2, 2) = ystart(5) - Mo(1, 2) - gamma(5)
            ' -----------------------------------------------------------


        End Function



        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double) As DBNull

            CalcChain = DBNull.Value
            ymo(4) = Mo(1, 1) * Math.Exp(-R(4) * t) + gamma(4)
            ymo(5) = Mo(1, 2) * Math.Exp(-R(4) * t) + Mo(2, 2) * Math.Exp(-R(5) * t) + gamma(5)

            yd(4) = ymo(4)
            yd(5) = ymo(5)

        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = Mo(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = Mo

        End Function


    End Class
End Namespace