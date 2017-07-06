using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class ReelTimeSwitch : MonoBehaviour {
    public GameObject RTCam;

    public Transform TheCar;

    public void RTSwitch()
    {
       AutoCam ac =  RTCam.GetComponent<AutoCam>();
        ac.SetTarget(TheCar);
    }

}
