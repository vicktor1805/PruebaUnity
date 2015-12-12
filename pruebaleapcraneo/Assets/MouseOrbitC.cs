using UnityEngine;
using System.Collections;
using System;

public class MouseOrbitC : MonoBehaviour
{

    public Transform target;
    public float distance;
    public float speedRotation = 0.01f;
    public float panSpeed = 0.3f;
    private float xSpeed = 250.0f;
    private float ySpeed = 120.0f;
    private float yMinLimit = -90;
    private float yMaxLimit = 90;
    private float x = 0.0f;
    private float y = 0.0f;
    private Vector3 position;
    private Quaternion rotation;
    // Use this for initialization
    void Start()
    {
        print("Script was started correctly");
        //var angles = transform.eulerAngles;
        //x = angles.y;
        //y = angles.x;

        GameObject Pivot = GameObject.Find("Pivot");
        print("Pivot was finded. Position: " + Pivot.transform.position);
        x = Pivot.transform.position.x;
        y = Pivot.transform.position.y;
        //x = Input.GetAxis("Mouse X") * xSpeed * speedRotation;
        //y = Input.GetAxis("Mouse Y") * ySpeed * speedRotation;
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

        if (!target)
        {
            try
            {
                Destroy(GameObject.Find("Cam Target"));
            }
            catch(Exception ex)
            {
                print(ex.Message);
            }
            distance = Vector3.Magnitude(transform.position - Pivot.transform.position);
            print(distance);
            GameObject go = new GameObject("Cam Target");
            go.transform.position = transform.position + (transform.forward * distance);
            target = go.transform;
        }
        else
        {
            distance = Vector3.Magnitude(transform.position - target.transform.position);
        }

        rotation = Quaternion.Euler(y, x, 0);
        position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
        transform.rotation = rotation;
        transform.position = position;
        //transform.LookAt(target);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * speedRotation;
            y -= Input.GetAxis("Mouse Y") * ySpeed * speedRotation;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            rotation = Quaternion.Euler(y, x, 0);
            position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
        else if (Input.GetMouseButton(2))
        {
            //grab the rotation of the camera so we can move in a psuedo local XY space
            target.rotation = transform.rotation;
            target.Translate(Vector3.right * -Input.GetAxis("Mouse X") * panSpeed);
            target.Translate(transform.up * -Input.GetAxis("Mouse Y") * panSpeed, Space.World);
        }
        position = target.position - (rotation * Vector3.forward * distance);
        transform.position = position;
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    public void SetTrget(Transform target)
    {

    }
}