using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Prompt : write a unity csharp script that will move left and right the player if the left/right arrow are pressed or if the A or D key are pressed or if the display is touched on the left/right of the current position of the sprite.  here is what I have aldready : using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 * 
 */
public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {
        // Ensure the player has a Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0; // Ensure the player is not affected by gravity
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float move = 0f;

        // Keyboard input
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = 1f;
        }

        // Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchPosition.x < transform.position.x)
                {
                    move = -1f;
                }
                else if (touchPosition.x > transform.position.x)
                {
                    move = 1f;
                }
            }
        }

        // Apply movement
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }

    // Handle collision with obstacles
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Implement your game over logic here
        Debug.Log("Game Over!");
        // For example, you can stop the game
        Time.timeScale = 0;
        // Or you can load a game over scene
        // SceneManager.LoadScene("GameOver");
    }
}
