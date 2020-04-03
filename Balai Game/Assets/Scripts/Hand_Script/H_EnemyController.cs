using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_EnemyController : MonoBehaviour
{
    GameObject Target;
    float speed;
    public int scorevalue;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        Target = GameObject.Find("handwash");
        scorevalue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "boll")
        {
            H_Score_Manager.score += scorevalue;
        }

    }
}
