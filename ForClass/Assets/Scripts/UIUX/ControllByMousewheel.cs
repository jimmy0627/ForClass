using UnityEngine;
using UnityEngine.InputSystem;

public class ControllByMousewheel : MonoBehaviour
{
    public InputAction movement;
    void Start()
    {
        movement.Enable();
    }
    void FixedUpdate()
    {
        int value=(int)movement.ReadValue<float>();
        if (value==-1)
        {
            transform.GetComponent<ChangeText>().onclicktext();
        }
    }
}
