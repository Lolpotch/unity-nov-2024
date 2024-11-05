using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public Transform attack;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = transform.GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        attack.gameObject.SetActive(playerMovement.GetIsBoosting());
    }
}
