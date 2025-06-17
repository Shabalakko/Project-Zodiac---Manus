using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;

    // Input Actions
    private PlayerInputActions playerInputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction dodgeBlockAction;
    private InputAction interactAction;
    private InputAction lockOnAction;
    private InputAction menuPauseAction;
    private InputAction changeTargetAction;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();

        // Assign actions
        moveAction = playerInputActions.Player.Move;
        jumpAction = playerInputActions.Player.Jump;
        attackAction = playerInputActions.Player.Attack;
        dodgeBlockAction = playerInputActions.Player.DodgeBlock;
        interactAction = playerInputActions.Player.Interact;
        lockOnAction = playerInputActions.Player.LockOn;
        menuPauseAction = playerInputActions.Player.MenuPause;
        changeTargetAction = playerInputActions.Player.ChangeTarget;

        // Enable actions
        moveAction.Enable();
        jumpAction.Enable();
        attackAction.Enable();
        dodgeBlockAction.Enable();
        interactAction.Enable();
        lockOnAction.Enable();
        menuPauseAction.Enable();
        changeTargetAction.Enable();

        // Subscribe to events for button presses
        jumpAction.performed += OnJumpPerformed;
        attackAction.performed += OnAttackPerformed;
        dodgeBlockAction.performed += OnDodgeBlockPerformed;
        interactAction.performed += OnInteractPerformed;
        lockOnAction.performed += OnLockOnPerformed;
        menuPauseAction.performed += OnMenuPausePerformed;
        changeTargetAction.performed += OnChangeTargetPerformed;

        // Note: Weapon change actions (Weapon1, Weapon2, etc.) and complex ability/item actions
        // would need to be defined in the Input Action Asset and handled here or in separate managers.
        // For simplicity, they are omitted in this basic PlayerController.
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputVector.x, 0f, inputVector.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("Jump!");
        }
    }

    void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Attack!");
        // Implement attack logic
    }

    void OnDodgeBlockPerformed(InputAction.CallbackContext context)
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        if (inputVector.magnitude > 0.1f)
        {
            Debug.Log("Dodge!");
            // Implement dodge logic
        }
        else
        {
            Debug.Log("Block!");
            // Implement block logic
        }
    }

    void OnInteractPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Interact!");
        // Implement interact logic
    }

    void OnLockOnPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Lock On!");
        // Implement lock-on logic
    }

    void OnMenuPausePerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Menu / Pause!");
        // Implement menu/pause logic
    }

    void OnChangeTargetPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Change Target!");
        // Implement change target logic
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnEnable()
    {
        playerInputActions.Enable();
    }

    void OnDisable()
    {
        playerInputActions.Disable();
    }
}


