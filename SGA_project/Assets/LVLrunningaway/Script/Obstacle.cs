using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Prompt :
 * Write a unity script that will move a sprite in a given direction.
 * At the beginning, a direction is chosen from a set of vector containing three directions:
 * down, down_left, down_right.
 * in the frame update, move the sprite in the chosen direction at a given speed.
 * the speed increase as the time pass (gravity effect).
 * Additionally, destroy the obstacle when it's outside the camera view.
 */
public class MoveSprite : MonoBehaviour
{
    public float initialSpeed = 1.0f;
    public float gravityAcceleration = 9.8f;
    private Vector3 direction;
    private float speed;
    private Camera mainCamera;

    // List of possible directions
    private List<Vector3> directions = new List<Vector3>
    {
        Vector3.down,
        new Vector3(-1, -1, 0).normalized, // Down-Left
        new Vector3(1, -1, 0).normalized   // Down-Right
    };

    void Start()
    {
        // Choose a random direction from the list
        int randomIndex = Random.Range(0, directions.Count);
        direction = directions[randomIndex];

        // Initialize the speed
        speed = initialSpeed;

        // Get the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Increase speed over time to simulate gravity
        speed += gravityAcceleration * Time.deltaTime;

        // Move the sprite in the chosen direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the sprite is outside the camera view and destroy it if so
        if (!IsInView())
        {
            Destroy(gameObject);
        }
    }

    // Function to check if the sprite is within the camera view
    bool IsInView()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}