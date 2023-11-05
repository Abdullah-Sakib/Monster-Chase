using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player; // Reference to the player's transform.
    private Vector3 tempPosition; // Temporary position for the camera.

    [SerializeField]
    private float minX, maxX; // Minimum and maximum X positions for the camera to follow.

    // Start is called before the first frame update
    void Start()
    {
        // Find the player's GameObject by tag and get its transform.
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called after all Update functions have been called.
    void LateUpdate()
    {
        if (!player) return; // If there's no player reference, exit early.

        tempPosition = transform.position;
        tempPosition.x = player.position.x; // Follow the player's X position.

        if (tempPosition.x < minX)
            tempPosition.x = minX; // Clamp camera's X position to the minimum.

        if (tempPosition.x > maxX)
            tempPosition.x = maxX; // Clamp camera's X position to the maximum.

        transform.position = tempPosition; // Update the camera's position.
    }
}
