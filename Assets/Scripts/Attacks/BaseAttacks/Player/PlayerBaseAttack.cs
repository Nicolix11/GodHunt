using UnityEngine;

public class PlayerBaseAttack : MonoBehaviour
{
    private Rigidbody rb;

    private const string ENEMY = "Enemy";
    private const string ENVIROMENT = "Enviroment";
    
    [Header("Stats")]
    [SerializeField] private float baseAttackDamage = 10f;
    [Space]
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

        if (hitObject != null && other.CompareTag(ENEMY))
        {
            hitObject.ApplyDamage(baseAttackDamage);
            Destroy(gameObject);
        }
        else if (other.CompareTag(ENVIROMENT))
        {
            Destroy(gameObject);
        }
    }
}
