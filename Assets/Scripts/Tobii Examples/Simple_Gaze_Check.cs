using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Gaze_Check : MonoBehaviour {

    public Tobii.EyeTracking.GazeAware gaze;
    public Renderer render;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gaze.HasGazeFocus)
        {
            render.material.color = Color.red;
        }
        else
        {
            render.material.color = Color.blue;
        }
		
	}
}
