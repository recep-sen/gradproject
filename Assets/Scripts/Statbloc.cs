using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statbloc : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float armor;
    public float respawn;
    public float damage;
    public float money;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
    }


}