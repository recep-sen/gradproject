using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapActivated : MonoBehaviour
{
    public GameObject tobeactivated;
    private void OnTriggerEnter(Collider other)
    {
        tobeactivated.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        tobeactivated.SetActive(false);
    }
}
