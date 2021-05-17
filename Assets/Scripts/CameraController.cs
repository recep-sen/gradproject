using UnityEngine;
public class CameraController : MonoBehaviour
{
    Transform ts;
    public float x = 0f;
    public float y = 0f;                                 //variables
    public float cmspeed = 50f;
    void Start()
    {
        ts = GetComponent<Transform>();                   //getting reference
    }
    void Update()
    {
        x = Input.GetAxisRaw("Mouse X");
        y = Input.GetAxisRaw("Mouse Y");                      //rotate with mouse movements
        if (x > 0f)
        {
            ts.Rotate(Vector3.up * Time.deltaTime * cmspeed * x);
        }
        else if (x < 0f)
        {
            ts.Rotate(Vector3.up * Time.deltaTime * cmspeed * x);
        }
    }
}