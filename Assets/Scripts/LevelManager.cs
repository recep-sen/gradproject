using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour

{
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;
        LevelLoading();
        GameManager.instance.gameState = GameManager.GameState.Gameplay;

    }

    void LevelLoading()
    {

    }
}