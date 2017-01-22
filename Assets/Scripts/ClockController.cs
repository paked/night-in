using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour {

	public GameController gameController;

	private Transform hourH;
	private Transform minH;
	private Transform secH;

	private float hourRate; // min per hour
	private float minRate; // sec per min
	private float secRate; // how fast is time moving


	// Use this for initialization
	void Start () {

		// start at 8PM (implied PM)
		hourH = transform.FindChild("hourHand");
		minH = transform.FindChild("minuteHand");
		secH = transform.FindChild("secondHand");

		hourRate = 6;
		minRate = 6;
		secRate = gameController.GetIntoxicationLevel(); // time flies when you're having fun
	}

	void Update() {
		hourH.rotation *= Quaternion.AngleAxis (secRate/(minRate*hourRate), Vector3.down);
		minH.rotation *= Quaternion.AngleAxis (secRate/minRate, Vector3.down);
		secH.rotation *= Quaternion.AngleAxis (secRate, Vector3.down);
	}
}
