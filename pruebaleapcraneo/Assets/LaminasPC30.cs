using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Controller;
using Assets.Classes;
using System.Collections.Generic;

public class LaminasPC30 : MonoBehaviour {


    public GameObject panel;
    public GameObject botonera;
    public GameObject GOLamina;
    public GameObject GOTexto;
    public GameObject panelDescripcion;
    private ButtonController controller;
    private int contLamina;
    private int contTexto;
	// Use this for initialization
	void Start () {

        controller = new ButtonController();
        csVariablesGlobales.ListNombreLaminas = new List<string>();
        csVariablesGlobales.ListNombreLaminasTexto = new List<string>();
        csVariablesGlobales.pc30 = true;
        CargarLaminas("PC30_A1");
        print("Setting object active");
        showPanel();
        
	}

    public void CargarLaminas(string pName)
    {
        List<Texture2D> TexturasLaminas = new List<Texture2D>();

        string[] pNameSpliteado;
        pNameSpliteado = pName.Split('_');
        Semana semana = controller.ObtenerSemana(pNameSpliteado[0]);
        Tema tema = controller.ObtenerTema(pNameSpliteado[0]);
        Actividad actividad = controller.ObtenerActividad(pNameSpliteado[0], pNameSpliteado[1]);

        var milista = controller.ObtenerLaminas(pNameSpliteado[0], pNameSpliteado[1]);
        var milistatexto = controller.ObtenerLaminasTexto(pNameSpliteado[0], pNameSpliteado[1]);
        int count = milista.Count;

        for (int i = 0; i < milista.Count; ++i)
        {
            Lamina lamina = milista[i];


            string NombreLamina = "Lamina_" + pNameSpliteado[0] + "_" + pNameSpliteado[1] + "_" + lamina.LaminaId;
            print(NombreLamina);
            csVariablesGlobales.ListNombreLaminas.Add(NombreLamina);

        }

        for (int i = 0; i < milistatexto.Count; ++i)
        {
            LaminaTexto Laminatexto = milistatexto[i];


            string NombreLamina = "Lamina_" + pNameSpliteado[0] + "_" + pNameSpliteado[1] + "_" + Laminatexto.LaminaTextoId;
            print(NombreLamina);
            csVariablesGlobales.ListNombreLaminasTexto.Add(NombreLamina);

        }

    }

    public void showPanel()
    {
        bool active = panel.activeSelf;
        contLamina = csVariablesGlobales.ListNombreLaminas.Count;
        contTexto = csVariablesGlobales.ListNombreLaminasTexto.Count;
        if (contLamina > 0)
        {
            if (!active)
            {
                panel.SetActive(true);
                botonera.SetActive(false);
                panelDescripcion.SetActive(false);
                Sprite newSprite = Resources.Load<Sprite>(csVariablesGlobales.ListNombreLaminas[0]);
                Sprite newSpriteTexto = Resources.Load<Sprite>(csVariablesGlobales.ListNombreLaminasTexto[0]);

                GOLamina.gameObject.GetComponent<Image>().sprite = newSprite;
                GOTexto.gameObject.GetComponent<Image>().sprite = newSpriteTexto;
            }
        }
        else
        {

        }
    }

}
