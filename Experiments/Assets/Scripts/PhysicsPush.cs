using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPush : MonoBehaviour
{
    public float pushForce = 0.5f;

    private Rigidbody physicsRB;

    // Start is called before the first frame update
    void Start()
    {
        physicsRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pushVector = new Vector3();

        pushVector.x = pushForce * Input.GetAxis("Horizontal");
        pushVector.y = pushForce * Input.GetAxis("Vertical");

        physicsRB.AddForce(pushVector);
    }
}
