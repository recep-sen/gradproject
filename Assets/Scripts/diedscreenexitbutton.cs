using UnityEngine;
public class diedscreenexitbutton : MonoBehaviour
{
    public void Buttonclicked()
    {
        GameManager.instance.gameState = GameManager.GameState.Gotomenu;     //setting instance to go to loading
    }
    public void Timecontinous()
    {
        Time.timeScale = 1f;                                //if it is paused resume
    }
}