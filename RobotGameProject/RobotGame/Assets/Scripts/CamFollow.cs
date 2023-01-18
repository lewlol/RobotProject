using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform target;


    private void Update()
    {
        transform.position = target.transform.position + new Vector3(-38, 30, -38);
    }
}
