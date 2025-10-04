using System.Collections.Generic;
using UnityEngine;

public class listandarray : MonoBehaviour
{
    List<int> list = new List<int>();
    int[] array = new int[] { 1, 2, 3 };
    void Start()
    {
        //在list裡填入資料
        list.Add(1);
        list.Add(3);
        list.Add(2);
        list.Add(3);
        Debug.Log("list " + list);
        //輸出list
        string test = "";
        foreach (int item in list)
        {
            test += item + " ";
        }
        Debug.Log("list before remove: " + test);

        //輸出被移除3後的list
        list.Remove(3);
        string test2 = "";
        for (int i = 0; i < list.Count; i++)
        {
            test2 += list[i] + " ";
        }
        Debug.Log("list after remove: " + test2);

        Debug.Log("Whether the list contains 1 before remove: " + list.Contains(1));
        list.Remove(1);
        Debug.Log("Whether the list contains 1 after remove: " + list.Contains(1));



        list.Clear();
        Debug.Log(list.Count);
    }
}
