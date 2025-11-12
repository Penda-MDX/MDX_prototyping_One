using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public string pickUpKey;
    public List<string> pickUpTags;
    public GameObject currentObject;
    public UIManager UIhandler;
    public ProgressTracker tracker;

    void Update()
    {
        //UIhandler.
    }

    public void showPickUpMessage()
    {
        UIhandler.ShowMessage("Press E to Pick Up");
    }

    public void hidePickUpMessage() 
    {
        UIhandler.HideMessage();
    }

    public void pickUpItem(string itemType)
    {
        switch (itemType)
        {
            case "YellowKey":
                tracker.keyCount++;
                currentObject.SetActive(false);
                UIhandler.HideMessage();
                break;
            default:
                Debug.Log("Picked Up " + itemType);
                break;
        }
    }
}
