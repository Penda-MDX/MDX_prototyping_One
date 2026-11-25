using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HideAtRuntime : MonoBehaviour
{
    public List<GameObject> visibleObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject obj in visibleObjects)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
