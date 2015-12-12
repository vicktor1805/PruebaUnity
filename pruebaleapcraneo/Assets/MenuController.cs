using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	string ResourcesFolder;
	GameObject Background;


	void Start () {

		ResourcesFolder = "Assets/Resources/";
		Background = GameObject.Find ("Background");
	}

	void InitComponents()
	{
		Background.GetComponent<Image> ().sprite = Resources.Load<Sprite> (ResourcesFolder + "fondo_1");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
