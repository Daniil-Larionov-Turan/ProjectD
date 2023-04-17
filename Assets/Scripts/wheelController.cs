using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{

    [SerializeField] WheelCollider frontRightCol;
    [SerializeField] WheelCollider frontLeftCol;
    [SerializeField] WheelCollider rearRightCol;
    [SerializeField] WheelCollider rearLeftCol;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space)) currentBreakForce = breakingForce;
        else currentBreakForce = 0f;

        frontRightCol.motorTorque = currentAcceleration;
        frontLeftCol.motorTorque = currentAcceleration;

        frontRightCol.brakeTorque = currentBreakForce;
        frontLeftCol.brakeTorque = currentBreakForce;
        rearRightCol.brakeTorque = currentBreakForce;
        rearLeftCol.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeftCol.steerAngle = currentTurnAngle;
        frontRightCol.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeftCol, frontLeftTransform);
        UpdateWheel(frontRightCol, frontRightTransform);
        UpdateWheel(rearRightCol, rearRightTransform);
        UpdateWheel(rearLeftCol, rearLeftTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);
        trans.position = position;
        trans.rotation = rotation;
    }
}
