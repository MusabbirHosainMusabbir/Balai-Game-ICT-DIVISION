using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;
    public float lifetime;
	float destroyTimer;

	private float time =10f;

	public GameObject DeatthSound;
	
	public LayerMask hitDetection;

    public GameObject impactPrefab;

    RaycastHit rh;



	// Update is called once per frame
	void Update()
    {
        float raycastLength = velocity * Time.deltaTime; // Determines distance to scan forward. This is used for both hit detection and movement, to ensure that the bullet never misses a spot in its flight path and that it moves at a consistent speed.
		if (Physics.Raycast(transform.position, transform.forward, out rh, raycastLength, hitDetection)) // Shoots out a raycast to detect for enemies
		{
            Instantiate(impactPrefab, rh.point, Quaternion.identity); // Instantiate impact prefab for cosmetic effect
            print("Bullet hit " + rh.collider.name + "."); // If true, print message confirming hit, and destroy bullet
            Destroy(gameObject);
		}
		else
		{
			//transform.Translate(transform.forward * raycastLength);
			transform.position += transform.forward * raycastLength; // If nothing is detected, move bullet forward a distance equal to raycastLength
		}

		// Counts up a timer and destroys gameobject when timer is reached, to prevent too many bullets from slowing down the game.
		/*destroyTimer += Time.deltaTime;
		if (destroyTimer >= lifetime)
		{
			Destroy(gameObject);
		}*/

		Destroy(gameObject, time);

    }
	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Shootable")
		{
			Destroy(collision.gameObject);
			Destroy(this.gameObject);

			Instantiate(DeatthSound, transform.position, Quaternion.identity);
			
		}
	}
}
