using UnityEngine;
public class WaitingScript : MonoBehaviour
{
    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)                                     //after 5 seconds deletes the object
        {
            Destroy(this.gameObject);
        }
    }
}