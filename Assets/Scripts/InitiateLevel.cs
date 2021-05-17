using UnityEngine;
public class InitiateLevel : MonoBehaviour
{
    public LevelManager levelmanager;
    private void Awake()
    {
        Instantiate(levelmanager, Vector3.zero, Quaternion.identity);   //initilazing level  manager
    }
}