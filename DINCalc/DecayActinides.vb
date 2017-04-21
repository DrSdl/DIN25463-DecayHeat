Namespace DIN25463MOX
    Public Class DecayActinides

        Private alpha(4, 24) As Double
        Private beta(4, 24) As Double
        Private lambda(4, 24) As Double
        Private epsilon As Double
        Private powhist As PowerHistory


        Public Sub New()

            epsilon = 0.00000000000016022

            alpha(1, 1) = 0.0#
            alpha(1, 2) = 0.8165
            alpha(1, 3) = 0.31517
            alpha(1, 4) = 0.12895
            alpha(1, 5) = 0.017314
            alpha(1, 6) = 0.03916
            alpha(1, 7) = 0.022162
            alpha(1, 8) = 0.0034983
            alpha(1, 9) = 0.001161
            alpha(1, 10) = 0.00027473
            alpha(1, 11) = 0.0001901
            alpha(1, 12) = 0.000032535
            alpha(1, 13) = 0.0000075595
            alpha(1, 14) = 0.0000025232
            alpha(1, 15) = 0.00000049948
            alpha(1, 16) = 0.00000018531
            alpha(1, 17) = 0.000000026608
            alpha(1, 18) = 0.0000000022398
            alpha(1, 19) = 0.0000000000081641
            alpha(1, 20) = 0.000000000087797
            alpha(1, 21) = 0.000000000000025131
            alpha(1, 22) = 0.00000000000000032176
            alpha(1, 23) = 4.5038E-17
            alpha(1, 24) = 7.4791E-17


            alpha(2, 1) = 1.6979
            alpha(2, 2) = -1.8576
            alpha(2, 3) = 2.3765
            alpha(2, 4) = 1.1888
            alpha(2, 5) = 0.26258
            alpha(2, 6) = 0.060201
            alpha(2, 7) = 0.014372
            alpha(2, 8) = 0.0016708
            alpha(2, 9) = 0.00084573
            alpha(2, 10) = 0.00010828
            alpha(2, 11) = 0.000072761
            alpha(2, 12) = 0.000024182
            alpha(2, 13) = 0.0000066356
            alpha(2, 14) = 0.0000010075
            alpha(2, 15) = 0.00000049894
            alpha(2, 16) = 0.00000016352
            alpha(2, 17) = 0.000000023355
            alpha(2, 18) = 0.0000000028094
            alpha(2, 19) = 0.000000000036236
            alpha(2, 20) = 0.000000000064577
            alpha(2, 21) = 0.000000000000044963
            alpha(2, 22) = 0.00000000000000036654
            alpha(2, 23) = 5.6293E-17
            alpha(2, 24) = 7.1602E-17


            alpha(3, 1) = 0.54912
            alpha(3, 2) = -0.86543
            alpha(3, 3) = 0.89528
            alpha(3, 4) = 0.25627
            alpha(3, 5) = 0.067895
            alpha(3, 6) = 0.030835
            alpha(3, 7) = 0.0089278
            alpha(3, 8) = 0.0040592
            alpha(3, 9) = 0.0015314
            alpha(3, 10) = 0.00071292
            alpha(3, 11) = 0.0001432
            alpha(3, 12) = 0.00001765
            alpha(3, 13) = 0.000007347
            alpha(3, 14) = 0.000001747
            alpha(3, 15) = 0.0000005481
            alpha(3, 16) = 0.0000001671
            alpha(3, 17) = 0.00000002112
            alpha(3, 18) = 0.000000002996
            alpha(3, 19) = 0.00000000005107
            alpha(3, 20) = 0.0000000000573
            alpha(3, 21) = 0.00000000000004138
            alpha(3, 22) = 0.000000000000001088
            alpha(3, 23) = 2.454E-17
            alpha(3, 24) = 7.557E-17

            alpha(4, 1) = 0.0#
            alpha(4, 2) = 0.69719
            alpha(4, 3) = 0.49499
            alpha(4, 4) = 0.14422
            alpha(4, 5) = 0.062519
            alpha(4, 6) = 0.029637
            alpha(4, 7) = 0.0049236
            alpha(4, 8) = 0.00070004
            alpha(4, 9) = 0.0012989
            alpha(4, 10) = -0.0002354
            alpha(4, 11) = 0.00058466
            alpha(4, 12) = 0.000065066
            alpha(4, 13) = -0.00005184
            alpha(4, 14) = 0.000056861
            alpha(4, 15) = 0.0000018962
            alpha(4, 16) = 0.00000044108
            alpha(4, 17) = 0.0000001646
            alpha(4, 18) = 0.00000000042263
            alpha(4, 19) = 0.000000016772
            alpha(4, 20) = 0.0000000004632
            alpha(4, 21) = 0.0000000038784
            alpha(4, 22) = 0.00000000010481
            alpha(4, 23) = -0.000000000001791
            alpha(4, 24) = 0.000000000052476

            beta(1, 1) = 1.0#
            beta(1, 2) = 0.080227
            beta(1, 3) = -0.013649
            beta(1, 4) = 0.023656
            beta(1, 5) = -0.014768
            beta(1, 6) = 0.011555
            beta(1, 7) = 0.00012866
            beta(1, 8) = 0.00012859
            beta(1, 9) = -0.0000079659
            beta(1, 10) = 0.000033929
            beta(1, 11) = 0.0000037938
            beta(1, 12) = 0.00000050468
            beta(1, 13) = 0.000000037017
            beta(1, 14) = 0.000000054362
            beta(1, 15) = 0.000000010741
            beta(1, 16) = 0.0000000036042
            beta(1, 17) = 0.00000000053327
            beta(1, 18) = 0.000000000044836
            beta(1, 19) = 0.00000000000016314
            beta(1, 20) = 0.0000000000017608
            beta(1, 21) = 0.00000000000000049856
            beta(1, 22) = 6.4033E-18
            beta(1, 23) = 9.1122E-19
            beta(1, 24) = 1.4982E-18

            beta(2, 1) = 0.5
            beta(2, 2) = 0.66232
            beta(2, 3) = -0.27501
            beta(2, 4) = 0.055906
            beta(2, 5) = 0.0043062
            beta(2, 6) = 0.0034671
            beta(2, 7) = 0.00044054
            beta(2, 8) = 0.000053836
            beta(2, 9) = 0.000048926
            beta(2, 10) = 0.000026355
            beta(2, 11) = 0.00000020871
            beta(2, 12) = 0.0000012033
            beta(2, 13) = 0.00000032115
            beta(2, 14) = 0.00000040651
            beta(2, 15) = 0.00000001764
            beta(2, 16) = 0.000000005777
            beta(2, 17) = 0.00000000080103
            beta(2, 18) = 0.00000000011941
            beta(2, 19) = 0.000000000003262
            beta(2, 20) = 0.0000000000032213
            beta(2, 21) = 0.000000000000002256
            beta(2, 22) = 1.8358E-17
            beta(2, 23) = 2.8107E-18
            beta(2, 24) = 3.575E-18

            beta(3, 1) = 1.1761
            beta(3, 2) = -0.11271
            beta(3, 3) = 0.049131
            beta(3, 4) = 0.012067
            beta(3, 5) = 0.0014788
            beta(3, 6) = 0.0010475
            beta(3, 7) = 0.0002214
            beta(3, 8) = 0.00007685
            beta(3, 9) = 0.000056811
            beta(3, 10) = 0.0000038582
            beta(3, 11) = 0.0000070454
            beta(3, 12) = 0.00000084819
            beta(3, 13) = 0.00000029721
            beta(3, 14) = 0.000000099509
            beta(3, 15) = 0.000000027086
            beta(3, 16) = 0.0000000083527
            beta(3, 17) = 0.0000000010569
            beta(3, 18) = 0.00000000014978
            beta(3, 19) = 0.0000000000025521
            beta(3, 20) = 0.0000000000028608
            beta(3, 21) = 0.0000000000000020722
            beta(3, 22) = 5.4206E-17
            beta(3, 23) = 1.2268E-18
            beta(3, 24) = 3.9291E-18

            beta(4, 1) = 1.0#
            beta(4, 2) = 0.065225
            beta(4, 3) = 0.033552
            beta(4, 4) = 0.0035971
            beta(4, 5) = 0.0020892
            beta(4, 6) = 0.00086955
            beta(4, 7) = 0.000075619
            beta(4, 8) = 0.00019638
            beta(4, 9) = -0.00016946
            beta(4, 10) = 0.000065484
            beta(4, 11) = -0.00000072421
            beta(4, 12) = 0.0000032533
            beta(4, 13) = -0.000002592
            beta(4, 14) = 0.0000028431
            beta(4, 15) = 0.00000009481
            beta(4, 16) = 0.000000022054
            beta(4, 17) = 0.00000000823
            beta(4, 18) = 0.000000000021131
            beta(4, 19) = 0.0000000008386
            beta(4, 20) = -0.00000000002316
            beta(4, 21) = 0.00000000019392
            beta(4, 22) = 0.0000000000052405
            beta(4, 23) = -0.00000000000008955
            beta(4, 24) = 0.0000000000026238

            lambda(1, 1) = 10.0#
            lambda(1, 2) = 0.7901
            lambda(1, 3) = 0.22114
            lambda(1, 4) = 0.10832
            lambda(1, 5) = 0.042129
            lambda(1, 6) = 0.033838
            lambda(1, 7) = 0.012196
            lambda(1, 8) = 0.0035424
            lambda(1, 9) = 0.0010045
            lambda(1, 10) = 0.00049374
            lambda(1, 11) = 0.00018778
            lambda(1, 12) = 0.000054988
            lambda(1, 13) = 0.000020958
            lambda(1, 14) = 0.00001001
            lambda(1, 15) = 0.0000025438
            lambda(1, 16) = 0.00000066361
            lambda(1, 17) = 0.0000001229
            lambda(1, 18) = 0.000000027213
            lambda(1, 19) = 0.0000000043714
            lambda(1, 20) = 0.0000000007578
            lambda(1, 21) = 0.00000000024786
            lambda(1, 22) = 0.00000000000022384
            lambda(1, 23) = 0.0000000000000246
            lambda(1, 24) = 0.000000000000015699

            lambda(2, 1) = 6.0#
            lambda(2, 2) = 1.9872
            lambda(2, 3) = 1.3112
            lambda(2, 4) = 0.36422
            lambda(2, 5) = 0.10166
            lambda(2, 6) = 0.024669
            lambda(2, 7) = 0.0071041
            lambda(2, 8) = 0.0015858
            lambda(2, 9) = 0.00061014
            lambda(2, 10) = 0.00019231
            lambda(2, 11) = 0.00016927
            lambda(2, 12) = 0.000049032
            lambda(2, 13) = 0.000017058
            lambda(2, 14) = 0.0000070465
            lambda(2, 15) = 0.000002319
            lambda(2, 16) = 0.0000006448
            lambda(2, 17) = 0.00000012649
            lambda(2, 18) = 0.000000025548
            lambda(2, 19) = 0.0000000084782
            lambda(2, 20) = 0.0000000007513
            lambda(2, 21) = 0.00000000024188
            lambda(2, 22) = 0.00000000000022739
            lambda(2, 23) = 0.000000000000090536
            lambda(2, 24) = 0.0000000000000056098


            lambda(3, 1) = 4.7905
            lambda(3, 2) = 1.9751
            lambda(3, 3) = 0.94315
            lambda(3, 4) = 0.19264
            lambda(3, 5) = 0.072747
            lambda(3, 6) = 0.023154
            lambda(3, 7) = 0.011478
            lambda(3, 8) = 0.0052372
            lambda(3, 9) = 0.0014875
            lambda(3, 10) = 0.00053342
            lambda(3, 11) = 0.000173
            lambda(3, 12) = 0.00004881
            lambda(3, 13) = 0.00002006
            lambda(3, 14) = 0.000008319
            lambda(3, 15) = 0.000002358
            lambda(3, 16) = 0.000000645
            lambda(3, 17) = 0.0000001278
            lambda(3, 18) = 0.00000002466
            lambda(3, 19) = 0.000000009378
            lambda(3, 20) = 0.000000000745
            lambda(3, 21) = 0.0000000002426
            lambda(3, 22) = 0.000000000000221
            lambda(3, 23) = 0.0000000000000264
            lambda(3, 24) = 0.0000000000000138

            lambda(4, 1) = 3.0#
            lambda(4, 2) = 1.0223
            lambda(4, 3) = 0.28135
            lambda(4, 4) = 0.1092
            lambda(4, 5) = 0.042857
            lambda(4, 6) = 0.014286
            lambda(4, 7) = 0.0051913
            lambda(4, 8) = 0.0015686
            lambda(4, 9) = 0.0010694
            lambda(4, 10) = 0.00053883
            lambda(4, 11) = 0.00036154
            lambda(4, 12) = 0.000092159
            lambda(4, 13) = 0.000034793
            lambda(4, 14) = 0.000031132
            lambda(4, 15) = 0.0000079226
            lambda(4, 16) = 0.0000022522
            lambda(4, 17) = 0.00000062943
            lambda(4, 18) = 0.00000020419
            lambda(4, 19) = 0.00000012453
            lambda(4, 20) = 0.000000041941
            lambda(4, 21) = 0.000000024791
            lambda(4, 22) = 0.000000011547
            lambda(4, 23) = 0.0000000038759
            lambda(4, 24) = 0.0000000007444


        End Sub



        Public Function CalcDecayPower(ByVal abklingzeit As Double, ByVal ph As DIN25463silverlight.DIN25463MOX.PowerHistory) As Double


            Dim i As Integer
            Dim j As Integer
            Dim k As Integer

            Dim Rik As Double
            Dim tbk As Double
            Dim tak As Double

            Dim sum As Double
            Dim alp(3) As Double
            Dim stuetze(3) As Double

            Dim depower As Double
            Dim powhist As DIN25463silverlight.DIN25463MOX.PowerHistory
            Dim dechist As DIN25463silverlight.DIN25463MOX.PowerHistory
            Dim ystart(51) As Double

            powhist = ph
            dechist = New DIN25463silverlight.DIN25463MOX.PowerHistory

            Call dechist.SetSingleDecay(abklingzeit)

            Dim neutronenfluss As New DIN25463silverlight.DIN25463MOX.NeutronFlux

            Call neutronenfluss.FindTetraeder(ph.GetPufiss, ph.GetPuQuality, ph.GetFuelToModRatio)

            ' ********* start calc decay power from fission products ********************

            Call neutronenfluss.FindPhi(ph)

            sum = 0

            For i = 1 To 4

                For k = 1 To ph.GetN

                    tbk = ph.GetInterval(k) * 24.0# * 3600.0#
                    tak = 0

                    For j = k + 1 To ph.GetN
                        tak = tak + ph.GetInterval(j) * 24.0# * 3600.0#
                    Next j

                    tak = tak + abklingzeit

                    Rik = neutronenfluss.GetRik(i, k)

                    For j = 1 To 24
                        sum = sum + epsilon * Rik * (alpha(i, j) / lambda(i, j)) * (1 - Math.Exp(-1.0# * lambda(i, j) * tbk)) * Math.Exp(-1.0# * lambda(i, j) * tak)
                    Next j

                Next k

            Next i

            depower = sum / 1000000.0#

            ' ********* stop calc decay power from fission products ********************
            'GoTo ende
            ' ********* start calc decay power from auxiliary isotopes *****************

            Dim myPhiInterpol As New DIN25463silverlight.DIN25463MOX.MyInterpolation
            Dim myNk1Interpol As New DIN25463silverlight.DIN25463MOX.MyInterpolation
            Dim myNk2Interpol As New DIN25463silverlight.DIN25463MOX.MyInterpolation
            Dim myNk3Interpol As New DIN25463silverlight.DIN25463MOX.MyInterpolation
            Dim myNk4Interpol As New DIN25463silverlight.DIN25463MOX.MyInterpolation

            Call myPhiInterpol.SetZeitSchritte(neutronenfluss.GetZeitSchritte)
            Call myNk1Interpol.SetZeitSchritte(neutronenfluss.GetZeitSchritte)
            Call myNk2Interpol.SetZeitSchritte(neutronenfluss.GetZeitSchritte)
            Call myNk3Interpol.SetZeitSchritte(neutronenfluss.GetZeitSchritte)
            Call myNk4Interpol.SetZeitSchritte(neutronenfluss.GetZeitSchritte)

            ' interpolate to t=0
            If (neutronenfluss.GetZeitSchritte > 1) Then
                sum = neutronenfluss.GetPhi(1) - neutronenfluss.GetZeit(1) * (neutronenfluss.GetPhi(2) - neutronenfluss.GetPhi(1)) / (neutronenfluss.GetZeit(2) - neutronenfluss.GetZeit(1))
                Call myPhiInterpol.SetFunk(0, sum)

                sum = neutronenfluss.GetNk(1, 1) - neutronenfluss.GetZeit(1) * (neutronenfluss.GetNk(2, 1) - neutronenfluss.GetNk(1, 1)) / (neutronenfluss.GetZeit(2) - neutronenfluss.GetZeit(1))
                Call myNk1Interpol.SetFunk(0, sum)

                sum = neutronenfluss.GetNk(1, 2) - neutronenfluss.GetZeit(1) * (neutronenfluss.GetNk(2, 2) - neutronenfluss.GetNk(1, 2)) / (neutronenfluss.GetZeit(2) - neutronenfluss.GetZeit(1))
                Call myNk2Interpol.SetFunk(0, sum)

                sum = neutronenfluss.GetNk(1, 3) - neutronenfluss.GetZeit(1) * (neutronenfluss.GetNk(2, 3) - neutronenfluss.GetNk(1, 3)) / (neutronenfluss.GetZeit(2) - neutronenfluss.GetZeit(1))
                Call myNk3Interpol.SetFunk(0, sum)

                sum = neutronenfluss.GetNk(1, 4) - neutronenfluss.GetZeit(1) * (neutronenfluss.GetNk(2, 4) - neutronenfluss.GetNk(1, 4)) / (neutronenfluss.GetZeit(2) - neutronenfluss.GetZeit(1))
                Call myNk4Interpol.SetFunk(0, sum)
            End If

            For i = 1 To neutronenfluss.GetZeitSchritte

                Call myPhiInterpol.SetZeit(i, neutronenfluss.GetZeit(i))
                Call myNk1Interpol.SetZeit(i, neutronenfluss.GetZeit(i))
                Call myNk2Interpol.SetZeit(i, neutronenfluss.GetZeit(i))
                Call myNk3Interpol.SetZeit(i, neutronenfluss.GetZeit(i))
                Call myNk4Interpol.SetZeit(i, neutronenfluss.GetZeit(i))

                Call myPhiInterpol.SetFunk(i, neutronenfluss.GetPhi(i))
                Call myNk1Interpol.SetFunk(i, neutronenfluss.GetNk(i, 1))
                Call myNk2Interpol.SetFunk(i, neutronenfluss.GetNk(i, 2))
                Call myNk3Interpol.SetFunk(i, neutronenfluss.GetNk(i, 3))
                Call myNk4Interpol.SetFunk(i, neutronenfluss.GetNk(i, 4))

            Next i

            Call neutronenfluss.SetNk1Pol(myNk1Interpol)
            Call neutronenfluss.SetNk2Pol(myNk2Interpol)
            Call neutronenfluss.SetNk3Pol(myNk3Interpol)
            Call neutronenfluss.SetNk4Pol(myNk4Interpol)
            Call neutronenfluss.SetPhiPol(myPhiInterpol)

            Call neutronenfluss.FindFissionXe(ph)
            Call neutronenfluss.FindFissionZr(ph)
            Call neutronenfluss.FindFissionRu(ph)
            Call neutronenfluss.FindFissionPd(ph)
            Call neutronenfluss.FindFissionMo(ph)
            Call neutronenfluss.FindFissionLa(ph)
            Call neutronenfluss.FindFissionCer(ph)

            ' ********* stop calc decay power from auxiliary isotopes ******************

            If abklingzeit > 0 Then

                ' start calculation of pure decay *****************************************

                Call neutronenfluss.FindPhiDecay(dechist)

                Call neutronenfluss.FindFissionXeDecay(dechist)
                Call neutronenfluss.FindFissionZrDecay(dechist)
                Call neutronenfluss.FindFissionRuDecay(dechist)
                Call neutronenfluss.FindFissionPdDecay(dechist)
                Call neutronenfluss.FindFissionMoDecay(dechist)
                Call neutronenfluss.FindFissionLaDecay(dechist)
                Call neutronenfluss.FindFissionCerDecay(dechist)

                ' stop calculation of pure decay *******************************************

            End If

            ' **** calc PR decay *******************************************************

            sum = 0

            For i = 1 To 21
                sum = sum + neutronenfluss.GetAcQn(i) * neutronenfluss.GetAclambda(i) * neutronenfluss.GetAcDecDensity(i)
            Next i

            sum = sum + neutronenfluss.GetFiQn(15) * neutronenfluss.GetFilambda(15) * neutronenfluss.GetPalladiumDecDensity(4) + neutronenfluss.GetFiQn(21) * neutronenfluss.GetFilambda(21) * neutronenfluss.GetXenonDecDensity(6) + neutronenfluss.GetFiQn(23) * neutronenfluss.GetFilambda(23) * neutronenfluss.GetXenonDecDensity(8) + neutronenfluss.GetFiQn(26) * neutronenfluss.GetFilambda(26) * neutronenfluss.GetLanthanDecDensity(3) + neutronenfluss.GetFiQn(35) * neutronenfluss.GetFilambda(35) * neutronenfluss.GetCerDecDensity(9) + neutronenfluss.GetFiQn(36) * neutronenfluss.GetFilambda(36) * neutronenfluss.GetCerDecDensity(10) + neutronenfluss.GetFiQn(49) * neutronenfluss.GetFilambda(49) * neutronenfluss.GetCerDecDensity(23) + neutronenfluss.GetFiQn(51) * neutronenfluss.GetFilambda(51) * neutronenfluss.GetCerDecDensity(25)

            sum = epsilon * sum

            depower = depower + sum / 1000000.0#

ende:

            CalcDecayPower = depower

        End Function


    End Class
End Namespace