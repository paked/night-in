﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	[SerializeField]
	public ItemActionable[] ghostItems;

	public GameController gameController;

	private int visibleItemCount = 0;

	void Start () {
		// Disable all glasses.
		foreach (var item in ghostItems) {
			item.gameObject.SetActive (false);
		}
	}

	public void SpawnItem() {
		gameController.ShiftToReality ();

		if (visibleItemCount > ghostItems.Length - 1) {
			return;
		}

		Debug.Log ("Spawning "+transform.gameObject.name);
		ghostItems [visibleItemCount].gameObject.SetActive (true);
		ghostItems [visibleItemCount].spawner = this;
		visibleItemCount++;
	}
}
