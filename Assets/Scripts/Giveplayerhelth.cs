using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giveplayerhelth : MonoBehaviour
{
    public ChestScript chestScript;
    // Start is called before the first frame update
    void Start()
    {
        chestScript = GetComponentInParent<ChestScript>();
        chestScript.a = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
