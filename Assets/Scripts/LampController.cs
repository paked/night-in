using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour {
	public Color color1;
	public Color color2;

    public float amp;
    public float flashing;

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
				l.intensity = amp * Mathf.Sin (Time.time * flashing) + 1.5f;
			} else {
				l.color = color2;
				l.intensity = amp * Mathf.Sin (Mathf.PI/2-Time.time * flashing) + 1.5f;
			}
		}
	}

	public void DesaturateAll (float desaturation) {
		color1 = Desaturate (color1, desaturation);
		color2 = Desaturate (color2, desaturation);

        amp = Mathf.Exp(-Time.time*desaturation);
	}

	Color Desaturate(Color color, float desaturation) {
		float h;
		float s;
		float v;
		Color.RGBToHSV (color, out h, out s, out v);

		return Color.HSVToRGB (h, Mathf.Max (0f, s - desaturation), v);
	}
}
