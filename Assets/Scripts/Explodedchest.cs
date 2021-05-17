using UnityEngine;
public class Explodedchest : MonoBehaviour
{
    public ChestScript chestScript;
    public Transform trans;
    public GameObject gameobject;                                           //variables
    void Start()
    {
        chestScript = GetComponentInParent<ChestScript>();                //references
        trans = GetComponentInParent<Transform>();
    }
    void Update()
    {
        if (trans.rotation.x >= -85)
        {
            chestScript.a = 2;                                          //refering to other script
        }
    }
    public void Explode()
    {
        gameobject.SetActive(true);                        //activating effect
    }
}