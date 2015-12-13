using UnityEngine;
using System.Collections;

public class ActivarLogoBit : MonoBehaviour {

    public GameObject MenuInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void btnAction()
    {
        MenuInfo.SetActive(true);
        for (int i = 0; i < MenuInfo.transform.childCount; i++)
        {
            MenuInfo.transform.GetChild(i).gameObject.SetActive(true);

            for (int j = 0; j < MenuInfo.transform.GetChild(i).gameObject.transform.childCount; j++)
            {

                if (MenuInfo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                {
                    MenuInfo.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                }
            }
        }
        /*GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("BotonAtras").gameObject.transform.GetChild(1).gameObject.collider.enabled = true;*/
    }
}
