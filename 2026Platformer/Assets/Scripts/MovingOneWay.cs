using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOneWay : MonoBehaviour
{
    public Vector3 movingVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _temporaryNext = transform.position + movingVector * Time.deltaTime;
        transform.position = _temporaryNext;
    }
}
