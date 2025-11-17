using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed = 3.0f;
    private int dir = -1;
    private float patrolDis = 15.0f;
    private float stopDis = 1.4f;
    float distance;
    private bool isTracking = false;

    private Rigidbody2D rb;
    //enemy용 리지바디
    public Rigidbody2D target;
    //추격할 플레이어 리지바디

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        //프리팹 상태끼리는 연결이 되지만 장면위에 이미 올라간 것들은 연결이 안도니 여기서 플레이어의 리지바디를 연결
        //여기서 다시 연결/ 인스펙터에서 연결하더라더 연결이 안됨.
    }

    private void Move()
    {
        distance = Vector2.Distance(target.position, rb.position);

        if (distance <= stopDis)
        {
            isTracking = false;
        }
        else if (distance <= patrolDis)
        {
            isTracking = true;
        }


        if (isTracking)
        {

            Vector2 chaseDir = (target.position - rb.position).normalized;
            rb.linearVelocity = chaseDir * speed;
        }
        else
        {
            rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);
        }

    }
}
