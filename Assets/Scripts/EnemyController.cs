using System.Collections;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public GameObject arrowprefab;
    Transform target;
    public float distance;                  //variables
    GameObject arrow;
    private float timer = 0f;
    Animator anim;
    public GameObject smokeprefab;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()                                                                   //telling the ai to aim to player and attack
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(transform.position, target.position);

        if (timer >= 5f && distance <= 20f)
        {
            transform.LookAt(target);
            arrow = shootarrow();

            timer = 0f;
        }
        else if (distance <= 20f)
        {
            anim.SetBool("isAttacking", true);
            transform.LookAt(target);
            timer += Time.deltaTime;
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
    GameObject shootarrow()
    {
        if (arrow != null)
        {                                                                                      //shooting of arrow
            arrow.transform.position = transform.position + (Vector3.up * 0.6f);
            arrow.GetComponent<Stick>().Unsticked();
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * 20f; /*shootforce*/
            return arrow;
        }
        else
        {
            arrow = Instantiate(arrowprefab, transform.position + (Vector3.up * 0.6f), Quaternion.identity);
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * 20f; /*shootforce*/
            return arrow;
        }
    }
    public void Died()
    {
        anim.SetBool("Dead", true);                 //death animation
        timer = -100000f;
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);                            //death smoke and deleting after death
        Instantiate(smokeprefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}