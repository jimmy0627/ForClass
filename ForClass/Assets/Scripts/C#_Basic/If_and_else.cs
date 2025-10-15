using UnityEngine;

public class If_and_else : MonoBehaviour
{
    
    void Start()
    {
        //設定參數
        int a = 8, b = 5;

        //判斷式會輸出布林值
        Debug.Log("a>b is : " + (a > b));
        Debug.Log("a<b is : " + (a < b));
        Debug.Log("a=b is :" + (a == b));

        //利用判斷是製作一個刪選器
        if (a > b)
        {
            Debug.Log("a>b");
        }
        else if (a < b)
        {
            Debug.Log("a<b");
        }
    }
}
