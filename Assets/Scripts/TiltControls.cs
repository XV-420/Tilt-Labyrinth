using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{

    private Rigidbody ballRigidBody;

    [SerializeField] private float speed = 200.0f;
    
    //gets the accelerometer data and uses the calibration data to modify it
    //then applys that using applyforce to the rigidybody
    void Update()
    {
        //get the input
        Vector3 fixedTilt = Input.acceleration;
        //calibrate
        fixedTilt = tiltReference * fixedTilt;
 

        //z = y
        fixedTilt.z = fixedTilt.y;
        //no y rotation so zero out
        fixedTilt.y = 0.0f;

        //rigidbody.AddForce(fixedTilt * 200.0f * Time.deltaTime);
        ballRigidBody.AddForce(fixedTilt * speed * Time.deltaTime);
    }
    
    private Quaternion tiltReference;
    
    /// <summary>
    /// Calibrates the phone to its current orientation.
    /// </summary>
    public void CalibrateAccelerometer()
    {
        Vector3 accelerationReference = Input.acceleration;
 
        Quaternion rotateQuaternion = Quaternion.FromToRotation(
            new Vector3(0.0f, 0.0f, -1.0f), accelerationReference);
 
        tiltReference = Quaternion.Inverse(rotateQuaternion);
    }
   
    void Start()
    {
        CalibrateAccelerometer();
        ballRigidBody = GetComponent<Rigidbody>();
    }

}



