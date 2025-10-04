using UnityEngine;

public class If_and_else : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int a = 5, b = 5;
        Debug.Log("a>b is : " + (a > b));
        Debug.Log("a<b is : " + (a < b));
        if (a > b)
        {
            Debug.Log("a>b");
        }
        else if (a<b)
        {
            Debug.Log("a<b");
        }
    }
}
