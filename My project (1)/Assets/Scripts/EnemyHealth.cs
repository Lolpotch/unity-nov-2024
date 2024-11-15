using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHitCount = 5;
    public int hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }

    void Update()
    {
        if (hitCount >= maxHitCount)
        {
            GetComponent<EnemyParticle>().SpawnDestroyEffect();
            Destroy(gameObject);
        }
    }

    public void PlayerHit()
    {
        hitCount++;
    }
}
