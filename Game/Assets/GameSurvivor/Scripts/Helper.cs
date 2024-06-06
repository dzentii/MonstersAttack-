using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static Enemy FindClosesEnemy(EnemiesSpawner spawner, Transform source)
        {
            Enemy closestEnemy = null;
            var minDistance = float.MaxValue;

            foreach (var enemy in spawner.SpawnedEnemies)
            {
                if (enemy.IsDead)
                    continue;
                var distance = (enemy.transform.position - source.position).magnitude;
                if (distance < minDistance)
                {
                    closestEnemy = enemy;
                    minDistance = distance;
                }
            }

            return closestEnemy;
        }   
}
