using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionable : MonoBehaviour {
	public void DoAction() {
		Debug.Log (transform.name + " is doing an action!");

		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y + 1f * Time.deltaTime,
			transform.position.z
		);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
