using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics_Character : MonoBehaviour {

    public float fl_MovementSpeed = 6f;
    public float fl_JumpForce = 8.0f;
    public FootScript footScript;
    public float maxVelocity = 5f;
    public float GroundDistance = 0.6f;
    public LayerMask Ground;
    public float groundDrag = 2;
    public float movingDrag = 0;
    public float airDrag = 0.5f;
    private Vector3 V3_move_direction = Vector3.zero;
    public Rigidbody characterRB;

    public Transform _groundChecker;
    private bool _isGrounded = true;

    // Use this for initialization
    void Start () {
        characterRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        if (_isGrounded)
        {
            if (characterRB.velocity.magnitude < maxVelocity)
            {
                V3_move_direction.x = Input.GetAxis("Horizontal");
                V3_move_direction.y = 0;
                V3_move_direction.z = Input.GetAxis("Vertical");
                V3_move_direction = V3_move_direction * fl_MovementSpeed * Time.deltaTime;
                if (V3_move_direction!=Vector3.zero)
                {
                     characterRB.AddRelativeForce(V3_move_direction);
                    //characterRB.AddForce(V3_move_direction, ForceMode.Acceleration);
                    characterRB.drag = movingDrag;
                }
                else
                {
                    characterRB.drag = groundDrag;
                }
                
            }
           else
           {
                characterRB.drag = groundDrag;
           }

            if (Input.GetButton("Jump"))
            {
                characterRB.AddRelativeForce(transform.up * fl_JumpForce);
                characterRB.drag = airDrag;
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
