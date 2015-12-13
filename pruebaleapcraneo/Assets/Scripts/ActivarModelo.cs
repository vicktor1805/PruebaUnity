using UnityEngine;
using System.Collections;
using Assets.Classes;
using System.Collections.Generic;
using System.Linq;

public class ActivarModelo : MonoBehaviour
{

    /*public GameObject CorazonGato;*/
    //public GameObject ControladorCamara;

    public GameObject MenuSistema;
    public Camera camaraPrincipal;
    public GameObject ControladorCamaraPrefab;
    public GameObject LoadingIcon;

    //public GameObject PrefabSistema;

    public string NombreSistema;

    //public int NumeroDePractica;

    IEnumerator CaragarModelo()
    {
        AsyncOperation async = Application.LoadLevelAdditiveAsync(NombreSistema);
        yield return async;
        //yield return new WaitForSeconds(0.5f);
        Debug.Log("Loading complete");
        //if (GameObject.Find("LoadingIcon") != null)
            //GameObject.Find("LoadingIcon").active = false;
        if (LoadingIcon = null)
            LoadingIcon.renderer.enabled = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void btnAction()
    {

        if (LoadingIcon != null)
            LoadingIcon.renderer.enabled = true;

        // Parte de Persistencia y cargar Sistemas
        //var ph = new PersistenceHelper();

        if (base.transform.parent.gameObject.name.Contains("(1)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 1;
        //    //NumeroDePractica = 1;
        //    //ph.CrearUnidadesPruebaXML();
        //    ph.CrearUnidadesPruebaXML1();

        //    var xmlHelper = new XmlHelper();
        //    var lstUnidadAprendizaje = xmlHelper.LoadXml<List<UnidadAprendizaje>>("Unidades.xml");
        //    UnidadSession.UnidadActual = lstUnidadAprendizaje.FirstOrDefault(x => x.Codigo == NombreSistema);
        //    UnidadSession.CamaraActual = camaraPrincipal.GetComponent<Camera>();

        //    if (UnidadSession.UnidadActual != null && false)
        //    {
        //        camaraPrincipal.transform.position = UnidadSession.UnidadActual.VistaCamara.Posicion;
        //        camaraPrincipal.GetComponent<Camera>().orthographicSize = UnidadSession.UnidadActual.VistaCamara.Size;
        //        //camaraPrincipal.transform.rotation = UnidadSession.UnidadActual.VistaCamara.Rotacion;
        //    }
        }

        if (base.transform.parent.gameObject.name.Contains("(2)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 2;
        //    //NumeroDePractica = 2;
        //    //ph.CrearUnidadesPruebaXML();
        //    ph.CrearUnidadesPruebaXML2();

        //    var xmlHelper = new XmlHelper();
        //    var lstUnidadAprendizaje = xmlHelper.LoadXml<List<UnidadAprendizaje>>("Unidades.xml");
        //    UnidadSession.UnidadActual = lstUnidadAprendizaje.FirstOrDefault(x => x.Codigo == NombreSistema);
        //    UnidadSession.CamaraActual = camaraPrincipal.GetComponent<Camera>();

        //    if (UnidadSession.UnidadActual != null && false)
        //    {
        //        camaraPrincipal.transform.position = UnidadSession.UnidadActual.VistaCamara.Posicion;
        //        camaraPrincipal.GetComponent<Camera>().orthographicSize = UnidadSession.UnidadActual.VistaCamara.Size;
        //        //camaraPrincipal.transform.rotation = UnidadSession.UnidadActual.VistaCamara.Rotacion;
        //    }
        }

        if (base.transform.parent.gameObject.name.Contains("(3)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 3;
        //    //NumeroDePractica = 3;
        //    //ph.CrearUnidadesPruebaXML();
        //    ph.CrearUnidadesPruebaXML3();

        //    var xmlHelper = new XmlHelper();
        //    var lstUnidadAprendizaje = xmlHelper.LoadXml<List<UnidadAprendizaje>>("Unidades.xml");
        //    UnidadSession.UnidadActual = lstUnidadAprendizaje.FirstOrDefault(x => x.Codigo == NombreSistema);
        //    UnidadSession.CamaraActual = camaraPrincipal.GetComponent<Camera>();

        //    if (UnidadSession.UnidadActual != null && false)
        //    {
        //        camaraPrincipal.transform.position = UnidadSession.UnidadActual.VistaCamara.Posicion;
        //        camaraPrincipal.GetComponent<Camera>().orthographicSize = UnidadSession.UnidadActual.VistaCamara.Size;
        //        //camaraPrincipal.transform.rotation = UnidadSession.UnidadActual.VistaCamara.Rotacion;
        //    }
        }

        if (base.transform.parent.gameObject.name.Contains("(4)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 4;
        //    //NumeroDePractica = 3;
        //    //ph.CrearUnidadesPruebaXML();
        //    ph.CrearUnidadesPruebaXML4();

        //    var xmlHelper = new XmlHelper();
        //    var lstUnidadAprendizaje = xmlHelper.LoadXml<List<UnidadAprendizaje>>("Unidades.xml");
        //    UnidadSession.UnidadActual = lstUnidadAprendizaje.FirstOrDefault(x => x.Codigo == NombreSistema);
        //    UnidadSession.CamaraActual = camaraPrincipal.GetComponent<Camera>();

        //    if (UnidadSession.UnidadActual != null && false)
        //    {
        //        camaraPrincipal.transform.position = UnidadSession.UnidadActual.VistaCamara.Posicion;
        //        camaraPrincipal.GetComponent<Camera>().orthographicSize = UnidadSession.UnidadActual.VistaCamara.Size;
        //        //camaraPrincipal.transform.rotation = UnidadSession.UnidadActual.VistaCamara.Rotacion;
        //    }
        }

        if (base.transform.parent.gameObject.name.Contains("(5)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 5;
        //    //NumeroDePractica = 3;
        //    //ph.CrearUnidadesPruebaXML();
        //    ph.CrearUnidadesPruebaXML5();

        //    var xmlHelper = new XmlHelper();
        //    var lstUnidadAprendizaje = xmlHelper.LoadXml<List<UnidadAprendizaje>>("Unidades.xml");
        //    UnidadSession.UnidadActual = lstUnidadAprendizaje.FirstOrDefault(x => x.Codigo == NombreSistema);
        //    UnidadSession.CamaraActual = camaraPrincipal.GetComponent<Camera>();

        //    if (UnidadSession.UnidadActual != null && false)
        //    {
        //        camaraPrincipal.transform.position = UnidadSession.UnidadActual.VistaCamara.Posicion;
        //        camaraPrincipal.GetComponent<Camera>().orthographicSize = UnidadSession.UnidadActual.VistaCamara.Size;
        //        //camaraPrincipal.transform.rotation = UnidadSession.UnidadActual.VistaCamara.Rotacion;
        //    }
        }
            
            

            /*CorazonGato.SetActive(true);*/
            /*ControladorCamara.SetActive(true);*/

            //MenuSistema.SetActive(true);
            //for (int i = 0; i < MenuSistema.transform.childCount; i++)
            //{

            //    if (MenuSistema.transform.GetChild(i).transform.name.Contains(csVariablesGlobales.NumeroDePracticaActual.ToString()) || (MenuSistema.transform.GetChild(i).transform.name == "LoadingIcon"))
            //        MenuSistema.transform.GetChild(i).gameObject.SetActive(true);
            //    else
            //        MenuSistema.transform.GetChild(i).gameObject.SetActive(false);

            //    for (int j = 0; j < MenuSistema.transform.GetChild(i).gameObject.transform.childCount; j++)
            //    {

            //        if (MenuSistema.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
            //        {
            //            MenuSistema.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
            //        }
            //    }
            //}

            /*GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.collider.enabled = true;*/

        if (base.transform.parent.gameObject.name.Contains("(6)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 6;
        }
        if (base.transform.parent.gameObject.name.Contains("(7)"))
        {
            csVariablesGlobales.NumeroDePracticaActual = 7;
        }

        Instantiate(ControladorCamaraPrefab);

            //Instantiate(PrefabSistema);

        LoadingIcon.SetActive(true);

        StartCoroutine(CaragarModelo());

        //////////////////////PERETENECIA A LA MANERA DE CARGAR MODELOS DESDE XML/////////////////////////

            //if (GameObject.Find("LoadingIcon") != null)
            //    GameObject.Find("LoadingIcon").renderer.enabled = true;

        //////////////////////PERETENECIA A LA MANERA DE CARGAR MODELOS DESDE XML/////////////////////////


            /*for (int i = 0; i < PrefabSistema.transform.childCount; i++)
            {
                PrefabSistema.transform.GetChild(i).gameObject.SetActive(true);

                for (int j = 0; j < PrefabSistema.transform.GetChild(i).gameObject.transform.childCount; j++)
                {

                    if (PrefabSistema.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                    {
                        PrefabSistema.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                    }
                }
            }*/
        
        }
}
