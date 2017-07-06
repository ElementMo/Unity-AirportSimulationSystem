using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public GameObject[] cams;
    public GameObject TowerCam;
    public GameObject panel;
	// Use this for initialization
	void Start () {
        foreach (GameObject cam in cams)
        {
            cam.SetActive(false);
        }
        cams[0].SetActive(true);
	}//禁用掉除天顶摄像机外的所有相机

    public void StartGameEnterTower()
    {
        TowerCam.SetActive(true);
        cams[0].SetActive(false);
        panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
