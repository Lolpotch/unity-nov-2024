using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject destroyEffect;
    public float lifetimeHit = .3f;
    public float lifetimeDestroy = 1f;

    public void SpawnHitEffect()
    {
        GameObject particle = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(particle, lifetimeHit);
    }

    public void SpawnDestroyEffect()
    {
        GameObject particle = Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(particle, lifetimeDestroy);
    }
}
