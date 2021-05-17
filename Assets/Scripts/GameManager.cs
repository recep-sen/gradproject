using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    public static int sceneToLoad;
    public GameState gameState;

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



    void Start()
    {

    }

    public enum GameState
    {
        MainMenu,
        Loading,
        Gameplay,
        GameExit,
        Dieded,
        Gotomenu
    }
    void FixedUpdate()
    {
        if (gameState == GameState.Loading)
        {
            gotoloading();
        }
        else if (gameState == GameState.GameExit)
        {
            gotoexit();
        }
        else if (gameState == GameState.Dieded)
        {
            dieded();
        }
        else if (gameState == GameState.Gotomenu)
        {
            gotomainmenu();
        }


    }
    public void gotoloading()
    {
        sceneToLoad = 2;
        SceneManager.LoadScene(1);
    }
    public void gotoexit()
    {
        Application.Quit();
    }
    public void dieded()
    {
    }
    public void gotomainmenu()
    {
        SceneManager.LoadScene(0);
        gameState = GameState.MainMenu;
    }
}