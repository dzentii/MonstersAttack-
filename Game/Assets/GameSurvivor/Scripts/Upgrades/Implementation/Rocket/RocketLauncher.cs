using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private float launchInterval;
    [SerializeField] private float launchSpeed;
    [SerializeField] private Rocket rocketPrefab;

    private EnemiesSpawner spawner;

    private float launcherTimer;

    private void Start() 
    {
        spawner = FindObjectOfType<EnemiesSpawner>();    
    }

    private void Update() 
    {
        launcherTimer += Time.deltaTime;
        if (launcherTimer >= launchInterval)
        {
            launcherTimer = 0;
            var closest = Helper.FindClosesEnemy(spawner, transform);
            if (closest)
            {
                var direction = (closest.transform.position - transform.position).normalized;
                Rocket rocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);
                rocket.Launch(direction * launchSpeed);
            } 
        }
    }
}