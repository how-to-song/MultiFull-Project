using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.instance.enemySpawnPool.Get(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.instance.enemySpawnPool.Get(0);
        }
    }
}
