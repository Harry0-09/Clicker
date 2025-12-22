using UnityEngine;
using UnityEngine.UI;

public class Clicks : MonoBehaviour
{
    public Text pointsText;

    void Start()
    {
        pointsText.text = "Money " + Mathf.RoundToInt(GameManager.Instance.money);
    }

    public void AddPoint()
    {
        GameManager.Instance.money = GameManager.Instance.money + 1 * GameManager.Instance.mnoznik_klikniec;
        GameManager.Instance.kasaCalkowita = Mathf.RoundToInt(GameManager.Instance.kasaCalkowita + 1 * GameManager.Instance.mnoznik_klikniec);
        pointsText.text = "Money " + Mathf.RoundToInt(GameManager.Instance.money);
        GameManager.Instance.klikniecia++;
    }
}
