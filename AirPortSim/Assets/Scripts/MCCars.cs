using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCCars : MonoBehaviour {
    private CarMove cm = new CarMove();
    public GameObject AutoPilotCar;

    void Start()
    {
        cm.WheelColliderSet(AutoPilotCar);
    }

    //private void WheelColliderSet()//调用定义的递归方法设置轮子碰撞器  根据父物体设置轮子模型网格面
    //{
    //    wheelColliders[0] = FindOBJ.findit(parentCar, "FL").GetComponent<WheelCollider>();
    //    wheelColliders[1] = FindOBJ.findit(parentCar, "FR").GetComponent<WheelCollider>();
    //    wheelColliders[2] = FindOBJ.findit(parentCar, "BL").GetComponent<WheelCollider>();
    //    wheelColliders[3] = FindOBJ.findit(parentCar, "BR").GetComponent<WheelCollider>();

    //    tireMesh[0] = FindOBJ.findit(parentCar, "fl_wheel").transform;
    //    tireMesh[1] = FindOBJ.findit(parentCar, "fr_wheel").transform;
    //    tireMesh[2] = FindOBJ.findit(parentCar, "rl_wheel").transform;
    //    tireMesh[3] = FindOBJ.findit(parentCar, "rr_wheel").transform;
    //}

    private void FixedUpdate()
    {

        //float finalAngle =0.2f * 40f;//最终旋转角40度
        cm.wheelColliders[0].steerAngle = 10;
        cm.wheelColliders[1].steerAngle = 10;//前俩轮的旋转角度等于刚刚定义的最终角度

        for (int i = 0; i < 4; i++)
        {
            cm.wheelColliders[i].motorTorque = 1 * cm.maxTorque;//四个轮子旋转到最大速度
        }
    }
    // Use this for initialization


}
