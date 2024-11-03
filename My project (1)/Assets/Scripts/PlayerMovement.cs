using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MyInput();
    }

    void FixedUpdate()
    {
        Move();
        
    }

    void MyInput()
    {
        // Get raw input for WASD keys
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
    }

    void Move()
    {
        // Apply velocity based on movement input
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }
}
