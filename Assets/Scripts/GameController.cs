using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class GameController : MonoBehaviour {
	//public GvrAudioSource crowdAudioSource;
	public AudioSource crowdAudioSource;
	//public GvrAudioSource aloneAudioSource;
	public AudioSource aloneAudioSource;

	public LampController ceilController;

	private float intoxicated = 1f; // start off at max intoxication

	public GameObject head;
	private float nextHead;

	private Camera cam;

	// Use this for initialization
	void Start () {
		nextHead = 0f;

		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (intoxicated > .5f) {
			float spawnRate = (1-intoxicated)*10;
			SpawnHeads (spawnRate);
		}
	}

	public float GetIntoxicationLevel() {
		return intoxicated;
	}

	public void ShiftToReality() {
		blurOnAction ();
		intoxicated -= 0.03f;
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

	// not sure if this needs to be public actually
	public void SpawnHeads(float rate) {
		if (Time.time > nextHead) {
			// spawn heads depending on party mood (more partymood = more heads) "intoxicated"
			Instantiate (head);
			nextHead += Time.time + rate;
		}
	}

	public void blurOnAction() {
		StartCoroutine (Blur());
	}

	public IEnumerator Blur() {
		var bo = cam.GetComponent<BlurOptimized> ();
		bo.enabled = true;

		for (int i = 0; i < 180; i++) {
			bo.blurSize = (Mathf.Sin (Time.time)*3 + 1.5f) * intoxicated;
			yield return 0;
		}

		bo.enabled = false;
		yield return null;
	}
}
