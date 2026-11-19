using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwirlingScript : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,rotationSpeed*Time.deltaTime, 0);
    }
}
