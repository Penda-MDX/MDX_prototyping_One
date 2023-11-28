using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : MonoBehaviour
{
    public GameObject triggerObject;
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            targetObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            targetObject.SetActive(false);
        }
    }
}
