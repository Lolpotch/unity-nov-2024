using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    public GameObject hitEffect;
    public float lifetime = .3f;
    public void SpawnHitEffect()
    {
        GameObject particle = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(particle, lifetime);
    }
}
