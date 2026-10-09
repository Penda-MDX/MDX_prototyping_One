using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicCharacterControl : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 60f;
    [SerializeField] private float gravity = 2f;
    [SerializeField] private float jumpForce = 0.8f;
    private Vector3 moveDirection = Vector3.zero;

    private bool jumpPressed;
    private CharacterController referenceToCharacterController;
    // Use this for initialization
    void Start()
    {
        referenceToCharacterController = GetComponent<CharacterController>();

    }
    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.spaceKey.isPressed)
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (referenceToCharacterController.isGrounded)
        {
            //moveDirection = Vector3.zero;

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

            moveDirection = moveDirection * movementSpeed * Time.deltaTime;

            if (jumpPressed)
            {
                moveDirection.y = jumpForce;
            }
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
