using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;             // Speed of enemy movement
    public float moveDuration = 2f;         // Duration to move in a random direction
    public float stopDuration = 1f;         // Duration to stop before moving again
    public bool isFollowing = false;        // If true, follow the player instead of moving randomly

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isMoving = false;
    private float timer = 0f;
    private Transform playerTransform;      // Reference to the player's transform

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Find the player object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        if (!isFollowing)
        {
            SetRandomMoveDirection();
        }
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (isFollowing && playerTransform != null)
        {
            FollowPlayer();
        }
        else
        {
            RandomMovement();
        }
    }

    private void FollowPlayer()
    {
        // Calculate direction towards the player
        Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
        rb.velocity = directionToPlayer * moveSpeed * Time.fixedDeltaTime;
    }

    private void RandomMovement()
    {
        if (isMoving)
        {
            // Check if move duration has elapsed
            if (timer >= moveDuration)
            {
                isMoving = false;
                timer = 0f;
                rb.velocity = Vector2.zero; // Stop movement
            }
            else
            {
                rb.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime; // Move in current direction
            }
        }
        else
        {
            // Check if stop duration has elapsed
            if (timer >= stopDuration)
            {
                isMoving = true;
                timer = 0f;
                SetRandomMoveDirection(); // Set a new move direction
            }
        }
    }

    private void SetRandomMoveDirection()
    {
        // Generate a random direction
        float angle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
