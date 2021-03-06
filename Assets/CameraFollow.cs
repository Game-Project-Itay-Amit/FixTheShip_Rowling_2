using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraofffset;

    public float smoothFactor = 0.5f;

    public bool lookAtPlayer = false;

    public bool RotateAroundPlayer = false;

    public float RotationSpeed = 5.0f;


    void Start()
    {
        _cameraofffset = transform.position - PlayerTransform.position;
    }
    void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.right);

            _cameraofffset = camTurnAngle * camTurnAngleY * _cameraofffset;
        }
        Vector3 newPos = PlayerTransform.position + _cameraofffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (lookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
