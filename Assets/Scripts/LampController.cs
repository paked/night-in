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
			if (i % 2 == 0) {
				l.color = color1;
				l.intensity = Mathf.Sin (Time.time * offset) + 1.5f;
			} else {
				l.color = color2;
				l.intensity = Mathf.Cos (Time.time * offset) + 1.5f;
			}
		}
	}

	public void DesaturateAll (float desaturation) {
		color1 = Desaturate (color1, desaturation);//Time.deltaTime);
		color2 = Desaturate (color2, desaturation);//Time.deltaTime);
		Debug.Log(color1+ " " + color2);
	}

	Color Desaturate(Color color, float desaturation) {
		float h;
		float s;
		float v;
		Color.RGBToHSV (color, out h, out s, out v);
		Debug.Log (""+desaturation +" "+ h + " "+s+ " "+v);

		return Color.HSVToRGB (h, Mathf.Max (0f, s - desaturation), v);
	}
}
