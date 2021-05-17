using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour

{
    public GameObject[] trees;
    public GameObject[] chests;
    public int tree_quantity;
    public int tree_objectcount;
    public int chest_quantity;
    public int chest_objectcount;
    public GameObject[] enemies;
    public int enemy_quantity;
    public int enemy_objectcount;
    [Header("Generated Texture")]
    public GameObject Terrain1;
    [Header("Generated Objects")]                           //getting necessary components and variables
    public GameObject[] object1;
    [Header("Coordinates of Objects")]
    public int x;
    public int z;
    private int randomobject = 0;
    [Header("Object Quantity")]
    public int quantity;
    [Header("Objects In Scene")]
    public int objectcount;
    void Awake()
    {

        GameManager.instance.gameState = GameManager.GameState.Gameplay;
        LevelLoading();




    }

    public void LevelLoading()
    {
        Instantiate(Terrain1, new Vector3(0, 0, 0), Quaternion.identity);
        while (objectcount < quantity)
        {
            randomobject = Random.Range(0, object1.Length);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);



            Instantiate(object1[randomobject], new Vector3(x, 20, z), Quaternion.identity);

            objectcount++;
        }
        while (chest_objectcount < chest_quantity)
        {
            randomobject = Random.Range(0, chests.Length);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);



            Instantiate(chests[randomobject], new Vector3(x, 20, z), Quaternion.identity);

            chest_objectcount++;
        }
        while (enemy_objectcount < enemy_quantity)
        {
            randomobject = Random.Range(0, enemies.Length);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);



            Instantiate(enemies[randomobject], new Vector3(x, 20, z), Quaternion.identity);

            enemy_objectcount++;
        }
        while (tree_objectcount < tree_quantity)
        {
            randomobject = Random.Range(0, trees.Length);
            x = Random.Range(0, 500);
            z = Random.Range(0, 500);



            Instantiate(trees[randomobject], new Vector3(x, 20, z), Quaternion.identity);

            tree_objectcount++;
        }
    }
}