using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // This method is called when a trigger collider enters the trigger area of the Collector.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Enemy" or "Player" tag and destroy it.
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
