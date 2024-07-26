using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float xPositionBound = 4f;
    public float speed = 10.0f;
    private PointSystem pointSystem;


    // Start is called before the first frame update
    void Start()
    {
        pointSystem = GameObject.Find("Game Manager").GetComponent<PointSystem>();
    }

    // Update is called once per frame
    void Update()
    {

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

    //Player colides with spawn objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemie"))
        {
            pointSystem.AddLive(-1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Powerup"))
        {

            pointSystem.AddPoint(1);
            Destroy(other.gameObject);
        }
    }
}