using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    public static int sceneToLoad;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"More than one {name} detected! Critical errors might occur.");
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);
    }
    #endregion

    public GameState gameState;

    void Start()
    {

    }

    public enum GameState
    {
        MainMenu,
        Loading,
        Gameplay,
        GameExit
    }
    void Update()
    {
        if (gameState == GameState.Loading)
        {
            gotoloading();
        }


    }
    public void gotoloading()
    {
        sceneToLoad = 2;
        SceneManager.LoadScene(1);
    }
}