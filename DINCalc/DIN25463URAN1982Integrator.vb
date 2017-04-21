Imports DIN25463silverlight.DIN25463URAN1982

Namespace DIN25463URAN1982

    Public Class DIN25463URAN1982Integrator


        Dim Pik(3, 100) As Double
        Dim Tss(65) As Double
        Dim Ats(65) As Double
        Dim Hts(65) As Double
        Dim Tk(100) As Double
        Dim Sk(100) As Double
        Dim ttk(100) As Double
        Dim Pt(100) As Double
        Dim Ht(100) As Integer
        Dim PQk(100) As Double
        Dim Qi(3) As Double
        Dim dQi(3) As Double
        Dim aij(3, 24) As Double
        Dim bij(3, 24) As Double
        Dim lij(3, 24) As Double
        Dim Psi(3) As Double
        Dim Ps0(3) As Double
        Dim dt As Double
        Dim Nh As Integer
        Dim wert As Double
        Dim ss(10000) As Double
        Dim hh(10000) As Double
        Dim ddss As Double
        Dim dss As Double
        Dim gamma(3, 3) As Double
        Dim alpha(6, 3) As Double
        Dim beta(6, 3) As Double
        Dim ces(2, 3) As Double
        Dim Fahc(65) As Double
        Dim Bmax(65) As Double
        Dim au235(23) As Double
        Dim ap239(23) As Double
        Dim au238(23) As Double
        Dim lu235(23) As Double
        Dim lp239(23) As Double
        Dim lu238(23) As Double
        Dim Tas(65) As Double
        Dim Gms(65) As Double
        Dim Qu235 As Double
        Dim Qu238 As Double
        Dim Qp239 As Double

        Dim DinZeit(100) As Double
        Dim DinPower(100) As Double
        Dim DinU235(100) As Double
        Dim DinU238(100) As Double
        Dim DinP239(100) As Double
        Dim DinEnrichment As Double
        Dim DinHMM As Double

        Public Function Init_ans() As Integer

            Init_ans = 0

            Qu235 = 200.0#
            Qp239 = 200.0#
            Qu238 = 200.0#

            au235(1) = 0.65057
            au235(2) = 0.51264
            au235(3) = 0.24384
            au235(4) = 0.1385
            au235(5) = 0.05544
            au235(6) = 0.022225
            au235(7) = 0.0033088
            au235(8) = 0.00093015
            au235(9) = 0.00080943
            au235(10) = 0.00019567

            au235(11) = 0.000032535
            au235(12) = 0.0000075595
            au235(13) = 0.0000025232
            au235(14) = 0.00000049948
            au235(15) = 0.00000018531
            au235(16) = 0.000000026608
            au235(17) = 0.0000000022398
            au235(18) = 0.0000000000081641
            au235(19) = 0.000000000087797
            au235(20) = 0.000000000000025131

            au235(21) = 0.00000000000000032176
            au235(22) = 4.5038E-17
            au235(23) = 7.4791E-17

            lu235(1) = 22.138
            lu235(2) = 0.51587
            lu235(3) = 0.19594
            lu235(4) = 0.10314
            lu235(5) = 0.033656
            lu235(6) = 0.011681
            lu235(7) = 0.003587
            lu235(8) = 0.001393
            lu235(9) = 0.0006263
            lu235(10) = 0.00018906

            lu235(11) = 0.000054988
            lu235(12) = 0.000020958
            lu235(13) = 0.00001001
            lu235(14) = 0.0000025438
            lu235(15) = 0.00000066361
            lu235(16) = 0.0000001229
            lu235(17) = 0.000000027213
            lu235(18) = 0.0000000043714
            lu235(19) = 0.0000000007578
            lu235(20) = 0.00000000024786

            lu235(21) = 0.00000000000022384
            lu235(22) = 0.0000000000000246
            lu235(23) = 0.000000000000015699


            ap239(1) = 0.2083
            ap239(2) = 0.3853
            ap239(3) = 0.2213
            ap239(4) = 0.0946
            ap239(5) = 0.03531
            ap239(6) = 0.02292
            ap239(7) = 0.003946
            ap239(8) = 0.001317
            ap239(9) = 0.0007052
            ap239(10) = 0.0001432

            ap239(11) = 0.00001765
            ap239(12) = 0.000007347
            ap239(13) = 0.000001747
            ap239(14) = 0.0000005481
            ap239(15) = 0.0000001671
            ap239(16) = 0.00000002112
            ap239(17) = 0.000000002996
            ap239(18) = 0.00000000005107
            ap239(19) = 0.00000000005703
            ap239(20) = 0.00000000000004138

            ap239(21) = 0.000000000000001088
            ap239(22) = 2.454E-17
            ap239(23) = 7.557E-17

            lp239(1) = 10.02
            lp239(2) = 0.6433
            lp239(3) = 0.2186
            lp239(4) = 0.1004
            lp239(5) = 0.03728
            lp239(6) = 0.01435
            lp239(7) = 0.004549
            lp239(8) = 0.001328
            lp239(9) = 0.0005356
            lp239(10) = 0.000173

            lp239(11) = 0.00004881
            lp239(12) = 0.00002006
            lp239(13) = 0.000008319
            lp239(14) = 0.000002358
            lp239(15) = 0.000000645
            lp239(16) = 0.0000001278
            lp239(17) = 0.00000002466
            lp239(18) = 0.000000009378
            lp239(19) = 0.000000000745
            lp239(20) = 0.0000000002426

            lp239(21) = 0.000000000000221
            lp239(22) = 0.0000000000000264
            lp239(23) = 0.0000000000000138


            au238(1) = 1.2311
            au238(2) = 1.1486
            au238(3) = 0.70701
            au238(4) = 0.25209
            au238(5) = 0.07187
            au238(6) = 0.028291
            au238(7) = 0.0068382
            au238(8) = 0.0012322
            au238(9) = 0.00068409
            au238(10) = 0.00016975

            au238(11) = 0.000024182
            au238(12) = 0.0000066356
            au238(13) = 0.0000010075
            au238(14) = 0.00000049894
            au238(15) = 0.00000016352
            au238(16) = 0.000000023355
            au238(17) = 0.0000000028094
            au238(18) = 0.000000000036236
            au238(19) = 0.000000000064577
            au238(20) = 0.000000000000044963

            au238(21) = 0.00000000000000036654
            au238(22) = 5.6293E-17
            au238(23) = 7.1602E-17

            lu238(1) = 3.2881
            lu238(2) = 0.93805
            lu238(3) = 0.37073
            lu238(4) = 0.11118
            lu238(5) = 0.036143
            lu238(6) = 0.013272
            lu238(7) = 0.0050133
            lu238(8) = 0.0013655
            lu238(9) = 0.00055158
            lu238(10) = 0.00017873

            lu238(11) = 0.000049032
            lu238(12) = 0.000017058
            lu238(13) = 0.0000070465
            lu238(14) = 0.000002319
            lu238(15) = 0.0000006448
            lu238(16) = 0.00000012649
            lu238(17) = 0.000000025548
            lu238(18) = 0.0000000084782
            lu238(19) = 0.0000000007513
            lu238(20) = 0.00000000024188

            lu238(21) = 0.00000000000022739
            lu238(22) = 0.000000000000090536
            lu238(23) = 0.0000000000000056098

            Tas(1) = 1.0#
            Tas(2) = 1.5
            Tas(3) = 2.0#
            Tas(4) = 4.0#
            Tas(5) = 6.0#
            Tas(6) = 8.0#

            Tas(7) = 10.0#
            Tas(8) = 15.0#
            Tas(9) = 20.0#
            Tas(10) = 40.0#
            Tas(11) = 60.0#
            Tas(12) = 80.0#

            Tas(13) = 100.0#
            Tas(14) = 150.0#
            Tas(15) = 200.0#
            Tas(16) = 400.0#
            Tas(17) = 600.0#
            Tas(18) = 800.0#

            Tas(19) = 1000.0#
            Tas(20) = 1500.0#
            Tas(21) = 2000.0#
            Tas(22) = 4000.0#
            Tas(23) = 6000.0#
            Tas(24) = 8000.0#

            Tas(25) = 10000.0#
            Tas(26) = 15000.0#
            Tas(27) = 20000.0#
            Tas(28) = 40000.0#
            Tas(29) = 60000.0#
            Tas(30) = 80000.0#

            Tas(31) = 100000.0#
            Tas(32) = 150000.0#
            Tas(33) = 200000.0#
            Tas(34) = 400000.0#
            Tas(35) = 600000.0#
            Tas(36) = 800000.0#

            Tas(37) = 1000000.0#
            Tas(38) = 1500000.0#
            Tas(39) = 2000000.0#
            Tas(40) = 4000000.0#
            Tas(41) = 6000000.0#
            Tas(42) = 8000000.0#

            Tas(43) = 10000000.0#
            Tas(44) = 15000000.0#
            Tas(45) = 20000000.0#
            Tas(46) = 40000000.0#
            Tas(47) = 60000000.0#
            Tas(48) = 80000000.0#

            Tas(49) = 100000000.0#
            Tas(50) = 150000000.0#
            Tas(51) = 200000000.0#
            Tas(52) = 400000000.0#
            Tas(53) = 600000000.0#
            Tas(54) = 800000000.0#

            Tas(55) = 1000000000.0#

            Gms(1) = 1.02
            Gms(2) = 1.02
            Gms(3) = 1.02
            Gms(4) = 1.021
            Gms(5) = 1.022
            Gms(6) = 1.022
            Gms(7) = 1.022
            Gms(8) = 1.022
            Gms(9) = 1.022
            Gms(10) = 1.022

            Gms(11) = 1.022
            Gms(12) = 1.022
            Gms(13) = 1.023
            Gms(14) = 1.024
            Gms(15) = 1.025
            Gms(16) = 1.028
            Gms(17) = 1.03
            Gms(18) = 1.032
            Gms(19) = 1.033
            Gms(20) = 1.037

            Gms(21) = 1.039
            Gms(22) = 1.048
            Gms(23) = 1.054
            Gms(24) = 1.06
            Gms(25) = 1.064
            Gms(26) = 1.074
            Gms(27) = 1.081
            Gms(28) = 1.098
            Gms(29) = 1.111
            Gms(30) = 1.119

            Gms(31) = 1.124
            Gms(32) = 1.13
            Gms(33) = 1.131
            Gms(34) = 1.126
            Gms(35) = 1.124
            Gms(36) = 1.123
            Gms(37) = 1.124
            Gms(38) = 1.125
            Gms(39) = 1.127
            Gms(40) = 1.134

            Gms(41) = 1.146
            Gms(42) = 1.162
            Gms(43) = 1.181
            Gms(44) = 1.233
            Gms(45) = 1.284
            Gms(46) = 1.444
            Gms(47) = 1.535
            Gms(48) = 1.586
            Gms(49) = 1.598
            Gms(50) = 1.498

            Gms(51) = 1.343
            Gms(52) = 1.065
            Gms(53) = 1.021
            Gms(54) = 1.012
            Gms(55) = 1.007

        End Function

        Public Function Init_simpl() As Integer

            Init_simpl = 0

            gamma(1, 1) = 0.07552
            gamma(2, 1) = 2.04
            gamma(3, 1) = -0.1991

            gamma(1, 2) = 0.07546
            gamma(2, 2) = 1.532
            gamma(3, 2) = -0.1934

            gamma(1, 3) = 0.07602
            gamma(2, 3) = 1.191
            gamma(3, 3) = -0.1918

            alpha(1, 1) = 0.09023
            alpha(2, 1) = 5.056
            alpha(3, 1) = -165.9
            alpha(4, 1) = -571.6
            alpha(5, 1) = -10220.0#
            alpha(6, 1) = -64980.0#

            alpha(1, 2) = 0.1069
            alpha(2, 2) = 5.226
            alpha(3, 2) = -170.5
            alpha(4, 2) = -835.6
            alpha(5, 2) = -11270.0#
            alpha(6, 2) = -73280.0#

            alpha(1, 3) = 0.1207
            alpha(2, 3) = 5.31
            alpha(3, 3) = -162.4
            alpha(4, 3) = -907.7
            alpha(5, 3) = -11260.0#
            alpha(6, 3) = -76440.0#

            beta(1, 1) = 2611.0#
            beta(2, 1) = 2286000.0#
            beta(3, 1) = 23890000000.0#
            beta(4, 1) = 24110000000000.0#
            beta(5, 1) = 688100000000000.0#
            beta(6, 1) = 1.763E+16

            beta(1, 2) = 1734.0#
            beta(2, 2) = 2158000.0#
            beta(3, 2) = 22870000000.0#
            beta(4, 2) = 17640000000000.0#
            beta(5, 2) = 694800000000000.0#
            beta(6, 2) = 1.846E+16

            beta(1, 3) = 1389.0#
            beta(2, 3) = 2115000.0#
            beta(3, 3) = 22140000000.0#
            beta(4, 3) = 17400000000000.0#
            beta(5, 3) = 690400000000000.0#
            beta(6, 3) = 1.869E+16

            ces(1, 1) = 0.00009156
            ces(2, 1) = -28.83

            ces(1, 2) = 0.0001717
            ces(2, 2) = -19.69

            ces(1, 3) = 0.0001683
            ces(2, 3) = -20.86


        End Function

        Public Function Init_As() As Integer

            Init_As = 0

            Fahc(1) = 1.027
            Fahc(2) = 1.028
            Fahc(3) = 1.028
            Fahc(4) = 1.029
            Fahc(5) = 1.029
            Fahc(6) = 1.03
            Fahc(7) = 1.031
            Fahc(8) = 1.031
            Fahc(9) = 1.033
            Fahc(10) = 1.034

            Fahc(11) = 1.034
            Fahc(12) = 1.034
            Fahc(13) = 1.035
            Fahc(14) = 1.037
            Fahc(15) = 1.037
            Fahc(16) = 1.037
            Fahc(17) = 1.039
            Fahc(18) = 1.041
            Fahc(19) = 1.042
            Fahc(20) = 1.004

            Fahc(21) = 1.049
            Fahc(22) = 1.052
            Fahc(23) = 1.055
            Fahc(24) = 1.059
            Fahc(25) = 1.063
            Fahc(26) = 1.07
            Fahc(27) = 1.075
            Fahc(28) = 1.084
            Fahc(29) = 1.091
            Fahc(30) = 1.097

            Fahc(31) = 1.109
            Fahc(32) = 1.118
            Fahc(33) = 1.131
            Fahc(34) = 1.142
            Fahc(35) = 1.158
            Fahc(36) = 1.168
            Fahc(37) = 1.177
            Fahc(38) = 1.188
            Fahc(39) = 1.195
            Fahc(40) = 1.201

            Fahc(41) = 1.203
            Fahc(42) = 1.206
            Fahc(43) = 1.21
            Fahc(44) = 1.213
            Fahc(45) = 1.223
            Fahc(46) = 1.231
            Fahc(47) = 1.247
            Fahc(48) = 1.258
            Fahc(49) = 1.285
            Fahc(50) = 1.31

            Fahc(51) = 1.331
            Fahc(52) = 1.378
            Fahc(53) = 1.415
            Fahc(54) = 1.466
            Fahc(55) = 1.503
            Fahc(56) = 1.565
            Fahc(57) = 1.628
            Fahc(58) = 1.691
            Fahc(59) = 1.785
            Fahc(60) = 1.799

            Fahc(61) = 1.721
            Fahc(62) = 1.721
            Fahc(63) = 1.721
            Fahc(64) = 1.721
            Fahc(65) = 1.721

            Bmax(1) = 0.003741
            Bmax(2) = 0.00374
            Bmax(3) = 0.00374
            Bmax(4) = 0.003739
            Bmax(5) = 0.003738
            Bmax(6) = 0.003737
            Bmax(7) = 0.003736
            Bmax(8) = 0.003734
            Bmax(9) = 0.003732
            Bmax(10) = 0.003727

            Bmax(11) = 0.003722
            Bmax(12) = 0.003712
            Bmax(13) = 0.003703
            Bmax(14) = 0.003684
            Bmax(15) = 0.003665
            Bmax(16) = 0.003646
            Bmax(17) = 0.0036
            Bmax(18) = 0.003555
            Bmax(19) = 0.003469
            Bmax(20) = 0.003387

            Bmax(21) = 0.003233
            Bmax(22) = 0.003095
            Bmax(23) = 0.002969
            Bmax(24) = 0.002702
            Bmax(25) = 0.002493
            Bmax(26) = 0.0022
            Bmax(27) = 0.002019
            Bmax(28) = 0.001833
            Bmax(29) = 0.001757
            Bmax(30) = 0.001721

            Bmax(31) = 0.001678
            Bmax(32) = 0.001649
            Bmax(33) = 0.001594
            Bmax(34) = 0.00154
            Bmax(35) = 0.001439
            Bmax(36) = 0.001344
            Bmax(37) = 0.001255
            Bmax(38) = 0.001058
            Bmax(39) = 0.0008925
            Bmax(40) = 0.0006346

            Bmax(41) = 0.0004512
            Bmax(42) = 0.0002281
            Bmax(43) = 0.0001154
            Bmax(44) = 0.00005832
            Bmax(45) = 0.0000106
            Bmax(46) = 0.000001927
            Bmax(47) = 0.00000006367
            Bmax(48) = 0.000000002104
            Bmax(49) = 0.000000000002297
            Bmax(50) = 0.000000000000002507

            Bmax(51) = 0.0#
            Bmax(52) = 0.0#
            Bmax(53) = 0.0#
            Bmax(54) = 0.0#
            Bmax(55) = 0.0#
            Bmax(56) = 0.0#
            Bmax(57) = 0.0#
            Bmax(58) = 0.0#
            Bmax(59) = 0.0#
            Bmax(60) = 0.0#

            Bmax(61) = 0.0#
            Bmax(62) = 0.0#
            Bmax(63) = 0.0#
            Bmax(64) = 0.0#
            Bmax(65) = 0.0#

            Tss(1) = 0.0#
            Tss(2) = 1.0#
            Tss(3) = 1.5
            Tss(4) = 2.0#
            Tss(5) = 3.0#
            Tss(6) = 4.0#
            Tss(7) = 6.0#
            Tss(8) = 8.0#
            Tss(9) = 10.0#
            Tss(10) = 15.0#

            Tss(11) = 20.0#
            Tss(12) = 30.0#
            Tss(13) = 40.0#
            Tss(14) = 60.0#
            Tss(15) = 80.0#
            Tss(16) = 100.0#
            Tss(17) = 150.0#
            Tss(18) = 200.0#
            Tss(19) = 300.0#
            Tss(20) = 400.0#

            Tss(21) = 600.0#
            Tss(22) = 800.0#
            Tss(23) = 1000.0#
            Tss(24) = 1500.0#
            Tss(25) = 2000.0#
            Tss(26) = 3000.0#
            Tss(27) = 4000.0#
            Tss(28) = 6000.0#
            Tss(29) = 8000.0#
            Tss(30) = 10000.0#

            Tss(31) = 15000.0#
            Tss(32) = 20000.0#
            Tss(33) = 30000.0#
            Tss(34) = 40000.0#
            Tss(35) = 60000.0#
            Tss(36) = 80000.0#
            Tss(37) = 100000.0#
            Tss(38) = 150000.0#
            Tss(39) = 200000.0#
            Tss(40) = 300000.0#

            Tss(41) = 400000.0#
            Tss(42) = 600000.0#
            Tss(43) = 800000.0#
            Tss(44) = 1000000.0#
            Tss(45) = 1500000.0#
            Tss(46) = 2000000.0#
            Tss(47) = 3000000.0#
            Tss(48) = 4000000.0#
            Tss(49) = 6000000.0#
            Tss(50) = 8000000.0#

            Tss(51) = 10000000.0#
            Tss(52) = 15000000.0#
            Tss(53) = 20000000.0#
            Tss(54) = 30000000.0#
            Tss(55) = 40000000.0#
            Tss(56) = 60000000.0#
            Tss(57) = 80000000.0#
            Tss(58) = 100000000.0#
            Tss(59) = 150000000.0#
            Tss(60) = 200000000.0#

            Tss(61) = 300000000.0#
            Tss(62) = 400000000.0#
            Tss(63) = 600000000.0#
            Tss(64) = 800000000.0#
            Tss(65) = 1000000000.0#

            Ats(1) = 0.008
            Ats(2) = 0.009
            Ats(3) = 0.009
            Ats(4) = 0.01
            Ats(5) = 0.01
            Ats(6) = 0.01
            Ats(7) = 0.011
            Ats(8) = 0.011
            Ats(9) = 0.012
            Ats(10) = 0.013

            Ats(11) = 0.013
            Ats(12) = 0.014
            Ats(13) = 0.015
            Ats(14) = 0.016
            Ats(15) = 0.017
            Ats(16) = 0.017
            Ats(17) = 0.019
            Ats(18) = 0.02
            Ats(19) = 0.021
            Ats(20) = 0.022

            Ats(21) = 0.024
            Ats(22) = 0.026
            Ats(23) = 0.027
            Ats(24) = 0.029
            Ats(25) = 0.031
            Ats(26) = 0.034
            Ats(27) = 0.036
            Ats(28) = 0.04
            Ats(29) = 0.043
            Ats(30) = 0.045

            Ats(31) = 0.05
            Ats(32) = 0.053
            Ats(33) = 0.058
            Ats(34) = 0.062
            Ats(35) = 0.067
            Ats(36) = 0.07
            Ats(37) = 0.073
            Ats(38) = 0.076
            Ats(39) = 0.078
            Ats(40) = 0.08

            Ats(41) = 0.08
            Ats(42) = 0.082
            Ats(43) = 0.085
            Ats(44) = 0.088
            Ats(45) = 0.098
            Ats(46) = 0.107
            Ats(47) = 0.122
            Ats(48) = 0.134
            Ats(49) = 0.152
            Ats(50) = 0.165

            Ats(51) = 0.174
            Ats(52) = 0.192
            Ats(53) = 0.203
            Ats(54) = 0.213
            Ats(55) = 0.218
            Ats(56) = 0.241
            Ats(57) = 0.282
            Ats(58) = 0.331
            Ats(59) = 0.439
            Ats(60) = 0.499

            Ats(61) = 0.547
            Ats(62) = 0.574
            Ats(63) = 0.624
            Ats(64) = 0.677
            Ats(65) = 0.737

            Hts(1) = 0.017
            Hts(2) = 0.017
            Hts(3) = 0.017
            Hts(4) = 0.017
            Hts(5) = 0.017
            Hts(6) = 0.018
            Hts(7) = 0.018
            Hts(8) = 0.018
            Hts(9) = 0.018
            Hts(10) = 0.018

            Hts(11) = 0.018
            Hts(12) = 0.017
            Hts(13) = 0.017
            Hts(14) = 0.017
            Hts(15) = 0.016
            Hts(16) = 0.016
            Hts(17) = 0.016
            Hts(18) = 0.016
            Hts(19) = 0.016
            Hts(20) = 0.017

            Hts(21) = 0.019
            Hts(22) = 0.021
            Hts(23) = 0.021
            Hts(24) = 0.023
            Hts(25) = 0.024
            Hts(26) = 0.027
            Hts(27) = 0.029
            Hts(28) = 0.033
            Hts(29) = 0.036
            Hts(30) = 0.039

            Hts(31) = 0.044
            Hts(32) = 0.048
            Hts(33) = 0.054
            Hts(34) = 0.059
            Hts(35) = 0.067
            Hts(36) = 0.072
            Hts(37) = 0.076
            Hts(38) = 0.081
            Hts(39) = 0.084
            Hts(40) = 0.084

            Hts(41) = 0.083
            Hts(42) = 0.08
            Hts(43) = 0.077
            Hts(44) = 0.073
            Hts(45) = 0.066
            Hts(46) = 0.058
            Hts(47) = 0.047
            Hts(48) = 0.036
            Hts(49) = 0.027
            Hts(50) = 0.024

            Hts(51) = 0.022
            Hts(52) = 0.02
            Hts(53) = 0.02
            Hts(54) = 0.023
            Hts(55) = 0.028
            Hts(56) = 0.037
            Hts(57) = 0.046
            Hts(58) = 0.057
            Hts(59) = 0.071
            Hts(60) = 0.076

            Hts(61) = 0.074
            Hts(62) = 0.066
            Hts(63) = 0.047
            Hts(64) = 0.033
            Hts(65) = 0.022

        End Function

        Public Function Init_din25463() As Integer

            Init_din25463 = 0

            Qi(1) = 202.6
            Qi(2) = 205.9
            Qi(3) = 211.4

            dQi(1) = 0.9
            dQi(2) = 1.1
            dQi(3) = 1.1

            aij(1, 1) = 0.0#
            aij(1, 2) = 0.65057
            aij(1, 3) = 0.51264
            aij(1, 4) = 0.24384
            aij(1, 5) = 0.1385
            aij(1, 6) = 0.05544
            aij(1, 7) = 0.022225
            aij(1, 8) = 0.0033088
            aij(1, 9) = 0.00093015
            aij(1, 10) = 0.00080943
            aij(1, 11) = 0.00019567
            aij(1, 12) = 0.000032535
            aij(1, 13) = 0.0000075595
            aij(1, 14) = 0.0000025232
            aij(1, 15) = 0.00000049948
            aij(1, 16) = 0.00000018531
            aij(1, 17) = 0.000000026608
            aij(1, 18) = 0.0000000022398
            aij(1, 19) = 0.0000000000081641
            aij(1, 20) = 0.000000000087797
            aij(1, 21) = 0.000000000000025131
            aij(1, 22) = 0.00000000000000032176
            aij(1, 23) = 4.5038E-17
            aij(1, 24) = 7.4791E-17

            aij(2, 1) = 0.0#
            aij(2, 2) = 1.2311
            aij(2, 3) = 1.1486
            aij(2, 4) = 0.70701
            aij(2, 5) = 0.25209
            aij(2, 6) = 0.07187
            aij(2, 7) = 0.028291
            aij(2, 8) = 0.0068382
            aij(2, 9) = 0.0012322
            aij(2, 10) = 0.00068409
            aij(2, 11) = 0.00016975
            aij(2, 12) = 0.000024182
            aij(2, 13) = 0.0000066356
            aij(2, 14) = 0.0000010075
            aij(2, 15) = 0.00000049894
            aij(2, 16) = 0.00000016352
            aij(2, 17) = 0.000000023355
            aij(2, 18) = 0.0000000028094
            aij(2, 19) = 0.000000000036236
            aij(2, 20) = 0.000000000064577
            aij(2, 21) = 0.000000000000044963
            aij(2, 22) = 0.00000000000000036654
            aij(2, 23) = 5.6293E-17
            aij(2, 24) = 7.1602E-17

            aij(3, 1) = 0.0#
            aij(3, 2) = 0.2083
            aij(3, 3) = 0.3853
            aij(3, 4) = 0.2213
            aij(3, 5) = 0.0946
            aij(3, 6) = 0.03531
            aij(3, 7) = 0.02292
            aij(3, 8) = 0.003946
            aij(3, 9) = 0.001317
            aij(3, 10) = 0.0007052
            aij(3, 11) = 0.0001432
            aij(3, 12) = 0.00001765
            aij(3, 13) = 0.000007347
            aij(3, 14) = 0.000001747
            aij(3, 15) = 0.0000005481
            aij(3, 16) = 0.0000001671
            aij(3, 17) = 0.00000002112
            aij(3, 18) = 0.000000002996
            aij(3, 19) = 0.00000000005107
            aij(3, 20) = 0.0000000000573
            aij(3, 21) = 0.00000000000004138
            aij(3, 22) = 0.000000000000001088
            aij(3, 23) = 2.454E-17
            aij(3, 24) = 7.557E-17


            bij(1, 1) = 2.964
            bij(1, 2) = 0.25739
            bij(1, 3) = 0.038948
            bij(1, 4) = 0.0096897
            bij(1, 5) = 0.0046536
            bij(1, 6) = 0.0011353
            bij(1, 7) = 0.00039893
            bij(1, 8) = 0.000068056
            bij(1, 9) = 0.000017065
            bij(1, 10) = 0.000014139
            bij(1, 11) = 0.0000040322
            bij(1, 12) = 0.00000050468
            bij(1, 13) = 0.000000037017
            bij(1, 14) = 0.000000054362
            bij(1, 15) = 0.000000010741
            bij(1, 16) = 0.0000000036042
            bij(1, 17) = 0.00000000053327
            bij(1, 18) = 0.000000000044836
            bij(1, 19) = 0.00000000000016314
            bij(1, 20) = 0.0000000000017608
            bij(1, 21) = 0.00000000000000049856
            bij(1, 22) = 6.4033E-18
            bij(1, 23) = 9.1122E-19
            bij(1, 24) = 1.4982E-18

            bij(2, 1) = 0.17096
            bij(2, 2) = 0.2285
            bij(2, 3) = 0.28887
            bij(2, 4) = 0.15385
            bij(2, 5) = 0.045971
            bij(2, 6) = 0.015754
            bij(2, 7) = 0.002926
            bij(2, 8) = 0.0004272
            bij(2, 9) = 0.000079935
            bij(2, 10) = 0.000032309
            bij(2, 11) = 0.000010408
            bij(2, 12) = 0.0000012033
            bij(2, 13) = 0.00000032115
            bij(2, 14) = 0.000000040651
            bij(2, 15) = 0.00000001764
            bij(2, 16) = 0.000000005777
            bij(2, 17) = 0.00000000080103
            bij(2, 18) = 0.00000000011941
            bij(2, 19) = 0.000000000003262
            bij(2, 20) = 0.0000000000032213
            bij(2, 21) = 0.000000000000002256
            bij(2, 22) = 1.8358E-17
            bij(2, 23) = 2.8107E-18
            bij(2, 24) = 3.575E-18

            bij(3, 1) = 2.3195
            bij(3, 2) = 0.11261
            bij(3, 3) = 0.021063
            bij(3, 4) = 0.011341
            bij(3, 5) = 0.005801
            bij(3, 6) = 0.0013538
            bij(3, 7) = 0.00087608
            bij(3, 8) = 0.0001636
            bij(3, 9) = 0.000053738
            bij(3, 10) = 0.000022605
            bij(3, 11) = 0.0000070454
            bij(3, 12) = 0.00000084819
            bij(3, 13) = 0.00000029721
            bij(3, 14) = 0.000000099509
            bij(3, 15) = 0.000000027086
            bij(3, 16) = 0.0000000083527
            bij(3, 17) = 0.0000000010569
            bij(3, 18) = 0.00000000014978
            bij(3, 19) = 0.0000000000025521
            bij(3, 20) = 0.0000000000028608
            bij(3, 21) = 0.0000000000000020722
            bij(3, 22) = 5.4206E-17
            bij(3, 23) = 1.2268E-18
            bij(3, 24) = 3.9291E-18

            lij(1, 1) = 2.499
            lij(1, 2) = 22.138
            lij(1, 3) = 0.51587
            lij(1, 4) = 0.19594
            lij(1, 5) = 0.10314
            lij(1, 6) = 0.033656
            lij(1, 7) = 0.011681
            lij(1, 8) = 0.003587
            lij(1, 9) = 0.001393
            lij(1, 10) = 0.0006263
            lij(1, 11) = 0.00018906
            lij(1, 12) = 0.000054988
            lij(1, 13) = 0.000020958
            lij(1, 14) = 0.00001001
            lij(1, 15) = 0.0000025438
            lij(1, 16) = 0.00000066361
            lij(1, 17) = 0.0000001229
            lij(1, 18) = 0.000000027213
            lij(1, 19) = 0.0000000043714
            lij(1, 20) = 0.0000000007578
            lij(1, 21) = 0.00000000024786
            lij(1, 22) = 0.00000000000022384
            lij(1, 23) = 0.0000000000000246
            lij(1, 24) = 0.000000000000015699

            lij(2, 1) = 2.9055
            lij(2, 2) = 3.2881
            lij(2, 3) = 0.93805
            lij(2, 4) = 0.37073
            lij(2, 5) = 0.11118
            lij(2, 6) = 0.036143
            lij(2, 7) = 0.013272
            lij(2, 8) = 0.0050133
            lij(2, 9) = 0.0013655
            lij(2, 10) = 0.00055158
            lij(2, 11) = 0.00017873
            lij(2, 12) = 0.000049032
            lij(2, 13) = 0.000017058
            lij(2, 14) = 0.0000070465
            lij(2, 15) = 0.000002319
            lij(2, 16) = 0.0000006448
            lij(2, 17) = 0.00000012649
            lij(2, 18) = 0.000000025548
            lij(2, 19) = 0.0000000084782
            lij(2, 20) = 0.0000000007513
            lij(2, 21) = 0.00000000024188
            lij(2, 22) = 0.00000000000022739
            lij(2, 23) = 0.000000000000090536
            lij(2, 24) = 0.0000000000000056098

            lij(3, 1) = 2.1836
            lij(3, 2) = 10.02
            lij(3, 3) = 0.6433
            lij(3, 4) = 0.2186
            lij(3, 5) = 0.1004
            lij(3, 6) = 0.03728
            lij(3, 7) = 0.01435
            lij(3, 8) = 0.004549
            lij(3, 9) = 0.001328
            lij(3, 10) = 0.0005356
            lij(3, 11) = 0.000173
            lij(3, 12) = 0.00004881
            lij(3, 13) = 0.00002006
            lij(3, 14) = 0.000008319
            lij(3, 15) = 0.000002358
            lij(3, 16) = 0.000000645
            lij(3, 17) = 0.0000001278
            lij(3, 18) = 0.00000002466
            lij(3, 19) = 0.000000009378
            lij(3, 20) = 0.000000000745
            lij(3, 21) = 0.0000000002426
            lij(3, 22) = 0.000000000000221
            lij(3, 23) = 0.0000000000000264
            lij(3, 24) = 0.0000000000000138

        End Function

        Public Function Ps_din25463(ByVal dt, ByVal Nh) As Double

            Call Init_din25463()
            Dim Sum As Double

            For k = 1 To Nh

                Pt(k) = DinPower(k)
                Tk(k) = DinZeit(k) * 24 * 60.0 * 60.0
                Pik(1, k) = DinU235(k) * Pt(k)
                Pik(2, k) = DinU238(k) * Pt(k)
                Pik(3, k) = DinP239(k) * Pt(k)

            Next k

            For k = 1 To Nh

                ttk(k) = dt
                For j = 1 To k - 1
                    ttk(k) = ttk(k) + Tk(j)
                Next j

            Next k

            Sum = 0

            For i = 1 To 3
                For k = 1 To Nh
                    For j = 1 To 24

                        Sum = Sum + (Pik(i, k) / Qi(i)) * ((aij(i, j) / lij(i, j)) * (1 - Math.Exp(-1.0# * lij(i, j) * Tk(k))) * (Math.Exp(-1.0# * lij(i, j) * ttk(k))))

                    Next j
                Next k
            Next i

            Ps_din25463 = Sum

        End Function

        Public Function Pb_din25463(ByVal dt, ByVal Nh) As Double

            Call Init_din25463()
            Dim EU As Double
            Dim lU As Double
            Dim ENp As Double
            Dim lNp As Double
            Dim a0 As Double
            Dim BU As Double
            Dim R As Double
            Dim Sum As Double
            Dim FU As Double
            Dim FNp As Double

            EU = 0.474
            lU = 0.000491
            ENp = 0.419
            lNp = 0.00000341
            a0 = DinEnrichment

            BU = 0.0

            For k = 1 To Nh

                Pt(k) = DinPower(k)
                Tk(k) = DinZeit(k) * 24 * 60.0 * 60.0
                Pik(1, k) = DinU235(k) * Pt(k)
                Pik(2, k) = DinU238(k) * Pt(k)
                Pik(3, k) = DinP239(k) * Pt(k)

                BU = BU + (DinPower(k) / DinHMM) * DinZeit(k)

            Next k

            R = 1.18 * Math.Exp(-0.141 * a0) - 0.2 + 0.0062 * BU


            For k = 1 To Nh

                ttk(k) = dt
                For j = 1 To k - 1
                    ttk(k) = ttk(k) + Tk(j)
                Next j

            Next k

            For k = 1 To Nh
                PQk(k) = 0
                For i = 1 To 3
                    PQk(k) = PQk(k) + Pik(i, k) / Qi(i)
                Next i
            Next k

            Sum = 0

            For k = 1 To Nh

                FU = EU * R * (1 - Math.Exp(-1.0# * lU * Tk(k))) * Math.Exp(-1.0# * lU * ttk(k))
                FNp = ENp * R * ((lU / (lU - lNp)) * (1 - Math.Exp(-1.0# * lNp * Tk(k))) * Math.Exp(-1.0# * lNp * ttk(k)) - (lNp / (lU - lNp)) * (1 - Math.Exp(-1.0# * lU * Tk(k))) * Math.Exp(-1.0# * lU * ttk(k)))

                Sum = Sum + PQk(k) * (FU + FNp)
            Next k

            Pb_din25463 = Sum

        End Function

        Public Function Pa_din25463(ByVal dt, ByVal Nh) As Double

            Call Init_As()
            Dim cnt As Integer
            Dim ast As Double
            Dim T1 As Double
            Dim T2 As Double
            Dim A1 As Double
            Dim A2 As Double

            cnt = 0

            For j = 1 To 65
                If dt <= Tss(j) Then
                    cnt = j
                    Exit For
                End If
            Next j

            If cnt = 0 Then
                cnt = 65
            End If

            If cnt = 1 Then
                cnt = 2
            End If

            T1 = Tss(cnt - 1)
            A1 = Ats(cnt - 1)
            T2 = Tss(cnt)
            A2 = Ats(cnt)

            ast = ((A2 - A1) / (T2 - T1)) * dt + ((A1 * T2 - A2 * T1) / (T2 - T1))

            Pa_din25463 = ast * Ps_din25463(dt, Nh)

        End Function


        Public Function Pcs_din25463(ByVal dt, ByVal Nh) As Double

            Call Init_din25463()
            Dim y As Double
            Dim ECs As Double
            Dim l4 As Double
            Dim sig3 As Double
            Dim sig4 As Double
            Dim aeff As Double
            Dim Teff As Double
            Dim Peff As Double
            Dim PQ As Double
            Dim FCs As Double

            For k = 1 To Nh

                Pt(k) = DinPower(k)
                Tk(k) = DinZeit(k) * 24 * 60.0 * 60.0
                Pik(1, k) = DinU235(k) * Pt(k)
                Pik(2, k) = DinU238(k) * Pt(k)
                Pik(3, k) = DinP239(k) * Pt(k)

            Next k

            y = 0.0683
            ECs = 1.717
            l4 = 0.00000001071
            sig3 = 1.07E-23
            sig4 = 1.68E-23
            aeff = 1.0# + 0.5 * DinEnrichment

            For k = 1 To Nh
                Sk(k) = (DinPower(k) * 1000.0 / DinHMM) * 25800000000000.0# / aeff
            Next k

            Teff = 0.0#
            For k = 1 To Nh
                If Sk(k) > 0 Then
                    Teff = Teff + Tk(k)
                End If
            Next k

            Peff = 0.0#
            For k = 1 To Nh
                Peff = Peff + (Sk(k) * Tk(k)) / Teff
            Next k

            PQ = 0.0#
            For k = 1 To Nh
                For i = 1 To 3
                    PQ = PQ + Pik(i, k) * Tk(k) / (Qi(i) * Teff)
                Next i
            Next k

            FCs = l4 * ECs * y * Math.Exp(-1.0# * l4 * dt) * ((1 - Math.Exp(-1.0# * Teff * (l4 + sig4 * Peff))) / (l4 + sig4 * Peff) + (Math.Exp(-1.0# * sig3 * Peff * Teff) - Math.Exp(-1.0# * Teff * (l4 + sig4 * Peff))) / (sig3 * Peff - (l4 + sig4 * Peff)))

            Pcs_din25463 = PQ * FCs

        End Function

        Public Function Pe_din25463(ByVal dt, ByVal Nh) As Double

            Call Init_As()
            Dim cnt As Integer
            Dim T1 As Double
            Dim T2 As Double
            Dim A1 As Double
            Dim A2 As Double
            Dim hst As Double

            cnt = 0

            For j = 1 To 65
                If dt <= Tss(j) Then
                    cnt = j
                    Exit For
                End If
            Next j

            If cnt = 0 Then
                cnt = 65
            End If

            If cnt = 1 Then
                cnt = 2
            End If

            T1 = Tss(cnt - 1)
            A1 = Hts(cnt - 1)
            T2 = Tss(cnt)
            A2 = Hts(cnt)

            hst = ((A2 - A1) / (T2 - T1)) * dt + ((A1 * T2 - A2 * T1) / (T2 - T1))

            Pe_din25463 = hst * Ps_din25463(dt, Nh)

        End Function

        Public Function Pfc_din25463(ByVal dt, ByVal Nh) As Double

            Pfc_din25463 = Ps_din25463(dt, Nh) + Pb_din25463(dt, Nh) + Pa_din25463(dt, Nh) + Pcs_din25463(dt, Nh) + Pe_din25463(dt, Nh)

        End Function


        Public Function DoIt(ByVal intervalle As Integer, ByRef zeiten() As Double, ByRef leistung() As Double, ByRef matvec() As Double, ByRef u235din() As Double, ByRef u238din() As Double, ByVal p239din() As Double) As Double

            Dim heat As Double
            Dim abklang As Double
            Dim i As Integer

            heat = -1.0

            For i = 1 To intervalle
                DinZeit(i) = zeiten(i)
                DinPower(i) = leistung(i)
                DinU235(i) = u235din(i)
                DinU238(i) = u238din(i)
                DinP239(i) = p239din(i)
            Next

            DinHMM = matvec(6)
            DinEnrichment = matvec(9)
            abklang = matvec(1)


            heat = Pfc_din25463(abklang, intervalle)

            DoIt = heat

        End Function

    End Class
End Namespace