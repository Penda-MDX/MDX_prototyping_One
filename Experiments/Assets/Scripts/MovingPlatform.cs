using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> wayPoints;

    [SerializeField] private int startingWayPoint = 0;
    [SerializeField] private float movementSpeed = 3;

    [SerializeField] private bool pauseAtEnd;
    [SerializeField] private float pauseTime = 1.5f;

    private int currentWayPoint;
    private float startTime;
    private float journeyLength;
    private float pauseUntil;
    private bool paused;
    private Transform startMarker;
    private Transform endMarker;

    // Use this for initialization
    void Start()
    {
        currentWayPoint = startingWayPoint;
        CalculateJourney();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            float distanceCovered = (Time.time-startTime) * movementSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position,fractionOfJourney);
        }
        else
        {
            if (pauseUntil < Time.time)
            {
                paused = false;
            }
        }

        //move towards the waypoint
        
        //when near the waypoint change to the next waypoint
        if (Vector3.Distance(transform.position, endMarker.position) < movementSpeed / 4)
        {
            if (pauseAtEnd)
            {
                paused = true;
                pauseUntil = Time.time + pauseTime;
            }
            currentWayPoint++;
            if (currentWayPoint > wayPoints.Count - 1)
            {
                currentWayPoint = startingWayPoint;
            }
            CalculateJourney();
        }
    }

    private void CalculateJourney()
    {
        startTime = Time.time;
        if (currentWayPoint == wayPoints.Count - 1)
        {
            startMarker = wayPoints[currentWayPoint].transform;
            endMarker = wayPoints[0].transform;
        }
        else
        {
            startMarker = wayPoints[currentWayPoint].transform;
            endMarker = wayPoints[currentWayPoint + 1].transform;
        }
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
