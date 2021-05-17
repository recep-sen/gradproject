using System.Collections;
using UnityEngine;
public class NoGravity : MonoBehaviour
{
    Rigidbody rb = new Rigidbody();
    bool grounded;
    public LayerMask lm;
    bool destroyed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!destroyed)
        {
            grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.4f, lm);
            if (grounded)
            {                                                       //basically deleting rigidbody after 10 seconds. Need to do this because the height of the scene is random so i spawn object up in the air
                StartCoroutine(DstryRb());
            }
        }
    }
    IEnumerator DstryRb()
    {
        yield return new WaitForSeconds(5f);
        Destroy(rb);
        destroyed = true;
    }
}