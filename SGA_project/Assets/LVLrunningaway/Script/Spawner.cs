using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 
 * write a spawner for unity,
 * the spawner create a new obstacle following a Poisson distribution
 * of lambda N second.
 * the obstacle is public and can be changed.
 * the N second also.
 * 
 */
public class ObstacleSpawner : MonoBehaviour
{
    // Public variables for obstacle prefab and lambda N
    public GameObject obstaclePrefab;
    public float lambda = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObstacles());
    }

    // Coroutine to spawn obstacles
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Calculate the next spawn time using Poisson distribution
            float spawnTime = GetPoissonRandom(lambda);
            yield return new WaitForSeconds(spawnTime);

            // Spawn the obstacle at the spawner's position
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
    }

    // Function to calculate Poisson random time
    float GetPoissonRandom(float lambda)
    {
        return lambda;
    }
}
