using Unity.VisualScripting;
using UnityEngine;

public class TestClass
{
    public int a;
    public int b;
    public int add(int a, int b)
    {
        return a + b;
    }
    public int diff(int a, int b)
    {
        return a - b;
    }
    private string secret = "This is a Secret";
    public void saysecret()
    {
        Debug.Log(secret);
    }
}
