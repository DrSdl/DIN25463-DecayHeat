Imports C1.Silverlight

Partial Public Class ProgressWindow
    Inherits C1Window
    Dim _timer As New Storyboard()

    Public Sub New()
        InitializeComponent()
        InitProgressBar()
    End Sub

    Public Sub InitProgressBar()

        CalcProgress.Value = 15

        _timer.Duration = TimeSpan.FromMilliseconds(20)
        AddHandler _timer.Completed, AddressOf _timer_Completed
        _timer.Begin()

    End Sub

    Public Sub _timer_Completed(ByVal sender As Object, ByVal e As EventArgs)

        If (CalcProgress.Value < CalcProgress.Maximum) Then
            CalcProgress.Value = CalcProgress.Value + 1
            _timer.Begin()
        Else
            'CalcProgress.Value = 0
            '_timer.Begin()
        End If

    End Sub

    Public Sub StopMe()
        CalcProgress.Value = CalcProgress.Maximum
        ProgressStatus.Text = "Finished."
        _timer.Stop()
    End Sub

End Class
