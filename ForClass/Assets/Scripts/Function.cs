using UnityEngine;

public class Function : MonoBehaviour
{
    void Start()
    {
        TestClass calculator = new TestClass();
        calculator.a = 5;
        calculator.b = 10;
        Debug.Log(calculator.diff(calculator.a, calculator.b));
        //Debug.Log(calculator.secret);
        calculator.saysecret();
    }
}
