using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class SpaceShip_Movement : MonoBehaviour
{
    [SerializeField] float horspeed;
    [SerializeField] float verspeed;
    [SerializeField] float rotatespeed;
    public InputAction movement;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.Enable();
    }
    void Update()
    {
        float inputvalue=movement.ReadValue<float>();
        float verticalInput = Input.GetAxis("Vertical"); 
        float horizontalInput = Input.GetAxis("Horizontal"); 
        Vector3 forwardMovement = transform.up * verticalInput * verspeed;
        Vector3 strafeMovement = transform.right * horizontalInput * horspeed;
        Vector3 dir = (forwardMovement + strafeMovement).normalized;
        rb.AddTorque(inputvalue*-1); ;
        rb.AddForce(dir,ForceMode2D.Force);
    }
}
