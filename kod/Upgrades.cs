using UnityEngine;
using UnityEngine.UI;
public class Upgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text upgradeText;
    public Text pointsText;
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Mnoznik()
    {
        if (GameManager.Instance.money >= GameManager.Instance.cena)
        {
            Debug.Log("Kupilesz ulepszenie"); 
            GameManager.Instance.money = GameManager.Instance.money - GameManager.Instance.cena;
            GameManager.Instance.cena = GameManager.Instance.cena * GameManager.Instance.mnoznik_ceny;
            GameManager.Instance.mnoznik_klikniec = GameManager.Instance.mnoznik_klikniec * 1.2f;
            pointsText.text = pointsText.text = "money " + Mathf.RoundToInt(GameManager.Instance.money);
            UpdateUI();
        }
        else
            Debug.Log("Nie masz kaski");

    }
    void UpdateUI()
    {
        upgradeText.text = "price " + Mathf.RoundToInt(GameManager.Instance.cena).ToString()
        + "\n" + "multiplier " + (GameManager.Instance.mnoznik_klikniec).ToString("F1");

        pointsText.text = pointsText.text = "money " + MoneyFormatter.Format(Mathf.RoundToInt(GameManager.Instance.money));

    }

}
