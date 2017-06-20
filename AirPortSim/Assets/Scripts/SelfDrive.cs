using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDrive : MonoBehaviour {
    public GameObject TargetCar;//目标小车
    public Transform waypoint;//路径点集合
    public float maxSteerAngle = 70f;//最大转向角
    public float turnSpeed = 5f;//转向速度
    public float maxTorque = 400;//最大车辆行驶速度

    [Header("Sensors")]//传感器变量声明
    public float sensorLength = 25f;//传感器感知距离
    public Vector3 frontSensorPos = new Vector3(0f, 1f, 0.5f);//传感器偏移量
    public float frontSideSensorPos = 1.2f;//前侧左右传感器偏移量
    public float frontSensorAngle = 20f;//侧向传感器偏移角度
    private float targetSteerAngle = 0f;


    private List<Transform> nodes;//声明路径节点
    private int currentNode = 0;//记录当前目标节点
    private bool avoiding;//是否避障
    private bool isStuck = false;//是否卡住
    private float countdown = 10f;//卡住后的计时器
    private float countdownEngine = 1f;//引擎倒退时长


    private WheelCollider FR;
    private WheelCollider FL;
    private WheelCollider BL;
    private WheelCollider BR;//查找四个轮子碰撞器

    private Transform TireFL;
    private Transform TireFR;//查找前轮模型

    private float minV = 0.001f;

	// Use this for initialization
	void Start ()
    {
        Transform[] waypointTransform = waypoint.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < waypointTransform.Length; i++)
        {
            if (waypointTransform[i] != waypoint.transform)
            {
                nodes.Add(waypointTransform[i]);
            }
        }

        FL = FindOBJ.findit(TargetCar, "FL").GetComponent<WheelCollider>();
        FR = FindOBJ.findit(TargetCar, "FR").GetComponent<WheelCollider>();
        BL = FindOBJ.findit(TargetCar, "BL").GetComponent<WheelCollider>();
        BR = FindOBJ.findit(TargetCar, "BR").GetComponent<WheelCollider>();

        TireFR = FindOBJ.findit(TargetCar, "fr_wheel").GetComponent<Transform>();
        TireFL = FindOBJ.findit(TargetCar, "fl_wheel").GetComponent<Transform>();


    }
	
	void Update () {
		
	}
    private void FixedUpdate()
    {

        ApplySteer();
        Engine(maxTorque);
        UpdateMeshPos();
        CheckNodeDistance();
        Sensors();
        LerpToSteerAngle();
        
    }

    private void ApplySteer()//计算车和node的相对向量方向
    {
        Vector3 relativeVector = TargetCar.transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude)*maxSteerAngle;
        targetSteerAngle = newSteer;
        //FL.steerAngle = newSteer;
        //FR.steerAngle = newSteer;
    }

    void UpdateMeshPos()//改变轮子模型的旋转以及位置
    {
        Quaternion quat;
        Vector3 pos;
        
        FL.GetWorldPose(out pos, out quat);

        TireFL.position = pos;
        TireFL.rotation = quat;

        FR.GetWorldPose(out pos, out quat);
        TireFR.position = pos;
        TireFR.rotation = quat;
    }

    private void Engine(float Torque)
    {
        FL.motorTorque = Torque;
        FR.motorTorque = Torque;
        BL.motorTorque = Torque;
        BR.motorTorque = Torque;
    }//启动引擎

    private void CheckNodeDistance()
    {
        if (Vector3.Distance(TargetCar.transform.position, nodes[currentNode].position) < 13f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }//小车到达目标node时，切换目标

    private void Sensors()//车辆传感器
    {
        
        RaycastHit hit;//碰撞检测射线
        Vector3 sensorStartPos = TargetCar.transform.position;
        Vector3 doorSensor = TargetCar.transform.position;
        doorSensor += TargetCar.transform.up * frontSensorPos.y;
        doorSensor += TargetCar.transform.forward * frontSensorPos.z;
        sensorStartPos += TargetCar.transform.forward * frontSensorPos.z;
        sensorStartPos += TargetCar.transform.up * frontSensorPos.y;

        float avoidMultiplyer = 0f;//避让转向叠加器
        avoiding = false;

        //右门传感器
        if (Physics.Raycast(doorSensor, TargetCar.transform.right, out hit, sensorLength/5))
        {
            Debug.DrawLine(doorSensor, hit.point);
            avoiding = true;
            avoidMultiplyer = -1f;
        }

        //左门传感器
        if (Physics.Raycast(doorSensor, -TargetCar.transform.right, out hit, sensorLength/5))
        {
            Debug.DrawLine(doorSensor, hit.point);
            avoiding = true;
            avoidMultiplyer = 1f;
        }

        //右侧传感器
        sensorStartPos += TargetCar.transform.right * frontSideSensorPos;
        if (Physics.Raycast(sensorStartPos, TargetCar.transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            avoiding = true;
            avoidMultiplyer -= 1;
        }
        //右偏传感器
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, TargetCar.transform.up) * TargetCar.transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            avoiding = true; ;
            avoidMultiplyer -= 0.5f;


        }


        //左侧传感器
        sensorStartPos -= TargetCar.transform.right * frontSideSensorPos * 2 ;
        if (Physics.Raycast(sensorStartPos, TargetCar.transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            avoiding = true;
            avoidMultiplyer += 1;
        }
        //左偏传感器
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, TargetCar.transform.up) * TargetCar.transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            avoiding = true;
            avoidMultiplyer += 0.5f;
        }

        //正前传感器
        sensorStartPos += TargetCar.transform.right * frontSideSensorPos ;
        if (avoidMultiplyer == 0f)
        {
            if (Physics.Raycast(sensorStartPos, TargetCar.transform.forward, out hit, sensorLength))
            {
                //Engine(maxTorque * -1f);
                avoiding = true;
                if (hit.normal.x < 0)
                {
                    avoidMultiplyer = 0.5f;
                }
                else
                {
                    avoidMultiplyer = -0.5f;
                }
                Debug.DrawLine(sensorStartPos, hit.point);
            }
            
        }

        if (avoiding)
        {
            targetSteerAngle = maxSteerAngle * avoidMultiplyer;

            Stuck();//卡边警告器
            if (isStuck == true)
            {
                avoidMultiplyer = 0;
                Engine(-400f);
                countdownEngine -= Time.deltaTime;
                if (countdownEngine < 0)
                {
                    countdownEngine = 0;
                }
                if (countdownEngine == 0)
                {
                    countdownEngine = 1f;
                }
            }
        }
        if (!avoiding)
        {
            isStuck = false;
        }
    }

    private void LerpToSteerAngle()//平缓转向车轮
    {
        FL.steerAngle = Mathf.Lerp(FL.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        FR.steerAngle = Mathf.Lerp(FR.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);

    }

    
    
    private void Stuck()//车子卡住数秒之后，执行警告
    {
        countdown -= Time.deltaTime;
        if (countdown < 0)
        {
            countdown = 0;
        }
        if (countdown == 0)
        {
            isStuck = true;
            //Debug.Log("Stucked");
            countdown = 10f;
        }
        
    }
}
