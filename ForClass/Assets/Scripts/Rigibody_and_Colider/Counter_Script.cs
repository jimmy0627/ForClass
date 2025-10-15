using UnityEngine;

public class Counter_Script : MonoBehaviour
{
    public int count = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
    }
}
