using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3[] wayPoints;
    private Vector3 startPosition;
    private float movementDistance;
    private bool moving = false;
    private int tagetIndex = 0;

    private void Start() 
    {
        ImageTrackingEvent.StartObjects += StartMoveing;
        ImageTrackingEvent.StopObjects += StopMoving;
        startPosition = transform.localPosition;
    }
    private void Update() 
    {
        if (moving) 
        {
            FollowWaypoints();
        }
    }
    private void FollowWaypoints() 
    {
        Vector3 currentTarget = wayPoints[tagetIndex];

        if (transform.localPosition == currentTarget) 
        {
            tagetIndex++;
            if (tagetIndex >= wayPoints.Length) 
            {
                tagetIndex = 0;
            }
            currentTarget = wayPoints[tagetIndex];
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentTarget, movementSpeed);
    }
    private void StartMoveing() 
    {
        moving = true;
    }
    private void StopMoving() 
    {
        moving = false;
        ResetObject();
    }
    private void ResetObject()
    {
        transform.localPosition = startPosition;
        tagetIndex = 0;
    }
}
