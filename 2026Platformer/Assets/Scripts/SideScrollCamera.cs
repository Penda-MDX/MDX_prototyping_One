using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollCamera : MonoBehaviour
{
    [SerializeField] private GameObject thingToBeFollowed;
    [SerializeField] private float zAxisOffset = 10f;
    [SerializeField] private float xAxisOffset = -3f;
    [SerializeField] private float yAxisOffset = -3f;
    [SerializeField] private bool pointAt = true;
    private Vector3 v3_new_camera_position = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        //if a thing to be followed by the camera has not been defined in the editor then 
        if (thingToBeFollowed == null)
        {
            //Try getting all the objects with the Player Tag and pick the first one
            GameObject[] _List_Of_GameObjects = GameObject.FindGameObjectsWithTag("Player");
            thingToBeFollowed = _List_Of_GameObjects[0];
        }
        //if there is still no object what do we do?
    }

    // Update is called once per frame
    void Update()
    {
        // print(go_thingToBeFollowed.transform.position.x);
        v3_new_camera_position.x = thingToBeFollowed.transform.position.x - xAxisOffset;
        v3_new_camera_position.y = thingToBeFollowed.transform.position.y - yAxisOffset;
        v3_new_camera_position.z = thingToBeFollowed.transform.position.z - zAxisOffset;
        //
        if (v3_new_camera_position.x != transform.position.x || v3_new_camera_position.y != transform.position.y)
        {
            transform.position = v3_new_camera_position;
        }
        // should we rotate the camera to point at the thing we are following?
        if (pointAt)
        {
            transform.LookAt(thingToBeFollowed.transform);
        }
    }
}
