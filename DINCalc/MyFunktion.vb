Namespace DIN25463MOX
    Public Class MyFunktion


        Public Sub New()

        End Sub

        Public Overridable Function SetNVar(ByVal nvar As Integer) As Boolean

        End Function

        Public Overridable Function SetStart(ByRef y() As Double) As Boolean

        End Function

        Public Overridable Function GetStart(ByVal N As Integer) As Double

        End Function



        Public Overridable Function derivs(ByRef x As Double, ByRef y() As Double, ByRef dydx() As Double) As Boolean

        End Function

        Public Overridable Function jacobn(ByRef x As Double, ByRef y() As Double, ByRef dfdx() As Double, ByRef dfdy(,) As Double, ByRef N As Integer) As Boolean

        End Function

        Public Overridable Function SetSigma(ByRef f() As Double, ByRef c() As Double, ByRef n2n() As Double) As Boolean

        End Function

        Public Overridable Function SetLambda(ByRef l() As Double) As Boolean

        End Function

        Public Overridable Function SetPhi(ByRef p As Double) As Boolean

        End Function

        Public Overridable Function SetPower(ByRef p As Double) As Boolean

        End Function

        Public Overridable Function GetPhi() As Double

        End Function

        Public Overridable Function GetPower() As Double

        End Function

        Public Overridable Function SetXN(ByRef ls(,) As Double, ByRef ss(,) As Double) As Boolean

        End Function

        Public Overridable Function SetYfi(ByRef fi(,) As Double) As Boolean

        End Function

        Public Overridable Function SetNk(ByRef Nk() As Double) As Boolean

        End Function

        Public Overridable Function CalcPhi() As Boolean

        End Function


    End Class
End Namespace
