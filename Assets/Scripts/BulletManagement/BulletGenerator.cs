using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public Transform bulletInitPos; // 총알 생성 위치
    public GameObject bulletPrefab;
    public float intervelTime = 0.3f; // 발사 텀

    private float elapsedTime = 0.0f; //경과시간

    public void Shoot()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime > intervelTime)
        {
            if (this.elapsedTime > intervelTime)
            {
                this.CallBullet();
                this.elapsedTime = 0.0f;
            }
        }
    }

    private void CallBullet()
    {
        GameObject bullet = BulletPoolManager.instance.GetBulletInPool();
        if (bullet == null) // 이미 만들어둔 총알을 다 사용하면
        {
            bullet = Instantiate(this.bulletPrefab);
            BulletPoolManager.instance.bulletPool.Add(bullet); // 총알 추가 생성
            bullet.transform.position = this.bulletInitPos.position;
        }
        else if (bullet != null)
        {
            bullet.transform.SetParent(this.transform);
            bullet.transform.position = this.bulletInitPos.position;
            bullet.SetActive(true);
        }
    }
}
