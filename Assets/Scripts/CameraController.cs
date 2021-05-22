using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform target;

    private float cameraDistance = 2f;
    private float cameraHeight = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void LateUpdate()
    {
        transform.position = target.position - target.forward * cameraDistance;
        transform.LookAt(target.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraHeight, transform.position.z);
    }

    public float GetCameraDistance() => cameraDistance;
}
