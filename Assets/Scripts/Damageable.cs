using System.Diagnostics.Contracts;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public Stats stats;
    public Rigidbody rb;
    public float knockbackMultiplier = 1f;

    public void TakeDamage (DamageInfo info)
    {
        float finalDamage = Mathf.Max(
            info.damage * (stats.defense / (stats.defense + 100)),
            1f
        );

        stats.health -= finalDamage;
        if (rb != null && info.knockbackForce > 0f)
        {
            rb.AddForce(info.direction * info.knockbackForce, ForceMode.Impulse);
        }

        if (stats.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
