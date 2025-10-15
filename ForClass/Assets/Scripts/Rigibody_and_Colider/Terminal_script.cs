using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Terminal_script : MonoBehaviour
{
    public List<int> statis = new List<int>();
    public List<GameObject> counters = new List<GameObject>();
    void Start()
    {
        foreach (var item in counters)
        {
            statis.Add(item.GetComponent<Counter_Script>().count);
        }
    }
    void FixedUpdate()
    {
        int i = 0;
        foreach (var item in counters)
        {
            statis[i] = item.GetComponent<Counter_Script>().count;
            i++;
        }
    }
}
