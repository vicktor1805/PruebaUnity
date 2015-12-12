using UnityEngine;
using System.Collections;
using Assets.Controller;
using Assets.Classes;

public class SemanaControllerScript : MonoBehaviour {

    private ButtonController controller = new ButtonController();
    public GameObject pfTema;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MostrarTemas(string Tag)
    {
        Semana semana = controller.ObtenerSemana(Tag);
        int i = 0;
        if (semana != null)
        {
            foreach (var tema in semana.ListTemas)
            {
                GameObject btn = Instantiate(pfTema, new Vector3(0, i * 20, 0), Quaternion.identity) as GameObject;
                btn.name = tema.TemaId;
                ++i;
            }
        }
    }
}
