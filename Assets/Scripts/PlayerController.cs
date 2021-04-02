using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb = new Rigidbody();            //getting memory for component
    public float maxSpeed; //max speed value changable in editor
    float x, z;          //movement coordinate values

    public float deceleration;
    public float currentSpeed;
    private bool isMoving;
    private Vector3 moveDirection;
    private float epsilon = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                        //referencing component
    }
    private void moving()
    {
        isMoving = true;
        moveDirection = new Vector3(x, 0f, z);
    }
    private void notmoving()
    {
        isMoving = false;
        moveDirection = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb.velocity.sqrMagnitude;
        x = Input.GetAxis("Horizontal") * Time.deltaTime;           //getting keys to variables
        z = Input.GetAxis("Vertical") * Time.deltaTime;
        if (x + z > 0)
        {
            moving();
        }

        if (isMoving)
        {
            if (currentSpeed < maxSpeed)
            {
                rb.velocity += moveDirection;
            }
            else
            {
                rb.velocity += moveDirection;
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
        else
        {
            if (rb.velocity.sqrMagnitude < epsilon) rb.velocity = Vector3.zero;
            else rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, deceleration);
        }
    }
    public void SetMaxSpeed(float newSpeed)
    {
        float sc = currentSpeed / maxSpeed;
        currentSpeed = sc * newSpeed;
        maxSpeed = newSpeed;
    }
}