using UnityEngine;

public class gamemanagerinstansiater : MonoBehaviour
{
    public static bool GMACTIVE = false;
    public GameObject gm;                               //global and local variables
    void Awake()
    {
        if (!GMACTIVE)                                    //to ensure game manager is single
        {
            Instantiate(gm, new Vector3(0, 0, 0), Quaternion.identity);
            GMACTIVE = true;
        }
    }
}