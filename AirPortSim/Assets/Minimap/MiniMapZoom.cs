using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapZoom : MonoBehaviour {
    public Camera cam;

    public void ZoomIn()
    {
        cam.orthographicSize += 5;
    }
    public void ZoomOut()
    {
        cam.orthographicSize -= 5;
    }
}
