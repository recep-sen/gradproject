using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InitiateLevel : MonoBehaviour
{
    LoadingManager loadingManager;
    GameObject lvlmngr;
    private void Start()
    {
        loadingManager = LoadingManager.Instance;
    }
    void FixedUpdate()
    {
        lvlmngr = GameObject.Find("LevelManager");
        if (loadingManager.loadingOperation.isDone)
        {
            lvlmngr.GetComponent<LevelManager>().LevelLoading();
            GameManager.instance.gameState = GameManager.GameState.Gameplay;
            Destroy(this.gameObject);
        }


    }
}