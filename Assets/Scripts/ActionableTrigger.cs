using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class ActionableTrigger : MonoBehaviour {
	public Camera cam;

	private LineRenderer lr;

    private GazePoint gazePoint;
    private Transform lookAtTarget;

    void Start() {
		cam = Camera.main;
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        gazePoint = EyeTracking.GetGazePoint();

        if (EyeTracking.GetGazeTrackingStatus().IsTrackingEyeGaze)
        {
            Debug.Log("Hey! I'm loggging here.");
            var ray = Camera.main.ScreenPointToRay(new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, 0));
            var hit = new RaycastHit();

            if (!Physics.Raycast(ray, out hit))
            {
                Debug.Log ("Did not hit anything");

                return;
            }

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.transform.position);

            Debug.DrawRay(cam.transform.position, hit.transform.position);

            var actionable = hit.transform.GetComponent<Actionable>();
            if (actionable == null)
            {
                Debug.Log (hit.transform.name + " is not an Actionable");
                return;
            }

            actionable.DoAction();
        }
    }
}
