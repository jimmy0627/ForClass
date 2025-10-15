
using UnityEngine;

public class ranadposition : MonoBehaviour
{

    [SerializeField] GameObject Ball;
    Rigidbody2D rigidbody2D;

    float timer = 0f;
    float speed = 3f;
    int times = 20;
    int j = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = new Rigidbody2D();
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer > 1f)
        // {
            var ball = Instantiate(Ball, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
            Destroy(ball, 3f);
            // timer = 0f;
        // }
        
    }


}
