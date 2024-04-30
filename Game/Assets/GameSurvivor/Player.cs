using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float shootInterval;
    [SerializeField] private float shootSpeed;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Enemy[] enemies;

    private float shootTimer;

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var step = new Vector3(horizontal, vertical, 0);

        transform.position += step * moveSpeed * Time.deltaTime;
    }
    
    private void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0;
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            var rbody = bullet.GetComponent<Rigidbody2D>();
            Enemy closest = FindClosesEnemy();
            var direction = (closest.transform.position - transform.position).normalized;
            rbody.AddForce(direction * shootSpeed);
        }

        Enemy FindClosesEnemy()
        {
            Enemy closestEnemy = null;
            var minDistance = float.MaxValue;

            foreach (var enemy in enemies)
            {
                var distance = (enemy.transform.position - transform.position).magnitude;
                if (distance < minDistance)
                {
                    closestEnemy = enemy;
                    minDistance = distance;
                }
            }

            return closestEnemy;
        }
    }
}
