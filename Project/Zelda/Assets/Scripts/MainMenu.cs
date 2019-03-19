using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        Debug.Log("Started Game");
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
