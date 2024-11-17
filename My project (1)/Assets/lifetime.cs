using UnityEngine;

public class lifetime : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);        
    }
}
