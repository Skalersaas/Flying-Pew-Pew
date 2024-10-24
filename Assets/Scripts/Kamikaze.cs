using UnityEngine;

public class Kamikaze : Creature
{
    [SerializeField] Transform Player;
    [SerializeField] float ExplosionDistance;
    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        transform.position += Speed * Time.deltaTime * (Player.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, Player.position) < ExplosionDistance)
        {
            Player.GetComponent<Player>().GetDamage(Damage);
            Destroy(gameObject);
        }
    }
    public override void GetDamage(float damage)
    {
        Destroy(gameObject);
    }
}
