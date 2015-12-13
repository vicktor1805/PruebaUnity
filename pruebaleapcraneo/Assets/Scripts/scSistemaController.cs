using UnityEngine;
using System.Collections;
using Assets.Classes;
using System.Collections.Generic;
using System.Linq;
using System;

public class scSistemaController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        /*
         * var ph = new PersistenceHelper();
        ph.CrearUnidadesPruebaXML();

        var xmlHelper = new XmlHelper();
        var lstUnidadAprendizaje = xmlHelper.LoadXml<List<UnidadAprendizaje>>("Unidades.xml");
        var unidadAprendizaje = lstUnidadAprendizaje.First();
        */

        var unidadAprendizaje = UnidadSession.UnidadActual;

        foreach (var vistaSistema in unidadAprendizaje.LstVistaSistema)
        {
            /*if(etc)
            {
                break; ///sirve para salir del foreach
            }*/

            if (vistaSistema.Sistema.Contains("Complemento"))
            {
                var prefabSistema = Resources.Load(vistaSistema.Sistema, typeof(GameObject));
                var sistema = (GameObject)GameObject.Instantiate(prefabSistema);
            }

            else
            {
                var prefabSistema = Resources.Load("PrefabSistema" + vistaSistema.Sistema, typeof(GameObject));
                var sistema = (GameObject)GameObject.Instantiate(prefabSistema, transform.position, transform.rotation);
                //sistema.transform.localScale = transform.localScale;

                foreach (var elementoEliminado in vistaSistema.ElementosEliminados)
                {
                    try
                    {
                        var elemento = sistema.transform.FindChild(elementoEliminado);
                        if (elemento == null)
                            Debug.Log("Elemento '" + elementoEliminado + "' es nulo.");
                        else
                        {
                            GameObject.Destroy(elemento.gameObject);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Log(ex.Message);
                    }
                }
            }
        }
        
        UnidadSession.CamaraActual.transform.position = UnidadSession.UnidadActual.VistaCamara.Posicion;
        UnidadSession.CamaraActual.orthographicSize = UnidadSession.UnidadActual.VistaCamara.Size;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
