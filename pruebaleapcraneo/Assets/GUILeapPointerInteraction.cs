using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GUILeapPointerInteraction : MonoBehaviour
{
    public Color hoverColor = new Color(0, 155, 193, 255);
    public GameObject ModalPanel;
    public GameObject PlaneChild;
    public Color ButtonBaseColor;
    public GameObject Canvas;
    public GameObject cameraEditor;
    public GameObject Pivot;
    public float velocidad = 80;
    public float movementSensitivity = 0.02f;
    public float rearmVelocity = 0.09f;
    float clickableElapsedTime;
    string lastClickableID;
    bool hoverClick;
    Texture2D cursorGlowImg;
    Vector2 PosicionPunteroLeap2DRelativaGUI;

    //--------------------------------------
    [SerializeField]
    public List<BotonObj> Botones;
    private string PrevBoton;
    bool colision = false;
    bool VerificacionDedoExtendido = false;
    private float xDeg;
    private float yDeg;
    public int speed;
    public int friction;
    public float lerpSpeed;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private GameObject objMover;
    private Boolean isRotatingYAxis;
    private Boolean isRotatingXAxis;
    private Boolean isRotatingZAxis;
    private Boolean changeAxis;
    private GameObject modelo;
    private Vector3 starPosition;
    private Quaternion startRotation;
    private Vector2 startScale;
    private bool resize;
    private bool loaded;
    private Vector3[] subModels;
    private Quaternion[] quad;

    IEnumerator CaragarModelo(string NombreSistema)
    {
        AsyncOperation async = Application.LoadLevelAdditiveAsync(NombreSistema);
        yield return async;
        loaded = true;
        Debug.Log("Loading complete");
        
    }

    void Awake()
    {
        csVariablesGlobales.HabilitarDesarme = true;//TODO
        csVariablesGlobales.HabilitarDesplazamiento = true;
        csVariablesGlobales.HabilitarGiro = true;
        csVariablesGlobales.HabilitarZoom = true;
        modelo = GameObject.FindGameObjectWithTag("Modelo");
        startRotation = modelo.transform.rotation;
        startScale = modelo.transform.localScale;
    }

    void Start()
    {
        loaded = true;
        resize = false;
        PrevBoton = "";
        changeAxis = true;

        if(PlaneChild!=null)
            PlaneChild.SetActive(true);
        ModalPanel.SetActive(true);
        //csVariablesGlobales.ObjetosActividad.Add(gameObject);
        csVariablesGlobales.ObjetosActividad.Add(ModalPanel);
        csVariablesGlobales.ObjetosActividad.Add(modelo);
        csVariablesGlobales.ObjetosActividad.Add(GameObject.Find("Pivot"));
        csVariablesGlobales.ObjetosActividad.Add(GameObject.Find("Light 1"));
        csVariablesGlobales.ObjetosActividad.Add(GameObject.Find("Light 2"));
        csVariablesGlobales.ObjetosActividad.Add(GameObject.Find("CuboProximidad"));
        csVariablesGlobales.ObjetosActividad.Add(Canvas);
        csVariablesGlobales.ObjetosActividad.Add(cameraEditor);
        Debug.Log("Objects activity to destroy: " + csVariablesGlobales.ObjetosActividad.Count);
        Camera.main.gameObject.AddComponent<MouseOrbitC>();
    }

    void setListSubModels()
    {
        var listChild = modelo.GetComponentsInChildren<Transform>();
        subModels = new Vector3[listChild.Length];
        quad = new Quaternion[listChild.Length];
        for (int i = 0; i < listChild.Length; ++i)
        {
            subModels[i] = listChild[i].gameObject.transform.position;
            quad[i] = listChild[i].rotation;
        }
    }

    void FixedUpdate()
    {
        if (resize)
        {
            float step = velocidad * Time.deltaTime;
            var listChild = modelo.GetComponentsInChildren<Transform>();

            for (int i = 0; i < listChild.Length; ++i)
            {
                var gameObject = listChild[i].gameObject;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, subModels[i], step * rearmVelocity);
                gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, quad[i], step * rearmVelocity);

            }
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, starPosition, step * rearmVelocity);
            modelo.transform.rotation = Quaternion.RotateTowards(modelo.transform.rotation, startRotation, step * rearmVelocity);
            //if (Camera.main.transform.position.Equals(starPosition))
            //{
            //    resize = false;
            //}
        }
    }

    void LateUpdate()
    {
        if (loaded)
        {
            starPosition = Camera.main.transform.position;
            setListSubModels();
            loaded = false;
        }

        float step = velocidad * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            resize = true;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            resize = false;
        }

        ////////////////CODIGO PARA EL ZOOM CON SCROLL

        //if (csVariablesGlobales.HabilitarZoom)
        //{
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                csVariablesGlobales.ZoomCamera -= 0.35f;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                csVariablesGlobales.ZoomCamera += 0.35f;
            }
        //}
        ////////////////CODIGO PARA EL ZOOM CON SCROLL

        ////////////////CODIGO PARA EL PANNING CON MOUSE

        if (csVariablesGlobales.HabilitarDesplazamiento)
        {
            //if (Input.GetMouseButton(0))
            //{
            //    if (Input.GetAxis("Mouse Y") < 0)
            //        Camera.main.transform.Translate(0, movementSensitivity * csVariablesGlobales.ZoomCamera, 0);
            //    if (Input.GetAxis("Mouse Y") > 0)
            //        Camera.main.transform.Translate(0, -movementSensitivity * csVariablesGlobales.ZoomCamera, 0);
            //    if (Input.GetAxis("Mouse X") > 0)
            //        Camera.main.transform.Translate(-movementSensitivity * csVariablesGlobales.ZoomCamera, 0, 0);
            //    if (Input.GetAxis("Mouse X") < 0)
            //        Camera.main.transform.Translate(movementSensitivity * csVariablesGlobales.ZoomCamera, 0, 0);
            //}
        }
        ////////////////CODIGO PARA EL PAN CON MOUSE
        if (Input.GetKeyDown("p"))
        {

                BotonDesarmePressed();

        }

        ////////////////CODIGO PARA ROTAR MODELO CON MOUSE

        //if (csVariablesGlobales.HabilitarGiro)
        //{
            //if ((Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0))
            //{
            //    isRotatingXAxis = false;
            //    isRotatingYAxis = true;
            //    isRotatingZAxis = false;
            //}
            //else if ((Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0))
            //{
            //    isRotatingXAxis = true;
            //    isRotatingYAxis = false;
            //    isRotatingZAxis = false;
            //}
            //if (Input.GetKeyDown(KeyCode.A))
            //{

            //    changeAxis = !changeAxis;
            //    isRotatingZAxis = !isRotatingZAxis;
            //    isRotatingXAxis = !isRotatingXAxis;
            //    isRotatingYAxis = !isRotatingYAxis;
            //    Debug.Log("Change axis value : " + changeAxis);

            //}
            //if (Input.GetMouseButton(1))
            //{
            //    if (Input.GetAxis("Mouse Y") > 0)
            //    {
            //        modelo.transform.RotateAround(Pivot.transform.position, Vector3.right, velocidad * Time.deltaTime);

            //    }
            //    else if (Input.GetAxis("Mouse Y") < 0)
            //    {
            //        modelo.transform.RotateAround(Pivot.transform.position, Vector3.left, velocidad * Time.deltaTime);
            //    }

            //    else if (Input.GetAxis("Mouse X") > 0)
            //    {
            //        modelo.transform.RotateAround(Pivot.transform.position, Vector3.down, velocidad * Time.deltaTime);
            //    }
            //    else if (Input.GetAxis("Mouse X") < 0)
            //    {
            //        modelo.transform.RotateAround(Pivot.transform.position, Vector3.up, velocidad * Time.deltaTime);
            //    }


            //}
        //}
        ConversorPosisionLeapaGUI();        
    }

    public void BotonGirarPressed(Button button)
    {
        GameObject[] ListaBotones = GameObject.FindGameObjectsWithTag("Button");
        if (!csVariablesGlobales.HabilitarGiro)
        {
            foreach (GameObject b in ListaBotones)
            {
                if (!b.name.Equals(button.name))
                {
                    b.GetComponent<Image>().color = ButtonBaseColor;
                }
            }
            button.GetComponent<Image>().color = hoverColor;
            csVariablesGlobales.HabilitarZoom = false;
            csVariablesGlobales.HabilitarDesarme = false;
            csVariablesGlobales.HabilitarDesplazamiento = false;
            csVariablesGlobales.HabilitarGiro = true;
        }
        else
        {
            button.GetComponent<Image>().color = ButtonBaseColor;
            csVariablesGlobales.HabilitarGiro = false;
        }
    }
    public void BotonZoomPressed(Button button)
    {
        GameObject[] ListaBotones = GameObject.FindGameObjectsWithTag("Button");
        if (!csVariablesGlobales.HabilitarZoom)
        {
            foreach (GameObject b in ListaBotones)
            {
                if (!b.name.Equals(button.name))
                {
                    b.GetComponent<Image>().color = ButtonBaseColor;
                }
            }
            button.GetComponent<Image>().color = hoverColor;
            csVariablesGlobales.HabilitarDesarme = false;
            csVariablesGlobales.HabilitarDesplazamiento = false;
            csVariablesGlobales.HabilitarGiro = false;
            csVariablesGlobales.HabilitarZoom = true;
        }
        else
        {
            csVariablesGlobales.HabilitarZoom = false;
            button.GetComponent<Image>().color = ButtonBaseColor;
        }
    }
    public void BotonDesplazarsePressed(Button button)
    {
        GameObject[] ListaBotones = GameObject.FindGameObjectsWithTag("Button");
        if (!csVariablesGlobales.HabilitarDesplazamiento)
        {
            foreach (GameObject b in ListaBotones)
            {
                if (!b.name.Equals(button.name))
                {
                    b.GetComponent<Image>().color = ButtonBaseColor;
                }
            }
            button.GetComponent<Image>().color = hoverColor;
            csVariablesGlobales.HabilitarZoom = false;
            csVariablesGlobales.HabilitarDesarme = false;
            csVariablesGlobales.HabilitarGiro = false;
            csVariablesGlobales.HabilitarDesplazamiento = true;
        }
        else
        {
            button.GetComponent<Image>().color = ButtonBaseColor;
            csVariablesGlobales.HabilitarDesplazamiento = false;
        }
    }

    public void BotonDesarmePressed(Button button)
    {
        GameObject[] ListaBotones = GameObject.FindGameObjectsWithTag("Button");
        if (!csVariablesGlobales.HabilitarDesarme)
        {
            //foreach (GameObject b in ListaBotones)
            //{
            //    if (!b.name.Equals(button.name))
            //    {
            //        b.GetComponent<Image>().color = hoverColor;
            //    }
            //}
            button.GetComponent<Image>().color = hoverColor;
            csVariablesGlobales.HabilitarDesarme = true;
        }
        else
        {
            button.GetComponent<Image>().color = Color.white;
            csVariablesGlobales.HabilitarDesarme = false;
        }
    }

    public void BotonDesarmePressed()
    {
        if (!csVariablesGlobales.HabilitarDesarme)
        {
            csVariablesGlobales.HabilitarDesarme = true;
            csVariablesGlobales.HabilitarDesplazamiento = false;
        }
        else
        {
            csVariablesGlobales.HabilitarDesarme = false;
            csVariablesGlobales.HabilitarDesplazamiento = true;
        }
    }

    private String changeGender(String s)
    {
        String res;
        res = s.Substring(6);
        string[] values = { "Femenino", "Masculino" };
        int index = 0;
        if (res.Contains(values[1])) index = 1;
        res = res.Replace(values[index], values[1 - index]);
        return res;
    }

    private void ConversorPosisionLeapaGUI()
    {
        if (csVariablesGlobales.ModoMouse)
        {
            PosicionPunteroLeap2DRelativaGUI.x = Input.mousePosition.x - 16f;
            PosicionPunteroLeap2DRelativaGUI.y = (float)Screen.height - Input.mousePosition.y - 16f;
        }
        else
        {
            PosicionPunteroLeap2DRelativaGUI = Leap_PointerModel.pointerPosition_2D;
            PosicionPunteroLeap2DRelativaGUI.y = Screen.height - PosicionPunteroLeap2DRelativaGUI.y;
        }
    }

    public void btnAction()
    {
        //csVariablesGlobales.pc30 = false;
        foreach (GameObject obj in csVariablesGlobales.ObjetosActividad)
        {
            Destroy(obj);
        }
        csVariablesGlobales.ObjetosActividad.Clear();

        base.gameObject.SetActive(false);

        GameObject controller = GameObject.FindGameObjectsWithTag("Controller")[0];

        //RESETEO DE LA CAMARA

        Vector3 pos = new Vector3(-1.270002f, -0.6900001f, -20.49f);
        Quaternion rot = new Quaternion(0f, 1.001789e-05f, 0f, 0f);

        //Camera.main.SendMessage("SetPosicion", pos);
        //Camera.main.SendMessage("SetRotacion", rot);
        //Camera.main.SendMessage("SetTargetPosicion", pos);
        Destroy(Camera.main.GetComponent<MouseOrbitC>());
        //RESETEO DE LA CAMARA

        controller.SendMessage("MostrarActividades",csVariablesGlobales.lastActivitySelected);
        if(PlaneChild!=null)
            PlaneChild.SetActive(false);




    }
}
