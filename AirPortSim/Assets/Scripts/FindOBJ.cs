using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindOBJ {


    /// <summary>
    /// 递归查找父物体下的子物体
    /// </summary>
    /// <param name="parent">每次向下寻找到的相对父物体</param>
    /// <param name="childName">目标物体名称</param>
    /// <returns>返回一个GameObject类的物体</returns>
    public static GameObject findit(GameObject parent,string childName)
    {
        if (parent.name == childName)
        {
            return parent;
        }
        if (parent.transform.childCount<1)
        {
            return null;
        }
        GameObject obj = null;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject go = parent.transform.GetChild(i).gameObject;

            obj = findit(go, childName);
            if (obj != null)
            {
                break;
            }
        }
        return obj;
    }

}
