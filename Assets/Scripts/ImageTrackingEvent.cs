using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class ImageTrackingEvent : MonoBehaviour,ITrackableEventHandler 
{
    [SerializeField] private GameObject targetImage;
    private TrackableBehaviour trackableBehaviour;
    public static event Action StartObjects;
    public static event Action ChangeMovement;//nog aanroepen en verander
    public static event Action StopObjects;
    
    void Start() 
    {
        trackableBehaviour = targetImage.GetComponent<TrackableBehaviour>();
        if (trackableBehaviour) 
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus) 
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED|| newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            StartObjects();
        }else 
        {
            if (StopObjects != null) 
            {
                StopObjects();
            }
        }
    }
}
