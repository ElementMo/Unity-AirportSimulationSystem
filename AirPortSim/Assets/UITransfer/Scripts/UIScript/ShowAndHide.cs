using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour {

    public GameObject targetOne;

    private bool flag = true;

    public void HideAndShow()
    {
        targetOne.SetActive(flag);

        flag = !flag;
        Debug.Log("自定义类");
    }





    void Start () {
		
	}
	void Update () {
        
	}
}
