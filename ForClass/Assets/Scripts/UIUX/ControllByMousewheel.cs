using UnityEngine;
using UnityEngine.InputSystem;

public class ControllByMousewheel : MonoBehaviour
{
    public InputAction movement;
    void Start()
    {
        movement.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        int value=(int)movement.ReadValue<float>();
        if (value!=0)
        {
            Debug.Log(value);
        }
    }
}
