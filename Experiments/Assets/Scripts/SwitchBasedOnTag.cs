using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBasedOnTag : MonoBehaviour
{
    public string triggerObjectTag;
    public bool reversable = true;
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == triggerObjectTag)
        {
            targetObject.SetActive(!targetObject.activeSelf);
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
