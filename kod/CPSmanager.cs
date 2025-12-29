using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CPSmanager : MonoBehaviour
{
    [Header("UI Reference")]
    // Referencja do komponentu UI Text, który wyświetla wynik na ekranie
    public Text cpsText; 

    // Lista przechowująca dokładny czas każdego kliknięcia
    private List<float> clickTimestamps = new List<float>();

    void Update()
    {
        // 1. Czyszczenie starych kliknięć (Clean up old clicks)
        // Sprawdź, czy najstarsze kliknięcie (indeks 0) miało miejsce dawniej niż 1 sekundę temu
        // Time.time to aktualny czas gry
        while (clickTimestamps.Count > 0 && Time.time - clickTimestamps[0] > 1.0f)
        {
            // Usuń kliknięcie z listy, ponieważ jest starsze niż sekunda i nie liczy się do CPS
            clickTimestamps.RemoveAt(0);
        }

        // 2. Aktualizacja wyświetlania (Update the Display)
        // Liczba elementów w liście odpowiada aktualnemu CPS (kliknięciom na sekundę)
        if (cpsText != null)
        {
            cpsText.text = "CPS: " + clickTimestamps.Count.ToString();
        }
    }

    // Podłącz tę funkcję do głównego przycisku w inspektorze Unity (On Click)
    public void RegisterClick()
    {
        // Dodaj aktualny czas do listy kliknięć
        clickTimestamps.Add(Time.time);
        
        // Tutaj dodaj inną logikę kliknięcia (np. dodawanie pieniędzy/punktów)
        // ScoreManager.instance.AddScore(1); 
    }
}
