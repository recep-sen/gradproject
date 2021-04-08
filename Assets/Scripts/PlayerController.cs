using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;                      // getting memory to get rigidbody component
    [Header("Movement and jump variables")]     //headers are here so i wont get lost in editor
    public float speed = 5f;                    // speed variable editable in editor
    public float jump = 5f;
    [Header("SELECT GROUND LAYER")]
    public LayerMask lm;                        //getting layer so we can check it in the future
    private bool grounded;                       // a bool so i can check am i in the air or not
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                  //adding component to variable
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;                 //getting input
        float y = Input.GetAxisRaw("Vertical") * speed;

        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.4f, lm);     //checking if am i close to floor so i cant jump indefinetly

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.y);       //jumping with if statetement to check am i up in the air
        }

        Vector3 move = transform.right * x + transform.forward * y;         //calculating movement vector from input
        Vector3 newmove = new Vector3(move.x, rb.velocity.y, move.z);
        rb.velocity = newmove;                                              //giving vector to component so movement can be done
    }
}