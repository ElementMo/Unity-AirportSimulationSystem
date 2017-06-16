using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomForFreeLook : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 120)
                Camera.main.fieldOfView += 4;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 4;
        }

    }
}
