using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Shootable")
        {
                 SceneManager.LoadScene("Lose_Scenes");

        }
   
    }

}
