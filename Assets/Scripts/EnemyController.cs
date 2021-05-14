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
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()                                                                   //telling the ai to chase player
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 20f)
        {
            transform.LookAt(target);
            arrow = shootarrow();
        }
    }
    GameObject shootarrow()
    {
        if (arrow != null)
        {
            arrow.transform.position = new Vector3(transform.position.x - 0.016f, transform.position.y - 0.004f, transform.position.z + 0.01f);
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * 100f; /*shootforce*/
            return arrow;
        }
        else
        {
            arrow = Instantiate(arrowprefab, new Vector3(transform.position.x - 0.016f, transform.position.y - 0.004f, transform.position.z + 0.01f), Quaternion.identity);
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * 100f; /*shootforce*/
            return arrow;
        }
    }
}//0 0.2 0  0.016 0.024 -0.01