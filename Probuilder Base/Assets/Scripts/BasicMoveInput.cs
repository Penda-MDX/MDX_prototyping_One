using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveInput : MonoBehaviour
{

    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.Translate(0, moveSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameObject.transform.Translate(0, -1*moveSpeed, 0);
        }
    }
}
