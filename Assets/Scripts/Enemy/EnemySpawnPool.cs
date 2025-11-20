using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnPool : MonoBehaviour
{
    public GameObject[] enemyPrefab; //적 프리팹 배열
    public List<GameObject>[] pool; //오브젝트 풀 배열

    private void Awake()
    {
        pool = new List<GameObject>[enemyPrefab.Length]; 
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            pool[i] = new List<GameObject>();
        }
        //각 프리페베대한 오브젝트 풀 임의값 초기화
    }

    public GameObject Get(int i)
    {
        GameObject select = null; //반환할 오브젝트

        foreach (var item in pool[i])
        {
            if (!item.activeSelf)//비활성화 오브젝트 탐색
            {
                select = item; //각 풀에서 오브젝트 셀렉
                select.SetActive(true); // 활성화
                break; // 반복문 탈출
            }
        }


        if (!select) // 활성화 오브젝트가 없을 경우
        {
            select = Instantiate(enemyPrefab[i],transform);// 프리팹 인스턴스화
            pool[i].Add(select);// 풀에 추가
        }

        return select;// 선택된 오브젝트 반환
    }

    public void Return(GameObject select,int i)//오브젝트 반환 메서드
    {
        select.SetActive(false);
    }
}
