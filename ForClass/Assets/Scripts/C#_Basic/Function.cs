using UnityEngine;

public class Function : MonoBehaviour
{
    void Start()
    {
        TestClass calculator = new TestClass();//依照藍圖製造一個物件

        //設定物件的參數
        calculator.a = 5;
        calculator.b = 10;

        //調用物件的方法
        Debug.Log("calculator diff 5 and 10: "+calculator.diff(calculator.a, calculator.b));
        Debug.Log("calculator add 5 and 10: "+calculator.add(calculator.a, calculator.b));

        //用兩種方法調用private的參數
        //Debug.Log(calculator.secret);
        calculator.saysecret();
    }
}
