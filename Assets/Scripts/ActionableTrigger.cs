using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionableTrigger : MonoBehaviour {
	public Camera cam;

	private LineRenderer lr;

	void Start() {
		cam = Camera.main;
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		// Debug.DrawRay(cam.transform.position, forward, Color.green)

		var ray = new Ray(cam.transform.position, cam.transform.forward * 10);
		var hit = new RaycastHit();


		if(!Physics.Raycast (ray, out hit)) {
			// Debug.Log ("Did not hit anything");
			return;
		}

		Debug.DrawRay(cam.transform.position, hit.transform.position);

		var actionable = hit.transform.GetComponent<Actionable> ();
		if (actionable == null) {
			Debug.Log (hit.transform.name + " is not an Actionable");
			return;
		}

		actionable.DoAction ();
	}
}
