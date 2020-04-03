using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletposs;

    public string LevelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootgun()
    {       
            shoot();
            Debug.Log("button shoot");            
    }

    void shoot()
    {
        Instantiate(bullet, bulletposs.position, transform.rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Application.LoadLevel(LevelToLoad);
            Destroy(collision.gameObject);
        }
    }
}
