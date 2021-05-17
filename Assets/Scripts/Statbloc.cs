using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statbloc : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float respawn;
    public float money;
    public float thismoney;
    // Start is called before the first frame update
    void Start()
    {
        money = GameManager.instance.score;
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