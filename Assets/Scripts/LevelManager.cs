using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour

{
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;
    // Start is called before the first frame update
    [Header("Generated Texture")]
    public GameObject[] Terrain1;
    [Header("Generated Objects")]                           //getting necessary components and variables
    public GameObject[] object1;
    [Header("Coordinates of Objects")]
    public int x;
    public int z;
    private int randomobject;
    private int randomterrain;
    [Header("Object Quantity")]
    public int quantity;
    [Header("Objects In Scene")]
    public int objectcount;
    void Awake()
    {

        GameManager.instance.gameState = GameManager.GameState.Gameplay;
        LevelLoading();




    }

    void LevelLoading()
    {
        randomterrain = Random.Range(0, 1);
        Instantiate(Terrain1[randomterrain], new Vector3(0, 0, 0), Quaternion.identity);
        while (objectcount < quantity)
        {
            randomobject = Random.Range(0, 1);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);
            if (randomobject == 0)
            {

                Instantiate(object1[randomobject], new Vector3(x, 20, z), Quaternion.identity);
            }
            objectcount++;
        }
        surfaces[0] = Terrain1[randomterrain].GetComponent<NavMeshSurface>();

        for (int j = 0; j < objectsToRotate.Length; j++)                        //loop for rotation
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        }
        for (int i = 0; i < surfaces.Length; i++)                               //building navigation
        {
            Debug.Log("I need to build");
            surfaces[i].BuildNavMesh();
        }
    }
}