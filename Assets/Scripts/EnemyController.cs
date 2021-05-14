using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //necessary variables to store objects
    public GameObject arrowprefab;
    Transform target;
    public float distance;
    GameObject arrow;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()                                                                   //telling the ai to chase player
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(transform.position, target.position);

        if (timer >= 2f && distance <= 20f)
        {
            transform.LookAt(target);
            arrow = shootarrow();
            timer = 0f;
        }
        else if (distance <= 20f)
        {
            transform.LookAt(target);
            timer += Time.deltaTime;
        }
    }
    GameObject shootarrow()
    {
        if (arrow != null)
        {
            arrow.transform.position = transform.position + (Vector3.up * 0.6f);
            arrow.GetComponent<Stick>().Unsticked();
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * 30f; /*shootforce*/
            return arrow;
        }
        else
        {
            arrow = Instantiate(arrowprefab, transform.position + (Vector3.up * 0.6f), Quaternion.identity);
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * 30f; /*shootforce*/
            return arrow;
        }
    }
}