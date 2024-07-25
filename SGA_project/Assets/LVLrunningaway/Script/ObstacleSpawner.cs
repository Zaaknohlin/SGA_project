using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * 
 * 
 * write a spawner for unity,
 * the spawner create a new obstacle
 * the obstacle is public and can be changed.
 * 
 */
public class ObstacleSpawner : MonoBehaviour
{
    // Public variables for obstacle prefab and lambda N
    public GameObject obstaclePrefab;
    public float lambda = 3.0f;

    // List of possible directions
    private List<Vector3> directions = new List<Vector3>
    {
        Vector3.down,
        new Vector3(-0.5f, -1, 0).normalized, // Down-Left
        new Vector3(0.5f, -1, 0).normalized   // Down-Right
    };

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
            float elapsedTime = Time.time; // know for how long the game have been running.

            //--------------------------------------------------------------------------------------- SPAWN RATE
            // Calculate the next spawn time using the currently elapsed time and a random component
            float spawnTime = (float)(2 * Math.Exp(-(Math.Log(2) * (elapsedTime / 20))));

            // Generate a random jitter between -0.2 and +0.2
            float jitter = UnityEngine.Random.Range(-0.2f, 0.2f);

            // Apply the jitter to the spawn time
            spawnTime = spawnTime * (1 + jitter);

            yield return new WaitForSeconds((spawnTime));

            //--------------------------------------------------------------------------------------- Obstacle Acceleration

            // Calculate the acceleration using the currently elapsed time and a random component
            float currentObstacleAcceleration = (float)(2 * Math.Exp(-(Math.Log(2) * (elapsedTime / 30))));
            float jitterAcceleration = UnityEngine.Random.Range(-0.2f, 0.2f);
            // Apply the jitter to the Acceleration time
            currentObstacleAcceleration = currentObstacleAcceleration * (1 + jitterAcceleration);
            //--------------------------------------------------------------------------------------- Obstacle configuration 
            int randomIndex = UnityEngine.Random.Range(0, 3); // in the beginning, only single obstacle
            if (elapsedTime > 10) // unlock more complexe pattern after 10 sec
            {
                // 6 possible pattern, 3 solo, 3 double
                randomIndex = UnityEngine.Random.Range(0, 6);
            }

            switch (randomIndex)
            {
                case 0:
                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleA = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteA = obstacleA.GetComponent<MoveSprite>();
                    moveSpriteA.SetDirection(directions[0]);
                    moveSpriteA.SetGravity(currentObstacleAcceleration);
                    break;
                case 1:
                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleB = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteB = obstacleB.GetComponent<MoveSprite>();
                    moveSpriteB.SetDirection(directions[1]);

                    break;
                case 2:
                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleC = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteC = obstacleC.GetComponent<MoveSprite>();
                    moveSpriteC.SetDirection(directions[2]);

                    break;
                case 3: //  _XX
                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleD = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteD = obstacleD.GetComponent<MoveSprite>();
                    moveSpriteD.SetDirection(directions[1]);

                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleE = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteE = obstacleE.GetComponent<MoveSprite>();
                    moveSpriteE.SetDirection(directions[2]);

                    break;
                case 4: //  XX_
                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleF = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteF = obstacleF.GetComponent<MoveSprite>();
                    moveSpriteF.SetDirection(directions[0]);

                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleG = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteG = obstacleG.GetComponent<MoveSprite>();
                    moveSpriteG.SetDirection(directions[1]);
                    break;
                case 5: //  X_X
                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleH = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteH = obstacleH.GetComponent<MoveSprite>();
                    moveSpriteH.SetDirection(directions[0]);

                    // Spawn the obstacle at the spawner's position
                    GameObject obstacleI = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

                    // Set the direction for the MoveSprite component
                    MoveSprite moveSpriteI = obstacleI.GetComponent<MoveSprite>();
                    moveSpriteI.SetDirection(directions[2]);
                    break;
                default:
                    break;
            }
        }
    }
}
