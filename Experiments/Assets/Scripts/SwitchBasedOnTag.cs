using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBasedOnTag : MonoBehaviour
{
    public string triggerObjectTag;
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == triggerObjectTag)
        {
            targetObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == triggerObjectTag)
        {
            targetObject.SetActive(false);
        }
    }
}
