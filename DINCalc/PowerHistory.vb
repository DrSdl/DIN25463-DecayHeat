Namespace DIN25463MOX

    Public Class PowerHistory


        Private leistung(100) As Double
        Private zeiten(100) As Double
        Private abklang As Double
        Private intervalle As Integer
        Private HMmass As Double
        Private pufiss As Double
        Private am241 As Double
        Private uranvec(3) As Double
        Private puvec(5) As Double
        Private puquality As Double
        Private modratio As Double


        Private Const u234atommass As Double = 234.0409456
        Private Const u235atommass As Double = 235.0439231
        Private Const u236atommass As Double = 236.0455619
        Private Const u237atommass As Double = 237.048724
        Private Const u238atommass As Double = 238.0507826
        Private Const u239atommass As Double = 239.0542878
        Private Const np237atommass As Double = 237.0481673
        Private Const np238atommass As Double = 238.0509405
        Private Const np239atommass As Double = 239.0529314
        Private Const pu238atommass As Double = 238.0495534
        Private Const pu239atommass As Double = 239.0521565
        Private Const pu240atommass As Double = 240.0538075
        Private Const pu241atommass As Double = 241.0568453
        Private Const pu242atommass As Double = 242.064198
        Private Const pu243atommass As Double = 243.061997
        Private Const am241atommass As Double = 241.0568229
        Private Const am242atommass As Double = 242.059543
        Private Const am243atommass As Double = 243.0613727
        Private Const am244atommass As Double = 244.0642794
        Private Const cm242atommass As Double = 242.0588293
        Private Const cm244atommass As Double = 244.0627463

        Private Const stdmass As Double = 1.660538782E-27

        Private ystart(100) As Double
        Private Nystart As Integer

        Public Sub New()
            intervalle = 0

            HMmass = 0.0#
            pufiss = 0.0#
            am241 = 0.0#
            uranvec(1) = 0.0#
            uranvec(2) = 0.0#
            uranvec(3) = 0.0#
            puvec(1) = 0.0#
            puvec(2) = 0.0#
            puvec(3) = 0.0#
            puvec(4) = 0.0#
            puvec(5) = 0.0#

            puquality = 0
            modratio = 0

        End Sub

        Public Function ReadPowerHistory(ByRef ins As Integer, ByRef zeits() As Double, ByRef leists() As Double, ByRef matref() As Double) As Boolean
            ' maximal 100 leistungsuntervalle

            Dim i As Integer


            For i = 1 To ins

                zeiten(i) = zeits(i)

                leistung(i) = leists(i)

            Next i

            intervalle = ins

            abklang = matref(1)

            HMmass = matref(6)
            pufiss = matref(7)
            am241 = matref(8)

            uranvec(1) = matref(9)
            uranvec(2) = matref(10)
            uranvec(3) = matref(11)

            puvec(1) = matref(12)
            puvec(2) = matref(13)
            puvec(3) = matref(14)
            puvec(4) = matref(15)
            puvec(5) = matref(16)

            puquality = matref(17)
            modratio = matref(18)

        End Function

        Public Function SetSingleDecay(ByVal t As Double) As Boolean
            ' maximal 100 leistungsuntervalle

            zeiten(1) = t
            leistung(1) = 0.0#
            intervalle = 1
            abklang = t
        End Function


        Public Function GetInterval(ByVal N As Integer) As Double

            GetInterval = zeiten(N)

        End Function

        Public Function GetLeistung(ByVal N As Integer) As Double

            GetLeistung = leistung(N)

        End Function

        Public Function GetN() As Integer

            GetN = intervalle

        End Function

        Public Function GetAbklang() As Double

            GetAbklang = abklang

        End Function



        Public Function SetHeavyMetalMass(ByVal x As Double) As Boolean
            HMmass = x
        End Function

        Public Function SetPufiss(ByVal x As Double) As Boolean
            pufiss = x
        End Function

        Public Function SetAn241(ByVal x As Double) As Boolean
            am241 = x
        End Function

        Public Function SetUraniumVector(ByVal x1 As Double, ByVal x2 As Double, ByVal x3 As Double) As Boolean
            uranvec(1) = x1
            uranvec(2) = x2
            uranvec(3) = x3
        End Function

        Public Function SetPlutoniumVector(ByVal x1 As Double, ByVal x2 As Double, ByVal x3 As Double, ByVal x4 As Double, ByVal x5 As Double) As Boolean
            puvec(1) = x1
            puvec(2) = x2
            puvec(3) = x3
            puvec(4) = x4
            puvec(5) = x5
        End Function

        Public Function SetPuQuality(ByVal x As Double) As Boolean
            puquality = x
        End Function

        Public Function SetFuelToModRatio(ByVal x As Double) As Boolean
            modratio = x
        End Function



        Public Function GetHeavyMetalMass() As Double
            GetHeavyMetalMass = HMmass
        End Function

        Public Function GetPufiss() As Double
            GetPufiss = pufiss
        End Function

        Public Function GetAn241() As Double
            GetAn241 = am241
        End Function

        Public Function GetUraniumVector(ByVal N As Integer) As Double
            GetUraniumVector = uranvec(N)
        End Function

        Public Function GetPlutoniumVector(ByVal N As Integer) As Double
            GetPlutoniumVector = puvec(N)
        End Function

        Public Function GetPuQuality() As Double
            GetPuQuality = puquality
        End Function

        Public Function GetFuelToModRatio() As Double
            GetFuelToModRatio = modratio
        End Function

        Public Function GetInitialConditions(ByRef y() As Double) As Boolean

            Dim i As Integer
            Dim pumasse As Double
            Dim pufissmasse As Double
            Dim umasse As Double
            Dim ammasse As Double

            Dim u234masse As Double
            Dim u235masse As Double
            Dim u238masse As Double

            Dim pu238masse As Double
            Dim pu239masse As Double
            Dim pu240masse As Double
            Dim pu241masse As Double
            Dim pu242masse As Double

            Dim am241masse As Double

            pufissmasse = HMmass * pufiss / 100.0#
            pumasse = pufissmasse / (puquality / 100.0#)


            ammasse = am241 * pumasse / 100.0#
            umasse = HMmass - pumasse - ammasse

            u234masse = umasse * uranvec(1) / 100.0#
            u235masse = umasse * uranvec(2) / 100.0#
            u238masse = umasse * uranvec(3) / 100.0#

            pu238masse = pumasse * puvec(1) / 100.0#
            pu239masse = pumasse * puvec(2) / 100.0#
            pu240masse = pumasse * puvec(3) / 100.0#
            pu241masse = pumasse * puvec(4) / 100.0#
            pu242masse = pumasse * puvec(5) / 100.0#

            am241masse = ammasse

            For i = 1 To 21
                y(i) = 0.0#
            Next i

            y(1) = u234masse / (u234atommass * stdmass)
            y(2) = u235masse / (u235atommass * stdmass)
            y(5) = u238masse / (u238atommass * stdmass)

            y(10) = pu238masse / (pu238atommass * stdmass)
            y(11) = pu239masse / (pu239atommass * stdmass)
            y(12) = pu240masse / (pu240atommass * stdmass)
            y(13) = pu241masse / (pu241atommass * stdmass)
            y(14) = pu242masse / (pu242atommass * stdmass)

            y(16) = am241masse / (am241atommass * stdmass)



        End Function


        Public Function ConvertNtoMasses(ByRef y() As Double) As Boolean
            ' results in grams

            y(1) = y(1) * (u234atommass * stdmass)
            y(2) = y(2) * (u235atommass * stdmass)
            y(3) = y(3) * (u236atommass * stdmass)
            y(4) = y(4) * (u237atommass * stdmass)
            y(5) = y(5) * (u238atommass * stdmass)
            y(6) = y(6) * (u239atommass * stdmass)
            y(7) = y(7) * (np237atommass * stdmass)
            y(8) = y(8) * (np238atommass * stdmass)
            y(9) = y(9) * (np239atommass * stdmass)
            y(10) = y(10) * (pu238atommass * stdmass)
            y(11) = y(11) * (pu239atommass * stdmass)
            y(12) = y(12) * (pu240atommass * stdmass)
            y(13) = y(13) * (pu241atommass * stdmass)
            y(14) = y(14) * (pu242atommass * stdmass)
            y(15) = y(15) * (pu243atommass * stdmass)
            y(16) = y(16) * (am241atommass * stdmass)
            y(17) = y(17) * (am242atommass * stdmass)
            y(18) = y(18) * (am243atommass * stdmass)
            y(19) = y(19) * (am244atommass * stdmass)
            y(20) = y(20) * (cm242atommass * stdmass)
            y(21) = y(21) * (cm244atommass * stdmass)

        End Function


        Public Function SetInitConditions(ByRef y() As Double, ByVal N As Integer) As Boolean

            Dim i As Integer

            For i = 1 To N
                ystart(i) = y(i)
            Next i

            Nystart = N

        End Function

        Public Function GetInitConditions(ByRef y() As Double) As Boolean

            Dim i As Integer

            For i = 1 To Nystart
                y(i) = ystart(i)
            Next i

        End Function

    End Class
End Namespace
