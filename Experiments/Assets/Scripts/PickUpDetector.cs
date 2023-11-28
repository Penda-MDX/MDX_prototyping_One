using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetector : MonoBehaviour
{
    public bool canPickUp;
    
    public PickUpController controller;
    private string itemType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp)
        {
            controller.showPickUpMessage();
            if(Input.GetKeyUp(controller.pickUpKey))
            {
                controller.pickUpItem(itemType);
            }
        }
        else
        {
            controller.hidePickUpMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (string ptag in controller.pickUpTags)
        {
            if (other.gameObject.tag == ptag)
            {
                canPickUp = true;
                itemType = ptag;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach(string ptag in controller.pickUpTags)
        {
            if (other.gameObject.tag == ptag)
            {
                canPickUp = false;
                itemType = "";
            }
        }

    }
}
