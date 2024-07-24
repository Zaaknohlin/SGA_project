using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float xPositionBound = 4f;
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TODO: If space is pressed enable movement of cats paw

        if (transform.position.x<-xPositionBound) 
        {
        transform.position = new Vector2(-xPositionBound,transform.position.y);
        }
        else if (transform.position.x > xPositionBound)
        {
            transform.position = new Vector2(xPositionBound, transform.position.y);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}