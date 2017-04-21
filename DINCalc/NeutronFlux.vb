Namespace DIN25463MOX

    Public Class NeutronFlux

        Private q(5) As Double

        Private Ac_lambda(21) As Double
        Private Ac_Qn(21) As Double
        Private Ac_Qcn(21) As Double
        Private MyTiny As Double


        Private fi_lambda(51) As Double
        Private fi_Qn(51) As Double
        Private fi_Qcn(51) As Double
        Private fi_y(4, 51) As Double

        Private Ac_XSc(21, 15) As Double
        Private Ac_XSf(21, 15) As Double
        Private Ac_XSn2n(21, 15) As Double

        Private fi_XSc(51, 15) As Double

        Private zeta_f30(4, 15) As Double
        Private zeta_f60(4, 15) As Double

        Private zeta_c30(7, 15) As Double
        Private zeta_c60(7, 15) As Double

        Private fgv(15, 3) As Double

        Private tetra(24, 3) As Integer

        Private alp(3) As Double

        Private Rik(4, 100) As Double

        Private zeit As Integer

        Private zeiten(1000) As Double

        Private phi(1000) As Double

        Private Nk(1000, 4) As Double

        Private tetraeder As Integer

        Private Nk1Pol As DIN25463silverlight.DIN25463MOX.MyInterpolation
        Private Nk2Pol As DIN25463silverlight.DIN25463MOX.MyInterpolation
        Private Nk3Pol As DIN25463silverlight.DIN25463MOX.MyInterpolation
        Private Nk4Pol As DIN25463silverlight.DIN25463MOX.MyInterpolation
        Private PhiPol As DIN25463silverlight.DIN25463MOX.MyInterpolation

        Private NXenon(8) As Double
        Private NZircon(3) As Double
        Private NRuthenium(6) As Double
        Private NPalladium(4) As Double
        Private NMolybdan(2) As Double
        Private NLanthan(3) As Double
        Private NCer(25) As Double
        Private NAct(21) As Double

        Private NXenonDecay(8) As Double
        Private NZirconDecay(3) As Double
        Private NRutheniumDecay(6) As Double
        Private NPalladiumDecay(4) As Double
        Private NMolybdanDecay(2) As Double
        Private NLanthanDecay(3) As Double
        Private NCerDecay(25) As Double
        Private NActDecay(21) As Double

        Private Const glob_EPS As Double = 0.001


        Public Function SetNk1Pol(ByVal x As DIN25463silverlight.DIN25463MOX.MyInterpolation) As Boolean
            Nk1Pol = x
        End Function

        Public Function SetNk2Pol(ByVal x As DIN25463silverlight.DIN25463MOX.MyInterpolation) As Boolean
            Nk2Pol = x
        End Function

        Public Function SetNk3Pol(ByVal x As DIN25463silverlight.DIN25463MOX.MyInterpolation) As Boolean
            Nk3Pol = x
        End Function

        Public Function SetNk4Pol(ByVal x As DIN25463silverlight.DIN25463MOX.MyInterpolation) As Boolean
            Nk4Pol = x
        End Function

        Public Function SetPhiPol(ByRef x As DIN25463silverlight.DIN25463MOX.MyInterpolation) As Boolean
            PhiPol = x
        End Function

        Private Sub InitBasis()

            Dim i, k As Integer

            MyTiny = 1.0E-20

            For i = 0 To 1000
                phi(i) = 0.0#
                Nk(i, 1) = 0.0#
                Nk(i, 2) = 0.0#
                Nk(i, 3) = 0.0#
                Nk(i, 4) = 0.0#
                zeiten(i) = 0.0#
            Next i

            For i = 1 To 4
                For k = 1 To 100
                    Rik(i, k) = 0.0#
                Next k
            Next i

            tetraeder = 0


            q(1) = 202.4
            q(2) = 209.0#
            q(3) = 211.4
            q(4) = 213.9
            q(5) = 210.0#

            tetra(1, 1) = 14
            tetra(1, 2) = 9
            tetra(1, 3) = 8

            tetra(2, 1) = 14
            tetra(2, 2) = 9
            tetra(2, 3) = 4

            tetra(3, 1) = 14
            tetra(3, 2) = 8
            tetra(3, 3) = 3

            tetra(4, 1) = 14
            tetra(4, 2) = 4
            tetra(4, 3) = 3

            tetra(5, 1) = 13
            tetra(5, 2) = 8
            tetra(5, 3) = 7

            tetra(6, 1) = 13
            tetra(6, 2) = 8
            tetra(6, 3) = 3

            tetra(7, 1) = 13
            tetra(7, 2) = 7
            tetra(7, 3) = 2

            tetra(8, 1) = 13
            tetra(8, 2) = 3
            tetra(8, 3) = 2

            tetra(9, 1) = 12
            tetra(9, 2) = 7
            tetra(9, 3) = 6

            tetra(10, 1) = 12
            tetra(10, 2) = 7
            tetra(10, 3) = 2

            tetra(11, 1) = 12
            tetra(11, 2) = 6
            tetra(11, 3) = 1

            tetra(12, 1) = 12
            tetra(12, 2) = 2
            tetra(12, 3) = 1

            tetra(13, 1) = 11
            tetra(13, 2) = 9
            tetra(13, 3) = 6

            tetra(14, 1) = 11
            tetra(14, 2) = 9
            tetra(14, 3) = 4

            tetra(15, 1) = 11
            tetra(15, 2) = 6
            tetra(15, 3) = 1

            tetra(16, 1) = 11
            tetra(16, 2) = 4
            tetra(16, 3) = 1

            tetra(17, 1) = 10
            tetra(17, 2) = 9
            tetra(17, 3) = 8

            tetra(18, 1) = 10
            tetra(18, 2) = 9
            tetra(18, 3) = 6

            tetra(19, 1) = 10
            tetra(19, 2) = 8
            tetra(19, 3) = 7

            tetra(20, 1) = 10
            tetra(20, 2) = 7
            tetra(20, 3) = 6

            tetra(21, 1) = 5
            tetra(21, 2) = 4
            tetra(21, 3) = 3

            tetra(22, 1) = 5
            tetra(22, 2) = 4
            tetra(22, 3) = 1

            tetra(23, 1) = 5
            tetra(23, 2) = 3
            tetra(23, 3) = 2

            tetra(24, 1) = 5
            tetra(24, 2) = 2
            tetra(24, 3) = 1

            fgv(1, 1) = 4.0#
            fgv(2, 1) = 1.8
            fgv(3, 1) = 5.3
            fgv(4, 1) = 7.5
            fgv(5, 1) = 4.65
            fgv(6, 1) = 4.0#
            fgv(7, 1) = 1.8
            fgv(8, 1) = 5.3
            fgv(9, 1) = 7.5
            fgv(10, 1) = 4.65
            fgv(11, 1) = 5.75
            fgv(12, 1) = 2.9
            fgv(13, 1) = 3.55
            fgv(14, 1) = 6.4
            fgv(15, 1) = 4.65

            fgv(1, 2) = 50
            fgv(2, 2) = 80
            fgv(3, 2) = 80
            fgv(4, 2) = 50
            fgv(5, 2) = 65
            fgv(6, 2) = 50
            fgv(7, 2) = 80
            fgv(8, 2) = 80
            fgv(9, 2) = 50
            fgv(10, 2) = 65
            fgv(11, 2) = 50
            fgv(12, 2) = 65
            fgv(13, 2) = 80
            fgv(14, 2) = 65
            fgv(15, 2) = 65

            fgv(1, 3) = 1.8
            fgv(2, 3) = 1.8
            fgv(3, 3) = 1.8
            fgv(4, 3) = 1.8
            fgv(5, 3) = 1.8
            fgv(6, 3) = 2.4
            fgv(7, 3) = 2.4
            fgv(8, 3) = 2.4
            fgv(9, 3) = 2.4
            fgv(10, 3) = 2.4
            fgv(11, 3) = 2.1
            fgv(12, 3) = 2.1
            fgv(13, 3) = 2.1
            fgv(14, 3) = 2.1
            fgv(15, 3) = 2.1

            alp(1) = 0.0#
            alp(2) = 0.0#
            alp(3) = 0.0#
        End Sub

        Private Sub InitActinides()
            Ac_lambda(1) = 0.00000000000008983
            Ac_lambda(2) = 3.121E-17
            Ac_lambda(3) = 0.0000000000000009381
            Ac_lambda(4) = 0.000001189
            Ac_lambda(5) = 4.916E-18
            Ac_lambda(6) = 0.0004909
            Ac_lambda(7) = 0.00000000000001026
            Ac_lambda(8) = 0.00000379
            Ac_lambda(9) = 0.000003406
            Ac_lambda(10) = 0.0000000002503
            Ac_lambda(11) = 0.0000000000009128
            Ac_lambda(12) = 0.00000000000336
            Ac_lambda(13) = 0.000000001525
            Ac_lambda(14) = 0.00000000000005677
            Ac_lambda(15) = 0.00003885
            Ac_lambda(16) = 0.00000000005082
            Ac_lambda(17) = 0.00001202
            Ac_lambda(18) = 0.000000000002976
            Ac_lambda(19) = 0.00001906
            Ac_lambda(20) = 0.00000004916
            Ac_lambda(21) = 0.000000001213


            Ac_Qn(1) = 4.859
            Ac_Qn(2) = 4.679
            Ac_Qn(3) = 4.57
            Ac_Qn(4) = 0.319
            Ac_Qn(5) = 4.27
            Ac_Qn(6) = 0.454
            Ac_Qn(7) = 4.957
            Ac_Qn(8) = 0.808
            Ac_Qn(9) = 0.408
            Ac_Qn(10) = 5.593
            Ac_Qn(11) = 5.244
            Ac_Qn(12) = 5.256
            Ac_Qn(13) = 0.005
            Ac_Qn(14) = 4.983
            Ac_Qn(15) = 0.195
            Ac_Qn(16) = 5.638
            Ac_Qn(17) = 0.196
            Ac_Qn(18) = 5.439
            Ac_Qn(19) = 0.884
            Ac_Qn(20) = 6.216
            Ac_Qn(21) = 5.902


            Ac_Qcn(1) = 6.1
            Ac_Qcn(2) = 6.1
            Ac_Qcn(3) = 6.1
            Ac_Qcn(4) = 6.1
            Ac_Qcn(5) = 6.1
            Ac_Qcn(6) = 6.1
            Ac_Qcn(7) = 6.1
            Ac_Qcn(8) = 6.1
            Ac_Qcn(9) = 6.1
            Ac_Qcn(10) = 6.1
            Ac_Qcn(11) = 6.1
            Ac_Qcn(12) = 6.1
            Ac_Qcn(13) = 6.1
            Ac_Qcn(14) = 6.1
            Ac_Qcn(15) = 6.1
            Ac_Qcn(16) = 6.1
            Ac_Qcn(17) = 6.1
            Ac_Qcn(18) = 6.1
            Ac_Qcn(19) = 6.1
            Ac_Qcn(20) = 6.1
            Ac_Qcn(21) = 6.1

        End Sub

        Private Sub InitFission()
            fi_lambda(1) = 0.000000125
            fi_lambda(2) = 0.000000228
            fi_lambda(3) = 0
            fi_lambda(4) = 0.00000292
            fi_lambda(5) = 0.0000000000001
            fi_lambda(6) = 0
            fi_lambda(7) = 0
            fi_lambda(8) = 0.000000204
            fi_lambda(9) = 0
            fi_lambda(10) = 0.0164
            fi_lambda(11) = 0.00000545
            fi_lambda(12) = 0
            fi_lambda(13) = 0.0000143
            fi_lambda(14) = 0
            fi_lambda(15) = 0.0000000321
            fi_lambda(16) = 0
            fi_lambda(17) = 0
            fi_lambda(18) = 0.00000153
            fi_lambda(19) = 0.0000212
            fi_lambda(20) = 0
            fi_lambda(21) = 0.0000000107
            fi_lambda(22) = 0.0000000000000096
            fi_lambda(23) = 0.000000612
            fi_lambda(24) = 0.000000627
            fi_lambda(25) = 0
            fi_lambda(26) = 0.00000479
            fi_lambda(27) = 0.00000583
            fi_lambda(28) = 0.000000591
            fi_lambda(29) = 0
            fi_lambda(30) = 0
            fi_lambda(31) = 0
            fi_lambda(32) = 0
            fi_lambda(33) = 0.000000725
            fi_lambda(34) = 0.00000000837
            fi_lambda(35) = 0.00000149
            fi_lambda(36) = 0.000000194
            fi_lambda(37) = 0.00000363
            fi_lambda(38) = 0.0000718
            fi_lambda(39) = 0
            fi_lambda(40) = 0
            fi_lambda(41) = 2.2E-24
            fi_lambda(42) = 0
            fi_lambda(43) = 0.00000000024
            fi_lambda(44) = 0
            fi_lambda(45) = 0.00000412
            fi_lambda(46) = 0
            fi_lambda(47) = 0.000516
            fi_lambda(48) = 0
            fi_lambda(49) = 0.00000000255
            fi_lambda(50) = 0.00000000443
            fi_lambda(51) = 0.000000528




            fi_Qn(1) = 0
            fi_Qn(2) = 0
            fi_Qn(3) = 0
            fi_Qn(4) = 0
            fi_Qn(5) = 0
            fi_Qn(6) = 0
            fi_Qn(7) = 0
            fi_Qn(8) = 0
            fi_Qn(9) = 0
            fi_Qn(10) = 0
            fi_Qn(11) = 0
            fi_Qn(12) = 0
            fi_Qn(13) = 0
            fi_Qn(14) = 0
            fi_Qn(15) = 2.817
            fi_Qn(16) = 0
            fi_Qn(17) = 0
            fi_Qn(18) = 0
            fi_Qn(19) = 0
            fi_Qn(20) = 0
            fi_Qn(21) = 1.717
            fi_Qn(22) = 0
            fi_Qn(23) = 2.3
            fi_Qn(24) = 0.471
            fi_Qn(25) = 0
            fi_Qn(26) = 2.828
            fi_Qn(27) = 0
            fi_Qn(28) = 0
            fi_Qn(29) = 0
            fi_Qn(30) = 0
            fi_Qn(31) = 0
            fi_Qn(32) = 0
            fi_Qn(33) = 0
            fi_Qn(34) = 0
            fi_Qn(35) = 1.299
            fi_Qn(36) = 2.139
            fi_Qn(37) = 0
            fi_Qn(38) = 0
            fi_Qn(39) = 0
            fi_Qn(40) = 0
            fi_Qn(41) = 0
            fi_Qn(42) = 0
            fi_Qn(43) = 0
            fi_Qn(44) = 0
            fi_Qn(45) = 0
            fi_Qn(46) = 0
            fi_Qn(47) = 0
            fi_Qn(48) = 0
            fi_Qn(49) = 1.509
            fi_Qn(50) = 0
            fi_Qn(51) = 1.741


            fi_Qcn(1) = 6.1
            fi_Qcn(2) = 6.1
            fi_Qcn(3) = 6.1
            fi_Qcn(4) = 6.1
            fi_Qcn(5) = 6.1
            fi_Qcn(6) = 6.1
            fi_Qcn(7) = 6.1
            fi_Qcn(8) = 6.1
            fi_Qcn(9) = 6.1
            fi_Qcn(10) = 6.1
            fi_Qcn(11) = 6.1
            fi_Qcn(12) = 6.1
            fi_Qcn(13) = 0.0#
            fi_Qcn(14) = 6.1
            fi_Qcn(15) = 6.1
            fi_Qcn(16) = 6.1
            fi_Qcn(17) = 6.1
            fi_Qcn(18) = 6.1
            fi_Qcn(19) = 6.1
            fi_Qcn(20) = 6.1
            fi_Qcn(21) = 6.1
            fi_Qcn(22) = 6.1
            fi_Qcn(23) = 6.1
            fi_Qcn(24) = 6.1
            fi_Qcn(25) = 6.1
            fi_Qcn(26) = 6.1
            fi_Qcn(27) = 6.1
            fi_Qcn(28) = 6.1
            fi_Qcn(29) = 6.1
            fi_Qcn(30) = 6.1
            fi_Qcn(31) = 6.1
            fi_Qcn(32) = 6.1
            fi_Qcn(33) = 6.1
            fi_Qcn(34) = 6.1
            fi_Qcn(35) = 6.1
            fi_Qcn(36) = 6.1
            fi_Qcn(37) = 6.1
            fi_Qcn(38) = 0.0#
            fi_Qcn(39) = 6.1
            fi_Qcn(40) = 6.1
            fi_Qcn(41) = 6.1
            fi_Qcn(42) = 6.1
            fi_Qcn(43) = 6.1
            fi_Qcn(44) = 6.1
            fi_Qcn(45) = 6.1
            fi_Qcn(46) = 6.1
            fi_Qcn(47) = 0.0#
            fi_Qcn(48) = 6.1
            fi_Qcn(49) = 6.1
            fi_Qcn(50) = 6.1
            fi_Qcn(51) = 6.1



            fi_y(1, 1) = 0.06602
            fi_y(1, 2) = 0.00000029
            fi_y(1, 3) = 0.000000000017
            fi_y(1, 4) = 0.06213
            fi_y(1, 5) = 0.0000000043
            fi_y(1, 6) = 0.05141
            fi_y(1, 7) = 0.03299
            fi_y(1, 8) = 0.03024
            fi_y(1, 9) = 0.000000000017
            fi_y(1, 10) = 0.00000000046
            fi_y(1, 11) = 0.009577
            fi_y(1, 12) = 0.00057
            fi_y(1, 13) = 0.000245
            fi_y(1, 14) = 0.0000000000000002
            fi_y(1, 15) = 0.0#
            fi_y(1, 16) = 0.02068
            fi_y(1, 17) = 0.04257
            fi_y(1, 18) = 0.06611
            fi_y(1, 19) = 0.06585
            fi_y(1, 20) = 0.0000000033
            fi_y(1, 21) = 0.0000002
            fi_y(1, 22) = 0.0000071
            fi_y(1, 23) = 0.000055
            fi_y(1, 24) = 0.06281
            fi_y(1, 25) = 0.06523
            fi_y(1, 26) = 0.000007
            fi_y(1, 27) = 0.05958
            fi_y(1, 28) = 0.0000000088
            fi_y(1, 29) = 0.0000000000002
            fi_y(1, 30) = 0.05463
            fi_y(1, 31) = 0.03944
            fi_y(1, 32) = 0.02063
            fi_y(1, 33) = 0.02267
            fi_y(1, 34) = 0.000000000064
            fi_y(1, 35) = 0.0000000007
            fi_y(1, 36) = 0.0000000017
            fi_y(1, 37) = 0.01048
            fi_y(1, 38) = 0.00000076
            fi_y(1, 39) = 0.0#
            fi_y(1, 40) = 0.00000000000006
            fi_y(1, 41) = 0.000000000005
            fi_y(1, 42) = 0.00000000026
            fi_y(1, 43) = 0.00416
            fi_y(1, 44) = 0.002586
            fi_y(1, 45) = 0.001507
            fi_y(1, 46) = 0.000728
            fi_y(1, 47) = 0.000324
            fi_y(1, 48) = 0.00000000025
            fi_y(1, 49) = 0.0000000017
            fi_y(1, 50) = 0.000000038
            fi_y(1, 51) = 0.000127


            fi_y(2, 1) = 0.05168
            fi_y(2, 2) = 0.00000001
            fi_y(2, 3) = 0.0000000000002
            fi_y(2, 4) = 0.06299
            fi_y(2, 5) = 0.000000000086
            fi_y(2, 6) = 0.06536
            fi_y(2, 7) = 0.0512
            fi_y(2, 8) = 0.06075
            fi_y(2, 9) = 0.0000000000003
            fi_y(2, 10) = 0.000000000019
            fi_y(2, 11) = 0.03717
            fi_y(2, 12) = 0.004898
            fi_y(2, 13) = 0.001136
            fi_y(2, 14) = 0.0#
            fi_y(2, 15) = 0.0#
            fi_y(2, 16) = 0.01578
            fi_y(2, 17) = 0.05059
            fi_y(2, 18) = 0.06689
            fi_y(2, 19) = 0.06697
            fi_y(2, 20) = 0.000000000015
            fi_y(2, 21) = 0.000000002
            fi_y(2, 22) = 0.0000001
            fi_y(2, 23) = 0.0000015
            fi_y(2, 24) = 0.05766
            fi_y(2, 25) = 0.05988
            fi_y(2, 26) = 0.000000087
            fi_y(2, 27) = 0.04815
            fi_y(2, 28) = 0.000000000017
            fi_y(2, 29) = 0.0#
            fi_y(2, 30) = 0.04341
            fi_y(2, 31) = 0.03985
            fi_y(2, 32) = 0.02987
            fi_y(2, 33) = 0.0267
            fi_y(2, 34) = 0.00000000000006
            fi_y(2, 35) = 0.000000000002
            fi_y(2, 36) = 0.000000000005
            fi_y(2, 37) = 0.01659
            fi_y(2, 38) = 0.000000011
            fi_y(2, 39) = 0.0#
            fi_y(2, 40) = 0.0#
            fi_y(2, 41) = 0.000000000000003
            fi_y(2, 42) = 0.0000000000004
            fi_y(2, 43) = 0.008094
            fi_y(2, 44) = 0.005498
            fi_y(2, 45) = 0.003403
            fi_y(2, 46) = 0.002367
            fi_y(2, 47) = 0.001221
            fi_y(2, 48) = 0.0000000000007
            fi_y(2, 49) = 0.000000000013
            fi_y(2, 50) = 0.00000000054
            fi_y(2, 51) = 0.000632


            fi_y(3, 1) = 0.04937
            fi_y(3, 2) = 0.0000029
            fi_y(3, 3) = 0.00000000044
            fi_y(3, 4) = 0.06202
            fi_y(3, 5) = 0.000000083
            fi_y(3, 6) = 0.06188
            fi_y(3, 7) = 0.04444
            fi_y(3, 8) = 0.06951
            fi_y(3, 9) = 0.000000001
            fi_y(3, 10) = 0.000000033
            fi_y(3, 11) = 0.05761
            fi_y(3, 12) = 0.02055
            fi_y(3, 13) = 0.007387
            fi_y(3, 14) = 0.0#
            fi_y(3, 15) = 0.0#
            fi_y(3, 16) = 0.03455
            fi_y(3, 17) = 0.05152
            fi_y(3, 18) = 0.06903
            fi_y(3, 19) = 0.07229
            fi_y(3, 20) = 0.00000015
            fi_y(3, 21) = 0.0000056
            fi_y(3, 22) = 0.000114
            fi_y(3, 23) = 0.000539
            fi_y(3, 24) = 0.05285
            fi_y(3, 25) = 0.05687
            fi_y(3, 26) = 0.00009
            fi_y(3, 27) = 0.04473
            fi_y(3, 28) = 0.00000025
            fi_y(3, 29) = 0.000000000015
            fi_y(3, 30) = 0.03753
            fi_y(3, 31) = 0.03056
            fi_y(3, 32) = 0.01649
            fi_y(3, 33) = 0.02053
            fi_y(3, 34) = 0.0000000032
            fi_y(3, 35) = 0.000000027
            fi_y(3, 36) = 0.000000064
            fi_y(3, 37) = 0.01253
            fi_y(3, 38) = 0.000016
            fi_y(3, 39) = 0.00000000000006
            fi_y(3, 40) = 0.000000000007
            fi_y(3, 41) = 0.00000000037
            fi_y(3, 42) = 0.000000015
            fi_y(3, 43) = 0.00762
            fi_y(3, 44) = 0.005858
            fi_y(3, 45) = 0.003931
            fi_y(3, 46) = 0.002791
            fi_y(3, 47) = 0.002076
            fi_y(3, 48) = 0.000000022
            fi_y(3, 49) = 0.00000015
            fi_y(3, 50) = 0.000003
            fi_y(3, 51) = 0.001072




            fi_y(4, 1) = 0.04031
            fi_y(4, 2) = 0.00000031
            fi_y(4, 3) = 0.000000000022
            fi_y(4, 4) = 0.05748
            fi_y(4, 5) = 0.0000000071
            fi_y(4, 6) = 0.06054
            fi_y(4, 7) = 0.04971
            fi_y(4, 8) = 0.07119
            fi_y(4, 9) = 0.000000000064
            fi_y(4, 10) = 0.0000000031
            fi_y(4, 11) = 0.06042
            fi_y(4, 12) = 0.03979
            fi_y(4, 13) = 0.01628
            fi_y(4, 14) = 0.0#
            fi_y(4, 15) = 0.0#
            fi_y(4, 16) = 0.02135
            fi_y(4, 17) = 0.04065
            fi_y(4, 18) = 0.06539
            fi_y(4, 19) = 0.07297
            fi_y(4, 20) = 0.0000000026
            fi_y(4, 21) = 0.00000018
            fi_y(4, 22) = 0.0000065
            fi_y(4, 23) = 0.000051
            fi_y(4, 24) = 0.0575
            fi_y(4, 25) = 0.04728
            fi_y(4, 26) = 0.0000051
            fi_y(4, 27) = 0.04374
            fi_y(4, 28) = 0.0000000049
            fi_y(4, 29) = 0.00000000000008
            fi_y(4, 30) = 0.04057
            fi_y(4, 31) = 0.03138
            fi_y(4, 32) = 0.0179
            fi_y(4, 33) = 0.02287
            fi_y(4, 34) = 0.000000000042
            fi_y(4, 35) = 0.00000000058
            fi_y(4, 36) = 0.0000000013
            fi_y(4, 37) = 0.0146
            fi_y(4, 38) = 0.00000095
            fi_y(4, 39) = 0.0#
            fi_y(4, 40) = 0.00000000000004
            fi_y(4, 41) = 0.000000000003
            fi_y(4, 42) = 0.00000000023
            fi_y(4, 43) = 0.00855
            fi_y(4, 44) = 0.008056
            fi_y(4, 45) = 0.005163
            fi_y(4, 46) = 0.004072
            fi_y(4, 47) = 0.004146
            fi_y(4, 48) = 0.00000000048
            fi_y(4, 49) = 0.0000000058
            fi_y(4, 50) = 0.00000028
            fi_y(4, 51) = 0.003295

        End Sub

        Private Sub InitAcXS()
            Ac_XSf(1, 1) = 5.343E-25
            Ac_XSf(2, 1) = 1.463E-23
            Ac_XSf(3, 1) = 3.137E-25
            Ac_XSf(4, 1) = 4.805E-25
            Ac_XSf(5, 1) = 1.12E-25
            Ac_XSf(6, 1) = 0
            Ac_XSf(7, 1) = 6.053E-25
            Ac_XSf(8, 1) = 4.3251E-23
            Ac_XSf(9, 1) = 4.266E-25
            Ac_XSf(10, 1) = 1.9167E-24
            Ac_XSf(11, 1) = 2.726E-23
            Ac_XSf(12, 1) = 6.201E-25
            Ac_XSf(13, 1) = 3.388E-23
            Ac_XSf(14, 1) = 4.814E-25
            Ac_XSf(15, 1) = 0
            Ac_XSf(16, 1) = 8.032E-25
            Ac_XSf(17, 1) = 4.2327E-23
            Ac_XSf(18, 1) = 5.495E-25
            Ac_XSf(19, 1) = 5.2112E-23
            Ac_XSf(20, 1) = 5.652E-25
            Ac_XSf(21, 1) = 1.1501E-24


            Ac_XSc(1, 1) = 1.6499E-23
            Ac_XSc(2, 1) = 5.075E-24
            Ac_XSc(3, 1) = 7.713E-24
            Ac_XSc(4, 1) = 1.3847E-23
            Ac_XSc(5, 1) = 8.156E-25
            Ac_XSc(6, 1) = 0
            Ac_XSc(7, 1) = 2.0485E-23
            Ac_XSc(8, 1) = 4.5202E-24
            Ac_XSc(9, 1) = 1.3065E-23
            Ac_XSc(10, 1) = 9.3818E-24
            Ac_XSc(11, 1) = 1.618E-23
            Ac_XSc(12, 1) = 2.875E-23
            Ac_XSc(13, 1) = 1.203E-23
            Ac_XSc(14, 1) = 9.429E-24
            Ac_XSc(15, 1) = 0
            Ac_XSc(16, 1) = 4.266E-23
            Ac_XSc(17, 1) = 4.761E-24
            Ac_XSc(18, 1) = 3.3362E-23
            Ac_XSc(19, 1) = 1.3333E-23
            Ac_XSc(20, 1) = 3.2615E-24
            Ac_XSc(21, 1) = 1.2508E-23


            Ac_XSn2n(1, 1) = 0
            Ac_XSn2n(2, 1) = 0
            Ac_XSn2n(3, 1) = 0
            Ac_XSn2n(4, 1) = 0
            Ac_XSn2n(5, 1) = 5.44E-27
            Ac_XSn2n(6, 1) = 0
            Ac_XSn2n(7, 1) = 0
            Ac_XSn2n(8, 1) = 0
            Ac_XSn2n(9, 1) = 0
            Ac_XSn2n(10, 1) = 0
            Ac_XSn2n(11, 1) = 0
            Ac_XSn2n(12, 1) = 0
            Ac_XSn2n(13, 1) = 0
            Ac_XSn2n(14, 1) = 0
            Ac_XSn2n(15, 1) = 0
            Ac_XSn2n(16, 1) = 0
            Ac_XSn2n(17, 1) = 0
            Ac_XSn2n(18, 1) = 0
            Ac_XSn2n(19, 1) = 0
            Ac_XSn2n(20, 1) = 0
            Ac_XSn2n(21, 1) = 0


            Ac_XSf(1, 2) = 5.031E-25
            Ac_XSf(2, 2) = 3.043E-23
            Ac_XSf(3, 2) = 3.047E-25
            Ac_XSf(4, 2) = 5.178E-25
            Ac_XSf(5, 2) = 1.02E-25
            Ac_XSf(6, 2) = 0
            Ac_XSf(7, 2) = 5.58E-25
            Ac_XSf(8, 2) = 1.0129E-22
            Ac_XSf(9, 2) = 3.911E-25
            Ac_XSf(10, 2) = 2.2094E-24
            Ac_XSf(11, 2) = 6.757E-23
            Ac_XSf(12, 2) = 5.841E-25
            Ac_XSf(13, 2) = 7.721E-23
            Ac_XSf(14, 2) = 4.422E-25
            Ac_XSf(15, 2) = 0
            Ac_XSf(16, 2) = 1.005E-24
            Ac_XSf(17, 2) = 1.094E-22
            Ac_XSf(18, 2) = 5.39E-25
            Ac_XSf(19, 2) = 1.1594E-22
            Ac_XSf(20, 2) = 6.701E-25
            Ac_XSf(21, 2) = 1.1241E-24


            Ac_XSc(1, 2) = 2.0505E-23
            Ac_XSc(2, 2) = 7.878E-24
            Ac_XSc(3, 2) = 8.527E-24
            Ac_XSc(4, 2) = 2.8081E-23
            Ac_XSc(5, 2) = 8.588E-25
            Ac_XSc(6, 2) = 0
            Ac_XSc(7, 2) = 2.8963E-23
            Ac_XSc(8, 2) = 1.0361E-23
            Ac_XSc(9, 2) = 1.4458E-23
            Ac_XSc(10, 2) = 2.1557E-23
            Ac_XSc(11, 2) = 3.932E-23
            Ac_XSc(12, 2) = 6.313E-23
            Ac_XSc(13, 2) = 2.833E-23
            Ac_XSc(14, 2) = 2.224E-23
            Ac_XSc(15, 2) = 0
            Ac_XSc(16, 2) = 8.021E-23
            Ac_XSc(17, 2) = 1.2221E-23
            Ac_XSc(18, 2) = 4.4037E-23
            Ac_XSc(19, 2) = 2.9848E-23
            Ac_XSc(20, 2) = 3.8713E-24
            Ac_XSc(21, 2) = 1.3659E-23


            Ac_XSn2n(1, 2) = 0
            Ac_XSn2n(2, 2) = 0
            Ac_XSn2n(3, 2) = 0
            Ac_XSn2n(4, 2) = 0
            Ac_XSn2n(5, 2) = 4.98E-27
            Ac_XSn2n(6, 2) = 0
            Ac_XSn2n(7, 2) = 0
            Ac_XSn2n(8, 2) = 0
            Ac_XSn2n(9, 2) = 0
            Ac_XSn2n(10, 2) = 0
            Ac_XSn2n(11, 2) = 0
            Ac_XSn2n(12, 2) = 0
            Ac_XSn2n(13, 2) = 0
            Ac_XSn2n(14, 2) = 0
            Ac_XSn2n(15, 2) = 0
            Ac_XSn2n(16, 2) = 0
            Ac_XSn2n(17, 2) = 0
            Ac_XSn2n(18, 2) = 0
            Ac_XSn2n(19, 2) = 0
            Ac_XSn2n(20, 2) = 0
            Ac_XSn2n(21, 2) = 0


            Ac_XSf(1, 3) = 5.319E-25
            Ac_XSf(2, 3) = 1.477E-23
            Ac_XSf(3, 3) = 3.132E-25
            Ac_XSf(4, 3) = 4.799E-25
            Ac_XSf(5, 3) = 1.11E-25
            Ac_XSf(6, 3) = 0
            Ac_XSf(7, 3) = 6.028E-25
            Ac_XSf(8, 3) = 4.4346E-23
            Ac_XSf(9, 3) = 4.248E-25
            Ac_XSf(10, 3) = 1.9173E-24
            Ac_XSf(11, 3) = 2.686E-23
            Ac_XSf(12, 3) = 6.208E-25
            Ac_XSf(13, 3) = 3.4E-23
            Ac_XSf(14, 3) = 4.798E-25
            Ac_XSf(15, 3) = 0
            Ac_XSf(16, 3) = 8.06E-25
            Ac_XSf(17, 3) = 4.3165E-23
            Ac_XSf(18, 3) = 5.593E-25
            Ac_XSf(19, 3) = 5.3553E-23
            Ac_XSf(20, 3) = 5.643E-25
            Ac_XSf(21, 3) = 1.1466E-24


            Ac_XSc(1, 3) = 1.6672E-23
            Ac_XSc(2, 3) = 5.105E-24
            Ac_XSc(3, 3) = 7.787E-24
            Ac_XSc(4, 3) = 1.41E-23
            Ac_XSc(5, 3) = 8.09E-25
            Ac_XSc(6, 3) = 0
            Ac_XSc(7, 3) = 2.0983E-23
            Ac_XSc(8, 3) = 4.6394E-24
            Ac_XSc(9, 3) = 1.3202E-23
            Ac_XSc(10, 3) = 9.5713E-24
            Ac_XSc(11, 3) = 1.579E-23
            Ac_XSc(12, 3) = 3.286E-23
            Ac_XSc(13, 3) = 1.206E-23
            Ac_XSc(14, 3) = 1.958E-23
            Ac_XSc(15, 3) = 0
            Ac_XSc(16, 3) = 4.419E-23
            Ac_XSc(17, 3) = 4.8575E-24
            Ac_XSc(18, 3) = 3.7749E-23
            Ac_XSc(19, 3) = 1.3698E-23
            Ac_XSc(20, 3) = 3.2611E-24
            Ac_XSc(21, 3) = 1.2484E-23


            Ac_XSn2n(1, 3) = 0
            Ac_XSn2n(2, 3) = 0
            Ac_XSn2n(3, 3) = 0
            Ac_XSn2n(4, 3) = 0
            Ac_XSn2n(5, 3) = 5.42E-27
            Ac_XSn2n(6, 3) = 0
            Ac_XSn2n(7, 3) = 0
            Ac_XSn2n(8, 3) = 0
            Ac_XSn2n(9, 3) = 0
            Ac_XSn2n(10, 3) = 0
            Ac_XSn2n(11, 3) = 0
            Ac_XSn2n(12, 3) = 0
            Ac_XSn2n(13, 3) = 0
            Ac_XSn2n(14, 3) = 0
            Ac_XSn2n(15, 3) = 0
            Ac_XSn2n(16, 3) = 0
            Ac_XSn2n(17, 3) = 0
            Ac_XSn2n(18, 3) = 0
            Ac_XSn2n(19, 3) = 0
            Ac_XSn2n(20, 3) = 0
            Ac_XSn2n(21, 3) = 0


            Ac_XSf(1, 4) = 5.537E-25
            Ac_XSf(2, 4) = 1.017E-23
            Ac_XSf(3, 4) = 3.122E-25
            Ac_XSf(4, 4) = 4.654E-25
            Ac_XSf(5, 4) = 1.17E-25
            Ac_XSf(6, 4) = 0
            Ac_XSf(7, 4) = 6.294E-25
            Ac_XSf(8, 4) = 2.5742E-23
            Ac_XSf(9, 4) = 4.461E-25
            Ac_XSf(10, 4) = 1.8458E-24
            Ac_XSf(11, 4) = 1.539E-23
            Ac_XSf(12, 4) = 6.376E-25
            Ac_XSf(13, 4) = 2.141E-23
            Ac_XSf(14, 4) = 5.023E-25
            Ac_XSf(15, 4) = 0
            Ac_XSf(16, 4) = 7.357E-25
            Ac_XSf(17, 4) = 2.3038E-23
            Ac_XSf(18, 4) = 5.547E-25
            Ac_XSf(19, 4) = 3.2355E-23
            Ac_XSf(20, 4) = 5.466E-25
            Ac_XSf(21, 4) = 1.1439E-24


            Ac_XSc(1, 4) = 1.402E-23
            Ac_XSc(2, 4) = 4.095E-24
            Ac_XSc(3, 4) = 6.779E-24
            Ac_XSc(4, 4) = 9.4542E-24
            Ac_XSc(5, 4) = 7.983E-25
            Ac_XSc(6, 4) = 0
            Ac_XSc(7, 4) = 1.6097E-23
            Ac_XSc(8, 4) = 2.74E-24
            Ac_XSc(9, 4) = 1.1964E-23
            Ac_XSc(10, 4) = 6.0131E-24
            Ac_XSc(11, 4) = 9.107E-24
            Ac_XSc(12, 4) = 1.676E-23
            Ac_XSc(13, 4) = 7.302E-24
            Ac_XSc(14, 4) = 6.182E-24
            Ac_XSc(15, 4) = 0
            Ac_XSc(16, 4) = 2.835E-23
            Ac_XSc(17, 4) = 2.6092E-24
            Ac_XSc(18, 4) = 2.724E-23
            Ac_XSc(19, 4) = 8.2366E-24
            Ac_XSc(20, 4) = 2.8512E-24
            Ac_XSc(21, 4) = 1.1071E-23


            Ac_XSn2n(1, 4) = 0
            Ac_XSn2n(2, 4) = 0
            Ac_XSn2n(3, 4) = 0
            Ac_XSn2n(4, 4) = 0
            Ac_XSn2n(5, 4) = 5.7E-23
            Ac_XSn2n(6, 4) = 0
            Ac_XSn2n(7, 4) = 0
            Ac_XSn2n(8, 4) = 0
            Ac_XSn2n(9, 4) = 0
            Ac_XSn2n(10, 4) = 0
            Ac_XSn2n(11, 4) = 0
            Ac_XSn2n(12, 4) = 0
            Ac_XSn2n(13, 4) = 0
            Ac_XSn2n(14, 4) = 0
            Ac_XSn2n(15, 4) = 0
            Ac_XSn2n(16, 4) = 0
            Ac_XSn2n(17, 4) = 0
            Ac_XSn2n(18, 4) = 0
            Ac_XSn2n(19, 4) = 0
            Ac_XSn2n(20, 4) = 0
            Ac_XSn2n(21, 4) = 0


            Ac_XSf(1, 5) = 5.335E-25
            Ac_XSf(2, 5) = 1.459E-23
            Ac_XSf(3, 5) = 3.132E-25
            Ac_XSf(4, 5) = 4.801E-25
            Ac_XSf(5, 5) = 1.12E-25
            Ac_XSf(6, 5) = 0
            Ac_XSf(7, 5) = 6.045E-25
            Ac_XSf(8, 5) = 4.3319E-23
            Ac_XSf(9, 5) = 4.26E-25
            Ac_XSf(10, 5) = 1.9153E-24
            Ac_XSf(11, 5) = 2.679E-23
            Ac_XSf(12, 5) = 6.205E-25
            Ac_XSf(13, 5) = 3.363E-23
            Ac_XSf(14, 5) = 4.81E-25
            Ac_XSf(15, 5) = 0
            Ac_XSf(16, 5) = 8.026E-25
            Ac_XSf(17, 5) = 4.2223E-23
            Ac_XSf(18, 5) = 5.546E-25
            Ac_XSf(19, 5) = 5.2292E-23
            Ac_XSf(20, 5) = 5.643E-25
            Ac_XSf(21, 5) = 1.1484E-24


            Ac_XSc(1, 5) = 1.6513E-23
            Ac_XSc(2, 5) = 5.07E-24
            Ac_XSc(3, 5) = 7.723E-24
            Ac_XSc(4, 5) = 1.386E-23
            Ac_XSc(5, 5) = 8.11E-25
            Ac_XSc(6, 5) = 0
            Ac_XSc(7, 5) = 2.0641E-23
            Ac_XSc(8, 5) = 4.5312E-24
            Ac_XSc(9, 5) = 1.3122E-23
            Ac_XSc(10, 5) = 9.3914E-24
            Ac_XSc(11, 5) = 1.584E-23
            Ac_XSc(12, 5) = 2.984E-23
            Ac_XSc(13, 5) = 1.192E-23
            Ac_XSc(14, 5) = 1.377E-23
            Ac_XSc(15, 5) = 0
            Ac_XSc(16, 5) = 4.305E-23
            Ac_XSc(17, 5) = 4.7509E-24
            Ac_XSc(18, 5) = 3.5451E-23
            Ac_XSc(19, 5) = 1.3376E-23
            Ac_XSc(20, 5) = 3.256E-24
            Ac_XSc(21, 5) = 1.2476E-23


            Ac_XSn2n(1, 5) = 0
            Ac_XSn2n(2, 5) = 0
            Ac_XSn2n(3, 5) = 0
            Ac_XSn2n(4, 5) = 0
            Ac_XSn2n(5, 5) = 5.44E-27
            Ac_XSn2n(6, 5) = 0
            Ac_XSn2n(7, 5) = 0
            Ac_XSn2n(8, 5) = 0
            Ac_XSn2n(9, 5) = 0
            Ac_XSn2n(10, 5) = 0
            Ac_XSn2n(11, 5) = 0
            Ac_XSn2n(12, 5) = 0
            Ac_XSn2n(13, 5) = 0
            Ac_XSn2n(14, 5) = 0
            Ac_XSn2n(15, 5) = 0
            Ac_XSn2n(16, 5) = 0
            Ac_XSn2n(17, 5) = 0
            Ac_XSn2n(18, 5) = 0
            Ac_XSn2n(19, 5) = 0
            Ac_XSn2n(20, 5) = 0
            Ac_XSn2n(21, 5) = 0


            Ac_XSf(1, 6) = 5.401E-25
            Ac_XSf(2, 6) = 1.993E-23
            Ac_XSf(3, 6) = 3.252E-25
            Ac_XSf(4, 6) = 5.011E-25
            Ac_XSf(5, 6) = 1.15E-25
            Ac_XSf(6, 6) = 0
            Ac_XSf(7, 6) = 6.076E-25
            Ac_XSf(8, 6) = 6.4064E-23
            Ac_XSf(9, 6) = 4.335E-25
            Ac_XSf(10, 6) = 2.0262E-24
            Ac_XSf(11, 6) = 4.034E-23
            Ac_XSf(12, 6) = 6.266E-25
            Ac_XSf(13, 6) = 4.843E-23
            Ac_XSf(14, 6) = 4.85E-25
            Ac_XSf(15, 6) = 0
            Ac_XSf(16, 6) = 8.949E-25
            Ac_XSf(17, 6) = 6.6091E-23
            Ac_XSf(18, 6) = 5.672E-25
            Ac_XSf(19, 6) = 7.5168E-23
            Ac_XSf(20, 6) = 6.242E-25
            Ac_XSf(21, 6) = 1.1954E-24


            Ac_XSc(1, 6) = 1.8553E-23
            Ac_XSc(2, 6) = 6.065E-24
            Ac_XSc(3, 6) = 8.357E-24
            Ac_XSc(4, 6) = 1.8914E-23
            Ac_XSc(5, 6) = 8.597E-25
            Ac_XSc(6, 6) = 0
            Ac_XSc(7, 6) = 2.3927E-23
            Ac_XSc(8, 6) = 6.6209E-24
            Ac_XSc(9, 6) = 1.3665E-23
            Ac_XSc(10, 6) = 1.3637E-23
            Ac_XSc(11, 6) = 2.363E-23
            Ac_XSc(12, 6) = 3.533E-23
            Ac_XSc(13, 6) = 1.741E-23
            Ac_XSc(14, 6) = 1.048E-23
            Ac_XSc(15, 6) = 0
            Ac_XSc(16, 6) = 5.566E-23
            Ac_XSc(17, 6) = 7.406E-24
            Ac_XSc(18, 6) = 3.769E-23
            Ac_XSc(19, 6) = 1.9295E-23
            Ac_XSc(20, 6) = 3.5577E-24
            Ac_XSc(21, 6) = 1.4058E-23


            Ac_XSn2n(1, 6) = 0
            Ac_XSn2n(2, 6) = 0
            Ac_XSn2n(3, 6) = 0
            Ac_XSn2n(4, 6) = 0
            Ac_XSn2n(5, 6) = 5.56E-27
            Ac_XSn2n(6, 6) = 0
            Ac_XSn2n(7, 6) = 0
            Ac_XSn2n(8, 6) = 0
            Ac_XSn2n(9, 6) = 0
            Ac_XSn2n(10, 6) = 0
            Ac_XSn2n(11, 6) = 0
            Ac_XSn2n(12, 6) = 0
            Ac_XSn2n(13, 6) = 0
            Ac_XSn2n(14, 6) = 0
            Ac_XSn2n(15, 6) = 0
            Ac_XSn2n(16, 6) = 0
            Ac_XSn2n(17, 6) = 0
            Ac_XSn2n(18, 6) = 0
            Ac_XSn2n(19, 6) = 0
            Ac_XSn2n(20, 6) = 0
            Ac_XSn2n(21, 6) = 0



            Ac_XSf(1, 7) = 5.029E-25
            Ac_XSf(2, 7) = 4.568E-23
            Ac_XSf(3, 7) = 3.048E-25
            Ac_XSf(4, 7) = 5.581E-25
            Ac_XSf(5, 7) = 1.02E-25
            Ac_XSf(6, 7) = 0
            Ac_XSf(7, 7) = 5.44E-25
            Ac_XSf(8, 7) = 1.5558E-22
            Ac_XSf(9, 7) = 3.861E-25
            Ac_XSf(10, 7) = 2.5262E-24
            Ac_XSf(11, 7) = 1.032E-22
            Ac_XSf(12, 7) = 5.736E-25
            Ac_XSf(13, 7) = 1.177E-22
            Ac_XSf(14, 7) = 4.327E-25
            Ac_XSf(15, 7) = 0
            Ac_XSf(16, 7) = 1.1791E-24
            Ac_XSf(17, 7) = 1.7344E-22
            Ac_XSf(18, 7) = 5.406E-25
            Ac_XSf(19, 7) = 1.7499E-22
            Ac_XSf(20, 7) = 8.044E-25
            Ac_XSf(21, 7) = 1.135E-24


            Ac_XSc(1, 7) = 2.3346E-23
            Ac_XSc(2, 7) = 1.04E-23
            Ac_XSc(3, 7) = 8.684E-24
            Ac_XSc(4, 7) = 4.1296E-23
            Ac_XSc(5, 7) = 9.189E-25
            Ac_XSc(6, 7) = 0
            Ac_XSc(7, 7) = 3.435E-35
            Ac_XSc(8, 7) = 1.5799E-23
            Ac_XSc(9, 7) = 1.5068E-23
            Ac_XSc(10, 7) = 3.3529E-23
            Ac_XSc(11, 7) = 5.914E-23
            Ac_XSc(12, 7) = 7.631E-23
            Ac_XSc(13, 7) = 4.33E-23
            Ac_XSc(14, 7) = 2.86E-23
            Ac_XSc(15, 7) = 0
            Ac_XSc(16, 7) = 1.07701E-22
            Ac_XSc(17, 7) = 1.9333E-23
            Ac_XSc(18, 7) = 4.7158E-23
            Ac_XSc(19, 7) = 4.5152E-23
            Ac_XSc(20, 7) = 4.28E-24
            Ac_XSc(21, 7) = 1.456E-23


            Ac_XSn2n(1, 7) = 0
            Ac_XSn2n(2, 7) = 0
            Ac_XSn2n(3, 7) = 0
            Ac_XSn2n(4, 7) = 0
            Ac_XSn2n(5, 7) = 4.95E-27
            Ac_XSn2n(6, 7) = 0
            Ac_XSn2n(7, 7) = 0
            Ac_XSn2n(8, 7) = 0
            Ac_XSn2n(9, 7) = 0
            Ac_XSn2n(10, 7) = 0
            Ac_XSn2n(11, 7) = 0
            Ac_XSn2n(12, 7) = 0
            Ac_XSn2n(13, 7) = 0
            Ac_XSn2n(14, 7) = 0
            Ac_XSn2n(15, 7) = 0
            Ac_XSn2n(16, 7) = 0
            Ac_XSn2n(17, 7) = 0
            Ac_XSn2n(18, 7) = 0
            Ac_XSn2n(19, 7) = 0
            Ac_XSn2n(20, 7) = 0
            Ac_XSn2n(21, 7) = 0


            Ac_XSf(1, 8) = 5.389E-25
            Ac_XSf(2, 8) = 1.973E-23
            Ac_XSf(3, 8) = 3.25E-25
            Ac_XSf(4, 8) = 5.001E-25
            Ac_XSf(5, 8) = 1.15E-25
            Ac_XSf(6, 8) = 0
            Ac_XSf(7, 8) = 6.065E-25
            Ac_XSf(8, 8) = 6.3977E-23
            Ac_XSf(9, 8) = 4.324E-25
            Ac_XSf(10, 8) = 2.0219E-24
            Ac_XSf(11, 8) = 3.871E-23
            Ac_XSf(12, 8) = 6.284E-25
            Ac_XSf(13, 8) = 4.748E-23
            Ac_XSf(14, 8) = 4.843E-25
            Ac_XSf(15, 8) = 0
            Ac_XSf(16, 8) = 8.919E-25
            Ac_XSf(17, 8) = 6.5593E-23
            Ac_XSf(18, 8) = 5.77E-25
            Ac_XSf(19, 8) = 7.5291E-23
            Ac_XSf(20, 8) = 6.215E-25
            Ac_XSf(21, 8) = 1.1924E-24


            Ac_XSc(1, 8) = 1.8617E-23
            Ac_XSc(2, 8) = 6.032E-24
            Ac_XSc(3, 8) = 8.403E-24
            Ac_XSc(4, 8) = 1.8881E-23
            Ac_XSc(5, 8) = 8.522E-25
            Ac_XSc(6, 8) = 0
            Ac_XSc(7, 8) = 2.4229E-23
            Ac_XSc(8, 8) = 6.6203E-24
            Ac_XSc(9, 8) = 1.3764E-23
            Ac_XSc(10, 8) = 1.3599E-23
            Ac_XSc(11, 8) = 2.249E-23
            Ac_XSc(12, 8) = 3.927E-23
            Ac_XSc(13, 8) = 1.703E-23
            Ac_XSc(14, 8) = 2.135E-23
            Ac_XSc(15, 8) = 0
            Ac_XSc(16, 8) = 5.589E-23
            Ac_XSc(17, 8) = 7.3534E-24
            Ac_XSc(18, 8) = 4.1805E-23
            Ac_XSc(19, 8) = 1.9319E-23
            Ac_XSc(20, 8) = 3.5473E-24
            Ac_XSc(21, 8) = 1.4008E-23


            Ac_XSn2n(1, 8) = 0
            Ac_XSn2n(2, 8) = 0
            Ac_XSn2n(3, 8) = 0
            Ac_XSn2n(4, 8) = 0
            Ac_XSn2n(5, 8) = 5.55E-27
            Ac_XSn2n(6, 8) = 0
            Ac_XSn2n(7, 8) = 0
            Ac_XSn2n(8, 8) = 0
            Ac_XSn2n(9, 8) = 0
            Ac_XSn2n(10, 8) = 0
            Ac_XSn2n(11, 8) = 0
            Ac_XSn2n(12, 8) = 0
            Ac_XSn2n(13, 8) = 0
            Ac_XSn2n(14, 8) = 0
            Ac_XSn2n(15, 8) = 0
            Ac_XSn2n(16, 8) = 0
            Ac_XSn2n(17, 8) = 0
            Ac_XSn2n(18, 8) = 0
            Ac_XSn2n(19, 8) = 0
            Ac_XSn2n(20, 8) = 0
            Ac_XSn2n(21, 8) = 0


            Ac_XSf(1, 9) = 5.615E-25
            Ac_XSf(2, 9) = 1.274E-23
            Ac_XSf(3, 9) = 3.275E-25
            Ac_XSf(4, 9) = 4.818E-25
            Ac_XSf(5, 9) = 1.21E-25
            Ac_XSf(6, 9) = 0
            Ac_XSf(7, 9) = 6.367E-25
            Ac_XSf(8, 9) = 3.6131E-23
            Ac_XSf(9, 9) = 4.565E-25
            Ac_XSf(10, 9) = 1.8968E-24
            Ac_XSf(11, 9) = 2.143E-23
            Ac_XSf(12, 9) = 6.485E-25
            Ac_XSf(13, 9) = 2.846E-23
            Ac_XSf(14, 9) = 5.096E-25
            Ac_XSf(15, 9) = 0
            Ac_XSf(16, 9) = 7.966E-25
            Ac_XSf(17, 9) = 3.4292E-23
            Ac_XSf(18, 9) = 5.765E-25
            Ac_XSf(19, 9) = 4.4202E-23
            Ac_XSf(20, 9) = 5.816E-25
            Ac_XSf(21, 9) = 1.2002E-24


            Ac_XSc(1, 9) = 1.5884E-23
            Ac_XSc(2, 9) = 4.688E-24
            Ac_XSc(3, 9) = 7.574E-24
            Ac_XSc(4, 9) = 1.2014E-23
            Ac_XSc(5, 9) = 8.437E-25
            Ac_XSc(6, 9) = 0
            Ac_XSc(7, 9) = 1.8749E-23
            Ac_XSc(8, 9) = 3.8009E-24
            Ac_XSc(9, 9) = 1.2647E-23
            Ac_XSc(10, 9) = 7.9916E-24
            Ac_XSc(11, 9) = 1.256E-23
            Ac_XSc(12, 9) = 2.099E-23
            Ac_XSc(13, 9) = 9.87E-24
            Ac_XSc(14, 9) = 7.101E-24
            Ac_XSc(15, 9) = 0
            Ac_XSc(16, 9) = 3.633E-23
            Ac_XSc(17, 9) = 3.8662E-24
            Ac_XSc(18, 9) = 3.1808E-23
            Ac_XSc(19, 9) = 1.1289E-23
            Ac_XSc(20, 9) = 3.1458E-24
            Ac_XSc(21, 9) = 1.287E-23


            Ac_XSn2n(1, 9) = 0
            Ac_XSn2n(2, 9) = 0
            Ac_XSn2n(3, 9) = 0
            Ac_XSn2n(4, 9) = 0
            Ac_XSn2n(5, 9) = 5.85E-27
            Ac_XSn2n(6, 9) = 0
            Ac_XSn2n(7, 9) = 0
            Ac_XSn2n(8, 9) = 0
            Ac_XSn2n(9, 9) = 0
            Ac_XSn2n(10, 9) = 0
            Ac_XSn2n(11, 9) = 0
            Ac_XSn2n(12, 9) = 0
            Ac_XSn2n(13, 9) = 0
            Ac_XSn2n(14, 9) = 0
            Ac_XSn2n(15, 9) = 0
            Ac_XSn2n(16, 9) = 0
            Ac_XSn2n(17, 9) = 0
            Ac_XSn2n(18, 9) = 0
            Ac_XSn2n(19, 9) = 0
            Ac_XSn2n(20, 9) = 0
            Ac_XSn2n(21, 9) = 0


            Ac_XSf(1, 10) = 5.399E-25
            Ac_XSf(2, 10) = 1.968E-23
            Ac_XSf(3, 10) = 3.251E-25
            Ac_XSf(4, 10) = 5.003E-25
            Ac_XSf(5, 10) = 1.15E-25
            Ac_XSf(6, 10) = 0
            Ac_XSf(7, 10) = 6.076E-25
            Ac_XSf(8, 10) = 6.337E-23
            Ac_XSf(9, 10) = 4.335E-25
            Ac_XSf(10, 10) = 2.0216E-24
            Ac_XSf(11, 10) = 3.915E-23
            Ac_XSf(12, 10) = 6.275E-25
            Ac_XSf(13, 10) = 4.751E-23
            Ac_XSf(14, 10) = 4.852E-25
            Ac_XSf(15, 10) = 0
            Ac_XSf(16, 10) = 8.922E-25
            Ac_XSf(17, 10) = 6.5118E-23
            Ac_XSf(18, 10) = 5.726E-25
            Ac_XSf(19, 10) = 7.4516E-23
            Ac_XSf(20, 10) = 6.217E-25
            Ac_XSf(21, 10) = 1.1943E-24


            Ac_XSc(1, 10) = 1.8518E-23
            Ac_XSc(2, 10) = 6.022E-24
            Ac_XSc(3, 10) = 8.363E-24
            Ac_XSc(4, 10) = 1.874E-23
            Ac_XSc(5, 10) = 8.549E-25
            Ac_XSc(6, 10) = 0
            Ac_XSc(7, 10) = 2.3975E-23
            Ac_XSc(8, 10) = 6.5555E-24
            Ac_XSc(9, 10) = 1.3703E-23
            Ac_XSc(10, 10) = 1.3494E-23
            Ac_XSc(11, 10) = 2.285E-23
            Ac_XSc(12, 10) = 3.624E-23
            Ac_XSc(13, 10) = 1.704E-23
            Ac_XSc(14, 10) = 1.517E-23
            Ac_XSc(15, 10) = 0
            Ac_XSc(16, 10) = 5.535E-23
            Ac_XSc(17, 10) = 7.2991E-24
            Ac_XSc(18, 10) = 3.9682E-23
            Ac_XSc(19, 10) = 1.9122E-23
            Ac_XSc(20, 10) = 3.547E-24
            Ac_XSc(21, 10) = 1.4019E-23


            Ac_XSn2n(1, 10) = 0
            Ac_XSn2n(2, 10) = 0
            Ac_XSn2n(3, 10) = 0
            Ac_XSn2n(4, 10) = 0
            Ac_XSn2n(5, 10) = 5.56E-27
            Ac_XSn2n(6, 10) = 0
            Ac_XSn2n(7, 10) = 0
            Ac_XSn2n(8, 10) = 0
            Ac_XSn2n(9, 10) = 0
            Ac_XSn2n(10, 10) = 0
            Ac_XSn2n(11, 10) = 0
            Ac_XSn2n(12, 10) = 0
            Ac_XSn2n(13, 10) = 0
            Ac_XSn2n(14, 10) = 0
            Ac_XSn2n(15, 10) = 0
            Ac_XSn2n(16, 10) = 0
            Ac_XSn2n(17, 10) = 0
            Ac_XSn2n(18, 10) = 0
            Ac_XSn2n(19, 10) = 0
            Ac_XSn2n(20, 10) = 0
            Ac_XSn2n(21, 10) = 0


            Ac_XSf(1, 11) = 5.495E-25
            Ac_XSf(2, 11) = 1.343E-23
            Ac_XSf(3, 11) = 3.211E-25
            Ac_XSf(4, 11) = 4.809E-25
            Ac_XSf(5, 11) = 1.17E-25
            Ac_XSf(6, 11) = 0
            Ac_XSf(7, 11) = 6.231E-25
            Ac_XSf(8, 11) = 3.8717E-23
            Ac_XSf(9, 11) = 4.432E-25
            Ac_XSf(10, 11) = 1.9032E-24
            Ac_XSf(11, 11) = 2.365E-23
            Ac_XSf(12, 11) = 6.356E-25
            Ac_XSf(13, 11) = 3.046E-23
            Ac_XSf(14, 11) = 4.973E-25
            Ac_XSf(15, 11) = 0
            Ac_XSf(16, 11) = 7.971E-25
            Ac_XSf(17, 11) = 3.72E-23
            Ac_XSf(18, 11) = 5.644E-25
            Ac_XSf(19, 11) = 4.7082E-23
            Ac_XSf(20, 11) = 5.731E-25
            Ac_XSf(21, 11) = 1.1778E-24


            Ac_XSc(1, 11) = 1.6124E-23
            Ac_XSc(2, 11) = 4.835E-24
            Ac_XSc(3, 11) = 7.633E-24
            Ac_XSc(4, 11) = 1.2689E-23
            Ac_XSc(5, 11) = 8.29E-25
            Ac_XSc(6, 11) = 0
            Ac_XSc(7, 11) = 1.945E-23
            Ac_XSc(8, 11) = 4.0626E-24
            Ac_XSc(9, 11) = 1.2823E-23
            Ac_XSc(10, 11) = 8.4945E-24
            Ac_XSc(11, 11) = 1.396E-23
            Ac_XSc(12, 11) = 2.392E-23
            Ac_XSc(13, 11) = 1.067E-23
            Ac_XSc(14, 11) = 8.003E-24
            Ac_XSc(15, 11) = 0
            Ac_XSc(16, 11) = 3.876E-23
            Ac_XSc(17, 11) = 4.1901E-24
            Ac_XSc(18, 11) = 3.2396E-23
            Ac_XSc(19, 11) = 1.2032E-23
            Ac_XSc(20, 11) = 3.192E-24
            Ac_XSc(21, 11) = 1.2698E-23


            Ac_XSn2n(1, 11) = 0
            Ac_XSn2n(2, 11) = 0
            Ac_XSn2n(3, 11) = 0
            Ac_XSn2n(4, 11) = 0
            Ac_XSn2n(5, 11) = 5.67E-27
            Ac_XSn2n(6, 11) = 0
            Ac_XSn2n(7, 11) = 0
            Ac_XSn2n(8, 11) = 0
            Ac_XSn2n(9, 11) = 0
            Ac_XSn2n(10, 11) = 0
            Ac_XSn2n(11, 11) = 0
            Ac_XSn2n(12, 11) = 0
            Ac_XSn2n(13, 11) = 0
            Ac_XSn2n(14, 11) = 0
            Ac_XSn2n(15, 11) = 0
            Ac_XSn2n(16, 11) = 0
            Ac_XSn2n(17, 11) = 0
            Ac_XSn2n(18, 11) = 0
            Ac_XSn2n(19, 11) = 0
            Ac_XSn2n(20, 11) = 0
            Ac_XSn2n(21, 11) = 0

            Ac_XSf(1, 12) = 5.223E-25
            Ac_XSf(2, 12) = 2.443E-23
            Ac_XSf(3, 12) = 3.161E-25
            Ac_XSf(4, 12) = 5.0586E-25
            Ac_XSf(5, 12) = 1.09E-25
            Ac_XSf(6, 12) = 0
            Ac_XSf(7, 12) = 5.84E-25
            Ac_XSf(8, 12) = 8.0879E-23
            Ac_XSf(9, 12) = 4.134E-25
            Ac_XSf(10, 12) = 2.1064E-24
            Ac_XSf(11, 12) = 5.209E-23
            Ac_XSf(12, 12) = 6.066E-25
            Ac_XSf(13, 12) = 6.08E-23
            Ac_XSf(14, 12) = 4.646E-25
            Ac_XSf(15, 12) = 0
            Ac_XSf(16, 12) = 9.465E-25
            Ac_XSf(17, 12) = 8.5518E-23
            Ac_XSf(18, 12) = 5.556E-25
            Ac_XSf(19, 12) = 9.3643E-23
            Ac_XSf(20, 12) = 6.433E-25
            Ac_XSf(21, 12) = 1.1634E-24


            Ac_XSc(1, 12) = 1.9546E-23
            Ac_XSc(2, 12) = 6.859E-24
            Ac_XSc(3, 12) = 8.499E-24
            Ac_XSc(4, 12) = 2.3061E-23
            Ac_XSc(5, 12) = 8.572E-25
            Ac_XSc(6, 12) = 0
            Ac_XSc(7, 12) = 2.6429E-23
            Ac_XSc(8, 12) = 8.3124E-24
            Ac_XSc(9, 12) = 1.409E-23
            Ac_XSc(10, 12) = 1.7175E-23
            Ac_XSc(11, 12) = 3.043E-23
            Ac_XSc(12, 12) = 4.692E-23
            Ac_XSc(13, 12) = 2.211E-23
            Ac_XSc(14, 12) = 1.733E-23
            Ac_XSc(15, 12) = 0
            Ac_XSc(16, 12) = 6.688E-23
            Ac_XSc(17, 12) = 9.5649E-24
            Ac_XSc(18, 12) = 4.1434E-23
            Ac_XSc(19, 12) = 2.4077E-23
            Ac_XSc(20, 12) = 3.7147E-24
            Ac_XSc(21, 12) = 1.396E-23


            Ac_XSn2n(1, 12) = 0
            Ac_XSn2n(2, 12) = 0
            Ac_XSn2n(3, 12) = 0
            Ac_XSn2n(4, 12) = 0
            Ac_XSn2n(5, 12) = 5.28E-27
            Ac_XSn2n(6, 12) = 0
            Ac_XSn2n(7, 12) = 0
            Ac_XSn2n(8, 12) = 0
            Ac_XSn2n(9, 12) = 0
            Ac_XSn2n(10, 12) = 0
            Ac_XSn2n(11, 12) = 0
            Ac_XSn2n(12, 12) = 0
            Ac_XSn2n(13, 12) = 0
            Ac_XSn2n(14, 12) = 0
            Ac_XSn2n(15, 12) = 0
            Ac_XSn2n(16, 12) = 0
            Ac_XSn2n(17, 12) = 0
            Ac_XSn2n(18, 12) = 0
            Ac_XSn2n(19, 12) = 0
            Ac_XSn2n(20, 12) = 0
            Ac_XSn2n(21, 12) = 0


            Ac_XSf(1, 13) = 5.233E-25
            Ac_XSf(2, 13) = 2.336E-23
            Ac_XSf(3, 13) = 3.167E-25
            Ac_XSf(4, 13) = 5.058E-25
            Ac_XSf(5, 13) = 1.09E-25
            Ac_XSf(6, 13) = 0
            Ac_XSf(7, 13) = 5.861E-25
            Ac_XSf(8, 13) = 7.7178E-23
            Ac_XSf(9, 13) = 4.148E-25
            Ac_XSf(10, 13) = 2.0851E-24
            Ac_XSf(11, 13) = 4.888E-23
            Ac_XSf(12, 13) = 6.096E-25
            Ac_XSf(13, 13) = 5.768E-23
            Ac_XSf(14, 13) = 4.665E-25
            Ac_XSf(15, 13) = 0
            Ac_XSf(16, 13) = 9.318E-25
            Ac_XSf(17, 13) = 8.1031E-23
            Ac_XSf(18, 13) = 5.61E-25
            Ac_XSf(19, 13) = 8.97E-23
            Ac_XSf(20, 13) = 6.353E-25
            Ac_XSf(21, 13) = 1.1642E-24


            Ac_XSc(1, 13) = 1.9343E-23
            Ac_XSc(2, 13) = 6.674E-24
            Ac_XSc(3, 13) = 8.476E-24
            Ac_XSc(4, 13) = 2.2149E-23
            Ac_XSc(5, 13) = 8.522E-25
            Ac_XSc(6, 13) = 0
            Ac_XSc(7, 13) = 2.6101E-23
            Ac_XSc(8, 13) = 7.9444E-24
            Ac_XSc(9, 13) = 1.4061E-23
            Ac_XSc(10, 13) = 1.6372E-23
            Ac_XSc(11, 13) = 2.85E-23
            Ac_XSc(12, 13) = 4.743E-23
            Ac_XSc(13, 13) = 2.093E-23
            Ac_XSc(14, 13) = 2.182E-23
            Ac_XSc(15, 13) = 0
            Ac_XSc(16, 13) = 6.478E-23
            Ac_XSc(17, 13) = 9.0691E-24
            Ac_XSc(18, 13) = 4.286E-23
            Ac_XSc(19, 13) = 2.305E-23
            Ac_XSc(20, 13) = 3.6753E-24
            Ac_XSc(21, 13) = 1.3892E-23


            Ac_XSn2n(1, 13) = 0
            Ac_XSn2n(2, 13) = 0
            Ac_XSn2n(3, 13) = 0
            Ac_XSn2n(4, 13) = 0
            Ac_XSn2n(5, 13) = 5.31E-27
            Ac_XSn2n(6, 13) = 0
            Ac_XSn2n(7, 13) = 0
            Ac_XSn2n(8, 13) = 0
            Ac_XSn2n(9, 13) = 0
            Ac_XSn2n(10, 13) = 0
            Ac_XSn2n(11, 13) = 0
            Ac_XSn2n(12, 13) = 0
            Ac_XSn2n(13, 13) = 0
            Ac_XSn2n(14, 13) = 0
            Ac_XSn2n(15, 13) = 0
            Ac_XSn2n(16, 13) = 0
            Ac_XSn2n(17, 13) = 0
            Ac_XSn2n(18, 13) = 0
            Ac_XSn2n(19, 13) = 0
            Ac_XSn2n(20, 13) = 0
            Ac_XSn2n(21, 13) = 0


            Ac_XSf(1, 14) = 5.475E-25
            Ac_XSf(2, 14) = 1.369E-23
            Ac_XSf(3, 14) = 3.211E-25
            Ac_XSf(4, 14) = 4.813E-25
            Ac_XSf(5, 14) = 1.17E-25
            Ac_XSf(6, 14) = 0
            Ac_XSf(7, 14) = 6.206E-25
            Ac_XSf(8, 14) = 4.0021E-23
            Ac_XSf(9, 14) = 4.415E-25
            Ac_XSf(10, 14) = 1.9072E-24
            Ac_XSf(11, 14) = 2.39E-23
            Ac_XSf(12, 14) = 6.353E-25
            Ac_XSf(13, 14) = 3.105E-23
            Ac_XSf(14, 14) = 4.955E-25
            Ac_XSf(15, 14) = 0
            Ac_XSf(16, 14) = 8.01E-25
            Ac_XSf(17, 14) = 3.8463E-23
            Ac_XSf(18, 14) = 5.692E-25
            Ac_XSf(19, 14) = 4.8648E-23
            Ac_XSf(20, 14) = 5.733E-25
            Ac_XSf(21, 14) = 1.176E-24


            Ac_XSc(1, 14) = 1.6313E-23
            Ac_XSc(2, 14) = 4.892E-24
            Ac_XSc(3, 14) = 7.707E-24
            Ac_XSc(4, 14) = 1.3007E-23
            Ac_XSc(5, 14) = 8.24E-25
            Ac_XSc(6, 14) = 0
            Ac_XSc(7, 14) = 1.987E-23
            Ac_XSc(8, 14) = 4.1986E-24
            Ac_XSc(9, 14) = 1.2946E-23
            Ac_XSc(10, 14) = 8.7468E-24
            Ac_XSc(11, 14) = 1.403E-23
            Ac_XSc(12, 14) = 2.584E-23
            Ac_XSc(13, 14) = 1.089E-23
            Ac_XSc(14, 14) = 1.242E-23
            Ac_XSc(15, 14) = 0
            Ac_XSc(16, 14) = 4.007E-23
            Ac_XSc(17, 14) = 4.3323E-24
            Ac_XSc(18, 14) = 3.4896E-23
            Ac_XSc(19, 14) = 1.2432E-23
            Ac_XSc(20, 14) = 3.2094E-24
            Ac_XSc(21, 14) = 1.2734E-23


            Ac_XSn2n(1, 14) = 0
            Ac_XSn2n(2, 14) = 0
            Ac_XSn2n(3, 14) = 0
            Ac_XSn2n(4, 14) = 0
            Ac_XSn2n(5, 14) = 5.65E-27
            Ac_XSn2n(6, 14) = 0
            Ac_XSn2n(7, 14) = 0
            Ac_XSn2n(8, 14) = 0
            Ac_XSn2n(9, 14) = 0
            Ac_XSn2n(10, 14) = 0
            Ac_XSn2n(11, 14) = 0
            Ac_XSn2n(12, 14) = 0
            Ac_XSn2n(13, 14) = 0
            Ac_XSn2n(14, 14) = 0
            Ac_XSn2n(15, 14) = 0
            Ac_XSn2n(16, 14) = 0
            Ac_XSn2n(17, 14) = 0
            Ac_XSn2n(18, 14) = 0
            Ac_XSn2n(19, 14) = 0
            Ac_XSn2n(20, 14) = 0
            Ac_XSn2n(21, 14) = 0


            Ac_XSf(1, 15) = 5.373E-25
            Ac_XSf(2, 15) = 1.707E-23
            Ac_XSf(3, 15) = 3.202E-25
            Ac_XSf(4, 15) = 4.906E-25
            Ac_XSf(5, 15) = 1.14E-25
            Ac_XSf(6, 15) = 0
            Ac_XSf(7, 15) = 6.067E-25
            Ac_XSf(8, 15) = 5.3104E-23
            Ac_XSf(9, 15) = 4.306E-25
            Ac_XSf(10, 15) = 1.9665E-24
            Ac_XSf(11, 15) = 3.286E-23
            Ac_XSf(12, 15) = 6.248E-25
            Ac_XSf(13, 15) = 4.042E-23
            Ac_XSf(14, 15) = 4.838E-25
            Ac_XSf(15, 15) = 0
            Ac_XSf(16, 15) = 8.488E-25
            Ac_XSf(17, 15) = 5.3317E-23
            Ac_XSf(18, 15) = 5.649E-25
            Ac_XSf(19, 15) = 6.3173E-23
            Ac_XSf(20, 15) = 5.93E-25
            Ac_XSf(21, 15) = 1.175E-24


            Ac_XSc(1, 15) = 1.7596E-23
            Ac_XSc(2, 15) = 5.547E-24
            Ac_XSc(3, 15) = 8.092E-24
            Ac_XSc(4, 15) = 1.6244E-23
            Ac_XSc(5, 15) = 8.352E-25
            Ac_XSc(6, 15) = 0
            Ac_XSc(7, 15) = 2.2399E-23
            Ac_XSc(8, 15) = 5.5202E-24
            Ac_XSc(9, 15) = 1.345E-23
            Ac_XSc(10, 15) = 1.1368E-23
            Ac_XSc(11, 15) = 1.93E-23
            Ac_XSc(12, 15) = 3.323E-23
            Ac_XSc(13, 15) = 1.443E-23
            Ac_XSc(14, 15) = 1.457E-23
            Ac_XSc(15, 15) = 0
            Ac_XSc(16, 15) = 4.935E-23
            Ac_XSc(17, 15) = 5.9861E-24
            Ac_XSc(18, 15) = 3.7812E-23
            Ac_XSc(19, 15) = 1.6187E-23
            Ac_XSc(20, 15) = 3.4151E-24
            Ac_XSc(21, 15) = 1.3356E-23


            Ac_XSn2n(1, 15) = 0
            Ac_XSn2n(2, 15) = 0
            Ac_XSn2n(3, 15) = 0
            Ac_XSn2n(4, 15) = 0
            Ac_XSn2n(5, 15) = 5.51E-27
            Ac_XSn2n(6, 15) = 0
            Ac_XSn2n(7, 15) = 0
            Ac_XSn2n(8, 15) = 0
            Ac_XSn2n(9, 15) = 0
            Ac_XSn2n(10, 15) = 0
            Ac_XSn2n(11, 15) = 0
            Ac_XSn2n(12, 15) = 0
            Ac_XSn2n(13, 15) = 0
            Ac_XSn2n(14, 15) = 0
            Ac_XSn2n(15, 15) = 0
            Ac_XSn2n(16, 15) = 0
            Ac_XSn2n(17, 15) = 0
            Ac_XSn2n(18, 15) = 0
            Ac_XSn2n(19, 15) = 0
            Ac_XSn2n(20, 15) = 0
            Ac_XSn2n(21, 15) = 0

        End Sub

        Private Sub InitFiXS()
            fi_XSc(1, 1) = 2.33E-25
            fi_XSc(2, 1) = 8.72E-25
            fi_XSc(3, 1) = 4.3414E-24
            fi_XSc(4, 1) = 1.04E-24
            fi_XSc(5, 1) = 1.0778E-23
            fi_XSc(6, 1) = 2.7697E-24
            fi_XSc(7, 1) = 1.659E-25
            fi_XSc(8, 1) = 1.4422E-24
            fi_XSc(9, 1) = 2.211E-23
            fi_XSc(10, 1) = 8.863E-25
            fi_XSc(11, 1) = 5.1122E-22
            fi_XSc(12, 1) = 7.4391E-24
            fi_XSc(13, 1) = 0
            fi_XSc(14, 1) = 4.6339E-23
            fi_XSc(15, 1) = 2.4259E-24
            fi_XSc(16, 1) = 2.2619E-23
            fi_XSc(17, 1) = 8.43E-26
            fi_XSc(18, 1) = 8.2843E-24
            fi_XSc(19, 1) = 4.1564E-20
            fi_XSc(20, 1) = 9.6108E-24
            fi_XSc(21, 1) = 6.9562E-24
            fi_XSc(22, 1) = 1.2518E-24
            fi_XSc(23, 1) = 7.537E-25
            fi_XSc(24, 1) = 5.04E-25
            fi_XSc(25, 1) = 4.473E-25
            fi_XSc(26, 1) = 2.4271E-24
            fi_XSc(27, 1) = 1.64E-24
            fi_XSc(28, 1) = 8.61E-24
            fi_XSc(29, 1) = 6.8047E-24
            fi_XSc(30, 1) = 3.26E-25
            fi_XSc(31, 1) = 6.3849E-24
            fi_XSc(32, 1) = 1.89E-25
            fi_XSc(33, 1) = 1.96E-23
            fi_XSc(34, 1) = 5.4798E-23
            fi_XSc(35, 1) = 7.7587E-22
            fi_XSc(36, 1) = 5.2201E-22
            fi_XSc(37, 1) = 7.0E-23
            fi_XSc(38, 1) = 0
            fi_XSc(39, 1) = 2.0385E-23
            fi_XSc(40, 1) = 1.12E-24
            fi_XSc(41, 1) = 1.1433E-21
            fi_XSc(42, 1) = 9.997E-24
            fi_XSc(43, 1) = 1.7864E-22
            fi_XSc(44, 1) = 1.0099E-22
            fi_XSc(45, 1) = 7.7134E-23
            fi_XSc(46, 1) = 1.3424E-24
            fi_XSc(47, 1) = 0
            fi_XSc(48, 1) = 3.8194E-23
            fi_XSc(49, 1) = 4.7068E-23
            fi_XSc(50, 1) = 9.013E-23
            fi_XSc(51, 1) = 5.258E-23


            fi_XSc(1, 2) = 2.33E-25
            fi_XSc(2, 2) = 8.72E-25
            fi_XSc(3, 2) = 4.5717E-24
            fi_XSc(4, 2) = 1.04E-24
            fi_XSc(5, 2) = 1.1394E-23
            fi_XSc(6, 2) = 2.9505E-24
            fi_XSc(7, 2) = 1.947E-25
            fi_XSc(8, 2) = 1.8676E-24
            fi_XSc(9, 2) = 3.1594E-23
            fi_XSc(10, 2) = 2.0868E-24
            fi_XSc(11, 2) = 1.0295E-21
            fi_XSc(12, 2) = 7.6878E-24
            fi_XSc(13, 2) = 0
            fi_XSc(14, 2) = 4.8898E-23
            fi_XSc(15, 2) = 4.6941E-24
            fi_XSc(16, 2) = 2.6537E-23
            fi_XSc(17, 2) = 9.35E-26
            fi_XSc(18, 2) = 1.2481E-23
            fi_XSc(19, 2) = 1.37E-19
            fi_XSc(20, 2) = 1.1365E-23
            fi_XSc(21, 2) = 1.1497E-23
            fi_XSc(22, 2) = 1.6764E-24
            fi_XSc(23, 2) = 9.03E-25
            fi_XSc(24, 2) = 5.04E-25
            fi_XSc(25, 2) = 7.13E-25
            fi_XSc(26, 2) = 2.4029E-24
            fi_XSc(27, 2) = 1.64E-24
            fi_XSc(28, 2) = 8.61E-24
            fi_XSc(29, 2) = 1.6327E-23
            fi_XSc(30, 2) = 3.26E-25
            fi_XSc(31, 2) = 7.9443E-24
            fi_XSc(32, 2) = 1.89E-25
            fi_XSc(33, 2) = 1.96E-23
            fi_XSc(34, 2) = 6.4261E-23
            fi_XSc(35, 2) = 1.0223E-24
            fi_XSc(36, 2) = 1.5109E-24
            fi_XSc(37, 2) = 7.0E-23
            fi_XSc(38, 2) = 0
            fi_XSc(39, 2) = 2.3184E-23
            fi_XSc(40, 2) = 1.12E-24
            fi_XSc(41, 2) = 3.6226E-21
            fi_XSc(42, 2) = 1.3215E-23
            fi_XSc(43, 2) = 4.2975E-22
            fi_XSc(44, 2) = 1.0508E-22
            fi_XSc(45, 2) = 8.3473E-23
            fi_XSc(46, 2) = 1.4328E-24
            fi_XSc(47, 2) = 0
            fi_XSc(48, 2) = 4.9005E-23
            fi_XSc(49, 2) = 9.3485E-23
            fi_XSc(50, 2) = 2.1171E-22
            fi_XSc(51, 2) = 5.258E-23

            fi_XSc(1, 3) = 2.33E-25
            fi_XSc(2, 3) = 8.72E-25
            fi_XSc(3, 3) = 4.3343E-24
            fi_XSc(4, 3) = 1.04E-24
            fi_XSc(5, 3) = 1.0768E-23
            fi_XSc(6, 3) = 2.7625E-24
            fi_XSc(7, 3) = 1.66E-25
            fi_XSc(8, 3) = 1.5076E-24
            fi_XSc(9, 3) = 2.4087E-23
            fi_XSc(10, 3) = 9.086E-25
            fi_XSc(11, 3) = 5.2745E-22
            fi_XSc(12, 3) = 7.455E-24
            fi_XSc(13, 3) = 0
            fi_XSc(14, 3) = 4.6283E-23
            fi_XSc(15, 3) = 2.4347E-24
            fi_XSc(16, 3) = 2.2585E-23
            fi_XSc(17, 3) = 8.45E-26
            fi_XSc(18, 3) = 8.6289E-24
            fi_XSc(19, 3) = 4.2048E-20
            fi_XSc(20, 3) = 9.7183E-24
            fi_XSc(21, 3) = 6.983E-24
            fi_XSc(22, 3) = 1.3079E-24
            fi_XSc(23, 3) = 7.894E-25
            fi_XSc(24, 3) = 5.04E-25
            fi_XSc(25, 3) = 4.538E-25
            fi_XSc(26, 3) = 2.4306E-24
            fi_XSc(27, 3) = 1.64E-24
            fi_XSc(28, 3) = 8.61E-24
            fi_XSc(29, 3) = 6.9678E-24
            fi_XSc(30, 3) = 3.26E-25
            fi_XSc(31, 3) = 6.4464E-24
            fi_XSc(32, 3) = 1.89E-25
            fi_XSc(33, 3) = 1.96E-23
            fi_XSc(34, 3) = 5.4905E-23
            fi_XSc(35, 3) = 8.1102E-22
            fi_XSc(36, 3) = 5.2858E-22
            fi_XSc(37, 3) = 7.0E-23
            fi_XSc(38, 3) = 0
            fi_XSc(39, 3) = 2.0445E-23
            fi_XSc(40, 3) = 1.12E-24
            fi_XSc(41, 3) = 1.1608E-21
            fi_XSc(42, 3) = 1.0059E-23
            fi_XSc(43, 3) = 1.8289E-22
            fi_XSc(44, 3) = 1.0079E-22
            fi_XSc(45, 3) = 7.7267E-23
            fi_XSc(46, 3) = 1.3405E-24
            fi_XSc(47, 3) = 0
            fi_XSc(48, 3) = 3.9805E-23
            fi_XSc(49, 3) = 4.842E-23
            fi_XSc(50, 3) = 9.2369E-23
            fi_XSc(51, 3) = 5.28E-23


            fi_XSc(1, 4) = 2.33E-25
            fi_XSc(2, 4) = 8.72E-25
            fi_XSc(3, 4) = 4.2257E-24
            fi_XSc(4, 4) = 1.04E-24
            fi_XSc(5, 4) = 1.0075E-23
            fi_XSc(6, 4) = 2.5214E-24
            fi_XSc(7, 4) = 1.589E-25
            fi_XSc(8, 4) = 1.1894E-24
            fi_XSc(9, 4) = 1.7254E-23
            fi_XSc(10, 4) = 5.251E-25
            fi_XSc(11, 4) = 3.4098E-22
            fi_XSc(12, 4) = 7.1321E-24
            fi_XSc(13, 4) = 0
            fi_XSc(14, 4) = 4.3596E-23
            fi_XSc(15, 4) = 1.8119E-24
            fi_XSc(16, 4) = 1.9433E-23
            fi_XSc(17, 4) = 8.1E-26
            fi_XSc(18, 4) = 6.4441E-24
            fi_XSc(19, 4) = 1.7174E-20
            fi_XSc(20, 4) = 8.1798E-24
            fi_XSc(21, 4) = 5.162E-24
            fi_XSc(22, 4) = 1.0196E-24
            fi_XSc(23, 4) = 6.38E-25
            fi_XSc(24, 4) = 5.04E-25
            fi_XSc(25, 4) = 3.594E-25
            fi_XSc(26, 4) = 2.4172E-24
            fi_XSc(27, 4) = 1.64E-24
            fi_XSc(28, 4) = 8.61E-24
            fi_XSc(29, 4) = 3.9705E-24
            fi_XSc(30, 4) = 3.26E-25
            fi_XSc(31, 4) = 5.4765E-24
            fi_XSc(32, 4) = 1.89E-25
            fi_XSc(33, 4) = 1.96E-23
            fi_XSc(34, 4) = 4.6762E-23
            fi_XSc(35, 4) = 6.3563E-22
            fi_XSc(36, 4) = 2.5032E-22
            fi_XSc(37, 4) = 7.0E-23
            fi_XSc(38, 4) = 0
            fi_XSc(39, 4) = 1.7987E-23
            fi_XSc(40, 4) = 1.12E-24
            fi_XSc(41, 4) = 4.9029E-22
            fi_XSc(42, 4) = 8.4396E-24
            fi_XSc(43, 4) = 1.0392E-22
            fi_XSc(44, 4) = 9.6591E-23
            fi_XSc(45, 4) = 7.4951E-23
            fi_XSc(46, 4) = 1.3114E-24
            fi_XSc(47, 4) = 0
            fi_XSc(48, 4) = 3.2262E-23
            fi_XSc(49, 4) = 3.1566E-23
            fi_XSc(50, 4) = 5.3538E-23
            fi_XSc(51, 4) = 5.28E-23


            fi_XSc(1, 5) = 2.33E-25
            fi_XSc(2, 5) = 8.72E-25
            fi_XSc(3, 5) = 4.3374E-24
            fi_XSc(4, 5) = 1.04E-24
            fi_XSc(5, 5) = 1.077E-23
            fi_XSc(6, 5) = 2.7636E-24
            fi_XSc(7, 5) = 1.657E-25
            fi_XSc(8, 5) = 1.4675E-24
            fi_XSc(9, 5) = 2.3009E-23
            fi_XSc(10, 5) = 8.877E-25
            fi_XSc(11, 5) = 5.1465E-22
            fi_XSc(12, 5) = 7.4456E-24
            fi_XSc(13, 5) = 0
            fi_XSc(14, 5) = 4.6295E-23
            fi_XSc(15, 5) = 2.4141E-24
            fi_XSc(16, 5) = 2.2551E-23
            fi_XSc(17, 5) = 8.43E-26
            fi_XSc(18, 5) = 8.4045E-24
            fi_XSc(19, 5) = 4.1146E-20
            fi_XSc(20, 5) = 9.6239E-24
            fi_XSc(21, 5) = 6.9322E-24
            fi_XSc(22, 5) = 1.2732E-24
            fi_XSc(23, 5) = 7.683E-25
            fi_XSc(24, 5) = 5.04E-25
            fi_XSc(25, 5) = 4.482E-25
            fi_XSc(26, 5) = 2.4288E-24
            fi_XSc(27, 5) = 1.64E-24
            fi_XSc(28, 5) = 8.61E-24
            fi_XSc(29, 5) = 6.8091E-24
            fi_XSc(30, 5) = 3.26E-25
            fi_XSc(31, 5) = 6.3933E-24
            fi_XSc(32, 5) = 1.89E-25
            fi_XSc(33, 5) = 1.96E-23
            fi_XSc(34, 5) = 5.472E-23
            fi_XSc(35, 5) = 7.8939E-22
            fi_XSc(36, 5) = 5.1804E-22
            fi_XSc(37, 5) = 7.0E-23
            fi_XSc(38, 5) = 0
            fi_XSc(39, 5) = 2.0381E-23
            fi_XSc(40, 5) = 1.12E-24
            fi_XSc(41, 5) = 1.1336999999999999E-21
            fi_XSc(42, 5) = 1.0008E-23
            fi_XSc(43, 5) = 1.7871E-22
            fi_XSc(44, 5) = 1.0088E-22
            fi_XSc(45, 5) = 7.7154E-23
            fi_XSc(46, 5) = 1.3412E-24
            fi_XSc(47, 5) = 0
            fi_XSc(48, 5) = 3.8898E-23
            fi_XSc(49, 5) = 4.7331E-23
            fi_XSc(50, 5) = 9.0256E-23
            fi_XSc(51, 5) = 5.258E-23


            fi_XSc(1, 6) = 2.33E-25
            fi_XSc(2, 6) = 8.72E-25
            fi_XSc(3, 6) = 4.3323E-24
            fi_XSc(4, 6) = 1.04E-24
            fi_XSc(5, 6) = 1.1059E-23
            fi_XSc(6, 6) = 2.8649E-24
            fi_XSc(7, 6) = 1.727E-25
            fi_XSc(8, 6) = 1.6364E-24
            fi_XSc(9, 6) = 2.6239E-23
            fi_XSc(10, 6) = 1.3166E-24
            fi_XSc(11, 6) = 7.0172E-22
            fi_XSc(12, 6) = 7.4785E-24
            fi_XSc(13, 6) = 0
            fi_XSc(14, 6) = 4.7332E-23
            fi_XSc(15, 6) = 3.1907E-24
            fi_XSc(16, 6) = 2.4598E-23
            fi_XSc(17, 6) = 8.62E-26
            fi_XSc(18, 6) = 9.98E-24
            fi_XSc(19, 6) = 7.5415E-20
            fi_XSc(20, 6) = 1.07E-23
            fi_XSc(21, 6) = 8.6893E-24
            fi_XSc(22, 6) = 1.4387E-24
            fi_XSc(23, 6) = 8.311E-25
            fi_XSc(24, 6) = 5.04E-25
            fi_XSc(25, 6) = 5.406E-25
            fi_XSc(26, 6) = 2.3753E-24
            fi_XSc(27, 6) = 1.64E-24
            fi_XSc(28, 6) = 8.61E-24
            fi_XSc(29, 6) = 1.0209E-23
            fi_XSc(30, 6) = 3.26E-25
            fi_XSc(31, 6) = 7.0589E-24
            fi_XSc(32, 6) = 1.89E-25
            fi_XSc(33, 6) = 1.96E-23
            fi_XSc(34, 6) = 6.0639E-23
            fi_XSc(35, 6) = 8.861E-22
            fi_XSc(36, 6) = 8.6843E-22
            fi_XSc(37, 6) = 7.0E-23
            fi_XSc(38, 6) = 0
            fi_XSc(39, 6) = 2.1918E-23
            fi_XSc(40, 6) = 1.12E-24
            fi_XSc(41, 6) = 2.0388E-21
            fi_XSc(42, 6) = 1.1639E-23
            fi_XSc(43, 6) = 2.6835E-22
            fi_XSc(44, 6) = 1.0181E-22
            fi_XSc(45, 6) = 7.8021E-23
            fi_XSc(46, 6) = 1.3432E-24
            fi_XSc(47, 6) = 0
            fi_XSc(48, 6) = 4.2733E-23
            fi_XSc(49, 6) = 6.431E-23
            fi_XSc(50, 6) = 1.3371E-22
            fi_XSc(51, 6) = 5.258E-23


            fi_XSc(1, 7) = 2.33E-25
            fi_XSc(2, 7) = 8.72E-25
            fi_XSc(3, 7) = 4.6905E-24
            fi_XSc(4, 7) = 1.04E-24
            fi_XSc(5, 7) = 1.1532E-23
            fi_XSc(6, 7) = 2.9544E-24
            fi_XSc(7, 7) = 2.211E-25
            fi_XSc(8, 7) = 2.1021E-24
            fi_XSc(9, 7) = 3.7072E-23
            fi_XSc(10, 7) = 3.2108E-24
            fi_XSc(11, 7) = 1.4961E-21
            fi_XSc(12, 7) = 7.6489E-24
            fi_XSc(13, 7) = 0
            fi_XSc(14, 7) = 4.9548E-23
            fi_XSc(15, 7) = 6.8956E-24
            fi_XSc(16, 7) = 2.8623E-23
            fi_XSc(17, 7) = 1.008E-25
            fi_XSc(18, 7) = 1.5651E-23
            fi_XSc(19, 7) = 2.34E-19
            fi_XSc(20, 7) = 1.2377E-23
            fi_XSc(21, 7) = 1.5388E-23
            fi_XSc(22, 7) = 1.9362E-24
            fi_XSc(23, 7) = 9.494E-25
            fi_XSc(24, 7) = 5.04E-25
            fi_XSc(25, 7) = 9.511E-25
            fi_XSc(26, 7) = 2.3252E-24
            fi_XSc(27, 7) = 1.64E-24
            fi_XSc(28, 7) = 8.61E-24
            fi_XSc(29, 7) = 2.5285E-23
            fi_XSc(30, 7) = 3.26E-25
            fi_XSc(31, 7) = 9.0183E-24
            fi_XSc(32, 7) = 1.89E-25
            fi_XSc(33, 7) = 1.96E-23
            fi_XSc(34, 7) = 6.9631E-23
            fi_XSc(35, 7) = 1.1658E-21
            fi_XSc(36, 7) = 2.4727E-21
            fi_XSc(37, 7) = 7.0E-23
            fi_XSc(38, 7) = 0
            fi_XSc(39, 7) = 2.4635E-23
            fi_XSc(40, 7) = 1.12E-24
            fi_XSc(41, 7) = 6.1302E-21
            fi_XSc(42, 7) = 1.5892E-23
            fi_XSc(43, 7) = 6.6608E-22
            fi_XSc(44, 7) = 1.0571E-22
            fi_XSc(45, 7) = 8.8072E-23
            fi_XSc(46, 7) = 1.4956E-24
            fi_XSc(47, 7) = 0
            fi_XSc(48, 7) = 5.5661E-23
            fi_XSc(49, 7) = 1.3532E-22
            fi_XSc(50, 7) = 3.2556E-22
            fi_XSc(51, 7) = 5.258E-23


            fi_XSc(1, 8) = 2.33E-25
            fi_XSc(2, 8) = 8.72E-25
            fi_XSc(3, 8) = 4.3232E-24
            fi_XSc(4, 8) = 1.04E-24
            fi_XSc(5, 8) = 1.1041E-23
            fi_XSc(6, 8) = 2.8565E-24
            fi_XSc(7, 8) = 1.724E-25
            fi_XSc(8, 8) = 1.6887E-24
            fi_XSc(9, 8) = 2.7813E-23
            fi_XSc(10, 8) = 1.3145E-24
            fi_XSc(11, 8) = 7.0687E-22
            fi_XSc(12, 8) = 7.4897E-24
            fi_XSc(13, 8) = 0
            fi_XSc(14, 8) = 4.7246E-23
            fi_XSc(15, 8) = 3.1557E-24
            fi_XSc(16, 8) = 2.4505E-23
            fi_XSc(17, 8) = 8.61E-26
            fi_XSc(18, 8) = 1.0219E-23
            fi_XSc(19, 8) = 7.4215E-20
            fi_XSc(20, 8) = 1.0755E-23
            fi_XSc(21, 8) = 8.6354E-24
            fi_XSc(22, 8) = 1.48214E-24
            fi_XSc(23, 8) = 8.61E-25
            fi_XSc(24, 8) = 5.04E-25
            fi_XSc(25, 8) = 5.416E-25
            fi_XSc(26, 8) = 2.3797E-24
            fi_XSc(27, 8) = 1.64E-24
            fi_XSc(28, 8) = 8.61E-24
            fi_XSc(29, 8) = 1.018E-23
            fi_XSc(30, 8) = 3.26E-25
            fi_XSc(31, 8) = 7.084E-24
            fi_XSc(32, 8) = 1.89E-25
            fi_XSc(33, 8) = 1.96E-23
            fi_XSc(34, 8) = 6.0552E-23
            fi_XSc(35, 8) = 9.1378E-22
            fi_XSc(36, 8) = 8.5603E-22
            fi_XSc(37, 8) = 7.0E-23
            fi_XSc(38, 8) = 0
            fi_XSc(39, 8) = 2.1926E-23
            fi_XSc(40, 8) = 1.12E-24
            fi_XSc(41, 8) = 2.0113E-21
            fi_XSc(42, 8) = 1.1436E-23
            fi_XSc(43, 8) = 2.6755E-22
            fi_XSc(44, 8) = 1.016E-22
            fi_XSc(45, 8) = 7.8037E-23
            fi_XSc(46, 8) = 1.3403E-24
            fi_XSc(47, 8) = 0
            fi_XSc(48, 8) = 4.3956E-23
            fi_XSc(49, 8) = 6.4674E-23
            fi_XSc(50, 8) = 1.3351E-22
            fi_XSc(51, 8) = 5.258E-23


            fi_XSc(1, 9) = 2.33E-25
            fi_XSc(2, 9) = 8.72E-25
            fi_XSc(3, 9) = 4.1957E-24
            fi_XSc(4, 9) = 1.04E-24
            fi_XSc(5, 9) = 1.0488E-23
            fi_XSc(6, 9) = 2.6766E-24
            fi_XSc(7, 9) = 1.597E-25
            fi_XSc(8, 9) = 1.3704E-24
            fi_XSc(9, 9) = 2.0865E-23
            fi_XSc(10, 9) = 7.395E-25
            fi_XSc(11, 9) = 4.4541E-22
            fi_XSc(12, 9) = 7.2362E-24
            fi_XSc(13, 9) = 0
            fi_XSc(14, 9) = 4.5053E-23
            fi_XSc(15, 9) = 2.1341E-24
            fi_XSc(16, 9) = 2.1641E-23
            fi_XSc(17, 9) = 8.15E-26
            fi_XSc(18, 9) = 7.6777E-24
            fi_XSc(19, 9) = 3.1701E-20
            fi_XSc(20, 9) = 9.337E-24
            fi_XSc(21, 9) = 6.2724E-24
            fi_XSc(22, 9) = 1.1829E-24
            fi_XSc(23, 9) = 7.245E-25
            fi_XSc(24, 9) = 5.04E-25
            fi_XSc(25, 9) = 4.088E-25
            fi_XSc(26, 9) = 2.3765E-24
            fi_XSc(27, 9) = 1.64E-24
            fi_XSc(28, 9) = 8.61E-24
            fi_XSc(29, 9) = 5.6451E-24
            fi_XSc(30, 9) = 3.26E-25
            fi_XSc(31, 9) = 6.0712E-24
            fi_XSc(32, 9) = 1.89E-25
            fi_XSc(33, 9) = 1.96E-23
            fi_XSc(34, 9) = 5.3257E-23
            fi_XSc(35, 9) = 7.3512E-22
            fi_XSc(36, 9) = 4.0619E-22
            fi_XSc(37, 9) = 7.0E-23
            fi_XSc(38, 9) = 0
            fi_XSc(39, 9) = 1.9742E-23
            fi_XSc(40, 9) = 1.12E-24
            fi_XSc(41, 9) = 8.8583E-22
            fi_XSc(42, 9) = 9.5923E-24
            fi_XSc(43, 9) = 1.4802E-22
            fi_XSc(44, 9) = 9.8144E-23
            fi_XSc(45, 9) = 7.4784E-23
            fi_XSc(46, 9) = 1.297E-24
            fi_XSc(47, 9) = 0
            fi_XSc(48, 9) = 3.6335E-23
            fi_XSc(49, 9) = 4.1218E-23
            fi_XSc(50, 9) = 7.5249E-23
            fi_XSc(51, 9) = 5.258E-23


            fi_XSc(1, 10) = 2.33E-25
            fi_XSc(2, 10) = 8.72E-25
            fi_XSc(3, 10) = 4.3263E-24
            fi_XSc(4, 10) = 1.04E-24
            fi_XSc(5, 10) = 1.1046E-23
            fi_XSc(6, 10) = 2.8591E-24
            fi_XSc(7, 10) = 1.722E-25
            fi_XSc(8, 10) = 1.6556E-24
            fi_XSc(9, 10) = 2.6941E-23
            fi_XSc(10, 10) = 1.3023E-24
            fi_XSc(11, 10) = 6.9832E-22
            fi_XSc(12, 10) = 7.4829E-24
            fi_XSc(13, 10) = 0
            fi_XSc(14, 10) = 4.7277E-23
            fi_XSc(15, 10) = 3.1499E-24
            fi_XSc(16, 10) = 2.4508E-23
            fi_XSc(17, 10) = 8.6E-26
            fi_XSc(18, 10) = 1.0042E-23
            fi_XSc(19, 10) = 7.3821E-20
            fi_XSc(20, 10) = 1.0693E-23
            fi_XSc(21, 10) = 8.6152E-24
            fi_XSc(22, 10) = 1.454E-24
            fi_XSc(23, 10) = 8.434E-25
            fi_XSc(24, 10) = 5.04E-25
            fi_XSc(25, 10) = 5.382E-25
            fi_XSc(26, 10) = 2.3776E-24
            fi_XSc(27, 10) = 1.64E-24
            fi_XSc(28, 10) = 8.61E-24
            fi_XSc(29, 10) = 1.0089E-23
            fi_XSc(30, 10) = 3.26E-25
            fi_XSc(31, 10) = 7.0497E-24
            fi_XSc(32, 10) = 1.89E-25
            fi_XSc(33, 10) = 1.96E-23
            fi_XSc(34, 10) = 6.0486E-23
            fi_XSc(35, 10) = 8.9609E-22
            fi_XSc(36, 10) = 8.5185E-22
            fi_XSc(37, 10) = 7.0E-23
            fi_XSc(38, 10) = 0
            fi_XSc(39, 10) = 2.1894E-23
            fi_XSc(40, 10) = 1.12E-24
            fi_XSc(41, 10) = 1.9981E-21
            fi_XSc(42, 10) = 1.141E-23
            fi_XSc(43, 10) = 2.652E-22
            fi_XSc(44, 10) = 1.0168E-22
            fi_XSc(45, 10) = 7.7962E-23
            fi_XSc(46, 10) = 1.3411E-24
            fi_XSc(47, 10) = 0
            fi_XSc(48, 10) = 4.3254E-23
            fi_XSc(49, 10) = 6.3967E-23
            fi_XSc(50, 10) = 1.3226E-22
            fi_XSc(51, 10) = 5.258E-23


            fi_XSc(1, 11) = 2.33E-25
            fi_XSc(2, 11) = 8.72E-25
            fi_XSc(3, 11) = 4.2611E-24
            fi_XSc(4, 11) = 1.04E-24
            fi_XSc(5, 11) = 1.0619E-23
            fi_XSc(6, 11) = 2.7171E-24
            fi_XSc(7, 11) = 1.622E-25
            fi_XSc(8, 11) = 1.3974E-24
            fi_XSc(9, 11) = 2.1331E-23
            fi_XSc(10, 11) = 7.929E-25
            fi_XSc(11, 11) = 4.6944E-22
            fi_XSc(12, 11) = 7.3281E-24
            fi_XSc(13, 11) = 0
            fi_XSc(14, 11) = 4.5625E-23
            fi_XSc(15, 11) = 2.242E-24
            fi_XSc(16, 11) = 2.2042E-23
            fi_XSc(17, 11) = 8.29E-26
            fi_XSc(18, 11) = 7.9022E-24
            fi_XSc(19, 11) = 3.5154E-20
            fi_XSc(20, 11) = 9.4442E-24
            fi_XSc(21, 11) = 6.5314E-24
            fi_XSc(22, 11) = 1.2088E-24
            fi_XSc(23, 11) = 7.357E-25
            fi_XSc(24, 11) = 5.04E-25
            fi_XSc(25, 11) = 4.233E-25
            fi_XSc(26, 11) = 2.3999E-24
            fi_XSc(27, 11) = 1.64E-24
            fi_XSc(28, 11) = 8.61E-24
            fi_XSc(29, 11) = 6.0661E-24
            fi_XSc(30, 11) = 3.26E-25
            fi_XSc(31, 11) = 6.1961E-24
            fi_XSc(32, 11) = 1.89E-25
            fi_XSc(33, 11) = 1.96E-23
            fi_XSc(34, 11) = 5.3852E-23
            fi_XSc(35, 11) = 7.5041E-22
            fi_XSc(36, 11) = 4.4797E-22
            fi_XSc(37, 11) = 7.0E-23
            fi_XSc(38, 11) = 0
            fi_XSc(39, 11) = 2.0004E-23
            fi_XSc(40, 11) = 1.12E-24
            fi_XSc(41, 11) = 9.7576E-22
            fi_XSc(42, 11) = 9.7403E-24
            fi_XSc(43, 11) = 1.5913E-22
            fi_XSc(44, 11) = 9.9427E-23
            fi_XSc(45, 11) = 7.5788E-23
            fi_XSc(46, 11) = 1.3171E-24
            fi_XSc(47, 11) = 0
            fi_XSc(48, 11) = 3.7057E-23
            fi_XSc(49, 11) = 4.3354E-23
            fi_XSc(50, 11) = 8.0654E-23
            fi_XSc(51, 11) = 5.258E-23


            fi_XSc(1, 12) = 2.33E-25
            fi_XSc(2, 12) = 8.72E-25
            fi_XSc(3, 12) = 4.4439E-24
            fi_XSc(4, 12) = 1.04E-24
            fi_XSc(5, 12) = 1.1249E-23
            fi_XSc(6, 12) = 2.9163E-24
            fi_XSc(7, 12) = 1.825E-25
            fi_XSc(8, 12) = 1.7567E-24
            fi_XSc(9, 12) = 2.9055E-23
            fi_XSc(10, 12) = 1.6643E-24
            fi_XSc(11, 12) = 8.5156E-22
            fi_XSc(12, 12) = 7.5939E-24
            fi_XSc(13, 12) = 0
            fi_XSc(14, 12) = 4.8181E-23
            fi_XSc(15, 12) = 3.8604E-24
            fi_XSc(16, 12) = 2.5608E-23
            fi_XSc(17, 12) = 8.95E-26
            fi_XSc(18, 12) = 1.1182E-23
            fi_XSc(19, 12) = 1.03E-19
            fi_XSc(20, 12) = 1.1081E-23
            fi_XSc(21, 12) = 9.9827E-24
            fi_XSc(22, 12) = 1.5592E-24
            fi_XSc(23, 12) = 8.728E-25
            fi_XSc(24, 12) = 5.04E-25
            fi_XSc(25, 12) = 6.194E-25
            fi_XSc(26, 12) = 2.3899E-24
            fi_XSc(27, 12) = 1.64E-24
            fi_XSc(28, 12) = 8.61E-24
            fi_XSc(29, 12) = 1.235E-23
            fi_XSc(30, 12) = 3.26E-25
            fi_XSc(31, 12) = 7.4945E-24
            fi_XSc(32, 12) = 1.89E-25
            fi_XSc(33, 12) = 1.96E-23
            fi_XSc(34, 12) = 6.2653E-23
            fi_XSc(35, 12) = 9.5602E-22
            fi_XSc(36, 12) = 1.1551E-21
            fi_XSc(37, 12) = 7.0E-23
            fi_XSc(38, 12) = 0
            fi_XSc(39, 12) = 2.2609E-23
            fi_XSc(40, 12) = 1.12E-24
            fi_XSc(41, 12) = 2.743E-21
            fi_XSc(42, 12) = 1.2287E-23
            fi_XSc(43, 12) = 3.4112E-22
            fi_XSc(44, 12) = 1.0353E-22
            fi_XSc(45, 12) = 8.052E-23
            fi_XSc(46, 12) = 1.384E-24
            fi_XSc(47, 12) = 0
            fi_XSc(48, 12) = 4.5968E-23
            fi_XSc(49, 12) = 7.7657E-23
            fi_XSc(50, 12) = 1.6893E-22
            fi_XSc(51, 12) = 5.258E-23



            fi_XSc(1, 13) = 2.33E-25
            fi_XSc(2, 13) = 8.72E-25
            fi_XSc(3, 13) = 4.4248E-24
            fi_XSc(4, 13) = 1.04E-24
            fi_XSc(5, 13) = 1.1208E-23
            fi_XSc(6, 13) = 2.9045E-24
            fi_XSc(7, 13) = 1.805E-25
            fi_XSc(8, 13) = 1.7583E-24
            fi_XSc(9, 13) = 2.9279E-23
            fi_XSc(10, 13) = 1.5877E-24
            fi_XSc(11, 13) = 8.2174E-22
            fi_XSc(12, 13) = 7.5863E-24
            fi_XSc(13, 13) = 0
            fi_XSc(14, 13) = 4.8007E-23
            fi_XSc(15, 13) = 3.6984E-24
            fi_XSc(16, 13) = 2.5356E-23
            fi_XSc(17, 13) = 8.89E-26
            fi_XSc(18, 13) = 1.1048E-23
            fi_XSc(19, 13) = 9.5914E-20
            fi_XSc(20, 13) = 1.1008E-23
            fi_XSc(21, 13) = 9.6812E-24
            fi_XSc(22, 13) = 1.5565E-24
            fi_XSc(23, 13) = 8.796E-25
            fi_XSc(24, 13) = 5.04E-25
            fi_XSc(25, 13) = 6.03E-25
            fi_XSc(26, 13) = 2.3937E-24
            fi_XSc(27, 13) = 1.64E-24
            fi_XSc(28, 13) = 8.61E-24
            fi_XSc(29, 13) = 1.235E-23
            fi_XSc(30, 13) = 3.26E-25
            fi_XSc(31, 13) = 7.4145E-24
            fi_XSc(32, 13) = 1.89E-25
            fi_XSc(33, 13) = 1.96E-23
            fi_XSc(34, 13) = 6.2117E-23
            fi_XSc(35, 13) = 9.5555E-22
            fi_XSc(36, 13) = 1.086E-21
            fi_XSc(37, 13) = 7.0E-23
            fi_XSc(38, 13) = 0
            fi_XSc(39, 13) = 2.246E-23
            fi_XSc(40, 13) = 1.12E-24
            fi_XSc(41, 13) = 2.5702E-21
            fi_XSc(42, 13) = 1.2089E-23
            fi_XSc(43, 13) = 3.2488E-22
            fi_XSc(44, 13) = 1.032E-22
            fi_XSc(45, 13) = 8.0121E-23
            fi_XSc(46, 13) = 1.3766E-24
            fi_XSc(47, 13) = 0
            fi_XSc(48, 13) = 4.5916E-23
            fi_XSc(49, 13) = 7.4936E-23
            fi_XSc(50, 13) = 1.6115E-22
            fi_XSc(51, 13) = 5.258E-23


            fi_XSc(1, 14) = 2.33E-25
            fi_XSc(2, 14) = 8.72E-25
            fi_XSc(3, 14) = 4.2637E-24
            fi_XSc(4, 14) = 1.04E-24
            fi_XSc(5, 14) = 1.0645E-23
            fi_XSc(6, 14) = 2.7238E-24
            fi_XSc(7, 14) = 1.626E-25
            fi_XSc(8, 14) = 1.4401E-24
            fi_XSc(9, 14) = 2.2519E-23
            fi_XSc(10, 14) = 8.195E-25
            fi_XSc(11, 14) = 4.8477E-22
            fi_XSc(12, 14) = 7.351E-24
            fi_XSc(13, 14) = 0
            fi_XSc(14, 14) = 4.5724E-23
            fi_XSc(15, 14) = 2.274E-24
            fi_XSc(16, 14) = 2.2153E-23
            fi_XSc(17, 14) = 8.3E-26
            fi_XSc(18, 14) = 8.1489E-24
            fi_XSc(19, 14) = 3.6532E-20
            fi_XSc(20, 14) = 9.5577E-24
            fi_XSc(21, 14) = 6.6174E-24
            fi_XSc(22, 14) = 1.246E-24
            fi_XSc(23, 14) = 7.579E-25
            fi_XSc(24, 14) = 5.04E-25
            fi_XSc(25, 14) = 4.305E-25
            fi_XSc(26, 14) = 2.4025E-24
            fi_XSc(27, 14) = 1.64E-24
            fi_XSc(28, 14) = 8.61E-24
            fi_XSc(29, 14) = 6.2701E-24
            fi_XSc(30, 14) = 3.26E-25
            fi_XSc(31, 14) = 6.2648E-24
            fi_XSc(32, 14) = 1.89E-25
            fi_XSc(33, 14) = 1.96E-23
            fi_XSc(34, 14) = 5.4231E-23
            fi_XSc(35, 14) = 7.7343E-22
            fi_XSc(36, 14) = 4.6329E-22
            fi_XSc(37, 14) = 7.0E-23
            fi_XSc(38, 14) = 0
            fi_XSc(39, 14) = 2.0143E-23
            fi_XSc(40, 14) = 1.12E-24
            fi_XSc(41, 14) = 1.0142E-21
            fi_XSc(42, 14) = 9.8482E-24
            fi_XSc(43, 14) = 1.6449E-22
            fi_XSc(44, 14) = 9.9537E-23
            fi_XSc(45, 14) = 7.5958E-23
            fi_XSc(46, 14) = 1.3178E-24
            fi_XSc(47, 14) = 0
            fi_XSc(48, 14) = 3.8151E-23
            fi_XSc(49, 14) = 4.4694E-23
            fi_XSc(50, 14) = 8.3361E-23
            fi_XSc(51, 14) = 5.258E-23


            fi_XSc(1, 15) = 2.33E-25
            fi_XSc(2, 15) = 8.72E-25
            fi_XSc(3, 15) = 4.3288E-24
            fi_XSc(4, 15) = 1.04E-24
            fi_XSc(5, 15) = 1.0936E-23
            fi_XSc(6, 15) = 2.8224E-24
            fi_XSc(7, 15) = 1.686E-25
            fi_XSc(8, 15) = 1.5693E-24
            fi_XSc(9, 15) = 2.5112E-23
            fi_XSc(10, 15) = 1.0897E-24
            fi_XSc(11, 15) = 6.0535E-22
            fi_XSc(12, 15) = 7.4734E-24
            fi_XSc(13, 15) = 0
            fi_XSc(14, 15) = 4.6883E-23
            fi_XSc(15, 15) = 2.7655E-24
            fi_XSc(16, 15) = 2.3649E-23
            fi_XSc(17, 15) = 8.51E-26
            fi_XSc(18, 15) = 9.2494E-24
            fi_XSc(19, 15) = 5.671E-20
            fi_XSc(20, 15) = 1.0221E-23
            fi_XSc(21, 15) = 7.7818E-24
            fi_XSc(22, 15) = 1.3697E-24
            fi_XSc(23, 15) = 8.106E-28
            fi_XSc(24, 15) = 5.04E-25
            fi_XSc(25, 15) = 4.925E-25
            fi_XSc(26, 15) = 2.4019E-24
            fi_XSc(27, 15) = 1.64E-24
            fi_XSc(28, 15) = 8.61E-24
            fi_XSc(29, 15) = 8.406E-24
            fi_XSc(30, 15) = 3.26E-25
            fi_XSc(31, 15) = 6.7434E-24
            fi_XSc(32, 15) = 1.89E-25
            fi_XSc(33, 15) = 1.96E-23
            fi_XSc(34, 15) = 5.7958E-23
            fi_XSc(35, 15) = 8.4673E-22
            fi_XSc(36, 15) = 6.7878E-22
            fi_XSc(37, 15) = 7.0E-23
            fi_XSc(38, 15) = 0
            fi_XSc(39, 15) = 2.1234E-23
            fi_XSc(40, 15) = 1.12E-24
            fi_XSc(41, 15) = 1.5467E-21
            fi_XSc(42, 15) = 1.0741E-23
            fi_XSc(43, 15) = 2.2081E-22
            fi_XSc(44, 15) = 1.014E-22
            fi_XSc(45, 15) = 7.7469E-23
            fi_XSc(46, 15) = 1.3394E-24
            fi_XSc(47, 15) = 0
            fi_XSc(48, 15) = 4.1229E-23
            fi_XSc(49, 15) = 5.5567E-23
            fi_XSc(50, 15) = 1.1074E-22
            fi_XSc(51, 15) = 5.258E-23

        End Sub

        Private Sub InitZeta()
            zeta_f30(1, 1) = 0.9614
            zeta_f30(2, 1) = 0.9955
            zeta_f30(3, 1) = 0.9189
            zeta_f30(4, 1) = 0.9624

            zeta_f60(1, 1) = 1.0725
            zeta_f60(2, 1) = 1
            zeta_f60(3, 1) = 1.12
            zeta_f60(4, 1) = 1.0845


            zeta_c30(1, 1) = 0.9928
            zeta_c30(2, 1) = 1.1166
            zeta_c30(3, 1) = 0.9161
            zeta_c30(4, 1) = 0.9575
            zeta_c30(5, 1) = 0.9466
            zeta_c30(6, 1) = 1.0122
            zeta_c30(7, 1) = 0.9987



            zeta_c60(1, 1) = 1.0314
            zeta_c60(2, 1) = 0.9428
            zeta_c60(3, 1) = 1.1206
            zeta_c60(4, 1) = 1.091
            zeta_c60(5, 1) = 1.0982
            zeta_c60(6, 1) = 0.9989
            zeta_c60(7, 1) = 1.049

            zeta_f30(1, 2) = 0.8774
            zeta_f30(2, 2) = 1.0078
            zeta_f30(3, 2) = 0.8435
            zeta_f30(4, 2) = 0.8694

            zeta_f60(1, 2) = 1.0853
            zeta_f60(2, 2) = 1
            zeta_f60(3, 2) = 1.1002
            zeta_f60(4, 2) = 1.0894


            zeta_c30(1, 2) = 0.9279
            zeta_c30(2, 2) = 1.11
            zeta_c30(3, 2) = 0.8426
            zeta_c30(4, 2) = 1.068
            zeta_c30(5, 2) = 0.8597
            zeta_c30(6, 2) = 1.2774
            zeta_c30(7, 2) = 0.9245



            zeta_c60(1, 2) = 1.0491
            zeta_c60(2, 2) = 0.9248
            zeta_c60(3, 2) = 1.0984
            zeta_c60(4, 2) = 1.0356
            zeta_c60(5, 2) = 1.0949
            zeta_c60(6, 2) = 0.81
            zeta_c60(7, 2) = 1.0473


            zeta_f30(1, 3) = 0.9303
            zeta_f30(2, 3) = 1
            zeta_f30(3, 3) = 0.8623
            zeta_f30(4, 3) = 0.9234

            zeta_f60(1, 3) = 1.0988
            zeta_f60(2, 3) = 1
            zeta_f60(3, 3) = 1.1735
            zeta_f60(4, 3) = 1.1168


            zeta_c30(1, 3) = 0.9739
            zeta_c30(2, 3) = 1.122
            zeta_c30(3, 3) = 0.8547
            zeta_c30(4, 3) = 1.071
            zeta_c30(5, 3) = 0.902
            zeta_c30(6, 3) = 1.1775
            zeta_c30(7, 3) = 0.9753



            zeta_c60(1, 3) = 1.0456
            zeta_c60(2, 3) = 0.9322
            zeta_c60(3, 3) = 1.1801
            zeta_c60(4, 3) = 1.0188
            zeta_c60(5, 3) = 1.1345
            zeta_c60(6, 3) = 0.8307
            zeta_c60(7, 3) = 1.0629

            zeta_f30(1, 4) = 0.9926
            zeta_f30(2, 4) = 0.9986
            zeta_f30(3, 4) = 0.9536
            zeta_f30(4, 4) = 1.0045

            zeta_f60(1, 4) = 1.0293
            zeta_f60(2, 4) = 1.0102
            zeta_f60(3, 4) = 1.076
            zeta_f60(4, 4) = 1.0305


            zeta_c30(1, 4) = 1.0097
            zeta_c30(2, 4) = 1.1193
            zeta_c30(3, 4) = 0.9469
            zeta_c30(4, 4) = 0.9952
            zeta_c30(5, 4) = 0.9864
            zeta_c30(6, 4) = 1.0053
            zeta_c30(7, 4) = 1.0392



            zeta_c60(1, 4) = 1.008
            zeta_c60(2, 4) = 0.9348
            zeta_c60(3, 4) = 1.0806
            zeta_c60(4, 4) = 1.0448
            zeta_c60(5, 4) = 1.0466
            zeta_c60(6, 4) = 1.0088
            zeta_c60(7, 4) = 1.0071

            zeta_f30(1, 5) = 0.9437
            zeta_f30(2, 5) = 0.9955
            zeta_f30(3, 5) = 0.8863
            zeta_f30(4, 5) = 0.9392

            zeta_f60(1, 5) = 1.0878
            zeta_f60(2, 5) = 1
            zeta_f60(3, 5) = 1.1495
            zeta_f60(4, 5) = 1.1021


            zeta_c30(1, 5) = 0.982
            zeta_c30(2, 5) = 1.1182
            zeta_c30(3, 5) = 0.8806
            zeta_c30(4, 5) = 0.9856
            zeta_c30(5, 5) = 0.9219
            zeta_c30(6, 5) = 1.0726
            zeta_c30(7, 5) = 0.9822



            zeta_c60(1, 5) = 1.0395
            zeta_c60(2, 5) = 0.9387
            zeta_c60(3, 5) = 1.1517
            zeta_c60(4, 5) = 1.0718
            zeta_c60(5, 5) = 1.1196
            zeta_c60(6, 5) = 0.9267
            zeta_c60(7, 5) = 1.0601


            zeta_f30(1, 6) = 0.8867
            zeta_f30(2, 6) = 1
            zeta_f30(3, 6) = 0.8299
            zeta_f30(4, 6) = 0.8748

            zeta_f60(1, 6) = 1.1642
            zeta_f60(2, 6) = 0.9938
            zeta_f60(3, 6) = 1.2254
            zeta_f60(4, 6) = 1.1855


            zeta_c30(1, 6) = 0.9446
            zeta_c30(2, 6) = 1.0979
            zeta_c30(3, 6) = 0.8269
            zeta_c30(4, 6) = 0.9232
            zeta_c30(5, 6) = 0.8591
            zeta_c30(6, 6) = 1.014
            zeta_c30(7, 6) = 0.9276



            zeta_c60(1, 6) = 1.0876
            zeta_c60(2, 6) = 0.9501
            zeta_c60(3, 6) = 1.2246
            zeta_c60(4, 6) = 1.139
            zeta_c60(5, 6) = 1.2008
            zeta_c60(6, 6) = 0.9894
            zeta_c60(7, 6) = 1.122

            zeta_f30(1, 7) = 0.7461
            zeta_f30(2, 7) = 1.0324
            zeta_f30(3, 7) = 0.7152
            zeta_f30(4, 7) = 0.7362

            zeta_f60(1, 7) = 1.1838
            zeta_f60(2, 7) = 0.9718
            zeta_f60(3, 7) = 1.193
            zeta_f60(4, 7) = 1.1886


            zeta_c30(1, 7) = 0.8215
            zeta_c30(2, 7) = 1.1225
            zeta_c30(3, 7) = 0.717
            zeta_c30(4, 7) = 0.9772
            zeta_c30(5, 7) = 0.7284
            zeta_c30(6, 7) = 1.2852
            zeta_c30(7, 7) = 0.8117



            zeta_c60(1, 7) = 1.1283
            zeta_c60(2, 7) = 0.9255
            zeta_c60(3, 7) = 1.1876
            zeta_c60(4, 7) = 1.127
            zeta_c60(5, 7) = 1.1915
            zeta_c60(6, 7) = 0.8052
            zeta_c60(7, 7) = 1.1241

            zeta_f30(1, 8) = 0.8567
            zeta_f30(2, 8) = 1
            zeta_f30(3, 8) = 0.7805
            zeta_f30(4, 8) = 0.8398

            zeta_f60(1, 8) = 1.1992
            zeta_f60(2, 8) = 0.9854
            zeta_f60(3, 8) = 1.2916
            zeta_f60(4, 8) = 1.2284


            zeta_c30(1, 8) = 0.9265
            zeta_c30(2, 8) = 1.1039
            zeta_c30(3, 8) = 0.7733
            zeta_c30(4, 8) = 1.0384
            zeta_c30(5, 8) = 0.8203
            zeta_c30(6, 8) = 1.1708
            zeta_c30(7, 8) = 0.9096



            zeta_c60(1, 8) = 1.1072
            zeta_c60(2, 8) = 0.9389
            zeta_c60(3, 8) = 1.2966
            zeta_c60(4, 8) = 1.0674
            zeta_c60(5, 8) = 1.2468
            zeta_c60(6, 8) = 0.8232
            zeta_c60(7, 8) = 1.1448

            zeta_f30(1, 9) = 0.9591
            zeta_f30(2, 9) = 1
            zeta_f30(3, 9) = 0.9058
            zeta_f30(4, 9) = 0.9598

            zeta_f60(1, 9) = 1.0672
            zeta_f60(2, 9) = 1
            zeta_f60(3, 9) = 1.1302
            zeta_f60(4, 9) = 1.0784


            zeta_c30(1, 9) = 0.99
            zeta_c30(2, 9) = 1.1039
            zeta_c30(3, 9) = 0.8988
            zeta_c30(4, 9) = 0.9731
            zeta_c30(5, 9) = 0.9402
            zeta_c30(6, 9) = 1.0019
            zeta_c30(7, 9) = 0.999



            zeta_c60(1, 9) = 1.0281
            zeta_c60(2, 9) = 0.9407
            zeta_c60(3, 9) = 1.1368
            zeta_c60(4, 9) = 1.067
            zeta_c60(5, 9) = 1.0955
            zeta_c60(6, 9) = 1.0068
            zeta_c60(7, 9) = 1.0432

            zeta_f30(1, 10) = 0.8695
            zeta_f30(2, 10) = 1.0049
            zeta_f30(3, 10) = 0.8018
            zeta_f30(4, 10) = 0.8549

            zeta_f60(1, 10) = 1.1829
            zeta_f60(2, 10) = 0.9896
            zeta_f60(3, 10) = 1.2611
            zeta_f60(4, 10) = 1.2092


            zeta_c30(1, 10) = 0.9348
            zeta_c30(2, 10) = 1.0993
            zeta_c30(3, 10) = 0.7966
            zeta_c30(4, 10) = 0.9526
            zeta_c30(5, 10) = 0.8384
            zeta_c30(6, 10) = 1.0789
            zeta_c30(7, 10) = 0.9146



            zeta_c60(1, 10) = 1.0979
            zeta_c60(2, 10) = 0.9442
            zeta_c60(3, 10) = 1.2635
            zeta_c60(4, 10) = 1.1182
            zeta_c60(5, 10) = 1.2274
            zeta_c60(6, 10) = 0.9146
            zeta_c60(7, 10) = 1.1369


            zeta_f30(1, 11) = 0.9568
            zeta_f30(2, 11) = 0.9997
            zeta_f30(3, 11) = 0.9056
            zeta_f30(4, 11) = 0.9566

            zeta_f60(1, 11) = 1.0742
            zeta_f60(2, 11) = 1
            zeta_f60(3, 11) = 1.1325
            zeta_f60(4, 11) = 1.0858


            zeta_c30(1, 11) = 0.9893
            zeta_c30(2, 11) = 1.109
            zeta_c30(3, 11) = 0.9013
            zeta_c30(4, 11) = 0.9649
            zeta_c30(5, 11) = 0.939
            zeta_c30(6, 11) = 1.0048
            zeta_c30(7, 11) = 0.9956



            zeta_c60(1, 11) = 1.0314
            zeta_c60(2, 11) = 0.9411
            zeta_c60(3, 11) = 1.136
            zeta_c60(4, 11) = 1.08
            zeta_c60(5, 11) = 1.1032
            zeta_c60(6, 11) = 1.0044
            zeta_c60(7, 11) = 1.0503


            zeta_f30(1, 12) = 0.8466
            zeta_f30(2, 12) = 1.0104
            zeta_f30(3, 12) = 0.7916
            zeta_f30(4, 12) = 0.8319

            zeta_f60(1, 12) = 1.194
            zeta_f60(2, 12) = 0.989
            zeta_f60(3, 12) = 1.2431
            zeta_f60(4, 12) = 1.2126


            zeta_c30(1, 12) = 0.9151
            zeta_c30(2, 12) = 1.1013
            zeta_c30(3, 12) = 0.7897
            zeta_c30(4, 12) = 0.9371
            zeta_c30(5, 12) = 0.8183
            zeta_c30(6, 12) = 1.1254
            zeta_c30(7, 12) = 0.8948



            zeta_c60(1, 12) = 1.1112
            zeta_c60(2, 12) = 0.9432
            zeta_c60(3, 12) = 1.2401
            zeta_c60(4, 12) = 1.1397
            zeta_c60(5, 12) = 1.2251
            zeta_c60(6, 12) = 0.8858
            zeta_c60(7, 12) = 1.1374


            zeta_f30(1, 13) = 0.8316
            zeta_f30(2, 13) = 1.0168
            zeta_f30(3, 13) = 0.763
            zeta_f30(4, 13) = 0.813

            zeta_f60(1, 13) = 1.2113
            zeta_f60(2, 13) = 0.9934
            zeta_f60(3, 13) = 1.2796
            zeta_f60(4, 13) = 1.2359


            zeta_c30(1, 13) = 0.9068
            zeta_c30(2, 13) = 1.1062
            zeta_c30(3, 13) = 0.7588
            zeta_c30(4, 13) = 1.0344
            zeta_c30(5, 13) = 0.7963
            zeta_c30(6, 13) = 1.2207
            zeta_c30(7, 13) = 0.8862



            zeta_c60(1, 13) = 1.1198
            zeta_c60(2, 13) = 0.9388
            zeta_c60(3, 13) = 1.2802
            zeta_c60(4, 13) = 1.0948
            zeta_c60(5, 13) = 1.2504
            zeta_c60(6, 13) = 0.8018
            zeta_c60(7, 13) = 1.1508


            zeta_f30(1, 14) = 0.9422
            zeta_f30(2, 14) = 0.9929
            zeta_f30(3, 14) = 0.8799
            zeta_f30(4, 14) = 0.9388

            zeta_f60(1, 14) = 1.0895
            zeta_f60(2, 14) = 0.9939
            zeta_f60(3, 14) = 1.1618
            zeta_f60(4, 14) = 1.1038


            zeta_c30(1, 14) = 0.9805
            zeta_c30(2, 14) = 1.1104
            zeta_c30(3, 14) = 0.8724
            zeta_c30(4, 14) = 0.9866
            zeta_c30(5, 14) = 0.9202
            zeta_c30(6, 14) = 1.0484
            zeta_c30(7, 14) = 0.9813



            zeta_c60(1, 14) = 1.04
            zeta_c60(2, 14) = 0.9382
            zeta_c60(3, 14) = 1.1675
            zeta_c60(4, 14) = 1.064
            zeta_c60(5, 14) = 1.1217
            zeta_c60(6, 14) = 0.9471
            zeta_c60(7, 14) = 1.0613


            zeta_f30(1, 15) = 0.905
            zeta_f30(2, 15) = 0.9997
            zeta_f30(3, 15) = 0.8406
            zeta_f30(4, 15) = 0.8947

            zeta_f60(1, 15) = 1.1354
            zeta_f60(2, 15) = 0.9852
            zeta_f60(3, 15) = 1.2083
            zeta_f60(4, 15) = 1.1576


            zeta_c30(1, 15) = 0.9583
            zeta_c30(2, 15) = 1.1076
            zeta_c30(3, 15) = 0.8351
            zeta_c30(4, 15) = 0.9676
            zeta_c30(5, 15) = 0.8773
            zeta_c30(6, 15) = 1.0754
            zeta_c30(7, 15) = 0.9459

            zeta_c60(1, 15) = 1.0679
            zeta_c60(2, 15) = 0.9431
            zeta_c60(3, 15) = 1.2099
            zeta_c60(4, 15) = 1.0967
            zeta_c60(5, 15) = 1.1745
            zeta_c60(6, 15) = 0.9214
            zeta_c60(7, 15) = 1.0992

        End Sub

        Public Sub New()

            Call InitBasis()
            Call InitAcXS()
            Call InitFiXS()
            Call InitActinides()
            Call InitFission()
            Call InitZeta()

        End Sub

        Private Function lubksb(ByRef a(,) As Double, ByRef N As Integer, ByRef indx() As Integer, ByRef b() As Double) As Boolean

            Dim i As Integer
            Dim ii As Integer
            Dim ip As Integer
            Dim j As Integer
            Dim sum As Double

            ii = 0

            For i = 1 To N
                ip = indx(i)
                sum = b(ip)
                b(ip) = b(i)

                If (ii <> 0) Then
                    For j = ii To i - 1
                        sum = sum - a(i, j) * b(j)
                    Next j
                Else
                    If (sum <> 0) Then
                        ii = i
                    End If
                End If
                b(i) = sum
            Next i


            For i = N To 1 Step -1
                sum = b(i)

                For j = i + 1 To N
                    sum = sum - a(i, j) * b(j)
                Next j

                b(i) = sum / a(i, i)
            Next i

        End Function

        Private Function ludcmp(ByRef a(,) As Double, ByRef N As Integer, ByRef indx() As Integer, ByRef d As Double) As Boolean

            Dim i As Integer
            Dim imax As Integer
            Dim j As Integer
            Dim k As Integer

            Dim big As Double
            Dim dum As Double
            Dim sum As Double
            Dim temp As Double

            Dim TINY As Double
            Dim vv() As Double

            ReDim vv(N)

            TINY = 1.0E-20
            d = 1.0#

            For i = 1 To N
                big = 0.0#

                For j = 1 To N
                    temp = Math.Abs(a(i, j))
                    If (temp > big) Then
                        big = temp
                    End If
                Next j

                If (big = 0.0#) Then
                    'MsgBox("Singular matrix in routine ludcmp")
                    Exit Function
                End If

                vv(i) = 1.0# / big
            Next i


            For j = 1 To N
                For i = 1 To j - 1
                    sum = a(i, j)

                    For k = 1 To i - 1
                        sum = sum - a(i, k) * a(k, j)
                    Next k

                    a(i, j) = sum
                Next i

                big = 0.0#

                For i = j To N
                    sum = a(i, j)
                    For k = 1 To j - 1
                        sum = sum - a(i, k) * a(k, j)
                    Next k
                    a(i, j) = sum

                    dum = vv(i) * Math.Abs(sum)
                    If (dum >= big) Then
                        big = dum
                        imax = i
                    End If

                Next i

                If (j <> imax) Then
                    For k = 1 To N
                        dum = a(imax, k)
                        a(imax, k) = a(j, k)
                        a(j, k) = dum
                    Next k

                    d = -1.0# * d
                    vv(imax) = vv(j)
                End If

                indx(j) = imax
                If (a(j, j) = 0.0#) Then
                    a(j, j) = TINY
                End If

                If (j <> N) Then
                    dum = 1.0# / a(j, j)
                    For i = j + 1 To N
                        a(i, j) = a(i, j) * dum
                    Next i
                End If

            Next j

        End Function

        Public Function SolveLinear(ByRef M(,) As Double, ByRef N As Integer, ByRef b() As Double) As Boolean

            Dim indx() As Integer
            ReDim indx(N)

            Dim d As Double

            Call ludcmp(M, N, indx, d)
            Call lubksb(M, N, indx, b)


        End Function


        Public Function FindTetraeder(ByVal f As Double, ByVal q As Double, ByVal v As Double) As Integer

            Dim i, k As Integer
            Dim fla As Integer

            Dim Pfqv(3) As Double
            Dim alphas(3) As Double
            Dim M(3, 3) As Double

            fla = 0

            Pfqv(1) = f
            Pfqv(2) = q
            Pfqv(3) = v

            For i = 1 To 3
                Pfqv(i) = Pfqv(i) - fgv(15, i)
            Next i

            For k = 1 To 24

                For i = 1 To 3
                    alphas(i) = Pfqv(i)
                Next i

                For i = 1 To 3
                    M(i, 1) = fgv(tetra(k, 1), i) - fgv(15, i)
                    M(i, 2) = fgv(tetra(k, 2), i) - fgv(15, i)
                    M(i, 3) = fgv(tetra(k, 3), i) - fgv(15, i)
                Next i

                Call SolveLinear(M, 3, alphas)

                If (alphas(1) >= 0 And alphas(2) >= 0 And alphas(3) >= 0 And (alphas(1) + alphas(2) + alphas(3)) <= 1) Then
                    alp(1) = alphas(1)
                    alp(2) = alphas(2)
                    alp(3) = alphas(3)
                    fla = k
                    Exit For
                End If

            Next k

            If (fla = 0) Then
                ' Call MsgBox("No suitable tetraeder was found!")
            End If

            tetraeder = fla
            FindTetraeder = fla


        End Function

        Public Function GetAlpha(ByVal N As Integer) As Double
            GetAlpha = alp(N)
        End Function


        Public Function GetStuetze(ByVal N As Integer) As Integer
            GetStuetze = tetra(tetraeder, N)
        End Function


        Public Function GetAcXSf(ByVal N As Integer, ByVal burnup As Double) As Double

            Dim sigma As Double
            Dim zeta30 As Double
            Dim zeta60 As Double
            Dim zeta As Double
            Dim kk As Integer

            zeta = 1

            sigma = Ac_XSf(N, 15) + alp(1) * (Ac_XSf(N, tetra(tetraeder, 1)) - Ac_XSf(N, 15)) + alp(2) * (Ac_XSf(N, tetra(tetraeder, 2)) - Ac_XSf(N, 15)) + alp(3) * (Ac_XSf(N, tetra(tetraeder, 3)) - Ac_XSf(N, 15))


            If (N = 13 Or N = 11 Or N = 5 Or N = 2) Then

                If (N = 13) Then
                    kk = 4
                End If

                If (N = 11) Then
                    kk = 3
                End If

                If (N = 5) Then
                    kk = 2
                End If

                If (N = 2) Then
                    kk = 1
                End If

                zeta30 = zeta_f30(kk, 15) + alp(1) * (zeta_f30(kk, tetra(tetraeder, 1)) - zeta_f30(kk, 15)) + alp(2) * (zeta_f30(kk, tetra(tetraeder, 2)) - zeta_f30(kk, 15)) + alp(3) * (zeta_f30(kk, tetra(tetraeder, 3)) - zeta_f30(kk, 15))
                zeta60 = zeta_f60(kk, 15) + alp(1) * (zeta_f60(kk, tetra(tetraeder, 1)) - zeta_f60(kk, 15)) + alp(2) * (zeta_f60(kk, tetra(tetraeder, 2)) - zeta_f60(kk, 15)) + alp(3) * (zeta_f60(kk, tetra(tetraeder, 3)) - zeta_f60(kk, 15))

                If (burnup <= 30) Then
                    zeta = 1.0# - (((30.0# - burnup) / 30.0#) * (1.0# - zeta30))
                Else
                    zeta = 1.0# - (((burnup - 30.0#) / 30.0#) * (1.0# - zeta60))
                End If

            End If

            GetAcXSf = sigma * zeta

        End Function

        Public Function GetAcXSc(ByVal N As Integer, ByVal burnup As Double) As Double

            Dim sigma As Double
            Dim zeta30 As Double
            Dim zeta60 As Double
            Dim zeta As Double
            Dim kk As Integer

            zeta = 1

            sigma = Ac_XSc(N, 15) + alp(1) * (Ac_XSc(N, tetra(tetraeder, 1)) - Ac_XSc(N, 15)) + alp(2) * (Ac_XSc(N, tetra(tetraeder, 2)) - Ac_XSc(N, 15)) + alp(3) * (Ac_XSc(N, tetra(tetraeder, 3)) - Ac_XSc(N, 15))

            If (N = 16 Or N = 14 Or N = 13 Or N = 12 Or N = 11 Or N = 3 Or N = 2) Then

                If (N = 16) Then
                    kk = 7
                End If

                If (N = 14) Then
                    kk = 6
                End If

                If (N = 13) Then
                    kk = 5
                End If

                If (N = 12) Then
                    kk = 4
                End If

                If (N = 11) Then
                    kk = 3
                End If

                If (N = 3) Then
                    kk = 2
                End If

                If (N = 2) Then
                    kk = 1
                End If


                zeta30 = zeta_c30(kk, 15) + alp(1) * (zeta_c30(kk, tetra(tetraeder, 1)) - zeta_c30(kk, 15)) + alp(2) * (zeta_c30(kk, tetra(tetraeder, 2)) - zeta_c30(kk, 15)) + alp(3) * (zeta_c30(kk, tetra(tetraeder, 3)) - zeta_c30(kk, 15))
                zeta60 = zeta_c60(kk, 15) + alp(1) * (zeta_c60(kk, tetra(tetraeder, 1)) - zeta_c60(kk, 15)) + alp(2) * (zeta_c60(kk, tetra(tetraeder, 2)) - zeta_c60(kk, 15)) + alp(3) * (zeta_c60(kk, tetra(tetraeder, 3)) - zeta_c60(kk, 15))

                If (burnup <= 30) Then
                    zeta = 1 - (((30 - burnup) / 30) * (1 - zeta30))
                Else
                    zeta = 1 - (((burnup - 30) / 30) * (1 - zeta60))
                End If

            End If

            GetAcXSc = sigma * zeta

        End Function

        Public Function GetAcXSn2n(ByVal N As Integer, ByVal burnup As Double) As Double

            Dim sigma As Double

            Dim zeta As Double

            zeta = 1

            sigma = Ac_XSn2n(N, 15) + alp(1) * (Ac_XSn2n(N, tetra(tetraeder, 1)) - Ac_XSn2n(N, 15)) + alp(2) * (Ac_XSn2n(N, tetra(tetraeder, 2)) - Ac_XSn2n(N, 15)) + alp(3) * (Ac_XSn2n(N, tetra(tetraeder, 3)) - Ac_XSn2n(N, 15))

            GetAcXSn2n = sigma * zeta

        End Function

        Public Function GetFiXSc(ByVal N As Integer, ByVal burnup As Double) As Double

            Dim sigma As Double

            Dim zeta As Double

            zeta = 1

            sigma = fi_XSc(N, 15) + alp(1) * (fi_XSc(N, tetra(tetraeder, 1)) - fi_XSc(N, 15)) + alp(2) * (fi_XSc(N, tetra(tetraeder, 2)) - fi_XSc(N, 15)) + alp(3) * (fi_XSc(N, tetra(tetraeder, 3)) - fi_XSc(N, 15))

            GetFiXSc = sigma * zeta

        End Function

        Public Function FindPhi(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(21) As Double
            Dim cap(21) As Double
            Dim capR(21) As Double
            Dim n2n(21) As Double
            Dim n2nR(21) As Double
            Dim sigmas(21, 21) As Double
            Dim lambdas(21, 21) As Double
            Dim sum As Double
            Dim bur As Double
            Dim ri As Double
            Dim deltasum As Double
            Dim deltadays As Double
            'Dim t As Integer
            Dim tt As Integer

            Dim R(21) As Double
            Dim sig(21) As Double
            Dim ya(21) As Double
            Dim yb(21) As Double
            Dim yc(21) As Double
            Dim yd(21) As Double
            Dim ye(21) As Double
            Dim yf(21) As Double
            Dim yg(21) As Double
            Dim yh(21) As Double
            Dim ym(21) As Double
            Dim yo(21) As Double
            Dim yp(21) As Double
            Dim yq(21) As Double

            Dim My1stChain As New DIN25463silverlight.DIN25463MOX.ActinideChain01
            Dim My2ndChain As New DIN25463silverlight.DIN25463MOX.ActinideChain02
            Dim My3rdChain As New DIN25463silverlight.DIN25463MOX.ActinideChain03
            Dim My4thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain04
            Dim My5thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain05

            Dim My6thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain06
            Dim My7thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain07
            Dim My8thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain08
            Dim My10thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain10
            Dim My11thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain11
            Dim My12thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain12

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktion As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim ystart(21) As Double
            Dim ybeg(21) As Double

            meineFunktion = New DIN25463silverlight.DIN25463MOX.MyActinideFunktion

            Call meineFunktion.SetNVar(21)

            Call ph.GetInitialConditions(ystart)
            Call ph.GetInitialConditions(ybeg)

            ' ********** test mass inital conditions ***********************************
            'Call ph.ConvertNtoMasses(ystart)
            'For i = 1 To 21
            'Worksheets("function").Cells(30 + i, 1) = ystart(i)
            'Next i
            ' ********** test mass inital conditions ***********************************

            Call meineFunktion.SetStart(ystart)
            Call meineFunktion.SetLambda(Ac_lambda)

            bur = 0.0#
            tt = 0
            zeiten(0) = 0.0#

            Call meinIntegral.SetNVar(21)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktion.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To 21
                        fis(k) = GetAcXSf(k, bur)
                        cap(k) = GetAcXSc(k, bur)
                        n2n(k) = GetAcXSn2n(k, bur)

                    Next k

                    Call meineFunktion.SetSigma(fis, cap, n2n)
                    Call InitXN(lambdas, sigmas, bur)
                    Call meineFunktion.SetXN(lambdas, sigmas)

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktion)
                    Call meineFunktion.CalcPhi()

                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()

                    tt = tt + 1

                    phi(tt) = meineFunktion.GetPhi
                    For k = 1 To 21
                        capR(k) = cap(k) * phi(tt)
                        n2nR(k) = n2n(k) * phi(tt)
                        R(k) = Ac_lambda(k) + (cap(k) + fis(k) + n2n(k)) * phi(tt)
                    Next k
                    '#############Eindimensionale Zerfallsketten#################################################


                    '##############Erste Kette(234U-->244CM I)#############

                    Call My1stChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My1stChain.CalcChain(R, ya, deltasum)

                    '###############Zweite Kette(234U -->244CM II)################

                    Call My2ndChain.CopyMatrix(My1stChain.GetMatrix, 10)

                    Call My2ndChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My2ndChain.CalcChain(R, yb, deltasum)


                    '###############Dritte Kette(234U -->244CM III)################

                    Call My3rdChain.CopyMatrix(My2ndChain.GetMatrix, 10)

                    Call My3rdChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My3rdChain.CalcChain(R, yc, deltasum)


                    '###############Vierte Kette(234U -->242CM)################

                    Call My4thChain.CopyMatrix(My2ndChain.GetMatrix, 12)

                    Call My4thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My4thChain.CalcChain(R, yd, deltasum)


                    '###############Fünfte Kette(238U -->244CM I)################

                    Call My5thChain.Init_chain(ybeg, capR, R, Ac_lambda, n2nR)
                    Call My5thChain.CalcChain(R, ye, deltasum)


                    '###############Sechste Kette(238U -->244CM II)################

                    Call My6thChain.CopyMatrix(My5thChain.GetMatrix, 8)

                    Call My6thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My6thChain.CalcChain(R, yf, deltasum)


                    '###############Siebte Kette(238U -->244CM III)################

                    Call My7thChain.CopyMatrix(My6thChain.GetMatrix, 10)

                    Call My7thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My7thChain.CalcChain(R, yg, deltasum)


                    '###############Achte Kette(238U -->242CM I)################

                    Call My8thChain.CopyMatrix(My7thChain.GetMatrix, 10)

                    Call My8thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My8thChain.CalcChain(R, yh, deltasum)


                    '###############Neunte Kette(238U -->244CM IV)################

                    Dim My9thChain As New ActinideChain09

                    Call My9thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My9thChain.CalcChain(R, ym, deltasum)



                    '###############Zehnte Kette(238U -->244CM V)################

                    Call My10thChain.CopyMatrix(My9thChain.GetMatrix, 6)

                    Call My10thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My10thChain.CalcChain(R, yo, deltasum)


                    '###############Elfte Kette(238U -->244CM VI)################

                    Call My11thChain.CopyMatrix(My10thChain.GetMatrix, 8)

                    Call My11thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My11thChain.CalcChain(R, yp, deltasum)


                    '###############Zwölfte Kette(238U -->242CM II)######################

                    Call My12thChain.CopyMatrix(My11thChain.GetMatrix, 8)

                    Call My12thChain.Init_chain(ybeg, capR, R, Ac_lambda)
                    Call My12thChain.CalcChain(R, yq, deltasum)


                    '############Summation der einzelnen Ketten###########################

                    For k = 1 To 21
                        ybeg(k) = ya(k) + yb(k) + yc(k) + yd(k) + ye(k) + yf(k) + yg(k) + yh(k) + ym(k) + yo(k) + yp(k) + yq(k)
                    Next k

                    Call meineFunktion.SetStart(ybeg)

                    ' ############# END of single decay chains ###########################

                    Nk(tt, 1) = meineFunktion.GetStart(2)
                    Nk(tt, 2) = meineFunktion.GetStart(5)
                    Nk(tt, 3) = meineFunktion.GetStart(11)
                    Nk(tt, 4) = meineFunktion.GetStart(13)

                    zeiten(tt) = zeiten(tt - 1) + deltadays
                    zeit = tt

                Next j
                ' *** stop burnup subloop ********************************************

                ' *** calculate Rik at the end of every big burnup interval
                Rik(1, i) = fis(2) * meineFunktion.GetPhi() * meineFunktion.GetStart(2)
                Rik(2, i) = fis(5) * meineFunktion.GetPhi() * meineFunktion.GetStart(5)
                Rik(3, i) = fis(11) * meineFunktion.GetPhi() * meineFunktion.GetStart(11)
                Rik(4, i) = fis(13) * meineFunktion.GetPhi() * meineFunktion.GetStart(13)

                ri = 0
                For k = 1 To 21
                    ri = ri + fis(k) * meineFunktion.GetStart(k)
                Next k

                Rik(1, i) = Rik(1, i) * ri
                Rik(2, i) = Rik(2, i) * ri
                Rik(3, i) = Rik(3, i) * ri
                Rik(4, i) = Rik(4, i) * ri

                ri = fis(2) * meineFunktion.GetStart(2) + fis(5) * meineFunktion.GetStart(5) + fis(11) * meineFunktion.GetStart(11) + fis(13) * meineFunktion.GetStart(13)

                Rik(1, i) = Rik(1, i) / ri
                Rik(2, i) = Rik(2, i) / ri
                Rik(3, i) = Rik(3, i) / ri
                Rik(4, i) = Rik(4, i) / ri

            Next i
            ' *** stop big burnup loop ******************************************


            For i = 1 To 21
                ystart(i) = meineFunktion.GetStart(i)
                NAct(i) = meineFunktion.GetStart(i)
                NActDecay(i) = meineFunktion.GetStart(i)
            Next i

        End Function

        Public Function FindPhiDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer

            Dim fis(21) As Double
            Dim cap(21) As Double
            Dim n2n(21) As Double
            Dim sigmas(21, 21) As Double
            Dim lambdas(21, 21) As Double

            Dim R(21) As Double
            Dim sig(21) As Double
            Dim ya(21) As Double
            Dim yb(21) As Double
            Dim yc(21) As Double
            Dim yd(21) As Double
            Dim ye(21) As Double
            Dim yf(21) As Double
            Dim yg(21) As Double
            Dim yh(21) As Double
            Dim ym(21) As Double
            Dim yo(21) As Double
            Dim yp(21) As Double
            Dim yq(21) As Double

            Dim My1stChain As New DIN25463silverlight.DIN25463MOX.ActinideChain01
            Dim My2ndChain As New DIN25463silverlight.DIN25463MOX.ActinideChain02
            Dim My3rdChain As New DIN25463silverlight.DIN25463MOX.ActinideChain03
            Dim My4thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain04
            Dim My5thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain05

            Dim My6thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain06
            Dim My7thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain07
            Dim My8thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain08
            Dim My10thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain10
            Dim My11thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain11
            Dim My12thChain As New DIN25463silverlight.DIN25463MOX.ActinideChain12

            Dim deltasum As Double
            Dim ta As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktion As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim ystart(21) As Double
            Dim ybeg(21) As Double

            meineFunktion = New DIN25463silverlight.DIN25463MOX.MyActinideDecayFunktion

            Call meineFunktion.SetNVar(21)

            Call meineFunktion.SetStart(NActDecay)
            Call meineFunktion.SetLambda(Ac_lambda)

            Call meinIntegral.SetNVar(21)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            For i = 1 To 21
                ybeg(i) = NActDecay(i)
            Next i

            ' *** start big burnup loop ******************************************
            'For i = 1 To ph.GetN

            Call meineFunktion.SetPower(0.0#)

            'deltasum = ph.GetInterval(i)
            deltasum = ph.GetAbklang
            ta = deltasum
            ' *** calc burnup dependent XS ****************************************
            For k = 1 To 21
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
                R(k) = Ac_lambda(k)
            Next k

            Call meineFunktion.SetSigma(fis, cap, n2n)
            Call InitXN(lambdas, sigmas, 0.0#)
            Call meineFunktion.SetXN(lambdas, sigmas)

            'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktion)

            '#############Eindimensionale Zerfallsketten#################################################


            '##############Erste Kette(234U-->244CM I)#############

            Call My1stChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My1stChain.CalcChain(R, ya, ta)

            '###############Zweite Kette(234U -->244CM II)################

            Call My2ndChain.CopyMatrix(My1stChain.GetMatrix, 10)

            Call My2ndChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My2ndChain.CalcChain(R, yb, ta)


            '###############Dritte Kette(234U -->244CM III)################

            Call My3rdChain.CopyMatrix(My2ndChain.GetMatrix, 10)

            Call My3rdChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My3rdChain.CalcChain(R, yc, ta)


            '###############Vierte Kette(234U -->242CM)################

            Call My4thChain.CopyMatrix(My2ndChain.GetMatrix, 12)

            Call My4thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My4thChain.CalcChain(R, yd, ta)


            '###############Fünfte Kette(238U -->244CM I)################

            Call My5thChain.Init_chain(ybeg, cap, R, Ac_lambda, n2n)
            Call My5thChain.CalcChain(R, ye, ta)


            '###############Sechste Kette(238U -->244CM II)################

            Call My6thChain.CopyMatrix(My5thChain.GetMatrix, 8)

            Call My6thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My6thChain.CalcChain(R, yf, ta)


            '###############Siebte Kette(238U -->244CM III)################

            Call My7thChain.CopyMatrix(My6thChain.GetMatrix, 10)

            Call My7thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My7thChain.CalcChain(R, yg, ta)


            '###############Achte Kette(238U -->242CM I)################

            Call My8thChain.CopyMatrix(My7thChain.GetMatrix, 10)

            Call My8thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My8thChain.CalcChain(R, yh, ta)


            '###############Neunte Kette(238U -->244CM IV)################

            Dim My9thChain As New ActinideChain09

            Call My9thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My9thChain.CalcChain(R, ym, ta)



            '###############Zehnte Kette(238U -->244CM V)################

            Call My10thChain.CopyMatrix(My9thChain.GetMatrix, 6)

            Call My10thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My10thChain.CalcChain(R, yo, ta)


            '###############Elfte Kette(238U -->244CM VI)################

            Call My11thChain.CopyMatrix(My10thChain.GetMatrix, 8)

            Call My11thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My11thChain.CalcChain(R, yp, ta)


            '###############Zwölfte Kette(238U -->242CM II)################

            Call My12thChain.CopyMatrix(My11thChain.GetMatrix, 8)

            Call My12thChain.Init_chain(ybeg, cap, R, Ac_lambda)
            Call My12thChain.CalcChain(R, yq, ta)


            '############Summation der einzelnen Ketten###############

            For k = 1 To 21
                ybeg(k) = ya(k) + yb(k) + yc(k) + yd(k) + ye(k) + yf(k) + yg(k) + yh(k) + ym(k) + yo(k) + yp(k) + yq(k)
            Next k

            Call meineFunktion.SetStart(ybeg)

            'Next i
            ' *** stop big burnup loop ******************************************


            For i = 1 To 21
                ystart(i) = meineFunktion.GetStart(i)
                NActDecay(i) = meineFunktion.GetStart(i)
            Next i

        End Function


        Public Function FindFissionXe(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyXeChain As New FissionChainXe

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NXe As Integer
            Dim zeit As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionXe As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double
            Dim ystart(8) As Double

            NXe = 8

            meineFunktionXe = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionXe.SetNVar(NXe)

            For i = 1 To NXe
                ystart(i) = 0
                ybeg(15 + i) = 0
                My_lambda(i) = fi_lambda(15 + i)
                My_yfi(1, i) = fi_y(1, 15 + i)
                My_yfi(2, i) = fi_y(2, 15 + i)
                My_yfi(3, i) = fi_y(3, 15 + i)
                My_yfi(4, i) = fi_y(4, 15 + i)
            Next i

            Call meineFunktionXe.SetStart(ystart)
            Call meineFunktionXe.SetLambda(My_lambda)
            Call meineFunktionXe.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NXe)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionXe.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NXe
                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(15 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NXe + 1) = GetAcXSf(2, bur)
                    fis(NXe + 2) = GetAcXSf(5, bur)
                    fis(NXe + 3) = GetAcXSf(11, bur)
                    fis(NXe + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionXe.SetSigma(fis, cap, n2n)
                    Call InitXeXN(lambdas, sigmas, bur)
                    Call meineFunktionXe.SetXN(lambdas, sigmas)
                    Call meineFunktionXe.SetNk(Nfiss)
                    Call meineFunktionXe.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionXe)

                    ' ############ Xe Chain ###################################
                    For k = 1 To NXe
                        R(15 + k) = fi_lambda(15 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionXe.GetPhi()
                        capR(15 + k) = cap(k) * meineFunktionXe.GetPhi()
                        zeta(15 + k) = (My_yfi(1, k) * fis(NXe + 1) * Nfiss(1) + My_yfi(2, k) * fis(NXe + 2) * Nfiss(2) + My_yfi(3, k) * fis(NXe + 3) * Nfiss(3) + My_yfi(4, k) * fis(NXe + 4) * Nfiss(4)) * meineFunktionXe.GetPhi()
                    Next k

                    If (meineFunktionXe.GetPhi() > MyTiny) Then
                        Call MyXeChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyXeChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyXeChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyXeChain.CalcChain(R, ya, deltasum)
                    End If


                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k

                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************


            For i = 1 To NXe
                NXenon(i) = meineFunktionXe.GetStart(i)
                NXenonDecay(i) = meineFunktionXe.GetStart(i)
            Next i

        End Function

        Public Function GetXenonDensity(ByVal i As Integer) As Double
            GetXenonDensity = NXenon(i)
        End Function

        Public Function GetXenonDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 8
                y(i) = NXenon(i)
            Next i

        End Function


        Public Function FindFissionXeDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NXe As Integer

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyXeChain As New FissionChainXe

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionXe As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double
            Dim ystart(8) As Double
            Dim ta As Double

            NXe = 8

            meineFunktionXe = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionXe.SetNVar(NXe)

            For i = 1 To NXe
                My_lambda(i) = fi_lambda(15 + i)
                ybeg(i + 15) = NXenonDecay(i)
                My_yfi(1, i) = 0.0#
                My_yfi(2, i) = 0.0#
                My_yfi(3, i) = 0.0#
                My_yfi(4, i) = 0.0#
            Next i

            Call meineFunktionXe.SetStart(NXenonDecay)
            Call meineFunktionXe.SetLambda(My_lambda)
            Call meineFunktionXe.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NXe)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            ' *** start big burnup loop ******************************************
            'For i = 1 To ph.GetN

            Call meineFunktionXe.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()

            ' *** start small burnup loop *****************************************

            For k = 1 To NXe
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NXe + 1) = GetAcXSf(2, 0.0#)
            fis(NXe + 2) = GetAcXSf(5, 0.0#)
            fis(NXe + 3) = GetAcXSf(11, 0.0#)
            fis(NXe + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionXe.SetSigma(fis, cap, n2n)
            Call InitXeXN(lambdas, sigmas, 0.0#)
            Call meineFunktionXe.SetXN(lambdas, sigmas)
            Call meineFunktionXe.SetNk(Nfiss)
            Call meineFunktionXe.SetPhi(0.0#)

            'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionXe)
            ' ############ Xe Chain ###################################
            For k = 1 To NXe
                R(15 + k) = fi_lambda(15 + k)
                capR(15 + k) = 0.0#
                zeta(15 + k) = 0
            Next k

            Call MyXeChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyXeChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k

            For k = 1 To NXe
                NXenonDecay(k) = ybeg(15 + k)
            Next k
            Call meineFunktionXe.SetStart(NXenonDecay)

            'Next i
            ' *** stop big burnup loop ******************************************

            For i = 1 To NXe
                NXenonDecay(i) = meineFunktionXe.GetStart(i)
            Next i

        End Function

        Public Function GetXenonDecDensity(ByVal i As Integer) As Double
            GetXenonDecDensity = NXenonDecay(i)
        End Function


        Public Function FindFissionZr(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyZrChain As New FissionChainZr

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NZr As Integer
            Dim zeit As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionZr As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double
            Dim ystart(3) As Double

            NZr = 3

            meineFunktionZr = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionZr.SetNVar(NZr)

            For i = 1 To NZr
                ystart(i) = 0
                ybeg(0 + i) = 0
                My_lambda(i) = fi_lambda(0 + i)
                My_yfi(1, i) = fi_y(1, 0 + i)
                My_yfi(2, i) = fi_y(2, 0 + i)
                My_yfi(3, i) = fi_y(3, 0 + i)
                My_yfi(4, i) = fi_y(4, 0 + i)
            Next i

            Call meineFunktionZr.SetStart(ystart)
            Call meineFunktionZr.SetLambda(My_lambda)
            Call meineFunktionZr.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NZr)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionZr.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NZr
                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(0 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NZr + 1) = GetAcXSf(2, bur)
                    fis(NZr + 2) = GetAcXSf(5, bur)
                    fis(NZr + 3) = GetAcXSf(11, bur)
                    fis(NZr + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionZr.SetSigma(fis, cap, n2n)
                    Call InitZrXN(lambdas, sigmas, bur)
                    Call meineFunktionZr.SetXN(lambdas, sigmas)
                    Call meineFunktionZr.SetNk(Nfiss)
                    Call meineFunktionZr.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    ' Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionZr)

                    ' ############ Zr Chain ###################################
                    For k = 1 To NZr
                        R(0 + k) = fi_lambda(0 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionZr.GetPhi()
                        capR(0 + k) = cap(k) * meineFunktionZr.GetPhi()
                        zeta(0 + k) = (My_yfi(1, k) * fis(NZr + 1) * Nfiss(1) + My_yfi(2, k) * fis(NZr + 2) * Nfiss(2) + My_yfi(3, k) * fis(NZr + 3) * Nfiss(3) + My_yfi(4, k) * fis(NZr + 4) * Nfiss(4)) * meineFunktionZr.GetPhi()
                    Next k


                    If (meineFunktionZr.GetPhi() > MyTiny) Then
                        Call MyZrChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyZrChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyZrChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyZrChain.CalcChain(R, ya, deltasum)
                    End If

                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k

                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************

            For k = 1 To NZr
                NZircon(k) = ybeg(0 + k)
            Next k
            Call meineFunktionZr.SetStart(NZircon)


            For i = 1 To NZr
                NZircon(i) = meineFunktionZr.GetStart(i)
                NZirconDecay(i) = meineFunktionZr.GetStart(i)
            Next i

        End Function

        Public Function GetZirconDensity(ByVal i As Integer) As Double
            GetZirconDensity = NZircon(i)
        End Function

        Public Function GetZirconDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 3
                y(i) = NZircon(i)
            Next i

        End Function

        Public Function FindFissionZrDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer


            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyZrChain As New FissionChainZr

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NZr As Integer

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionZr As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double
            Dim ystart(3) As Double
            Dim ta As Double

            NZr = 3

            meineFunktionZr = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionZr.SetNVar(NZr)

            For i = 1 To NZr
                My_lambda(i) = fi_lambda(0 + i)
                ybeg(i) = NZirconDecay(i)
                My_yfi(1, i) = 0.0#
                My_yfi(2, i) = 0.0#
                My_yfi(3, i) = 0.0#
                My_yfi(4, i) = 0.0#
            Next i

            Call meineFunktionZr.SetStart(NZirconDecay)
            Call meineFunktionZr.SetLambda(My_lambda)
            Call meineFunktionZr.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NZr)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)


            ' *** start big burnup loop ******************************************
            'For i = 1 To ph.GetN

            Call meineFunktionZr.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()
            ' *** start small burnup loop *****************************************

            For k = 1 To NZr
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NZr + 1) = GetAcXSf(2, 0.0#)
            fis(NZr + 2) = GetAcXSf(5, 0.0#)
            fis(NZr + 3) = GetAcXSf(11, 0.0#)
            fis(NZr + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionZr.SetSigma(fis, cap, n2n)
            Call InitZrXN(lambdas, sigmas, 0.0#)
            Call meineFunktionZr.SetXN(lambdas, sigmas)
            Call meineFunktionZr.SetNk(Nfiss)
            Call meineFunktionZr.SetPhi(0.0#)


            'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionZr)
            ' ############ Zr Chain ###################################
            For k = 1 To NZr
                R(0 + k) = fi_lambda(0 + k)
                capR(0 + k) = 0.0#
                zeta(0 + k) = 0
            Next k

            Call MyZrChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyZrChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k

            For k = 1 To NZr
                NZirconDecay(k) = ybeg(0 + k)
            Next k
            Call meineFunktionZr.SetStart(NZirconDecay)

            ' Next i
            ' *** stop big burnup loop ******************************************

            For i = 1 To NZr
                NZirconDecay(i) = meineFunktionZr.GetStart(i)
            Next i

        End Function

        Public Function GetZirconDecDensity(ByVal i As Integer) As Double
            GetZirconDecDensity = NZirconDecay(i)
        End Function


        Public Function FindFissionRu(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyRuChain As New FissionChainRu

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NRu As Integer
            Dim zeit As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionRu As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(6) As Double
            NRu = 6

            meineFunktionRu = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionRu.SetNVar(NRu)

            For i = 1 To NRu
                ystart(i) = 0
                ybeg(5 + i) = 0
                My_lambda(i) = fi_lambda(5 + i)
                My_yfi(1, i) = fi_y(1, 5 + i)
                My_yfi(2, i) = fi_y(2, 5 + i)
                My_yfi(3, i) = fi_y(3, 5 + i)
                My_yfi(4, i) = fi_y(4, 5 + i)
            Next i

            Call meineFunktionRu.SetStart(ystart)
            Call meineFunktionRu.SetLambda(My_lambda)
            Call meineFunktionRu.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NRu)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionRu.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NRu
                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(5 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NRu + 1) = GetAcXSf(2, bur)
                    fis(NRu + 2) = GetAcXSf(5, bur)
                    fis(NRu + 3) = GetAcXSf(11, bur)
                    fis(NRu + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionRu.SetSigma(fis, cap, n2n)
                    Call InitRuXN(lambdas, sigmas, bur)
                    Call meineFunktionRu.SetXN(lambdas, sigmas)
                    Call meineFunktionRu.SetNk(Nfiss)
                    Call meineFunktionRu.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    ' Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionRu)

                    ' ############ Ru Chain ###################################
                    For k = 1 To NRu
                        R(5 + k) = fi_lambda(5 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionRu.GetPhi()
                        capR(5 + k) = cap(k) * meineFunktionRu.GetPhi()
                        zeta(5 + k) = (My_yfi(1, k) * fis(NRu + 1) * Nfiss(1) + My_yfi(2, k) * fis(NRu + 2) * Nfiss(2) + My_yfi(3, k) * fis(NRu + 3) * Nfiss(3) + My_yfi(4, k) * fis(NRu + 4) * Nfiss(4)) * meineFunktionRu.GetPhi()
                    Next k

                    If (meineFunktionRu.GetPhi() > MyTiny) Then
                        Call MyRuChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyRuChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyRuChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyRuChain.CalcChain(R, ya, deltasum)
                    End If

                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k

                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************
            For k = 1 To NRu
                NRuthenium(k) = ybeg(5 + k)
            Next k
            Call meineFunktionRu.SetStart(NRuthenium)


            For i = 1 To NRu
                NRuthenium(i) = meineFunktionRu.GetStart(i)
                NRutheniumDecay(i) = meineFunktionRu.GetStart(i)
            Next i

        End Function

        Public Function GetRutheniumDensity(ByVal i As Integer) As Double
            GetRutheniumDensity = NRuthenium(i)
        End Function

        Public Function GetRutheniumDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 6
                y(i) = NRuthenium(i)
            Next i

        End Function

        Public Function FindFissionRuDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NRu As Integer

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyRuChain As New FissionChainRu

            Dim ta As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionRu As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(6) As Double
            NRu = 6

            meineFunktionRu = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionRu.SetNVar(NRu)

            For i = 1 To NRu
                My_lambda(i) = fi_lambda(5 + i)
                ybeg(i + 5) = NRutheniumDecay(i)
                My_yfi(1, i) = 0.0#
                My_yfi(2, i) = 0.0#
                My_yfi(3, i) = 0.0#
                My_yfi(4, i) = 0.0#
            Next i

            Call meineFunktionRu.SetStart(NRutheniumDecay)
            Call meineFunktionRu.SetLambda(My_lambda)
            Call meineFunktionRu.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NRu)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            ' *** start big burnup loop ******************************************
            'For i = 1 To ph.GetN

            Call meineFunktionRu.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()

            ' *** calc burnup dependent XS ****************************************
            For k = 1 To NRu
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NRu + 1) = GetAcXSf(2, 0.0#)
            fis(NRu + 2) = GetAcXSf(5, 0.0#)
            fis(NRu + 3) = GetAcXSf(11, 0.0#)
            fis(NRu + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionRu.SetSigma(fis, cap, n2n)
            Call InitRuXN(lambdas, sigmas, 0.0#)
            Call meineFunktionRu.SetXN(lambdas, sigmas)
            Call meineFunktionRu.SetNk(Nfiss)
            Call meineFunktionRu.SetPhi(0.0#)

            ' Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionRu)
            ' ############ Ru Chain ###################################
            For k = 1 To NRu
                R(5 + k) = fi_lambda(5 + k)
                capR(5 + k) = 0.0#
                zeta(5 + k) = 0
            Next k

            Call MyRuChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyRuChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k

            For k = 1 To NRu
                NRutheniumDecay(k) = ybeg(5 + k)
            Next k
            Call meineFunktionRu.SetStart(NRutheniumDecay)

            'Next i
            ' *** stop big burnup loop ******************************************


            For i = 1 To NRu
                NRutheniumDecay(i) = meineFunktionRu.GetStart(i)
            Next i

        End Function

        Public Function GetRutheniumDecDensity(ByVal i As Integer) As Double
            GetRutheniumDecDensity = NRutheniumDecay(i)
        End Function

        Public Function FindFissionPd(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyPdChain As New FissionChainPd

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NPd As Integer
            Dim zeit As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionPd As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(4) As Double
            NPd = 4

            meineFunktionPd = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionPd.SetNVar(NPd)

            For i = 1 To NPd
                ystart(i) = 0
                ybeg(11 + i) = 0
                My_lambda(i) = fi_lambda(11 + i)
                My_yfi(1, i) = fi_y(1, 11 + i)
                My_yfi(2, i) = fi_y(2, 11 + i)
                My_yfi(3, i) = fi_y(3, 11 + i)
                My_yfi(4, i) = fi_y(4, 11 + i)
            Next i

            Call meineFunktionPd.SetStart(ystart)
            Call meineFunktionPd.SetLambda(My_lambda)
            Call meineFunktionPd.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NPd)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionPd.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NPd
                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(11 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NPd + 1) = GetAcXSf(2, bur)
                    fis(NPd + 2) = GetAcXSf(5, bur)
                    fis(NPd + 3) = GetAcXSf(11, bur)
                    fis(NPd + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionPd.SetSigma(fis, cap, n2n)
                    Call InitPdXN(lambdas, sigmas, bur)
                    Call meineFunktionPd.SetXN(lambdas, sigmas)
                    Call meineFunktionPd.SetNk(Nfiss)
                    Call meineFunktionPd.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    ' Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionPd)

                    ' ############ Pd Chain ###################################
                    For k = 1 To NPd
                        R(11 + k) = fi_lambda(11 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionPd.GetPhi()
                        capR(11 + k) = cap(k) * meineFunktionPd.GetPhi()
                        zeta(11 + k) = (My_yfi(1, k) * fis(NPd + 1) * Nfiss(1) + My_yfi(2, k) * fis(NPd + 2) * Nfiss(2) + My_yfi(3, k) * fis(NPd + 3) * Nfiss(3) + My_yfi(4, k) * fis(NPd + 4) * Nfiss(4)) * meineFunktionPd.GetPhi()
                    Next k

                    If (meineFunktionPd.GetPhi() > MyTiny) Then
                        Call MyPdChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyPdChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyPdChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyPdChain.CalcChain(R, ya, deltasum)
                    End If

                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k


                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************

            For k = 1 To NPd
                NPalladium(k) = ybeg(11 + k)
            Next k
            Call meineFunktionPd.SetStart(NPalladium)


            For i = 1 To NPd
                NPalladium(i) = meineFunktionPd.GetStart(i)
                NPalladiumDecay(i) = meineFunktionPd.GetStart(i)
            Next i

        End Function

        Public Function GetPalladiumDensity(ByVal i As Integer) As Double
            GetPalladiumDensity = NPalladium(i)
        End Function

        Public Function GetPalladiumDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 4
                y(i) = NPalladium(i)
            Next i

        End Function

        Public Function FindFissionPdDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer


            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NPd As Integer

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyPdChain As New FissionChainPd


            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionPd As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double
            Dim ta As Double
            Dim ystart(4) As Double
            NPd = 4

            meineFunktionPd = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionPd.SetNVar(NPd)

            For i = 1 To NPd
                My_lambda(i) = fi_lambda(11 + i)
                ybeg(i + 11) = NPalladiumDecay(i)
                My_yfi(1, i) = fi_y(1, 11 + i)
                My_yfi(2, i) = fi_y(2, 11 + i)
                My_yfi(3, i) = fi_y(3, 11 + i)
                My_yfi(4, i) = fi_y(4, 11 + i)
            Next i

            Call meineFunktionPd.SetStart(NPalladiumDecay)
            Call meineFunktionPd.SetLambda(My_lambda)
            Call meineFunktionPd.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NPd)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)


            ' *** start big burnup loop ******************************************
            'For i = 1 To ph.GetN

            Call meineFunktionPd.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()

            ' *** calc burnup dependent XS ****************************************
            For k = 1 To NPd

                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NPd + 1) = GetAcXSf(2, 0.0#)
            fis(NPd + 2) = GetAcXSf(5, 0.0#)
            fis(NPd + 3) = GetAcXSf(11, 0.0#)
            fis(NPd + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionPd.SetSigma(fis, cap, n2n)
            Call InitPdXN(lambdas, sigmas, 0.0#)
            Call meineFunktionPd.SetXN(lambdas, sigmas)
            Call meineFunktionPd.SetNk(Nfiss)
            Call meineFunktionPd.SetPhi(0.0#)

            'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionPd)
            ' ############ Pd Chain ###################################
            For k = 1 To NPd
                R(11 + k) = fi_lambda(11 + k)
                capR(11 + k) = 0.0#
                zeta(11 + k) = 0
            Next k

            Call MyPdChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyPdChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k

            For k = 1 To NPd
                NPalladiumDecay(k) = ybeg(11 + k)
            Next k
            Call meineFunktionPd.SetStart(NPalladiumDecay)

            'Next i
            ' *** stop big burnup loop ******************************************


            For i = 1 To NPd
                NPalladiumDecay(i) = meineFunktionPd.GetStart(i)
            Next i

        End Function

        Public Function GetPalladiumDecDensity(ByVal i As Integer) As Double
            GetPalladiumDecDensity = NPalladiumDecay(i)
        End Function

        Public Function FindFissionMo(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyMoChain As New FissionChainMo

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NMo As Integer
            Dim zeit As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionMo As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(2) As Double
            NMo = 2

            meineFunktionMo = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionMo.SetNVar(NMo)

            For i = 1 To NMo
                ystart(i) = 0
                ybeg(3 + i) = 0
                My_lambda(i) = fi_lambda(3 + i)
                My_yfi(1, i) = fi_y(1, 3 + i)
                My_yfi(2, i) = fi_y(2, 3 + i)
                My_yfi(3, i) = fi_y(3, 3 + i)
                My_yfi(4, i) = fi_y(4, 3 + i)
            Next i

            Call meineFunktionMo.SetStart(ystart)
            Call meineFunktionMo.SetLambda(My_lambda)
            Call meineFunktionMo.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NMo)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionMo.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NMo

                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(3 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NMo + 1) = GetAcXSf(2, bur)
                    fis(NMo + 2) = GetAcXSf(5, bur)
                    fis(NMo + 3) = GetAcXSf(11, bur)
                    fis(NMo + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionMo.SetSigma(fis, cap, n2n)
                    Call InitMoXN(lambdas, sigmas, bur)
                    Call meineFunktionMo.SetXN(lambdas, sigmas)
                    Call meineFunktionMo.SetNk(Nfiss)
                    Call meineFunktionMo.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionMo)

                    ' ############ Mo Chain ###################################
                    For k = 1 To NMo
                        R(3 + k) = fi_lambda(3 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionMo.GetPhi()
                        capR(3 + k) = cap(k) * meineFunktionMo.GetPhi()
                        zeta(3 + k) = (My_yfi(1, k) * fis(NMo + 1) * Nfiss(1) + My_yfi(2, k) * fis(NMo + 2) * Nfiss(2) + My_yfi(3, k) * fis(NMo + 3) * Nfiss(3) + My_yfi(4, k) * fis(NMo + 4) * Nfiss(4)) * meineFunktionMo.GetPhi()
                    Next k

                    If (meineFunktionMo.GetPhi() > MyTiny) Then
                        Call MyMoChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyMoChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyMoChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyMoChain.CalcChain(R, ya, deltasum)
                    End If

                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k
                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************

            For k = 1 To NMo
                NMolybdan(k) = ybeg(3 + k)
            Next k
            Call meineFunktionMo.SetStart(NMolybdan)

            For i = 1 To NMo
                NMolybdan(i) = meineFunktionMo.GetStart(i)
                NMolybdanDecay(i) = meineFunktionMo.GetStart(i)
            Next i

        End Function

        Public Function GetMolybdanDensity(ByVal i As Integer) As Double
            GetMolybdanDensity = NMolybdan(i)
        End Function

        Public Function GetMolybdanDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 2
                y(i) = NMolybdan(i)
            Next i

        End Function

        Public Function FindFissionMoDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyMoChain As New FissionChainMo

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NMo As Integer

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionMo As DIN25463silverlight.DIN25463MOX.MyFunktion
            Dim ta As Double

            Dim Nfiss(4) As Double

            Dim ystart(2) As Double
            NMo = 2

            meineFunktionMo = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionMo.SetNVar(NMo)

            For i = 1 To NMo
                My_lambda(i) = fi_lambda(3 + i)
                ybeg(i + 3) = NMolybdanDecay(i)
                My_yfi(1, i) = 0.0#
                My_yfi(2, i) = 0.0#
                My_yfi(3, i) = 0.0#
                My_yfi(4, i) = 0.0#
            Next i

            Call meineFunktionMo.SetStart(NMolybdanDecay)
            Call meineFunktionMo.SetLambda(My_lambda)
            Call meineFunktionMo.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NMo)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            ' For i = 1 To ph.GetN

            Call meineFunktionMo.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()

            ' *** calc burnup dependent XS ****************************************
            For k = 1 To NMo
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NMo + 1) = GetAcXSf(2, 0.0#)
            fis(NMo + 2) = GetAcXSf(5, 0.0#)
            fis(NMo + 3) = GetAcXSf(11, 0.0#)
            fis(NMo + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionMo.SetSigma(fis, cap, n2n)
            Call InitMoXN(lambdas, sigmas, 0.0#)
            Call meineFunktionMo.SetXN(lambdas, sigmas)
            Call meineFunktionMo.SetNk(Nfiss)
            Call meineFunktionMo.SetPhi(0.0#)

            ' meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionMo)
            ' ############ Mo Chain ###################################
            For k = 1 To NMo
                R(3 + k) = fi_lambda(3 + k)
                capR(3 + k) = 0.0#
                zeta(3 + k) = 0
            Next k

            Call MyMoChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyMoChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k

            For k = 1 To NMo
                NMolybdanDecay(k) = ybeg(3 + k)
            Next k
            Call meineFunktionMo.SetStart(NMolybdanDecay)

            'Next i
            ' *** stop big burnup loop ******************************************


            For i = 1 To NMo
                NMolybdanDecay(i) = meineFunktionMo.GetStart(i)
            Next i

        End Function

        Public Function GetMolybdanDecDensity(ByVal i As Integer) As Double
            GetMolybdanDecDensity = NMolybdanDecay(i)
        End Function

        Public Function FindFissionLa(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NLa As Integer
            Dim zeit As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyLaChain As New FissionChainBa

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionLa As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(3) As Double
            NLa = 3

            meineFunktionLa = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionLa.SetNVar(NLa)

            For i = 1 To NLa
                ystart(i) = 0
                ybeg(23 + i) = 0
                My_lambda(i) = fi_lambda(23 + i)
                My_yfi(1, i) = fi_y(1, 23 + i)
                My_yfi(2, i) = fi_y(2, 23 + i)
                My_yfi(3, i) = fi_y(3, 23 + i)
                My_yfi(4, i) = fi_y(4, 23 + i)
            Next i

            'Kette 2.6b
            My_yfi(1, 3) = 0.0#
            My_yfi(2, 3) = 0.0#
            My_yfi(3, 3) = 0.0#
            My_yfi(4, 3) = 0.0#


            Call meineFunktionLa.SetStart(ystart)
            Call meineFunktionLa.SetLambda(My_lambda)
            Call meineFunktionLa.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NLa)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionLa.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NLa

                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(3 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NLa + 1) = GetAcXSf(2, bur)
                    fis(NLa + 2) = GetAcXSf(5, bur)
                    fis(NLa + 3) = GetAcXSf(11, bur)
                    fis(NLa + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionLa.SetSigma(fis, cap, n2n)
                    Call InitLaXN(lambdas, sigmas, bur)
                    Call meineFunktionLa.SetXN(lambdas, sigmas)
                    Call meineFunktionLa.SetNk(Nfiss)
                    Call meineFunktionLa.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    ' Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionLa)

                    ' ############ La Chain ###################################
                    For k = 1 To NLa
                        R(23 + k) = fi_lambda(23 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionLa.GetPhi()
                        capR(23 + k) = cap(k) * meineFunktionLa.GetPhi()
                        zeta(23 + k) = (My_yfi(1, k) * fis(NLa + 1) * Nfiss(1) + My_yfi(2, k) * fis(NLa + 2) * Nfiss(2) + My_yfi(3, k) * fis(NLa + 3) * Nfiss(3) + My_yfi(4, k) * fis(NLa + 4) * Nfiss(4)) * meineFunktionLa.GetPhi()
                    Next k

                    If (meineFunktionLa.GetPhi() > MyTiny) Then
                        Call MyLaChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyLaChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyLaChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyLaChain.CalcChain(R, ya, deltasum)
                    End If

                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k

                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************

            For k = 1 To NLa
                NLanthan(k) = ybeg(23 + k)
            Next k
            Call meineFunktionLa.SetStart(NLanthan)


            For i = 1 To NLa
                NLanthan(i) = meineFunktionLa.GetStart(i)
                NLanthanDecay(i) = meineFunktionLa.GetStart(i)
            Next i

        End Function

        Public Function GetLanthanDensity(ByVal i As Integer) As Double
            GetLanthanDensity = NLanthan(i)
        End Function

        Public Function GetLanthanDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 3
                y(i) = NLanthan(i)
            Next i

        End Function

        Public Function FindFissionLaDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyLaChain As New FissionChainBa

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NLa As Integer

            Dim ta As Double

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionLa As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(3) As Double
            NLa = 3

            meineFunktionLa = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionLa.SetNVar(NLa)

            For i = 1 To NLa
                My_lambda(i) = fi_lambda(23 + i)
                ybeg(23 + i) = NLanthanDecay(i)
                My_yfi(1, i) = 0.0#
                My_yfi(2, i) = 0.0#
                My_yfi(3, i) = 0.0#
                My_yfi(4, i) = 0.0#
            Next i

            Call meineFunktionLa.SetStart(NLanthanDecay)
            Call meineFunktionLa.SetLambda(My_lambda)
            Call meineFunktionLa.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NLa)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            ' *** start big burnup loop ******************************************
            'For i = 1 To ph.GetN
            Call meineFunktionLa.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()

            ' *** calc burnup dependent XS ****************************************
            For k = 1 To NLa
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NLa + 1) = GetAcXSf(2, 0.0#)
            fis(NLa + 2) = GetAcXSf(5, 0.0#)
            fis(NLa + 3) = GetAcXSf(11, 0.0#)
            fis(NLa + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionLa.SetSigma(fis, cap, n2n)
            Call InitLaXN(lambdas, sigmas, 0.0#)
            Call meineFunktionLa.SetXN(lambdas, sigmas)
            Call meineFunktionLa.SetNk(Nfiss)
            Call meineFunktionLa.SetPhi(0.0#)

            'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionLa)

            ' ############ La Chain ###################################
            For k = 1 To NLa
                R(23 + k) = fi_lambda(23 + k)
                capR(23 + k) = 0.0#
                zeta(23 + k) = 0
            Next k

            Call MyLaChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyLaChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k


            For k = 1 To NLa
                NLanthanDecay(k) = ybeg(23 + k)
            Next k
            Call meineFunktionLa.SetStart(NLanthanDecay)


            ' Next i
            ' *** stop big burnup loop ******************************************

            For i = 1 To NLa
                NLanthanDecay(i) = meineFunktionLa.GetStart(i)
            Next i

        End Function

        Public Function GetLanthanDecDensity(ByVal i As Integer) As Double
            GetLanthanDecDensity = NLanthanDecay(i)
        End Function

        Public Function FindFissionCer(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim Ns As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double
            Dim sum As Double
            Dim bur As Double

            Dim deltasum As Double
            Dim deltadays As Double

            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NCe As Integer
            Dim zeit As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(52) As Double
            Dim ybeg(52) As Double
            Dim MyCeChain As New DIN25463silverlight.DIN25463MOX.FissionChainCe


            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionCe As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double

            Dim ystart(25) As Double
            NCe = 25

            meineFunktionCe = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionCe.SetNVar(NCe)

            For i = 1 To NCe
                ystart(i) = 0
                ybeg(i + 26) = 0
                My_lambda(i) = fi_lambda(26 + i)
                My_yfi(1, i) = fi_y(1, 26 + i)
                My_yfi(2, i) = fi_y(2, 26 + i)
                My_yfi(3, i) = fi_y(3, 26 + i)
                My_yfi(4, i) = fi_y(4, 26 + i)
            Next i

            Call meineFunktionCe.SetStart(ystart)
            Call meineFunktionCe.SetLambda(My_lambda)
            Call meineFunktionCe.SetYfi(My_yfi)

            bur = 0.0#

            Call meinIntegral.SetNVar(NCe)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)

            zeit = 0

            ' *** start big burnup loop ******************************************
            For i = 1 To ph.GetN
                Call meineFunktionCe.SetPower(ph.GetLeistung(i) * 1000000.0#)

                sum = ph.GetInterval(i) * 24.0# * 3600.0#
                deltadays = 10.0#
                deltasum = deltadays * 24.0# * 3600.0#
                Ns = CInt(Math.Floor(sum / deltasum))

                ' *** start small burnup loop *****************************************
                For j = 1 To Ns + 1

                    ' *** calc burnup dependent XS ****************************************
                    For k = 1 To NCe

                        fis(k) = 0.0#
                        cap(k) = GetFiXSc(26 + k, bur)
                        n2n(k) = 0.0#
                    Next k

                    fis(NCe + 1) = GetAcXSf(2, bur)
                    fis(NCe + 2) = GetAcXSf(5, bur)
                    fis(NCe + 3) = GetAcXSf(11, bur)
                    fis(NCe + 4) = GetAcXSf(13, bur)

                    Nfiss(1) = Nk1Pol.GetInterpol(zeit)
                    Nfiss(2) = Nk2Pol.GetInterpol(zeit)
                    Nfiss(3) = Nk3Pol.GetInterpol(zeit)
                    Nfiss(4) = Nk4Pol.GetInterpol(zeit)

                    Call meineFunktionCe.SetSigma(fis, cap, n2n)
                    Call InitCeXN(lambdas, sigmas, bur)
                    Call meineFunktionCe.SetXN(lambdas, sigmas)
                    Call meineFunktionCe.SetNk(Nfiss)
                    Call meineFunktionCe.SetPhi(PhiPol.GetInterpol(zeit))

                    ' *** calc residual burnup *******************************************
                    If j = Ns + 1 Then
                        deltasum = (sum - Ns * deltasum)
                        deltadays = deltasum / (24.0# * 3600.0#)
                        If (deltasum = 0) Then
                            Exit For
                        End If
                    End If

                    'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionCe)

                    ' ############ Ce Chain ###################################
                    For k = 1 To NCe
                        R(26 + k) = fi_lambda(26 + k) + (fis(k) + cap(k) + n2n(k)) * meineFunktionCe.GetPhi()
                        capR(26 + k) = cap(k) * meineFunktionCe.GetPhi()
                        zeta(26 + k) = (My_yfi(1, k) * fis(NCe + 1) * Nfiss(1) + My_yfi(2, k) * fis(NCe + 2) * Nfiss(2) + My_yfi(3, k) * fis(NCe + 3) * Nfiss(3) + My_yfi(4, k) * fis(NCe + 4) * Nfiss(4)) * meineFunktionCe.GetPhi()
                    Next k

                    If (meineFunktionCe.GetPhi() > MyTiny) Then
                        Call MyCeChain.Init_chain(ybeg, capR, R, fi_lambda, zeta)
                        Call MyCeChain.CalcChain(R, ya, deltasum)
                    Else
                        Call MyCeChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
                        Call MyCeChain.CalcChain(R, ya, deltasum)
                    End If

                    For k = 1 To 51
                        ybeg(k) = ya(k)
                    Next k

                    bur = bur + deltadays * ph.GetLeistung(i) / ph.GetHeavyMetalMass()
                    zeit = zeit + deltadays

                Next j
                ' *** stop burnup subloop ********************************************

            Next i
            ' *** stop big burnup loop ******************************************

            For k = 1 To NCe
                NCer(k) = ybeg(26 + k)
            Next k
            Call meineFunktionCe.SetStart(NCer)


            For i = 1 To NCe
                NCer(i) = meineFunktionCe.GetStart(i)
                NCerDecay(i) = meineFunktionCe.GetStart(i)
            Next i

        End Function


        Public Function GetCerDensity(ByVal i As Integer) As Double
            GetCerDensity = NCer(i)
        End Function

        Public Function GetCerDensities(ByRef y() As Double) As Boolean
            Dim i As Integer

            For i = 1 To 25
                y(i) = NCer(i)
            Next i

        End Function

        Public Function FindFissionCerDecay(ByRef ph As PowerHistory) As Boolean

            Dim i As Integer

            Dim k As Integer

            Dim fis(51) As Double
            Dim cap(51) As Double
            Dim n2n(51) As Double
            Dim sigmas(51, 51) As Double
            Dim lambdas(51, 51) As Double

            Dim R(51) As Double
            Dim capR(51) As Double
            Dim zeta(51) As Double
            Dim ya(51) As Double
            Dim ybeg(51) As Double
            Dim MyCeChain As New FissionChainCe

            Dim deltasum As Double
            Dim My_lambda(51) As Double
            Dim My_yfi(4, 51) As Double
            Dim NCe As Integer

            Dim meinIntegral As New DIN25463silverlight.DIN25463MOX.MyIntegrator
            Dim meineFunktionCe As DIN25463silverlight.DIN25463MOX.MyFunktion

            Dim Nfiss(4) As Double
            Dim ta As Double

            Dim ystart(25) As Double
            NCe = 25

            meineFunktionCe = New DIN25463silverlight.DIN25463MOX.MyFissionFunktion
            Call meineFunktionCe.SetNVar(NCe)

            For i = 1 To NCe
                My_lambda(i) = fi_lambda(26 + i)
                ybeg(26 + i) = NCerDecay(i)
                My_yfi(1, i) = 0.0#
                My_yfi(2, i) = 0.0#
                My_yfi(3, i) = 0.0#
                My_yfi(4, i) = 0.0#
            Next i

            Call meineFunktionCe.SetStart(NCerDecay)
            Call meineFunktionCe.SetLambda(My_lambda)
            Call meineFunktionCe.SetYfi(My_yfi)

            Call meinIntegral.SetNVar(NCe)
            Call meinIntegral.SetH1(0.00001)
            Call meinIntegral.SetHMin(1.0E-25)
            Call meinIntegral.SetEps(glob_EPS)


            ' *** start big burnup loop ******************************************
            ' For i = 1 To ph.GetN

            Call meineFunktionCe.SetPower(0.0#)

            deltasum = ph.GetAbklang()
            ta = ph.GetAbklang()

            ' *** calc burnup dependent XS ****************************************
            For k = 1 To NCe
                fis(k) = 0.0#
                cap(k) = 0.0#
                n2n(k) = 0.0#
            Next k

            fis(NCe + 1) = GetAcXSf(2, 0.0#)
            fis(NCe + 2) = GetAcXSf(5, 0.0#)
            fis(NCe + 3) = GetAcXSf(11, 0.0#)
            fis(NCe + 4) = GetAcXSf(13, 0.0#)

            Nfiss(1) = Nk1Pol.GetInterpol(0.0#)
            Nfiss(2) = Nk2Pol.GetInterpol(0.0#)
            Nfiss(3) = Nk3Pol.GetInterpol(0.0#)
            Nfiss(4) = Nk4Pol.GetInterpol(0.0#)

            Call meineFunktionCe.SetSigma(fis, cap, n2n)
            Call InitCeXN(lambdas, sigmas, 0.0#)
            Call meineFunktionCe.SetXN(lambdas, sigmas)
            Call meineFunktionCe.SetNk(Nfiss)
            Call meineFunktionCe.SetPhi(0.0#)

            'Call meinIntegral.DoStiffIntegration(0.0#, deltasum, meineFunktionCe)

            ' ################# Ce Decay #######################################
            For k = 1 To NCe
                R(26 + k) = fi_lambda(26 + k)
                capR(26 + k) = 0.0#
                zeta(26 + k) = 0
            Next k

            Call MyCeChain.Init_chainDecay(ybeg, capR, R, fi_lambda, zeta)
            Call MyCeChain.CalcChain(R, ya, ta)

            For k = 1 To 51
                ybeg(k) = ya(k)
            Next k

            For k = 1 To NCe
                NCerDecay(k) = ybeg(26 + k)
            Next k
            Call meineFunktionCe.SetStart(NCerDecay)


            'Next i
            ' *** stop big burnup loop ******************************************

            For i = 1 To NCe
                NCerDecay(i) = meineFunktionCe.GetStart(i)
            Next i

        End Function


        Public Function GetCerDecDensity(ByVal i As Integer) As Double
            GetCerDecDensity = NCerDecay(i)
        End Function

        Public Function GetZeitSchritte() As Integer

            GetZeitSchritte = zeit

        End Function

        Public Function GetZeit(ByVal t As Integer) As Double

            GetZeit = zeiten(t)

        End Function

        Public Function GetPhi(ByVal t As Integer) As Double

            GetPhi = phi(t)

        End Function

        Public Function GetNk(ByVal t As Integer, ByVal k As Integer) As Double

            GetNk = Nk(t, k)

        End Function

        Public Function GetRik(ByRef i As Integer, ByVal k As Integer) As Double

            GetRik = Rik(i, k)

        End Function

        Public Sub InitXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 21
                For j = 1 To 21
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            lambdas(1, 10) = Ac_lambda(10)

            sigmas(2, 1) = GetAcXSc(1, bur)

            sigmas(3, 2) = GetAcXSc(2, bur)

            sigmas(4, 3) = GetAcXSc(3, bur)
            sigmas(4, 5) = GetAcXSn2n(5, bur)

            sigmas(5, 4) = GetAcXSc(4, bur)

            sigmas(6, 5) = GetAcXSc(5, bur)

            lambdas(7, 4) = Ac_lambda(4)

            sigmas(8, 7) = GetAcXSc(7, bur)

            lambdas(9, 6) = Ac_lambda(6)

            lambdas(10, 20) = Ac_lambda(20)
            lambdas(10, 8) = Ac_lambda(8)

            sigmas(11, 10) = GetAcXSc(10, bur)
            lambdas(11, 9) = Ac_lambda(9)

            sigmas(12, 11) = GetAcXSc(11, bur)

            sigmas(13, 12) = GetAcXSc(12, bur)

            sigmas(14, 13) = GetAcXSc(13, bur)
            lambdas(14, 17) = Ac_lambda(17)

            sigmas(15, 14) = GetAcXSc(14, bur)

            lambdas(16, 13) = Ac_lambda(13)

            sigmas(17, 16) = 0.827 * GetAcXSc(16, bur)

            sigmas(18, 17) = GetAcXSc(17, bur)
            lambdas(18, 15) = Ac_lambda(15)

            sigmas(19, 18) = GetAcXSc(18, bur)

            lambdas(20, 17) = Ac_lambda(17)

            lambdas(21, 19) = Ac_lambda(19)

        End Sub


        Public Sub InitCeXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 25
                For j = 1 To 25
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            lambdas(2, 1) = fi_lambda(27)
            lambdas(3, 2) = fi_lambda(28)
            lambdas(8, 7) = fi_lambda(33)
            lambdas(13, 8) = fi_lambda(34)
            lambdas(14, 9) = fi_lambda(35)
            lambdas(14, 10) = fi_lambda(36)
            lambdas(15, 11) = fi_lambda(37)
            lambdas(16, 12) = fi_lambda(38)
            lambdas(22, 19) = fi_lambda(45)
            lambdas(24, 21) = fi_lambda(47)


            sigmas(4, 3) = GetFiXSc(29, bur)
            sigmas(5, 4) = GetFiXSc(30, bur)
            sigmas(6, 5) = GetFiXSc(31, bur)
            sigmas(7, 6) = GetFiXSc(32, bur)
            sigmas(9, 8) = 0.528 * GetFiXSc(34, bur)
            sigmas(10, 8) = 0.472 * GetFiXSc(34, bur)
            sigmas(11, 9) = GetFiXSc(35, bur)
            sigmas(11, 10) = GetFiXSc(36, bur)
            sigmas(12, 11) = GetFiXSc(37, bur)
            sigmas(14, 13) = GetFiXSc(39, bur)
            sigmas(15, 14) = GetFiXSc(40, bur)
            sigmas(16, 15) = GetFiXSc(41, bur)
            sigmas(17, 16) = GetFiXSc(42, bur)
            sigmas(18, 17) = GetFiXSc(43, bur)
            sigmas(19, 18) = GetFiXSc(44, bur)
            sigmas(20, 19) = GetFiXSc(45, bur)
            sigmas(21, 20) = GetFiXSc(46, bur)
            sigmas(23, 22) = GetFiXSc(48, bur)
            sigmas(24, 23) = GetFiXSc(49, bur)
            sigmas(25, 24) = GetFiXSc(50, bur)


        End Sub

        Public Sub InitLaXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 3
                For j = 1 To 3
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            'Kette 2.6b
            'lambdas(3, 1) = fi_lambda(24)
            sigmas(3, 2) = GetFiXSc(25, bur)


        End Sub

        Public Sub InitMoXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 2
                For j = 1 To 2
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            lambdas(2, 1) = fi_lambda(4)


        End Sub

        Public Sub InitPdXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 4
                For j = 1 To 4
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            sigmas(2, 1) = GetFiXSc(12, bur)
            lambdas(3, 2) = fi_lambda(13)
            sigmas(4, 3) = 0.038 * GetFiXSc(14, bur)


        End Sub

        Public Sub InitRuXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 6
                For j = 1 To 6
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            sigmas(2, 1) = GetFiXSc(6, bur)
            sigmas(3, 2) = GetFiXSc(7, bur)
            lambdas(4, 3) = fi_lambda(8)
            sigmas(5, 4) = GetFiXSc(9, bur)
            sigmas(6, 5) = GetFiXSc(10, bur)


        End Sub


        Public Sub InitXeXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 8
                For j = 1 To 8
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            sigmas(2, 1) = GetFiXSc(16, bur)
            sigmas(3, 2) = GetFiXSc(17, bur)
            lambdas(5, 3) = fi_lambda(18)
            lambdas(7, 4) = fi_lambda(19)
            sigmas(6, 5) = GetFiXSc(20, bur)
            sigmas(7, 6) = GetFiXSc(21, bur)
            sigmas(8, 7) = GetFiXSc(22, bur)

        End Sub

        Public Sub InitZrXN(ByRef lambdas(,) As Double, ByRef sigmas(,) As Double, ByRef bur As Double)

            Dim i As Integer
            Dim j As Integer

            For i = 1 To 3
                For j = 1 To 3
                    lambdas(i, j) = 0.0#
                    sigmas(i, j) = 0.0#
                Next j
            Next i

            lambdas(2, 1) = fi_lambda(1)
            lambdas(3, 2) = fi_lambda(2)


        End Sub

        Public Function GetAcDensity(ByRef i As Integer) As Double
            GetAcDensity = NAct(i)
        End Function

        Public Function GetAcDecDensity(ByRef i As Integer) As Double
            GetAcDecDensity = NActDecay(i)
        End Function

        Public Function GetAclambda(ByRef i As Integer) As Double
            GetAclambda = Ac_lambda(i)
        End Function

        Public Function GetFilambda(ByRef i As Integer) As Double
            GetFilambda = fi_lambda(i)
        End Function

        Public Function GetFiQn(ByRef i As Integer) As Double
            GetFiQn = fi_Qn(i)
        End Function

        Public Function GetAcQn(ByRef i As Integer) As Double
            GetAcQn = Ac_Qn(i)
        End Function


        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

    End Class
End Namespace
