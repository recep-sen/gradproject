using System.Collections;
using System.Collections.Generic;
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
            if (time >= 1f)
            {
                statbloc.health -= 2;
                time = 0f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        tobeactivated.SetActive(true);
        timeron = true;
        statbloc.health -= 2;
    }
    private void OnTriggerExit(Collider other)
    {
        tobeactivated.SetActive(false);
        timeron = false;
    }
}