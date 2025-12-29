using UnityEngine;
using UnityEngine.UI; 

public class BackgroundManager : MonoBehaviour
{
    public Sprite[] backgroundOptions; 

    private void Start()
    {
        // 1. Gdy scena się ładuje, sprawdź, jakie tło jest zapisane
        // Pobiera zapisaną wartość (domyślnie 0, jeśli brak zapisu)
        int savedIndex = PlayerPrefs.GetInt("CurrentBackgroundID", 0);
        
        // 2. Wymuś natychmiastową aktualizację wszystkich otagowanych obiektów
        UpdateAllTaggedBackgrounds(savedIndex);
    }

    // Ta funkcja wywołuje się automatycznie przy wyjściu z gry
    private void OnApplicationQuit()
    {
        // Resetuje zapisane tło do domyślnego (0) po zamknięciu aplikacji
        PlayerPrefs.SetInt("CurrentBackgroundID", 0);
        PlayerPrefs.Save(); // Zapisuje zmiany na dysku
    }

    // Podłącz tę funkcję do swoich Przycisków (Connect this to your Buttons)
    public void ChangeBackground(int index)
    {
        // Sprawdź, czy gracza stać (zakładając cenę 69). Jeśli nie, przerwij funkcję.
        if (GameManager.Instance.money < 69) return;

        // 1. Zapisz wybór dla przyszłych scen (Save the choice for future scenes)
        PlayerPrefs.SetInt("CurrentBackgroundID", index);
        PlayerPrefs.Save();

        // 2. Znajdź i zaktualizuj wszystko w BIEŻĄCEJ scenie
        UpdateAllTaggedBackgrounds(index);
    }

    private void UpdateAllTaggedBackgrounds(int index)
    {
        // Sprawdzenie bezpieczeństwa (Safety check)
        // Jeśli indeks jest nieprawidłowy (mniejszy od 0 lub większy niż liczba dostępnych grafik), przerwij
        if (index < 0 || index >= backgroundOptions.Length) return;

        Sprite selectedSprite = backgroundOptions[index];

        // A. Znajdź KAŻDY obiekt w scenie z tagiem "Background"
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");

        // B. Pętla przez wszystkie znalezione obiekty i aktualizacja ich Source Image
        foreach (GameObject bgObj in backgrounds)
        {
            Image imgComponent = bgObj.GetComponent<Image>();
            
            // Jeśli obiekt ma komponent Image (jest elementem UI)
            if (imgComponent != null)
            {
                imgComponent.sprite = selectedSprite;
            }
            else
            {
                // Zabezpieczenie (Fallback): Jeśli przypadkowo otagowałeś SpriteRenderer zamiast UI Image
                SpriteRenderer sr = bgObj.GetComponent<SpriteRenderer>();
                if (sr != null) sr.sprite = selectedSprite;
            }
        }
    }
}
