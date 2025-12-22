using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void go_to_settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void go_to_upgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }
    public void go_to_stats()
    {
        SceneManager.LoadScene("Stats");
    }
}

