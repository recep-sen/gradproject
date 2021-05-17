using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    public static int sceneToLoad;                                      //variables
    public GameState gameState;
    public float score = 0f;
    public float chests = 1000f;             //min 100
    public float enemies = 100f;             //max 1000
    public float trap = 100f;                //max 1000
    public float respawn = 5f;            //min 0
    public float scoremltp;
    private void Awake()
    {
        if (instance != null)                           //singleton check and persistent
        {
            Debug.LogError($"More than one {name} detected! Critical errors might occur.");
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);
    }
    #endregion
    public enum GameState
    {
        MainMenu,
        Loading,                                            //gamestates enum
        Gameplay,
        GameExit,
        Dieded,
        Gotomenu
    }
    void FixedUpdate()
    {
        if (gameState == GameState.Loading)
        {
            gotoloading();                                           //doing stuff to enums
        }
        else if (gameState == GameState.GameExit)
        {
            gotoexit();
        }
        else if (gameState == GameState.Gotomenu)
        {
            gotomainmenu();
        }
        scoremltp = (250f / chests) + (enemies / 400f) + (trap / 400f) + (1.5f / (respawn + 1f));
    }
    public void gotoloading()
    {                                                   //calling loading screen
        sceneToLoad = 2;
        SceneManager.LoadScene(1);
    }
    public void gotoexit()
    {
        Application.Quit();                          //quitting
    }
    public void gotomainmenu()
    {
        SceneManager.LoadScene(0);                          //calling main menu
        gameState = GameState.MainMenu;
    }
}