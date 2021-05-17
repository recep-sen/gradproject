using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour
{
    public AsyncOperation loadingOperation;
    void Start()                                        //loading scene async
    {
        loadingOperation = SceneManager.LoadSceneAsync(GameManager.sceneToLoad);
    }
}