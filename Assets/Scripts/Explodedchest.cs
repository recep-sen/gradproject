using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodedchest : MonoBehaviour
{
    public ChestScript chestScript;
    public Transform trans;
    public GameObject gameobject;
    void Start()
    {
        chestScript = GetComponentInParent<ChestScript>();
        trans = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.rotation.x >= -85)
        {
            chestScript.a = 2;
        }
    }
    public void Explode()
    {
        gameobject.SetActive(true);
    }
}
