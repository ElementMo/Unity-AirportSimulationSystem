using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeText : MonoBehaviour {
    public moveIt car;
    private Text text1;

    
	// Use this for initialization
	void Start () {
        text1 = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text1.text = "\n小方块位置:" + car.returnPos();

	}
}
