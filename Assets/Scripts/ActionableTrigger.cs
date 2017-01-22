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
		var ray = new Ray(cam.transform.position, cam.transform.forward * 10);
		var hit = new RaycastHit();

		if(!Physics.Raycast (ray, out hit)) {
			// Debug.Log ("Did not hit anything");
			return;
		}

		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, hit.transform.position);

		Debug.DrawRay(cam.transform.position, hit.transform.position);

		var actionable = hit.transform.GetComponent<Actionable> ();
		if (actionable == null) {
			//Debug.Log (hit.transform.name + " is not an Actionable");
			return;
		}

		actionable.DoAction ();
	}
}
