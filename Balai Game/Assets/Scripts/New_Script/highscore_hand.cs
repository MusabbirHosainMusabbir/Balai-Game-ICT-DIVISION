using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore_hand : MonoBehaviour
{
    public Text highscoreText;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {

        highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("highscore_hand");

    }

    // Update is called once per frame
    void Update()
    {

        Score.text = " Your Score: " + H_Score_Manager.score;


        int highscore = PlayerPrefs.GetInt("highscore_hand");
        if (H_Score_Manager.score > highscore)
        {

            PlayerPrefs.SetInt("highscore_hand", H_Score_Manager.score);
            highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("highscore_hand");
        }

    }
}
