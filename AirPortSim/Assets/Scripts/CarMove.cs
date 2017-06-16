using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMove : MonoBehaviour {
    public float maxTorque = 500f;      //设置轮子最大速度
    public WheelCollider[] wheelColliders = new WheelCollider[4];   //在面板中创建4个轮子碰撞器
    public Transform[] tireMesh = new Transform[4];   //声明4个模型中轮子的Transform属性
    public GameObject HandDrivingCar;

    public AudioSource audioSource;     //在面板中创建音源
    private bool audioflag = true;    //音频的一个Flag，用来确定是否开始或停止播放

    private void OnEnable()
    {
        audioflag = true;
        audioSource.volume = 0;
        WheelColliderSet(HandDrivingCar);

    }
    void Start()
    {
        
    }

    public void WheelColliderSet(GameObject parentCar)//调用定义的递归方法设置轮子碰撞器  根据父物体设置轮子模型网格面
    {
        wheelColliders[0] = FindOBJ.findit(parentCar, "FL").GetComponent<WheelCollider>();
        wheelColliders[1] = FindOBJ.findit(parentCar, "FR").GetComponent<WheelCollider>();
        wheelColliders[2] = FindOBJ.findit(parentCar, "BL").GetComponent<WheelCollider>();
        wheelColliders[3] = FindOBJ.findit(parentCar, "BR").GetComponent<WheelCollider>();

        tireMesh[0] = FindOBJ.findit(parentCar, "fl_wheel").transform;
        tireMesh[1] = FindOBJ.findit(parentCar, "fr_wheel").transform;
        tireMesh[2] = FindOBJ.findit(parentCar, "rl_wheel").transform;
        tireMesh[3] = FindOBJ.findit(parentCar, "rr_wheel").transform;
    }


    /// <summary>
    /// 引擎声音播放
    /// 
    /// 接收输入，获得正向值，则开始播放声音
    /// 若之前正在播放，则不执行
    /// 若音源音量降到零，则停止播放，并设置Flag值为反
    /// 若音源音量大于0，则开始播放
    /// 
    /// </summary>
    void EnginSound()
    {
        if (Input.GetAxis("Vertical") != 0 && audioflag == true)
        {
            audioSource.Play();
            audioSource.volume = 1;
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

    void Update ()//每一帧更新轮子位置，并检测引擎音效
    {
        UpdateMeshPos();
        EnginSound();
	}

    private void FixedUpdate()//
    {
        float steer = Input.GetAxis("Horizontal");//根据输入轴向确定轮子旋转
        float accelerate = Input.GetAxis("Vertical");//根据输入轴向确定轮子正反转

        float finalAngle = steer * 40f;//最终旋转角40度
        wheelColliders[0].steerAngle = finalAngle;
        wheelColliders[1].steerAngle = finalAngle;//前俩轮的旋转角度等于刚刚定义的最终角度

        for (int i = 0; i < 4; i++)
        {
            wheelColliders[i].motorTorque = accelerate * maxTorque;//四个轮子旋转到最大速度
        }
    }
    void UpdateMeshPos()//改变轮子模型的旋转以及位置
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out quat);

            tireMesh[i].position = pos;
            tireMesh[i].rotation = quat;
        }
    }
}
