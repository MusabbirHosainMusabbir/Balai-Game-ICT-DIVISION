using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;
	public Transform muzzle;
	
	public float roundsPerMinute;
	float fireTimer;

	public AudioSource ShootAudio;
	public float range;
	public LayerMask hitDetection;
	RaycastHit rh;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
		
		if (Physics.Raycast(transform.position, transform.forward, out rh, range, hitDetection)) // Shoots raycast forward to check for objects the player is looking at
		{
			if (rh.collider.gameObject.CompareTag("Shootable") && fireTimer >= 60 / roundsPerMinute) // If object player is looking at is something that can be shot at, and previous shot has finished firing
			{
                // Shoot bullet and reset fire timer
                fireTimer = 0;
				GameObject bullet = Instantiate(bulletPrefab.gameObject, muzzle.position, Quaternion.identity);
				bullet.transform.LookAt(rh.point);
				ShootAudio.Play();
				
			}
		}
    }
}
