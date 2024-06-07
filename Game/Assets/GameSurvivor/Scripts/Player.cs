using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float shootInterval;
    [SerializeField] private float shootSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private EnemiesSpawner spawner;
    [SerializeField] private UpgradesManager upgradesManager;
    [SerializeField] private int[] experiencesLevels;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerUI localUI;
    [SerializeField] private AudioClip shootAudio;
    [SerializeField] private AudioManager audioManager;

    private float shootTimer;
    private int currentLevel;
    private int experience;

    private const float BulletsInterval = 0.25f;
    public int BulletsCount { get; set; } = 1;

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
            StartCoroutine(ShootProcess());
        }

        localUI.UpdateColldown(shootTimer, shootInterval);
    }

    private IEnumerator ShootProcess()
    {
        for (int i = 0; i < BulletsCount; i++)
        {
            var closest = Helper.FindClosesEnemy(spawner, transform);
            if (closest)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                var rbody = bullet.GetComponent<Rigidbody2D>();
                var direction = (closest.transform.position - transform.position).normalized;
                rbody.AddForce(direction * shootSpeed);
                audioManager.PlayAudio(shootAudio, 0.2f);
            }

            yield return new WaitForSeconds(BulletsInterval);
        }
    }
    
    public void AddExperience(int value)
    {
            experience += value;
            var newLevel = Array.FindLastIndex(experiencesLevels, e => experience >= e);
            Debug.Log("Level: " + currentLevel + ", exp: " + experience);
            if (newLevel > currentLevel)
            {
                upgradesManager.Suggest();
                currentLevel = newLevel;
                uiManager.SetLevel(currentLevel + 1);
            }
    }

    protected override void OnDamaged(float damage)
    {
        uiManager.SetHealth(Health, maxHealth);
        localUI.ShowDamage(damage); 
    }
}
