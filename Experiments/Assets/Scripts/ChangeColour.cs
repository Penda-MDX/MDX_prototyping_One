using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    [SerializeField] private Material startMaterial;
    [SerializeField] private Material endMaterial;
    [SerializeField] private bool hasChanged = false;

    private Renderer colourChangeRenderer;

    // Use this for initialization
    void Start()
    {
        colourChangeRenderer = gameObject.GetComponent<Renderer>();
        colourChangeRenderer.material = startMaterial;

    }

    void OnTriggerEnter(Collider other)
    {
        //if the colour has not already changed 
        if (!hasChanged)
        {
            //change it
            colourChangeRenderer.material = endMaterial;
            hasChanged = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if the colour has not already changed 
        if (hasChanged)
        {
            //change it
            colourChangeRenderer.material = startMaterial;
            hasChanged = false;
        }
    }
}
