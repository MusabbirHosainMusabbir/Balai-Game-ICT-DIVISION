using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    public Text highscoreText;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        
        highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("highscore");

    }

    // Update is called once per frame
    void Update()
    {

        Score.text = " Your Score: " + Score_Manager.score;

       
        int highscore = PlayerPrefs.GetInt("highscore");
        if (Score_Manager.score > highscore)
        {
            
            PlayerPrefs.SetInt("highscore", Score_Manager.score);
            highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("highscore");
        }
        
    }
}
