using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Kamikaze;
    public float KamikazeSpawnChance;
    public float Interval;
    public Transform BulletHolder;
    private Vector3 Direction;
    public void Configure(Transform bulletHolder, float dmg)
    {
        BulletHolder = bulletHolder;
        Damage = dmg;
    }
    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0.5f, Interval);
    }
    public void ChangeInterval(float interval)
    {
        Interval = interval;
        CancelInvoke(nameof(Shoot));
        InvokeRepeating(nameof(Shoot), 0, Interval);
    }
    public void Shoot()
    {
        if (Random.Range(1, 100) <= KamikazeSpawnChance)
        {
            GameObject kamikaze = Instantiate(Kamikaze, BulletHolder);
            kamikaze.transform.position = transform.position - Direction / 5;
        }
        else
        {
            Direction = (transform.parent.position - transform.position).normalized;
            Direction.z = 0;
            GameObject bullet = Instantiate(Bullet, BulletHolder);
            bullet.transform.position = transform.position - Direction / 5;
            bullet.GetComponent<Bullet>().Configure(bullet.transform.position - Direction, false, 10);
        }
    }
}
