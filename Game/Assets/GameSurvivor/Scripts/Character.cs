using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected AudioClip damageAudio;
    [SerializeField] protected ParticleSystem hitEffect;

    private AudioManager audioManager;

    public float Health { get; private set; }

    public bool IsDead => Health <=0;

    private void Awake()
    {
        Health = maxHealth;
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);

        audioManager.PlayAudio(damageAudio, 0.2f);
        hitEffect.Play();
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