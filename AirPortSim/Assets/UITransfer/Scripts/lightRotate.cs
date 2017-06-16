using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightRotate : MonoBehaviour {
    public GameObject light1;
    public Slider slider1;
    public void RotateLight()
    {
        light1.transform.rotation = Quaternion.Euler(slider1.value, 0, 0);
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
