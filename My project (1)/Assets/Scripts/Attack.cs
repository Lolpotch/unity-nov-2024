using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float delay = .1f;  // Delay in seconds
    private bool isProcessing = true;  // Flag to prevent multiple coroutine calls

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void OnEnable()
    {
        isProcessing = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the other object has the "Enemy" tag
        if (other.CompareTag("Enemy") && isProcessing) //&& playerMovement.GetIsBoosting())
        {
            Debug.Log("Hit Enemy");
            other.GetComponent<EnemyParticle>().SpawnHitEffect();
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
