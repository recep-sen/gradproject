using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Rigidbody rb;
    public bool hitsomething = false;
    public LayerMask lm;
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
    void Sticked()
    {

    }
    public void Unsticked()
    {
        rb.constraints = RigidbodyConstraints.None;
        hitsomething = false;
    }
}
