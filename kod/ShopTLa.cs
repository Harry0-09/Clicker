using UnityEngine;
using UnityEngine.UI;

public class ShopTLa : MonoBehaviour
{

    // Cena pierwszego tła (ustawiona domyślnie na 69)
    public double cenaTlo1 = 69f;
    
    // Referencja do tekstu UI wyświetlającego punkty/pieniądze
    public Text pointsText;

    void Start()
    {
        // Sprawdź, czy gracz ma już ustawione inne tło niż domyślne (ID 0).
        // Jeśli tak, to znaczy, że tło jest już kupione/używane, więc usuwamy ten przycisk sklepu.
        if (PlayerPrefs.GetInt("CurrentBackgroundID") != 0)
        {
            Destroy(gameObject); // Usuwa ten obiekt (przycisk sklepu) ze sceny
        }
    }

    // UpdateUI służy do odświeżania tekstu z ilością pieniędzy
    void UpdateUI()
    {
        // Aktualizuje tekst punktów, formatując liczbę pieniędzy za pomocą MoneyFormattera.
        // Konwertuje double na int i zaokrągla wartość.
        pointsText.text = "money " + MoneyFormatter.Format((int)System.Math.Round(GameManager.Instance.money));
    }

    // Funkcja kupowania tła - podłącz ją do przycisku w inspektorze Unity
    public void BuyTlo1()
    {
        // Sprawdź, czy gracza stać na tło (czy ma więcej lub tyle samo pieniędzy co cena)
        if (GameManager.Instance.money >= cenaTlo1)
        {
            // Odejmij cenę tła od pieniędzy gracza (GameManager to Singleton zarządzający stanem gry)
            GameManager.Instance.money -= cenaTlo1;
            
            // Po zakupie usuń przycisk sklepu, żeby nie można było kupić go ponownie
            Destroy(gameObject);

            Debug.Log("Kupiono tlo1");
            
            // Odśwież widok pieniędzy po zakupie (choć obiekt zaraz zniknie, warto to wywołać dla pewności)
            UpdateUI();
        }
        else
        {
            
            Debug.Log("Nie masz kasy sadeg");
        }
    }
}
