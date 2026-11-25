using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InertiaModelCharacter : MonoBehaviour
{
    [Header("Hovering")]
    public float hoveringHeight = 1.5f;
    public float maxStepHeight = 0.4f;

    [Header("Movement")]
    public float movementSpeed = 8f;
    public float acceleration = 12f;
    public float rotationSpeed = 6f;

    [Header("Jump")]
    public float jumpMaxSpeed = 6f;

    [Header("Grounding")]
    public float maxSlopeAngle = 50f;

    public Transform cameraTransform;

    public InputActionReference move;
    public InputActionReference jump;

    private Rigidbody rb;

    private Vector3 moveDirection;
    private Vector3 lastDirection;
    private Vector3 horizontalVelocity;

    public bool isGrounded = false;
    public LayerMask GroundMask;
    private bool isJumping = false;
    private Vector3 floorNormal = Vector3.up;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 input = move.action.ReadValue<Vector2>();

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 inputDir = forward * input.y + right * input.x;

        if (inputDir.sqrMagnitude > 0.01f)
        {
            moveDirection = inputDir;
            lastDirection = inputDir.normalized;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        HandleGrounding();
        HandleMovement();
    }

    // ---------------------------------------------------------
    // GROUNDING + HOVERING
    // ---------------------------------------------------------
    void HandleGrounding()
    {
        float rayLength = hoveringHeight + maxStepHeight;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayLength,GroundMask))
        {
            //
            float angle = Vector3.Angle(hit.normal, Vector3.up);

            //
            if (angle > maxSlopeAngle)
            {
                isGrounded = false;
                return;
            }

            float distance = hit.distance;

            // 
            if (isJumping)
            {
                if (distance <= hoveringHeight && rb.linearVelocity.y <= 0)
                {
                    isJumping = false;
                }
                else
                {
                    return;
                }
            }

            isGrounded = true;

            floorNormal = hit.normal;

            // 
            if (isGrounded)
            {
                float hoverVelocity = (hoveringHeight - distance) / Time.fixedDeltaTime;

                Vector3 linearVelocity = rb.linearVelocity;
                linearVelocity.y = hoverVelocity;
                rb.linearVelocity = linearVelocity;
            }
        }
        else
        {
            // 
            isGrounded = false;
        }
    }


    void HandleMovement()
    {
        if (!isGrounded) return;

        // Target velocity 
        Vector3 targetVelocity = moveDirection * movementSpeed;

        horizontalVelocity = Vector3.MoveTowards(
            horizontalVelocity,
            targetVelocity,
            acceleration * Time.fixedDeltaTime
        );

        // 
        Vector3 projectedVelocity = Vector3.ProjectOnPlane(horizontalVelocity, floorNormal);

        if (projectedVelocity.sqrMagnitude > 0.001f)
        {
            projectedVelocity = projectedVelocity.normalized * horizontalVelocity.magnitude;
        }

        rb.linearVelocity = new Vector3(
            projectedVelocity.x,
            rb.linearVelocity.y + projectedVelocity.y,
            projectedVelocity.z);

        if (lastDirection.sqrMagnitude < 0.01f)
            return;

        Quaternion targetRot = Quaternion.LookRotation(lastDirection);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRot,
            rotationSpeed * Time.fixedDeltaTime
        );
    }

    // ---------------------------------------------------------
    // JUMP
    // ---------------------------------------------------------
    void OnEnable()
    {
        jump.action.performed += OnJump;
    }

    void OnDisable()
    {
        jump.action.performed -= OnJump;
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        if (!isGrounded)
            return;

        isJumping = true;
        isGrounded = false;

        Vector3 vel = rb.linearVelocity;
        vel.y = jumpMaxSpeed;
        rb.linearVelocity = vel;
    }
}

