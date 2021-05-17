using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravity : MonoBehaviour
{
    Rigidbody rb = new Rigidbody();           //to delete rb i need to get it first
    bool grounded;                            //variable to check if object is grounded
    public LayerMask lm;                      //to check floor
    bool destroyed = false;                   //to check if rigidbody destroyed
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        //getting the rigidbody

    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyed)                        //condition to check if rigidbody is still here
        {
            grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.4f, lm); //if object is close to ground
            if (grounded)                                   //if it is then start the process of destroying
            {
                StartCoroutine(DstryRb());
            }
        }
    }
    IEnumerator DstryRb()                  //process of destroying the rb
    {                                      //waiting for 5 seconds to adjust all objects to their pozisitons
                                           //after that destroy the object
        yield return new WaitForSeconds(5f);

        Destroy(rb);
        destroyed = true;
    }
}