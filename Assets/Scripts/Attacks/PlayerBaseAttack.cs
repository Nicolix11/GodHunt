using UnityEngine;

public class PlayerBaseAttack : MonoBehaviour
{
    private Rigidbody rb;
    
    [Header("Stats")]
    [SerializeField] private float baseAttackDamage = 10f;
    [SerializeField] private float movSpeed = 10f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        rb.MovePosition(rb.position + (transform.forward * (Time.deltaTime * movSpeed))); // move Character
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable hitObject = other.gameObject.GetComponent<IDamageable>();

        if (hitObject != null)
        {
            hitObject.ApplyDamage(baseAttackDamage);
        }
        
        Destroy(gameObject);
    }
}
