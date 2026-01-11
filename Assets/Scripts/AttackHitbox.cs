using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public float damage = 10f;
    public float knockbackForce = 20f;

    void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            Vector3 dir = (other.transform.position - transform.position).normalized;
            damageable.TakeDamage(damage, dir);
        }
    }

}