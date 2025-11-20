using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Hitbox가 켜져 있을 때 적과 충돌하면 호출됨
        if (other.CompareTag("Enemy"))
        {
            // TODO: 적의 Health 컴포넌트를 찾아서 데미지 부여
            // other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            Debug.Log(other.name + "에게 데미지 " + damageAmount + " 부여!");
        }
    }
}
