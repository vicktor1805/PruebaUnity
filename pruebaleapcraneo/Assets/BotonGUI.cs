using UnityEngine;
using System.Collections;

[System.Serializable]
public class BotonObj {

    public string nombreBoton;
    public Texture2D[] spritesBoton;
    public int modificadorX;
    public float proporcionX;
    public int modificadorY;
    public float proporcionY;
    public bool BotonIndependiente;
    public KeyCode tecla;
    public float TiempoActivacion = 1.0f;

    private int btnEstado; //0 = normal, 1 = mouse hover
    private float posicionX;

    public float PosicionX
    {
        get { return posicionX; }
        set { posicionX = value; }
    }
    private float posicionY;

    public float PosicionY
    {
        get { return posicionY; }
        set { posicionY = value; }
    }
    private float tamaño;
    private Rect rectColision;
    private float tiempoPresionado;
    private bool ejecutar;    
    //diferentes estados
    private bool MouseHoverStart;


	// Use this for initialization
	void Start () {
        rectColision = new Rect(-10, -10, -10, -10);
        btnEstado = 0;
        BotonIndependiente = false;
        tiempoPresionado = 0;
        ejecutar = false;
        
        //declarar tiempo de activacion por defecto
        TiempoActivacion = 1.0f;

        //
        MouseHoverStart = false;
	}

    public void dibujarBoton()
    {
        if (nombreBoton.Contains("GirarCon") && !csVariablesGlobales.HabilitarGiro)
            return;
        if (nombreBoton.Contains("ZoomCon") && !csVariablesGlobales.HabilitarZoom)
            return;
        if (nombreBoton.Contains("DesplazarseCon") && !csVariablesGlobales.HabilitarDesplazamiento)
            return;
        if (nombreBoton.Contains("DesarmarCon") && !csVariablesGlobales.HabilitarDesarme)
            return;

        float x = (Screen.width * modificadorX) / proporcionX;
        PosicionX = x;
        float y = (Screen.height * modificadorY) / proporcionY;
        PosicionY = y;
        

        float rescalar = Screen.width / 3000.0f;

        int indiceSprite = Mathf.RoundToInt(Mathf.Clamp(tiempoPresionado * spritesBoton.Length - 1 / TiempoActivacion, 0f, spritesBoton.Length - 1));

        if (spritesBoton.Length > 2)
        {
            //tiene animacion
            rectColision = new Rect(x - (spritesBoton[indiceSprite].width / 2), y - (spritesBoton[indiceSprite].height / 2), spritesBoton[indiceSprite].width * rescalar, spritesBoton[indiceSprite].height * rescalar);
            GUI.DrawTexture(rectColision, spritesBoton[indiceSprite]);
        }
        else
        {
            rectColision = new Rect(x - (spritesBoton[btnEstado].width / 2), y - (spritesBoton[btnEstado].height / 2), spritesBoton[btnEstado].width * rescalar, spritesBoton[btnEstado].height * rescalar);
            GUI.DrawTexture(rectColision, spritesBoton[btnEstado]);
        }
    }

    public void dibujarBoton(int estado)
    {
        if (nombreBoton.Contains("GirarCon") && !csVariablesGlobales.HabilitarGiro)
            return;
        if (nombreBoton.Contains("ZoomCon") && !csVariablesGlobales.HabilitarZoom)
            return;
        if (nombreBoton.Contains("DesplazarseCon") && !csVariablesGlobales.HabilitarDesplazamiento)
            return;
        if (nombreBoton.Contains("DesarmarCon") && !csVariablesGlobales.HabilitarDesarme)
            return;

        float x = (Screen.width * modificadorX) / proporcionX;
        PosicionX = x;
        float y = (Screen.height * modificadorY) / proporcionY ;
        PosicionY = y;

        float rescalar = Screen.width / 3000f;

        rectColision = new Rect(x - (spritesBoton[estado].width / 2), y - (spritesBoton[estado].height / 2), spritesBoton[estado].width * rescalar, spritesBoton[estado].height * rescalar);
        GUI.DrawTexture(rectColision, spritesBoton[estado]);
    }

    public bool ColisionMouse(Vector2 PosicionPuntero)
    {
        if (nombreBoton.Contains("GirarCon") && !csVariablesGlobales.HabilitarGiro)
            return false;
        if (nombreBoton.Contains("ZoomCon") && !csVariablesGlobales.HabilitarZoom)
            return false;
        if (nombreBoton.Contains("DesplazarseCon") && !csVariablesGlobales.HabilitarDesplazamiento)
            return false;
        if (nombreBoton.Contains("DesarmarCon") && !csVariablesGlobales.HabilitarDesarme)
            return false;

        float x = (Screen.width * modificadorX) / proporcionX;
        float y = (Screen.height * modificadorY) / proporcionY;

        float rescalar = Screen.width / 3000f;

        rectColision = new Rect(x - (spritesBoton[0].width / 2), y - (spritesBoton[0].height / 2), spritesBoton[0].width * rescalar, spritesBoton[0].height * rescalar);

        if (rectColision.Contains(PosicionPuntero))
        {
            btnEstado = 1;
            if (tiempoPresionado == 0)
                MouseHoverStart = true;
            else
                MouseHoverStart = false;


            tiempoPresionado += Time.deltaTime;
            if (tiempoPresionado > TiempoActivacion)
                ejecutar = true;

            return true;
        }
        else
        {
            if (BotonIndependiente)
                btnEstado = 0;
            tiempoPresionado = 0;
            ejecutar = false;
        }

        return false;
    }

    public void CambiarEstado(int nuevoEstado, string PrevBoton)
    {
        if (nuevoEstado == btnEstado)
            return;
        if (nombreBoton.Equals(PrevBoton))
            return;

        btnEstado = nuevoEstado;
    }
    
    //Get
    public int GetEstado()
    {
        return btnEstado;
    }
    public float getTiempoPresionado()
    {
        return tiempoPresionado;
    }

    /// <summary>
    /// Devuelve si es que es posible ejecutar la accion del boton. Es verdadero si el tiempo transcurrido es mayor al tiempo de activacion.
    /// </summary>
    public bool GetEjecutar()
    {
        return ejecutar;
    }

    //Get Estados
    public bool getMouseHoverStart()
    {
        return MouseHoverStart;
    }
}
