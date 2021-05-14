using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Rigidbody rb;
    public bool hitsomething = false;
    public LayerMask lm;
    void Start()
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == lm)
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
        else if (collision.gameObject.tag != "enemy")           //add player to if and make if, else if
        {
            hitsomething = true;
            Sticked();
        }

    }
    void Sticked()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void Unsticked()
    {
        rb.constraints = RigidbodyConstraints.None;
        hitsomething = false;
    }
}
