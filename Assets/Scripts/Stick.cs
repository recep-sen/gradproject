using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Rigidbody rb;
    public bool hitsomething = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
    void FixedUpdate()
    {
        if (!hitsomething)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag != "enemy")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            hitsomething = true;
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Statbloc>().health -= 30;
            }
        }
    }
    public void Unsticked()
    {
        rb.constraints = RigidbodyConstraints.None;
        hitsomething = false;
    }
}
