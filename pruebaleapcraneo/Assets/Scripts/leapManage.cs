using UnityEngine;
using System.Collections;
using Leap;

public class leapManage : MonoBehaviour {

    private Controller _controller;
    private Frame _frame;

    public Controller controller { get { return _controller; } }

	// Use this for initialization
	void Start () {
            _controller = new Controller();

	}
	
	// Update is called once per frame
	void Update () {

        if (_controller.IsConnected)
            _frame = _controller.Frame();

        if (_frame.Hands.Count > 1) {
            Debug.Log("MANASOSO");
        }

	
	}
}
