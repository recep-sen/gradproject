using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordhit : MonoBehaviour
{
    Animator anim;
    private bool getready = false;
    GameObject enemystore;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (getready && anim.GetBool("isAttacking"))
        {
            enemystore.GetComponent<EnemyController>().Died();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().money += 30;
            getready = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy" && anim.GetBool("isAttacking"))
        {
            other.gameObject.GetComponent<EnemyController>().Died();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().money += 30;
        }
        else if (other.gameObject.tag == "enemy")
        {
            enemystore = other.gameObject;
            getready = true;
        }
        else
        {
            getready = false;
        }
    }
}
