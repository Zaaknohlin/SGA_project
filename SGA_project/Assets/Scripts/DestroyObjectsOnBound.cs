using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOnBound : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
