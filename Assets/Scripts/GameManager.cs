using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

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
        //gameState = GameState.MainMenu;
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
        Debug.Log(gameState);
        if (gameState == GameState.Loading)
        {
            Debug.Log("LOADING");
        }

    }
}