using UnityEngine;

public class Finish_detect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Finished!!!!");
    }
}
