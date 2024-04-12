using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{

    private Rigidbody ballRigidBody;

    [SerializeField] private float speed = 200.0f;
    [SerializeField] private float jumpSpeed = 200.0f;
    [SerializeField] private bool jumpEnable = false;
    //gets the accelerometer data and uses the calibration data to modify it
    //then applys that using applyforce to the rigidybody
    void Update()
    {
        //get the input
        Vector3 fixedTilt = Input.acceleration;
        //calibrate
        fixedTilt = tiltReference * fixedTilt;
        
        //z = y
        fixedTilt = new Vector3(fixedTilt.x, fixedTilt.z, fixedTilt.y);

        if (jumpEnable && fixedTilt.y > 0.0)
        {
            fixedTilt.y *= jumpSpeed;
        }
        else fixedTilt.y = 0.0f;


        //debugging rays
        Debug.DrawRay(transform.position, fixedTilt * speed * Time.deltaTime, Color.green);
        Debug.DrawRay(transform.position, ballRigidBody.velocity, Color.red);
        
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



