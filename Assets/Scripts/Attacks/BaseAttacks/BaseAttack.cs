using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    protected Rigidbody rb;

    protected const string PLAYER = "Player";
    protected const string ENEMY = "Enemy";
    protected const string ENVIROMENT = "Enviroment";
    
    [Header("Stats")]
    [SerializeField] protected float baseAttackDamage = 10f;
    [Space]
    [SerializeField] protected float movSpeed = 10f;


    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        MoveProjectile();
    }

    protected void MoveProjectile()
    {
        rb.MovePosition(rb.position + (transform.forward * (Time.deltaTime * movSpeed))); // move Character
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamageable hitObject = other.gameObject.GetComponent<IDamageable>();

        if (hitObject != null && other.CompareTag(PLAYER))
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
