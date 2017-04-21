Namespace DIN25463MOX
    Public Class FissionChainXe


        Private XeI(7, 7) As Double
        Private XeII(3, 3) As Double
        Private gammaI(51) As Double
        Private gammaII(51) As Double



        Public Sub New()

            '' do nothing

        End Sub

        Public Function CopyMatrix(ByRef cc(,) As Double, ByVal N As Integer) As DBNull
            CopyMatrix = DBNull.Value
            Dim k, l As Integer

            For k = 1 To N
                For l = 1 To N
                    XeI(k, l) = cc(k, l)
                Next l
            Next k

        End Function


        Public Function Init_chain(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Dim k As Integer
            '############ 131XE-->136CS################
            Init_chain = DBNull.Value
            gammaI(16) = zeta(16) / R(16)
            gammaI(17) = (cap(16) * gammaI(16) + zeta(17)) / R(17)
            gammaI(18) = (cap(17) * gammaI(17) + zeta(18)) / R(18)
            gammaI(20) = (Fi_lambda(18) * gammaI(18) + zeta(20)) / R(20)
            gammaI(21) = (cap(20) * gammaI(20) + zeta(21) * 0) / R(21)
            gammaI(22) = (cap(21) * gammaI(21) + zeta(22)) / R(22)
            gammaI(23) = (cap(22) * gammaI(22) + zeta(23) * 0) / R(23)

            XeI(1, 1) = ystart(16) - gammaI(16)
            ' ---------------------------------------------------------------
            XeI(1, 2) = XeI(1, 1) * cap(16) / (R(17) - R(16))
            XeI(2, 2) = ystart(17) - XeI(1, 2) - gammaI(17)
            ' ---------------------------------------------------------------
            XeI(1, 3) = XeI(1, 2) * cap(17) / (R(18) - R(16))
            XeI(2, 3) = XeI(2, 2) * cap(17) / (R(18) - R(17))
            XeI(3, 3) = ystart(18) - XeI(1, 3) - XeI(2, 3) - gammaI(18)
            ' ---------------------------------------------------------------
            XeI(1, 4) = XeI(1, 3) * Fi_lambda(18) / (R(20) - R(16))
            XeI(2, 4) = XeI(2, 3) * Fi_lambda(18) / (R(20) - R(17))
            XeI(3, 4) = XeI(3, 3) * Fi_lambda(18) / (R(20) - R(18))
            XeI(4, 4) = ystart(20) - gammaI(20)
            For k = 1 To 3
                XeI(4, 4) = XeI(4, 4) - XeI(k, 4)
            Next k
            ' ---------------------------------------------------------------
            XeI(1, 5) = XeI(1, 4) * cap(20) / (R(21) - R(16))
            XeI(2, 5) = XeI(2, 4) * cap(20) / (R(21) - R(17))
            XeI(3, 5) = XeI(3, 4) * cap(20) / (R(21) - R(18))
            XeI(4, 5) = XeI(4, 4) * cap(20) / (R(21) - R(20))
            XeI(5, 5) = ystart(21) - gammaI(21)
            For k = 1 To 4
                XeI(5, 5) = XeI(5, 5) - XeI(k, 5)
            Next k
            ' ---------------------------------------------------------------
            XeI(1, 6) = XeI(1, 5) * cap(21) / (R(22) - R(16))
            XeI(2, 6) = XeI(2, 5) * cap(21) / (R(22) - R(17))
            XeI(3, 6) = XeI(3, 5) * cap(21) / (R(22) - R(18))
            XeI(4, 6) = XeI(4, 5) * cap(21) / (R(22) - R(20))
            XeI(5, 6) = XeI(5, 5) * cap(21) / (R(22) - R(21))
            XeI(6, 6) = ystart(22) - gammaI(22)
            For k = 1 To 5
                XeI(6, 6) = XeI(6, 6) - XeI(k, 6)
            Next k
            ' ---------------------------------------------------------------
            XeI(1, 7) = XeI(1, 6) * cap(22) / (R(23) - R(16))
            XeI(2, 7) = XeI(2, 6) * cap(22) / (R(23) - R(17))
            XeI(3, 7) = XeI(3, 6) * cap(22) / (R(23) - R(18))
            XeI(4, 7) = XeI(4, 6) * cap(22) / (R(23) - R(20))
            XeI(5, 7) = XeI(5, 6) * cap(22) / (R(23) - R(21))
            XeI(6, 7) = XeI(6, 6) * cap(22) / (R(23) - R(22))
            XeI(7, 7) = ystart(23) - gammaI(23)
            For k = 1 To 6
                XeI(7, 7) = XeI(7, 7) - XeI(k, 7)
            Next k
            ' ---------------------------------------------------------------


            '############ 135XE-->136CS################

            gammaII(19) = zeta(19) / R(19)
            ' fission source does contribute only once ! ###################
            gammaII(22) = (Fi_lambda(19) * gammaII(19) + zeta(22) * 0) / R(22)
            gammaII(23) = (cap(22) * gammaII(22) + zeta(23)) / R(23)

            XeII(1, 1) = ystart(19) - gammaII(19)
            ' ---------------------------------------------------------------
            XeII(1, 2) = XeII(1, 1) * Fi_lambda(19) / (R(22) - R(19))
            XeII(2, 2) = ystart(22) * 0 - XeII(1, 2) - gammaII(22)
            ' ---------------------------------------------------------------
            XeII(1, 3) = XeII(1, 2) * cap(22) / (R(23) - R(19))
            XeII(2, 3) = XeII(2, 2) * cap(22) / (R(23) - R(22))
            XeII(3, 3) = ystart(23) * 0 - XeII(1, 3) - XeII(2, 3) - gammaII(23)
            ' ---------------------------------------------------------------


        End Function

        Public Function Init_chainDecay(ByRef ystart() As Double, ByRef cap() As Double, ByRef R() As Double, ByRef Fi_lambda() As Double, ByRef zeta() As Double) As DBNull
            Dim k As Integer
            '############ 131XE-->136CS################
            Init_chainDecay = DBNull.Value

            gammaI(16) = 0
            gammaI(17) = 0
            gammaI(18) = 0
            gammaI(20) = 0
            gammaI(21) = 0
            gammaI(22) = 0
            gammaI(23) = 0

            XeI(1, 1) = ystart(16) - gammaI(16)
            ' ---------------------------------------------------------------
            XeI(1, 2) = 0
            XeI(2, 2) = ystart(17) - XeI(1, 2) - gammaI(17)
            ' ---------------------------------------------------------------
            XeI(1, 3) = 0
            XeI(2, 3) = 0
            XeI(3, 3) = ystart(18) - XeI(1, 3) - XeI(2, 3) - gammaI(18)
            ' ---------------------------------------------------------------
            XeI(1, 4) = 0
            XeI(2, 4) = 0
            XeI(3, 4) = XeI(3, 3) * Fi_lambda(18) / (R(20) - R(18))
            XeI(4, 4) = ystart(20) - gammaI(20)
            For k = 1 To 3
                XeI(4, 4) = XeI(4, 4) - XeI(k, 4)
            Next k
            ' ---------------------------------------------------------------
            XeI(1, 5) = 0
            XeI(2, 5) = 0
            XeI(3, 5) = 0
            XeI(4, 5) = 0
            XeI(5, 5) = ystart(21) - gammaI(21)
            For k = 1 To 4
                XeI(5, 5) = XeI(5, 5) - XeI(k, 5)
            Next k
            ' ---------------------------------------------------------------
            XeI(1, 6) = 0
            XeI(2, 6) = 0
            XeI(3, 6) = 0
            XeI(4, 6) = 0
            XeI(5, 6) = 0
            XeI(6, 6) = ystart(22) - gammaI(22)
            For k = 1 To 5
                XeI(6, 6) = XeI(6, 6) - XeI(k, 6)
            Next k
            ' ---------------------------------------------------------------
            XeI(1, 7) = 0
            XeI(2, 7) = 0
            XeI(3, 7) = 0
            XeI(4, 7) = 0
            XeI(5, 7) = 0
            XeI(6, 7) = 0
            XeI(7, 7) = ystart(23) - gammaI(23)
            For k = 1 To 6
                XeI(7, 7) = XeI(7, 7) - XeI(k, 7)
            Next k
            ' ---------------------------------------------------------------


            '############ 135XE-->136CS################

            gammaII(19) = 0
            ' fission source does contribute only once ! ###################
            gammaII(22) = (Fi_lambda(19) * gammaII(19) + zeta(22) * 0) / R(22)
            gammaII(23) = 0

            XeII(1, 1) = ystart(19) - gammaII(19)
            ' ---------------------------------------------------------------
            XeII(1, 2) = XeII(1, 1) * Fi_lambda(19) / (R(22) - R(19))
            XeII(2, 2) = ystart(22) * 0 - XeII(1, 2) - gammaII(22)
            ' ---------------------------------------------------------------
            XeII(1, 3) = 0
            XeII(2, 3) = 0
            XeII(3, 3) = ystart(23) * 0 - XeII(1, 3) - XeII(2, 3) - gammaII(23)
            ' ---------------------------------------------------------------


        End Function



        Public Function CalcChain(ByRef R() As Double, ByRef yd() As Double, ByVal t As Double)

            Dim yxeI(51), yxeII(51) As Double
            Dim k As Integer
            CalcChain = DBNull.Value

            yxeI(16) = XeI(1, 1) * Math.Exp(-R(16) * t) + gammaI(16)
            yxeI(17) = XeI(1, 2) * Math.Exp(-R(16) * t) + XeI(2, 2) * Math.Exp(-R(17) * t) + gammaI(17)
            yxeI(18) = XeI(1, 3) * Math.Exp(-R(16) * t) + XeI(2, 3) * Math.Exp(-R(17) * t) + XeI(3, 3) * Math.Exp(-R(18) * t) + gammaI(18)
            yxeI(20) = XeI(1, 4) * Math.Exp(-R(16) * t) + XeI(2, 4) * Math.Exp(-R(17) * t) + XeI(3, 4) * Math.Exp(-R(18) * t) + XeI(4, 4) * Math.Exp(-R(20) * t) + gammaI(20)
            yxeI(21) = XeI(1, 5) * Math.Exp(-R(16) * t) + XeI(2, 5) * Math.Exp(-R(17) * t) + XeI(3, 5) * Math.Exp(-R(18) * t) + XeI(4, 5) * Math.Exp(-R(20) * t) + XeI(5, 5) * Math.Exp(-R(21) * t) + gammaI(21)
            yxeI(22) = XeI(1, 6) * Math.Exp(-R(16) * t) + XeI(2, 6) * Math.Exp(-R(17) * t) + XeI(3, 6) * Math.Exp(-R(18) * t) + XeI(4, 6) * Math.Exp(-R(20) * t) + XeI(5, 6) * Math.Exp(-R(21) * t) + XeI(6, 6) * Math.Exp(-R(22) * t) + gammaI(22)
            yxeI(23) = XeI(1, 7) * Math.Exp(-R(16) * t) + XeI(2, 7) * Math.Exp(-R(17) * t) + XeI(3, 7) * Math.Exp(-R(18) * t) + XeI(4, 7) * Math.Exp(-R(20) * t) + XeI(5, 7) * Math.Exp(-R(21) * t) + XeI(6, 7) * Math.Exp(-R(22) * t) + XeI(7, 7) * Math.Exp(-R(23) * t) + gammaI(23)

            yxeII(19) = XeII(1, 1) * Math.Exp(-R(19) * t) + gammaII(19)
            yxeII(22) = XeII(1, 2) * Math.Exp(-R(19) * t) + XeII(2, 2) * Math.Exp(-R(22) * t) + gammaII(22)
            yxeII(23) = XeII(1, 3) * Math.Exp(-R(19) * t) + XeII(2, 3) * Math.Exp(-R(22) * t) + XeII(3, 3) * Math.Exp(-R(23) * t) + gammaII(23)


            For k = 1 To 51
                yd(k) = yxeI(k) + yxeII(k)
            Next k


        End Function


        Public Function GetMatrixElement(ByVal j As Integer, ByVal k As Integer) As Double

            GetMatrixElement = XeI(j, k)

        End Function

        Public Function GetMatrix() As Double(,)

            GetMatrix = XeI

        End Function



    End Class
End Namespace