using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform bulletPrefab; // Assign the bullet prefab in the inspector
    public Transform nozzle;
    private Transform player;
    

    public float shootDelay = 1f;  // Delay time in seconds
    public float bulletSpeed = 10f; // Speed of the bullet

    void Start()
    {
        StartCoroutine(ShootBulletWithDelay());
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        Vector3 direction = player.position - nozzle.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        nozzle.rotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator ShootBulletWithDelay()
    {
        while (true) // Continuously shoot bullets with a delay
        {        
            // Instantiate the bullet and set its direction
            Transform bullet = Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            // Make the bullet move in the direction transformA is facing
            rb.velocity = nozzle.right * bulletSpeed;

            yield return new WaitForSeconds(shootDelay);
        }
    }

}
