using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwirlingScript : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotationSpeed*Time.deltaTime);
    }
}
