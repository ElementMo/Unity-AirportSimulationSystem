using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorShowHide : MonoBehaviour {
    public GameObject[] monitorcams;


    public void SH()
    {
        foreach (GameObject cam in monitorcams)
        {
            cam.SetActive(false); 
        }
        monitorcams[0].SetActive(true);
    }
}
