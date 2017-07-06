using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfFly : MonoBehaviour {

    public GameObject TargetAir;//目标飞机
    public Transform waypoint;//路径点集合
    private List<Transform> nodes;//声明路径节点
    private int currentNode = 0;//记录当前目标节点
    public float MaxMoveSpeed = 10.0f;//设置最大速度

    void Start()
    {
        Transform[] waypointTransform = waypoint.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < waypointTransform.Length; i++)
        {
            if (waypointTransform[i] != waypoint.transform)
            {
                nodes.Add(waypointTransform[i]);
            }

            Debug.Log(waypointTransform.Length);

        }


    }

    void Update()
    {


    }
    private void FixedUpdate()
    {

        ApplySteer();
        CheckNodeDistance();
        Move();
    }

    //计算飞机和node的相对向量方向
    private void ApplySteer()
    {
        //Vector3 relativeVector = TargetAir.transform.InverseTransformPoint(nodes[currentNode].position);
        //float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
    }


    //飞机到达目标node时，切换目标
    private void CheckNodeDistance()
    {
        if (Vector3.Distance(TargetAir.transform.position, nodes[currentNode].position) < 13f)
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
    }
    private void Move()
    {
        if (TargetAir.transform.position != nodes[currentNode].position)
        {
            TargetAir.transform.LookAt(nodes[currentNode].position);
            TargetAir.transform.Translate(Vector3.forward * Time.deltaTime * 50f);
        }

        Debug.Log(TargetAir.transform.position);
    }

}
