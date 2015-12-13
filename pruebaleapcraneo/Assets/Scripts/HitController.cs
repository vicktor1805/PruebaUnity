using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Classes;

public class HitController : MonoBehaviour {

	// Use this for initialization
    private Text textDescripcion;
    private PersistenceHelper ph;
    private List<ModeloDescripcion> descripciones;

	void Start () {

        ph = new PersistenceHelper();
        descripciones = ph.CargarDescripciones();
        Debug.Log("Number of descriptions on XML file: " + descripciones.Count);
        textDescripcion = GameObject.Find("Descripcion").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                textDescripcion.text = getDescriptionByName(hit.collider.gameObject.name);
                Debug.Log("Name of the gameobject hited: " + hit.collider.gameObject.name);
            }
            else
            {
                textDescripcion.text = "";
            }
        }
	}
    
    string getDescriptionByName(string name)
    {
        string res = "";

        foreach (var dsc in descripciones)
        {
            if (dsc.Nombre.ToLower().Equals(name.ToLower()))
            {
                res = dsc.Descripcion;
            }
        }

        return res;
        
    }
}
