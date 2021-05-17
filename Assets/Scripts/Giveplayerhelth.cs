using UnityEngine;
public class Giveplayerhelth : MonoBehaviour
{
    public ChestScript chestScript;
    void Start()
    {                                                             //setting chest script to apporipate
        chestScript = GetComponentInParent<ChestScript>();
        chestScript.a = 0;
    }
}