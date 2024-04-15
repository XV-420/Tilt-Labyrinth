using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Position for where the ball is reset to when reset is called")]
    [SerializeField] private GameObject spawnPos;
    [SerializeField] Quaternion hi;
    [SerializeField] Vector3 fast;
    Gyroscope gyro;
    private Vector3 simulatedRotation;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        GyroManager.Instance.EnableGyro();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { 
            simulatedRotation.x +=  100 * Time.deltaTime;
         }
        if (Input.GetKeyDown(KeyCode.S))
        {
            simulatedRotation.x -= 100 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            simulatedRotation.z -= 100 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            simulatedRotation.z += 100* Time.deltaTime;
        }
        
        gyro = Input.gyro;
       

        transform.localRotation = hi * new Quaternion(0, 0, 1, 0);

        Vector3 acceleration = simulatedRotation;
        Vector3 gyroDir = -transform.up;
        float x = -acceleration.x * 0.9f;
        float z = -acceleration.z * 0.9f;
        acceleration.x += x;
        acceleration.z += z;
        Debug.Log("Accel: " + acceleration + " Gyro: " + gyroDir);

        transform.position += (acceleration - gyroDir) * Time.deltaTime;
    }
    /// <summary>
    ///function to move the ball aroundd gyro 
    /// </summary>
    //function to reset the ball to certain
    public void tiltball()
    {
        Quaternion worldRotation = GyroManager.Instance.GetGyroRotation();

        // make the rotation relative to the local rotation rather than the world
        Quaternion localRotation = GyroManager.Instance.GetGyroReferenceRotation() * worldRotation;

        Vector3 euler = localRotation.eulerAngles;

        


        Quaternion zRotation = Quaternion.AngleAxis(euler.z, Vector3.forward);

        zRotation = new Quaternion(zRotation.x, zRotation.y, zRotation.z, 0.0f);
        // reverse the rotation about the z-axis
        localRotation = Quaternion.Inverse(zRotation) * localRotation;

        localRotation = new Quaternion(localRotation.x, localRotation.z, localRotation.y, -localRotation.w);

        Vector3 localRotationEuler = localRotation.eulerAngles;

        //make y the same always
        localRotationEuler.y = -localRotationEuler.normalized.y;


        //reverse z by the x so its rotation doesn't change when x is clamped FIX
        
        

    }
    public void ResetBall()
    {
        transform.position = spawnPos.transform.position;
        rigidBody.velocity = Vector3.zero;
    }
}
