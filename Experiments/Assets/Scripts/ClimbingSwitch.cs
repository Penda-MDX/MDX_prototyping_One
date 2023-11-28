using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
            _controller.Move(move * Time.deltaTime * speed);
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

