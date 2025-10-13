using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EnemySpawnPool enemySpawnPool;   // 인스펙터에 드래그
    void Awake() { 
        instance = this; 
    }
}


