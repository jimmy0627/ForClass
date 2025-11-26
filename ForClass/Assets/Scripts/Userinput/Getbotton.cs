using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
public class test : MonoBehaviour
{
    public string text;

    void Update()
    {
        foreach (char c in Input.inputString) //讀取被按下的按鈕
        {
            if (c=='\n' || c=='\r') //如果按下enter 就印出文字
            {
                Debug.Log(text);
                text=null;
            }
            else //否則紀錄有哪些字被按下
            {
                text+=c;
            }
        }
    }

    /*
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //檢測空白鍵是否被按下
        {
            Debug.Log("space is be presed"); //print 空白鍵被按下
        }
    }
    */
}
