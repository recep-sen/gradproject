using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenubuttons : MonoBehaviour
{
    public GameObject main;
    public GameObject[] actives;
    private void Start()
    {
    }
    public void buttonStart()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;
    }
    public void buttonExit()
    {
        GameManager.instance.gameState = GameManager.GameState.GameExit;
    }
    public void buttonNewGame()
    {
        main.SetActive(false);
        foreach (GameObject active in actives)
        {
            active.SetActive(true);
        }
    }
}