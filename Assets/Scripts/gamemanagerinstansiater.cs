using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanagerinstansiater : MonoBehaviour
{
    public static bool GMACTIVE = false;
    public GameObject gm;
    void Awake()
    {
        if (!GMACTIVE)
        {
            Instantiate(gm, new Vector3(0, 0, 0), Quaternion.identity);
            GMACTIVE = true;
        }
    }
}