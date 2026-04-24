using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    public static CharacterController instance { get; private set; }
    
    public event EventHandler OnAttack;

    public event EventHandler PauseGame;
    
    private Rigidbody rb;
    private PlayerInput playerInput;

    private Vector3 moveDir;
    private bool isMoving;
    
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 20f;
    [Space] 
    [SerializeField] private GameObject baseAttackPrefab;
    [SerializeField] private Transform baseAttackSpawnPoint;
    [SerializeField] private float baseAttackCooldown = 1f;
    private float baseAttackTimer;
    [Space]
    [SerializeField] private GameObject abilityAttackPrefab;
    [SerializeField] private Transform abilityAttackSpawnPoint;
    //[SerializeField] private float abilityAttackCooldown = 20f;
    private float abilityAttackTimer;
    
    
    private void Awake()
    {
        instance = this; // singleton pattern instance assignment
        
        rb = GetComponent<Rigidbody>(); // assign the Rigidbody

        playerInput = new PlayerInput(); // create and assign the player Input variable
        playerInput.Player.Enable(); // enable the specific part of the Actionmap
    }

    private void Start()
    {
        baseAttackTimer = 0f;
        
        playerInput.Player.Pause.performed += OnPausePerformed;
    }
    
    private void Update()
    {
        RotateCharacter();

        PerformBaseAttack();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void OnDestroy()
    {
        playerInput.Dispose(); // Destroy the Input when the Scene ends
    }

    private void PerformBaseAttack()
    {
        baseAttackTimer += Time.deltaTime; // increase the BaseAttackTimer

        if (CharacterStats.instance.GetIsAlive())
        {
            if (WaveManager.instance.IsWaveActive())
            {
                if (!IsMoving())
                {
                    if (baseAttackTimer >= baseAttackCooldown) // check for BaseAttackCooldown and Character is not moving
                    {
                        OnAttack?.Invoke(this, EventArgs.Empty); // Fire of OnAttack Event

                        Instantiate(baseAttackPrefab, baseAttackSpawnPoint.position, transform.rotation); // Angriff spawnen

                        baseAttackTimer = 0f; // attack timer auf null zurücksetzen
                    }
                }
            }
        }
    }
    
    private void RotateCharacter()
    {
        Vector3 lastMoveVector = new Vector3(0, 0, 0);

        if (moveDir != Vector3.zero)
            lastMoveVector = moveDir;
        
        if (WaveManager.instance.IsWaveActive())
        {
            transform.LookAt(WaveManager.instance.GetNearestEnemy().transform.position); // Fehler: Slerp einbauen
        }
        else
        {
            if(moveDir == Vector3.zero)
            {
                transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed); // rotate Character
            }
            else
            {
                transform.forward = lastMoveVector;
            }
        }
    }
    
    private void MoveCharacter()
    {
        rb.MovePosition(rb.position + GetInputVectorNormalized() * (moveSpeed * Time.deltaTime)); // move Character
    }

    private Vector3 GetInputVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>(); // Get the movement Input Vector
        Vector3 movVector = new Vector3(inputVector.x, 0, inputVector.y); // transform Vector2 to Vector3
        
        moveDir = movVector;

        isMoving = moveDir != Vector3.zero;
        
        return movVector.normalized; // return normalized Vector
    }

    public bool IsMoving()
    {
        return isMoving; // return is Moving bool
    }
    
    private void OnPausePerformed(InputAction.CallbackContext obj)
    {
        PauseGame?.Invoke(this, EventArgs.Empty);
    }
}
