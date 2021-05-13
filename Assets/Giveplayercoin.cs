using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveplayercoin : MonoBehaviour
{
    public ChestScript chestScript;
    void Start()
    {
        chestScript = GetComponentInParent<ChestScript>();
        chestScript.a = 1;
    }
}
