using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.Mathematics;
public class guns : MonoBehaviour
{
    public GameObject bullet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet,transform.position,quaternion.identity,transform);
        }
    }
}
