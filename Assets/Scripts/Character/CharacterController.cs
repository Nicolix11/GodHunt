using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController instance { get; private set; }
    
    private Rigidbody rb;
    private PlayerInput playerInput;

    private Vector3 moveDir;
    private bool isMoving;
    
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 8f;
    
    
    private void Awake()
    {
        instance = this; // singleton pattern instance assignment
        
        rb = GetComponent<Rigidbody>(); // assign the Rigidbody

        playerInput = new PlayerInput(); // create and assign the player Input variable
        playerInput.Player.Enable(); // enable the specific part of the Actionmap
    }

    private void Update()
    {
        RotateCharacter();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void RotateCharacter()
    {
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed); // rotate Character
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

    public bool IsCharacterMoving()
    {
        return isMoving;
    }
}
