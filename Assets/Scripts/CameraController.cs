using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float rotSpeed = 1.5f;
    
    [SerializeField] private Transform target;

    private float _rotY;
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // float horInput = Input.GetAxis("Horizontal");
        // if (horInput != 0) {
           
        // } else {
        //     _rotY += Input.GetAxis("Mouse X") * rotSpeed *3;
        // }
        if ( _offset != target.position - transform.position) {
            print(target.position - transform.position);
            _rotY += 1 * rotSpeed;
            // Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
            transform.position = target.position - _offset;
            // transform.LookAt(target);
        }

    }
}
