using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InitiateLevel : MonoBehaviour
{
    public LevelManager levelmanager;
    private void Awake()
    {
        Instantiate(levelmanager, Vector3.zero, Quaternion.identity);
    }
}