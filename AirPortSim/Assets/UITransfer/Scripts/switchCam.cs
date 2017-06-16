using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCam : MonoBehaviour {
    public GameObject[] cam;
    //public GameObject[] sc;

    public void SwitchCam()
    {
        //try
        //{
        //    foreach (var sci in sc)
        //    {
        //        sci.SetActive(false);
        //    }
        //    sc[0].SetActive(true);
        //}
        //catch (System.Exception)
        //{
        //}


        foreach (var cami in cam)
        {
            cami.SetActive(false);
        }
        cam[0].SetActive(true);
        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
