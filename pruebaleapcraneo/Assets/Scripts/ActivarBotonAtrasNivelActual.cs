using UnityEngine;
using System.Collections;

public class ActivarBotonAtrasNivelActual : MonoBehaviour {

    private bool ActivadoPorPrimeraVez;

    public GameObject MenuCraneo;
    public GameObject ControladorCamara;

	// Use this for initialization
	void Start () {

        ActivadoPorPrimeraVez = false;

	}
	
	// Update is called once per frame
	void Update () {


        if (!ActivadoPorPrimeraVez)
        {
            /*if (GameObject.Find("02btn_stinger") != null)
            {
                GameObject.Find("02btn_stinger").SetActive(true);
                GameObject.Find("02btn_stinger").collider.enabled = true;
                ActivadoPorPrimeraVez = true;
            }*/

            
            MenuCraneo.SetActive(true);
            for (int i = 0; i < MenuCraneo.transform.childCount; i++)
            {
                MenuCraneo.transform.GetChild(i).gameObject.SetActive(true);

                for (int j = 0; j < MenuCraneo.transform.GetChild(i).gameObject.transform.childCount; j++)
                {

                    //MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.SetActive(true);
                    

                    if (MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                    {
                        MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                        //MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.renderer.enabled = true;
                    }
                }
            }

            /*MenuCraneo.SetActive(true);
            for (int i = 0; i < MenuCraneo.transform.childCount; i++)
            {
                MenuCraneo.transform.GetChild(i).gameObject.SetActive(true);

                for (int j = 0; j < MenuCraneo.transform.GetChild(i).gameObject.transform.childCount; j++)
                {

                    if (MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                    {
                        MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                    }
                }
            }*/
            ControladorCamara.SetActive(true);
            ActivadoPorPrimeraVez = true;
            
        }

        /*MenuCraneo.SetActive(true);
        for (int i = 0; i < MenuCraneo.transform.childCount; i++)
        {
            MenuCraneo.transform.GetChild(i).gameObject.SetActive(true);

            for (int j = 0; j < MenuCraneo.transform.GetChild(i).gameObject.transform.childCount; j++)
            {

                if (MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                {
                    MenuCraneo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                }
            }
        }*/

	}
}
