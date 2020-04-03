using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreValue : MonoBehaviour
{

    public int scorevalue;
       
    // Start is called before the first frame update
    void Start()
    {
        
        scorevalue = 5;
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Score_Manager.score += scorevalue;
           
        }

        

    }
}
