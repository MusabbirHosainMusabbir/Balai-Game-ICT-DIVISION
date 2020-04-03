using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (ParticleSystem))]
public class TemporaryParticleSystem : MonoBehaviour
{
    ParticleSystem p;

    private void Awake()
    {
        p = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!p.IsAlive()) // Checks if particle system has finished, destroy gameObject
        {
            Destroy(gameObject);
        }
    }
}
