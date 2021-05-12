using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public static bool gotinteracted = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (gotinteracted)
        {
            // play animation
            Debug.Log("AYOL BÝÞEY DEÐDÝ BANA");
            gotinteracted = false;
        }
    }
    public void SetTrue()
    {

        gotinteracted = true;
    }
}
