using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassActionable : Actionable {
	public GlassSpawner gs;
	public float cooldown = 0.5F;

	private float next = 0;

	override public void DoAction() {
		Debug.Log ("Actionable is triggered");
		Debug.Log (Time.time);
		Debug.Log (next);
		if (Time.time > next) {
			Debug.Log ("Doing a thing!");
			gs.SpawnGlass ();

			next = Time.time + cooldown;
		}
	}
}
