using UnityEngine;

public class Enemy : Character
{
    protected Transform target;

    [SerializeField] private ExperiencePickup pickup;

    protected virtual void Start() 
    {
        target = FindObjectOfType<Player>().transform;
    }

    protected virtual private void Update()
    {
        var direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    protected override void OnDead()
    {
        Instantiate(pickup, transform.position, Quaternion.identity);
    }
}