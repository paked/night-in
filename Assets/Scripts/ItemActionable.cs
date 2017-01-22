using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActionable : Actionable {
	public ItemSpawner spawner;
	public float cooldown;

	private float next = 0;

	override public void DoAction() {
		
//		Debug.Log ("Actionable is triggered, time.time is "
//			+Time.time+" nextAction occurs at "+next);
		if (Time.time > next) {
//			Debug.Log ("Spawning a thing!");

			spawner.SpawnItem ();
			next = Time.time + cooldown;
		}
	}
}
