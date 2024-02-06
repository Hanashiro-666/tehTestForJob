using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider FrontLeftWheel, FrontRightWheel, RearLeftWheel, RearRightWheel;
    public Transform FrontLeftT, FrontRightT, RearLeftT, RearRightT;
    public float maxSteerAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 100f;
    public float handbrakeForce = 500f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float handbrake = Input.GetKey(KeyCode.Space) ? handbrakeForce : 0;

        Steer(h);
        Accelerate(v);
        UpdateWheelPoses();
        HandBrake(handbrake);
    }

    void Steer(float amount)
    {
        FrontLeftWheel.steerAngle = maxSteerAngle * amount;
        FrontRightWheel.steerAngle = maxSteerAngle * amount;
    }

    void Accelerate(float amount)
    {
        FrontLeftWheel.motorTorque = motorForce * amount;
        FrontRightWheel.motorTorque = motorForce * amount;
    }

    void UpdateWheelPoses()
    {
        UpdateWheelPose(FrontLeftWheel, FrontLeftT);
        UpdateWheelPose(FrontRightWheel, FrontRightT);
        UpdateWheelPose(RearLeftWheel, RearLeftT);
        UpdateWheelPose(RearRightWheel, RearRightT);
    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }

    void HandBrake(float amount)
    {
        RearLeftWheel.brakeTorque = amount;
        RearRightWheel.brakeTorque = amount;
    }
}

