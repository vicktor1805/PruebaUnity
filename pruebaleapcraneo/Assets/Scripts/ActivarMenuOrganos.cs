using UnityEngine;
using System.Collections;

public class ActivarMenuOrganos : MonoBehaviour {

	// Use this for initialization
    public GameObject MenuOrganos;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void btnAction()
    {
        MenuOrganos.SetActive(true);

        for (int i = 0; i < MenuOrganos.transform.childCount; i++)
        {
            MenuOrganos.transform.GetChild(i).gameObject.SetActive(true);

            for (int j = 0; j < MenuOrganos.transform.GetChild(i).gameObject.transform.childCount; j++)
            {

                if (MenuOrganos.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                {
                    
                    MenuOrganos.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                }
            }
        }

        /*GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.collider.enabled = true;*/
    }
}
