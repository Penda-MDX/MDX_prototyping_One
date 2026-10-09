using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
//based on Character controller script from  https://github.com/valgoun/CharacterController and https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483

public class ImprovedCharacterController : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpHeight = 2f;
    [SerializeField] private float Gravity = -9.81f;
    [SerializeField] private float GroundDistance = 0.2f;
    [SerializeField] private float DashDistance = 5f;
    [SerializeField] private float FallMultiplier = 3.0f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private Vector3 Drag;
    [SerializeField] private Transform groundChecker;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded = true;
    private bool isJumping = false;
  
    void Start()
    {
        controller = GetComponent<CharacterController>();
       
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
            isJumping = false;
        }
            

        Vector3 moveDirection = Vector3.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            moveDirection.z = +1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            moveDirection.z = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            moveDirection.x = -1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveDirection.x = +1f;
        }
        //controller.Move(moveDirection * Time.deltaTime * Speed);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
        velocity += moveDirection * Time.deltaTime * Speed;
        //controller.Move(moveDirection * Time.deltaTime * Speed);

        if (!isJumping && Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            isJumping = true;
        }

        //start to fall
        if (velocity.y < 0)
        {
            velocity.y += (Gravity * Time.deltaTime)*FallMultiplier;
        }else //going up
        {
            velocity.y += Gravity * Time.deltaTime;
        }
        

        velocity.x /= 1 + Drag.x * Time.deltaTime;
        velocity.y /= 1 + Drag.y * Time.deltaTime;
        velocity.z /= 1 + Drag.z * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}