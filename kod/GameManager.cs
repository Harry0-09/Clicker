using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float money;
    public float kasaCalkowita;

    public float mnoznik_ceny = 1.2f;
    public float cena = 5f;
    public float mnoznik_klikniec = 1;
    public int klikniecia = 0;
    public float sessionTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
     void Update()
    {
        sessionTime += Time.deltaTime;
    }
}
