using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 120)
                Camera.main.fieldOfView += 4;
        }
        //Zoom in  
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 4;
        }
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * 5f;
            float rotationY = Input.GetAxis("Mouse Y") * 5f;
            transform.Rotate(-rotationY, 0, 0);
        }
    }
}
