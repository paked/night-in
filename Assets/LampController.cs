using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour {

	public Color color1;
	public Color color2;
	public float offset;

	private List<Light> lights;

	// Use this for initialization
	void Start () {
		lights = new List<Light>();

		foreach (Transform lamp in transform) {
			GameObject spotlight = lamp.GetChild (0).gameObject;
			Light lightComp = spotlight.GetComponent<Light> ();
			lights.Add (lightComp);
		}
	}

	void Update () {
		// change colors of every lamp
		for (int i = 0; i < lights.Count; i++) {
			Light l = lights[i];
			Color lColor = (i%3 == 0) ? color1 : color2;

			ChangeLightSettings (l, lColor, Time.time * offset);
		}
	}

	void ChangeLightSettings(Light light, Color color, float amp) {
		light.color = color;
		light.intensity = Mathf.Cos(amp) + 0.5f; // at least .5 intensity
	}
}
