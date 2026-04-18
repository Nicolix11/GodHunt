using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 moveDir;
    private bool isMoving;
    
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 20f;
    [Space] 
    [SerializeField] private GameObject baseAttackPrefab;
    [SerializeField] private GameObject baseAttackSpawnPoint;
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
        transform.LookAt(CharacterController.instance.transform.position);
    }

    private void PerformBaseAttack()
    {
        baseAttackTimer += Time.deltaTime; // increase the BaseAttackTimer

        if (baseAttackTimer >= baseAttackCooldown && !IsMoving()) // check for BaseAttackCooldown and Character is not moving
        {
            Instantiate(baseAttackPrefab, baseAttackSpawnPoint.transform.position, transform.rotation); // Angriff spawnen

            baseAttackTimer = 0f; // attack timer auf null zurücksetzen
        }
    }
    
    public bool IsMoving()
    {
        return isMoving; // return is Moving bool
    }
}
