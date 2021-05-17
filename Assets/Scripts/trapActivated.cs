using UnityEngine;
public class trapActivated : MonoBehaviour
{
    public GameObject tobeactivated;
    private Statbloc statbloc;
    private bool timeron = false;
    private float time = 0f;
    private void Start()
    {
        statbloc = GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>();
    }
    private void Update()
    {
        if (timeron)
        {
            time += Time.deltaTime;
            if (time >= 1f)                                           //simple timer to damage over time
            {
                statbloc.health -= 2;
                time = 0f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {                                                           //damaging player
            tobeactivated.SetActive(true);
            timeron = true;
            statbloc.health -= 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tobeactivated.SetActive(false);                                 //closing trap if player leaves
            timeron = false;
        }
    }
}