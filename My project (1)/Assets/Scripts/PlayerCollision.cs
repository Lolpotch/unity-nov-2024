using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float delay = .2f;  // Delay in seconds
    private bool isProcessing = true;  // Flag to prevent multiple coroutine calls

    void Start()
    {
        playerMovement = transform.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the other object has the "Enemy" tag
        if (other.CompareTag("Enemy") && isProcessing && playerMovement.GetIsBoosting())
        {
            Debug.Log("Hit Enemy");
            StartCoroutine(DelayedAction());
        }
    }

    private IEnumerator DelayedAction()
    {
        isProcessing = false;  // Set flag to prevent multiple coroutine calls
        yield return new WaitForSeconds(delay);  // Wait for the specified delay
        isProcessing = true;  // Reset flag
    }

}
