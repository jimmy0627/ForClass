using UnityEngine;
using System.Collections;
public class movebygetaxis : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float hor=1f;
        float ver=1f;
        Vector2 dir=new Vector2(hor*Input.GetAxis("Horizontal"),ver*Input.GetAxis("Vertical"));
        rb.linearVelocity=dir;
    }

}
