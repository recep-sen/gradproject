using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosiondeleter : MonoBehaviour
{
    ParticleSystem particlesystem;
    void Start()
    {
        particlesystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!particlesystem.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}