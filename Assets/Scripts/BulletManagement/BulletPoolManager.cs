using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public List<GameObject> bulletPool = new List<GameObject>();
    public GameObject bulletPrefab;
    public static BulletPoolManager instance;

    private int maxBullets = 20;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.CreateBulletPool();
    }

    private void CreateBulletPool()
    {
        for(int i = 0; i < maxBullets; i++)
        {
            GameObject bulletObject = Instantiate(this.bulletPrefab);
            bulletObject.SetActive(false);
            bulletObject.transform.SetParent(this.transform);
            bulletPool.Add(bulletObject);
        }
    }

    public GameObject GetBulletInPool()
    {
        foreach(GameObject bullet in this.bulletPool)
        {
            if (!bullet.activeSelf)
            {
                return bullet;
            }
        }

        return null;
    }

    public void ReleaseBullet(GameObject bulletObject)
    {
        bulletObject.SetActive(false);
        bulletObject.transform.SetParent(this.transform);
    }
}
