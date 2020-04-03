using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H_Score_Manager : MonoBehaviour
{
    public static int score;
    public Text ScoreText;

    public Image fillbar;
    public int maxScore = 310;

    public string LevelToLoad;

    // Start is called before the first frame update

    private void Awake()
    {
        ScoreText = GetComponent<Text>();
        score = 0;
    }
   

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + score;
        fillbar.fillAmount = (float)score / (float)maxScore;

        if (score >= 300f)
        {
            Application.LoadLevel(LevelToLoad);
        
        }

    }
}
