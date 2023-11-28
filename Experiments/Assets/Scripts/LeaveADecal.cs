using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveADecal : MonoBehaviour
{
    public GameObject splat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            //Instantiate (splat, transform.position, Quaternion.Euler(collision.gameObject.transform.forward));
            Quaternion _surfaceNormal = Quaternion.LookRotation(collision.gameObject.transform.forward, collision.GetContact(0).normal);

            Instantiate(splat, transform.position, _surfaceNormal);

            //destroy gameObject, timer seconds
            Destroy(this.gameObject);
        }
    }
}
