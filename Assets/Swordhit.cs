using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordhit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Died();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Statbloc>().money += 30;
        }
    }
}
