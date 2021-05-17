using System.Collections;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public GameObject pausemenu;
    private bool paused = false;
    private Rigidbody rb;
    [Header("Movement and jump variables")]
    public float speed = 5f;
    public float jump = 5f;
    public float rtspeed = 5f;
    [Header("SELECT GROUND LAYER")]
    public LayerMask lm;
    private bool grounded;
    private LayerMask lm2;
    private Transform transformdata;
    private Transform transf;
    private float needforrotation;
    private Animator anim;
    private bool isMoving;
    Statbloc statbloc;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transformdata = GetComponent<Transform>();
        transf = transformdata.Find("CameraRotation").GetComponentInChildren<Transform>();
        anim = GetComponent<Animator>();
        lm2 = LayerMask.GetMask("Interactable");
        statbloc = GetComponent<Statbloc>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;                 //getting input
        float y = Input.GetAxisRaw("Vertical") * speed;
        grounded = Physics.CheckSphere(new Vector3(transformdata.position.x, transformdata.position.y - 0.4f, transformdata.position.z), 0.4f, lm);     //checking if am i close to floor so i cant jump indefinetly
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (statbloc.thismoney > 999)                       //next map code
            {
                GameManager.instance.score = statbloc.money;
                GameManager.instance.gameState = GameManager.GameState.Loading;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {                                               //pause menu
                paused = false;
                Time.timeScale = 1f;
                pausemenu.SetActive(false);
            }
            else
            {
                paused = true;
                Time.timeScale = 0f;
                pausemenu.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            anim.SetBool("isJumping", true);
            StartCoroutine(Jumpanimationfin());
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.y);       //jumping with if statetement to check am i up in the air
        }
        if (x > 0)
        {
            transformdata.Rotate(Vector3.up * Time.deltaTime * rtspeed);        //rotation of player
        }
        else if (x < 0)
        {
            transformdata.Rotate(-Vector3.up * Time.deltaTime * rtspeed);        //rotation of player
        }
        Vector3 move = transformdata.forward * y;         //calculating movement vector from input
        Vector3 newmove = new Vector3(move.x, rb.velocity.y, move.z);
        if ((y > 0 || y < 0) && !anim.GetBool("isAttacking"))
        {
            anim.SetBool("isMoving", true);                                //animation and movement
            rb.velocity = newmove;
        }
        else if (!anim.GetBool("isAttacking"))
        {
            anim.SetBool("isMoving", false);
            rb.velocity = newmove;
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
            rb.velocity = Vector3.zero;
            StartCoroutine(Attackanimationfin());
        }
        if (Input.GetKeyDown(KeyCode.E))                                            //opening chest
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (var hitCollider in hitColliders)
            {
                GameObject foundone = hitCollider.gameObject;

                if (foundone.TryGetComponent(out ChestScript chestScript))
                {
                    chestScript.SetTrue();
                }
            }
        }
    }
    IEnumerator Jumpanimationfin()
    {
        yield return new WaitForSeconds(0.5f);                          //animation couroutines
        anim.SetBool("isJumping", false);
    }
    IEnumerator Attackanimationfin()
    {
        yield return new WaitForSeconds(2.01f);
        anim.SetBool("isAttacking", false);
    }
}