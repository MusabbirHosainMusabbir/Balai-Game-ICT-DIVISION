using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timing : MonoBehaviour
{
    public float TimeStart=0f;
    public Text texbox;
   
    // Start is called before the first frame update
    void Start()
    {
        texbox.text = TimeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimeStart += Time.deltaTime;
        texbox.text = "time:" + (int)TimeStart;
         
                
    }
}
