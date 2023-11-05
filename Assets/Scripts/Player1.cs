using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement and jump parameters
    [SerializeField]
    private float moveForce = 10f; // Force applied for horizontal movement
    [SerializeField]
    private float jumpForce = 11f; // Force applied for jumping

    [SerializeField]
    private float movementX; // Input for horizontal movement

    [SerializeField]
    private Rigidbody2D myBody; // Reference to the player's Rigidbody component
    private SpriteRenderer sr; // Reference to the player's SpriteRenderer component
    private Animator anim; // Reference to the player's Animator component
    private string WALK_ANIMATION = "Walk"; // Animation parameter name for walking
    private string GROUND_TAG = "Ground"; // Tag for identifying the ground
    private string ENEMY_TAG = "Enemy"; // Tag for identifying enemies

    private bool isGrounded = true; // A flag to check if the player is on the ground

    private void Awake()
    {
        // Get references to the required components
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be placed here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player input for movement and animations
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        // Handle player jumping in the FixedUpdate() method to ensure physics accuracy
        PlayerJump();
    }

    // Handle player movement using keyboard input
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); // Get horizontal input (-1, 0, or 1)

        // Move the player horizontally based on input
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    // Update player animations based on movement
    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true); // Play walk animation
            sr.flipX = false; // Flip the player sprite to face right
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true); // Play walk animation
            sr.flipX = true; // Flip the player sprite to face left
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false); // Stop walking animation
        }
    }

    // Handle player jumping
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false; // Player is not grounded after jumping
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Apply an upward force for jumping
        }
    }

    // Handle collisions with other objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true; // Player is grounded when colliding with objects tagged as "Ground"

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject); // Destroy the player if colliding with objects tagged as "Enemy"
    }

    // Handle trigger collisions (e.g., sensors) with other objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject); // Destroy the player if triggering with objects tagged as "Enemy"
    }
}
