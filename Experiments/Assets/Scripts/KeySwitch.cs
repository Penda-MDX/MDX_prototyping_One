using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySwitch : MonoBehaviour
{
    public string triggerObjectTag;
    public bool reversable = true;
    public GameObject targetObject;
    public ProgressTracker progressTracker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == triggerObjectTag)
        {
            if (progressTracker.keyCount > 0)
            {
                progressTracker.keyCount--;
                targetObject.SetActive(!targetObject.activeSelf);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (reversable)
        {
            if (other.gameObject.tag == triggerObjectTag)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }

    }
}
