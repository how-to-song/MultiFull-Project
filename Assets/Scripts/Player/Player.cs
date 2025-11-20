using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; // 코루틴 사용을 위해 추가

public class Player : MonoBehaviour
{
    [Header("이동 관련")]
    public float speed = 5f;          // 이동 속도
    private Vector2 inputVec;         // 입력 벡터
    public float minX = -9.5f;
    public float maxX = 9.5f;
    public float minY = -7f;
    public float maxY = 7f;

    [Header("공격 관련")]
    public GameObject meleeHitbox;      // 근접 공격 범위 (Hitbox) 오브젝트
    public float attackCooldown = 0.5f; // 공격 쿨타임
    public float hitboxDuration = 0.2f; // Hitbox 유지 시간 (애니메이션 타이밍에 맞춤)
    private float nextAttackTime = 0f;  // 다음 공격 가능 시간



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

    private void OnFire()
    {
        // 쿨타임 체크: 현재 시간(Time.time)이 다음 공격 가능 시간(nextAttackTime)보다 크거나 같을 때만 공격
        if (Time.time >= nextAttackTime)
        {
            // 다음 공격 가능 시간 업데이트
            nextAttackTime = Time.time + attackCooldown;

            // Hitbox 관리 코루틴 시작
            StartCoroutine(MeleeAttackCoroutine());

            // TODO: 근접 공격 애니메이션을 재생하는 코드 추가
            // GetComponent<Animator>().SetTrigger("Melee"); 
        }
    }

    IEnumerator MeleeAttackCoroutine()
    {
        // Hitbox 오브젝트가 설정되어 있지 않다면 에러 방지
        if (meleeHitbox == null)
        {
            Debug.LogError("근접 공격을 위해 Hitbox 오브젝트를 할당해야 합니다!");
            yield break;
        }

        // 1. Hitbox 오브젝트를 활성화하여 공격 감지 시작
        meleeHitbox.SetActive(true);

        // 2. hitboxDuration 시간(프레임)만큼 대기
        yield return new WaitForSeconds(hitboxDuration);

        // 3. Hitbox 오브젝트를 비활성화하여 공격 종료
        meleeHitbox.SetActive(false);
    }
}
