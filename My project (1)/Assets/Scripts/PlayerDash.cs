using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public GameObject ghostPrefab;     // Assign GhostTrailPrefab here
    public float dashDuration = 0.3f;  // Duration of the dash
    public float ghostSpawnInterval = 0.05f;  // Time between ghost sprites
    public float fadeOutTime = 0.5f;   // How long the ghost sprite fades
    public float lifetime = 0.2f;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
    }

    public void StartCoroutineDash()
    {
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        // Start dash movement (implement as desired)
        // Example: increase player speed or move to dash direction
        
        float dashTime = 0f;

        // Spawn ghosts over the dash duration
        while (dashTime < dashDuration)
        {
            SpawnGhost();
            yield return new WaitForSeconds(ghostSpawnInterval);
            dashTime += ghostSpawnInterval;
        }
    }

    private void SpawnGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);
        //SpriteRenderer ghostRenderer = ghost.GetComponent<SpriteRenderer>();

        // Set ghost's sprite and color to current player sprite
        // ghostRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        // ghostRenderer.color = new Color(1, 1, 1, 0.5f);  // Example: semi-transparent

        // Start the fade-out coroutine on the ghost object
        Destroy(ghost, lifetime);
    }

    // private IEnumerator FadeOutGhost(SpriteRenderer ghostRenderer)
    // {
    //     float fadeTime = 0f;
    //     Color startColor = ghostRenderer.color;

    //     while (fadeTime < fadeOutTime)
    //     {
    //         fadeTime += Time.deltaTime;
    //         float alpha = Mathf.Lerp(0.5f, 0f, fadeTime / fadeOutTime);
    //         ghostRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
    //         yield return null;
    //     }

    //     Destroy(ghostRenderer.gameObject);  // Remove the ghost object after fade out
    // }
}
