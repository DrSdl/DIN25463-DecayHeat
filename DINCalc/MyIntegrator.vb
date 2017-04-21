Namespace DIN25463MOX
    Public Class MyIntegrator


        Private Integrator_nvar As Integer
        Private Integrator_eps As Double
        Private Integrator_h1 As Double
        Private Integrator_hmin As Double
        Private Integrator_function As DIN25463silverlight.DIN25463MOX.MyFunktion

        Public Sub New()

        End Sub


        Private Function derivs(ByRef x As Double, ByRef y() As Double, ByRef dydx() As Double) As Boolean
            ' we want to solve and equation of the form y'=f(y,x)
            ' deriv is the derivative of y, i.e. the evaluation of the right hand side f(y,x)

            Call Integrator_function.derivs(x, y, dydx)

        End Function

        Private Function jacobn(ByRef x As Double, ByRef y() As Double, ByRef dfdx() As Double, ByRef dfdy(,) As Double, ByRef N As Integer) As Boolean
            ' we want to solve and equation of the form y'=f(y,x)
            ' jacobn is the jacobian of f with respect to y

            Call Integrator_function.jacobn(x, y, dfdx, dfdy, N)

        End Function

        Public Function SetNVar(ByVal nvar As Integer) As Boolean
            Integrator_nvar = nvar
        End Function

        Public Function SetEps(ByVal eps As Double) As Boolean
            Integrator_eps = eps
        End Function

        Public Function SetH1(ByVal h1 As Double) As Boolean
            Integrator_h1 = h1
        End Function

        Public Function SetHMin(ByVal hmin As Double) As Boolean
            Integrator_hmin = hmin
        End Function

        Public Function DoStiffIntegration(ByRef tx1 As Double, ByRef tx2 As Double, ByRef tfunc As MyFunktion) As Boolean

            Dim x1 As Double
            Dim x2 As Double
            Dim nvar As Integer
            Dim nok As Integer
            Dim nbad As Integer
            Dim eps As Double
            Dim h1 As Double
            Dim hmin As Double
            Dim ystart(200) As Double
            Dim i As Integer

            Integrator_function = tfunc

            For i = 1 To Integrator_nvar
                ystart(i) = Integrator_function.GetStart(i)
            Next i

            x1 = tx1
            x2 = tx2

            nvar = Integrator_nvar
            eps = Integrator_eps
            h1 = Integrator_h1
            hmin = Integrator_hmin

            Call odeint(ystart, nvar, x1, x2, eps, h1, hmin, nok, nbad)


            Call Integrator_function.SetStart(ystart)


        End Function

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


        Private Function pzextr(ByRef iest As Integer, ByRef xest As Double, ByRef yest() As Double, ByRef yz() As Double, ByRef dy() As Double, ByRef nv As Integer, ByRef x() As Double, ByRef d(,) As Double) As Boolean

            Dim k1 As Integer
            Dim j As Integer

            Dim q As Double
            Dim f2 As Double
            Dim f1 As Double
            Dim delta As Double

            Dim c() As Double

            ReDim c(nv)

            x(iest) = xest

            For j = 1 To nv
                dy(j) = yest(j)
                yz(j) = yest(j)
            Next j


            If (iest = 1) Then

                For j = 1 To nv
                    d(j, 1) = yest(j)
                Next j

            Else

                For j = 1 To nv
                    c(j) = yest(j)
                Next j

                For k1 = 1 To iest - 1

                    delta = 1.0# / (x(iest - k1) - xest)
                    f1 = xest * delta
                    f2 = x(iest - k1) * delta

                    For j = 1 To nv
                        q = d(j, k1)
                        d(j, k1) = dy(j)
                        delta = c(j) - q
                        dy(j) = f1 * delta
                        c(j) = f2 * delta
                        yz(j) = yz(j) + dy(j)
                    Next j

                Next k1

                For j = 1 To nv
                    d(j, iest) = dy(j)
                Next j

            End If


        End Function



        Private Function Pow(ByRef x As Double, ByRef y As Double) As Double

            Pow = x ^ y

        End Function

        Private Function FMIN(ByRef x As Double, ByRef y As Double) As Double

            If (x < y) Then
                FMIN = x
            Else
                FMIN = y
            End If

        End Function

        Private Function FMAX(ByRef x As Double, ByRef y As Double) As Double

            If (x > y) Then
                FMAX = x
            Else
                FMAX = y
            End If

        End Function

        Private Function SIGN(ByRef x As Double, ByRef y As Double) As Double

            If (y >= 0) Then
                SIGN = Math.Abs(x)
            Else
                SIGN = -1 * Math.Abs(x)
            End If

        End Function

        Private Function simpr(ByRef y() As Double, ByRef dydx() As Double, ByRef dfdx() As Double, ByRef dfdy(,) As Double, ByRef N As Integer, ByRef xs As Double, ByRef htot As Double, ByRef nstep As Integer, ByRef yout() As Double) As Boolean

            Dim i As Integer
            Dim j As Integer
            Dim nn As Integer

            Dim d As Double
            Dim h As Double
            Dim x As Double

            Dim a(,) As Double
            Dim del() As Double
            Dim ytemp() As Double
            Dim indx() As Integer

            ReDim a(N, N)
            ReDim del(N)
            ReDim ytemp(N)
            ReDim indx(N)

            h = htot / nstep

            ' *************************************************************
            For i = 1 To N

                For j = 1 To N
                    a(i, j) = -h * dfdy(i, j)
                Next j

                a(i, i) = a(i, i) + 1
            Next i

            Call ludcmp(a, N, indx, d)

            ' *************************************************************
            For i = 1 To N
                yout(i) = h * (dydx(i) + h * dfdx(i))
            Next i

            Call lubksb(a, N, indx, yout)

            ' *************************************************************
            For i = 1 To N
                ytemp(i) = y(i) + (yout(i))
                del(i) = yout(i)
            Next i

            x = xs + h

            Call derivs(x, ytemp, yout)

            ' *************************************************************
            For nn = 2 To nstep

                For i = 1 To N
                    yout(i) = h * yout(i) - del(i)
                Next i

                Call lubksb(a, N, indx, yout)

                For i = 1 To N
                    del(i) = del(i) + 2.0# * yout(i)
                    ytemp(i) = ytemp(i) + del(i)
                Next i

                x = x + h

                Call derivs(x, ytemp, yout)

            Next nn


            ' *************************************************************
            For i = 1 To N
                yout(i) = h * yout(i) - del(i)
            Next i

            Call lubksb(a, N, indx, yout)

            For i = 1 To N
                yout(i) = yout(i) + ytemp(i)
            Next i


        End Function

        Private Function stifbs(ByRef y() As Double, ByRef dydx() As Double, ByRef nv As Integer, ByRef xx As Double, ByRef htry As Double, ByRef eps As Double, ByRef yscal() As Double, ByRef hdid As Double, ByRef hnext As Double) As Boolean

            Dim i As Integer
            Dim iq As Integer
            Dim km As Integer
            Dim k As Integer
            Dim kk As Integer

            Dim first As Integer
            Dim kmax As Integer
            Dim kopt As Integer
            Dim nvold As Integer

            Dim epsold As Double
            Dim xnew As Double

            Dim eps1 As Double
            Dim errmax As Double
            Dim fact As Double
            Dim h As Double
            Dim red As Double
            Dim scales As Double
            Dim work As Double
            Dim wrkmin As Double
            Dim xest As Double

            Dim IMAXX As Integer
            Dim KMAXX As Integer

            first = 1
            nvold = -1
            epsold = -1

            KMAXX = 7
            IMAXX = KMAXX + 1

            Dim a() As Double
            Dim alf(,) As Double
            Dim nseq() As Integer

            ReDim a(IMAXX + 1)
            ReDim alf(KMAXX + 1, KMAXX + 1)
            ReDim nseq(IMAXX + 1)

            nseq(1) = 0
            nseq(2) = 2
            nseq(3) = 6
            nseq(4) = 10
            nseq(5) = 14
            nseq(6) = 22
            nseq(7) = 34
            nseq(8) = 50
            nseq(9) = 70

            Dim reduct As Integer
            Dim exitflag As Integer

            exitflag = 0

            Dim SCALMX As Double
            Dim TINY As Double
            Dim REDMIN As Double
            Dim REDMAX As Double
            Dim SAFE1 As Double
            Dim SAFE2 As Double

            SCALMX = 0.1
            TINY = 1.0E-30
            REDMIN = 0.7
            REDMAX = 0.00001
            SAFE1 = 0.25
            SAFE2 = 0.7

            Dim d(,) As Double
            Dim dfdx() As Double
            Dim dfdy(,) As Double
            Dim err() As Double
            Dim x() As Double
            Dim yerr() As Double
            Dim ysav() As Double
            Dim yseq() As Double

            ReDim d(nv, KMAXX)
            ReDim dfdx(nv)
            ReDim dfdy(nv, nv)
            ReDim err(KMAXX)
            ReDim x(KMAXX)
            ReDim yerr(nv)
            ReDim ysav(nv)
            ReDim yseq(nv)


            ' ************************************** initalisation ***************************
            If (eps <> epsold Or nv <> nvold) Then

                hnext = -1.0E+29
                xnew = -1.0E+29

                eps1 = SAFE1 * eps
                a(1) = nseq(1) + 1

                For k = 1 To KMAXX
                    a(k + 1) = a(k) + nseq(k + 1)
                Next k


                For iq = 2 To KMAXX
                    For k = 1 To iq
                        alf(k, iq) = Pow(eps1, ((a(k + 1) - a(iq + 1)) / ((a(iq + 1) - a(1) + 1.0#) * (2 * k + 1))))
                    Next k
                Next iq

                epsold = eps
                nvold = nv
                a(1) = a(1) + nv

                For k = 1 To KMAXX
                    a(k + 1) = a(k) + nseq(k + 1)
                Next k

                For kopt = 2 To KMAXX
                    If (a(kopt + 1) > a(kopt) * alf(kopt - 1, kopt)) Then
                        Exit For
                    End If
                Next kopt

                kmax = kopt

            End If

            ' ************************************** calc Jacobian ***************************

            h = htry

            For i = 1 To nv
                ysav(i) = y(i)
                Call jacobn(xx, y, dfdx, dfdy, nv)
            Next i

            If (xx <> xnew Or h <> hnext) Then
                first = 1
                kopt = kmax
            End If

            reduct = 0
            ' ************************************** big integral loop ***************************

            Do

                For k = 1 To kmax
                    ' Worksheets("function").Cells(2, 1) = "stifbs do loop: " & k
                    xnew = xx + h

                    If (xnew = xx) Then
                        'MsgBox("step size underflow in stifbs: x=" & xx & "; h=" & h)
                        Exit Do
                    End If

                    Call simpr(ysav, dydx, dfdx, dfdy, nv, xx, h, nseq(k + 1), yseq)
                    xest = Math.Sqrt(h / nseq(k + 1))
                    Call pzextr(k, xest, yseq, y, yerr, nv, x, d)

                    If (k <> 1) Then
                        errmax = TINY

                        For i = 1 To nv
                            errmax = FMAX(errmax, Math.Abs(yerr(i) / yscal(i)))
                        Next i

                        errmax = errmax / eps
                        km = k - 1
                        err(km) = Pow(errmax / SAFE1, 1.0# / (2 * km + 1))
                    End If


                    If (k <> 1 And (k > kopt - 1 Or first = 1)) Then

                        If (errmax < 1.0#) Then
                            exitflag = 1
                            Exit Do
                        End If

                        If (k = kmax Or k = kopt + 1) Then
                            red = SAFE2 / err(km)
                            Exit Do
                        Else

                            If (k = kopt And alf(kopt - 1, kopt) < err(km)) Then
                                red = 1.0# / err(km)
                                Exit Do
                            End If

                            If (k = kmax And alf(km, kmax - 1) < err(km)) Then
                                red = alf(km, kmax - 1) * SAFE2 / err(km)
                                Exit Do
                            End If

                            If (alf(km, kopt) < err(km)) Then
                                red = alf(km, kopt - 1) / err(km)
                                Exit Do
                            End If

                        End If
                    End If

                Next k

                If (exitflag = 1) Then
                    Exit Do
                End If

                red = FMIN(red, REDMIN)
                red = FMAX(red, REDMAX)

                h = h * red
                reduct = 1

            Loop

            ' ************************************** cleanup ********************************
            xx = xnew
            hdid = h
            wrkmin = 1.0E+35

            For kk = 1 To km

                fact = FMAX(err(kk), SCALMX)
                work = fact * a(kk + 1)
                If (work < wrkmin) Then
                    scales = fact
                    wrkmin = work
                    kopt = kk + 1
                End If

            Next kk

            hnext = h / scales
            If (kopt >= k And kopt <> kmax And reduct <> 1) Then
                fact = FMAX(scales / alf(kopt - 1, kopt), SCALMX)

                If (a(kopt + 1) * fact <= wrkmin) Then
                    hnext = h / fact
                    kopt = kopt + 1
                End If

            End If


        End Function

        Private Function odeint(ByRef ystart() As Double, ByRef nvar As Integer, ByRef x1 As Double, ByRef x2 As Double, ByRef eps As Double, ByRef h1 As Double, ByRef hmin As Double, ByRef nok As Integer, ByRef nbad As Integer) As Boolean

            Dim nstp As Integer
            Dim i As Integer

            Dim xsav As Double
            Dim x As Double
            Dim hnext As Double
            Dim hdid As Double
            Dim h As Double

            Dim kmax As Integer
            Dim kount As Integer
            Dim dxsav As Double

            kmax = 0
            dxsav = 0

            Dim yscal() As Double
            Dim y() As Double
            Dim dydx() As Double
            Dim xp() As Double
            Dim yp(,) As Double

            Dim MAXSTP As Integer
            Dim TINY As Double

            ReDim yscal(nvar)
            ReDim y(nvar)
            ReDim dydx(nvar)
            ReDim xp(nvar)
            ReDim yp(nvar, kmax + 1)

            MAXSTP = 1000000
            TINY = 1.0E-30

            x = x1
            h = SIGN(h1, x2 - x1)

            nok = 0
            nbad = 0
            kount = 0


            For i = 1 To nvar
                y(i) = ystart(i)
            Next i

            If (kmax > 0) Then
                xsav = x - dxsav * 2
            End If

            For nstp = 1 To MAXSTP
                'Worksheets("function").Cells(31, 1) = "odint big step: " & nstp

                Call derivs(x, y, dydx)

                For i = 1 To nvar
                    yscal(i) = Math.Abs(y(i)) + Math.Abs(dydx(i) * h) + TINY
                Next i

                If (kmax > 0 And kount < kmax - 1 And Math.Abs(x - xsav) > Math.Abs(dxsav)) Then
                    kount = kount + 1
                    xp(kount) = x

                    For i = 1 To nvar
                        yp(i, kount) = y(i)
                    Next i

                    xsav = x
                End If


                If ((x + h - x2) * (x + h - x1) > 0.0#) Then
                    h = x2 - x
                End If

                Call stifbs(y, dydx, nvar, x, h, eps, yscal, hdid, hnext)

                If (hdid = h) Then
                    nok = nok + 1
                Else
                    nbad = nbad + 1
                End If

                If ((x - x2) * (x2 - x1) >= 0.0#) Then

                    For i = 1 To nvar
                        ystart(i) = y(i)
                    Next i

                    If (kmax > 0) Then
                        kount = kount + 1
                        xp(kount) = x

                        For i = 1 To nvar
                            yp(i, kount) = y(i)
                        Next i

                    End If

                    Exit Function
                End If

                If (Math.Abs(hnext) <= hmin) Then
                    'MsgBox("Step size too small in odeint")
                    Exit Function
                End If

                h = hnext

            Next nstp

            'MsgBox("Too manx steps in routine odeint")

        End Function



    End Class
End Namespace
