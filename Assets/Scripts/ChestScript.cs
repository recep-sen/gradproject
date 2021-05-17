using UnityEngine;
public class ChestScript : MonoBehaviour
{
    Animator anim;
    private bool alreadyplayed = false;
    public int a = 10;                               //variables
    Statbloc statbloc;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        statbloc = GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>();     //reference
    }
    public void SetTrue()
    {
        if (!alreadyplayed)                                                     //if it is first time does which chest does
        {
            anim.SetBool("transition", true);
            if (a == 0)
            {
                statbloc.health += 50;
                a = 10;
            }
            else if (a == 1)
            {
                statbloc.money += 50 * statbloc.scoremltp;
                statbloc.thismoney += 50 * statbloc.scoremltp;
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