using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptable Objects/EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    public float maxHealth = 10.0f;
    public float speed = 3.0f;
    public float attackDamage = 2.0f;
    public float attackRange = 1.5f;

}
