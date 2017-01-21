using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	[SerializeField]
	public GameObject[] ghostItems;
	//public int itemsInBatch;

	private int visibleItemCount = 0;

	void Start () {
		// Disable all glasses.
		foreach (var item in ghostItems) {
			item.SetActive (false);
		}
	}

	public void SpawnItem() {
		Debug.Log ("Spawning "+transform.gameObject.name);
		ghostItems [visibleItemCount].SetActive (true);
		visibleItemCount++;
	}
}
