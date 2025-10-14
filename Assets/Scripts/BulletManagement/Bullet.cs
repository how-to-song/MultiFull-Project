using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float damage;
    public int per;

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * this.moveSpeed * Time.deltaTime);
        this.SelfComeback();
    }

    private void SelfComeback()
    {
        if (this.transform.position.x > 9.5f)
        {
            BulletPoolManager.instance.ReleaseBullet(this.gameObject);
        }
    }
}
