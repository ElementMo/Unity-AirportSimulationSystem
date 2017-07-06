using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightRotate : MonoBehaviour {
    public GameObject light1;
    private float time;

    private void Update()
    {
        RotateLight();
        if (time > 180)
        {
            time = 0;
        }
    }
    public void RotateLight()
    {
        light1.transform.rotation = Quaternion.Euler(time+=0.01f, 15, 0);
    }

}
