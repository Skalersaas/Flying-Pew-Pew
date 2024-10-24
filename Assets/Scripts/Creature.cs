using UnityEngine;

public class Creature : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public float Health;
    public float maxHealth;
    public virtual void GetDamage(float damage)
    {
        Health -= damage;
    }
}
