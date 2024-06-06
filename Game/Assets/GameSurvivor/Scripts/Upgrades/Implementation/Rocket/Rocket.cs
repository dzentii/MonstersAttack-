using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Damager
{
    [SerializeField] private float aoe;
    [SerializeField] private Rigidbody2D rbody;

    public void Launch(Vector3 force)
    {
        rbody.AddForce(force);
        transform.up = force;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, aoe);
        bool anyDamaged = false;
        foreach (var target in targets)
            anyDamaged |= TryDoDamage(target);

        if (anyDamaged && destroyOnHit)
            Destroy(gameObject);

    }
}
