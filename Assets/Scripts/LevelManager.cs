using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool loaded = false;
    void Awake()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;
        Debug.Log(GameManager.instance.gameState);
        LevelLoading();


    }

    void LevelLoading()
    {
        StartCoroutine(GenerateTerrain());
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateTerrain()
    {
        randomterrain = Random.Range(0, 1);
        Instantiate(Terrain1[randomterrain], new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
    }
    IEnumerator GenerateObjects()                               //if you need to create object it creates in a random given position
    {
        if (objectcount == quantity)
        {
            loaded = true;
        }
        while (objectcount < quantity)
        {
            randomobject = Random.Range(0, 1);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);
            if (randomobject == 0)
            {
                Debug.Log(randomobject);
                Instantiate(object1[randomobject], new Vector3(x, 20, z), Quaternion.identity);
            }
            yield return null;
            objectcount++;
        }
        GameManager.instance.gameState = GameManager.GameState.Gameplay;

    }
}