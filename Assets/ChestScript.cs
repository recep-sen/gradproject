using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    Animator anim;
    private bool alreadyplayed = false;
    public int a = 10;
    Statbloc statbloc;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        statbloc = GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>();
    }
    public void SetTrue()
    {
        if (!alreadyplayed)
        {
            anim.SetBool("transition", true);

            if (a == 0)
            {
                statbloc.health += 50;
                a = 10;
            }
            else if (a == 1)
            {
                statbloc.money += 50;
                a = 10;
            }
            else if (a == 2)
            {
                statbloc.health -= 50;
                Explodedchest explodedChest = GetComponentInChildren<Explodedchest>();
                explodedChest.Explode();
                a = 10;
            }
            alreadyplayed = true;
        }
    }
}