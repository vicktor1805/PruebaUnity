using UnityEngine;
using System.Collections;
using Assets.Controller;
using Assets.Classes;
using System.Collections.Generic;

public class ButtonControllerScript : MonoBehaviour
{

    private ButtonController controller;
    public GameObject spriteSemana;
    public GameObject pfPC;
    public GameObject pfActividad;
    public GameObject pfBCLogoPeque;
    public GameObject pfBCSemana;
    public GameObject pfBCPC;
    public GameObject pfNACT;
    public GameObject LoadingIcon;
    public GameObject prefabEM3;
    public GameObject prefabFooter;
    public GameObject prefabVersion;
    public GameObject prefabLogoEnchufate;
    public GameObject prefabRegresar;
    public GameObject prefabRegresarSemanas;
    public GameObject pfDerecha;
    public GameObject pfIzquierda;
    public Camera MainCamera;
    public GameObject pfBCAC;
    public GameObject PanelAyuda;
    public CanvasGroup AyudaGroup;
    List<GameObject> listGameObjects;
    private Vector3 starCameraPosition;
    private Vector3 starCameraScale;
    private Quaternion starCameraRotation;

    private GameObject logoPeque;
    private GameObject bcSemana;
    private GameObject bcPC;
    private GameObject bcAC;
    private int index;
    private int maxPages;
    private bool AyudaActiva= false;

    private int posFondo = 0;
    private string[] fondos = { "fondo_1", "fondo_2" };
    // Use this for initialization
    void Start()
    {
        Debug.Log(Application.persistentDataPath + "/" );
        index = 1;
        controller = new ButtonController();
        listGameObjects = new List<GameObject>();
        logoPeque = new GameObject();
        bcSemana = new GameObject();
        bcPC = new GameObject();
        bcAC = new GameObject();
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        starCameraPosition = camera.transform.position;
        starCameraScale = camera.transform.localScale;
        starCameraRotation = camera.transform.rotation;
        Screen.showCursor = false;
        Screen.lockCursor = false;
    }

    void resizeCamera()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = starCameraPosition;
        GameObject.FindGameObjectWithTag("MainCamera").transform.localScale = starCameraScale;
        GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = starCameraRotation;
        csVariablesGlobales.ZoomCamera = 20.0f;
    }

    void CleanScenceMain(string tag = "Main", bool flag = false)
    {
        if (tag.Equals("Main"))
        {
            if (listGameObjects.Count == 0)
            {
                var list = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject gameObject in list)
                {
                    listGameObjects.Add(gameObject);
                }
            }
            foreach (GameObject gameObject in listGameObjects)
            {
                gameObject.SetActive(flag);
            }
        }
        else
        {
            var list = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject gameObject in list)
            {
                gameObject.SetActive(flag);
            }
        }

    }

    void DeleteChild(string pTag = "btnChild")
    {
        var list = GameObject.FindGameObjectsWithTag(pTag);
        foreach (GameObject gameObject in list)
        {
            Destroy(gameObject);
        }
    }

    void CambiarFondo()
    {
        /*GameObject fondo = GameObject.FindGameObjectsWithTag("fondo")[0];
        Texture2D texture = (Texture2D)Resources.Load(fondos[posFondo]);
        (fondo.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer).sprite = texture;
        posFondo = 1 - posFondo;
        
        fondo.guiTexture.texture = texture;*/
    }

    void changeIndex(string btnName)
    {

        if (btnName.Equals("btnRight"))
        {
            index++;
        }
        if (btnName.Equals("btnLeft"))
        {
            index--;
        }

        if (index == 0) index++;
        if (index == maxPages + 1) index--;
        MostrarSemanas();
    }

    void MostrarSemanas()
    {
        //try
        //{
        if (AyudaActiva != true)
        {
            resizeCamera();
            CleanScenceMain();
            DeleteChild("Fondo");
            DeleteChild();
            float btnWidth = pfPC.guiTexture.texture.width;
            float width = Screen.width, height = Screen.height;
            int limite = 0;
            float posX = 0.09f + 0.0335f, posY = -0.4f * height;
            float difX = 0.251f;

            List<Semana> lstSemanas = controller.ListarSemanas();
            int n = lstSemanas.Count;
            int div = n / 4;
            int q = n % 4;
            int contX = 0;
            int contY = 0;
            if (q != 0)
            {
                maxPages = div + 1;
            }
            else
            {
                maxPages = div;
            }

            if (index == maxPages)
            {
                limite = n;
            }
            else
            {
                limite = index * 4;
            }
            // Crear Logo Peque
            Texture2D txtLogo = (Texture2D)Resources.Load("logo_peque");
            logoPeque = Instantiate(pfBCLogoPeque, new Vector3(0.13f, 0.92f, 0), Quaternion.identity) as GameObject;
            logoPeque.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            logoPeque.guiTexture.texture = txtLogo;
            logoPeque.tag = "Fondo";
            logoPeque.SendMessage("setDefaultTexture", txtLogo);
            logoPeque.SendMessage("setHoverTexture", txtLogo);
            logoPeque.SendMessage("setClickedTexture", txtLogo);

            //Crear Logo EM3
            Texture2D txtEM3 = (Texture2D)Resources.Load("EM3");
            GameObject EM3 = Instantiate(prefabEM3, new Vector3(0.89f, 0.92f, 0), Quaternion.identity) as GameObject;
            EM3.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            EM3.guiTexture.texture = txtEM3;
            EM3.tag = "Fondo";
            EM3.SendMessage("setDefaultTexture", txtEM3);
            EM3.SendMessage("setHoverTexture", txtEM3);
            EM3.SendMessage("setClickedTexture", txtEM3);

            //Crear Footer
            Texture2D txtFooter = (Texture2D)Resources.Load("Footer");
            GameObject Footer = Instantiate(prefabFooter, new Vector3(0.5f, 0.02f, 0), Quaternion.identity) as GameObject;
            Footer.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            Footer.guiTexture.texture = txtFooter;
            Footer.tag = "Fondo";
            Footer.SendMessage("setDefaultTexture", txtFooter);
            Footer.SendMessage("setHoverTexture", txtFooter);
            Footer.SendMessage("setClickedTexture", txtFooter);

            // Crear Back
            Texture2D txtBack = (Texture2D)Resources.Load("back");
            GameObject Back = Instantiate(prefabRegresar, new Vector3(0.88f, 0.2f, 0), Quaternion.identity) as GameObject;
            Back.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            Back.guiTexture.texture = txtBack;
            Back.tag = "btnChild";
            Back.SendMessage("setDefaultTexture", txtBack);
            Back.SendMessage("setHoverTexture", txtBack);
            Back.SendMessage("setClickedTexture", txtBack);


            for (int i = index * 4 - 4; i < limite; ++i)
            {
                Semana semana = lstSemanas[i];
                Texture2D texture = (Texture2D)Resources.Load(semana.SemanaId);
                GameObject btnTitulo = Instantiate(spriteSemana, new Vector3(posX + difX * contX, 0.76f, 0), Quaternion.identity) as GameObject;
                btnTitulo.guiTexture.texture = texture;
                btnTitulo.name = semana.SemanaId;

                btnTitulo.SendMessage("setDefaultTexture", texture);
                btnTitulo.SendMessage("setHoverTexture", texture);
                btnTitulo.SendMessage("setClickedTexture", texture);
                btnTitulo.tag = "btnChild";

                contY = 0;
                for (int j = 0; j < semana.ListTemas.Count; ++j)
                {
                    Tema tema = lstSemanas[i].ListTemas[j];
                    string sHelp = tema.TemaId; //"PC" + (j + 1);
                    string act = "btn" + sHelp + "_A" + tema.ListActividad.Count;
                    Texture2D defaultTexture = (Texture2D)Resources.Load(act + "_1");
                    Texture2D hoverTexture = (Texture2D)Resources.Load(act + "_2");
                    Texture2D clickedTexture = (Texture2D)Resources.Load(act + "_3");

                    GameObject btn = Instantiate(pfPC, new Vector3(posX + difX * contX, 0.6f - 0.2f * contY, 0), Quaternion.identity) as GameObject;
                    btn.name = tema.TemaId;
                    btn.tag = "btnChild";
                    btn.guiTexture.texture = defaultTexture;
                    btn.SendMessage("setDefaultTexture", defaultTexture);
                    btn.SendMessage("setHoverTexture", hoverTexture);
                    btn.SendMessage("setClickedTexture", clickedTexture);
                    contY++;
                }
                contX++;
            }

            //Instanciar botones de paginado
            if (maxPages > 1)
            {
                string pngNameRight = "desplazamiento_derecha_";
                string pngNameLeft = "desplazamiento_izquierda_";

                if (index > 1 && index < maxPages)
                {
                    //Right
                    Texture2D defaultTexture = (Texture2D)Resources.Load(pngNameLeft + "1");
                    Texture2D hoverTexture = (Texture2D)Resources.Load(pngNameLeft + "2");
                    Texture2D clickedTexture = (Texture2D)Resources.Load(pngNameLeft + "3");
                    GameObject btnDerecha = Instantiate(pfDerecha, new Vector3(0.05f, 0.05f, 1f), Quaternion.identity) as GameObject;
                    btnDerecha.tag = "btnChild";
                    btnDerecha.name = "btnLeft";
                    btnDerecha.guiTexture.texture = defaultTexture;
                    btnDerecha.SendMessage("setDefaultTexture", defaultTexture);
                    btnDerecha.SendMessage("setHoverTexture", hoverTexture);
                    btnDerecha.SendMessage("setClickedTexture", clickedTexture);


                    //Left
                    Texture2D defaultTexture2 = (Texture2D)Resources.Load(pngNameRight + "1");
                    Texture2D hoverTexture2 = (Texture2D)Resources.Load(pngNameRight + "2");
                    Texture2D clickedTexture2 = (Texture2D)Resources.Load(pngNameRight + "3");
                    GameObject btnIzquierda = Instantiate(pfDerecha, new Vector3(0.10f, 0.05f, 1f), Quaternion.identity) as GameObject;
                    btnIzquierda.tag = "btnChild";
                    btnIzquierda.name = "btnRight";
                    btnIzquierda.guiTexture.texture = defaultTexture2;
                    btnIzquierda.SendMessage("setDefaultTexture", defaultTexture2);
                    btnIzquierda.SendMessage("setHoverTexture", hoverTexture2);
                    btnIzquierda.SendMessage("setClickedTexture", clickedTexture2);

                }
                if (index == 1)
                {
                    //Left
                    Texture2D defaultTexture2 = (Texture2D)Resources.Load(pngNameRight + "1");
                    Texture2D hoverTexture2 = (Texture2D)Resources.Load(pngNameRight + "2");
                    Texture2D clickedTexture2 = (Texture2D)Resources.Load(pngNameRight + "3");
                    GameObject btnIzquierda = Instantiate(pfDerecha, new Vector3(0.10f, 0.05f, 1f), Quaternion.identity) as GameObject;
                    btnIzquierda.tag = "btnChild";
                    btnIzquierda.name = "btnRight";
                    btnIzquierda.guiTexture.texture = defaultTexture2;
                    btnIzquierda.SendMessage("setDefaultTexture", defaultTexture2);
                    btnIzquierda.SendMessage("setHoverTexture", hoverTexture2);
                    btnIzquierda.SendMessage("setClickedTexture", clickedTexture2);
                }
                if (index == maxPages)
                {
                    //Right
                    Texture2D defaultTexture = (Texture2D)Resources.Load(pngNameLeft + "1");
                    Texture2D hoverTexture = (Texture2D)Resources.Load(pngNameLeft + "2");
                    Texture2D clickedTexture = (Texture2D)Resources.Load(pngNameLeft + "3");
                    GameObject btnDerecha = Instantiate(pfDerecha, new Vector3(0.05f, 0.05f, 1f), Quaternion.identity) as GameObject;
                    btnDerecha.tag = "btnChild";
                    btnDerecha.name = "btnLeft";
                    btnDerecha.guiTexture.texture = defaultTexture;
                    btnDerecha.SendMessage("setDefaultTexture", defaultTexture);
                    btnDerecha.SendMessage("setHoverTexture", hoverTexture);
                    btnDerecha.SendMessage("setClickedTexture", clickedTexture);
                }
            }
        }
    }

    void MostrarActividades(string pName)
    {
        Debug.Log("Loading Activity: " + pName + " ...");
        csVariablesGlobales.lastActivitySelected = pName;
        resizeCamera();
        DeleteChild();
        Semana semana = controller.ObtenerSemana(pName);
        Tema tema = controller.ObtenerTema(pName);

        if (logoPeque.transform.position.y == 0.03f)
        {
            logoPeque.transform.position = new Vector3(0.13f, 0.92F, 0);
            Texture2D logopequetextr = (Texture2D)Resources.Load("logo_peque");
            logoPeque.guiTexture.texture = logopequetextr;
            logoPeque.SendMessage("setDefaultTexture", logopequetextr);
            logoPeque.SendMessage("setHoverTexture", logopequetextr);
            logoPeque.SendMessage("setClickedTexture", logopequetextr);
        }

        bcSemana = new GameObject();
        bcSemana.tag = "btnChild2";
        // Crear BC Semana
        
        if (bcSemana.transform.position.y != 0.04f)
        {
            Texture2D txtSemana = (Texture2D)Resources.Load(semana.SemanaId + "_peque");
            bcSemana = Instantiate(pfBCSemana, new Vector3(0.28f, 0.92f, 0), Quaternion.identity) as GameObject;
            bcSemana.guiTexture.texture = txtSemana;
            bcSemana.tag = "btnChild2";
            bcSemana.SendMessage("setDefaultTexture", txtSemana);
            bcSemana.SendMessage("setHoverTexture", txtSemana);
            bcSemana.SendMessage("setClickedTexture", txtSemana);
        }

        bcPC = new GameObject();
        bcPC.tag = "btnChild2";
        // Crear BC PC
        if (bcPC.transform.position.y != 0.04f)
        {
            Texture2D txtPC = (Texture2D)Resources.Load(tema.TemaId + "_peque");
            bcPC = Instantiate(pfBCPC, new Vector3(0.39f, 0.92f, 0), Quaternion.identity) as GameObject;
            bcPC.guiTexture.texture = txtPC;
            bcPC.tag = "btnChild2";
            bcPC.SendMessage("setDefaultTexture", txtPC);
            bcPC.SendMessage("setHoverTexture", txtPC);
            bcPC.SendMessage("setClickedTexture", txtPC);
        }

        // Crear ACT
        Texture2D txtACT = (Texture2D)Resources.Load("ACT" + tema.ListActividad.Count);
        GameObject ACT = Instantiate(pfNACT, new Vector3(0.15f, 0.75f, 0), Quaternion.identity) as GameObject;
        ACT.guiTexture.texture = txtACT;
        ACT.tag = "btnChild";
        ACT.SendMessage("setDefaultTexture", txtACT);
        ACT.SendMessage("setHoverTexture", txtACT);
        ACT.SendMessage("setClickedTexture", txtACT);

        // Crear Back
        Texture2D txtBack = (Texture2D)Resources.Load("back");
        GameObject Back = Instantiate(prefabRegresarSemanas, new Vector3(0.88f, 0.2f, 0), Quaternion.identity) as GameObject;
        Back.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Back.guiTexture.texture = txtBack;
        Back.tag = "btnChild";
        Back.SendMessage("setDefaultTexture", txtBack);
        Back.SendMessage("setHoverTexture", txtBack);
        Back.SendMessage("setClickedTexture", txtBack);

        //var milista = controller.listaordenada(tema.ListActividad); ;
        var milista = tema.ListActividad;
        int count = tema.ListActividad.Count;
        for (int i = 0; i < (count + 1) / 2; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                int it = i * 2 + j + 1;
                Actividad actividad = milista[it - 1]; //tema.ListActividad[it - 1];
                /*if (tema.ListActividad.Count > 2)
                {
                    if (it == 2) it = 3;
                    else if (it == 3) it = 2;
                }*/
                string sTextura = "btn" + semana.SemanaId + "_" + tema.TemaId + "_" + actividad.ActividadId + "_";
                Texture2D txtActividad = (Texture2D)Resources.Load(sTextura + "1");
                GameObject activity = Instantiate(pfActividad, new Vector3(0.25f + j * 0.45f, 0.60f - i * 0.20f, 0), Quaternion.identity) as GameObject;
                //activity.name = ("Semana" + semana.SemanaId.Substring(1) + "Practica" + tema.TemaId.Substring(2) + "Actividad" + actividad.ActividadId.Substring(1));
                activity.name = pName + "_" + actividad.ActividadId;
                //btn.name = tema.TemaId;
                activity.guiTexture.texture = txtActividad;
                activity.tag = "btnChild";
                activity.SendMessage("setDefaultTexture", txtActividad);
                Texture2D txtActividadHover = (Texture2D)Resources.Load(sTextura + "2");
                activity.SendMessage("setHoverTexture", txtActividadHover);
                Texture2D txtActividadClicked = (Texture2D)Resources.Load(sTextura + "3");
                activity.SendMessage("setClickedTexture", txtActividadClicked);
            }
        }

        Debug.Log("Activity: " + pName + " loaded succesfully. ");
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

            csVariablesGlobales.ListNombreLaminas.Add(NombreLamina);

        }

        for (int i = 0; i < milistatexto.Count; ++i)
        {
            LaminaTexto Laminatexto = milistatexto[i];

            
            string NombreLamina = "Lamina_" + pNameSpliteado[0] + "_" + pNameSpliteado[1] + "_" + Laminatexto.LaminaTextoId;

            csVariablesGlobales.ListNombreLaminasTexto.Add(NombreLamina);

        }

    }

    void CargarModelo(string pName)
    {
        //Logo SJB
        logoPeque.transform.position = new Vector3(0.13f, 0.03f, 0);
        Texture2D logopequetextr = (Texture2D)Resources.Load(logoPeque.guiTexture.texture.name + "1");
        logoPeque.guiTexture.texture = logopequetextr;
        logoPeque.SendMessage("setDefaultTexture", logopequetextr);
        logoPeque.SendMessage("setHoverTexture", logopequetextr);
        logoPeque.SendMessage("setClickedTexture", logopequetextr);

        //csVariablesGlobales.ObjetosActividad.Add(logoPeque);

        //BC PC
        bcSemana.transform.position = new Vector3(0.14f, 0.04f, 1f);
        string asdasda = bcSemana.guiTexture.texture.name;
        Texture2D bcSemanatatr = (Texture2D)Resources.Load(bcSemana.guiTexture.texture.name + "1");
        bcSemana.guiTexture.texture = bcSemanatatr;
        bcSemana.SendMessage("setDefaultTexture", bcSemanatatr);
        bcSemana.SendMessage("setHoverTexture", bcSemanatatr);
        bcSemana.SendMessage("setClickedTexture", bcSemanatatr);

        csVariablesGlobales.ObjetosActividad.Add(bcSemana);

        //BC SE
        bcPC.transform.position = new Vector3(0.25f, 0.04f, 1f);
        Texture2D bcPCtxtr = (Texture2D)Resources.Load(bcPC.guiTexture.texture.name + "1");
        bcPC.guiTexture.texture = bcPCtxtr;
        bcPC.SendMessage("setDefaultTexture", bcPCtxtr);
        bcPC.SendMessage("setHoverTexture", bcPCtxtr);
        bcPC.SendMessage("setClickedTexture", bcPCtxtr);

        //BC AC
        bcAC = Instantiate(pfBCAC, new Vector3(0.45f, 0.04f, 1f), Quaternion.identity) as GameObject;
        Texture2D bcPCAC = (Texture2D)Resources.Load(pName);
        bcAC.guiTexture.texture = bcPCAC;
        bcAC.SendMessage("setDefaultTexture", bcPCAC);
        bcAC.SendMessage("setHoverTexture", bcPCAC);
        bcAC.SendMessage("setClickedTexture", bcPCAC);

        csVariablesGlobales.ObjetosActividad.Add(bcAC);
        csVariablesGlobales.ObjetosActividad.Add(bcPC);
        csVariablesGlobales.ListNombreLaminas.Clear();
        csVariablesGlobales.ListNombreLaminasTexto.Clear();
        CargarLaminas(pName);
        
        CleanScenceMain("btnChild");
        if (LoadingIcon != null)
            LoadingIcon.SetActive(true);

        csVariablesGlobales.ActividadXML = pName;
        StartCoroutine(CaragarModelo(csVariablesGlobales.EscenaModelo));
    }

    IEnumerator CaragarModelo(string NombreActividad)
    {
        AsyncOperation async = Application.LoadLevelAdditiveAsync(NombreActividad);
        yield return async;

        Debug.Log("Loading complete");
        if (LoadingIcon != null)
            LoadingIcon.SetActive(false);
    }

    void RegresarInicio()
    {
        logoPeque.transform.position = new Vector3(0.13f, 0.92F, 0);
        resizeCamera();
        DeleteChild();
        DeleteChild("Fondo");
        //DeleteChild("BtnChild2");
        CleanScenceMain("Main", true);
        index = 1;
    }

    public void RegresarSemanas()
    {
        resizeCamera();
        logoPeque.transform.position = new Vector3(0.13f, 0.92F, 0);
        DeleteChild();
        DeleteChild("btnChild2");
        MostrarSemanas();
    }

    public void Close()
    {
        if(AyudaActiva!=true){
            Application.Quit();
        }
    }

    public void Ayuda()
    {
        
        if (AyudaActiva != true)
        {
            PanelAyuda.SetActive(true);
            AyudaGroup.alpha = 0;
            AyudaActiva = true;
            Debug.Log(AyudaActiva);

            //Invoke("FadeIn", 1);
            StartCoroutine("FadeIn");
        }
    }


    IEnumerator FadeIn()
    {
        float time = 0.7f;
        while (AyudaGroup.alpha <= 1)
        {
            AyudaGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    public void CloseAyuda()
    {
       
        if (AyudaActiva == true)
        { 
           
            StartCoroutine("FadeOut");
            Invoke("ApagarPanel", 0.7f);
        }
    }

    IEnumerator FadeOut()
    {
        float time = 0.7f;
        while (AyudaGroup.alpha > 0)
        {
            AyudaGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

    void ApagarPanel()
    {
        PanelAyuda.SetActive(false);
        AyudaActiva = false;
        Debug.Log(AyudaActiva);
    }

}
