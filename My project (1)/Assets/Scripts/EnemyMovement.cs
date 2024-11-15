using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;             // Speed of enemy movement
    public float moveDuration = 2f;          // Duration to move in a random direction
    public float stopDuration = 1f;          // Duration to stop before moving again

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isMoving = false;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomMoveDirection();
    }

    void Update()
    {
        // Increment timer by deltaTime
        timer += Time.deltaTime;

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
                rb.velocity = moveDirection * moveSpeed * Time.deltaTime; // Move in current direction
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
