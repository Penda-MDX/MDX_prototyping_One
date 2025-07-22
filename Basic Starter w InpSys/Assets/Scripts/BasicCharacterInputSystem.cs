using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicCharacterInputSystem : MonoBehaviour
{
    public float fl_MovementSpeed = 6f;
    public float fl_gravity = 2f;
    public float fl_JumpForce = 0.8f;

    public InputActionReference movementDirection;
    public InputActionReference jumpButton;


    private Vector3 V3_move_direction = Vector3.zero;
    private Vector2 v2_movement = Vector2.zero;

    private bool jumpPressed;
    private CharacterController cc_Reference_To_Character_Controller;
    // Use this for initialization
    void Start()
    {
        cc_Reference_To_Character_Controller = GetComponent<CharacterController>();

    }
    // Update is called once per frame
    void Update()
    {

        v2_movement = movementDirection.action.ReadValue<Vector2>();
        if (Input.GetButtonUp("Jump"))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (cc_Reference_To_Character_Controller.isGrounded)
        {
            //V3_move_direction.x = Input.GetAxis("Horizontal");
            V3_move_direction.x = v2_movement.x;
            V3_move_direction.y = 0;
            //V3_move_direction.z = Input.GetAxis("Vertical");
            V3_move_direction.z = v2_movement.y;
            V3_move_direction = V3_move_direction * fl_MovementSpeed * Time.deltaTime;

            if (jumpPressed)
            {
                V3_move_direction.y = fl_JumpForce;
            }
        }
        else
        {
            V3_move_direction.y -= fl_gravity * Time.deltaTime;
        }

    }
    void FixedUpdate()
    {
        cc_Reference_To_Character_Controller.Move(V3_move_direction);
    }
}
