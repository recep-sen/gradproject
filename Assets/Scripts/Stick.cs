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
        if (!hitsomething)                                                      //setting the point of arrow to flight location
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {                                                                   //if arrow collides it will stick and damage the player
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
        rb.constraints = RigidbodyConstraints.None;                     //making it unstick if it is called back
        hitsomething = false;
    }
}
