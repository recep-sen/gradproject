using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform ts;
    public float x = 0f;
    public float y = 0f;
    public float cmspeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Mouse X");
        y = Input.GetAxisRaw("Mouse Y");

        if (x > 0f)
        {
            ts.Rotate(Vector3.up * Time.deltaTime * cmspeed * x);
        }
        else if (x < 0f)
        {
            ts.Rotate(Vector3.up * Time.deltaTime * cmspeed * x);
        }
        /*if (y > 0f)
        {
            ts.Rotate(-Vector3.forward * Time.deltaTime * cmspeed * y, Space.Self);
        }
        else if (y < 0f)
        {
            ts.Rotate(-Vector3.forward * Time.deltaTime * cmspeed * y, Space.Self);
        }*/

    }
}