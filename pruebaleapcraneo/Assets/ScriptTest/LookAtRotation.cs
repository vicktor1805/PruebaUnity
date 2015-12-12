using UnityEngine;
using System.Collections;

public class LookAtRotation : MonoBehaviour {

    GameObject lookAt;
    float x, y, distance,t;
    Vector3 lookatPos;
    Camera camera;
    Vector3 newPos;

	// Use this for initialization
	void Start () {

        newPos = new Vector3();
        t = 0;
        lookAt = GameObject.Find("Cube");
        lookatPos = lookAt.transform.position;
        camera = Camera.main;
        var relativePos = lookAt.transform.position - camera.transform.position;
        distance = relativePos.magnitude;
        x = lookAt.transform.position.x;
        y = lookAt.transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    t += 0.01f;
        //}
        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    t -= 0.01f;
        //}

        //if(Input.GetMouseButton(0))
        //    t += Input.GetAxis("Mouse Y");
        //if (t == 360) t = 0;

        //float newX = distance * Mathf.Cos(t) + x;
        //float newY = distance * Mathf.Sin(t) + y;


        //Vector3 newPos = new Vector3(newX, newY, lookAt.transform.position.z);
        //camera.transform.position = newPos;
        //camera.transform.LookAt(lookAt.transform.position, Vector3.up);
	}

    void Update()
    {

        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                newPos = Vector3.right;
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                newPos = Vector3.left;
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                newPos = Vector3.down;
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                newPos = Vector3.up;
            }
        }
        else
        {
            newPos = Vector3.zero;
        }
        transform.RotateAround(lookAt.transform.position, newPos, 3f);
    }
}
