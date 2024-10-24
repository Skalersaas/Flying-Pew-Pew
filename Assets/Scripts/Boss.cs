using System.Collections;
using UnityEngine;

public class Boss : Creature
{
    [SerializeField] GameObject Shooter;
    [SerializeField] Transform BulletHolder;
    [SerializeField] bool unTouchable = false;
    [SerializeField] float rotationSpeed;
    [SerializeField] float StagePercent = 0.5f;
    public void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            float angle = i * Mathf.PI / 8;


            Vector3 position = new Vector3(Mathf.Cos(angle) * 2, Mathf.Sin(angle) * 2, 0) + transform.position;

            var shooter = Instantiate(Shooter, position, Quaternion.identity, transform);
            shooter.GetComponent<Shooter>().Configure(BulletHolder, Damage);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    public override void GetDamage(float dmg)
    {
        if (unTouchable)
            return;
        base.GetDamage(dmg);
        if (Health <= maxHealth * StagePercent)
        {
            if (StagePercent == 0.5f)
            {
                StagePercent = 0.25f;
                foreach (var shooter in transform.GetComponentsInChildren<Shooter>())
                {
                    shooter.KamikazeSpawnChance = 5;
                }
            }
            else if (StagePercent == 0.25f)
            {
                StagePercent = 0.05f;
                rotationSpeed *= 2;
                foreach (var shooter in transform.GetComponentsInChildren<Shooter>())
                {
                    shooter.KamikazeSpawnChance *= 2;
                }
            }
            else if (StagePercent == 0.05f)
            {
                StagePercent = 0;
                rotationSpeed *= 3;
                foreach (var shooter in transform.GetComponentsInChildren<Shooter>())
                {
                    shooter.ChangeInterval(shooter.Interval / 3);
                }
                StartCoroutine(MakeInvinsibleFor(30f));
            }
        }
    }
    private IEnumerator MakeInvinsibleFor(float secs)
    {
        unTouchable = true;
        yield return new WaitForSeconds(secs);
        unTouchable = false;
    }
}
