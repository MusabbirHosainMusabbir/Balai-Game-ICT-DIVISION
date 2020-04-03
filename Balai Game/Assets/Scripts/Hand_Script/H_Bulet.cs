using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Bulet : MonoBehaviour
{

    public GameObject DeathAudio;
    private float time = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-5f,0 ,0);
        Destroy(gameObject, time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            Instantiate(DeathAudio, transform.position, Quaternion.identity);
        }
        

    }
}
