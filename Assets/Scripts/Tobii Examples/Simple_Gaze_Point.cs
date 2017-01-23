using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class Simple_Gaze_Point : MonoBehaviour {

    private GazePoint gazePoint;

    private Transform lookAtTarget;

	// Use this for initialization
	void Start ()
    {
        lookAtTarget = new GameObject().transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gazePoint = EyeTracking.GetGazePoint();

        if (EyeTracking.GetGazeTrackingStatus().IsTrackingEyeGaze)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, 0));

            lookAtTarget.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, 1.0f));

            transform.LookAt(lookAtTarget);

        }
    }
}
