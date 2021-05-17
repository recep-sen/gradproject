using UnityEngine;
public class Explosiondeleter : MonoBehaviour
{
    ParticleSystem particlesystem;                             //variables
    void Start()
    {
        particlesystem = GetComponent<ParticleSystem>();           //reference
    }
    void FixedUpdate()
    {
        if (!particlesystem.IsAlive())                              //deleting after effect is over
        {
            Destroy(gameObject);
        }
    }
}