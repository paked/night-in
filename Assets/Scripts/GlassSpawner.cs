using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSpawner : MonoBehaviour {
	[SerializeField]
	public GameObject[] ghostGlasses;
	public int glassesInABatch = 3;

	private int glassCount = 0;

	// Use this for initialization
	void Start () {
		// Disable all glasses.
		foreach (var glass in ghostGlasses) {
			glass.SetActive (false);
		}
	}

	public void SpawnGlass() {
		Debug.Log ("Spawning glass.");
		ghostGlasses [glassCount].SetActive (true);
		glassCount++;
	}
}
