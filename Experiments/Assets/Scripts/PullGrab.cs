using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullGrab : MonoBehaviour
{

    //[SerializeField]
    public bool canPickUp = false;
    private GameObject movableObject;
    private GameObject carriedObject;

    private bool carryingObject = false;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            if (carryingObject)
            {
                carryingObject = false;
                carriedObject.transform.SetParent(null);
            }
            else
            {
                if (canPickUp)
                {
                    carryingObject = true;
                    movableObject.transform.SetParent(gameObject.transform);
                    carriedObject = movableObject;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            canPickUp = true;
            movableObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            canPickUp = false;
            movableObject = null;
        }
    }
}