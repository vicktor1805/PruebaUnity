using UnityEngine;
using System.Collections;

public class ActivarSistemaOseo : MonoBehaviour {

    /*public GameObject Craneo;*/
    public GameObject ControladorCamara;

    public GameObject MenuCraneo;

    public GameObject ControladorCamaraPrefab;

    public GameObject PrefabSistemaOseo;

	// Use this for initialization
	void Start () {
        //GameObject load = GameObject.Find("LoadingSprite");
        //if (load != null)
        //{
        //    load.gameObject.renderer.enabled = true;
        //}
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void btnAction()
    {
        /*Craneo.SetActive(true);*/


        /*ControladorCamara.SetActive(true);*/
        

        MenuCraneo.SetActive(true);
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
        }


        /*GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.collider.enabled = true;*/

        Instantiate(ControladorCamaraPrefab);

        Instantiate(PrefabSistemaOseo);
        

        


        for (int i = 0; i < PrefabSistemaOseo.transform.childCount; i++)
        {
            PrefabSistemaOseo.transform.GetChild(i).gameObject.SetActive(true);

            for (int j = 0; j < PrefabSistemaOseo.transform.GetChild(i).gameObject.transform.childCount; j++)
            {

                if (PrefabSistemaOseo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                {
                    PrefabSistemaOseo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                }
            }
        }

        //GameObject load = GameObject.Find("LoadingSprite");
        //if (load != null)
        //{
        //    load.gameObject.renderer.enabled = false;
        //}


    }
}
