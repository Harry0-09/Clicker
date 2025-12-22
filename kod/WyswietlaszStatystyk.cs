using UnityEngine;
using TMPro;
using System.Net.WebSockets;

public class WyswietlaszStatystyk : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    void Update()
    {
        float czasSesji = GameManager.Instance.sessionTime;
        float clicks = GameManager.Instance.klikniecia;
        float kasa = GameManager.Instance.kasaCalkowita;

        int hours2 = Mathf.FloorToInt(czasSesji/ 3600);
        int minutes2 = Mathf.FloorToInt((czasSesji % 3600) / 60);
        int seconds2 = Mathf.FloorToInt(czasSesji % 60);

        statsText.text =
            $"Czas sesji: {hours2:00}:{minutes2:00}:{seconds2:00}\n" +
            $"Całkowite zebrane pieniądze: {MoneyFormatter.Format(kasa)} \n" +
            $"Kliknięcia: {clicks}";
    }
}
