using UnityEngine;
using UnityEngine.InputSystem;

public class BasicControllerwEvents : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float gravity = 2f;
    [SerializeField] private float jumpForce = 0.8f;

    public InputActionReference move;
    public InputActionReference jump;

    private Vector3 moveDirection = Vector3.zero;

    private bool jumpPressed;
    private CharacterController referenceToCharacterController;
    // Use this for initialization
    void Start()
    {
        referenceToCharacterController = GetComponent<CharacterController>();

    }

    // Start is called before the first frame update
    void OnEnable()
    {
        jump.action.started += OnJump;
    }
    void OnDisable()
    {
        jump.action.started -= OnJump;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        moveDirection.y = jumpForce;
    }

    // Update is called once per frame
    void Update()
    {

        if (referenceToCharacterController.isGrounded)
        {
            moveDirection.z = move.action.ReadValue<Vector2>().y;
            moveDirection.x = move.action.ReadValue<Vector2>().x;

            moveDirection = moveDirection * movementSpeed * Time.deltaTime;

        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        referenceToCharacterController.Move(moveDirection);
        if (referenceToCharacterController.isGrounded)
        {
            moveDirection = Vector3.zero;

        }
    }

}
