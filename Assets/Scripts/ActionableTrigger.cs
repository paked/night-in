using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionableTrigger : MonoBehaviour {
	public Camera cam;

	void Start() {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		var ray = new Ray(cam.transform.position, cam.transform.forward);
		var hit = new RaycastHit();

		if(!Physics.Raycast (ray, out hit)) {
			Debug.Log ("Did not hit anything");
			return;
		}

		var actionable = hit.transform.GetComponent<Actionable> ();
		if (actionable == null) {
			Debug.Log ("Object is not an Actionable");
			return;
		}

		actionable.DoAction ();
//
//		Debug.Log (hit.transform.name + " was hit!");
//		var newPos = new Vector3 (
//			hit.transform.position.x,
//			hit.transform.position.y + 2f * Time.deltaTime,
//			hit.transform.position.z
//		);
//
//		hit.transform.position = newPos;
	}
}
