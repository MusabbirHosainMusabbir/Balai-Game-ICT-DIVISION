using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{

    public static int score;
    public Text ScoreText;
    
    public Text highscoreText;
    public GameObject HiddenEnemy;

    public Image fillbar;
    public int MaxScore = 100;

    public string LevelToLoad;
          
    // Start is called before the first frame update

    private void Awake()
    {
        ScoreText = GetComponent<Text>();
        score = 0;
        
    }
    void Start()
    {
        highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("highscore");
        
    }

    // Update is called once per frame
    void Update()
    {
        //score(Code)
        ScoreText.text = "Score " + score;

        //ScoreBar(Code)
        fillbar.fillAmount = (float)score / (float)MaxScore;

        //HighScore(Code)
        int highscore = PlayerPrefs.GetInt("highscore");
        if(score > highscore)
        {
            
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "HighScore : " + PlayerPrefs.GetInt("highscore");
        }


        //HideEnemyActive(Code)
        if (score >= 300f)
        {
            HiddenEnemy.SetActive(true);
        }

        //NewScenes(Code)
        if(score >= 310f)
        {
            Application.LoadLevel(LevelToLoad);
        }


    }
   
}
