using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed = 5.0f;
    private int dir = -1;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);
    }
}
