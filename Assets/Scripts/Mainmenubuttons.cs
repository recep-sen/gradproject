using UnityEngine;
public class Mainmenubuttons : MonoBehaviour
{
    public GameObject main;
    public GameObject[] actives;
    public void buttonStart()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;             //setting apporipate gamestate
    }
    public void buttonExit()
    {
        GameManager.instance.gameState = GameManager.GameState.GameExit;
    }
    public void buttonNewGame()
    {
        main.SetActive(false);                                          //changing of ui with button
        foreach (GameObject active in actives)
        {
            active.SetActive(true);
        }
    }
}