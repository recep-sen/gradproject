using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    public NavMeshSurface[] surfaces;                               //getting variables
    public Transform[] objectsToRotate;

    void Start()
    {
        for (int j = 0; j < objectsToRotate.Length; j++)                        //loop for rotation
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        }
        for (int i = 0; i < surfaces.Length; i++)                               //building navigation
        {
            surfaces[i].BuildNavMesh();
        }
    }
}