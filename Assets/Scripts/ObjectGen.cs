using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGen : MonoBehaviour
{
    [Header("Generated Objects")]                           //getting necessary components and variables
    public GameObject object1;
    [Header("Coordinates")]
    public int x;
    public int z;
    private int randomobject;
    [Header("Object Quantity")]
    public int quantity;
    [Header("Objects In Scene")]
    public int objectcount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateObjects());                  //starting multi-thread task
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GenerateObjects()                               //if you need to create object it creates in a random given position
    {
        while (objectcount < quantity)
        {
            randomobject = Random.Range(1, 2);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);
            if (randomobject == 1)
            {
                Instantiate(object1, new Vector3(x, 10, z), Quaternion.identity);
            }
            yield return null;
            objectcount++;
        }
    }
}
