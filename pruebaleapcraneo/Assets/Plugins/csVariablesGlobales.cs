using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class csVariablesGlobales : MonoBehaviour
{

    public static float LeapScale = 0.1f;

    public static List<GameObject> MenuAnterior;

    public static Stack<List<GameObject>> PilaDeMenus;

    public static List<GameObject> MenuHome;

    public static Color32 ColorBotones;

    public static bool HabilitarZoom;

    public static bool HabilitarGiro;

    public static bool HabilitarDesplazamiento;

    public static bool HabilitarDesarme;

    public static bool Cargar;

    private bool MenuHomeEncontrado;

    public static float LoadingScreen = 3.0f;

    public static Vector3 origenbotones;

    public static float ZoomCamera;

    //variable para que no se presionen botones de casualidad mientras se estan moviendo las piezas
    public static bool moviendoPieza = false;    

    //variables menu contextual Giro
    public static bool GiroEjeX;
    public static bool GiroEjeY;
    public static bool GiroEjeZ;

    public static bool ResetRot = false;
    public static bool ResetPosPiezas = false;
    public static bool UndoPosPiezas = false;

    public static Transform objMoviendose;
    // Use this for initialization

    public static Transform ModeloSeleccionado;

    public static Transform UltimoPrefabSeleccionado;

    public static string NombreUltimoPrefabSeleccionado;

    public static string UltimoBotonGUIPrincipalSeleccionado;

    public static string UltimoBotonSeleccinado;

    public static int NumeroDePracticaActual;

    public static Vector3 UltimaPosicionMouse;

    public static bool ModoMouse;
    //public static bool EstoySobreUnBotonGUIPrincinpal = false;
    public static List<GameObject> ObjetosActividad;

    public static List<string> ListNombreLaminas;
    public static List<string> ListNombreLaminasTexto;
    public static string lastActivitySelected;
    public static string ActividadXML;
    public static string EscenaModelo = "EscenaEditor";
    public static bool pc30 = false;
    void Start()
    {
        ListNombreLaminas = new List<string>();
        ListNombreLaminasTexto = new List<string>();
        MenuAnterior = new List<GameObject>();
        MenuHome = new List<GameObject>();
        
        PilaDeMenus = new Stack<List<GameObject>>();
        HabilitarZoom = false;
        UltimoBotonSeleccinado = "";
        NumeroDePracticaActual = 0;
        ModoMouse = true;

        origenbotones = new Vector3(0, 0, 0);

        ZoomCamera = Camera.main.orthographicSize;

        GiroEjeX = false;
        GiroEjeY = false;
        GiroEjeZ = false;

        UltimoBotonGUIPrincipalSeleccionado = "";

        ObjetosActividad = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        if (ZoomCamera < 1)
            ZoomCamera = 1;
        if (ZoomCamera > 20)
            ZoomCamera = 20;
        Camera.main.orthographicSize = ZoomCamera;

        if (Cargar)
        {
            Cargar = false;
        }

        if (Input.GetKeyDown("s"))
        {
            if (Leap_PointerModel.pickHit.transform != null)
                csVariablesGlobales.ModeloSeleccionado = Leap_PointerModel.pickHit.transform;       
        }

        if (Input.GetKeyDown("c"))
        {
            csVariablesGlobales.ModeloSeleccionado = csVariablesGlobales.UltimoPrefabSeleccionado;
        }

        //if (Input.GetKeyDown("m"))
        //{
        //    if(ModoMouse == false)
        //        ModoMouse = true;
        //    else
        //        ModoMouse = false;
        //}

        if (ModoMouse)
        {
            Leap_PointerModel.pointerPosition_2D = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            //Ray ray = Camera.main.ScreenPointToRay(Leap_PointerModel.pointerPosition_2D);
        }

        if (Leap_PointerModel.pickHit.transform == null)
        {
            FingerInteraction.ContadorBoton = 0;
            if (GameObject.FindGameObjectsWithTag("ButtonStinger").Length > 0)
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("ButtonStinger").Length; i++)
                    GameObject.FindGameObjectsWithTag("ButtonStinger")[i].renderer.material.color = new Color(0, 0, 0, 1);
            }
            else
                return;
        }

    }

    IEnumerator DesactivarConDelay()
    {
        // suspend execution for 5 seconds

        GameObject load = GameObject.Find("LoadingSprite");
        if (load != null)
        {
            load.gameObject.renderer.enabled = true;
        }

        yield return new WaitForSeconds(3);


        GameObject load2 = GameObject.Find("LoadingSprite");
        if (load2 != null)
        {
            load2.gameObject.renderer.enabled = false;
        }
    }
}
