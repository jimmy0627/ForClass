using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
public class test : MonoBehaviour
{
    public string text;
    /*
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c=='\n' || c=='\r')
            {
                Debug.Log(text);
                text=null;
            }
            else
            {
                text+=c;
            }
        }
    }
    */
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space is be presed");
        }
    }
}
