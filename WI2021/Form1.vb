Public Class Form1

    'Objekte (Fahrräder)
    Dim Rennrad As Fahrrad = New Fahrrad("Rennrad", 2, 10, 65, 0, 1, 1)
    Dim Crosser As Fahrrad = New Fahrrad("Crosser", 2, 11, 55, 0, 1, 1)
    Dim Triathlon As Fahrrad = New Fahrrad("Triathlon Rad", 2, 11, 65, 0, 1, 1)
    Dim Mountainbike As Fahrrad = New Fahrrad("Mountainbike", 1, 11, 55, 0, 1, 1)

    'Lokale Variablen für die Verarbeitung
    Dim CurrentFahrrad As Fahrrad
    Dim FlagLeft As Boolean
    Dim FlagRight As Boolean


    'GroupBox1 Funktionen
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles Crosser_PB.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen
        setGroupVisible(Crosser)        'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles Rennrad_PB.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlasse
        setGroupVisible(Rennrad)        'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles Triathlon_PB.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen
        setGroupVisible(Triathlon)      'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles Mountain_PB.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen 
        setGroupVisible(Mountainbike)   'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Crosser_B.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen
        setGroupVisible(Crosser)        'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Rennrad_B.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen
        setGroupVisible(Rennrad)        'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Triathlon_B.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen
        setGroupVisible(Triathlon)      'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Sub Button4_Click(sender As Object, e As EventArgs) Handles Mountain_B.Click
        GroupBox1.Visible = False       'Die erste Ansicht verlassen
        setGroupVisible(Mountainbike)   'Aufruf der Funktion, die die Ansicht wechselt 
    End Sub

    Private Sub setGroupVisible(crtFahrrad As Fahrrad)
        GroupBox2.Visible = True                    'Die zweite Ansicht wird angezeigt 
        CurrentFahrrad = crtFahrrad                 'Das derzeitige Fahrrad wird ausgewählt
        FahrradName.Text = CurrentFahrrad.FName     'Der Titel für die Ansicht 2 wurde gesetzt
    End Sub

    'Das Ende von GroupBox1 

    'GroupBox2 
    Private Sub LosFahren(sender As Object, e As EventArgs) Handles los_fahren.Click
        setGeschw()
    End Sub

    Public Sub setGeschw()
        'Hier wird die Geschwindigkeit runter gezählt
        While CurrentFahrrad.Geschwindigkeit < ((CurrentFahrrad.FMaxGeschw / (CurrentFahrrad.FKettenblaetter * CurrentFahrrad.FRitzel)) * CurrentFahrrad.CurrentRitze * CurrentFahrrad.CurrentKette)
            CurrentFahrrad.Geschwindigkeit += 0.1
            GeschwAnzeige.Text = $"{CurrentFahrrad.Geschwindigkeit.ToString("F1")} km/h"
            GeschwAnzeige.Refresh()
            System.Threading.Thread.Sleep(25)
        End While

        'Hier wird die Geschwindigkeit runter gezählt 
        While CurrentFahrrad.Geschwindigkeit > (((CurrentFahrrad.FMaxGeschw / (CurrentFahrrad.FKettenblaetter * CurrentFahrrad.FRitzel)) * CurrentFahrrad.CurrentKette * CurrentFahrrad.CurrentRitze) + 1)
            CurrentFahrrad.Geschwindigkeit -= 0.1
            GeschwAnzeige.Text = $"{CurrentFahrrad.Geschwindigkeit.ToString("F1")} km/h"
            GeschwAnzeige.Refresh()
            System.Threading.Thread.Sleep(25)
        End While
    End Sub

    Private Sub Hochschalten_Ritze(sender As Object, e As EventArgs) Handles HochRitze.Click
        If CurrentFahrrad.CurrentRitze < CurrentFahrrad.FRitzel Then
            CurrentFahrrad.CurrentRitze += 1
            RitzelAnzeige.Text = CurrentFahrrad.CurrentRitze
            RitzelAnzeige.Refresh()
            setGeschw()
        End If
    End Sub

    Private Sub Runterschalten_Ritze(sender As Object, e As EventArgs) Handles RunterRitze.Click
        If CurrentFahrrad.CurrentRitze > 1 Then
            CurrentFahrrad.CurrentRitze -= 1
            RitzelAnzeige.Text = CurrentFahrrad.CurrentRitze
            RitzelAnzeige.Refresh()
            setGeschw()
        End If
    End Sub

    Private Sub Hochschalten_Kette(sender As Object, e As EventArgs) Handles HochKette.Click
        If CurrentFahrrad.CurrentKette < CurrentFahrrad.FKettenblaetter Then
            CurrentFahrrad.CurrentKette += 1
            KetteAnzeige.Text = CurrentFahrrad.CurrentKette
            KetteAnzeige.Refresh()
            setGeschw()
        End If
    End Sub

    Private Sub Runterschalten_Kette(sender As Object, e As EventArgs) Handles RunterKette.Click
        If CurrentFahrrad.CurrentKette > 1 Then
            CurrentFahrrad.CurrentKette -= 1
            KetteAnzeige.Text = CurrentFahrrad.CurrentKette
            KetteAnzeige.Refresh()
            setGeschw()
        End If
    End Sub

    Private Sub Blink_Left(ByVal sender As Object, ByVal e As EventArgs) Handles BlinkLinks.Click
        FlagRight = False
        FlagLeft = True
        BlinkRightBox.Visible = False
        Blink("left")
    End Sub

    Private Sub Blink_Right(sender As Object, e As EventArgs) Handles BlinkRechts.Click
        FlagLeft = False
        FlagRight = True
        BlinkLeftBox.Visible = False
        Blink("right")
    End Sub



    Private Async Sub Blink(left_right As String)
        Dim i = 0
        While i < 120
            If left_right = "right" And FlagRight Then
                If BlinkRightBox.Visible Then
                    BlinkRightBox.Hide()
                Else
                    BlinkRightBox.Show()
                End If
            ElseIf left_right = "left" And FlagLeft Then
                If BlinkLeftBox.Visible Then
                    BlinkLeftBox.Hide()
                Else
                    BlinkLeftBox.Show()
                End If
            End If

            i += 1
            Await Task.Delay(250)
        End While
    End Sub


    Private Sub lala(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 97 Or Asc(e.KeyChar) = 65 Then
            Label1.Visible = False
        End If
    End Sub

    Public Sub Textox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Label1.KeyPress
        If (e.KeyCode < Keys.D0 And e.KeyCode > Keys.D9) Then
            Label1.Visible = False
        End If
    End Sub
End Class
