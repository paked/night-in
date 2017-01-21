using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionable : MonoBehaviour {
	virtual public void DoAction() {
		// Debug.Log (transform.name + " is doing an action!");

		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y + 1f * Time.deltaTime,
			transform.position.z
		);
	}
}
