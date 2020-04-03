using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Openscene_To_SelectScene : MonoBehaviour
{
    
    public void OpenToSelect()
    {
        SceneManager.LoadScene("Select_mission");
    }
    public void selectMouthToMouthmission()
    {
        SceneManager.LoadScene("Mouth_Level");
    }
    public void StarMenuToOpenScene()
    {
        SceneManager.LoadScene("Open_Scene");
    }

    public void selectHandToHandmission()
    {
        SceneManager.LoadScene("Hand_Level");
    }

    public void StarSceneToSelectScene()
    {
        SceneManager.LoadScene("Select_mission");
    }

    public void ExittheGame()
    {
        Application.Quit();
    }
    public void OpenSceneToInformation()
    {
        SceneManager.LoadScene("Information_Scenes");
    }
}
