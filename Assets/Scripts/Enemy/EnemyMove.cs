using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed = 3.0f;
    private int dir = -1;
    private float patrolDis = 15.0f;
    private float stopDis = 1.4f;
    private float distance;
    private float currentHealth;
    private float attack;

    private bool facingRight = false;
    private bool isTracking = false;

    public EnemyInfo data;    
    private Rigidbody2D rb;
    //enemy용 리지바디
    public Rigidbody2D target;
    //추격할 플레이어 리지바디

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = data.maxHealth;
        attack = data.attackDamage;
    }

    private void Update()
    {
        distance = Vector2.Distance(target.position, rb.position);

        if (!facingRight)
        {
            if (!isTracking && distance < patrolDis && distance > stopDis)
            {
                isTracking = true;
            }

            // 2) 추격 중일 때, 너무 가까워지면 추격 종료 + 영구 종료 플래그
            if (isTracking && distance <= stopDis)
            {
                isTracking = false;
                facingRight = true;     // ★ 여기서부터는 다시는 추격 안 함
            }
        }
        else
        {
            isTracking = false;
        }

    }

    void FixedUpdate()
    {
        if (isTracking)
        {
            ChaseMove();
        }
        else
        {
            StraightMove();
        }
    }


    private void StraightMove()
    {
        rb.linearVelocity = new Vector2(dir * speed, 0);
    }

    private void ChaseMove()
    {
        Vector2 chaseDir = (target.position - rb.position).normalized;
        rb.linearVelocity = chaseDir * speed;
    }

}