using UnityEngine;

public class Player : Creature
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletHolder;
    public void Move(float x, float y)
    {
        transform.position += Speed * Time.deltaTime * new Vector3(x, y) ;
    }
    public void Shoot(Vector3 pos)
    {
        GameObject bullet = Instantiate(Bullet, BulletHolder);
        pos.z = 0;
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().Configure(pos, true, Damage);
    }
}
