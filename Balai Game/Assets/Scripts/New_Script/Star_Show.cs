using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Show : MonoBehaviour
{
    public GameObject OneStar;
    public GameObject twoStar;
    public GameObject ThreeStar;
    public GameObject LosePanel;
    public GameObject WinPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     /*   if (Time.time <=90f)
        {
            OneStar.SetActive(true);
            twoStar.SetActive(false);
            ThreeStar.SetActive(false);


            LosePanel.SetActive(false);
            WinPanel.SetActive(true);


        }
        else if (Time.time >=91f)
        {
            OneStar.SetActive(false);
        }
        if (Time.time <= 80f)
        {
            twoStar.SetActive(true);
            OneStar.SetActive(false);
            ThreeStar.SetActive(false);


            LosePanel.SetActive(false);
            WinPanel.SetActive(true);


        }
        else if (Time.time > 81f)
        {
            twoStar.SetActive(false);
        }
        if (Time.time <= 70f)
        {
            ThreeStar.SetActive(true);
            OneStar.SetActive(false);
            twoStar.SetActive(false);


            LosePanel.SetActive(false);
            WinPanel.SetActive(true);


        }
        else if (Time.time > 71f)
        {
            ThreeStar.SetActive(false);
        }*/
        if (Time.time >= 101f)
        {
            LosePanel.SetActive(true);
            WinPanel.SetActive(false);
        }
        else if (Time.time <= 100f)
        {
            LosePanel.SetActive(false);
            WinPanel.SetActive(true);
        }
        
        
          
    }
}
