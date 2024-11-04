using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;             // Speed of enemy movement
    public float moveDuration = 2f;          // Duration to move in a random direction
    public float stopDuration = 1f;          // Duration to stop before moving again

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MovementRoutine());
    }

    private IEnumerator MovementRoutine()
    {
        while (true)
        {
            // Move in a random direction
            yield return StartCoroutine(MoveRandomDirection());

            // Stop for a while
            yield return StartCoroutine(StopForDuration());
        }
    }

    private IEnumerator MoveRandomDirection()
    {
        isMoving = true;

        // Generate a random direction
        float angle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        float moveEndTime = Time.time + moveDuration;
        while (Time.time < moveEndTime)
        {
            rb.velocity = moveDirection * moveSpeed * Time.deltaTime    ;
            yield return null;  // Continue moving for the duration
        }

        // Stop the enemy
        rb.velocity = Vector2.zero;
        isMoving = false;
    }

    private IEnumerator StopForDuration()
    {
        // Wait for the stop duration
        yield return new WaitForSeconds(stopDuration);
    }
}
