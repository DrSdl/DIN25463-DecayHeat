Imports DIN25463silverlight.DIN25463MOX

Namespace DIN25463MOX

    Public Class DIN25463MOXIntegrator


        Public Function DoIt(ByVal intervalle As Integer, ByRef zeiten() As Double, ByRef leistung() As Double, ByRef matvec() As Double) As Double

            Dim heat As Double
            Dim phist As New DIN25463silverlight.DIN25463MOX.PowerHistory
            Dim ZerfallAktinide As New DIN25463silverlight.DIN25463MOX.DecayActinides
            Dim abklang As Double

            heat = -1.0

            abklang = matvec(1)
            phist.ReadPowerHistory(intervalle, zeiten, leistung, matvec)

            heat = ZerfallAktinide.CalcDecayPower(abklang, phist)

            DoIt = heat

        End Function

    End Class
End Namespace
