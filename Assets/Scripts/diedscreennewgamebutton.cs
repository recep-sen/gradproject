using UnityEngine;
public class diedscreennewgamebutton : MonoBehaviour
{
    public void buttonclicked()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;         //setting instance to go to loading
    }
    public void Timecontinous()
    {
        Time.timeScale = 1f;                                           //if it is paused resume
    }
}