using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GvrAudioSource crowdAudioSource;
	public GvrAudioSource aloneAudioSource;

	public LampController ceilController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShiftToReality() {
		Debug.Log (ceilController.gameObject.name);
		ceilController.DesaturateAll (0.1f);

		var cOld = crowdAudioSource.transform.position;
		cOld.x += 0.5f;

		crowdAudioSource.transform.position = cOld;

		if (aloneAudioSource.transform.position.x < -1.5 || aloneAudioSource.transform.position.x > 0.5) {
			var aOld = aloneAudioSource.transform.position;
			aOld.x += 0.3f;

			aloneAudioSource.transform.position = aOld;
		}
	}
}
