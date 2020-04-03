using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuseMenu : MonoBehaviour
{

    bool ispaused = false;

    public GameObject menupanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pausedGame()
    {
        if (ispaused)
        {
            Time.timeScale = 1;
            ispaused = false;
            menupanel.SetActive(false);

        }
        else
        {
            Time.timeScale = 0;
            ispaused = true;
            menupanel.SetActive(true);
        }

    }
    public void HandMissionToOpenScene()
    {
        SceneManager.LoadScene("Open_Scene");
    }
    public void Exitthegame()
    {
        Application.Quit();
    }
   
}


