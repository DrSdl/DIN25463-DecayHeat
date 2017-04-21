Imports System.Xml.Linq
Imports C1.Silverlight
Imports C1.Silverlight.Extended
Imports C1.Silverlight.DataGrid
Imports DIN25463silverlight.DIN25463MOX
Imports DIN25463silverlight.DIN25463URAN1982

' (c) 2013 DrSdl
' The program is provided as is, without any warranties
' This program is only for educational purposes.
'
' Decay heat calculations with Silverlight frontend for the DIN25463 Standard 2015
' The routines were first implemented within Excel and VBA. The wonderful thing about
' .Net is that one can easily transfer from Excel VBA to a Web-Application, as 
' demonstrated for this project.
'
' The WebApp is running at www.din25463.de



Partial Public Class MainPage
    Inherits UserControl

    Dim intervalle As Integer
    Dim klaenge As Integer
    Dim zeiten(100) As Double
    Dim leistung(100) As Double
    Dim abklaenge(100) As Double
    Dim heizen(100) As Double
    Dim matvec(20) As Double

    Dim u235din(100) As Double
    Dim u238din(100) As Double
    Dim p239din(100) As Double

    Dim DINmode As Integer

    Dim xprogress As ProgressWindow

    Public Sub New()
        ' DIN25463-MOX 2008, default
        DINmode = 0
        ' DIN25463-URAN 2010
        'DINmode = 1
        ' ANS-5.1 2005
        'DINmode = 2
        ' DIN25463-URAN 1982
        'DINmode = 3

        InitializeComponent()
        LoadMyDINData()
        LoadMyReactorData()
        LoadMyTimesData()

        LoadMyDINOutput()
        CalcMyDINMOX2010()

        UpdateMyDINOutput()
    End Sub


    Private Sub HyperlinkButton_MouseEnter_1(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs)

        Dim MyImaga As New Image

        MyImaga.Source = New Imaging.BitmapImage(New Uri("../Resources/DIN contact red02a.png", UriKind.Relative))
        'MyImaga.Height = "8"
        CTbutton.Content = MyImaga

    End Sub

    Private Sub HyperlinkButton_MouseLeave_1(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs)

        Dim MyImaga As New Image

        MyImaga.Source = New Imaging.BitmapImage(New Uri("../Resources/DIN contact black02a.png", UriKind.Relative))
        'MyImaga.Height = "8"
        CTbutton.Content = MyImaga

    End Sub


    Public Sub UpdateMyDINOutput()

        Dim MyData As New List(Of Reactoroutput)
        Dim i As Integer


        For i = 1 To klaenge
            MyData.Add(New Reactoroutput(heizen(i), "MW", abklaenge(i), "sec"))
        Next

        MyDINOutput.ItemsSource = MyData

    End Sub

    Public Sub LoadMyDINOutput()

        Dim LoaderDoc As XDocument

        LoaderDoc = XDocument.Load("DIN_results.xml")

        Dim MyData As New List(Of Reactoroutput)

        For Each x In LoaderDoc.Descendants("DINOutput")
            MyData.Add(New Reactoroutput(x.Attribute("Power").Value, x.Attribute("UnitP").Value, x.Attribute("Interval").Value, x.Attribute("UnitT").Value))
        Next

        MyDINOutput.ItemsSource = MyData

    End Sub

    Private Sub MyDINOutput_AutoGeneratingColumn(ByVal sender As Object, ByVal e As C1.Silverlight.DataGrid.DataGridAutoGeneratingColumnEventArgs)

        If (e.Property.Name = "Power") Then
            e.Column.Format = "F5"
        End If

    End Sub



    Public Sub CalcMyDINMOX2010()

        Dim x As DINinput
        Dim y As Reactorinput
        Dim z As Timesinput
        Dim DINMOX As New DIN25463MOXIntegrator

        intervalle = 0
        klaenge = 0

        For Each x In MyDINInput.ItemsSource
            If (x.Name = "HMM heavy metal mass") Then
                matvec(6) = Convert.ToDouble(x.Value)

                If (x.Unit = "kg") Then
                    matvec(6) = matvec(6) * 1
                End If

                If (x.Unit = "g") Then
                    matvec(6) = matvec(6) / 1000
                End If

                If (x.Unit = "t") Then
                    matvec(6) = matvec(6) * 1000
                End If

            End If

            If (x.Name = "Pufiss content") Then
                matvec(7) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Am241") Then
                matvec(8) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "U-vector U234") Then
                matvec(9) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "U-vector U235") Then
                matvec(10) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "U-vector U238") Then
                matvec(11) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Pu-vector Pu238") Then
                matvec(12) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Pu-vector Pu239") Then
                matvec(13) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Pu-vector Pu240") Then
                matvec(14) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Pu-vector Pu241") Then
                matvec(15) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Pu-vector Pu242") Then
                matvec(16) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "Pu-quality") Then
                matvec(17) = Convert.ToDouble(x.Value)
            End If

            If (x.Name = "moderator-to-fuel ratio") Then
                matvec(18) = Convert.ToDouble(x.Value)
            End If

        Next


        For Each y In MyReactorInput.ItemsSource
            intervalle = intervalle + 1

            If (intervalle > 99) Then
                Exit For
            End If

            leistung(intervalle) = Convert.ToDouble(y.Power)

            If (y.UnitP = "MW") Then
                leistung(intervalle) = leistung(intervalle) * 1
            End If

            If (y.UnitP = "W") Then
                leistung(intervalle) = leistung(intervalle) / 1000000.0
            End If

            If (y.UnitP = "kW") Then
                leistung(intervalle) = leistung(intervalle) / 1000.0
            End If

            If (y.UnitP = "GW") Then
                leistung(intervalle) = leistung(intervalle) * 1000.0
            End If


            zeiten(intervalle) = Convert.ToDouble(y.Time)

            If (y.UnitT = "days" Or y.UnitT = "d") Then
                zeiten(intervalle) = zeiten(intervalle) * 1
            End If

            If (y.UnitT = "hours" Or y.UnitT = "h") Then
                zeiten(intervalle) = zeiten(intervalle) / 24.0
            End If

            If (y.UnitT = "min" Or y.UnitT = "m") Then
                zeiten(intervalle) = zeiten(intervalle) / (24.0 * 60)
            End If

            If (y.UnitT = "sec" Or y.UnitT = "s") Then
                zeiten(intervalle) = zeiten(intervalle) / (24.0 * 60 * 60)
            End If

        Next

        For Each z In MyTimesInput.ItemsSource
            klaenge = klaenge + 1

            If (klaenge > 99) Then
                Exit For
            End If

            abklaenge(klaenge) = Convert.ToDouble(z.Time)

            If (z.Unit = "days" Or z.Unit = "d") Then
                abklaenge(klaenge) = abklaenge(klaenge) * (24.0 * 60 * 60)
            End If

            If (z.Unit = "hours" Or z.Unit = "h") Then
                abklaenge(klaenge) = abklaenge(klaenge) * (60 * 60.0)
            End If

            If (z.Unit = "min" Or z.Unit = "m") Then
                abklaenge(klaenge) = abklaenge(klaenge) * (60.0)
            End If

            If (z.Unit = "sec" Or z.Unit = "s") Then
                abklaenge(klaenge) = abklaenge(klaenge) * 1.0
            End If


        Next

        Dim i As Integer
        Dim heat As Double

        For i = 1 To klaenge
            matvec(1) = abklaenge(i)
            heat = DINMOX.DoIt(intervalle, zeiten, leistung, matvec)
            heizen(i) = heat
        Next

    End Sub


    Public Sub CalcMyDINUran1982()

        Dim x As DINinput
        Dim y As ReactorinputDIN1990uran
        Dim z As Timesinput
        Dim DINURAN As New DIN25463URAN1982Integrator

        intervalle = 0
        klaenge = 0

        For Each x In MyDINInput.ItemsSource()
            If (x.Name = "HMM heavy metal mass") Then
                matvec(6) = Convert.ToDouble(x.Value)

                If (x.Unit = "kg") Then
                    matvec(6) = matvec(6) * 1
                End If

                If (x.Unit = "g") Then
                    matvec(6) = matvec(6) / 1000
                End If

                If (x.Unit = "t") Then
                    matvec(6) = matvec(6) * 1000
                End If

            End If

            If (x.Name = "U-vector U235") Then
                matvec(9) = Convert.ToDouble(x.Value)
            End If


        Next


        For Each y In MyReactorInput.ItemsSource
            intervalle = intervalle + 1

            If (intervalle > 99) Then
                Exit For
            End If

            leistung(intervalle) = Convert.ToDouble(y.Power)

            If (y.UnitP = "MW") Then
                leistung(intervalle) = leistung(intervalle) * 1
            End If

            If (y.UnitP = "W") Then
                leistung(intervalle) = leistung(intervalle) / 1000000.0
            End If

            If (y.UnitP = "kW") Then
                leistung(intervalle) = leistung(intervalle) / 1000.0
            End If

            If (y.UnitP = "GW") Then
                leistung(intervalle) = leistung(intervalle) * 1000.0
            End If


            zeiten(intervalle) = Convert.ToDouble(y.Time)

            If (y.UnitT = "days" Or y.UnitT = "d") Then
                zeiten(intervalle) = zeiten(intervalle) * 1
            End If

            If (y.UnitT = "hours" Or y.UnitT = "h") Then
                zeiten(intervalle) = zeiten(intervalle) / 24.0
            End If

            If (y.UnitT = "min" Or y.UnitT = "m") Then
                zeiten(intervalle) = zeiten(intervalle) / (24.0 * 60)
            End If

            If (y.UnitT = "sec" Or y.UnitT = "s") Then
                zeiten(intervalle) = zeiten(intervalle) / (24.0 * 60 * 60)
            End If

            u235din(intervalle) = Convert.ToDouble(y.U235)
            u238din(intervalle) = Convert.ToDouble(y.U238)
            p239din(intervalle) = Convert.ToDouble(y.P239)

            If (y.UnitV = "%") Then
                u235din(intervalle) = u235din(intervalle) / 100
                u238din(intervalle) = u238din(intervalle) / 100
                p239din(intervalle) = p239din(intervalle) / 100
            End If

            If (y.UnitV = "-") Then
                'do nothing
            End If

        Next

        For Each z In MyTimesInput.ItemsSource
            klaenge = klaenge + 1

            If (klaenge > 99) Then
                Exit For
            End If

            abklaenge(klaenge) = Convert.ToDouble(z.Time)

            If (z.Unit = "days" Or z.Unit = "d") Then
                abklaenge(klaenge) = abklaenge(klaenge) * (24.0 * 60 * 60)
            End If

            If (z.Unit = "hours" Or z.Unit = "h") Then
                abklaenge(klaenge) = abklaenge(klaenge) * (60 * 60.0)
            End If

            If (z.Unit = "min" Or z.Unit = "m") Then
                abklaenge(klaenge) = abklaenge(klaenge) * (60.0)
            End If

            If (z.Unit = "sec" Or z.Unit = "s") Then
                abklaenge(klaenge) = abklaenge(klaenge) * 1.0
            End If


        Next

        Dim i As Integer
        Dim heat As Double

        For i = 1 To klaenge
            matvec(1) = abklaenge(i)
            heat = DINURAN.DoIt(intervalle, zeiten, leistung, matvec, u235din, u238din, p239din)
            heizen(i) = heat
        Next

    End Sub


    Public Sub LoadMyDINData()

        Dim LoaderDoc As XDocument

        LoaderDoc = XDocument.Load("DIN_MOX_2009_input.xml")

        Dim MyData As New List(Of DINinput)

        For Each x In LoaderDoc.Descendants("DINinput")
            MyData.Add(New DINinput(x.Attribute("Name").Value, x.Attribute("Unit").Value, x.Attribute("Value").Value))
        Next

        MyDINInput.ItemsSource = MyData

    End Sub

    Public Sub LoadMyDIN1990uranData()

        Dim LoaderDoc As XDocument

        LoaderDoc = XDocument.Load("DIN_URAN_1990_input.xml")

        Dim MyData As New List(Of DINinput)

        For Each x In LoaderDoc.Descendants("DINinput")
            MyData.Add(New DINinput(x.Attribute("Name").Value, x.Attribute("Unit").Value, x.Attribute("Value").Value))
        Next

        MyDINInput.ItemsSource = MyData

    End Sub

    Public Sub LoadMyReactorData()

        Dim LoaderDoc As XDocument

        LoaderDoc = XDocument.Load("ReactorPower_input.xml")

        Dim MyData As New List(Of Reactorinput)

        For Each x In LoaderDoc.Descendants("Reactorinput")
            MyData.Add(New Reactorinput(x.Attribute("Power").Value, x.Attribute("UnitP").Value, x.Attribute("Interval").Value, x.Attribute("UnitT").Value))
        Next

        MyReactorInput.ItemsSource = MyData

    End Sub

    Public Sub LoadMyReactorDataDIN1990uran()

        Dim LoaderDoc As XDocument

        LoaderDoc = XDocument.Load("ReactorPower_din1990uran_input.xml")

        Dim MyData As New List(Of ReactorinputDIN1990uran)

        For Each x In LoaderDoc.Descendants("Reactorinput")
            MyData.Add(New ReactorinputDIN1990uran(x.Attribute("Power").Value, x.Attribute("UnitP").Value, x.Attribute("Interval").Value, x.Attribute("UnitT").Value, x.Attribute("U235power").Value, x.Attribute("U238power").Value, x.Attribute("P239power").Value, x.Attribute("UnitV").Value))
        Next

        MyReactorInput.ItemsSource = MyData

    End Sub

    Public Sub LoadMyTimesData()

        Dim LoaderDoc As XDocument

        LoaderDoc = XDocument.Load("DecayTimes_input.xml")

        Dim MyData As New List(Of Timesinput)

        For Each x In LoaderDoc.Descendants("Timeinput")
            MyData.Add(New Timesinput(x.Attribute("Shutdown").Value, x.Attribute("Unit")))
        Next

        MyTimesInput.ItemsSource = MyData

    End Sub

    Private Sub DoIt_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        xprogress = New ProgressWindow
        xprogress.CenterOnScreen()
        xprogress.Show()

        If (DINmode = 0) Then
            CalcMyDINMOX2010()

            UpdateMyDINOutput()
        End If

        If (DINmode = 3) Then
            CalcMyDINUran1982()

            UpdateMyDINOutput()
        End If


        xprogress.StopMe()
    End Sub

    Private Sub WhichHeat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As C1.Silverlight.PropertyChangedEventArgs(Of System.Int32))

        Dim uwindow As New UnableWindow
        uwindow.CenterOnScreen()

        Dim i As Integer

        i = e.NewValue

        If i = 0 Then
            If DINmode <> 0 Then
                LoadMyDINData()
                LoadMyReactorData()
            End If
            DINmode = 0
        End If

        If i = 3 Then
            DINmode = 1
            DINmode = 0
            uwindow.Show()
        End If

        If i = 2 Then
            DINmode = 2
            DINmode = 0
            uwindow.Show()
        End If

        If i = 1 Then
            If DINmode <> 3 Then
                LoadMyDIN1990uranData()
                LoadMyReactorDataDIN1990uran()
            End If
            DINmode = 3
            'DINmode = 0
            'uwindow.Show()
        End If

    End Sub
End Class


Public Class DINinput

    Dim myName As String
    Dim myUnit As String
    Dim myValue As Double

    Public Sub New()

        Name = "def"
        Unit = "%"
        Value = 0

    End Sub

    Public Sub New(ByVal s1 As String, ByVal s2 As String, ByVal x As Double)

        Name = s1
        Unit = s2
        Value = x

    End Sub

    Public Sub DINinput(ByVal s1 As String, ByVal s2 As String, ByVal x As Double)

        Name = s1
        Unit = s2
        Value = x

    End Sub

    Public Property Name() As String
        Get
            Return myName
        End Get

        Set(ByVal value As String)
            myName = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return myUnit
        End Get

        Set(ByVal value As String)
            myUnit = value
        End Set
    End Property

    Public Property Value() As Double
        Get
            Return myValue
        End Get

        Set(ByVal value As Double)
            myValue = value
        End Set
    End Property

End Class


Public Class Reactorinput

    Dim myPower As Double
    Dim myUnitP As String
    Dim myTime As Double
    Dim myUnitT As String

    Public Sub New()

        myPower = 0
        myUnitP = "MW"
        myTime = 0
        myUnitT = "days"
    End Sub

    Public Sub New(ByVal x1 As Double, ByVal s1 As String, ByVal x2 As Double, ByVal s2 As String)

        myPower = x1
        myTime = x2

        myUnitP = s1
        myUnitT = s2

    End Sub

    Public Sub Reactorinput(ByVal x1 As Double, ByVal s1 As String, ByVal x2 As Double, ByVal s2 As String)

        myPower = x1
        myTime = x2

        myUnitP = s1
        myUnitT = s2

    End Sub


    Public Property Power() As Double
        Get
            Return myPower
        End Get

        Set(ByVal value As Double)
            myPower = value
        End Set
    End Property

    Public Property UnitP() As String
        Get
            Return myUnitP
        End Get

        Set(ByVal value As String)
            myUnitP = value
        End Set
    End Property

    Public Property Time() As Double
        Get
            Return myTime
        End Get

        Set(ByVal value As Double)
            myTime = value
        End Set
    End Property

    Public Property UnitT() As String
        Get
            Return myUnitT
        End Get

        Set(ByVal value As String)
            myUnitT = value
        End Set
    End Property



End Class

Public Class Timesinput

    Dim myTime As Double
    Dim myUnit As String

    Public Sub New()

        myTime = 0
        myUnit = "sec"
    End Sub

    Public Sub New(ByVal x1 As Double, ByVal s As String)

        myTime = x1
        myUnit = s

    End Sub

    Public Sub Timesinput(ByVal x1 As Double, ByVal s As String)

        myTime = x1
        myUnit = s
    End Sub

    Public Property Time() As Double
        Get
            Return myTime
        End Get

        Set(ByVal value As Double)
            myTime = value
        End Set
    End Property


    Public Property Unit() As String
        Get
            Return myUnit
        End Get

        Set(ByVal value As String)
            myUnit = value
        End Set
    End Property
End Class

Public Class Reactoroutput

    Dim myPower As Double
    Dim myUnitP As String
    Dim myTime As Double
    Dim myUnitT As String

    Public Sub New()

        myPower = 0
        myUnitP = "MW"
        myTime = 0
        myUnitT = "days"

    End Sub

    Public Sub New(ByVal x1 As Double, ByVal s1 As String, ByVal x2 As Double, ByVal s2 As String)

        myPower = x1
        myTime = x2

        myUnitP = s1
        myUnitT = s2

    End Sub

    Public Sub Reactoroutput(ByVal x1 As Double, ByVal s1 As String, ByVal x2 As Double, ByVal s2 As String)

        myPower = x1
        myTime = x2

        myUnitP = s1
        myUnitT = s2

    End Sub

    Public Property Power() As Double
        Get
            Return myPower
        End Get

        Set(ByVal value As Double)
            myPower = value
        End Set
    End Property

    Public Property UnitP() As String
        Get
            Return myUnitP
        End Get

        Set(ByVal value As String)
            myUnitP = value
        End Set
    End Property

    Public Property Time() As Double
        Get
            Return myTime
        End Get

        Set(ByVal value As Double)
            myTime = value
        End Set
    End Property

    Public Property UnitT() As String
        Get
            Return myUnitT
        End Get

        Set(ByVal value As String)
            myUnitT = value
        End Set
    End Property
End Class

Public Class ReactorinputDIN1990uran

    Dim myPower As Double
    Dim myUnitP As String
    Dim myTime As Double
    Dim myUnitT As String

    Dim myU235Power As Double
    Dim myU238Power As Double
    Dim myP239Power As Double

    Dim myUnitV As String


    Public Sub New()

        myPower = 0
        myUnitP = "MW"
        myTime = 0
        myUnitT = "days"

        myU235Power = 0
        myU238Power = 0
        myP239Power = 0

        myUnitV = "-"

    End Sub

    Public Sub New(ByVal x1 As Double, ByVal s1 As String, ByVal x2 As Double, ByVal s2 As String, ByVal x3 As Double, ByVal x4 As Double, ByVal x5 As Double, ByVal s5 As String)

        myPower = x1
        myTime = x2

        myUnitP = s1
        myUnitT = s2

        myU235Power = x3
        myU238Power = x4
        myP239Power = x5

        myUnitV = s5

    End Sub

    Public Sub ReactorinputDIN1990uran(ByVal x1 As Double, ByVal s1 As String, ByVal x2 As Double, ByVal s2 As String, ByVal x3 As Double, ByVal x4 As Double, ByVal x5 As Double, ByVal s5 As String)

        myPower = x1
        myTime = x2

        myUnitP = s1
        myUnitT = s2

        myU235Power = x3
        myU238Power = x4
        myP239Power = x5

        myUnitV = s5

    End Sub

    Public Property Power() As Double
        Get
            Return myPower
        End Get

        Set(ByVal value As Double)
            myPower = value
        End Set
    End Property

    Public Property UnitP() As String
        Get
            Return myUnitP
        End Get

        Set(ByVal value As String)
            myUnitP = value
        End Set
    End Property

    Public Property Time() As Double
        Get
            Return myTime
        End Get

        Set(ByVal value As Double)
            myTime = value
        End Set
    End Property

    Public Property UnitT() As String
        Get
            Return myUnitT
        End Get

        Set(ByVal value As String)
            myUnitT = value
        End Set
    End Property

    Public Property U235() As Double
        Get
            Return myU235Power
        End Get

        Set(ByVal value As Double)
            myU235Power = value
        End Set
    End Property

    Public Property U238() As Double
        Get
            Return myU238Power
        End Get

        Set(ByVal value As Double)
            myU238Power = value
        End Set
    End Property

    Public Property P239() As Double
        Get
            Return myP239Power
        End Get

        Set(ByVal value As Double)
            myP239Power = value
        End Set
    End Property



    Public Property UnitV() As String
        Get
            Return myUnitV
        End Get

        Set(ByVal value As String)
            myUnitV = value
        End Set
    End Property

End Class