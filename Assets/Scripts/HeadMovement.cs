using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

	private float theta;
	private float rad;

	private float speed;

	// Use this for initialization
	void Start () {
		// random angle
		theta = Random.Range(0f, 359f);
		rad = Random.Range (1f, 2f);
		speed = Random.Range (.5f, 1f);
		transform.position = new Vector3 (
			Mathf.Cos (theta) * rad,
			Mathf.Sin (theta) * rad,
			4f
		);
		Debug.Log ("starting at " +transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			Mathf.Cos (theta) * rad,
			Mathf.Sin (theta) * rad,
			transform.position.z + -speed * Time.deltaTime
		);

		theta += Time.deltaTime;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Back Wall")) {
			Destroy (transform.gameObject);
		}
	}
}
