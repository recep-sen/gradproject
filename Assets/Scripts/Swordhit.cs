using UnityEngine;
public class Swordhit : MonoBehaviour
{
    Animator anim;
    private bool getready = false;
    GameObject enemystore;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    void FixedUpdate()
    {                                                                   //checking hit
        if (getready && anim.GetBool("isAttacking"))
        {
            enemystore.GetComponent<EnemyController>().Died();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().money += 30;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().thismoney += 30;
            getready = false;
        }
    }
    private void OnTriggerEnter(Collider other)                                 //checking if it is a hit with right thing
    {
        if (other.gameObject.tag == "enemy" && anim.GetBool("isAttacking"))
        {
            other.gameObject.GetComponent<EnemyController>().Died();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().money += 30 * GameManager.instance.scoremltp;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().thismoney += 30 * GameManager.instance.scoremltp;
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
