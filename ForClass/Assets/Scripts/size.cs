using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    void Start()
    {
        //不同資料型態在記憶體中佔據的位元組數量
        Debug.Log("size of int: " + sizeof(int));
        Debug.Log("size of char: " + sizeof(char));
        Debug.Log("size of float: " + sizeof(float));
        Debug.Log("size of double: " + sizeof(double));
        

        //不同資料型態在加法上的不同
        int number1 = 4, number2 = 5;
        char char1 = '4';
        string string1 = "4";
        Debug.Log("int + int= "+number1 + number2);
        Debug.Log(number1 + char1);
        Debug.Log("int + string=" +number1 + string1);
    }

}
