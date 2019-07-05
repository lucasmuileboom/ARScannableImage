using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadeOject : MonoBehaviour
{
    [SerializeField]private int rotationSpeed;
    private bool rotating = false;

    private void Start() 
    {
        ImageTrackingEvent.StartObjects += StartRotating;
        ImageTrackingEvent.ChangeMovement += ChangeRotationDirection;
        ImageTrackingEvent.StopObjects += StopRotating;
    }
    private void Update() 
    {
        if (rotating) 
        {
            Rotate();
        }
    }
    private void StartRotating() 
    {
        rotating = true;
    }
    private void ChangeRotationDirection() 
    {
        rotationSpeed *= -1;
    }
    private void StopRotating() 
    {
        rotating = false;
    }
    private void Rotate() 
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + rotationSpeed, 0);
    }
}
