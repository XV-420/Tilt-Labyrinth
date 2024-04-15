using System;
using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{

    private Rigidbody ballRigidBody;

    [Header("Controls")]
    [SerializeField] private float speed = 200.0f;
    [SerializeField] private float jumpSpeed = 200.0f;
    [SerializeField] private bool jumpEnable = false;

    [Header("True cancels out all XZ, False cancels out XZ Input, leaves current velocity")]
    [SerializeField] private bool inputCancelOrVelocityCancel = true;
    [SerializeField] private float heightOfInputCancelation = 1.5f;
    [SerializeField] private float maxJumpSpeed = 5.0f;

    [SerializeField] private Transform lowBoundsForJump;
    
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

        if (jumpEnable)
        {
            //check jump velocity and clamp
            if (ballRigidBody.velocity.y > maxJumpSpeed)
                ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x,maxJumpSpeed, ballRigidBody.velocity.z);
            
            //check if there is y input and double
            if (fixedTilt.y > 0.0f)
            {
                fixedTilt.y *= jumpSpeed;
            }

            //if off the board remove xz input or velocity
            if (transform.position.y >lowBoundsForJump.position.y + heightOfInputCancelation)
            {
                //checks on height
                if (!inputCancelOrVelocityCancel)
                    fixedTilt = new Vector3(0, fixedTilt.y, 0);
                else
                    ballRigidBody.velocity = new Vector3(0, ballRigidBody.velocity.y, 0);
            }
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
        lowBoundsForJump = GetComponent<Ball>().GetLowBounds();
    }

    public void ZeroVelocity()
    {
        ballRigidBody.velocity = Vector3.zero;
    }
    
    
}



