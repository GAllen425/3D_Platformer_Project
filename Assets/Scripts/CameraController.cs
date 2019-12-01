using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    public float pitch;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;
    public float rotationSpeed =5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = target.position - offset;
        transform.LookAt(target.position + Vector3.up * 2f * pitch);

        if (Input.GetMouseButton(1))
        {
            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

                offset = camTurnAngle * offset;
            }

            if (lookAtPlayer || rotateAroundPlayer)

            {
                transform.LookAt(target);
            }
            
        }
    }
}
