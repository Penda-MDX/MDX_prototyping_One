using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTracker : MonoBehaviour
{
    public Vector3 lastGoodCheckPoint;
    private bool resetPosition=false;

    public void FixedUpdate()
    {
        if (resetPosition)
        {
            transform.position = lastGoodCheckPoint;
            resetPosition = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastGoodCheckPoint = transform.position;
        }

        if (other.gameObject.tag == "Danger")
        {
            resetPosition = true;
        }

    }

}
