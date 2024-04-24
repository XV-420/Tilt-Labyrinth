using System;
using System.IO.Compression;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TiltControls : MonoBehaviour
{
    [SerializeField] private UIEventChannelSO uiEventChannel;

    private Rigidbody ballRigidBody;

    [Header("Controls")]
    [SerializeField] private float speed = 200.0f;
 
    [Header("Jump Controls")]
    [SerializeField] private LayerMask m_LayerMask;
    [SerializeField] private float jumpSpeed = 15.0f;
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

        if (jumpEnable)
        {
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);

            if (hitColliders.Length > 0)
            {
                //check if there is y input and double
                if (fixedTilt.y > 0.0f)
                {
                   ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x,jumpSpeed, ballRigidBody.velocity.z);
                }
                
            }
            else fixedTilt = Vector3.zero;

        }
        fixedTilt.y = 0.0f;


        
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

    public void ZeroVelocity()
    {
        ballRigidBody.velocity = Vector3.zero;
    }
    
    

    private void OnEnable()
    {
        uiEventChannel.OnCalibrate += CalibrateAccelerometer;
    }
    private void OnDisable()
    {
        uiEventChannel.OnCalibrate -= CalibrateAccelerometer;
    }

    
    
}



