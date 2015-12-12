using UnityEngine;
using System.Collections;
using Assets.Classes;
using Assets.Controller;
using System.Collections.Generic;

public class MainControllerScript : MonoBehaviour {

    private ButtonController controller = new ButtonController();
    public GameObject pfSemana;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MostrarSemanas()
    {
        List<Semana> lstSemana = controller.ListarSemanas();
        foreach (Semana semana in lstSemana)
        {
            GameObject btn = Instantiate(pfSemana, new Vector3(0, 0, 5), Quaternion.identity) as GameObject;            
            btn.name = semana.SemanaId;
        }
    }
}
