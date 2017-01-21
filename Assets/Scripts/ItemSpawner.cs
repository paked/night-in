using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	[SerializeField]
	public GameObject[] ghostItems;

	public GameController gameController;

	private int visibleItemCount = 0;

	void Start () {
		// Disable all glasses.
		foreach (var item in ghostItems) {
			item.SetActive (false);
		}
	}

	public void SpawnItem() {
		gameController.ShiftToReality ();

		Debug.Log ("Spawning "+transform.gameObject.name);
		ghostItems [visibleItemCount].SetActive (true);
		visibleItemCount++;
	}
}
