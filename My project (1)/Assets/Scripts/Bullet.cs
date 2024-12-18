using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject playerHitEffect;
    public float lifetime = 3.0f; // Lifetime of the bullet in seconds

    void Start()
    {
        // Destroy the bullet after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerMovement>().GetIsBoosting())
            {
                Debug.Log("Hit player");
                GameObject particle = Instantiate(playerHitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject); // Destroy the bullet    
            }
            
        }
    }
}
