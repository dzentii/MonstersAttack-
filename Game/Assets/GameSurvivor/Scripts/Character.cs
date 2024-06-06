using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    [SerializeField] protected float maxHealth;

    public float Health { get; private set; }

    public bool IsDead => Health <=0;

    private void Awake()
    {
        Health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        OnDamaged(damage);
        print("health change: " + damage + ", health: " + Health + ", " + name);

        if (IsDead)
        {
            gameObject.SetActive(false);
            OnDead();
        }
    }

    protected virtual void OnDamaged(float damage)
    {
    }
    
    protected virtual void OnDead()
    {
    }
}