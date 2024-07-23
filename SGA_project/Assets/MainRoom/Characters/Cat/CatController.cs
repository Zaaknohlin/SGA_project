using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
   
        gameObject.transform.position = new Vector2 (transform.position.x + (h * moveSpeed), 
        transform.position.y + (v * moveSpeed));
    }

   
}
