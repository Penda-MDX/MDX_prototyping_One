using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointerRayCollision : MonoBehaviour
{
    public GameObject InGamePointer;
    public bool IsOn;
    public Vector3 Offset;

    //private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOn)
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(pos, out hit))
            {
                if (hit.collider.gameObject != InGamePointer)
                {
                    print(hit.point);
                    InGamePointer.transform.position = hit.point + Offset;
                }
            }
            
            //InGamePointer.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
    }
}
