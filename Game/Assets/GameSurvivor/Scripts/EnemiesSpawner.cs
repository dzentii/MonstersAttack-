using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius;
    [SerializeField] private Transform center;

    [Serializable]

    class Wave
    {
        public float spawnTime;
        public Enemy enemyPrefab;
        public int countMin;
        public int countMax;
    }

    [SerializeField] private Wave[] waves;

    private int waveIndex;

    private Wave CurrentWave => waves[waveIndex];
    private bool HasWaves => waveIndex < waves.Length;

    public List<Enemy> SpawnedEnemies { get; } = new List<Enemy>();

    private void Update() 
    {
        if (HasWaves && Time.timeSinceLevelLoad > CurrentWave.spawnTime)
        {   
            Spawn();
            waveIndex++;
        }
    }
    
    private void Spawn()
    {
        var count = UnityEngine.Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);
        for (int i = 0; i < count; i++)
        {
            var position = center.position + (Vector3)UnityEngine.Random.insideUnitCircle * spawnRadius;
            var enemy = Instantiate(CurrentWave.enemyPrefab, position, Quaternion.identity);
            SpawnedEnemies.Add(enemy);
        }
    }
}
