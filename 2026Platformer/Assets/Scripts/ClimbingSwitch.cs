using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClimbingSwitch : MonoBehaviour
{
    public bool isClimbing = false;
    public ImprovedCharacterController characterController;
    public float speed;

    private CharacterController _controller;
    private Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClimbing)
        {
            if (characterController.isActiveAndEnabled)
            {
                characterController.enabled = false;
            }

            Vector3 moveDirection = Vector3.zero;
            if (Keyboard.current.wKey.isPressed)
            {
                moveDirection.y = +1f;
            }
            if (Keyboard.current.sKey.isPressed)
            {
                moveDirection.y = -1f;
            }
            if (Keyboard.current.aKey.isPressed)
            {
                moveDirection.x = -1f;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                moveDirection.x = +1f;
            }
            _controller.Move(moveDirection * Time.deltaTime * speed);
        }
        else
        {
            if (!characterController.isActiveAndEnabled)
            {
                characterController.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = false;
        }
    }
}

