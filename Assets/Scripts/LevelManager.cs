using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour

{
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
            randomobject = Random.Range(0, object1.Length);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);



            Instantiate(object1[randomobject], new Vector3(x, 20, z), Quaternion.identity);

            objectcount++;
        }
    }
}