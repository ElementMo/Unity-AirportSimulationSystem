using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonChange : MonoBehaviour {
    public Transform dirLight;
    public Slider slider1;

    public void ScSpring()
    {
        dirLight.rotation = Quaternion.Euler(0, 0, -40);
        Debug.Log("Spring");
    }
    public void ScSummer()
    {
        dirLight.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Summer");
    }
    public void ScAutum()
    {
        dirLight.rotation = Quaternion.Euler(0, 0, -50);
        Debug.Log("Autum");
    }
    public void ScWinter()
    {
        dirLight.rotation = Quaternion.Euler(0, 0, -70);
        Debug.Log("Winter");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
