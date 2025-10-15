using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class random_swpan : MonoBehaviour
{
    public GameObject ball;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(spwan());
    }
    IEnumerator spwan()
    {
        for (int i = 0; i < 200; i++)
        {
            Instantiate(ball, new Vector3(1, 3f, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }  
    }
}
