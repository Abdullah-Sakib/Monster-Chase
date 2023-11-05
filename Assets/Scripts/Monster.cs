using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed; // Speed of the monster, which can be set in the inspector

    private Rigidbody2D myBody; // Reference to the monster's Rigidbody2D component

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the monster
    }

    private void FixedUpdate()
    {
        // Update the monster's velocity to move horizontally at the specified speed
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
