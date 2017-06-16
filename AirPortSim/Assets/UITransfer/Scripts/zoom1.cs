using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * 5f;
            float rotationY = Input.GetAxis("Mouse Y") * 5f;
            transform.Rotate(0, rotationX, 0);
        }
    }
}
