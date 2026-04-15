using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed = 3f;
    public Transform cameraTarget;
    
    void Update()
    {
        Vector3 newPos = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, cameraSpeed*Time.deltaTime);
    }
}
