using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Target;
    float speed;
    public int scorevalue;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        Target = GameObject.Find("Past_Model");
        scorevalue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Score_Manager.score += scorevalue;
        }
       
    }
}
