using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Physics_Character : MonoBehaviour {

    [SerializeField] private bool useOldInput = false;
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float maxVelocity = 5f;
    [SerializeField] private float groundDistance = 0.6f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDrag = 2;
    [SerializeField] private float movingDrag = 0;
    [SerializeField] private float airDrag = 0.5f;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private Rigidbody characterRB;

    private Vector3 moveDirection = Vector3.zero;

    private bool isGrounded = true;

    // Use this for initialization
    void Start () {
        characterRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask, QueryTriggerInteraction.Ignore);

        if (isGrounded)
        {
            if (characterRB.linearVelocity.magnitude < maxVelocity)
            {
                if (useOldInput)
                {
                    moveDirection.x = Input.GetAxis("Horizontal");
                    moveDirection.y = 0;
                    moveDirection.z = Input.GetAxis("Vertical");
                }
                else
                {
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
                }

                moveDirection = moveDirection * movementSpeed * Time.deltaTime;
                if (moveDirection != Vector3.zero)
                {
                     characterRB.AddRelativeForce(moveDirection);
                    //characterRB.AddForce(moveDirection, ForceMode.Acceleration);
                    characterRB.linearDamping = movingDrag;
                }
                else
                {
                    characterRB.linearDamping = groundDrag;
                }
                
            }
           else
           {
                characterRB.linearDamping = groundDrag;
           }

            if (Input.GetButton("Jump"))
            {
                characterRB.AddRelativeForce(transform.up * jumpForce);
                characterRB.linearDamping = airDrag;
            }
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpeedUp")
        {
            Destroy(other.gameObject);
        }
    }

}
