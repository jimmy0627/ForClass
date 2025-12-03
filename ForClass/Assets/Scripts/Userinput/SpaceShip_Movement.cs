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
        //rotate
        float inputvalue=movement.ReadValue<float>();
        rb.AddTorque(inputvalue*-1);

        
        //平移
        float verticalInput = Input.GetAxis("Vertical"); 
        float horizontalInput = Input.GetAxis("Horizontal"); 
        Vector3 Vertical = transform.up * verticalInput * verspeed;
        Vector3 Horizontal = transform.right * horizontalInput * horspeed;
        Vector3 dir = (Vertical + Horizontal).normalized;
        
        rb.AddForce(dir,ForceMode2D.Force);
    }
}
