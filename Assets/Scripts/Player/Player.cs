using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("이동 관련")]
    public float speed = 5f;          // 이동 속도
    private Vector2 inputVec;         // 입력 벡터
    public float minX = -9.5f;
    public float maxX = 9.5f;
    public float minY = -7f;
    public float maxY = 7f;



    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 입력값이 있을 경우 이동
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        // 플레이어 이동 최소, 최대 값
        if (rigid.position.x <= minX)
            rigid.MovePosition(new Vector2(minX + 0.01f, rigid.position.y));
        if (rigid.position.x >= maxX)
            rigid.MovePosition(new Vector2(maxX - 0.01f, rigid.position.y));
        if (rigid.position.y <= minY)
            rigid.MovePosition(new Vector2(rigid.position.x, minY + 0.01f));
        if (rigid.position.y >= maxY)
            rigid.MovePosition(new Vector2(rigid.position.x, maxY - 0.01f));

        // 총알 발사
        GameManager.instance.bulletGenerator.Shoot();

    }

    // Input System에서 Move 액션이 호출될 때 실행됨
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
