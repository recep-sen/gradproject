using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    Animator anim;
    private bool alreadyplayed = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {


    }
    public void SetTrue()
    {
        if (!alreadyplayed)
        {
            //chest animation
        }
    }
}
