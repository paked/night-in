using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActionable : Actionable {
	public ItemSpawner spawner;
	public float cooldown;

	override public void DoAction() {
		spawner.SpawnItem ();
	}
}
