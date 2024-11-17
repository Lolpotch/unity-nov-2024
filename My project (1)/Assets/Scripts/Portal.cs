using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float rotationSpeed = 50f; // Degrees per second

    public float spawnDelay = 1f;    // Delay between spawns
    private float spawnTimer;
    private int spawnIndex = 0;
    public GameObject[] enemyPrefabs; // List of enemy prefabs

    void Start()
    {
        spawnIndex = 0;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnDelay)
        {
            SpawnRandomEnemy();
            spawnTimer = 0f;
        }
    }


    void FixedUpdate()
    {
        // Rotate around the Y-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Length > 0)
        {
            // Select a random enemy from the list
            //int randomIndex = Random.Range(0, enemyPrefabs.Length);

            // Instantiate the enemy at the spawn point
            Instantiate(enemyPrefabs[spawnIndex], transform.position, Quaternion.identity);
            
            spawnIndex++;

            if (spawnIndex >= enemyPrefabs.Length) {spawnIndex = 0;}
        }
        else
        {
            Debug.LogWarning("Enemy list is empty!");
        }
    }
}