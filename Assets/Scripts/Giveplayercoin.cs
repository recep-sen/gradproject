using UnityEngine;
public class Giveplayercoin : MonoBehaviour
{
    public ChestScript chestScript;
    void Start()
    {                                        //setting chest script to apporipate
        chestScript = GetComponentInParent<ChestScript>();
        chestScript.a = 1;
    }
}