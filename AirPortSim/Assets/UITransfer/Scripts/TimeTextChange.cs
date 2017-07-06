using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextChange : MonoBehaviour {
    public Text text1;
    public GameObject light;
    private int min,texthour,textmin;
    private float lightAngle;
    System.DateTime now = System.DateTime.Now;

    public void Update()
    {
        lightAngle = light.transform.rotation.x*180;
        Debug.Log(lightAngle);
        min = (int)lightAngle*4;
        texthour = 6 + min / 60;
        textmin = min % 60;
        text1.text = now.Year.ToString() + "年" + now.Month.ToString() + "月" + now.Day + "日     " + texthour + "时" + textmin + "分";
        
    }
}
