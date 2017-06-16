using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnly : MonoBehaviour {
    public GameObject target;
    public GameObject original;

    public void ShowTarget()
    {
        try
        {
            
            original.SetActive(false);
        }
        catch (System.Exception)
        {
            Debug.Log("暂未设置original");
        }
        try
        {
            target.SetActive(true);
        }
        catch (System.Exception)
        {

            Debug.Log("暂未设置target");
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
