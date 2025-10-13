using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("이동 관련")]
    public float speed = 5f;          // 이동 속도
    private Vector2 inputVec;         // 입력 벡터

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
    }

    // Input System에서 Move 액션이 호출될 때 실행됨
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
