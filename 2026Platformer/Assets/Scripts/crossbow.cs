using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbow : MonoBehaviour
{
    public GameObject firepoint;
    public GameObject boltPrefab;
    public KeyCode fireButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(fireButton))
        {
            Instantiate(boltPrefab,firepoint.transform.position,firepoint.transform.rotation);
        }
    }
}
