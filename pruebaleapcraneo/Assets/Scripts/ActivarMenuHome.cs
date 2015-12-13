using UnityEngine;
using System.Collections;

public class ActivarMenuHome : MonoBehaviour {

    public GameObject MenuHome;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void btnAction()
    {
        MenuHome.SetActive(true);

        for (int i = 0; i < MenuHome.transform.childCount; i++)
        {
            MenuHome.transform.GetChild(i).gameObject.SetActive(true);

            for (int j = 0; j < MenuHome.transform.GetChild(i).gameObject.transform.childCount; j++)
            {

                if (MenuHome.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.name == "02btn_stinger")
                {
                    //MenuHome.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.SetActive(true);
                    MenuHome.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.collider.enabled = true;
                }
            }
        }
    }
}
