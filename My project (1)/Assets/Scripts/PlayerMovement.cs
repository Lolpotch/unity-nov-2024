using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boostSpeed = 10f;
    public float boostDuration = 2f;
    public float boostCooldown = 1f;  // Delay after boost ends

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isBoosting = false;
    private bool isOnCooldown = false;
    private float boostEndTime;
    private float cooldownEndTime;
    private Vector2 boostDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isBoosting)
        {
            // Get input only if not boosting or on cooldown
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
        }

        // Check if Space is pressed to initiate boost
        if (Input.GetKeyDown(KeyCode.Space) && movement != Vector2.zero && !isBoosting && !isOnCooldown)
        {
            StartBoost();
        }

        // Check if boost duration has ended
        if (isBoosting && Time.time >= boostEndTime)
        {
            EndBoost();
        }

        // Check if cooldown period has ended
        if (isOnCooldown && Time.time >= cooldownEndTime)
        {
            isOnCooldown = false;
        }
    }

    void FixedUpdate()
    {
        if (isBoosting)
        {
            // Use locked boost direction while boosting
            rb.velocity = boostDirection * boostSpeed * Time.fixedDeltaTime;
        }
        else
        {
            // Regular movement
            rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void StartBoost()
    {
        isBoosting = true;
        boostEndTime = Time.time + boostDuration;
        boostDirection = movement; // Lock the current movement direction
    }

    private void EndBoost()
    {
        isBoosting = false;
        isOnCooldown = true;
        cooldownEndTime = Time.time + boostCooldown;
    }
}
