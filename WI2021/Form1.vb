Public Class Form1

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    'Objekte (Fahrräder)
    Dim Rennrad As Fahrrad = New Fahrrad("Rennrad", 2, 10, 65, 0, 1, 1)                     'Hier wird das Objekt Rennrad mit den entsprechenden Attributen erstellt 
    Dim Crosser As Fahrrad = New Fahrrad("Crosser", 2, 11, 55, 0, 1, 1)                     'Hier wird das Objekt Crosser mit den entsprechnenden Attributen erstellt 
    Dim Triathlon As Fahrrad = New Fahrrad("Triathlon Rad", 2, 11, 65, 0, 1, 1)             'Hier wird das Objekt Triathlon Rad mit den entsprechenden Attributen erstellt 
    Dim Mountainbike As Fahrrad = New Fahrrad("Mountainbike", 1, 11, 55, 0, 1, 1)           'Hier wird das Objekt Mountainbike mit den entsprechenden Attributen erstellt 

    'Lokale Variablen für die Verarbeitung
    Dim CurrentFahrrad As Fahrrad                               'Hier wird das in der ersten Ansicht ausgewählte Fahrrad zwischengespeichert um damit zu arbeiten 
    Dim FlagLeft As Boolean                                     'Dies ist eine Flag um den Linksblinker aktivieren zu können 
    Dim FlagRight As Boolean                                    'Dies ist eine Flag um den Rechtsblinker aktivieren zu können 
    Dim Herzfrequenz As Integer = 90                            'Dies ist die Variable für die Herzfrequenz
    Dim Drehzahl As Double                                      'Dies ist die Variable für die Drezahl 
    Public Const PI As Double = 3.1415926535897931              'Dies ist die Konstante Pi, damit die Drezhahl ausgerechnet werden kann 
    Dim AngGeschwindigkeit As Integer                           'Dies ist die Variable welche den Text von der Textbox übernimmt 


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
        If IsNumeric(TextBox1.Text) Then
            AngGeschwindigkeit = TextBox1.Text          'Die Geschwindigkeit wird gespeichert 
            setGeschw()                                 'Die Geschwindigkeitsfunktion wird aufgerufen
            HerzfrequenzSub()                           'Die Herzfrequenz wird angefangen hoch zu zählen 
        Else
            MsgBox("Bitte geben Sie eine Geschwindigkeit an.")
        End If
    End Sub

    Public Sub setGeschw()
        'Hier wird die Geschwindigkeit hoch gezählt,
        While CurrentFahrrad.Geschwindigkeit < ((CurrentFahrrad.FMaxGeschw / (CurrentFahrrad.FKettenblaetter * CurrentFahrrad.FRitzel)) * CurrentFahrrad.CurrentRitze * CurrentFahrrad.CurrentKette) And CurrentFahrrad.Geschwindigkeit < AngGeschwindigkeit
            CurrentFahrrad.Geschwindigkeit += 0.1
            GeschwAnzeige.Text = $"{CurrentFahrrad.Geschwindigkeit.ToString("F1")} km/h"
            GeschwAnzeige.Refresh()
            DrehzahlSub()
            System.Threading.Thread.Sleep(25)
        End While

        'Hier wird die Geschwindigkeit runter gezählt 
        While CurrentFahrrad.Geschwindigkeit > (((CurrentFahrrad.FMaxGeschw / (CurrentFahrrad.FKettenblaetter * CurrentFahrrad.FRitzel)) * CurrentFahrrad.CurrentKette * CurrentFahrrad.CurrentRitze) + 1) Or CurrentFahrrad.Geschwindigkeit > AngGeschwindigkeit And AngGeschwindigkeit > 0
            CurrentFahrrad.Geschwindigkeit -= 0.1
            GeschwAnzeige.Text = $"{CurrentFahrrad.Geschwindigkeit.ToString("F1")} km/h"
            GeschwAnzeige.Refresh()
            DrehzahlSub()
            System.Threading.Thread.Sleep(25)
        End While
    End Sub

    Private Sub Hochschalten_Ritze(sender As Object, e As EventArgs) Handles HochRitze.Click            'Hier wird die Ritze hochgeschalten 
        If CurrentFahrrad.CurrentRitze < CurrentFahrrad.FRitzel Then                                    'Die Ritze kann nur hochgeschalten werden solgange sie kleiner ist als das Fahrrad Ritzel hat 
            CurrentFahrrad.CurrentRitze += 1                                                            'Hier wird die Ritze neu berechent 
            RitzelAnzeige.Text = CurrentFahrrad.CurrentRitze                                            'Hier wird der Text für die Ritze neu gesetzt 
            RitzelAnzeige.Refresh()                                                                     'Hier wird die Anzeige der Ritze aktualisiert 
            setGeschw()                                                                                 'Hier wird die Geschwindigkeit neu berechnet 
        End If
    End Sub

    Private Sub Runterschalten_Ritze(sender As Object, e As EventArgs) Handles RunterRitze.Click        'Hier wird die Ritze runter geschaltet 
        If CurrentFahrrad.CurrentRitze > 1 Then                                                         'Die Ritze kann nur runtergeschalten werden solangen sie größer ist als 1 
            CurrentFahrrad.CurrentRitze -= 1                                                            'Hier wird die Ritze neu berechnet 
            RitzelAnzeige.Text = CurrentFahrrad.CurrentRitze                                            'Hier wird der Text für die Ritze neu gesetzt 
            RitzelAnzeige.Refresh()                                                                     'Hier wird die Anzeige für die Ritze aktualisiert 
            setGeschw()                                                                                 'Hier wird die Geschwindigkeit entsprechend der neuen Kette und Ritze berechnet 
        End If
    End Sub

    Private Sub Hochschalten_Kette(sender As Object, e As EventArgs) Handles HochKette.Click        'Hier wird die Kette hochgeschaltet 
        If CurrentFahrrad.CurrentKette < CurrentFahrrad.FKettenblaetter Then                        'Die Kette kann nur hochgeschaltet werdeon solange sie kleiner ist als das Fahrrad Kettenblätter hat 
            CurrentFahrrad.CurrentKette += 1                                                        'Hier wird die Kette hochgezähtl 
            KetteAnzeige.Text = CurrentFahrrad.CurrentKette                                         'Hier wird der Text für die Kette neu gesetzt
            KetteAnzeige.Refresh()                                                                  'Hier wird die Anzeige für die Kette aktualisiert um den richtigen Wert anzuzeigen 
            setGeschw()                                                                             'Hier wird die Geschwindigkeit entsprechend der Kette und Ritze neu berechnet 
        End If
    End Sub

    Private Sub Runterschalten_Kette(sender As Object, e As EventArgs) Handles RunterKette.Click    'Hier wird die Kette runtergeschalten 
        If CurrentFahrrad.CurrentKette > 1 Then                                                     'Die Kette kann nur runtergeschalten werden solange sie größer ist als 1 
            CurrentFahrrad.CurrentKette -= 1                                                        'Hier wird die Kette runter gezählt 
            KetteAnzeige.Text = CurrentFahrrad.CurrentKette                                         'Hier wird der Text für die Kette neu gesetzt
            KetteAnzeige.Refresh()                                                                  'Hier wird die Anzeige für die Kette geändert 
            setGeschw()                                                                             'Die gefahrene Geschwindigkeit wird neu berechnet entsprechend der Kette und der Ritze 
        End If
    End Sub

    Private Sub Blink_Left(ByVal sender As Object, ByVal e As EventArgs) Handles BlinkLinks.Click   'Hier wird der Button Klick erkannt wenn rechts geblinkt werden soll 
        FlagRight = False                                                                           'Die Flag für den Rechts Blinker wird auf False gesetzt, damit dieser nicht mehr blinkt 
        FlagLeft = True                                                                             'Die Flag für den Links Blinker wird auf True gesetzt, damit dieser anfangen kann zu blinken 
        BlinkRightBox.Visible = False                                                               'Der Rechtsblinker wird auf unsichtbar gesetzt, damit man diesen nicht mehr sieht 
        Blink("left")                                                                               'Die Blinkerfunktion wird aufgerufen
    End Sub

    Private Sub Blink_Right(sender As Object, e As EventArgs) Handles BlinkRechts.Click             'Hier wird der Button Klick erkannt wenn rechts geblinkt werden soll 
        FlagLeft = False                                                                            'Die Flag für den Links Blinker wird auf False gesetzt, damit dieser nicht mehr blinkt 
        FlagRight = True                                                                            'Die Flag für den Rechts Blinker wird auf True gesetzt, damit dieser anfangen kann zu blinken 
        BlinkLeftBox.Visible = False                                                                'Der Linksblinker wird auf unsichtbar gesetzt, damit man diesen nicht mehr sieht 
        Blink("right")                                                                              'Die Blinkerfunktion wird aufgerufen
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
        CurrentFahrrad.Geschwindigkeit = 0                                          'Hier wird die Geschwindigkeit auf 0 gesetzt, damit sie wieder von null startet, wenn man das Fahrrad wechselt 
        GeschwAnzeige.Text = $"{CurrentFahrrad.Geschwindigkeit.ToString("F1")}"     'Hier wird der Text für die Geschwindigkeit auf 0 gesetzt
        CurrentFahrrad = Nothing                                                    'Hier wird das Fahrrad wieder auf Null gesetzt, damit keine Fehler entstehen können  
        GroupBox2.Visible = False                                                   'Hier wird die 2. Ansicht auf unsichtbar geschaltet
        GroupBox1.Visible = True                                                    'Hier wird die 1. Ansicht wieder Sichtbar geschaltet 
        Herzfrequenz = 90                                                           'Hier wird die Herzfrequenz zurückgesetzt 
        Herz.Text = $"{Herzfrequenz.ToString("F1")}"                                'Hier wird der Text für die Herzfrequnz neu gesetzt 
        Drehzahl = 0                                                                'Hier wird die Drehzahl zurückgesetzt
        DrZhl.Text = $"{Drehzahl.ToString("F1")}"                                   'Hier wird der Text für die Drehzahl neu gesetzt 
    End Sub

    Private Async Sub HerzfrequenzSub()                                                 'Hier wird die Herzfrequenz ausgerechnet und gesetzt 
        While True                                                                      'Hier wird eine Endlosschleife gestartet, damit die Herzfrequenz dauerhaft hochgezählt wird
            If Herzfrequenz < 135 Then                                                  'Hier wird die Herzfrequenz Immer hochgezählt, sofern sie unter 135 ist
                Dim rndmNrSmall As Integer = CInt(Int((3 * Rnd()) + 1))                 'Hier wird eine Zurällige Zahl ziwschen 1 und 3 erzäugt die, verwendet wird um auf die Herzfrequenz zu addieren 
                Herzfrequenz += rndmNrSmall                                             'Hier wird die Herzfrequenz erhöht 
                Herz.Text = $"{Herzfrequenz.ToString("F1")}"                            'Hier wird die Herzfrequenz neu angezeigt 
            ElseIf Herzfrequenz >= 135 And Herzfrequenz <= 150 Then                     'Hier wird geprüft ob die Herzfrequenz über/gleich 135 und niedriger ist als 150
                Dim rndmNrLarge As Integer = CInt(Int((5 * Rnd()) + 1))                 'Hier wird eine zufällige Zahl zwischen 1 und 5 erzäugt um diese der Herzfrequenz hinzuzufügen oder abzuziehen 
                Dim addSubstract As Integer = CInt(Int((2 * Rnd()) + 1))                'Hier wird eine zufällige Nummer zwischen 1 und 2 erzäugt, welche bestimmt ob die Herzfrequenz hoch oder runter geht
                If addSubstract = 1 Then                                                'Ist die Zufällige Nummer 1 so wird die Herzfrequenz gesängt 
                    Herzfrequenz -= rndmNrLarge                                         'Hier wird die Herzfrequenz runter gezählt mit der zufälligen Nummer 1-5
                    Herz.Text = $"{Herzfrequenz.ToString("F1")}"                        'Hier wird die neue Herzfrequenz angezeigt 
                ElseIf addSubstract = 2 Then                                            'Ist die Zufällige Nummer 2, so wird die Herzfrequenz hoch gezählt 
                    Herzfrequenz += rndmNrLarge                                         'Hier wird die Herzfrequenz hochgezählt 
                    Herz.Text = $"{Herzfrequenz.ToString("F1")}"                        'Hier wird die Herzfrequenz neu angezeigt 
                End If
            End If
            Await Task.Delay(5000)                                                      'Hier wird die Schleife pausiert, damit sich die Herzfrequenz alle 5 Sekunden ändert
        End While
    End Sub

    Private Sub DrehzahlSub()                                                   'Hier wird die Drezhal bestimmt
        Dim meterSek As Double = CurrentFahrrad.Geschwindigkeit / 3.6           'Hier wird die gefahrene Geschwindigkeit in m/s umgerechnet 
        Drehzahl = (meterSek / (2 * 0.3175 * PI)) * 60                          'hier wird die Drezahl des Rades ausgerechnet   
        DrZhl.Text = $"{Drehzahl.ToString("F1")} U/min"                         'Hier wird die Drehzahl neu angezeigt 
        DrZhl.Refresh()                                                         'Hier wird die Anzeige für die Drehzahl neu geladen, damit die Anzeige auch richtig funktioniert 
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 97 Or Asc(e.KeyChar) = 65 Then
            TextBox1.Text = ""
            RadarFunction()
        End If
    End Sub

    Private Async Sub RadarFunction()
        Dim i = 0
        If (GetAsyncKeyState(65)) Then
            While i < 80
                If WarningSignal.Visible = True Then
                    WarningSignal.Visible = False
                Else
                    WarningSignal.Visible = True
                End If
                i += 1
                Await Task.Delay(250)
            End While
        End If
    End Sub

End Class
