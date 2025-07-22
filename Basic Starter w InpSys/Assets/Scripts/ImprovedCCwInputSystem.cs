using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//based on Character controller script from  https://github.com/valgoun/CharacterController and https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483

public class ImprovedCCwInputSystem : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public float FallMultiplier = 3.0f;
    public LayerMask Ground;
    public Vector3 Drag;
    public Transform _groundChecker;

    public InputActionReference movementDirection;
    public InputActionReference jumpButton;
    public InputActionReference dashButton;
    public InputActionReference interactButton;

    private CharacterController _controller;
    private Vector2 v2_movement = Vector2.zero;
    private bool jumpPressed;
    private bool dashPressed;
    private bool interactPressed;
    private Vector3 _velocity;
    private bool _isGrounded = true;
  


    void Start()
    {
        _controller = GetComponent<CharacterController>();
       
    }

    void Update()
    {


        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        v2_movement = movementDirection.action.ReadValue<Vector2>();

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(v2_movement.x, 0, v2_movement.y);
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
            transform.forward = move;

        if (jumpPressed && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            jumpPressed = false;
        }
        if (dashPressed)
        {
            Debug.Log("Dash");
            _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
            dashPressed=false;

        }
        if (interactPressed)
        {
            //pass through?
            interactPressed = false;    
        }


        //start to fall
        if (_velocity.y < 0)
        {
            _velocity.y += (Gravity * Time.deltaTime)*FallMultiplier;
        }else //going up
        {
            _velocity.y += Gravity * Time.deltaTime;
        }
        

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        jumpButton.action.started += Jump;
        dashButton.action.started += Dash;
        interactButton.action.started += Interact;
    }

    private void OnDisable()
    {
        jumpButton.action.started -= Jump;
    }

    public void Jump(InputAction.CallbackContext obj)
    {
        jumpPressed=true;
    }

    public void Dash(InputAction.CallbackContext obj)
    {
        dashPressed = true;
    }

    public void Interact(InputAction.CallbackContext obj)
    {
        interactPressed = true;
    }
}