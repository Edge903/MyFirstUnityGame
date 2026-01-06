using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public Stats stats;

    public void TakeDamage (float incomingDamage, Vector3 hitDirection)
    {
        float finalDamage = Mathf.Max(
            incomingDamage * (stats.defense / (stats.defense + 100)),
            1f
        );

        stats.health -= finalDamage;

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
