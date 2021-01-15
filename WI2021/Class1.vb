Imports Microsoft.VisualBasic

Public Class Fahrrad
    Public Property FName As String                 'Der Name des Fahrrads 
    Public Property FKettenblaetter As Integer      'Die Gesamtzahl der Kettenblätter eines Fahrrads
    Public Property FRitzel As Integer              'Die Gesamtzahl der ´Ritzel eines Fahrrads 
    Public Property FMaxGeschw As Double            'Die Maximalgeschwindigkeit eines Fahrrads 
    Public Property Geschwindigkeit As Double       'Die Momentane Geschwindigkeit des Fahrrads
    Public Property CurrentRitze As Integer         'Die Momentane Ritze in der sich die FahrradKette befindet 
    Public Property CurrentKette As Integer         'Die Momentane Kette in der sich die Fahrradkette befindet



    Public Sub New(ByVal name As String, ByVal kettenblaetter As Integer, ByVal ritzel As Integer, ByVal maxGeschw As Double, geschw As Double, crtRitzel As Integer, crtKette As Integer)
        'Zuweisung der Variablen zu der Klasse und somit den einzelnen Objekten der Klasse
        FName = name
        FKettenblaetter = kettenblaetter
        FRitzel = ritzel
        FMaxGeschw = maxGeschw
        Geschwindigkeit = geschw
        CurrentRitze = crtRitzel
        CurrentKette = crtKette
    End Sub
End Class
