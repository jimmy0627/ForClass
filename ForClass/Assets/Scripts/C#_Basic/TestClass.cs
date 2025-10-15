using Unity.VisualScripting;
using UnityEngine;

public class TestClass //繪製一個藍圖
{
    //儲存狀態
    public int a;
    public int b;
    private string secret = "This is a Secret";

    //儲存方法
    public int add(int a, int b)
    {
        return a + b;
    }
    public int diff(int a, int b)
    {
        return a - b;
    }
    
    public void saysecret()
    {
        Debug.Log(secret);
    }
}
