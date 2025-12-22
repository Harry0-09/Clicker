using UnityEngine;
using UnityEngine.SceneManagement;

public class Powrot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void go_to_main()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
