using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour
{

    private GameObject objMover;
    private bool lockObj;
    private float distance;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        ////////////////////CODIGO PARA ROTAR MODELO CON MOUSE

        if (csVariablesGlobales.HabilitarDesarme)
        {
            if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit golpe = new RaycastHit();
                if (Physics.Raycast(ray.origin, ray.direction, out golpe) && !lockObj)
                {
                  if (!golpe.collider.gameObject.name.Contains("MeshPart"))
                    {
                        objMover = golpe.collider.gameObject;
                        distance = golpe.distance;
                    }
                }
         
                lockObj = true;
                if (objMover != null && golpe.collider.gameObject == objMover)
                {
                    offset = objMover.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                }

            }
            else
            {
                lockObj = false;
            }
        }

        ////////////////CODIGO PARA ROTAR MODELO CON MOUSE
    }

    void FixedUpdate()
    {
        if (lockObj && csVariablesGlobales.HabilitarDesarme)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            if (objMover != null)
            {
                //csVariablesGlobales.HabilitarDesplazamiento = false;
                objMover.transform.position = curPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            objMover = null;
        }
    }
}
