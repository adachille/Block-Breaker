using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : MonoBehaviour {

    private Vector3 lowerLeft;
    private Vector3 upperRight;

    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        lowerLeft = camera.ViewportToScreenPoint(new Vector3(0, 0));
        upperRight = camera.ViewportToScreenPoint(new Vector3(1, 1));
    }

    public Vector3 GetLowerLeft() { return lowerLeft; }
    public Vector3 GetUpperRight() { return upperRight; }
}
