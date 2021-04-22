using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    public AsyncOperation loadingOperation;


    // Start is called before the first frame update
    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(GameManager.sceneToLoad);

    }


    // Update is called once per frame
    void Update()
    {
    }
}