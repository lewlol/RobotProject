using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    Camera cam;
    float minZoom = 12;
    float maxZoom = 6;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        transform.position = target.transform.position + new Vector3(-40, 35, -40);

        if(Input.GetAxis("Mouse ScrollWheel") > 0 && cam.orthographicSize > maxZoom)
        {
            cam.orthographicSize -= 0.2f;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0 && cam.orthographicSize < minZoom)
        {
            cam.orthographicSize += 0.2f; //fix
        }
    }
}
