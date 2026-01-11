using System.Diagnostics.Contracts;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public Stats stats;
    public Rigidbody rb;
    public float knockbackMultiplier = 1f;

    public void TakeDamage (float incomingDamage, Vector3 hitDirection)
    {
        float finalDamage = Mathf.Max(
            incomingDamage * (stats.defense / (stats.defense + 100)),
            1f
        );

        stats.health -= finalDamage;
        if (rb != null)
        {
            rb.AddForce(hitDirection * knockbackMultiplier, ForceMode.Impulse);
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
