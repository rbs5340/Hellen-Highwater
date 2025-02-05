using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public int playerId = 0; // The Rewired player ID (for a single player game, should always be 0)
    private Rewired.Player player; // The Rewired Player

    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpStrength = 10f;
    public float decelerationFactor = 0.9f;

    [Header("Attack Settings")]
    public GameObject WrenchPrefab;
    public Transform attackSpawnPoint;

    private bool isGrounded;
    private float direction;

    private void Start()
    {
        // Get Rewired Player
        player = ReInput.players.GetPlayer(playerId);

        // Get Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        if (!rb)
        {
            Debug.LogError("No Rigidbody2D found on Player!");
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleAttack();
    }

    private float lastDirection = 1f; // 1 for right, -1 for left

    private void HandleMovement()
    {
        direction = player.GetAxis("MoveHorizontal");

        if (Mathf.Abs(direction) > 0.1f) // small dead zone to prevent jitter
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
            lastDirection = Mathf.Sign(direction); // Update last facing direction
        }
        else
        {
            // Apply deceleration
            rb.velocity = new Vector2(rb.velocity.x * decelerationFactor, rb.velocity.y);
        }
    }

    private void HandleJumping()
    {
        if (player.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            isGrounded = false;
        }
    }

    private void HandleAttack()
    {
        if (player.GetButtonDown("Attack") && WrenchPrefab && attackSpawnPoint)
        {
            GameObject wrench = Instantiate(WrenchPrefab, attackSpawnPoint.position, Quaternion.identity);
            WrenchBehaviour wrenchScript = wrench.GetComponent<WrenchBehaviour>();

            if (wrenchScript)
            {
                wrenchScript.Initialize(lastDirection, transform);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
