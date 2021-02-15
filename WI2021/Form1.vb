Public Class Form1

    'Objekte (Fahrräder)
    Dim Rennrad As Fahrrad = New Fahrrad("Rennrad", 2, 10, 65, 0, 1, 1)
    Dim Crosser As Fahrrad = New Fahrrad("Crosser", 2, 11, 55, 0, 1, 1)
    Dim Triathlon As Fahrrad = New Fahrrad("Triathlon Rad", 2, 11, 65, 0, 1, 1)
    Dim Mountainbike As Fahrrad = New Fahrrad("Mountainbike", 1, 11, 55, 0, 1, 1)
    Dim blabla As Fahrrad = New Fahrrad("huen", 5, 1, 65, 0, 1, 1)

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
        Dim i = 0                                                   'Funktionsvariable um die Schleife steuern zu können 
        While i < 120                                               'While Schleife, um die Blinker aufblinken zu lassen 
            If left_right = "right" And FlagRight Then              'If Anweisung, um zu entscheiden ob der linke oder rechte Blinker blinkt (Flag steuert, ob der Blinker stoppt, wenn die andere Richtung geklickt wird
                If BlinkRightBox.Visible Then                       'Hier wird die PictureBox sichtbar gemacht um den Blinker sehen zu können 
                    BlinkRightBox.Hide()
                Else
                    BlinkRightBox.Show()                            'Hier wird die PictureBox unsichtbar gemacht, um den Blinker nicht mehr sehen zu können
                End If
            ElseIf left_right = "left" And FlagLeft Then            'If Anweisung, um zu entscheiden ob der linke oder rechte Blinker blinkt (Flag steuert, ob der Blinker stoppt, wenn die andere Richtung geklickt wird
                If BlinkLeftBox.Visible Then                        'Hier wird die PictureBox sichtbar gemacht um den Blinker sehen zu können 
                    BlinkLeftBox.Hide()
                Else
                    BlinkLeftBox.Show()                             'Hier wird die PictureBox unsichtbar gemacht, um den Blinker nicht mehr sehen zu können
                End If
            End If

            i += 1                                                  'Variable hochzählen, damit die While Schleife auch mal stoppt 
            Await Task.Delay(250)                                   'Die Funktion pausieren, damit der Blinker überhaupt sichtbar ist
        End While
    End Sub


    Private Sub Zurueck_Button(sender As Object, e As EventArgs) Handles Zurueck.Click  'Der Zurück Button 
        CurrentFahrrad.Geschwindigkeit = 0      'Hier wird die Geschwindigkeit auf 0 gesetzt, damit sie wieder von null startet, wenn man das Fahrrad wechselt 
        CurrentFahrrad = Nothing                'Hier wird das Fahrrad wieder auf Null gesetzt, damit keine Fehler entstehen können  
        GroupBox2.Visible = False               'Hier wird die 2. Ansicht auf unsichtbar geschaltet
        GroupBox1.Visible = True                'Hier wird die 1. Ansicht wieder Sichtbar geschaltet 
    End Sub
End Class
