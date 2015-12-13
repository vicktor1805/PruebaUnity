using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

	private Camera camera;
	void Start () {

		camera = GameObject.FindGameObjectWithTag ("Main Camera").camera;
		var canvas = camera.GetComponent<Canvas> ();
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		canvas.worldCamera = camera;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
