using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data.SqlTypes;

public class AutoSkarpeta : MonoBehaviour
{
    public Text KliknieciaText;
    public Text Punkty;

    public Text messageText;
    private readonly WaitForSeconds interval = new WaitForSeconds(1f);

    void Start()
    {
        StartCoroutine(AutoMoneyLoop());
        Update_UI();
    }

    public void ShowMessage(string msg, float time = 2f)
    {
        StartCoroutine(Show(msg, time));
    }

    IEnumerator Show(string msg, float time)
    {
        messageText.text = msg;
        yield return new WaitForSeconds(time);
        messageText.text = "";
    }


    public void OnClick()
    {
        if (GameManager.Instance.money >= GameManager.Instance.cena_auto)
        {
            GameManager.Instance.money -= GameManager.Instance.cena_auto;
            GameManager.Instance.cena_auto = (int)Math.Round(GameManager.Instance.cena_auto * GameManager.Instance.mnoznik_ceny_auto);
            GameManager.Instance.ilosc_auto += 0.25;
            Update_UI();
        }
        else
        {
            ShowMessage($"Cena ulepszenia: {MoneyFormatter.Format(GameManager.Instance.cena_auto)}$, brakuje ci {MoneyFormatter.Format(GameManager.Instance.cena_auto-GameManager.Instance.money)}$");
        }
    }

    void Update_UI()
    {
        KliknieciaText.text = "Clicks /s: " + (GameManager.Instance.ilosc_auto * GameManager.Instance.sock).ToString();
        Punkty.text = "money " + MoneyFormatter.Format((int)Math.Round(GameManager.Instance.money));
    }

    private IEnumerator AutoMoneyLoop()
    {
        while (true)
        {
            double add = GameManager.Instance.ilosc_auto * GameManager.Instance.mnoznik_klikniec * GameManager.Instance.sock;

            GameManager.Instance.money += Math.Round(add, 2);
            GameManager.Instance.kasaCalkowita += Math.Round(add, 2);

            Punkty.text = "money " + MoneyFormatter.Format(GameManager.Instance.money);

            yield return interval;
        }
    }
}
