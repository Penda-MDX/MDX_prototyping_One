using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public float timeToDrop = 2.0f;
    public Rigidbody aRigidbody;
    private float timeToFall;
    private bool go;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go &&  Time.time >= timeToFall)
        {
            aRigidbody.isKinematic = false;
            aRigidbody.useGravity = true;
            go = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            go = true;
            timeToFall = Time.time + timeToDrop;
        }

        if(other.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
        }

    }
}
