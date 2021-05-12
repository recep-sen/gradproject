using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;                      // getting memory to get rigidbody component
    [Header("Movement and jump variables")]     //headers are here so i wont get lost in editor
    public float speed = 5f;                    // speed variable editable in editor
    public float jump = 5f;
    public float rtspeed = 5f;
    [Header("SELECT GROUND LAYER")]
    public LayerMask lm;                        //getting layer so we can check it in the future
    private bool grounded;                       // a bool so i can check am i in the air or not
    private LayerMask lm2;
    private Transform transformdata;
    private Transform transf;
    private float needforrotation;
    private Animator anim;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                  //adding component to variable
        transformdata = GetComponent<Transform>();
        transf = transformdata.Find("CameraRotation").GetComponentInChildren<Transform>();
        anim = GetComponent<Animator>();
        lm2 = LayerMask.GetMask("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;                 //getting input
        float y = Input.GetAxisRaw("Vertical") * speed;
        grounded = Physics.CheckSphere(new Vector3(transformdata.position.x, transformdata.position.y - 0.4f, transformdata.position.z), 0.4f, lm);     //checking if am i close to floor so i cant jump indefinetly

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            anim.SetBool("isJumping", true);
            StartCoroutine(Jumpanimationfin());
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.y);       //jumping with if statetement to check am i up in the air
            //anim.SetBool("isJumping", false);
        }

        if (x > 0)
        {
            transformdata.Rotate(Vector3.up * Time.deltaTime * rtspeed);
        }
        else if (x < 0)
        {
            transformdata.Rotate(-Vector3.up * Time.deltaTime * rtspeed);
        }


        Vector3 move = transformdata.forward * y;         //calculating movement vector from input
        Vector3 newmove = new Vector3(move.x, rb.velocity.y, move.z);
        //transform.rotation = Quaternion.LookRotation(move);
        //Quaternion newrotate = Quaternion.Euler(0, (x * 18), 0);
        rb.velocity = newmove;
        if (y > 0 || y < 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
            StartCoroutine(Attackanimationfin());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 2f, transform.forward, out hit, 2f, lm2))
            {
                Transform foundintractable = hit.transform;
                GameObject foundone = foundintractable.gameObject;
                foundone.GetComponent<ChestScript>().SetTrue();
            }
        }
    }
    IEnumerator Jumpanimationfin()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isJumping", false);
    }
    IEnumerator Attackanimationfin()
    {
        yield return new WaitForSeconds(2.01f);
        anim.SetBool("isAttacking", false);
    }

}