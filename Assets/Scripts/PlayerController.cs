using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;  // speed value changable in editor
    float x, z;          //movement coordinate values


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;           //getting keys to variables
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);                                       //translating variables to game object
    }
}
