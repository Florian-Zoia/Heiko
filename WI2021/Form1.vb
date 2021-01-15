Public Class Form1
    'Objekte (Fahrräder)
    Dim Rennrad As Fahrrad = New Fahrrad("Rennrad", 2, 10, 65, 0, 1, 1)
    Dim Crosser As Fahrrad = New Fahrrad("Crosser", 2, 11, 55, 0, 1, 1)
    Dim Triathlon As Fahrrad = New Fahrrad("Triathlon Rad", 2, 11, 65, 0, 1, 1)
    Dim Mountainbike As Fahrrad = New Fahrrad("Mountainbike", 1, 11, 55, 0, 1, 1)

    'Lokale Variablen für die Verarbeitung
    Dim CurrentFahrrad As Fahrrad


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

End Class
