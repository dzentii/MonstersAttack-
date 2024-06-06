using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private float shootInterval;
    [SerializeField] private float shootSpeed;
    [SerializeField] private GameObject bulletPrefab;
    
    private float shootTimer; 
    
    private protected override void Update() 
    {
        base.Update();
        Shoot();
    }

    
    
     private void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0;
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            var rbody = bullet.GetComponent<Rigidbody2D>();
            var direction = (target.position - transform.position).normalized;
            rbody.AddForce(direction * shootSpeed);
        }
    }
}
