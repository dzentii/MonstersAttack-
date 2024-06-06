using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] protected bool destroyOnHit;

    protected virtual void OnTriggerEnter2D(Collider2D collision) 
    {
        if (TryDoDamage(collision) && destroyOnHit)
            Destroy(gameObject);
    }

    protected bool TryDoDamage(Collider2D collision)
    {
        var hasHealth = collision.TryGetComponent<Character>(out var character);
        var otherHealth = !collision.CompareTag(tag);
        if (hasHealth && otherHealth)
        {
            character.TakeDamage(damage);
            return true;
        }

        return false;
    }
}