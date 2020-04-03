using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Enemy_Ganaret : MonoBehaviour
{

    public GameObject[] Enemy;
    int RandomNumber;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ganaret", speed, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ganaret()
    {
        RandomNumber = Random.Range(0,Enemy.Length);
        Instantiate(Enemy[RandomNumber], transform.position, Quaternion.identity);
    }
}
