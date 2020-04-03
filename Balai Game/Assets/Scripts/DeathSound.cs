using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 5f;


 void Start()
    {
        Destroy(gameObject, time);
    }

}
