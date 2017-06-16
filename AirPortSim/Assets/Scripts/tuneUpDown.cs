using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tuneUpDown : MonoBehaviour {
    public AudioSource audio;
    public Slider sd1;
	// Use this for initialization
	void Start () {
		
	}
	public void TUD()
    {
        audio.volume = sd1.value;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
