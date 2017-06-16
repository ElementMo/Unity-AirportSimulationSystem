using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveIt : MonoBehaviour {

    private string posCombine;
    //public string ss;
	// Use this for initialization
	void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
       
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
            posCombine = "\nx:" + transform.localPosition.x.ToString() + "\ny:" + transform.localPosition.z.ToString();
        }
        else
        {
            posCombine = "不动";
        }
        
        ///*tex*/t.text = posCombine;
    }

    public string returnPos()
    {
        return posCombine;
    }

}