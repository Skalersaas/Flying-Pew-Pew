using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 Direction;
    [SerializeField] float Speed;
    [SerializeField] float Damage;
    [SerializeField] float LifeSpan;
    [SerializeField] bool Ally;
    public void Configure(Vector3 dest, bool ally, float dmg)
    {
        Ally = ally;
        if (Ally)
            GetComponent<SpriteRenderer>().color = Color.yellow;
        Damage = dmg;
       
        dest.z = 0;
        Direction = (dest - transform.position).normalized;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Destroy(gameObject, LifeSpan);
    }
    public void Update()
    {
        transform.position += Time.deltaTime * Speed * Direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Ally)
        {
            if (collision.CompareTag("Boss"))
                collision.gameObject.GetComponent<Boss>().GetDamage(Damage);
            else if (collision.CompareTag("Kamikaze"))
                collision.gameObject.GetComponent<Kamikaze>().GetDamage(Damage);
            else
                return;
        }
        else if (!Ally && collision.transform.CompareTag("Player"))
            collision.gameObject.GetComponent<Player>().GetDamage(Damage);
        else
            return;

        Destroy(gameObject);
    }

}
