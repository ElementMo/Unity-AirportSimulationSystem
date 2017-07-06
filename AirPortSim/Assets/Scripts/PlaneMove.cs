using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneMove : MonoBehaviour
{
   
    public float maxTorque = 2000f;
    public WheelCollider[] wheelColliders = new WheelCollider[5];

    public AudioSource audioSource;
    private bool audioflag = true;

    // Use this for initialization
    void Start()
    {
        
    }
    private void OnEnable()
    {
        audioflag = true;
        audioSource.volume = 0;
    }
    void EnginSound()
    {
        if (Input.GetAxis("Vertical") != 0 && audioflag == true)
        {
            audioSource.Play();
            audioflag = false;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            audioSource.volume -= Time.deltaTime * 0.2f;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            audioSource.volume += Time.deltaTime * 0.3f;
        }
        if (audioSource.volume == 0 && audioflag == false)
        {
            audioSource.Stop();
            audioflag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnginSound();
    }

    private void FixedUpdate()
    {
       
        float steer = Input.GetAxis("Horizontal");
        float accelerate = Input.GetAxis("Vertical");
       
       
        float finalAngle = steer * 40f;
        wheelColliders[0].steerAngle = finalAngle;
        
        for (int i = 0; i < 4; i++)
        {
            wheelColliders[i].motorTorque = accelerate * maxTorque;
        }
    }

}
