using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {

    public GameObject Parent;
    private Component[] elementsToShow;    

	// Use this for initialization
	void Start () {

        elementsToShow = new Transform[Parent.GetComponentsInChildren(typeof(Transform),true).Length];
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F9))
        {
            doSomething(Parent);
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            activateSomething();
        }
	}

    void doSomething(GameObject parent)
    {
        int total = 0;
        int index = 0;
        var allChildrens = parent.GetComponentsInChildren(typeof(Transform), false);
        elementsToShow = allChildrens;

        Debug.Log(allChildrens.GetType());

        Debug.Log("Number of childrens " + elementsToShow.Length);

    }

    void activateSomething()
    {
        var allChildrens = Parent.GetComponentsInChildren(typeof(Transform), true);

        for (int i = 0; i < elementsToShow.Length; ++i)
        {
            for (int j = 0; j < allChildrens.Length; ++j)
            {
                if (elementsToShow[i].name.Equals(allChildrens[j].name))
                {
                    allChildrens[i].gameObject.SetActive(true);
                }
            }
        }

    }
    
    
}
