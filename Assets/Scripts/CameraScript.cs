using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    public void Zoom_plus()
    {
        cam.orthographicSize = cam.orthographicSize + 1;
    }
    public void Zoom_minus()
    {
        cam.orthographicSize = cam.orthographicSize - 1;
    }
    public void x_plus()
    {
        transform.position = new Vector3(transform.position.x +1f, transform.position.y, transform.position.z);
    }
    public void x_minus()
    {
        transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
    }
    public void y_plus()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }
    public void y_minus()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
    }
}
