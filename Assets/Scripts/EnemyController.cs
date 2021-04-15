using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject[] gameobject;                                            //necessary variables to store objects
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        gameobject = GameObject.FindGameObjectsWithTag("Player");                   //getting player objects transform data and navmeshagent component
        target = gameobject[0].transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()                                                                   //telling the ai to chase player
    {
        agent.SetDestination(target.position);
    }
}