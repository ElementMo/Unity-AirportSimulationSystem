using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextChange : MonoBehaviour {
    public Text text1;
    public Slider slider1;
    private int min,texthour,textmin;

    public void ChangeTime()
    {
        min = (int)slider1.value*4;
        texthour = 6 + min / 60;
        textmin = min % 60;
        text1.text = texthour + "时" + textmin + "分";
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
