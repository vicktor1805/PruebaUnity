using UnityEngine;
using System.Collections;

public class CuboPruebaDesaparecer : MonoBehaviour {

    //public GameObject CuboProximidad;
    public GameObject InstrumentoProximidad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



        if (GameObject.Find("CuboProximidad") != null)
        {
            InstrumentoProximidad = GameObject.Find("CuboProximidad");

            //for (int i = 0; i < base.transform.childCount; i++)
            //{
            //    base.transform.GetChild(i).gameObject.renderer.sharedMaterial.SetVector("_PlayerPosition", InstrumentoProximidad.transform.position);
            //}

            //renderer.sharedMaterial.SetVector("_PlayerPosition", InstrumentoProximidad.transform.position);

            GameObject ModeloPadre = GameObject.Find("Humano");

            if (ModeloPadre != null)
            {
//                Debug.Log(ModeloPadre.transform.childCount);
                //for (int i = 0; i < ModeloPadre.transform.childCount; i++)
                //{
                //    for (int j = 0; j < ModeloPadre.transform.GetChild(i).childCount; j++)
                //    {
                //        //base.transform.GetChild(i).gameObject.renderer.sharedMaterial.SetVector("_PlayerPosition", InstrumentoProximidad.transform.position);
                //        ModeloPadre.transform.GetChild(i).transform.GetChild(j).renderer.sharedMaterial.SetVector("_PlayerPosition", InstrumentoProximidad.transform.position);
                //    }
                //}

                //var allChildrens = ModeloPadre.GetComponentsInChildren(typeof(Transform), false);
                //foreach (Component organo in allChildrens)
                //{
                //    if (organo.name != "Humano")
                //    {
                //        if(!organo.name.Contains("Sistema"))
                //            organo.gameObject.renderer.sharedMaterial.SetVector("_PlayerPosition", InstrumentoProximidad.transform.position);
                //    }
                //}
            }

        }

        

	}
}
