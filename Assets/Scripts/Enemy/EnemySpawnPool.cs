using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnPool : MonoBehaviour
{
    public GameObject[] enemyPrefab;  // 인스펙터에 드래그
    public List<GameObject>[] pool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        pool = new List<GameObject>[enemyPrefab.Length];
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            pool[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;

        foreach (var item in pool[i])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }


        if (!select)
        {
            select = Instantiate(enemyPrefab[i],transform);
            pool[i].Add(select);
        }

        return select;
    }
}
