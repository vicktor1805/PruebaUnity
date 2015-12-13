using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControllerBotones : MonoBehaviour {

    
	public GameObject panel;
	public GameObject botonera;
    public GameObject GOLamina;
    public GameObject GOTexto;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;
    public GameObject ButtonShow;
    private int contLamina;
    private int contTexto;
    private Sprite lamina;
    private int index = 1;
    //lista de imagenes de xml
    void Start()
    {

        if (csVariablesGlobales.ListNombreLaminas.Count == 0)
        {
            ButtonShow.SetActive(false);
        }
    }

    void Update()
    {
		if(contLamina==1)
		{
			ButtonLeft.SetActive(false);
            ButtonRight.SetActive(false);
		}
        else if (index == 1)
        {
            if (csVariablesGlobales.pc30)
            {
                ButtonLeft.SetActive(false);
                ButtonRight.SetActive(false);
            }
            else
            {
                ButtonLeft.SetActive(false);
                ButtonRight.SetActive(true);
            }
        }
        else if (index == contLamina)
        {
            ButtonRight.SetActive(false);
			ButtonLeft.SetActive(true);
        }
        else 
        {
            ButtonLeft.SetActive(true);
            ButtonRight.SetActive(true);
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

	public void hidePanel()
	{
        if (!csVariablesGlobales.pc30)
        {
            bool active = panel.activeSelf;

            if (active)
            {
                panel.SetActive(false);
                botonera.SetActive(true);
            }
        }
        else
        {
            RegresarPC30();
        }
        index=1;
	}

    public void changeImage(string side)
    {
        string nombreLamina = GOLamina.gameObject.GetComponent<Image>().sprite.name;
        index = 1;
        foreach (string str in csVariablesGlobales.ListNombreLaminas)
        {
            if (str.Equals(nombreLamina))
            {
                break;
            }
            index++;
        }

		print(index);
        if (side.Equals("Izquierda"))
        {
            if (index > 1)
            {
                index--;
                GOLamina.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(csVariablesGlobales.ListNombreLaminas[index-1]);
                GOTexto.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(csVariablesGlobales.ListNombreLaminasTexto[index - 1]);
            }
        }
        else if(side.Equals("Derecha"))
        {
            if (index < contLamina)
            {
                index++;
                GOLamina.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(csVariablesGlobales.ListNombreLaminas[index-1]);
                GOTexto.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(csVariablesGlobales.ListNombreLaminasTexto[index - 1]);
            }
        }
    }

    void RegresarPC30()
    {
        foreach (GameObject obj in csVariablesGlobales.ObjetosActividad)
        {
            Destroy(obj);
        }
        csVariablesGlobales.pc30 = false;

        csVariablesGlobales.ObjetosActividad.Clear();

        base.gameObject.SetActive(false);

        GameObject controller = GameObject.FindGameObjectsWithTag("Controller")[0];

        Vector3 pos = new Vector3(-1.270002f, -0.6900001f, -20.49f);
        Quaternion rot = new Quaternion(0f, 1.001789e-05f, 0f, 0f);

        Destroy(Camera.main.GetComponent<MouseOrbitC>());

        controller.SendMessage("MostrarActividades", csVariablesGlobales.lastActivitySelected);

    }
}
