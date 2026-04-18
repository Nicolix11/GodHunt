using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 moveDir;
    private bool isMoving;
    
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotSpeed = 20f;
    [Space] 
    [SerializeField] private GameObject baseAttackPrefab;
    [SerializeField] private Transform baseAttackSpawnPoint;
    [SerializeField] private float baseAttackCooldown = 1f;
    private float baseAttackTimer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        baseAttackTimer = 0f;
    }

    private void Update()
    {
        RotateEnemy();
        
        PerformBaseAttack();
    }

    private void RotateEnemy()
    {
        if (CharacterController.instance)
        {
            transform.LookAt(CharacterController.instance.GetCharacterPosition());
        }
    }

    private void PerformBaseAttack()
    {
        baseAttackTimer += Time.deltaTime; // increase the BaseAttackTimer

        if (baseAttackTimer >= baseAttackCooldown && !IsMoving()) // check for BaseAttackCooldown and Character is not moving
        {
            Instantiate(baseAttackPrefab, baseAttackSpawnPoint.position, transform.rotation); // Angriff spawnen

            baseAttackTimer = 0f; // attack timer auf null zurücksetzen
        }
    }
    
    public bool IsMoving()
    {
        return isMoving; // return is Moving bool
    }
}
