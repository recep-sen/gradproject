using UnityEngine;
public class Statbloc : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float respawn;
    public float money;
    public float thismoney;
    public float scoremltp;
    void Start()
    {
        money = GameManager.instance.score;
        respawn = (int)GameManager.instance.respawn;
        scoremltp = GameManager.instance.scoremltp;
    }
    void Update()
    {
        if (health > maxhealth)                                 //setting max health and health and storing player data
        {
            health = maxhealth;
        }
    }
}